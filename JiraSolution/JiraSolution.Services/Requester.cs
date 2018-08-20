using System;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace JiraSolution.Services
{
	public class Requester
	{
		private readonly string _username;
		private readonly string _password;
		private readonly string _projectName;
		private readonly string _userName;
		private readonly DateTime _startDate;
		private readonly DateTime _endDate;

		public Requester(string username, string password, string projectName, string userName, DateTime startDate, DateTime endDate)
		{
			_username = username;
			_password = password;
			_projectName = projectName;
			_userName = userName;
			_startDate = startDate;
			_endDate = endDate;
		}

		public string GetIssues(string uri, int startAt)
		{
			return Get(uri + "search?jql=project=" + _projectName + "& startAt=" + startAt + " & updated >= '" + _startDate.ToString("yyyy-MM-dd") + "' & updated <= '" + _endDate.ToString("yyyy-MM-dd") + "'", _username, _password);
		}

		public string GetWorklogs(string uri, string issueName)
		{
			return Get(uri + "issue/" + issueName + "?fields=worklog", _username, _password);
		}

		private string Get(string uri, string username, string password)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

				String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
				request.Headers.Add("Authorization", "Basic " + encoded);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					string result = reader.ReadToEnd();
					return result;
				} 
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "ERROR");
				return null;
			}

		}
	}
}
