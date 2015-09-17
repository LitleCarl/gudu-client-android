using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace GuduCommon
{
	public enum SpecificationStatus{
		Normal = 1,
		Pending = 2
	};

	public class SpecificationModel : INotifyPropertyChanged
	{
		private String id;
		[JsonProperty("id")]
		public String Id {
			get{ 

				return id;
			}
			set { SetField(ref id, value); }
		}

		private String name;
		[JsonProperty("name")]
		public String Name {
			get{ 

				return name;
			}
			set { SetField(ref name, value); }
		}

		private String value;
		[JsonProperty("value")]
		public String Value {
			get{
				return value;
			}
			set { SetField(ref value, value); }
		}

		private Decimal price;
		[JsonProperty("price")]
		public Decimal Price {
			get{
				return price;
			}
			set { SetField(ref price, value); }
		}

		private ProductModel product;
		[JsonProperty("product")]
		public ProductModel Product {
			get{
				return product;
			}
			set { SetField(ref product, value); }
		}

		private SpecificationStatus status;
		[JsonProperty("status")]
		public SpecificationStatus Status {
			get{
				return status;
			}
			set { SetField(ref status, value); }
		}

		private int stock;
		[JsonProperty("stock")]
		public int Stock {
			get{
				return stock;
			}
			set { SetField(ref stock, value); }
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

		public SpecificationModel ()
		{
		}
	}
}

