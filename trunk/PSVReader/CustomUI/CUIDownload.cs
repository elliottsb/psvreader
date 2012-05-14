using System;
using System.Collections.Generic;
using Sce.Pss.Core;
using Sce.Pss.Core.Imaging;
using Sce.Pss.Core.Environment;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
	partial class DownloadUI
	{
		private void CustomInit()
		{
			DownloadBtn.ButtonAction += HandleButton1ButtonAction;
		}
		
		public void HandleButton1ButtonAction(object sender, TouchEventArgs e)
		{
			string url = download_url.Text;
			PSVReader.Logic.DownloadStory("test", "testChapter", url);
		}
	}
}

