
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
using Newtonsoft.Json;
using GuduCommon;
using System.Reactive;
using System.Reactive.Linq;
using AndroidHUD;
using DSoft.Messaging;
using Android.Content.PM;
namespace Gudu
{
	[Activity (Label = "AddAddressActivity", ScreenOrientation = ScreenOrientation.Portrait )]			
	public class AddAddressActivity : Activity, INotifyPropertyChanged
	{
		private EditText _receiverNameEditText;
		private EditText _receiverPhoneEditText;
		private EditText _receiverAddressEditText;
		private Button _submitButton;

		private AddressModel address;
		public AddressModel Address {
			get{
				return address;
			}
			set { SetField(ref address, value); }
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.add_address_activity);
			initUI ();
			setUpTrigger ();

			// Create your application here
		}

		void initUI(){
			_receiverNameEditText = FindViewById<EditText> (Resource.Id.receiver_name_edittext);
			_receiverPhoneEditText = FindViewById<EditText> (Resource.Id.receiver_phone_edittext);
			_receiverAddressEditText = FindViewById<EditText> (Resource.Id.receiver_address_edittext);
			_submitButton = FindViewById<Button> (Resource.Id.submit_add_address_button);
		}

		void setUpTrigger(){
			this.Address = new AddressModel ();
			var signalOfName = this.Address.FromMyEvent<string> ("Name");
			var signalOfPhone = this.Address.FromMyEvent<string> ("Phone");
			var signalOfAddress = this.Address.FromMyEvent<string> ("Address");
			Observable.CombineLatest (signalOfName, signalOfPhone, signalOfAddress).Subscribe (
				(IList<String> stringList) => {
					var bool1 = stringList[0] != null && stringList[0].Length >= 1;
					var bool2 = stringList[1] != null && TsaoRegular.isMobileNO(stringList[1]);
					var bool3 = stringList[2] != null && stringList[2].Length >= 1;
					this.RunOnUiThread(
						() => {
							_submitButton.Enabled = bool1 && bool2 && bool3;
					});

				}
			);
			_receiverNameEditText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				this.Address.Name = e.Text.ToString();
				_receiverNameEditText.SetSelection(_receiverNameEditText.Text.Length);
			};
			_receiverAddressEditText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				this.Address.Address = e.Text.ToString();
				_receiverAddressEditText.SetSelection(_receiverAddressEditText.Text.Length);
			};
			_receiverPhoneEditText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				this.Address.Phone = e.Text.ToString();
				_receiverPhoneEditText.SetSelection(_receiverPhoneEditText.Text.Length);
			};
			_submitButton.Click += (object sender, EventArgs e) => {
				var postBody = JsonConvert.SerializeObject(this.Address);
				Tool.Post(URLConstant.kBaseUrl, URLConstant.kAddAddressUrl, this, postBody,
					(responseObject) => {
						if (Tool.CheckStatusCode(responseObject)){
							this.RunOnUiThread(
								() => {
									MessageBus.Default.Post(new NeedFetchUserInfoEvent());
									AndHUD.Shared.ShowToast(this, "添加成功", MaskType.Clear, TimeSpan.FromSeconds(1));
									Observable.Timer(TimeSpan.FromSeconds(2.0)).Subscribe(
										(time) => {
											this.Finish();
										}
									);
								}
							);

						}
					},
					(exception) => {}
				);
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

