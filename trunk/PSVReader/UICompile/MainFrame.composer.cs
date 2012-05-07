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

            // MainWindow
            MainWindow.Clip = true;
            MainWindow.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 255f / 255f);

            // Label_1
            Label_1.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Label_1.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            Label_1.LineBreak = LineBreak.Word;
            Label_1.VerticalAlignment = VerticalAlignment.Top;

            // Scene
            this.RootWidget.AddChildLast(MainWindow);
            this.RootWidget.AddChildLast(Label_1);

            SetWidgetLayout(orientation);

            UpdateLanguage();
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

                break;

            default:
                this.DesignWidth = 960;
                this.DesignHeight = 544;

                MainWindow.SetPosition(0, 0);
                MainWindow.SetSize(960, 544);
                MainWindow.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                MainWindow.Visible = true;

                Label_1.SetPosition(0, 0);
                Label_1.SetSize(960, 554);
                Label_1.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                Label_1.Visible = true;

                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
            Label_1.Text = "label";
        }
		
		public void UpdateText(string content)
		{
			Label_1.Text = content;
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
