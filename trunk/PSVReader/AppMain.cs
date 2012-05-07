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
			
			// TODO: Create scenes and call UISystem.SetScene
			// Create scene			
			UISystem.Initialize(graphics);
			
			MainWnd = new PSVReaderUI.MainFrame();
			// Set scene
			UISystem.SetScene(MainWnd, null);
			
			HttpDownload.DownloadContent("http://192.168.1.102/1234.txt");		
			
			var tmpString = "12321a中文测试";

			UnicodeEncoding encoding = new UnicodeEncoding();    
			byte[] tmpbyte = encoding.GetBytes(tmpString);
			
			PSVReader.FileStorage onefile = new PSVReader.FileStorage("/Application/1.txt");
			onefile.WriteContent(tmpbyte);
			
			tmpString = "223";
			tmpString = encoding.GetString(onefile.ReadContent());
			
			//MainWnd.UpdateText(tmpString);	
		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			
			// Query touch for current state
            List<TouchData> touchDataList = Touch.GetData (0);
			
			//MainWnd.UpdateText("中文测试");
			
            // Update UI Toolkit
            UISystem.Update(touchDataList);
			
			HttpDownload.Update();
			
			byte[] byttemp = HttpDownload.GetRawData();
			
			if (null != byttemp)
			{
				ASCIIEncoding encoding = new ASCIIEncoding();   
				var tempstring = encoding.GetString(byttemp);
			
				//MainWnd.UpdateText(tempstring);			
			}
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
