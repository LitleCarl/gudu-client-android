using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuduCommon
{
	public enum ProductStatus{
		Normal = 1,
		Pending = 2
	};
	public class ProductModel : INotifyPropertyChanged
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

		private StoreModel store;
		[JsonProperty("store")]
		public StoreModel Store {
			get{
				return store;
			}
			set { SetField(ref store, value); }
		}

		private String logo_filename;
		[JsonProperty("logo_filename")]
		public String Logo_filename {
			get{
				return logo_filename;
			}
			set { SetField(ref logo_filename, value); }
		}

		private String brief;
		[JsonProperty("brief")]
		public String Brief {
			get{
				return brief;
			}
			set { SetField(ref brief, value); }
		}

		private String min_price;
		[JsonProperty("min_price")]
		public String Min_price {
			get{
				return min_price;
			}
			set { SetField(ref min_price, value); }
		}

		private String max_price;
		[JsonProperty("max_price")]
		public String Max_price {
			get{
				return max_price;
			}
			set { SetField(ref max_price, value); }
		}

		private NutritionModel nutrition;
		[JsonProperty("nutrition")]
		public NutritionModel Nutrition {
			get{
				return nutrition;
			}
			set { SetField(ref nutrition, value); }
		}

		private String category;
		[JsonProperty("category")]
		public String Category {
			get{
				return category;
			}
			set { SetField(ref category, value); }
		}


		private ProductStatus status;
		[JsonProperty("status")]
		public ProductStatus Status {
			get{
				return status;
			}
			set { SetField(ref status, value); }
		}

		private List<SpecificationModel> specifications;
		[JsonProperty("specifications")]
		public List<SpecificationModel> Specifications {
			get{
				return specifications;
			}
			set { SetField(ref specifications, value); }
		}

		private List<ProductImageModel> product_images;
		[JsonProperty("product_images")]
		public List<ProductImageModel> Product_images {
			get{
				return product_images;
			}
			set { SetField(ref product_images, value); }
		}
		private String pinyin;
		[JsonProperty("pinyin")]
		public String Pinyin {
			get{
				return pinyin;
			}
			set { SetField(ref pinyin, value); }
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

		public ProductModel ()
		{
		}
	}
}

