
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace Gudu
{
	[Activity (Label = "早餐巴士", Icon = "@drawable/icon", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]			
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView(Resource.Layout.splashscreen);

			new Handler ().PostDelayed (
				() => {
					Intent intent = new Intent(this, typeof(TabSampleActivity));
					this.StartActivity(intent);
					this.Finish();
				}, 2000
			);
			// Create your application here
		}
	}
}

