// logic为UI事件的逻辑处理类别
// 同时为了UI和逻辑分离，所有需要通知到UI的时间，全部通过logic进行转播
// 同时本文件作为模块间的消息流转中心

using System;
using System.Text;
using Sce.Pss.HighLevel.UI;
using System.Collections.Generic;
using System.IO;

namespace PSVReader
{
	// 所有要求UI层做的东西全部走这个渠道，保持UI和内容分离。
	public class UINoitfy
	{
		public delegate void DlgtShowOneStory(ReadContentStream cStream);
		private static event DlgtShowOneStory ShowNotify;
		
		public static void ListenOnShowOneStory(DlgtShowOneStory obj)
		{
			ShowNotify += obj;
		}
		
		public static void DoShowOneStory(ReadContentStream cStream)
		{
			ShowNotify(cStream);
		}
		
		public delegate void DlgtNewStoryAdded(string name, string chapter);
		private static event DlgtNewStoryAdded AddNotify;
		
		public static void ListionOnNewStoryAdded(DlgtNewStoryAdded obj)
		{
			AddNotify += obj;
		}
		
		public static void DoNewStroyAdded(string name, string chapter)
		{
			AddNotify(name, chapter);
		}
	}	
	
	public class Logic
	{	
		private static DownCmplt downAct = new DownCmplt(OnDownloadComplete);
		
		public static ReadContentStream contentStream = new ReadContentStream();
		
		public static bool Init()
		{
			DownloadComplate.ListonDownloadEvent(downAct);
			
			FileManage.Init();
			
			return true;
		}
		
		public static bool OnDownloadComplete(byte[] data, string name, string chapter)
		{
			return FileManage.SaveFile(data, name, chapter);
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
			
			PSVReader.FileManage.SaveFile(encode.GetBytes(tempstr), "file3", "chapter2");
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
			
			//PSVReaderUI.MainFrame.ShowConnect(Encoding.Unicode.GetString(data));
			ReadContentStream rcs = new ReadContentStream();
			rcs.SetContent(Encoding.Unicode.GetString(data));
			
			UINoitfy.DoShowOneStory(rcs);
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

