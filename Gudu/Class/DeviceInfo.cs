using System;
using Android.Views;
using Android.Content;
using Android.App;
using Android.Util;

namespace Gudu
{
	public static class DeviceInfo
	{
		public static float kScreenWidthInPixel (Activity activity){
			Display display = activity.WindowManager.DefaultDisplay;
			DisplayMetrics outMetrics = new DisplayMetrics ();
			display.GetMetrics(outMetrics);
			float dpWidth  = outMetrics.WidthPixels;
			return dpWidth;
		}
		public static float kScreenHeightInPixel (Activity activity){
			Display display = activity.WindowManager.DefaultDisplay;
			DisplayMetrics outMetrics = new DisplayMetrics ();
			display.GetMetrics(outMetrics);
			float dpHeight = outMetrics.HeightPixels;
			return dpHeight;
		}
		public static float kScreenWidth (Activity activity){
			Display display = activity.WindowManager.DefaultDisplay;
			DisplayMetrics outMetrics = new DisplayMetrics ();
			display.GetMetrics(outMetrics);

			float density  = activity.Resources.DisplayMetrics.Density;
			float dpWidth  = outMetrics.WidthPixels / density;
			return dpWidth;
		}
		public static float kScreenHeight (Activity activity){
			Display display = activity.WindowManager.DefaultDisplay;
			DisplayMetrics outMetrics = new DisplayMetrics ();
			display.GetMetrics(outMetrics);

			float density  = activity.Resources.DisplayMetrics.Density;
			float dpHeight = outMetrics.HeightPixels / density;
			return dpHeight;
		}
	}
}

