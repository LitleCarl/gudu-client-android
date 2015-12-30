
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
using System.Reactive.Linq;
using DSoft.Messaging;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content.PM;
using Com.Tencent.MM.Sdk.Openapi;
using Com.Tencent.MM.Sdk.Modelbase;
using Com.Tencent.MM.Sdk.Modelmsg;

namespace Gudu
{
	[Activity (Label = "早餐巴士", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class TabSampleActivity : TabActivity, IWXAPIEventHandler
	{
		private TabHost tabHost;
		private List<TabHost.TabSpec> specList;



		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			//RequestWindowFeature (WindowFeatures.ActionBar);

			SetContentView(Resource.Layout.tab_main);
			initAPP ();
			SetTabs() ;
			setUpTrigger ();

			initWeixin ();

		}

		void initWeixin(){
			
		}

		void initAPP(){
			Tool.sharedInstance = PreferenceManager.GetDefaultSharedPreferences (this);
		}

		private void SetTabs()
		{
			specList = new List<TabHost.TabSpec> ();
			AddTab("首页", Resource.Drawable.tab_home, typeof(MainActivity));
			AddTab("购物车", Resource.Drawable.tab_cart, typeof(CartActivity));
			AddTab("我", Resource.Drawable.tab_mine, typeof(LoginActivity));
			InvalidTabs ();			
		}

		private void InvalidTabs(){
			tabHost.ClearAllTabs();
			specList.ForEach (
				(item) => {
					tabHost.AddTab(item);
				}
			);
		}

		private void AddTab(string labelId, int drawableId, Type c)
		{
			tabHost = FindViewById<TabHost>(Android.Resource.Id.TabHost);
			Intent intent = new Intent(this, c);
			TabHost.TabSpec spec = tabHost.NewTabSpec("tab" + labelId);	

			View tabIndicator = LayoutInflater.From(this).Inflate(Resource.Layout.tab_indicator, FindViewById<TabWidget>(Android.Resource.Id.Tabs), false);
			TextView title = (TextView) tabIndicator.FindViewById(Resource.Id.title);
			title.Text = (labelId);
			ImageView icon = tabIndicator.FindViewById<ImageView>(Resource.Id.icon);
			icon.SetImageResource(drawableId);

			spec.SetIndicator(tabIndicator);
			spec.SetContent(intent);
			specList.Add (spec);
		}

		void setUpTrigger(){
			UserSession.sharedInstance ().FromMyEvent<bool> ("IsLogin").Subscribe(
				(logined) => {
					RunOnUiThread(
						()=>{
					if (logined){

								specList.RemoveAt(2);
								AddTab("我", Resource.Drawable.tab_mine, typeof(MineActivity));
								this.InvalidTabs();
								tabHost.CurrentTab = 2;
							}
							else {
								specList.RemoveAt(2);
								AddTab("登录", Resource.Drawable.tab_mine, typeof(LoginActivity));
								this.InvalidTabs();
								tabHost.CurrentTab = 2;
								 
							}
						
					}
					);
				}
			);
			SharedPreferenceSignal<string>.rac_listen_for_key<string> (SPConstant.LoginToken).Skip(1).Subscribe (
				(value) =>{
					RunOnUiThread(
						()=>{
							specList.RemoveAt(2);
							if (value != null){
								AddTab("我", Resource.Drawable.tab_mine, typeof(MineActivity));
							}
							else {
								AddTab("登录", Resource.Drawable.tab_mine, typeof(LoginActivity));
							}
							this.InvalidTabs();
							tabHost.CurrentTab = 2;
						}
					);
				}
			);
		}

		//
		public void OnReq (BaseReq p0){
			Console.WriteLine ("微信返回结果");
		}

		public void OnResp (BaseResp p0){
			Console.WriteLine ("微信返回结果2");
		}

	}

}

