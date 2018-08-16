using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;
using JiraSolution.Services;

namespace JiraSolution.Domain
{
	public class DataGridEditor
	{
		private Requester _requester = new Requester();
		private BindingSource _bindingSource = new BindingSource();
		private List<User> users = new List<User>();

		private string _username;
		private string _password;
		private string _projectName;
		private string _userName;

		private const string Url = "https://glinttdev.atlassian.net/rest/api/latest/";

		public void PopulateDataGrid(DataGridView dataGridIssuesOrWorklog, string username, string password, string projectName, string userName)
		{
			_username = username;
			_password = password;
			_projectName = projectName;
			_userName = userName;

			string restQueryResult = _requester.Get(Url + "search?jql=project=" + _projectName, _username, _password);

			if (!string.IsNullOrEmpty(restQueryResult))
			{
				int maxIssues = Convert.ToInt32(findValuesInRestQueryResult('"' + "total" + '"' + ": ", restQueryResult));
				int maxResults = Convert.ToInt32(findValuesInRestQueryResult('"' + "maxResults" + '"' + ": ", restQueryResult));

				int startAt = 0;
				int maxPages = (maxIssues + maxResults + 1) / maxResults;

				for (int i = 0; i < maxPages; i++)
				{
					users = getUsers(restQueryResult, users);

					if (startAt + maxResults < maxIssues)
					{
						startAt += maxResults;

						restQueryResult = _requester.Get(Url + "search?jql=project=" + _projectName + "&startAt=" + startAt, _username, _password);
					}
				}

				foreach (User user in users)
				{
					_bindingSource.Add(user);
				}

				dataGridIssuesOrWorklog.Columns.Clear();
				dataGridIssuesOrWorklog.AutoGenerateColumns = false;
				dataGridIssuesOrWorklog.AutoSize = true;
				dataGridIssuesOrWorklog.DataSource = _bindingSource;
			}
			
		}

		private List<User> getUsers(string restQueryResult, List<User> users)
		{
			string issues = restQueryResult.Substring(restQueryResult.IndexOf('"' + "expand" + '"' + ": ") + 7);
			
			int maxResults = Convert.ToInt32(findValuesInRestQueryResult('"' + "maxResults" + '"' + ": ", restQueryResult));


			for (int i = 0; i < maxResults; i++)
			{
				try
				{
					issues = issues.Substring(issues.IndexOf('"' + "expand" + '"' + ": ") + 7);
				}
				catch (Exception e)
				{
					break;
				}

				if (findValuesInRestQueryResult('"' + "timespent" + '"' + ": ", issues) != "null")
				{
					string issueName = findValuesInRestQueryResult('"' + "key" + '"' + ": ", issues);
					issueName = issueName.Substring(1, issueName.Length-2);

					string worklogs = _requester.Get(Url + "issue/" + issueName + "?fields=worklog", _username, _password);

					int maxResultsWorklogs = Convert.ToInt32(findValuesInRestQueryResult('"' + "maxResults" + '"' + ": ", worklogs));

					for (int t = 0; t < maxResultsWorklogs; t++)
					{
						try
						{
							worklogs = worklogs.Substring(worklogs.IndexOf('"' + "author" + '"' + ": ") + 7);
						}
						catch (Exception e)
						{
							continue;
						}

						Worklog newWorklog = new Worklog();

						newWorklog.Id = findValuesInRestQueryResult('"' + "id" + '"' + ": ", worklogs);
						newWorklog.IssueName = issueName;
						newWorklog.Description = findValuesInRestQueryResult('"' + "comment" + '"' + ": ", worklogs);
						newWorklog.LogTime = Convert.ToDouble(findValuesInRestQueryResult('"' + "timeSpentSeconds" + '"' + ": ", worklogs));
						
						User newUser = new User();

						if (users.Find(user => user.Name == findValuesInRestQueryResult('"' + "displayName" + '"' + ": ", worklogs)) == null)
						{
							newUser.Name = findValuesInRestQueryResult('"' + "displayName" + '"' + ": ", worklogs);
							newUser.Photo = findValuesInRestQueryResult('"' + "48x48" + '"' + ": ", worklogs);
							newUser.TotalWorklog = Convert.ToDouble(findValuesInRestQueryResult('"' + "timeSpentSeconds" + '"' + ": ", worklogs));
							users.Add(newUser);
						}
						else
						{
							newUser = users.Find(
								user => user.Name == findValuesInRestQueryResult('"' + "displayName" + '"' + ": ", worklogs));
							users.Find(
									user => user.Name == findValuesInRestQueryResult('"' + "displayName" + '"' + ": ", worklogs)).TotalWorklog +=
								Convert.ToDouble(findValuesInRestQueryResult('"' + "timeSpentSeconds" + '"' + ": ", worklogs));
						}

						newWorklog.User = newUser;
					}
				}
			}

			return users;
		}
		
		private string findValuesInRestQueryResult(string dataToFind, string restQueryResult)
		{
			try
			{
				int startIndex = restQueryResult.IndexOf(dataToFind);
				string result = restQueryResult.Substring(startIndex + dataToFind.Length, restQueryResult.IndexOf(",", startIndex) - startIndex + dataToFind.Length);
				return result.Substring(1, result.Length - 2);

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "ERROR");
				return null;
			}
		}

	}
}
