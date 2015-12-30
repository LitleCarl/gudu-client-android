using System;
using DSoft.Messaging;

namespace Gudu
{
	public class PaymentDoneEvent : MessageBusEvent
	{
		public String PayMethod {
			get;
			set;
		}

		public bool PayDone {
			get;
			set;
		}

		public PaymentDoneEvent ()
		{
		}
		public override string EventId{
			get{ 
				return "PaymentDone";
			}
		}
			
	}
}

