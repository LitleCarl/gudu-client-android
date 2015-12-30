using System;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;
using Android.Content;

namespace Gudu
{
	public class PaymentModel : INotifyPropertyChanged
	{
		private String name;
		public String Name {
			get{
				return name;
			}
			set { SetField(ref name, value); }
		}

		private String code;
		public String Code {
			get{
				return code;
			}
			set { SetField(ref code, value); }
		}

		// 添加一个触发 PropertyChanged 事件的通用方法
		public event PropertyChangedEventHandler PropertyChanged;

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
		// PropertyChanged结束

	}

	public class BasicConfigManager : Object, INotifyPropertyChanged
	{
		private List<String> deliveryTimeSet;
		public List<String> DeliveryTimeSet {
			get{
				return deliveryTimeSet;
			}
			set { SetField(ref deliveryTimeSet, value); }
		}

		private String kefu_phone;
		public String Kefu_phone {
			get{
				return kefu_phone;
			}
			set { SetField(ref kefu_phone, value); }
		}

		private bool red_pack_available;
		public bool Red_pack_available {
			get{
				return red_pack_available;
			}
			set { SetField(ref red_pack_available, value); }
		}

		private List<PaymentModel> payMethodSet;
		public List<PaymentModel> PayMethodSet {
			get{
				return payMethodSet;
			}
			set { SetField(ref payMethodSet, value); }
		}

		// 添加一个触发 PropertyChanged 事件的通用方法
		public event PropertyChangedEventHandler PropertyChanged;

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
		// PropertyChanged结束

		private static BasicConfigManager manager;
		public static BasicConfigManager sharedManager(Context context){
			if (manager == null){
				manager = new BasicConfigManager ();
				manager.LoadConfig (context);
			}
			return manager;
		}

		public BasicConfigManager ()
		{
		}

		void LoadConfig (Context context)
		{
			Tool.Get(URLConstant.kBaseUrl, URLConstant.kBasicConfig, null, context, (responseObject) => {
				if (Tool.CheckStatusCode(responseObject)){
					var data = JObject.Parse(responseObject).SelectToken("data").SelectToken("config");
					this.DeliveryTimeSet = JsonConvert.DeserializeObject<List<String>>(data.SelectToken("availableDeliveryTime").ToString(), new JsonSerializerSettings
						{
							Error = (sender,errorArgs) =>
							{
								var currentError = errorArgs.ErrorContext.Error.Message;
								errorArgs.ErrorContext.Handled = true;
							}}
					);
					this.PayMethodSet = JsonConvert.DeserializeObject<List<PaymentModel>>(data.SelectToken("availablePayMethod").ToString(), new JsonSerializerSettings
						{
							Error = (sender,errorArgs) =>
							{
								var currentError = errorArgs.ErrorContext.Error.Message;
								errorArgs.ErrorContext.Handled = true;
							}}
					);
					this.Red_pack_available = data.SelectToken("red_pack_available").Value<bool>();
					this.Kefu_phone = data.SelectToken("kefu_phone").Value<String>();
				}
				else {
					MaterialUI.Widget.SnackBar snack = MaterialUI.Widget.SnackBar.Make(context).ApplyStyle(Resource.Style.Material_Widget_SnackBar_Mobile_MultiLine);
					snack.Text("与服务器断开连接,请联系客服")
						.ActionText("确定")
						.Duration(1000);
					snack.Show();
					Console.WriteLine("获取Basic Config异常");
				}
			}, (exception) => {
				
			}, true);
		}
//		public void OnActionClick (MaterialUI.Widget.SnackBar p0, int p1){
//			//TODO 
//		}

	}
}

