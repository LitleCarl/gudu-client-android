
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
using Android.Preferences;

namespace Gudu
{
	[Activity (Label = "咕嘟早餐", Icon = "@drawable/icon", MainLauncher = true)]			
	public class TabSampleActivity : TabActivity
	{
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView(Resource.Layout.tab_main);
			initAPP ();
			SetTabs() ;
		}

		void initAPP(){
			Tool.sharedInstance = PreferenceManager.GetDefaultSharedPreferences (this);
		}

		private void SetTabs()
		{

			AddTab("首页", Resource.Drawable.tab_home, typeof(MainActivity));
			AddTab("购物车", Resource.Drawable.tab_cart, typeof(CartActivity));
			AddTab("我", Resource.Drawable.tab_mine, typeof(MineActivity));

		}

		private void AddTab(string labelId, int drawableId, Type c)
		{
			TabHost tabHost = FindViewById<TabHost>(Android.Resource.Id.TabHost);
			Intent intent = new Intent(this, c);
			TabHost.TabSpec spec = tabHost.NewTabSpec("tab" + labelId);	

			View tabIndicator = LayoutInflater.From(this).Inflate(Resource.Layout.tab_indicator, FindViewById<TabWidget>(Android.Resource.Id.Tabs), false);
			TextView title = (TextView) tabIndicator.FindViewById(Resource.Id.title);
			title.Text = (labelId);
			ImageView icon = tabIndicator.FindViewById<ImageView>(Resource.Id.icon);
			icon.SetImageResource(drawableId);

			spec.SetIndicator(tabIndicator);
			spec.SetContent(intent);
			tabHost.AddTab(spec);
		}
	}

}

