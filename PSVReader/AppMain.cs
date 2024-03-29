using System;
using System.Collections.Generic;

using Sce.Pss.Core;
using Sce.Pss.Core.Environment;
using Sce.Pss.Core.Graphics;
using Sce.Pss.Core.Input;
using Sce.Pss.HighLevel.UI;
using System.Text; 

namespace PSVReader
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		private static PSVReaderUI.MainFrame MainWnd;
		
		public static void Main (string[] args)
		{
			Initialize ();

			while (true) {
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}

		public static void Initialize ()
		{
			// Set up the graphics system
			graphics = new GraphicsContext ();
			
			Logic.Init();
			// TODO: Create scenes and call UISystem.SetScene
			// Create scene			
			UISystem.Initialize(graphics);
			
			MainWnd = new PSVReaderUI.MainFrame();
			
			// Set scene
			UISystem.SetScene(MainWnd, null);
		}
		
		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			
			// Query touch for current state
            List<TouchData> touchDataList = Touch.GetData (0);
			
            // Update UI Toolkit
            UISystem.Update(touchDataList);
			
			HttpDownload.Update();
		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear ();
			
			// Render UI Toolkit
            UISystem.Render ();
			
			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
