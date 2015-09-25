using System;
using DSoft.Messaging;

namespace Gudu
{
	public class CartItemChangedEvent : MessageBusEvent
	{
		
		public override string EventId{
			get{ 
				return "CART_CHANGED";
			}
		}

		public CartItemChangedEvent ()
		{
		}
	}
}

