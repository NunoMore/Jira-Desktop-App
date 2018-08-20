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

		public Requester(string username, string password)
		{
			_username = username;
			_password = password;
		}

		public string GetFirstIssues(string uri, string projectName)
		{
			return Get(uri + "search?jql=project=" + projectName + " AND updated >= '2018-08-01' AND updated <= '2018-08-20'", _username, _password);
		}

		public string GetMoreIssues(string uri, string projectName, int startAt)
		{
			return Get(uri + "search?jql=project=" + projectName + "&startAt=" + startAt + " AND updated >= '2018-08-01' AND updated <= '2018-08-20'", _username, _password);
		}

		public string GetWorklogs(string uri, string issueName)
		{
			return Get(uri + "issue/" + issueName + "?fields=worklog", _username, _password);
		}

		private static string Get(string uri, string username, string password)
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
