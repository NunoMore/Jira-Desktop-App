using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;

namespace JiraSolution.Services
{
	public static class QueryResultReader
	{
		public static int Progress;
		public static int ProgressStep;

		public static List<User> ReadUsers(string restQueryResult, List<User> users, string url,
			BackgroundWorker backgroundWorker)
		{
			var issues = restQueryResult.Substring(restQueryResult.IndexOf("expand", StringComparison.Ordinal) + 7);

			var maxResults = Convert.ToInt32(FindValuesInRestQueryResult("maxResults", restQueryResult));

			if (maxResults > Convert.ToInt32(FindValuesInRestQueryResult("total", restQueryResult)))
				maxResults = Convert.ToInt32(FindValuesInRestQueryResult("total", restQueryResult));

			for (var i = 0; i < maxResults; i++)
			{
				if (backgroundWorker.CancellationPending) return null;

				try
				{
					issues = issues.Substring(issues.IndexOf("expand", StringComparison.Ordinal) + 7);
				}
				catch (Exception)
				{
					break;
				}

				if (FindValuesInRestQueryResult("timespent", issues) != "null")
				{
					var issueName = FindValuesInRestQueryResult("key", issues);

					var worklogs = Requester.GetWorklogs(url, issueName);

					users = ReadWorklogs(worklogs, users, issueName);
				}

				backgroundWorker.ReportProgress(Progress);
				Progress += 10000 / ProgressStep;
			}

			return users;
		}

		private static List<User> ReadWorklogs(string worklogs, List<User> users, string issueName)
		{
			var totalWorklogs = Convert.ToInt32(FindValuesInRestQueryResult("total", worklogs));

			for (var t = 0; t < totalWorklogs; t++)
			{
				try
				{
					worklogs = worklogs.Substring(worklogs.IndexOf("author", StringComparison.Ordinal) + 7);
				}
				catch (Exception)
				{
					continue;
				}

				//if (Convert.ToDateTime(FindValuesInRestQueryResult("started", worklogs)) < Requester.StartDate.ToString("yyyy-MM-dd"))
				//{
					
				//}

				// Se não existe user cria-se um novo
				if (users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs)) == null)
				{
					var newUser = new User();

					newUser.Name = FindValuesInRestQueryResult("displayName", worklogs);

					var webClient = new WebClient();
					newUser.Photo = webClient.DownloadData(FindValuesInRestQueryResult("48x48", worklogs));

					newUser.Worklogs = new Dictionary<string, List<int>>
					{
						{issueName, new List<int>()}
					};

					newUser.Worklogs[issueName].Add(Convert.ToInt32(FindValuesInRestQueryResult("timeSpentSeconds", worklogs)));
					users.Add(newUser);
				}
				else // Se existir é necessário atualizar
				{
					// Se o User não contém ainda o issue cria-se um novo
					if (!users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs))
						.Worklogs.ContainsKey(issueName))
						users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs))
							.Worklogs.Add(issueName, new List<int>());

					users.Find(user => user.Name == FindValuesInRestQueryResult("displayName", worklogs))
						.Worklogs[issueName].Add(Convert.ToInt32(FindValuesInRestQueryResult("timeSpentSeconds", worklogs)));
				}
			}

			return users;
		}

		public static string FindValuesInRestQueryResult(string dataToFind, string restQueryResult)
		{
			try
			{
				var startIndex = restQueryResult.IndexOf(dataToFind, StringComparison.Ordinal);
				var result = restQueryResult.Substring(startIndex + dataToFind.Length + 2,
					restQueryResult.IndexOf(",", startIndex, StringComparison.Ordinal) - (startIndex + dataToFind.Length + 2));

				return int.TryParse(result, out _) ? result : result.Substring(1, result.Length - 2);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "ERROR");
				return null;
			}
		}
	}
}