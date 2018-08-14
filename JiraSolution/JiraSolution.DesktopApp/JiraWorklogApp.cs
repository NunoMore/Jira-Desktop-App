using System;
using System.Windows.Forms;
using JiraSolution.DesktopApp.Services;

namespace JiraSolution.DesktopApp
{
	public partial class JiraWorklogApp : Form
	{
		public JiraWorklogApp()
		{
			InitializeComponent();
		}

		private const string Url = "https://glinttdev.atlassian.net/rest/api/2/";
		// private const string Url2 = "https://glinttdev.atlassian.net/rest/api/2/search?jql=project=B2Bsd";
		// private const string url3 = "https://glinttdev.atlassian.net/rest/api/2/issue/B2BMSFT-66?fields=worklog";

		private GetRequest getRequest = new GetRequest();

		private string username;
		private string password;
		private string projectName;
		private string issueName;


		private void ButtonIssues_Click(object sender, EventArgs e)
		{
			string result = getRequest.Get(Url + "search?jql=project=" + projectName, username, password);
			

		}
		
		private void TextBoxUsername_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			username = s.Text;
		}

		private void TextBoxPassword_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			password = s.Text;
		}


		private void TextBoxIssue_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			issueName = s.Text;
		}

		private void TextBoxProject_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			projectName = s.Text;
		}
	}

}

