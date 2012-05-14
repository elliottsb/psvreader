// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.Pss.Core;
using Sce.Pss.Core.Imaging;
using Sce.Pss.Core.Environment;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
    partial class StoryNameListItem
    {
        Label Label_Story;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            Label_Story = new Label();
            Label_Story.Name = "Label_Story";

            // Label_Story
            Label_Story.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Label_Story.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            Label_Story.LineBreak = LineBreak.Character;

            //StoryNameListItem
            this.BackgroundColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 0f / 255f);

            // ListPanelItem
            this.AddChildLast(Label_Story);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
            case LayoutOrientation.Vertical:
                this.SetSize(50, 100);
                this.Anchors = Anchors.None;

                Label_Story.SetPosition(-86, 0);
                Label_Story.SetSize(214, 36);
                Label_Story.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Label_Story.Visible = true;

                break;

            default:
                this.SetSize(100, 50);
                this.Anchors = Anchors.None;

                Label_Story.SetPosition(8, 7);
                Label_Story.SetSize(84, 35);
                Label_Story.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                Label_Story.Visible = true;

                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
            Label_Story.Text = "label";
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

        public static ListPanelItem Creator()
        {
            return new StoryNameListItem();
        }
    }
}
