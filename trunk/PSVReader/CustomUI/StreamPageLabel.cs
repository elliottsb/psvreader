using System;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
	public class StreamPageLabel: Label
	{
		// 这里记录的是搭载内容的标签坐标
		private int index;
		private int lenth;
		
		public StreamPageLabel ()
		{
		}
		
		public int ContentIndex
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}
		
		public int ContentLenth
		{
			get
			{
				return lenth;
			}
			set
			{
				lenth = value;
			}			
		}
	}
}

