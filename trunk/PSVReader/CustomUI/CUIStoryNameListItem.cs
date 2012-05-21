using System;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
	partial class StoryNameListItem
	{
		private string story;
		
		public string Text
        {
            get
            {
                return Label_Story.Text;
            }
            set
            {
                Label_Story.Text = value;
            }
        }
		
		public string Story
		{
			get
			{
				return story;
			}
			set
			{
				story = value;
			}
		}
	}
}

