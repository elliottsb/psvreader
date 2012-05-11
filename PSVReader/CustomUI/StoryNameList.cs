using System;
using Sce.Pss.HighLevel.UI;
using System.Collections.Generic;

namespace PSVReaderUI
{
	public class StoryListItem : ListPanelItem
	{
		const float margin = 5.0f;
		private Label lbl;
		private string story;
		
		public string Text
        {
            get
            {
                return lbl.Text;
            }
            set
            {
                lbl.Text = value;
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
		
		public StoryListItem(float itemWidth, float itemHeight)
		{
			this.Width = itemWidth;
			this.Height = itemHeight;
			
			lbl = new Label();
			lbl.X = margin;
			lbl.Y = margin;
			lbl.Width = Width - 2*margin;
			lbl.Height = Height - 2*margin;
			lbl.HorizontalAlignment = HorizontalAlignment.Left;
			this.AddChildLast(lbl);
		}
	}
	
	public class StoryNameList : ListPanel
	{
		private ListSectionCollection section;
		private List<string> listItemStr;
		
		public StoryNameList ()
		{
			listItemStr = new List<string>();
			section = new ListSectionCollection();
			this.SetListItemCreator(Creator);
			this.SetListItemUpdater(ListItemUpdater);
			this.Sections = section;
		}
		
		public void AddBook(string bookName, List<string> listChapter)
		{
			section.Add(new ListSection(bookName, listChapter.Count));
			
			listItemStr.AddRange(listChapter);
			
			this.Sections = section;
		}	
		
		private ListPanelItem Creator()
		{
			return new StoryListItem(this.Width, this.Height / 8.0f);
		}
		
		private void ListItemUpdater(ListPanelItem item)
		{
			if (item is StoryListItem)
			{
				StoryListItem StItem = item as StoryListItem;
				if (item.Index < listItemStr.Count)
				{
					StItem.Story = this.section[item.SectionIndex].Title;
					StItem.Text = listItemStr[item.Index];
				}
			}
		}
		
		protected override void OnTouchEvent (TouchEventCollection touchEvents)
		{
			base.OnTouchEvent (touchEvents);
			
			foreach (TouchEvent th in touchEvents)
			{
				Widget tmpWidget = th.Source;
				while (null != tmpWidget)
				{
					if (tmpWidget is StoryListItem)
					{
						StoryListItem item = tmpWidget as StoryListItem;
						PSVReader.Logic.ShowOneStory(item.Story, item.Text);
						
						break;
					}
					
					tmpWidget = tmpWidget.Parent;
				}
			}
		}
	}
}

