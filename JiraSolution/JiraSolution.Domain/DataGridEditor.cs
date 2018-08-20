using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;

namespace JiraSolution.Domain
{
	public class DataGridEditor
	{
		private readonly BindingSource _bindingSource = new BindingSource();
		
		public void PopulateDataGrid(DataGridView dataGridIssuesOrWorklog, List<User> users)
		{
			if (users != null)
			{

				foreach (User user in users)
				{
					_bindingSource.Add(user);
				}

				// dataGridIssuesOrWorklog.Columns.Clear();
				// dataGridIssuesOrWorklog.AutoGenerateColumns = false;
				// dataGridIssuesOrWorklog.AutoSize = true;
				dataGridIssuesOrWorklog.DataSource = _bindingSource;
				dataGridIssuesOrWorklog.Columns.Remove("Worklog");
			}
			
		}
	}
}
