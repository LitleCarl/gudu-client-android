
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
using MaterialUI.Widget;
using Android.Support.V4;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Java.Lang;

namespace Gudu
{
	[Activity (Label = "StoreIndexActivity")]			
	public class StoreIndexActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.store_index_activity);
			initUI ();
			// Create your application here
		}	
		void initUI(){
			TabPageIndicator tab_indicator = FindViewById<TabPageIndicator>(Resource.Id.tab_indicator);
			Android.Support.V4.View.ViewPager pager = FindViewById<Android.Support.V4.View.ViewPager> (Resource.Id.menuViewPager);

			pager.Adapter = new MenuPagerAdapter(SupportFragmentManager);

			tab_indicator.SetViewPager (pager);
		}


	}
		
	/// <summary>
	/// fragment类型
	/// </summary>
	public class FragmentForMenuListView: Android.Support.V4.App.Fragment{
		public FragmentForMenuListView(): base(){
			
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.Main, container, false);
		}
	}
	public class MenuPagerAdapter: FragmentStatePagerAdapter{
		public MenuPagerAdapter(Android.Support.V4.App.FragmentManager fm): base(fm){
		}
		public override Android.Support.V4.App.Fragment GetItem (int position){
			return new FragmentForMenuListView();
		}

		public override int Count{
			get{ 
				return	5;
			}
		}

		public override ICharSequence GetPageTitleFormatted (int position){
			return CharSequence.ArrayFromStringArray(new string[]{"包子", "豆浆","包子", "豆浆","包子", "豆浆"})[position];
		}

	}
}

