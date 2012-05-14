using System;
using Sce.Pss.HighLevel.UI;
using System.Collections.Generic;

namespace PSVReaderUI
{
	public class StoryNameList : ListPanel
	{
		private ListSectionCollection sections;
		private List<string> listItemStr;
		
		public StoryNameList ()
		{
			listItemStr = new List<string>();
			sections = new ListSectionCollection();
			this.SetListItemCreator(StoryNameListItem.Creator);
			this.SetListItemUpdater(ListItemUpdater);
			this.Sections = sections;
		}
		
		public void ClearBook()
		{
			sections.Clear();
			
			this.Sections = sections;
		}

		// 这个API可能有问题，今天不改了
		public void RemoveBook(string bookName)
		{
			foreach(ListSection sec in sections)
			{
				if (sec.Title == bookName)
				{
					//int index = sections.IndexOf(sec);
					//sections.RemoveAt(sec);
					break;
				}
			}
			
			this.Sections = sections;
		}
		
		public void AddBook(string bookName, List<string> listChapter)
		{
			sections.Add(new ListSection(bookName, listChapter.Count));
			
			listItemStr.AddRange(listChapter);
			
			this.Sections = sections;
		}	
		
		private void ListItemUpdater(ListPanelItem item)
		{
			if (item is StoryNameListItem)
			{
				StoryNameListItem StItem = item as StoryNameListItem;
				if (item.Index < listItemStr.Count)
				{
					StItem.Story = this.sections[item.SectionIndex].Title;
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
					if (tmpWidget is StoryNameListItem)
					{
						StoryNameListItem item = tmpWidget as StoryNameListItem;
						PSVReader.Logic.ShowOneStory(item.Story, item.Text);
						
						break;
					}
					
					tmpWidget = tmpWidget.Parent;
				}
			}
		}
	}
}

