using System.Collections.Generic;
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
				dataGridIssuesOrWorklog.DataSource = _bindingSource;
				dataGridIssuesOrWorklog.Columns.Remove("Worklog"); // A coluna é colocada por default porque existe no objeto User. Não é necessária.
			}
		}
	}
}
