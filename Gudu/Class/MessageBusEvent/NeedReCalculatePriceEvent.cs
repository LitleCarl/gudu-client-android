using System;
using DSoft.Messaging;

namespace Gudu
{
	public class NeedReCalculatePriceEvent : MessageBusEvent
	{

		public override string EventId{
			get{ 
				return "NeedReCalculatePrice";
			}
		}
		public NeedReCalculatePriceEvent ()
		{
		}
	}
}

