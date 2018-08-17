using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

		private readonly DataGridEditor _dataGridEditor = new DataGridEditor();
		private readonly QueryResultReader _queryResultReader = new QueryResultReader();

		private const string Url = "https://glinttdev.atlassian.net/rest/api/latest/";

		public Runner(string username, string password, DataGridView dataGridIssuesOrWorklog, string projectName,
			string userName)
		{
			_username = username;
			_password = password;
			_dataGridIssuesOrWorklog = dataGridIssuesOrWorklog;
			_projectName = projectName;
			_userName = userName;
		}

		public void Run()
		{
			Requester requester = new Requester(_username, _password);

			_users.Clear();

			string restQueryResult = requester.GetFirstIssues(Url, _projectName);

			int maxIssues = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("total", restQueryResult));
			int maxResults = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("maxResults", restQueryResult));

			int startAt = 0;
			int maxPages = (maxIssues + maxResults + 1) / maxResults;

			for (int i = 0; i < maxPages; i++)
			{
				_users = GetUsers(restQueryResult, _users, requester);

				if (startAt + maxResults < maxIssues)
				{
					startAt += maxResults;
					restQueryResult = requester.GetMoreIssues(Url, _projectName, startAt);
					_users = GetUsers(restQueryResult, _users, requester);
				}
			}

			_users.ForEach(x=> x.UpdateTotalWorklog());

			_dataGridEditor.PopulateDataGrid(_dataGridIssuesOrWorklog, restQueryResult, _users);
		}

		private List<User> GetUsers(string restQueryResult, List<User> users, Requester requester)
		{
			string issues = restQueryResult.Substring(restQueryResult.IndexOf("expand") + 7);

			int maxResults = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("maxResults", restQueryResult));

			for (int i = 0; i < maxResults; i++)
			{
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
			}

			// users.ForEach(x => x.UpdateTotalWorklog());

			return users;
		}
	}
}
