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
		private static int maxReadLen = 5000;
		private static int sessionOffset = 0;
		
		public static byte[] ReadContent(string filename)
		{
			if ( true == CheckFileExsit(filename)) {
                using (System.IO.FileStream hStream = System.IO.File.Open(filename, FileMode.Open)) {
                    if (hStream != null) {
                        long size = hStream.Length < maxReadLen ? hStream.Length : maxReadLen;
                        inputData = new byte[size];
						sessionOffset += hStream.Read(inputData, sessionOffset, (int)size);
						hStream.Close();
						return inputData;
                    }
                }
            }
			
			return null;
		}
		
		public static void WriteContent(byte[] data, string filename)
		{
			using (System.IO.FileStream hStream = System.IO.File.Open(filename, FileMode.OpenOrCreate)) {
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
		private static string filename;

		
		public FileStorage ()
		{
		}
		
		public FileStorage (string name)
		{
			filename = name;
		}
		
		public byte[] ReadContent()
		{
			return FileOpHelper.ReadContent(filename);
		}
		
		public void WriteContent(byte[] data)
		{
			FileOpHelper.WriteContent(data, filename);
		}
	}
}

