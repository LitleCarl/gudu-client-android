using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace GuduCommon
{
	public enum OrderStatus{
		All = -1,
		Dead = 0 ,
		notPaid = 1,
		notDelivered = 2,
		notReceived = 3,
		notCommented = 4,
		done = 5,
	}
	public class OrderModel : INotifyPropertyChanged
	{
		private String id;
		[JsonProperty("id")]
		public String Id {
			get{
				return id;
			}
			set { SetField(ref id, value); }
		}

		private OrderStatus status;
		[JsonProperty("status")]
		public OrderStatus Status {
			get{
				return status;
			}
			set { SetField(ref status, value); }
		}

		private UserModel user;
		[JsonProperty("user")]
		public UserModel User {
			get{
				return user;
			}
			set { SetField(ref user, value); }
		}

		private String price;
		[JsonProperty("price")]
		public String Price {
			get{
				return price;
			}
			set { SetField(ref price, value); }
		}

		private String pay_price;
		[JsonProperty("pay_price")]
		public String Pay_price {
			get{
				return pay_price;
			}
			set { SetField(ref pay_price, value); }
		}

		private String order_number;
		[JsonProperty("order_number")]
		public String Order_number {
			get{
				return order_number;
			}
			set { SetField(ref order_number, value); }
		}

		private String delivery_time;
		[JsonProperty("delivery_time")]
		public String Delivery_time {
			get{
				return delivery_time;
			}
			set { SetField(ref delivery_time, value); }
		}

		private String receiver_name;
		[JsonProperty("receiver_name")]
		public String Receiver_name {
			get{
				return receiver_name;
			}
			set { SetField(ref receiver_name, value); }
		}

		private String receiver_phone;
		[JsonProperty("receiver_phone")]
		public String Receiver_phone {
			get{
				return receiver_phone;
			}
			set { SetField(ref receiver_phone, value); }
		}

		private String receiver_address;
		[JsonProperty("receiver_address")]
		public String Receiver_address {
			get{
				return receiver_address;
			}
			set { SetField(ref receiver_address, value); }
		}

		private CampusModel campus;
		[JsonProperty("campus")]
		public CampusModel Campus {
			get{
				return campus;
			}
			set { SetField(ref campus, value); }
		}

		private PaymentModel payment;
		[JsonProperty("payment")]
		public PaymentModel Payment {
			get{
				return payment;
			}
			set { SetField(ref payment, value); }
		}

		private List<OrderItemModel> order_items;
		[JsonProperty("order_items")]
		public List<OrderItemModel> Order_items {
			get{
				return order_items;
			}
			set { SetField(ref order_items, value); }
		}

		private String pay_method;
		[JsonProperty("pay_method")]
		public String Pay_method {
			get{
				return pay_method;
			}
			set { SetField(ref pay_method, value); }
		}

		public OrderModel ()
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

