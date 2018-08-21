using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JiraSolution.Domain.Objects;

namespace JiraSolution.Services.WinForm_Services
{
	public static class DataGridEditor
	{
		private static readonly BindingSource BindingSource = new BindingSource();
		
		public static void PopulateDataGrid<T>(DataGridView dataGridIssuesOrWorklog, List<T> objs)
		{
			if (objs != null)
			{
				dataGridIssuesOrWorklog.AllowUserToAddRows = false;
				foreach (Object obj in objs)
				{
					BindingSource.Add(obj);
				}

				// dataGridIssuesOrWorklog.Columns.Clear();
				dataGridIssuesOrWorklog.DataSource = BindingSource;
			}
		}

		public static void RemoveColumn(DataGridView dataGridIssuesOrWorklog, string columnName)
		{
			try
			{
				dataGridIssuesOrWorklog.Columns.Remove(columnName); // A coluna é colocada por default porque existe no objeto User. Não é necessária.
			}
			catch (Exception e)
			{
				// ignored
			}
		}
	}
}
