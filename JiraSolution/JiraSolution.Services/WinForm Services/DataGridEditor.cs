using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JiraSolution.Services.WinForm_Services
{
	public static class DataGridEditor
	{
		
		public static void PopulateDataGrid<T>(DataGridView dataGridIssuesOrWorklog, List<T> objs)
		{
			BindingSource bindingSource = new BindingSource();

			if (objs != null)
			{
				foreach (object obj in objs)
				{
					bindingSource.Add(obj);
				}

				dataGridIssuesOrWorklog.DataSource = bindingSource;

				dataGridIssuesOrWorklog.AllowUserToResizeColumns = false;
				dataGridIssuesOrWorklog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

				dataGridIssuesOrWorklog.AllowUserToAddRows = false;
				dataGridIssuesOrWorklog.RowHeadersVisible = false;
				dataGridIssuesOrWorklog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
				dataGridIssuesOrWorklog.BackgroundColor = dataGridIssuesOrWorklog.DefaultCellStyle.BackColor;
			}
		}

		public static void RemoveColumn(DataGridView dataGridIssuesOrWorklog, string columnName)
		{
			try
			{
				dataGridIssuesOrWorklog.Columns.Remove(columnName); // A coluna é colocada por default porque existe no objeto User. Não é necessária.
			}
			catch (Exception)
			{
				// ignored
			}
		}
	}
}
