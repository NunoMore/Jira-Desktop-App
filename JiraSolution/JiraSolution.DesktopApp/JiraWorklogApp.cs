using System;
using System.ComponentModel;
using System.Windows.Forms;
using JiraSolution.Services;

namespace JiraSolution.DesktopApp
{
	public partial class JiraWorklogApp : Form
	{
		public JiraWorklogApp()
		{
			InitializeComponent();
		}

		private string _username;
		private string _password;
		private string _projectName;
		private string _userName;

		private void ButtonUsers_Click(object sender, EventArgs e)
		{
			Runner runner = new Runner(_username, _password, dataGridIssuesOrWorklog, _projectName, _userName);

			Cursor.Current = Cursors.WaitCursor;


			runner.Run();
			Cursor.Current = Cursors.Default;
		}

		private void TextBoxUsername_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			_username = s.Text;
		}

		private void TextBoxPassword_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			_password = s.Text;
		}


		private void TextBoxProject_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			_projectName = s.Text;
		}

		private void TextBoxUser_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			_userName = s.Text;
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{

		}
	}
}

