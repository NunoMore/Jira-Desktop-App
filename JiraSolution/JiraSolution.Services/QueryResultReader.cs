using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
			var issues = restQueryResult; // restQueryResult.Substring(restQueryResult.IndexOf("fields", StringComparison.Ordinal) + 7);

			var maxResults = Convert.ToInt32(FindValuesInRestQueryResult("maxResults", restQueryResult));

			if (maxResults > Convert.ToInt32(FindValuesInRestQueryResult("total", restQueryResult)))
				maxResults = Convert.ToInt32(FindValuesInRestQueryResult("total", restQueryResult));

			for (var i = 0; i < maxResults; i++)
			{
				if (backgroundWorker.CancellationPending) return null;

				var issueName = FindValuesInRestQueryResult("key", issues);


				if (FindValuesInRestQueryResult("timespent", issues) != "null")
				{
					// var issueName = FindValuesInRestQueryResult("key", issues);

					var worklogs = Requester.GetWorklogs(url, issueName);

					users = ReadWorklogs(worklogs, users, issueName);
				}

				if (FindValuesInRestQueryResult("subtask", restQueryResult) == "true")
				{
					
				}

				try
				{
					issues = issues.Substring(issues.IndexOf("hasVoted", StringComparison.Ordinal) + 7);
				}
				catch (Exception)
				{
					break;
				}

				backgroundWorker.ReportProgress(Progress);
				Progress += 10000 / ProgressStep;
			}

			return users;
		}

		public static List<User> ReadWorklogs(string worklogs, List<User> users, string issueName)
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

				//var d = Convert.ToDateTime(FindValuesInRestQueryResult("started", worklogs));
				//var d2 = Convert.ToDateTime(Requester.EndDate.ToString("yyyy-MM-dd") + " 23:59:59");

				//var s = d < Convert.ToDateTime(Requester.StartDate.ToString());
				//var s2 = Convert.ToDateTime(FindValuesInRestQueryResult("started", worklogs)) > d2 ;

				if (Convert.ToDateTime(FindValuesInRestQueryResult("started", worklogs)) < Convert.ToDateTime(Requester.StartDate.ToString()) ||
				       Convert.ToDateTime(FindValuesInRestQueryResult("started", worklogs)) > Convert.ToDateTime(Requester.EndDate.ToString("yyyy-MM-dd") + " 23:59:59"))
				{
					continue;
				}

				var stringUser = FindValuesInRestQueryResult("displayName", worklogs); 

				// Se não existe user cria-se um novo
				if (users.Find(user => user.Name == stringUser) == null)
				{
					var newUser = new User
					{
						Name = stringUser
					};


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
					if (!users.Find(user => user.Name == stringUser)
						.Worklogs.ContainsKey(issueName))
						users.Find(user => user.Name == stringUser)
							.Worklogs.Add(issueName, new List<int>());

					users.Find(user => user.Name == stringUser)
						.Worklogs[issueName].Add(Convert.ToInt32(FindValuesInRestQueryResult("timeSpentSeconds", worklogs)));
				}
			}

			return users;
		}

		//public static List<string> ReadProjects(string projects)
		//{
		//	List<string> list = new List<string>();

		//	string project = FindValuesInRestQueryResult("key", projects);
		//	projects.Substring(project.IndexOf("expand", StringComparison.Ordinal) + 7);

		//}

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
				// MessageBox.Show(e.Message, "ERROR");
				return null;
			}
		}
	}
}