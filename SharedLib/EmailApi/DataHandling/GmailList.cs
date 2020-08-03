using System;
using System.Collections.Generic;
using System.Text;

namespace EmailApi.DataHandling
{
	public class GmailList
	{
		public class GmailRoot
		{
			public Message[] messages { get; set; }
			public int resultSizeEstimate { get; set; }
		}

		public class Message
		{
			public string id { get; set; }
			public string threadId { get; set; }
		}

	}
}
