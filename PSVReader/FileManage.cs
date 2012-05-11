/*	FileStorge.cs
 * 管理全部的小说文件
 * 提供查找当前存在的小说文件，
 * 将内容保存为小说文件
 * 删除小说文件
 * 获取一份小说文件，进行显示
 */

using System;
using System.IO;
using System.Collections.Generic;
//文件按照一下方式组织

//跟目录为 /Application/PSVReader/小说名称
//目录下包含主文件txt格式，和配置文件，包含编码，上次阅读等信息。

namespace PSVReader
{
	public class FileManage
	{
		private const string BaseFolder = "/Application/PSVReader/";
		
		public FileManage ()
		{

		}
		
		public static void StartCheck()
		{
			if (!System.IO.Directory.Exists(BaseFolder))
			{
				System.IO.Directory.CreateDirectory(BaseFolder);	
			}		
		}
		
		public static List<string> GetAllStoryName()
		{
			DirectoryInfo dirInfo = new DirectoryInfo(BaseFolder);
			DirectoryInfo[] subDirInfo = dirInfo.GetDirectories();
			
			List<string> StoryNameList = new List<string>();
			
			foreach (var vInfo in subDirInfo)
			{
				StoryNameList.Add(vInfo.Name);
			}			
			
			return StoryNameList;
		}	
	
		public static bool CheckFileExsit(string name, string chapter)
		{
			if (false == System.IO.Directory.Exists(BaseFolder + name))
				return false;
			return System.IO.Directory.Exists(BaseFolder + name + '/' + chapter);
		}
		
		public static bool DeleteStory(string name)
		{
			System.IO.Directory.Delete(BaseFolder + name, true);
			
			return true;
		}
		
		public static List<string> GetStory(string name)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(BaseFolder + name);
			DirectoryInfo[] subDirInfo = dirInfo.GetDirectories();
			
			List<string> ChapterList = new List<string>();
			
			foreach (var vInfo in subDirInfo)
			{
				ChapterList.Add(vInfo.Name);
			}			
			
			return ChapterList;
		}
		
		public static FileStorage GetStoryChapter(string name, string chapter)
		{
			string dstDir = BaseFolder + name + "/" + chapter;
			
			FileStorage newFile = new FileStorage(dstDir);
			
			return newFile;
		}
		
		public static bool SaveFile(byte[] data, string name, string chapter)
		{
			if (CheckFileExsit(name, chapter))
			{
				return false;
			}
			
			string dstDirName = BaseFolder + name + "/" + chapter;
			
			if (false == System.IO.Directory.Exists(dstDirName))
			{
				System.IO.Directory.CreateDirectory(dstDirName);
			}
			
			FileStorage newFile = new FileStorage(dstDirName);
			newFile.WriteContent(data);
			
			return false;
		}	
	}
}

