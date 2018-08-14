using System;

public class GetRequest
{
	public string Get(string uri)
	{
		try
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

			String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
			request.Headers.Add("Authorization", "Basic " + encoded);

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			StreamReader reader = new StreamReader(response.GetResponseStream());

			return reader.ReadToEnd();

		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message, "ERROR");
			return null;
		}

	}
}
