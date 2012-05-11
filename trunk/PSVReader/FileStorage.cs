/*	FileStorge.cs
 * 用于管理单份的小说文件
 * 一个小说文件对应一个文件夹，包含原始的txt文档和对应的cfg文档
 * txt文档保存原始的数据包
 * cfg文档保存文件的编码和上一次阅读位置等信息
 */

using System;
using System.IO;

namespace PSVReader
{
	public class FileOpHelper
	{
    	private static byte[] inputData;
		
		public static byte[] ReadContent(string filename)
		{
			if ( true == CheckFileExsit(filename)) {
                using (System.IO.FileStream hStream = System.IO.File.Open(filename, FileMode.Open)) {
                    if (hStream != null) {
                        long size = hStream.Length;
                        inputData = new byte[size];
						hStream.Read(inputData, 0, (int)size);
						hStream.Close();
						return inputData;
                    }
                }
            }
			
			return null;
		}
		
		public static void WriteContent(byte[] data, string filename)
		{
			using (System.IO.FileStream hStream = System.IO.File.Open(filename, FileMode.Open)) {
                   hStream.SetLength((int)data.Length);
                   hStream.Write(data, 0, (int)data.Length);
                   hStream.Close();
			}
		}
		
		public static bool CheckFileExsit(string filename)
		{
			return true;
		}
	}
	
	public class FileStorage
	{
		private string pathname;
		private string filename;
		private string cfgfilename;
		
		public FileStorage (string filepathname)
		{
			pathname = filepathname;
			
			string chaptername = pathname.Substring(pathname.LastIndexOf('/'), 
			                                        pathname.Length - pathname.LastIndexOf('/'));
			
			filename = pathname + chaptername + ".txt";
			cfgfilename = pathname + chaptername + ".cfg";
			
			preparefile();
		}
		
		private void preparefile()
		{
			if (false == System.IO.File.Exists(filename))
			{
				System.IO.File.Create(filename).Close();
			}
			
			if (false == System.IO.File.Exists(cfgfilename))
			{
				System.IO.File.Create(cfgfilename).Close();
			}
		}
		
		public byte[] ReadContent()
		{
			return FileOpHelper.ReadContent(filename);
		}
		
		public int LastReadSign()
		{
			return 0;
		}
		
		public void SaveLastReadSign()
		{
			
		}
		
		public string GetEncodingType()
		{
			return "ascii";
		}
		
		public void WriteContent(byte[] data)
		{
			FileOpHelper.WriteContent(data, filename);
		}
	}
}

