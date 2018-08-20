using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using JiraSolution.Domain;
using JiraSolution.Domain.Objects;
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
		private DateTime _startDate;
		private DateTime _endDate;
		private List<User> _users = null;

		private readonly DataGridEditor _dataGridEditor = new DataGridEditor();
		
		private void Button_Click(object sender, EventArgs e)
		{
			progressBar1.Maximum = 100 * 100;
			progressBar1.Step = 1;
			progressBar1.Value = 0;

			backgroundWorker1.RunWorkerAsync();

		}

		private void TextBoxUsername_TextChanged(object sender, EventArgs e)
		{
			TextBox s = sender as TextBox;
			_username = s.Text;
		}

		private void TextBoxPassword_TextChanged(object sender, EventArgs e)
		{
			TextBox s = sender as TextBox;
			_password = s.Text;
		}


		private void TextBoxProject_TextChanged(object sender, EventArgs e)
		{
			TextBox s = sender as TextBox;
			_projectName = s.Text;
		}

		private void TextBoxUser_TextChanged(object sender, EventArgs e)
		{
			TextBox s = sender as TextBox;
			_userName = s.Text;
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			
			Runner runner = new Runner(_username, _password, dataGridIssuesOrWorklog, _projectName, _userName, backgroundWorker);
			_users = runner.Run();
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			if (_users != null && (_users != null || _users.Count != 0))
			{
				_dataGridEditor.PopulateDataGrid(dataGridIssuesOrWorklog, _users);
			}
			progressBar1.Value = progressBar1.Maximum;
			Cursor.Current = Cursors.Default;
		}

		private void EndDatePicker_ValueChanged(object sender, EventArgs e)
		{
			DateTimePicker s = sender as DateTimePicker;
			_endDate = s.Value;
		}

		private void StartDatePicker_ValueChanged(object sender, EventArgs e)
		{
			DateTimePicker s = sender as DateTimePicker;
			_startDate = s.Value;
		}
	}
}

