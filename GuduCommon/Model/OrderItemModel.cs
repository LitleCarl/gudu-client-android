using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace GuduCommon
{
	public class OrderItemModel : INotifyPropertyChanged
	{
		private String id;
		[JsonProperty("id")]
		public String Id {
			get{
				return id;
			}
			set { SetField(ref id, value); }
		}

		private ProductModel product;
		[JsonProperty("product")]
		public ProductModel Product {
			get{
				return product;
			}
			set { SetField(ref product, value); }
		}

		private int quantity;
		[JsonProperty("quantity")]
		public int Quantity {
			get{
				return quantity;
			}
			set { SetField(ref quantity, value); }
		}

		private OrderModel order;
		[JsonProperty("order")]
		public OrderModel Order {
			get{
				return order;
			}
			set { SetField(ref order, value); }
		}

		private SpecificationModel specification;
		[JsonProperty("specification")]
		public SpecificationModel Specification {
			get{
				return specification;
			}
			set { SetField(ref specification, value); }
		}

		private String price_snapshot;
		[JsonProperty("price_snapshot")]
		public String Price_snapshot {
			get{
				return price_snapshot;
			}
			set { SetField(ref price_snapshot, value); }
		}

		public OrderItemModel ()
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

