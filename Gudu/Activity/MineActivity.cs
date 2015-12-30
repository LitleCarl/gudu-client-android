
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
using GuduCommon;
using System.Reactive.Linq;
using DSoft.Messaging;
using Android.Content.PM;
using Squareup.Picasso;

namespace Gudu
{
	[Activity (Label = "MineActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class MineActivity : Activity
	{
		//View
		private TextView _userNameTextView;
		private ImageView _avatarImageView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.mine_activity);
			// Create your application here
			InitUI();
			SetUpTrigger ();
			MessageBus.Default.Post (new NeedFetchUserInfoEvent());
		}
		void InitUI(){
			_userNameTextView = FindViewById<TextView> (Resource.Id.user_name_textview);
			_avatarImageView = FindViewById<ImageView> (Resource.Id.avatar);
		}
		void SetUpTrigger(){
			UserSession.sharedInstance ().FromMyEvent<UserModel> ("User").Subscribe (
				(user) => {
					if (user != null){
						_userNameTextView.Text = user.Phone;
						Picasso.With (this).Load (user.Avatar).Into (_avatarImageView);
					}
				}
			);

			// 注销按钮
			FindViewById<Button> (Resource.Id.log_out_button).Click += (object sender, EventArgs e) => {
				UserSession.sharedInstance().SessionToken = null;
			};

			FindViewById<Button>(Resource.Id.show_all_order).Click += (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(OrderViewPagerActivity)));
			};
			FindViewById<Button>(Resource.Id.show_not_paid_order).Click += (object sender, EventArgs e) => {
				Intent intent = new Intent(this, typeof(OrderViewPagerActivity));
				intent.PutExtra("order_status", (int)(OrderStatus.notPaid));
				StartActivity(intent);
			};FindViewById<Button>(Resource.Id.show_not_delivered_order).Click += (object sender, EventArgs e) => {
				Intent intent = new Intent(this, typeof(OrderViewPagerActivity));
				intent.PutExtra("order_status", (int)(OrderStatus.notDelivered));
				StartActivity(intent);
			};
			FindViewById<Button>(Resource.Id.show_all_address_button).Click += (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(AddressManagementActivity)));
			};
			FindViewById<Button>(Resource.Id.show_coupons).Click += (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(CouponGridViewActivity)));
			};
		}
		bool doubleBackToExitPressedOnce = false;
		public override void OnBackPressed ()
		{
			if (doubleBackToExitPressedOnce) {
				base.OnBackPressed ();
				Java.Lang.JavaSystem.Exit(0);
				return;
			} 


			this.doubleBackToExitPressedOnce = true;
			Toast.MakeText(this, "再点一次退出",ToastLength.Short).Show();

			new Handler().PostDelayed(()=>{
				doubleBackToExitPressedOnce=false;
			},2000);
		}
	}

}

