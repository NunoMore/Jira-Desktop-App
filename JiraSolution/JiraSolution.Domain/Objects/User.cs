using System;
using System.Collections.Generic;

namespace JiraSolution.Domain.Objects
{
	public class User
	{
		public Byte[] Photo { get; set; }
		public string Name { get; set; }
		public Dictionary<string, List<int>> Worklog { get; set; }
		//public string Link { get; set; }

		public int TotalWorklog { get; set; } // Must be public for DataGridView

		public void UpdateTotalWorklog()
		{
			foreach (List<int> worklogs in Worklog.Values)
			{
				foreach (int worklog in worklogs)
				{
					TotalWorklog += worklog/3600;
				}
			}
		}
	}
}
