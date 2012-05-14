// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.Pss.Core;
using Sce.Pss.Core.Imaging;
using Sce.Pss.Core.Environment;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
    partial class MainFrame
    {
		PSVReader.DownCmplt dmpt;
		
		public static void ShowConnect(string content)
		{
			ContentPanel.Text = content;
		}
		
		public void UpdateStoryList()
		{
			PSVReader.Logic.UpdateStory(ListPanel_FileList);
		}
		
		public void CustomInit()
		{
			UpdateStoryList();
			Button_DelAll.ButtonAction += HandleDelAllButtonAction;
			Add_New.ButtonAction += HandleAddNewButtonAction;
			dmpt = new PSVReader.DownCmplt(DownloadStoryComplete);
			PSVReader.DownloadComplate.ListonDownloadEvent(dmpt);
		}
		
		public void HandleDelAllButtonAction(object sender, TouchEventArgs e)
		{
			PSVReader.Logic.DelAllStory();
			UpdateStoryList();
		}
		
		public void HandleAddNewButtonAction(object sender, TouchEventArgs e)
		{
			PSVReader.Logic.testSaveFile();
			//PSVReader.Logic.DownloadStory("test", "testchp1", "http://192.168.1.102/123.txt");
		}
		
		public bool DownloadStoryComplete(byte[] data, string storyname, string Chaptername)
		{
			UpdateStoryList();
			return true;
		}
	}
}

