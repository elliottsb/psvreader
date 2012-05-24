using System;
using Sce.Pss.HighLevel.UI;
using Sce.Pss.Core.Imaging;

namespace PSVReaderUI
{
	public class AutoFixPanel : ScrollPanel
	{
		Label ContentLabel;
		
		public string Text
        {
            get
            {
                return ContentLabel.Text;
            }
            set
            {
                ContentLabel.Text = value;
				ResetSizeBycontent();
            }
        }
		
		public AutoFixPanel ()
		{
			InitializeWidget();
		}
		
		private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
			ContentLabel = new Label();
			ContentLabel.Name = "ContentLabel";
			
			// ContentLabel	
			ContentLabel.BackgroundColor = new UIColor(0.5f, 0.8f, 0.5f, 1.0f);
			ContentLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            ContentLabel.Font = new Font(FontAlias.System, 25, FontStyle.Regular);
            ContentLabel.LineBreak = LineBreak.Character;
			ContentLabel.HorizontalAlignment = HorizontalAlignment.Left;
			ContentLabel.VerticalAlignment = VerticalAlignment.Top;
			
            // ScrollPanel_Text
            this.HorizontalScroll = false;
            this.VerticalScroll = true;
            this.ScrollBarVisibility = ScrollBarVisibility.ScrollableVisible;
			this.PanelWidth = 960;
            this.PanelHeight = 20000;
            this.PanelX = 0;
            this.PanelY = 0;
			this.AddChildLast(ContentLabel);
        }
		
		public void ResetSizeBycontent()
		{
			this.PanelWidth = ContentLabel.Width;
			this.PanelHeight = ContentLabel.Height;
			ContentLabel.SetSize(this.Width, ContentLabel.TextHeight);
		}
		
		private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
			case LayoutOrientation.Vertical:				
                ContentLabel.SetPosition(0, 0);
                ContentLabel.SetSize(544, 960);
                ContentLabel.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ContentLabel.Visible = true;				

                break;

            default:				
                ContentLabel.SetPosition(0, 0);
                ContentLabel.SetSize(960, 544);
                ContentLabel.Anchors = Anchors.Top | Anchors.Height | Anchors.Left | Anchors.Width;
                ContentLabel.Visible = true;
				
                break;
            }
            _currentLayoutOrientation = orientation;
        }
	}
}

