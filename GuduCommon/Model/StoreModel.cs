using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;

namespace GuduCommon
{
	public enum StoreStatus{
		Pending = 1,
		Normal = 2,
		Suspend = 3
	};

	public class StoreModel
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

		private String brief;
		[JsonProperty("brief")]
		public String Brief {
			get{ 

				return brief;
			}
			set { SetField(ref brief, value); }
		}

		private String address;
		[JsonProperty("address")]
		public String Address {
			get{ 

				return address;
			}
			set { SetField(ref address, value); }
		}



		private StoreStatus status;
		[JsonProperty("status")]
		public StoreStatus Status {
			get{ 

				return status;
			}
			set { SetField(ref status, value); }
		}

		private String logo_filename;
		[JsonProperty("logo_filename")]
		public String Logo_filename {
			get{
				return logo_filename;
			}
			set { SetField(ref logo_filename, value); }
		}

		private OwnerModel owner;
		[JsonProperty("owner")]
		public OwnerModel Owner {
			get{
				return owner;
			}
			set { SetField(ref owner, value); }
		}

		private List<CampusModel> campuses;
		[JsonProperty("campuses")]
		public List<CampusModel> Campuses {
			get{
				return campuses;
			}
			set { SetField(ref campuses, value); }
		}

		private List<ProductModel> products;
		[JsonProperty("products")]
		public List<ProductModel> Products {
			get{
				return products;
			}
			set { SetField(ref products, value); }
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
		public StoreModel ()
		{
		}
	}
}

