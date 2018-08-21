using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraSolution.Services.WinForm_Services
{
	public static class BackgroundWorkerEditor
	{
		public static void ReportProgress( BackgroundWorker backgroundWorker, int progress)
		{
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.ReportProgress(progress);
		}
	}
}
