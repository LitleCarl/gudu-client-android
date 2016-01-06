using System;
using Android.App;

namespace Gudu
{
	public abstract class IAlertViewActivity: Activity
	{
		public bool AlertIsShown{
			get;set;
		}
	}
}

