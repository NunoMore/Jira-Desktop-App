using System.Collections.Generic;

namespace JiraSolution.Domain.Objects
{
	public class User
	{
		public byte[] Photo { get; set; }
		public string Name { get; set; }

		public Dictionary<string, List<int>> Worklogs { get; set; }
		//public string Link { get; set; }

		public int TotalWorklog { get; set; } // Must be public for DataGridView

		public void UpdateTotalWorklog()
		{
			foreach (var worklogs in Worklogs.Values)
			foreach (var worklog in worklogs)
				TotalWorklog += worklog / 3600;
		}
	}
}