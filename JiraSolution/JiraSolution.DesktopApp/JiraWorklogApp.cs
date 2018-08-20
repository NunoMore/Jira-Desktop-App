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
		private DateTime _startDate = Convert.ToDateTime("2018-01-01");
		private DateTime _endDate = Convert.ToDateTime("2018-07-31");
		private List<User> _users = new List<User>();

		private const string Url = "https://glinttdev.atlassian.net/rest/api/latest/";

		private readonly DataGridEditor _dataGridEditor = new DataGridEditor();
		private readonly QueryResultReader _queryResultReader = new QueryResultReader();

		private void Button_Click(object sender, EventArgs e)
		{
			progressBar1.Maximum = 105;
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

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			//BackgroundWorker backgroundWorker = sender as BackgroundWorker;

			//Cursor.Current = Cursors.WaitCursor;
			
			//Runner runner = new Runner(_username, _password, _projectName, _userName, _startDate, _endDate, backgroundWorker);
			//_users = runner.Run();

			////////

			Requester requester = new Requester(_username, _password,_projectName, _userName, _startDate, _endDate);

			_users.Clear();

			string restQueryResult = requester.GetIssues(Url, 0);

			if (!string.IsNullOrEmpty(restQueryResult))
			{
				int maxIssues = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("total", restQueryResult));
				int maxResults = Convert.ToInt32(_queryResultReader.FindValuesInRestQueryResult("maxResults", restQueryResult));

				int progressBarCurrentStep = maxIssues;

				int startAt = 0;
				int maxPages = (maxIssues + maxResults + 1) / maxResults;

				for (int i = 0; i < maxPages; i++)
				{
					_users = _queryResultReader.ReadUsers(restQueryResult, _users, requester, progressBarCurrentStep, Url, backgroundWorker1);

					if (startAt + maxResults < maxIssues)
					{
						startAt += maxResults;
						restQueryResult = requester.GetIssues(Url, startAt);
						_users = _queryResultReader.ReadUsers(restQueryResult, _users, requester, progressBarCurrentStep, Url, backgroundWorker1);
					}
				}

				_users.ForEach(x => x.UpdateTotalWorklog());
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			if (_users != null)
			{
				if(_users.Count != 0)
				{
					_dataGridEditor.PopulateDataGrid(dataGridIssuesOrWorklog, _users);

					progressBar1.Value = progressBar1.Maximum;
				}
			}
			Cursor.Current = Cursors.Default;
		}
	}
}

