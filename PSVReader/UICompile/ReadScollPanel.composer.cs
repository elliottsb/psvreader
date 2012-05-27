// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.Pss.Core;
using Sce.Pss.Core.Imaging;
using Sce.Pss.Core.Environment;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
    partial class ReadScollPanel
    {
        StreamPagePanel ScrollPanel_Text;
		
		public PSVReader.ReadContentStream ContentStrm
        {
            set
            {
                ScrollPanel_Text.ContentStrm = value;
            }
        }
		
        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            ScrollPanel_Text = new StreamPagePanel();
            ScrollPanel_Text.Name = "ScrollPanel_Text";

            // ReadScollPanel
            this.BackgroundColor = new UIColor(153f / 255f, 100f / 255f, 153f / 255f, 255f / 255f);
            this.Clip = true;

            // Panel
            this.AddChildLast(ScrollPanel_Text);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
            case LayoutOrientation.Vertical:
                this.SetSize(544, 860);
                this.Anchors = Anchors.None;

                ScrollPanel_Text.SetPosition(150, 106);
                ScrollPanel_Text.SetSize(100, 50);
                ScrollPanel_Text.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ScrollPanel_Text.Visible = true;

                break;

            default:
                this.SetSize(860, 544);
                this.Anchors = Anchors.None;

                ScrollPanel_Text.SetPosition(0, 0);
                ScrollPanel_Text.SetSize(860, 544);
                ScrollPanel_Text.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                ScrollPanel_Text.Visible = true;

                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
        }
        public void InitializeDefaultEffect()
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
        public void StartDefaultEffect()
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
