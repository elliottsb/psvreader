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
        Label Label_1;
        Button DownloadBtn;
        EditableText download_url;
        GridListPanel GridListPanel_1;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            MainWindow = new Panel();
            MainWindow.Name = "MainWindow";
            Label_1 = new Label();
            Label_1.Name = "Label_1";
            DownloadBtn = new Button();
            DownloadBtn.Name = "DownloadBtn";
            download_url = new EditableText();
            download_url.Name = "download_url";
            GridListPanel_1 = new GridListPanel(GridListScrollOrientation.Vertical);
            GridListPanel_1.Name = "GridListPanel_1";

            // Label_1
            Label_1.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Label_1.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            Label_1.LineBreak = LineBreak.Word;
            Label_1.VerticalAlignment = VerticalAlignment.Top;

            // DownloadBtn
            DownloadBtn.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            DownloadBtn.TextFont = new Font( FontAlias.System, 25, FontStyle.Regular);
			DownloadBtn.ButtonAction += HandleButton1ButtonAction;
			
            // download_url
            download_url.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            download_url.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            download_url.LineBreak = LineBreak.Character;

            // MainWindow
            MainWindow.Clip = true;
            MainWindow.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 255f / 255f);
            this.MainWindow.AddChildLast(Label_1);
            this.MainWindow.AddChildLast(DownloadBtn);
            this.MainWindow.AddChildLast(download_url);

            //GridListPanel_1
            GridListPanel_1.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;

            // Scene
            this.RootWidget.AddChildLast(MainWindow);
            this.RootWidget.AddChildLast(GridListPanel_1);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }
		
		void HandleButton1ButtonAction(object sender, TouchEventArgs e)
		{
    		Label_1.Text = "Stop";
		}

		
        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
            case LayoutOrientation.Vertical:
                this.DesignWidth = 544;
                this.DesignHeight = 960;

                MainWindow.SetPosition(0, -14);
                MainWindow.SetSize(100, 100);
                MainWindow.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                MainWindow.Visible = true;

                Label_1.SetPosition(0, 91);
                Label_1.SetSize(214, 36);
                Label_1.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Label_1.Visible = true;

                DownloadBtn.SetPosition(690, 16);
                DownloadBtn.SetSize(214, 56);
                DownloadBtn.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                DownloadBtn.Visible = true;

                download_url.SetPosition(583, 19);
                download_url.SetSize(360, 56);
                download_url.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                download_url.Visible = true;

                GridListPanel_1.SetPosition(-16, 0);
                GridListPanel_1.SetSize(100, 50);
                GridListPanel_1.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                GridListPanel_1.Visible = true;

                break;

            default:
                this.DesignWidth = 960;
                this.DesignHeight = 544;

                MainWindow.SetPosition(0, 0);
                MainWindow.SetSize(960, 544);
                MainWindow.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                MainWindow.Visible = true;

                Label_1.SetPosition(100, 0);
                Label_1.SetSize(860, 554);
                Label_1.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                Label_1.Visible = true;

                DownloadBtn.SetPosition(661, 120);
                DownloadBtn.SetSize(173, 56);
                DownloadBtn.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                DownloadBtn.Visible = true;

                download_url.SetPosition(546, 40);
                download_url.SetSize(360, 56);
                download_url.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                download_url.Visible = true;

                GridListPanel_1.SetPosition(0, 0);
                GridListPanel_1.SetSize(100, 544);
                GridListPanel_1.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                GridListPanel_1.Visible = true;

                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
            Label_1.Text = "label";
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
    }
}
