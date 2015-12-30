using System;
using DSoft.Messaging;
using GuduCommon;

namespace Gudu
{
	public class SelectCouponEvent : MessageBusEvent
	{
		public CouponModel coupon;
		public override string EventId{
			get{ 
				return "SelectCoupon";
			}
		}
		public SelectCouponEvent ()
		{
		}
	}
}

