// 这个类仅仅是用来过渡的类，因为这2个属性无法直接访问

using System;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
	public class StreamContainerWidget : ContainerWidget
	{
		public StreamContainerWidget ()
		{
		}
		
		public RootUIElement BaseRootUIElement
		{
			get
			{
				return this.RootUIElement;	
			}
		}
		
		public bool BaseClip
		{
			get
			{
				return this.Clip;
			}
			set
			{
				this.Clip = value;
			}
		}
	}
}

