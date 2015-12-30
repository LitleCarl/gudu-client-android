using System;
using DSoft.Messaging;

namespace Gudu
{
	public class NeedFetchUserInfoEvent : MessageBusEvent
	{
		public override string EventId{
			get{ 
				return "NeedFetchUserInfo";
			}
		}
		public NeedFetchUserInfoEvent ()
		{
		}
	}
}

