
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
using System.Reactive;
using System.Reactive.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DSoft.Messaging;
using Android.Content.PM;
using Android.Views.InputMethods;
using Com.Tencent.MM.Sdk.Openapi;
using Com.Tencent.MM.Sdk.Modelmsg;


namespace Gudu
{
	[Activity (Label = "LoginActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class LoginActivity : Activity
	{
		private bool isPresented; //表明是否是由下至上弹出
		private Button sendSMSButton;
		private EditText phoneField;
		private Button loginButton;
		private EditText smsField;
		private string smsToken;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			var showMethod = this.Intent.GetStringExtra ("show_method");
			if (showMethod == ActivityShowMethod.PRESENT) {
				SetupWindowAnimations ();
				isPresented = true;
			}
			SetContentView (Resource.Layout.login_activity);
			initUI ();
			setUpTrigger ();
			// Create your application here
		}
		void initUI(){
			phoneField = FindViewById<EditText> (Resource.Id.phone_field);
			sendSMSButton = FindViewById<Button> (Resource.Id.send_sms_button);
			loginButton = FindViewById<Button> (Resource.Id.login_button);
			smsField = FindViewById<EditText> (Resource.Id.sms_code_field);
		}

		private void SetupWindowAnimations() {
			OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
		}

		void setUpTrigger(){
			var deadLine = 20;
			phoneField.EditorAction += (object sender, TextView.EditorActionEventArgs e) => {
				bool done = e.ActionId == Android.Views.InputMethods.ImeAction.Done;
				if(done){
					InputMethodManager inputMethodManager = (InputMethodManager) this.GetSystemService(Context.InputMethodService);  
					inputMethodManager.ToggleSoftInput(0, HideSoftInputFlags.NotAlways);  
					e.Handled = true;
				}
			};
			smsField.EditorAction += (object sender, TextView.EditorActionEventArgs e) => {
				bool done = e.ActionId == Android.Views.InputMethods.ImeAction.Done;
				if(done){
					InputMethodManager inputMethodManager = (InputMethodManager) this.GetSystemService(Context.InputMethodService);  
					inputMethodManager.ToggleSoftInput(0, HideSoftInputFlags.NotAlways);  
					e.Handled = true;
				}
			};
			sendSMSButton.Click += (object sender, EventArgs e) => {
				Observable.Interval(TimeSpan.FromSeconds(1))
					.Take(deadLine + 1)
					.Subscribe(
						time => {
							RunOnUiThread(
								() => sendSMSButton.Enabled = false
							);
						
							RunOnUiThread(() => {
								if (time < deadLine){
									sendSMSButton.Text = (deadLine - time).ToString();
								}
								else{
									sendSMSButton.Enabled = true;
									sendSMSButton.Text = "验证码";
								}
							});
						}
					);
			};
			sendSMSButton.Enabled = false;
			phoneField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				bool isMobile = TsaoRegular.isMobileNO(phoneField.Text);
				if (isMobile){
					sendSMSButton.Enabled = true;
					sendSMSButton.Text = "验证码";
				}
				else {
					sendSMSButton.Enabled = false;
					sendSMSButton.Text = "验证码";
				}
			};
			sendSMSButton.Click += (object sender, EventArgs e) => {
				var param = new Dictionary<string, string>();
				param.Add("phone", phoneField.Text);

				Tool.Post(URLConstant.kBaseUrl, URLConstant.kSendSmsUrl, this, param,
					(responseObject)=>{
						if (Tool.CheckStatusCode(responseObject)){
							this.smsToken = JObject.Parse(responseObject).SelectToken("data").SelectToken("token").Value<string>();
							//Tool.SetStringForKey(SPConstant.LoginToken, token.Value<string>());
						}

						},
					(error) => {
						
					}, showHud:false);
			};

			IObservable<EventPattern<Android.Text.TextChangedEventArgs>> phoneFieldValid = Observable.FromEventPattern<Android.Text.TextChangedEventArgs> (
				s => phoneField.TextChanged += s,
				s => phoneField.TextChanged -= s
			);
			var signalOfPhoneField = phoneFieldValid.Select (evt => phoneField.Text);

			IObservable<EventPattern<Android.Text.TextChangedEventArgs>> smsFieldValid = Observable.FromEventPattern<Android.Text.TextChangedEventArgs> (
				s => smsField.TextChanged += s,
				s => smsField.TextChanged -= s
			);
			var signalOfSMSField = smsFieldValid.Select (evt => smsField.Text);

			Observable.CombineLatest<string>( signalOfPhoneField, signalOfSMSField).Subscribe(
				(IList<string> values) => {
					RunOnUiThread(
						() =>{
							if (values[0] != null && values[1] != null && TsaoRegular.isMobileNO (values[0]) && values[1].Length > 0) {
								loginButton.Enabled = true;
							} else {
								loginButton.Enabled = false;
								Console.WriteLine("检测了一次login可用性");
							}
						}
					);

				}
			);
			phoneField.Text = "";
			smsField.Text = "";

				

//			Observable.CombineLatest()
			loginButton.Click += (object sender, EventArgs e) => {
				Dictionary<string, object> param = new Dictionary<string, object>();
				param.Add("phone", phoneField.Text);
				param.Add("smsCode", smsField.Text);
				param.Add("smsToken", this.smsToken);
				Tool.Post(URLConstant.kBaseUrl, URLConstant.kLoginUrl, this, param, (responseObject)=>{
					if (Tool.CheckStatusCode(responseObject)){
						UserSession.sharedInstance().SessionToken = JObject.Parse(responseObject).SelectToken("data").SelectToken("token").Value<string>();
						if (isPresented){
							this.Finish();
						}
					}
					else {
						MaterialUI.Widget.SnackBar snack = MaterialUI.Widget.SnackBar.Make(this).ApplyStyle(Resource.Style.Material_Widget_SnackBar_Mobile_MultiLine);
						snack.Text("登录失败,请检查是否输入正确")
							.ActionText("")
							.Duration(1000);
						snack.Show(this);
					}

				},
					(error) => {

					}, showHud:false);
			};
			FindViewById<ImageButton> (Resource.Id.bind_role_button).Click += (object sender, EventArgs e) => {
				var api = WXApiManager.manager(this).api;
				SendAuth.Req auth = new SendAuth.Req ();
				auth.Scope = "snsapi_message,snsapi_userinfo,snsapi_friend,snsapi_contact";
				auth.State = "zaocan84";
				auth.OpenId = "0c806938e2413ce73eef92cc3";
				api.SendReq (auth);
			};
		}

		bool doubleBackToExitPressedOnce = false;
		public override void OnBackPressed ()
		{
			if (this.isPresented) {
				base.OnBackPressed ();
				return;
			}

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

