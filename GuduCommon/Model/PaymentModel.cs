using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace GuduCommon
{
	public class PaymentModel : INotifyPropertyChanged
	{
		private String id;
		[JsonProperty("id")]
		public String Id {
			get{
				return id;
			}
			set { SetField(ref id, value); }
		}

		private DateTime time_paid;
		[JsonProperty("time_paid")]
		public DateTime Time_paid {
			get{
				return time_paid;
			}
			set { SetField(ref time_paid, value); }
		}

		private OrderModel order;
		[JsonProperty("order")]
		public OrderModel Order {
			get{
				return order;
			}
			set { SetField(ref order, value); }
		}

		private String amount;
		[JsonProperty("amount")]
		public String Amount {
			get{
				return amount;
			}
			set { SetField(ref amount, value); }
		}

		private String transaction_no;
		[JsonProperty("transaction_no")]
		public String Transaction_no {
			get{
				return transaction_no;
			}
			set { SetField(ref transaction_no, value); }
		}

		private String charge_id;
		[JsonProperty("charge_id")]
		public String Charge_id {
			get{
				return charge_id;
			}
			set { SetField(ref charge_id, value); }
		}

		private String payment_method;
		[JsonProperty("payment_method")]
		public String Payment_method {
			get{
				return payment_method;
			}
			set { SetField(ref payment_method, value); }
		}

		public PaymentModel ()
		{
		}

		/// <summary>
		/// 开始Property监听
		/// </summary>
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

