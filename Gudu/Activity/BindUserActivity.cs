
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Android.Views.InputMethods;

namespace Gudu
{
	[Activity (Label = "BindUserActivity")]			
	public class BindUserActivity : BackButtonActivity, INotifyPropertyChanged
	{
		private string union_id;
		public string Union_id {
			get{
				return union_id;
			}
			set { SetField(ref union_id, value); }
		}

		private Button sendSMSButton;
		private EditText phoneField;
		private Button loginButton;
		private EditText smsField;
		private string smsToken;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.bind_role_activity);
			// Create your application here
			this.Union_id = this.Intent.GetStringExtra("union_id");
			initUI ();
			setUpTrigger ();

		}

		void initUI(){
			phoneField = FindViewById<EditText> (Resource.Id.phone_field);
			sendSMSButton = FindViewById<Button> (Resource.Id.send_sms_button);
			loginButton = FindViewById<Button> (Resource.Id.login_button);
			smsField = FindViewById<EditText> (Resource.Id.sms_code_field);
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

			Observable.CombineLatest<string>( signalOfPhoneField, signalOfSMSField, this.FromMyEvent<string>("Union_id")).Subscribe(
				(IList<string> values) => {
					RunOnUiThread(
						() =>{
							if (values[0] != null && values[1] != null && TsaoRegular.isMobileNO (values[0]) && values[1].Length > 0 && values[2] != null) {
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
				param.Add("union_id", this.union_id);
				Tool.Post(URLConstant.kBaseUrl, URLConstant.kLoginUrl, this, param, (responseObject)=>{
					if (Tool.CheckStatusCode(responseObject)){
						UserSession.sharedInstance().SessionToken = JObject.Parse(responseObject).SelectToken("data").SelectToken("token").Value<string>();
							this.Finish();
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

		}

		public event PropertyChangedEventHandler PropertyChanged;
		// 添加一个触发 PropertyChanged 事件的通用方法
		protected virtual void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected bool SetField<T>(ref T field, T value,
			[CallerMemberName] string propertyName = null){
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			NotifyPropertyChanged(propertyName);
			return true;
		}
	}
}

