using System;
using System.Text;
using Sce.Pss.HighLevel.UI;
using System.Collections.Generic;


namespace PSVReader
{
	public class Logic
	{
		private static string storyName;
		
		public Logic ()
		{
			
		}
		
		public static void testSaveFile()
		{	
			string tempstr = "this is test string";
			
			ASCIIEncoding encode = new ASCIIEncoding();
			
			PSVReader.FileManage.SaveFile(encode.GetBytes(tempstr), "file1", "chapter1");
		}
		
		public static void DownloadStory(string name, string chapter, string url)
		{
			testSaveFile();
			//PSVReader.FileDownloadMgr.DownloadStory(name, chapter, url);
		}

		public static void SetStoryName(string name)
		{
			storyName = name;
		}
		
		public static string GetStroyName()
		{
			return storyName;
		}
		
		public static void ShowOneStory(string name, string chapter)
		{
			FileStorage onefile = PSVReader.FileManage.GetStoryChapter(name, chapter);
			
			byte[] data = onefile.ReadContent();
			
			ASCIIEncoding encoding = new ASCIIEncoding();
			
			PSVReaderUI.MainFrame.ShowConnect(encoding.GetString(data));
		}
		
		public static void UpdateStory(PSVReaderUI.StoryNameList list)
		{
			List<string> names = FileManage.GetAllStoryName();
			
			foreach (string na in names)
			{
				List<string> chapterName = FileManage.GetStory(na);
				
				list.AddBook(na, chapterName);
			}				
		}
	}
}

