using System;
using Com.Tencent.MM.Sdk.Openapi;
using Android.Content;

namespace Gudu
{
	public class WXApiManager
	{
		private static WXApiManager sharedManager;
		private static string app_id = "wxc4638e10bf2d70d1";

		public IWXAPI api;
		public static WXApiManager manager(Context context){
			if (sharedManager == null){
				sharedManager = new WXApiManager ();

				sharedManager.api = WXAPIFactory.CreateWXAPI (context, app_id);
				sharedManager.api.RegisterApp (app_id);
			}
			return sharedManager;
		}
		public WXApiManager ()
		{
		}
	}
}

