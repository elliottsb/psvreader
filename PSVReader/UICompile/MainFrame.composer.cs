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
        Panel MainWindow;
        Button DownloadBtn;
        EditableText download_url;
        ScrollPanel ScrollPanel_Text;
        StoryNameList ListPanel_FileList;
		static Label ContentLabel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            MainWindow = new Panel();
            MainWindow.Name = "MainWindow";
            DownloadBtn = new Button();
            DownloadBtn.Name = "DownloadBtn";
            download_url = new EditableText();
            download_url.Name = "download_url";
            ScrollPanel_Text = new ScrollPanel();
            ScrollPanel_Text.Name = "ScrollPanel_Text";
			ContentLabel = new Label();
			ContentLabel.Name = "ContentLabel";
            ListPanel_FileList = new StoryNameList();
            ListPanel_FileList.Name = "ListPanel_FileList";


            // DownloadBtn
            DownloadBtn.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            DownloadBtn.TextFont = new Font( FontAlias.System, 25, FontStyle.Regular);			
			
            // download_url
            download_url.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            download_url.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            download_url.LineBreak = LineBreak.Character;

            // ScrollPanel_Text
            ScrollPanel_Text.HorizontalScroll = true;
            ScrollPanel_Text.VerticalScroll = true;
            ScrollPanel_Text.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
			 
			// ContentLabel
			ScrollPanel_Text.AddChildLast(ContentLabel);
			ContentLabel.BackgroundColor = new UIColor(0.1f, 0.8f, 0.5f, 1.0f);
			ContentLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            ContentLabel.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            ContentLabel.LineBreak = LineBreak.Character;
			
            // ListPanel_FileList
            ListPanel_FileList.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
			ListPanel_FileList.BackgroundColor = new UIColor(0.12f, 0.12f, 0.12f, 1.0f);			
			
            // MainWindow
            MainWindow.Clip = true;
            MainWindow.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 255f / 255f);
            this.MainWindow.AddChildLast(DownloadBtn);
            this.MainWindow.AddChildLast(download_url);
			this.MainWindow.AddChildLast(ScrollPanel_Text);
            this.MainWindow.AddChildLast(ListPanel_FileList);
			
            // Scene
            this.RootWidget.AddChildLast(MainWindow);

            SetWidgetLayout(orientation);

            UpdateLanguage();
			
			CustomInit();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
            case LayoutOrientation.Vertical:
                this.DesignWidth = 544;
                this.DesignHeight = 960;

                MainWindow.SetPosition(0, 0);
                MainWindow.SetSize(100, 100);
                MainWindow.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                MainWindow.Visible = true;

                DownloadBtn.SetPosition(490, 16);
                DownloadBtn.SetSize(114, 56);
                DownloadBtn.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                DownloadBtn.Visible = true;

                download_url.SetPosition(383, 19);
                download_url.SetSize(260, 56);
                download_url.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                download_url.Visible = true;
				
                ScrollPanel_Text.SetPosition(150, 106);
                ScrollPanel_Text.SetSize(100, 50);
                ScrollPanel_Text.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ScrollPanel_Text.Visible = true;

                ContentLabel.SetPosition(181, 96);
                ContentLabel.SetSize(214, 36);
                ContentLabel.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ContentLabel.Visible = true;				
				
                ListPanel_FileList.SetPosition(-130, 236);
                ListPanel_FileList.SetSize(854, 400);
                ListPanel_FileList.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ListPanel_FileList.Visible = true;

                break;

            default:
                this.DesignWidth = 960;
                this.DesignHeight = 544;

                MainWindow.SetPosition(0, 0);
                MainWindow.SetSize(960, 544);
                MainWindow.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                MainWindow.Visible = true;

                DownloadBtn.SetPosition(661, 120);
                DownloadBtn.SetSize(173, 56);
                DownloadBtn.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                DownloadBtn.Visible = true;

                download_url.SetPosition(546, 40);
                download_url.SetSize(360, 56);
                download_url.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                download_url.Visible = true;

                ScrollPanel_Text.SetPosition(100, 0);
                ScrollPanel_Text.SetSize(860, 544);
                ScrollPanel_Text.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                ScrollPanel_Text.Visible = true;

                ContentLabel.SetPosition(181, 96);
                ContentLabel.SetSize(364, 247);
                ContentLabel.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ContentLabel.Visible = true;
				
                ListPanel_FileList.SetPosition(0, 0);
                ListPanel_FileList.SetSize(100, 544);
                ListPanel_FileList.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                ListPanel_FileList.Visible = true;

                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
            DownloadBtn.Text = "Download";
            download_url.Text = "http:\\\\192.186.1.102\\123.txt";
        }
        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                {
                }
                break;

                default:
                {
                }
                break;
            }
        }
        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                {
                }
                break;

                default:
                {
                }
                break;
            }
        }
		
		private void CustomInit()
		{
			DownloadBtn.ButtonAction += HandleButton1ButtonAction;
			PSVReader.Logic.UpdateStory(ListPanel_FileList);
		}
		
		public void HandleButton1ButtonAction(object sender, TouchEventArgs e)
		{
			string url = download_url.Text;
			PSVReader.Logic.DownloadStory("test", "test", url);
		}
		
		public static void ShowConnect(string content)
		{
			ContentLabel.Text = content;
		}
    }
}
