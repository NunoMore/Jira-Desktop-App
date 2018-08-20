using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using JiraSolution.Domain;
using JiraSolution.Domain.Objects;

namespace JiraSolution.Services
{
	public class Runner
	{
		private readonly string _username;
		private readonly string _password;
		private readonly string _projectName;
		private readonly string _userName;
		private readonly DataGridView _dataGridIssuesOrWorklog;
		private List<User> _users = new List<User>();
		private readonly BackgroundWorker _backgroundWorker;

		private readonly DataGridEditor _dataGridEditor = new DataGridEditor();
		private readonly QueryResultReader _queryResultReader = new QueryResultReader();

		private const string Url = "https://glinttdev.atlassian.net/rest/api/latest/";

		public Runner(string username, string password, DataGridView dataGridIssuesOrWorklog, string projectName,
			string userName, BackgroundWorker backgroundWorker)
		{
			_username = username;
			_password = password;
			_dataGridIssuesOrWorklog = dataGridIssuesOrWorklog;
			_projectName = projectName;
			_userName = userName;
			_backgroundWorker = backgroundWorker;
		}

		public List<User> Run()
		{
			Requester requester = new Requester(_username, _password);

			_users.Clear();

			string restQueryResult = requester.GetFirstIssues(Url, _projectName);

			if (!string.IsNullOrEmpty(restQueryResult))
			{
				int maxIssues = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("total", restQueryResult));
				int maxResults = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("maxResults", restQueryResult));

				int progressBarCurrentStep = maxIssues;

				int startAt = 0;
				int maxPages = (maxIssues + maxResults + 1) / maxResults;

				for (int i = 0; i < maxPages; i++)
				{
					_users = GetUsers(restQueryResult, _users, requester, progressBarCurrentStep);

					if (startAt + maxResults < maxIssues)
					{
						startAt += maxResults;
						restQueryResult = requester.GetMoreIssues(Url, _projectName, startAt);
						_users = GetUsers(restQueryResult, _users, requester, progressBarCurrentStep);
					}
				}

				_users.ForEach(x => x.UpdateTotalWorklog());

				return _users;

				// _dataGridEditor.PopulateDataGrid(_dataGridIssuesOrWorklog, restQueryResult, _users);
			}

			return null;
		}

		private List<User> GetUsers(string restQueryResult, List<User> users, Requester requester, int j)
		{
			string issues = restQueryResult.Substring(restQueryResult.IndexOf("expand") + 7);

			int maxResults = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("maxResults", restQueryResult));

			if (maxResults > Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("total", restQueryResult)))
			{
				maxResults = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("total", restQueryResult));
			}

			_backgroundWorker.WorkerReportsProgress = true;
			int progress = 0;

			for (int i = 0; i < maxResults; i++)
			{
				progress += j;
				try
				{
					issues = issues.Substring(issues.IndexOf("expand") + 7);
				}
				catch (Exception e)
				{
					break;
				}

				if (_queryResultReader.FindValuesInRestQueryResult("timespent", issues) != "null")
				{
					string issueName = _queryResultReader.FindValuesInRestQueryResult("key", issues);

					string worklogs = requester.GetWorklogs(Url, issueName);

					users = _queryResultReader.ReadWorklogs(worklogs, _users, issueName);
					
				}

				_backgroundWorker.ReportProgress(progress);
			}

			return users;
		}
	}
}
