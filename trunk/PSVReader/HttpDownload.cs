using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Net;
using System.Text;

namespace PSVReader
{
	public class RequestState
	{
		// This class stores the State of the request.
		const int BUFFER_SIZE = 1024;
		//public StringBuilder requestData;
		public List<byte> RawData;
		public byte[] BufferRead;
		public HttpWebRequest request;
		public HttpWebResponse response;
		public Stream streamResponse;
		public RequestState()
		{
			BufferRead = new byte[BUFFER_SIZE];
		    //requestData = new StringBuilder("");
			RawData = new List<byte>();
		    request = null;
		    streamResponse = null;
		}
	}
	
	public interface IDownloadComplete
	{
		void OnDownloadComplete(object state);
	}
	
	public class HttpDownload
	{
		// 用event无法在psv上跑，会死锁。不理解。
	  	//public static ManualResetEvent allDone= new ManualResetEvent(false);  
		const int BUFFER_SIZE = 1024;
		const int DefaultTimeout = 2 * 60; // 2 minutes timeout
		static object state;
		static IDownloadComplete icb;
		static System.DateTime startTime;
		
		public enum ConnectEvent:uint
        {
            Idel=0,
			DownloadWaiting=1,
            Downloading=2,
            Finish=3,
			ErrorEnding=4,
			TimeOut=5,
        }
		private static ConnectEvent cntEvent = ConnectEvent.Idel;
		private static HttpWebRequest myHttpWebRequest;
		private static RequestState myRequestState;
			
		public HttpDownload ()
		{
			startTime = new System.DateTime();
		}
		
		private static void SetState(ConnectEvent errcode)
		{
			cntEvent = errcode;
			
			if (errcode == ConnectEvent.DownloadWaiting)
			{
				startTime = System.DateTime.Now;
			}
		}
		
		private static bool IsState(ConnectEvent Cnntevent)
		{
			return cntEvent == Cnntevent;
		}
		
		// Abort the request if the timer fires.
	  	private static void DoOnTimeout(object state, bool timedOut) { 
	      	if (timedOut) {
	          	HttpWebRequest request = state as HttpWebRequest;
	          	if (request != null) {
	              	request.Abort();
	        	}
				SetState(ConnectEvent.TimeOut);
	      	}
		}
		
		public static byte[] GetRawData()
		{
			if (null == myRequestState)
				return null;
			
			if(cntEvent == ConnectEvent.Downloading ||
			   myRequestState.RawData.Count == 0)
			{
				return null;
			}
			
			return myRequestState.RawData.ToArray();
		}
		
		public static bool DownloadContent(string url, IDownloadComplete iDownCB, object objState)
		{
			if (cntEvent != ConnectEvent.Idel)
			{
				return false;
			}
			
			SetState(ConnectEvent.DownloadWaiting);
			icb = iDownCB;
			state = objState;
			
	        try 
			{
	             // Create a HttpWebrequest object to the desired URL. 
      			myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			  	/**
			    * If you are behind a firewall and you do not have your browser proxy setup
			    * you need to use the following proxy creation code.
			
		      	// Create a proxy object.
		      	WebProxy myProxy = new WebProxy();
		
		      	// Associate a new Uri object to the _wProxy object, using the proxy address
		      	// selected by the user.
		      	myProxy.Address = new Uri("http://myproxy");
		
		
		      	// Finally, initialize the Web request object proxy property with the _wProxy
		      	// object.
		      	myHttpWebRequest.Proxy=myProxy;
		    	***/
			
		      	// Create an instance of the RequestState and assign the previous myHttpWebRequest
		      	// object to its request field.  
		      	myRequestState = new RequestState();  
		      	myRequestState.request = myHttpWebRequest;
		
		
		      	// Start the asynchronous request.
		      	IAsyncResult result=
					(IAsyncResult) myHttpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback), myRequestState);
		
		      	// this line implements the timeout, if there is a timeout, the callback fires and the request becomes aborted
		      	//ThreadPool.RegisterWaitForSingleObject (result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), myHttpWebRequest, DefaultTimeout, true);
		
		      	// The response came in the allowed time. The work processing will happen in the 
		      	// callback function.
				// event的方式会导致PSV死锁，可能是同步方式的问题，修改为忙等待方式
		      	//allDone.WaitOne();
		
		      	// Release the HttpWebResponse resource.
		      	//myRequestState.response.Close();
		    }
		    catch(WebException e)
		    {
				SetState(ConnectEvent.ErrorEnding);
		    }
		    catch(Exception e)
		    {
				SetState(ConnectEvent.ErrorEnding);
		    }
			
	        return true;			
		}
		
		public static void Update()
		{
			if(IsState(ConnectEvent.DownloadWaiting))
			{
				if (null == startTime)
					SetState(ConnectEvent.ErrorEnding);
				
				TimeSpan ts = System.DateTime.Now - startTime;
				if (ts.Seconds > DefaultTimeout)
					DoOnTimeout(myHttpWebRequest, true);
			}
			
			if(IsState(ConnectEvent.Finish))
			{
				myRequestState.response.Close();
				cntEvent = ConnectEvent.Idel;
					
				// 下载到东西后以回调方式通知
				if (myRequestState.RawData.Count != 0 && null != icb)
				{
					icb.OnDownloadComplete(state);
				}
			}
			
			if (IsState(ConnectEvent.ErrorEnding) ||
			    IsState(ConnectEvent.TimeOut))
			{
				SetState(ConnectEvent.Idel);
			}
		}
		
		private static void RespCallback(IAsyncResult asynchronousResult)
		{
		    try
		    {
				SetState(ConnectEvent.Downloading);
				
		      	// State of request is asynchronous.
		      	RequestState myRequestState=(RequestState) asynchronousResult.AsyncState;
		      	HttpWebRequest  myHttpWebRequest=myRequestState.request;
		      	myRequestState.response = (HttpWebResponse) myHttpWebRequest.EndGetResponse(asynchronousResult);
		
		      	// Read the response into a Stream object.
		      	Stream responseStream = myRequestState.response.GetResponseStream();
		      	myRequestState.streamResponse=responseStream;
		
		      	// Begin the Reading of the contents of the HTML page and print it to the console.
		      	IAsyncResult asynchronousInputRead = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
		      	return;
		    }
		    catch(WebException e)
		    {
		      	Console.WriteLine("\nRespCallback Exception raised!");
		      	Console.WriteLine("\nMessage:{0}",e.Message);
		      	Console.WriteLine("\nStatus:{0}",e.Status);
		    }
		    //allDone.Set();
		}
			
		private static  void ReadCallBack(IAsyncResult asyncResult)
		{
		    try
		    {
		    	RequestState myRequestState = (RequestState)asyncResult.AsyncState;
		    	Stream responseStream = myRequestState.streamResponse;
		    	int read = responseStream.EndRead( asyncResult );
		    
				// Read the HTML page and then print it to the console.
		    	if (read > 0)
		    	{
					foreach(byte bData in myRequestState.BufferRead)
					{
						myRequestState.RawData.Add(bData);
					}

		      		//myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.BufferRead, 0, read));
		      		IAsyncResult asynchronousResult = responseStream.BeginRead( myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
		      		return;
		    	}
		   		else
		    	{
		     		Console.WriteLine("\nThe contents of the Html page are : ");
		      		/*if(myRequestState.requestData.Length>1)
		      		{
		        		string stringContent;
		        		stringContent = myRequestState.requestData.ToString();
		        		Console.WriteLine(stringContent);
		      		}*/
					//myRequestState.RawData[0] = myRequestState.RawData[0];
		      		responseStream.Close();					
					SetState(ConnectEvent.Finish);
		   		}
		    }
		    catch(WebException e)
		    {
		      	Console.WriteLine("\nReadCallBack Exception raised!");
		      	Console.WriteLine("\nMessage:{0}",e.Message);
		      	Console.WriteLine("\nStatus:{0}",e.Status);
		    }
		    //allDone.Set();
		}
	}
}

