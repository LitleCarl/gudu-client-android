using System;
using DSoft.Messaging;

namespace Gudu
{
	public class LoginDoneEvent : MessageBusEvent
	{

		public override string EventId{
			get{ 
				return "LoginDone";
			}
		}

		public LoginDoneEvent ()
		{
		}
	}
}

