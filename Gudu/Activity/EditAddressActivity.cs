
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
using Newtonsoft.Json;
using DSoft.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AndroidHUD;
using Android.Content.PM;

namespace Gudu
{
	[Activity (Label = "EditAddressActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class EditAddressActivity : Activity
	{
		private EditText _receiverNameEditText;
		private EditText _receiverPhoneEditText;
		private EditText _receiverAddressEditText;
		private Button _submitButton;
		private Button _setDefaultAddressButton;

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
			var addressID = this.Intent.GetStringExtra("address_id");
			var selectAddress = (from address in UserSession.sharedInstance ().User.Addresses where address.Id == addressID select address).First<AddressModel>();
			this.Address = selectAddress.Clone ();

			SetContentView (Resource.Layout.edit_address_activity);
			initUI ();
			if (addressID != null) {
				setUpTrigger ();
			}
			// Create your application here
		}

		void initUI(){
			_receiverNameEditText = FindViewById<EditText> (Resource.Id.receiver_name_edittext);
			_receiverPhoneEditText = FindViewById<EditText> (Resource.Id.receiver_phone_edittext);
			_receiverAddressEditText = FindViewById<EditText> (Resource.Id.receiver_address_edittext);
			_submitButton = FindViewById<Button> (Resource.Id.submit_add_address_button);
			_setDefaultAddressButton = FindViewById<Button> (Resource.Id.set_default_address);
		}

		void setUpTrigger(){

			Address.FromMyEvent<String> ("Name").Subscribe (
				(name) => {
					this.RunOnUiThread(
						() => {
							this._receiverNameEditText.Text = name;
						}
					);
				}
			);

			Address.FromMyEvent<String> ("Phone").Subscribe (
				(name) => {
					this.RunOnUiThread(
						() => {
							this._receiverPhoneEditText.Text = name;
						}
					);
				}
			);

			Address.FromMyEvent<String> ("Address").Subscribe (
				(name) => {
					this.RunOnUiThread(
						() => {
							this._receiverAddressEditText.Text = name;
						}
					);
				}
			);

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
				Dictionary<string, object> param = new Dictionary<string, object>();
				param.Add("address", address);
				var postBody = JsonConvert.SerializeObject(param);
				Tool.Put(URLConstant.kBaseUrl, URLConstant.kUpdateAddressUrl.Replace(":address_id", address.Id), this, postBody,
					(responseObject) => {
						if (Tool.CheckStatusCode(responseObject)){
							this.RunOnUiThread(
								() => {
									MessageBus.Default.Post(new NeedFetchUserInfoEvent());
									AndHUD.Shared.ShowToast(this, "修改成功", MaskType.Clear, TimeSpan.FromSeconds(1));
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

			_setDefaultAddressButton.Click += (object sender, EventArgs e) => {
				Dictionary<string, object> param = new Dictionary<string, object>();
				param.Add("address", address);
				address.DefaultAddress = true;
				var postBody = JsonConvert.SerializeObject(param);
				Tool.Put(URLConstant.kBaseUrl, URLConstant.kUpdateAddressUrl.Replace(":address_id", address.Id), this, postBody,
					(responseObject) => {
						if (Tool.CheckStatusCode(responseObject)){
							this.RunOnUiThread(
								() => {
									MessageBus.Default.Post(new NeedFetchUserInfoEvent());
									AndHUD.Shared.ShowToast(this, "修改成功", MaskType.Clear, TimeSpan.FromSeconds(1));
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

