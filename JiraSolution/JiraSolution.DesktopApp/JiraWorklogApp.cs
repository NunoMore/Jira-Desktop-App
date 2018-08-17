using System;
using System.Windows.Forms;
using JiraSolution.Domain;
using DataGrid = JiraSolution.Domain.DataGridEditor;

namespace JiraSolution.DesktopApp
{
	public partial class JiraWorklogApp : Form
	{
		public JiraWorklogApp()
		{
			InitializeComponent();
		}

		private DataGridEditor dataGridEditor = new DataGridEditor();

		private string username;
		private string password;
		private string projectName;
		private string userName;

		private void ButtonUsers_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			dataGridEditor.PopulateDataGrid(dataGridIssuesOrWorklog, username, password, projectName, userName);
			Cursor.Current = Cursors.Default;
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


		private void TextBoxProject_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			projectName = s.Text;
		}

		private void TextBoxUser_TextChanged(object sender, EventArgs e)
		{
			TextBox s = (TextBox)sender;
			userName = s.Text;
		}
	}
}

