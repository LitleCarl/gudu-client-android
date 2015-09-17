using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuduCommon
{
	public class NutritionModel : INotifyPropertyChanged
	{

		private String id;
		[JsonProperty("id")]
		public String Id {
			get{ 

				return id;
			}
			set { SetField(ref id, value); }
		}

		private float energy;
		[JsonProperty("energy")]
		public float Energy {
			get{
				return energy;
			}
			set { SetField(ref energy, value); }
		}
			
		private ProductModel product;
		[JsonProperty("product")]
		public ProductModel Product {
			get{
				return product;
			}
			set { SetField(ref product, value); }
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

		public NutritionModel ()
		{
		}
	}
}

