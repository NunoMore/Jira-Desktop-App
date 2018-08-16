using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraSolution.Domain.Objects
{
	public class Worklog
	{
		public string Id { get; set; }
		public User User { get; set; }
		public string IssueName { get; set; }
		public double LogTime { get; set; }
		public string Description { get; set; }
	}
}
