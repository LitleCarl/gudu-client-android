using System;
using DSoft.Messaging;

namespace Gudu
{
	public class OrderRefreshOverEvent: MessageBusEvent
	{
		public override string EventId{
			get{ 
				return "OrderRefreshOver";
			}
		}
		public OrderRefreshOverEvent ()
		{
		}
	}
}

