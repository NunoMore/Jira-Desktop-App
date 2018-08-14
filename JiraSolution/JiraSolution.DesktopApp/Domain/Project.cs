using System.Collections.Generic;

namespace JiraSolution.DesktopApp.Domain
{
	class Project
	{
		List<Issue> issues = new List<Issue>();

		public List<Issue> getIssues()
		{
			return issues;
		}

		public void addIssue(Issue issue)
		{
			issues.Add(issue);
		}
	}
}
