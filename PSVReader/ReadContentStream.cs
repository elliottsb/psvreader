using System;
using Sce.Pss.HighLevel.UI;

namespace PSVReader
{
	public class ReadContentStream
	{
		private string str;
		private int curIndex;
		private int curPageLen;
		
		public ReadContentStream ()
		{
		}
		
		public void SetContent(string content)
		{
			str = content;
		}
		
		private void PrepareOnePage(Label sampleLabel, bool reserve, int startIndex, out int index, out int lenth)
		{			
			int offset = startIndex;
			bool oneFullPage = false;
			int newIndex = 0;
			int newLenth = 0;
			// 正向
			if (!reserve)
			{
				while (offset < str.Length)
				{
					sampleLabel.Text = str.Substring(curIndex, offset - curIndex);
					
					if (sampleLabel.TextHeight > sampleLabel.Height)
					{
						oneFullPage = true;
						offset--;
						break;
					}
					
					offset++;
				}
				
				newIndex = startIndex;
				newLenth = offset;
			}
			else
			{
				while (offset >= 0)
				{
					sampleLabel.Text = str.Substring(curIndex - offset, offset);
					
					if (sampleLabel.TextHeight > sampleLabel.Height)
					{
						oneFullPage = true;
						offset++;
						break;
					}
					
					offset--;
				}
				
				if (oneFullPage)
				{
					newIndex = curIndex - offset;
					newLenth = offset;					
				}
				else
				{
					PrepareOnePage(sampleLabel, false, 0, out newIndex, out newLenth); 
				}
			}
			
			index = newIndex;
			lenth = newLenth;
		}
		
		public string GetPrevPage(Label sampleLabel)
		{
			if (false == HasPrev())
				return null;
			
			int index = 0;
			int lenth = 0;
			PrepareOnePage(sampleLabel, true, curIndex, out index, out lenth);
			
			return str.Substring(index, lenth);
		}
		
		public string GetThisPage(Label sampleLabel)
		{
			int index = 0;
			int lenth = 0;
			PrepareOnePage(sampleLabel, true, curIndex, out index, out lenth);
			
			return str.Substring(index, lenth);			
		}
		
		public string GetNextPage(Label sampleLabel)
		{
			if (false == HasNext())
				return null;
			
			int index = 0;
			int lenth = 0;
			PrepareOnePage(sampleLabel, false, curIndex + lenth, out index, out lenth);
			
			return str.Substring(index, lenth);
		}
		
		public bool HasPrev()
		{
			return curIndex != 0;
		}
		
		public bool HasNext()
		{
			return curIndex + curPageLen != str.Length;
		}
	}
}

