using System;
using System.Collections.Generic;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
	public class StreamPagePanel : Widget
	{
		private enum AnimationState
		{
			None,
			Drag,
			Flick
		}
		private const float defaultPagePanelPointWidth = 24f;
		private const float defaultPagePanelPointHeight = 24f;
		private StreamContainerWidget panelContainer;
		private StreamContainerWidget sprtContainer;
		private List<Panel> panelList;
		private List<UISprite> sprtList;
		private int pageCount;
		private int pageIndex;
		private float startPos;
		private float nextPos;
		private float touchDownLocalPos;
		private StreamPagePanel.AnimationState state;
		private ImageAsset activeImage;
		private ImageAsset normalImage;
		private bool animation;
		private float animationElapsedTime;
		private float animationStartPos;
		private PSVReader.ReadContentStream contentStrm;
		
		public PSVReader.ReadContentStream ContentStrm
		{
			set
			{
				contentStrm = value;
				InitData();
			}
		}
		
		public int PageCount
		{
			get
			{
				return this.pageCount;
			}
		}
		public int CurrentPageIndex
		{
			get
			{
				return this.pageIndex;
			}
			set
			{
				this.ScrollTo (value, false);
			}
		}
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
				this.updateSize ();
			}
		}
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				this.updateSize ();
			}
		}
		
		public StreamPagePanel ()
		{
			this.panelContainer = new StreamContainerWidget ();
			this.panelContainer.BaseClip = false;
			base.AddChildLast (this.panelContainer);
			this.sprtContainer = new StreamContainerWidget ();
			this.sprtContainer.BaseClip = false;
			base.AddChildLast (this.sprtContainer);
			this.panelList = new List<Panel> ();
			this.sprtList = new List<UISprite> ();
			this.pageCount = 0;
			this.pageIndex = -1;
			base.Clip = true;
			base.HookChildTouchEvent = true;
			this.state = StreamPagePanel.AnimationState.None;
			this.activeImage = new ImageAsset (SystemImageAsset.PagePanelActive);
			this.normalImage = new ImageAsset (SystemImageAsset.PagePanelNormal);
			DragGestureDetector dragGestureDetector = new DragGestureDetector ();
			dragGestureDetector.DragDetected += new EventHandler<DragEventArgs> (this.DragEventHandler);
			base.AddGestureDetector (dragGestureDetector);
			FlickGestureDetector flickGestureDetector = new FlickGestureDetector ();
			flickGestureDetector.Direction = FlickDirection.Horizontal;
			flickGestureDetector.FlickDetected += new EventHandler<FlickEventArgs> (this.FlickEventHandler);
			base.AddGestureDetector (flickGestureDetector);
		}
		protected override void DisposeSelf ()
		{
			if (this.activeImage != null)
			{
				this.activeImage.Dispose ();
				this.activeImage = null;
			}
			if (this.normalImage != null)
			{
				this.normalImage.Dispose ();
				this.normalImage = null;
			}
			base.DisposeSelf ();
		}
		public int AddPage ()
		{
			return this.InsertPage (this.pageCount, new Panel ());
		}
		public int AddPage (Panel panel)
		{
			return this.InsertPage (this.pageCount, panel);
		}
		public int InsertPage (int index, Panel panel)
		{
			if (index < 0 || index > this.pageCount)
			{
				throw new ArgumentOutOfRangeException ("index");
			}
			if (panel == null)
			{
				throw new ArgumentNullException ("panel");
			}
			panel.Y = 0f;
			panel.Width = this.Width;
			panel.Height = this.Height;
			if (index > 0)
			{
				this.panelContainer.InsertChildBefore (panel, this.panelList [index - 1]);
			}
			else
			{
				this.panelContainer.AddChildFirst (panel);
			}
			this.panelList.Insert (index, panel);
			this.updatePagePos ();
			UISprite uISprite = new UISprite (1);
			uISprite.ShaderType = ShaderType.Texture;
			uISprite.Image = this.normalImage;
			UISpriteUnit unit = uISprite.GetUnit (0);
			unit.X = 24f * (float)this.pageCount;
			unit.Y = 0f;
			unit.Width = 24f;
			unit.Height = 24f;
			this.sprtContainer.BaseRootUIElement.AddChildLast (uISprite);
			this.sprtList.Add (uISprite);
			this.pageCount++;
			if (this.pageIndex >= index || this.pageIndex == -1)
			{
				this.pageIndex++;
				this.panelContainer.X = -(this.Width * (float)this.pageIndex);
			}
			this.UpdateSprite ();
			return index;
		}
		public void InsertPage (int index)
		{
			this.InsertPage (index, new Panel ());
		}
		public bool RemovePage (Panel panel)
		{
			int num = this.panelList.IndexOf (panel);
			if (num < 0)
			{
				return false;
			}
			this.RemovePageAt (num);
			return true;
		}
		public void RemovePageAt (int index)
		{
			if (index < 0 || index >= this.pageCount)
			{
				throw new ArgumentOutOfRangeException ("index");
			}
			Panel child = this.panelList [index];
			this.panelContainer.RemoveChild (child);
			this.panelList.RemoveAt (index);
			this.updatePagePos ();
			this.sprtList [this.pageCount - 1].Dispose ();
			this.sprtList.RemoveAt (this.pageCount - 1);
			this.pageCount--;
			if (this.pageIndex > index || this.pageIndex == this.pageCount)
			{
				this.pageIndex--;
				this.panelContainer.X = -(this.Width * (float)this.pageIndex);
			}
			this.UpdateSprite ();
		}
		private void UpdateSprite ()
		{
			for (int i = 0; i < this.pageCount; i++)
			{
				this.sprtList [i].Image = ((this.pageIndex == i) ? this.activeImage : this.normalImage);
			}
			this.sprtContainer.X = (this.Width - 24f * (float)this.pageCount) / 2f;
			this.sprtContainer.Y = this.Height - 24f;
		}
		private void updatePagePos ()
		{
			for (int i = 0; i < this.panelList.Count; i++)
			{
				this.panelList [i].SetPosition (this.Width * (float)i, 0f);
			}
		}
		private void updateSize ()
		{
			if (this.panelList != null && this.sprtContainer != null)
			{
				for (int i = 0; i < this.panelList.Count; i++)
				{
					this.panelList [i].SetSize (this.Width, this.Height);
					this.panelList [i].SetPosition (this.Width * (float)i, 0f);
				}
				this.updatePagePos ();
				this.panelContainer.X = -(this.Width * (float)this.pageIndex);
				this.sprtContainer.X = (this.Width - 24f * (float)this.pageCount) / 2f;
				this.sprtContainer.Y = this.Height - 24f;
			}
		}
		public Panel GetPage (int index)
		{
			return this.panelList [index];
		}
		private void setCurrentPos (float distance)
		{
			this.panelContainer.X = this.startPos + distance;
			float num = 0f;
			float num2 = -this.Width * (float)(this.pageCount - 1);
			if (this.panelContainer.X > num)
			{
				this.panelContainer.X = num;
			}
			else
			{
				if (this.panelContainer.X < num2)
				{
					this.panelContainer.X = num2;
				}
			}
			int num3 = -(int)(this.panelContainer.X / this.Width);
			int num4 = this.pageIndex;
			this.pageIndex = (int)(0.5f - this.panelContainer.X / this.Width);
			if (num4 != this.pageIndex)
			{
				this.UpdateSprite ();
			}
			for (int i = 0; i < this.pageCount; i++)
			{
				this.panelList [i].Visible = (i == num3 || i == num3 + 1);
			}
		}
		public void InitData ()
		{
			Label newLabel = CreateOneCompetibleLabel();
			
			string content = contentStrm.GetThisPage(newLabel);
			
			newLabel.Text = content;
			
			this.AddPage();
			this.GetPage(0).AddChildLast(newLabel);
			
			this.PrepareNextPage();
			this.PreparePrevPage();
		}
		
		public void ScrollTo (int index, bool withAnimation)
		{
			PrepareNextPage();
			PreparePrevPage();
			
			if (index >= this.pageCount)
			{
				index = this.pageCount - 1;
			}
			else
			{
				if (index < 0)
				{
					index = 0;
				}
			}
			if (withAnimation)
			{
				this.animationStartPos = this.panelContainer.X;
				this.animationElapsedTime = 0f;
				this.nextPos = -(this.Width * (float)index);
				this.animation = true;
				return;
			}
			this.pageIndex = index;
			this.panelContainer.X = -(this.Width * (float)this.pageIndex);
			this.animation = false;
			this.SetupPageVisible ();
			this.UpdateSprite ();
		}
		protected override void OnUpdate (float elapsedTime)
		{
			base.OnUpdate (elapsedTime);
			if (this.animation)
			{
				this.animationElapsedTime += elapsedTime;
				this.panelContainer.X = (this.animationStartPos - this.nextPos) * (float)Math.Exp ((double)(-(double)this.animationElapsedTime * 0.011997601f)) + this.nextPos;
				int num = -(int)(this.panelContainer.X / this.Width);
				for (int i = 0; i < this.pageCount; i++)
				{
					this.panelList [i].Visible = (i == num || i == num + 1);
				}
				float num2 = this.nextPos - this.panelContainer.X;
				this.pageIndex = (int)(0.5f - this.panelContainer.X / this.Width);
				this.UpdateSprite ();
				if (num2 < 1f && num2 > -1f)
				{
					this.panelContainer.X = this.nextPos;
					this.animation = false;
					this.state = StreamPagePanel.AnimationState.None;
					this.SetupPageVisible ();
				}
			}
		}
		
		protected override void OnTouchEvent (TouchEventCollection touchEvents)
		{
			base.OnTouchEvent (touchEvents);
			TouchEvent primaryTouchEvent = touchEvents.PrimaryTouchEvent;
			if (primaryTouchEvent.Type == TouchEventType.Down)
			{
				this.animation = false;
				this.startPos = this.panelContainer.X;
				this.touchDownLocalPos = primaryTouchEvent.LocalPosition.X;
				this.state = StreamPagePanel.AnimationState.None;
			}
			if (primaryTouchEvent.Type == TouchEventType.Up && this.state != StreamPagePanel.AnimationState.Flick)
			{
				this.ScrollTo (this.pageIndex, true);
			}
			if (this.state != StreamPagePanel.AnimationState.Drag && this.state != StreamPagePanel.AnimationState.Flick)
			{
				touchEvents.Forward = true;
			}
		}
		private void DragEventHandler (object sender, DragEventArgs e)
		{
			base.ResetState (false);
			this.state = StreamPagePanel.AnimationState.Drag;
			this.setCurrentPos (e.LocalPosition.X - this.touchDownLocalPos);
		}
		private void FlickEventHandler (object sender, FlickEventArgs e)
		{
			base.ResetState (false);
			this.state = StreamPagePanel.AnimationState.Flick;
			int num = -(int)(this.panelContainer.X / this.Width);
			if (e.Speed.X < 0f)
			{
				this.ScrollTo (num + 1, true);
			}
			else
			{
				this.ScrollTo (num, true);
			}
			this.animation = true;
		}
		private void SetupPageVisible ()
		{
			for (int i = 0; i < this.pageCount; i++)
			{
				this.panelList [i].Visible = (this.pageIndex == i);
			}
		}
		
		private Label CreateOneCompetibleLabel()
		{
			Label newLabel = new Label();
			
			newLabel.Width = this.Width;
			newLabel.Height = this.Height;
			
			return newLabel;
		}
		
		private void PreparePrevPage()
		{
			if (null == contentStrm)
				return;
			
			if (this.pageIndex > 0)
				// already have one
				return;
			
			if (contentStrm.HasPrev())
			{
				this.InsertPage(this.pageIndex);
				
				Label newLabel = CreateOneCompetibleLabel();
				
				this.GetPage(this.pageIndex).AddChildLast(newLabel);
				
				string strcontent = contentStrm.GetPrevPage(newLabel);
				
				newLabel.Text = strcontent;
			}
		}
		
		private void PrepareNextPage()
		{
			if (null == contentStrm)
				return;
			
			if (this.pageIndex < this.pageCount - 1)
				// already have one
				return;
			
			if (contentStrm.HasPrev())
			{
				this.InsertPage(this.pageIndex);
				
				Label newLabel = CreateOneCompetibleLabel();
				
				this.GetPage(this.pageIndex).AddChildLast(newLabel);
				
				string strcontent = contentStrm.GetPrevPage(newLabel);
				
				newLabel.Text = strcontent;
			}
		}
	}
}
