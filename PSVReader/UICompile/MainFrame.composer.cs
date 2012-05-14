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
        StoryNameList ListPanel_FileList;
		static ReadScollPanel ContentPanel;
		Button Button_DelAll;
        Button Add_New;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            MainWindow = new Panel();
            MainWindow.Name = "MainWindow";
            ListPanel_FileList = new StoryNameList();
            ListPanel_FileList.Name = "ListPanel_FileList";
            Button_DelAll = new Button();
            Button_DelAll.Name = "Button_DelAll";
            Add_New = new Button();
            Add_New.Name = "Add_New";
			ContentPanel = new ReadScollPanel();
			ContentPanel.Name = "ContentPanel";
			
            // ListPanel_FileList
            ListPanel_FileList.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
        	ListPanel_FileList.BackgroundColor = new UIColor(200f / 255f, 153f / 255f, 100f / 255f, 255f / 255f);
			
			// Button_DelAll
            Button_DelAll.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Button_DelAll.TextFont = new Font( FontAlias.System, 25, FontStyle.Regular);

            // Add_New
            Add_New.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Add_New.TextFont = new Font( FontAlias.System, 25, FontStyle.Regular);
            // MainWindow
            MainWindow.Clip = true;
            MainWindow.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 255f / 255f);
			this.MainWindow.AddChildLast(ListPanel_FileList);
	        this.MainWindow.AddChildLast(ContentPanel);
			this.MainWindow.AddChildLast(Button_DelAll);
			this.MainWindow.AddChildLast(Add_New);

            // Scen
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
				
                ContentPanel.SetPosition(50, 106);
                ContentPanel.SetSize(100, 500);
                ContentPanel.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ContentPanel.Visible = true;
				ContentPanel.SetWidgetLayout(orientation);
				
                ListPanel_FileList.SetPosition(-130, 236);
                ListPanel_FileList.SetSize(854, 400);
                ListPanel_FileList.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ListPanel_FileList.Visible = true;

                Button_DelAll.SetPosition(-62, 467);
                Button_DelAll.SetSize(214, 56);
                Button_DelAll.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Button_DelAll.Visible = true;

                Add_New.SetPosition(-62, 467);
                Add_New.SetSize(214, 56);
                Add_New.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Add_New.Visible = true;

                break;

            default:
                this.DesignWidth = 960;
                this.DesignHeight = 544;

                MainWindow.SetPosition(0, 0);
                MainWindow.SetSize(960, 544);
                MainWindow.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                MainWindow.Visible = true;

                ContentPanel.SetPosition(100, 0);
                ContentPanel.SetSize(860, 544);
                ContentPanel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                ContentPanel.Visible = true;
				ContentPanel.SetWidgetLayout(orientation);
				
                ListPanel_FileList.SetPosition(0, 0);
                ListPanel_FileList.SetSize(100, 432);
                ListPanel_FileList.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                ListPanel_FileList.Visible = true;

                Button_DelAll.SetPosition(0, 388);
                Button_DelAll.SetSize(100, 56);
                Button_DelAll.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Button_DelAll.Visible = true;

                Add_New.SetPosition(0, 332);
                Add_New.SetSize(100, 56);
                Add_New.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Add_New.Visible = true;
                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
            Button_DelAll.Text = "删除";
            Add_New.Text = "添加";
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
	}
} 