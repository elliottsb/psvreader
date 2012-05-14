// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.Pss.Core;
using Sce.Pss.Core.Imaging;
using Sce.Pss.Core.Environment;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
    partial class DownloadUI
    {
        EditableText download_url;
        Button DownloadBtn;
        EditableText EditableText_1;
        EditableText EditableText_2;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            download_url = new EditableText();
            download_url.Name = "download_url";
            DownloadBtn = new Button();
            DownloadBtn.Name = "DownloadBtn";
            EditableText_1 = new EditableText();
            EditableText_1.Name = "EditableText_1";
            EditableText_2 = new EditableText();
            EditableText_2.Name = "EditableText_2";

            // download_url
            download_url.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            download_url.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            download_url.LineBreak = LineBreak.Character;

            // DownloadBtn
            DownloadBtn.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            DownloadBtn.TextFont = new Font( FontAlias.System, 25, FontStyle.Regular);

            // EditableText_1
            EditableText_1.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            EditableText_1.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            EditableText_1.LineBreak = LineBreak.Character;

            // EditableText_2
            EditableText_2.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            EditableText_2.Font = new Font( FontAlias.System, 25, FontStyle.Regular);
            EditableText_2.LineBreak = LineBreak.Character;

            // DownloadUI

            // Dialog
            this.AddChildLast(download_url);
            this.AddChildLast(DownloadBtn);
            this.AddChildLast(EditableText_1);
            this.AddChildLast(EditableText_2);
            this.ShowEffect = new BunjeeJumpEffect()
            {
            };
            this.HideEffect = new TiltDropEffect();

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
            case LayoutOrientation.Vertical:
                this.SetPosition(0, 0);
                this.SetSize(300, 500);
                this.Anchors = Anchors.None;

                download_url.SetPosition(583, 19);
                download_url.SetSize(360, 56);
                download_url.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                download_url.Visible = true;

                DownloadBtn.SetPosition(690, 16);
                DownloadBtn.SetSize(214, 56);
                DownloadBtn.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                DownloadBtn.Visible = true;

                EditableText_1.SetPosition(-99, 108);
                EditableText_1.SetSize(360, 56);
                EditableText_1.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                EditableText_1.Visible = true;

                EditableText_2.SetPosition(118, 124);
                EditableText_2.SetSize(360, 56);
                EditableText_2.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                EditableText_2.Visible = true;

                break;

            default:
                this.SetPosition(0, 0);
                this.SetSize(500, 300);
                this.Anchors = Anchors.None;

                download_url.SetPosition(49, 30);
                download_url.SetSize(419, 56);
                download_url.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                download_url.Visible = true;

                DownloadBtn.SetPosition(190, 216);
                DownloadBtn.SetSize(126, 56);
                DownloadBtn.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                DownloadBtn.Visible = true;

                EditableText_1.SetPosition(49, 124);
                EditableText_1.SetSize(188, 56);
                EditableText_1.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                EditableText_1.Visible = true;

                EditableText_2.SetPosition(287, 124);
                EditableText_2.SetSize(181, 56);
                EditableText_2.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                EditableText_2.Visible = true;

                break;
            }
            _currentLayoutOrientation = orientation;
        }
        public void UpdateLanguage()
        {
            download_url.Text = "http:\\\\192.186.1.102\\123.txt";
            DownloadBtn.Text = "Download";
            EditableText_1.Text = "Edit";
            EditableText_2.Text = "Edit";
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
