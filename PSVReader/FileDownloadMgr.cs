using System;

namespace PSVReader
{
	public delegate void DownCmplt(byte[] data, string storyname, string Chaptername);
	
	public class NameUrlPair
	{
		public string name;
		public string chapter;
		public string url;
	}
	
	public class DownloadComplate : PSVReader.IDownloadComplete
	{ 
		private event DownCmplt downloadDlgt;
		
		public void ListonDownloadEvent(DownCmplt dlgt)
		{
			downloadDlgt += dlgt;
		}
		
		public void OnDownloadComplete(object state)
		{
			if (state is NameUrlPair)
			{
				NameUrlPair pair = state as NameUrlPair;
				
				downloadDlgt(PSVReader.HttpDownload.GetRawData(), pair.name, pair.chapter);
			}
		}
	}
	
	public class FileDownloadMgr
	{
		public FileDownloadMgr ()
		{
		}
		
		public static void DownloadStory(string name, string chapter, string url)
		{
			NameUrlPair pair = new NameUrlPair();
			pair.chapter = chapter;
			pair.name = name;
			pair.url = url;
			
			HttpDownload.DownloadContent(url, new DownloadComplate(), pair);
		}
	}
}

