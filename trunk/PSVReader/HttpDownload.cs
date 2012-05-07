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
		
	public class HttpDownload
	{
		// 用event无法在psv上跑，会死锁。不理解。
	  	//public static ManualResetEvent allDone= new ManualResetEvent(false);  
		const int BUFFER_SIZE = 1024;
		const int DefaultTimeout = 2 * 60 * 1000; // 2 minutes timeout
		
		public enum ConnectEvent:uint
        {
            Idel=0,
            Downloading=1,
            Finish=2,
        }
		private static ConnectEvent cntEvent = ConnectEvent.Idel;
		private static HttpWebRequest myHttpWebRequest;
		private static RequestState myRequestState;
			
		public HttpDownload ()
		{
		}
		
		// Abort the request if the timer fires.
	  	private static void TimeoutCallback(object state, bool timedOut) { 
	      	if (timedOut) {
	          	HttpWebRequest request = state as HttpWebRequest;
	          	if (request != null) {
	              	request.Abort();
					cntEvent = ConnectEvent.Finish;
	        	}
	      	}
		}
		
		public static byte[] GetRawData()
		{
			if(cntEvent == ConnectEvent.Downloading ||
			   myRequestState.RawData.Count == 0)
			{
				return null;
			}
			
			return myRequestState.RawData.ToArray();
		}
		
		public static bool DownloadContent(string url)
		{
			if (cntEvent != ConnectEvent.Idel)
			{
				return false;
			}
			
			cntEvent = ConnectEvent.Downloading;
			
	        try 
			{
	             // Create a HttpWebrequest object to the desired URL. 
      			myHttpWebRequest= (HttpWebRequest)WebRequest.Create(url);
					
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
		      	ThreadPool.RegisterWaitForSingleObject (result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), myHttpWebRequest, DefaultTimeout, true);
		
		      	// The response came in the allowed time. The work processing will happen in the 
		      	// callback function.
				// event的方式会导致PSV死锁，可能是同步方式的问题，修改为忙等待方式
		      	//allDone.WaitOne();
		
		      	// Release the HttpWebResponse resource.
		      	//myRequestState.response.Close();
		    }
		    catch(WebException e)
		    {
		      	Console.WriteLine("\nMain Exception raised!");
		      	Console.WriteLine("\nMessage:{0}",e.Message);
		      	Console.WriteLine("\nStatus:{0}",e.Status);
		      	Console.WriteLine("Press any key to continue..........");
				cntEvent = ConnectEvent.Finish;
		    }
		    catch(Exception e)
		    {
		      	Console.WriteLine("\nMain Exception raised!");
		      	Console.WriteLine("Source :{0} " , e.Source);
		      	Console.WriteLine("Message :{0} " , e.Message);
		      	Console.WriteLine("Press any key to continue..........");
		      	Console.Read();
				cntEvent = ConnectEvent.Finish;
		    }
	
	        return true;			
		}
		
		public static void Update()
		{
			if(cntEvent == ConnectEvent.Finish)
			{
				myRequestState.response.Close();
				cntEvent = ConnectEvent.Idel;				
			}
		}
		
		private static void RespCallback(IAsyncResult asynchronousResult)
		{
		    try
		    {
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
					cntEvent = ConnectEvent.Finish;
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
