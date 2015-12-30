using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GuduCommon
{
	public enum CouponStatus{
		Unused = 1,
		Used = 2,
	}
	public class CouponModel
	{
		private String id;
		[JsonProperty("id")]
		public String Id {
			get{ 

				return id;
			}
			set { SetField(ref id, value); }
		}

		private Decimal discount;
		[JsonProperty("discount")]
		public Decimal Discount {
			get{ 

				return discount;
			}
			set { SetField(ref discount, value); }
		}

		private Decimal least_price;
		[JsonProperty("least_price")]
		public Decimal Least_price {
			get{ 

				return least_price;
			}
			set { SetField(ref least_price, value); }
		}

		private String activated_date;
		[JsonProperty("activated_date")]
		public String Activated_date {
			get{ 

				return activated_date;
			}
			set { SetField(ref activated_date, value); }
		}

		private String expired_date;
		[JsonProperty("expired_date")]
		public String Expired_date {
			get{ 

				return expired_date;
			}
			set { SetField(ref expired_date, value); }
		}

		private CouponStatus status;
		[JsonProperty("status")]
		public CouponStatus Status {
			get{ 

				return status;
			}
			set { SetField(ref status, value); }
		}

		public CouponModel ()
		{
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

