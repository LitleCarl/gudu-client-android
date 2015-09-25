using System;
using DSoft.Messaging;

namespace Gudu
{
	public class CartEmptyEvent : MessageBusEvent
	{

		public override string EventId{
			get{ 
				return "CartEmpty";
			}
		}

		public CartEmptyEvent ()
		{
		}
	}
}

