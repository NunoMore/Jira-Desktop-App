using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;

namespace JiraSolution.Services
{
	public class QueryResultReader
	{
		public List<User> ReadUsers(string restQueryResult, List<User> users, Requester requester, int j, string url, BackgroundWorker backgroundWorker)
		{
			string issues = restQueryResult.Substring(restQueryResult.IndexOf("expand") + 7);

			int maxResults = Convert.ToInt32(FindValuesInRestQueryResult("maxResults", restQueryResult));

			if (maxResults > Convert.ToInt32(FindValuesInRestQueryResult("total", restQueryResult)))
			{
				maxResults = Convert.ToInt32(FindValuesInRestQueryResult("total", restQueryResult));
			}

			backgroundWorker.WorkerReportsProgress = true;
			int progress = 0;

			for (int i = 0; i < maxResults; i++)
			{
				progress += i+1;
				try
				{
					issues = issues.Substring(issues.IndexOf("expand") + 7);
				}
				catch (Exception e)
				{
					break;
				}

				if (FindValuesInRestQueryResult("timespent", issues) != "null")
				{
					string issueName = FindValuesInRestQueryResult("key", issues);

					string worklogs = requester.GetWorklogs(url, issueName);

					users = ReadWorklogs(worklogs, users, issueName);

				}

				backgroundWorker.ReportProgress(progress);
			}

			return users;
		}

		public List<User> ReadWorklogs(string worklogs, List<User> users, string issueName)
		{
			int totalWorklogs = Convert.ToInt32(FindValuesInRestQueryResult("total", worklogs));

			for (int t = 0; t < totalWorklogs; t++)
			{
				try
				{
					worklogs = worklogs.Substring(worklogs.IndexOf("author") + 7);
				}
				catch (Exception e)
				{
					continue;
				}

				// Se não existe user cria-se um novo
				if (users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs)) == null)
				{
					User newUser = new User();

					newUser.Name = FindValuesInRestQueryResult("displayName", worklogs);

					WebClient webClient = new WebClient();
					newUser.Photo = webClient.DownloadData(FindValuesInRestQueryResult("48x48", worklogs));

					newUser.Worklog = new Dictionary<string, List<int>>
					{
						{issueName, new List<int>()}
					};

					newUser.Worklog[issueName].Add(Convert.ToInt32(FindValuesInRestQueryResult("timeSpentSeconds", worklogs)));
					users.Add(newUser);
				}
				else // Se existir é necessário atualizar
				{
					// Se o User não contém ainda o issue cria-se um novo
					if (!users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs))
						.Worklog.ContainsKey(issueName))
					{
						users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs))
							.Worklog.Add(issueName, new List<int>());

					}

					users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs))
						.Worklog[issueName].Add(Convert.ToInt32(FindValuesInRestQueryResult("timeSpentSeconds", worklogs)));
				}
			}

			return users;
		}

		public string FindValuesInRestQueryResult(string dataToFind, string restQueryResult)
		{
			try
			{
				int startIndex = restQueryResult.IndexOf(dataToFind);
				string result = restQueryResult.Substring(startIndex + dataToFind.Length + 2, restQueryResult.IndexOf(",", startIndex) - (startIndex + dataToFind.Length + 2));

				if (int.TryParse(result, out int n))
				{
					return result;
				}

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
