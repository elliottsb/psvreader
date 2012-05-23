using System;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
	partial class ReadScollPanel
	{
		private Label ShowLabel;
		private Label CalLabel;
		private float MaxWidth;
		private float MaxHeight;
		private string Content;
		
		public string Text
        {
            get
            {
                return Content;
            }
            set
            {
                Content = value;
				int lenth = CalcShowString(Content);
				ShowLabel.Text = Content.Substring(0, lenth);
            }
        }
		
		public int CalcShowString(string str, int startIndex)
		{
			if (null == CalLabel)
				CalLabel = new Label();
			
			CalLabel.SetSize(MaxWidth, MaxHeight);
			
			int ContentLenth = 0;
			for (; ContentLenth < str.Length; ContentLenth++)
			{
				CalLabel.Text = str.Substring(0, ContentLenth);
				if (CalLabel.TextHeight > MaxHeight)
				{
					break;
				}
			}
			
			return ContentLenth;
		}
	}
}

