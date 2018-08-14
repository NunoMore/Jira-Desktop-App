using System;
using System.DirectoryServices;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using JiraSolution.DesktopApp.Domain;

namespace JiraSolution.DesktopApp.Services
{
	class GetRequest
	{
		public string Get(string uri, string username, string password)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

				String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
				request.Headers.Add("Authorization", "Basic " + encoded);

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				StreamReader reader = new StreamReader(response.GetResponseStream());
				string result = reader.ReadToEnd();

				return result;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "ERROR");
				return null;
			}

		}
	}
}
