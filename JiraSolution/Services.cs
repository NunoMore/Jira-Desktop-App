﻿using System;

public class Services
{

	private const string URL = "https://glinttdev.atlassian.net/rest/api/2/search?jql=project=B2Bsd";
	private string urlParameters = "?api_key=123";

	public Class1()
	{

		HttpClient client = new HttpClient();
		client.BaseAddress = new Uri(URL);

		// Add an Accept header for JSON format.
		client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

		// List data response.
		HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
		if (response.IsSuccessStatusCode)
		{
			// Parse the response body.
			var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
			foreach (var d in dataObjects)
			{
				Console.WriteLine("{0}", d.Name);
			}
		}
		else
		{
			Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
		}


		client.Dispose();
	}
}
