using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace JiraSolution.Services
{
	public static class Requester
	{
		public static string Username;
		public static string Password;
		public static string ProjectName;
		public static string UserName;
		public static DateTime StartDate = Convert.ToDateTime("2018-01-01");
		public static DateTime EndDate = Convert.ToDateTime("2018-07-31");


		public static string GetIssues(string uri, int startAt)
		{
			return Get(uri + "search?jql=project=" + ProjectName + " AND worklogDate  >= '" + StartDate.ToString("yyyy-MM-dd") + "' AND worklogDate <= '" + EndDate.ToString("yyyy-MM-dd") + "'" + "& startAt=" + startAt + " & maxResults=100");
		}

		public static string GetWorklogs(string uri, string issueName)
		{
			return Get(uri + "issue/" + issueName + "/worklog");
		}

		public static string GetProjects(string uri)
		{
			return Get(uri + "project");
		}

		private static string Get(string uri)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

				String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Username + ":" + Password));
				request.Headers.Add("Authorization", "Basic " + encoded);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				using (StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
				{
					string result = reader.ReadToEnd();
					return result;
				} 
			}
			catch (Exception e)
			{
				if (!e.Message.Contains("(404)"))
				{
					MessageBox.Show(e.Message, "ERROR");
				}
				return null;
			}

		}
	}
}
