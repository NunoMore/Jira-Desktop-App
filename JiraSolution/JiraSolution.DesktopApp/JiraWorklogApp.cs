using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;
using JiraSolution.Services;
using JiraSolution.Services.WinForm_Services;

namespace JiraSolution.DesktopApp
{
	public partial class JiraWorklogApp : Form
	{
		public JiraWorklogApp()
		{
			InitializeComponent();
		}

		private List<User> _users = new List<User>();
		private const string Url = "https://glinttdev.atlassian.net/rest/api/latest/";

		private void Button_Click(object sender, EventArgs e)
		{
			_users.Clear();

			progressBar1.Maximum = 100 * 100;
			progressBar1.Step = 1;
			progressBar1.Value = 0;

			try
			{
				backgroundWorker1.RunWorkerAsync();
			}
			catch (Exception )
			{
				MessageBox.Show( "Must wait before current call ends...", "WARNING");
			}

		}

		private void TextBoxUsername_TextChanged(object sender, EventArgs e)
		{
			if (sender is TextBox s) Requester.Username = s.Text;
		}

		private void TextBoxPassword_TextChanged(object sender, EventArgs e)
		{
			if (sender is TextBox s) Requester.Password = s.Text;
		}


		private void TextBoxProject_TextChanged(object sender, EventArgs e)
		{
			if (sender is TextBox s) Requester.ProjectName = s.Text;
		}

		private void TextBoxUser_TextChanged(object sender, EventArgs e)
		{
			if (sender is TextBox s) Requester.UserName = s.Text;
		}

		private void StartDatePicker_ValueChanged(object sender, EventArgs e)
		{
			if (sender is DateTimePicker s) Requester.StartDate = s.Value;
		}

		private void EndDatePicker_ValueChanged(object sender, EventArgs e)
		{
			if (sender is DateTimePicker s) Requester.EndDate = s.Value;
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.ReportProgress(0);

			var restQueryResult = Requester.GetIssues(Url, 0);

			if (!string.IsNullOrEmpty(restQueryResult))
			{
				var maxIssues = Convert.ToInt32(QueryResultReader.FindValuesInRestQueryResult("total", restQueryResult));
				var maxResults = Convert.ToInt32(QueryResultReader.FindValuesInRestQueryResult("maxResults", restQueryResult));

				QueryResultReader.ProgressStep = maxIssues;

				var startAt = 0;
				var maxPages = (maxIssues + maxResults + 1) / maxResults;

				for (var i = 0; i < maxPages; i++)
				{
					if (QueryResultReader.ReadUsers(restQueryResult, _users, Url, backgroundWorker1) == null)
					{
						e.Cancel = true;
						return;
					}

					_users = QueryResultReader.ReadUsers(restQueryResult, _users, Url, backgroundWorker1);

					if (startAt + maxResults < maxIssues)
					{
						startAt += maxResults;
						restQueryResult = Requester.GetIssues(Url, startAt);
						_users = QueryResultReader.ReadUsers(restQueryResult, _users, Url, backgroundWorker1);
					}
				}

				_users.ForEach(x => x.UpdateTotalWorklog());
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				progressBar1.Value = e.ProgressPercentage;
			}
			catch (Exception)
			{
				// ignored
			}
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (_users != null)
				if (_users.Count != 0)
				{
					DataGridEditor.PopulateDataGrid(dataGridIssuesOrWorklog, _users);
					DataGridEditor.RemoveColumn(dataGridIssuesOrWorklog, "Worklogs");
					progressBar1.Value = progressBar1.Maximum;
				}
			Cursor.Current = Cursors.Default;
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();
		}
	}
}