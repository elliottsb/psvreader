using System;
using System.IO;

namespace PSVReader
{
	public class FileStorage
	{
		private static string filename;
    	private static byte[] inputData;
		private static int maxReadLen = 5000;
		private static int sessionOffset = 0;
		
		public FileStorage ()
		{
		}
		
		public static void SetFileName(string fname)
		{
			filename = fname;
		}
		
		public static bool CheckFileExsit()
		{
			return true;
		}
		
		public static byte[] ReadContent()
		{
			if ( true == CheckFileExsit()) {
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
		
		public static void WriteContent(byte[] data)
		{
			using (System.IO.FileStream hStream = System.IO.File.Open(filename, FileMode.OpenOrCreate)) {
                   hStream.SetLength((int)data.Length);
                   hStream.Write(data, 0, (int)data.Length);
                   hStream.Close();
			}
		}
	}
}

