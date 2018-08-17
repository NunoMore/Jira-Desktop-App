using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;

namespace JiraSolution.Services
{
	public class QueryResultReader
	{
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

				//Worklog newWorklog = new Worklog();

				//newWorklog.Id = FindValuesInRestQueryResult('"' + "id" + '"' + ": ", worklogs);
				//newWorklog.IssueName = issueName;
				//newWorklog.Description = FindValuesInRestQueryResult('"' + "comment" + '"' + ": ", worklogs);
				//newWorklog.LogTime = Convert.ToDouble(FindValuesInRestQueryResult('"' + "timeSpentSeconds" + '"' + ": ", worklogs));

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
