using System;
using DSoft.Messaging;

namespace Gudu
{
	public class OrderLoadMoreOverEvent: MessageBusEvent
	{
		public override string EventId{
			get{ 
				return "OrderLoadMoreOver";
			}
		}
		public OrderLoadMoreOverEvent ()
		{
		}
	}
}

