using System;
using System.Text;
using Sce.Pss.HighLevel.UI;
using System.Collections.Generic;
using System.IO;

namespace PSVReader
{
	public class Logic
	{	
		public Logic ()
		{
			
		}
		
		public static void DelAllStory()
		{
			List<string> listName = PSVReader.FileManage.GetAllStoryName();	
			
			foreach(string name in listName)
			{
				PSVReader.FileManage.DeleteStory(name);
			}
		}
		
		public static void testSaveFile()
		{	
			string tempstr = "this is test string";
			
			UnicodeEncoding encode = new UnicodeEncoding();
			
			PSVReader.FileManage.SaveFile(encode.GetBytes(tempstr), "file1", "chapter2");
		}
		
		public static void DownloadStory(string name, string chapter, string url)
		{
			PSVReader.FileDownloadMgr.DownloadStory(name, chapter, url);
		}
		
		public static void ShowOneStory(string name, string chapter)
		{
			FileStorage onefile = PSVReader.FileManage.GetStoryChapter(name, chapter);
			
			byte[] data = onefile.ReadContent();
			
			//UnicodeEncoding encoding = new UnicodeEncoding();
			
			PSVReaderUI.MainFrame.ShowConnect(Encoding.Unicode.GetString(data));
		}
		
		public static void UpdateStory(PSVReaderUI.StoryNameList list)
		{
			List<string> names = FileManage.GetAllStoryName();
			
			list.ClearBook();
			foreach (string na in names)
			{
				List<string> chapterName = FileManage.GetStory(na);
				
				list.AddBook(na, chapterName);
			}				
		}
	}
}

