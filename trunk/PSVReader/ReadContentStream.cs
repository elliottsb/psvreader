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
		
		private void PrepareOnePage(Label sampleLabel, bool forward, int startIndex, out int index, out int lenth)
		{			
			int offset = 0;
			bool oneFullPage = false;
			int newIndex = 0;
			int newLenth = 0;
			// 正向
			if (forward)
			{
				while (startIndex + offset < str.Length)
				{
					sampleLabel.Text = str.Substring(startIndex, offset);
					
					if (sampleLabel.TextHeight > sampleLabel.Height)
					{
						oneFullPage = true;
						break;
					}
					
					offset++;
				}
				
				// 无论是超过一页还是到达末尾，都需要将offset - 1；
				offset--;
				newIndex = startIndex;
				newLenth = offset;
			}
			else
			{
				while (startIndex - offset >= 0)
				{
					sampleLabel.Text = str.Substring(curIndex - offset, offset);
					
					if (sampleLabel.TextHeight > sampleLabel.Height)
					{
						oneFullPage = true;
						break;
					}
					
					offset--;
				}
				
				// 无论是超过一页还是到达末尾，都需要将offset - 1；
				offset++;
				if (oneFullPage)
				{
					newIndex = curIndex - offset;
					newLenth = offset;					
				}
				else
				{
					PrepareOnePage(sampleLabel, true, 0, out newIndex, out newLenth); 
				}
			}
			
			index = newIndex;
			lenth = newLenth;
		}
		
		public string GetPrevPage(PSVReaderUI.StreamPageLabel sampleLabel)
		{
			if (false == HasPrev())
				return null;
			
			int index = 0;
			int lenth = 0;
			PrepareOnePage(sampleLabel, false, curIndex, out index, out lenth);
			
			sampleLabel.ContentIndex = index;
			sampleLabel.ContentLenth = lenth;
			
			return str.Substring(index, lenth);
		}
		
		public string GetThisPage(PSVReaderUI.StreamPageLabel sampleLabel)
		{
			int index = 0;
			int lenth = 0;
			PrepareOnePage(sampleLabel, true, curIndex, out index, out lenth);

			sampleLabel.ContentIndex = index;
			sampleLabel.ContentLenth = lenth;
			
			return str.Substring(index, lenth);			
		}
		
		public string GetNextPage(PSVReaderUI.StreamPageLabel sampleLabel)
		{
			if (false == HasNext())
				return null;
			
			int index = 0;
			int lenth = 0;
			PrepareOnePage(sampleLabel, true, curIndex + curPageLen, out index, out lenth);

			sampleLabel.ContentIndex = index;
			sampleLabel.ContentLenth = lenth;
			
			return str.Substring(index, lenth);
		}
		
		public bool HasPrev()
		{
			return curIndex != 0;
		}
		
		public bool HasNext()
		{
			// 应该等于finalIndex，就是Length - 1
			return curIndex + curPageLen != str.Length - 1;
		}
		
		public void UpdateLocation(int newIndex, int newLenth)
		{
			curIndex = newIndex;
			curPageLen = newLenth;
		}
	}
}

