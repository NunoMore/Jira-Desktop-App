using System.Collections.Generic;

namespace JiraSolution.Domain.Objects
{
	public class User
	{
		public byte[] Photo { get; set; }
		public string Name { get; set; }

		public Dictionary<string, List<int>> Worklogs { get; set; }
		//public string Link { get; set; }

		public string TotalWorklog { get; set; } // Must be public for DataGridView

		public void UpdateTotalWorklog()
		{
			var total = 0;

			foreach (var worklogs in Worklogs.Values)
			foreach (var worklog in worklogs)
				total += worklog;


			TotalWorklog = (total /3600) + "h " + (total%3600)*60/3600 + "m ";
		}
	}
}