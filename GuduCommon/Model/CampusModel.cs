using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuduCommon
{
	public class CampusModel : INotifyPropertyChanged
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
		private String first_letter;

		[JsonProperty("first_letter")]
		public String First_letter {
			get{ 

				return first_letter;
			}
			set { SetField(ref first_letter, value); }
		}
		private String address;

		[JsonProperty("address")]
		public String Address {
			get{ 
				return address;
			}
			set { SetField(ref address, value); }
		}

		private String logo_filename;
		[JsonProperty("logo_filename")]
		public String Logo_filename {
			get{ 
				return logo_filename;
			}
			set { SetField(ref logo_filename, value); }
		}

		private CityModel city;
		[JsonProperty("city")]
		public CityModel City {
			get{ 
				return city;
			}
			set { SetField(ref city, value); }
		}
			
//		public List<StoreModel> stores {
//			get;
//			set;
//		}
		public CampusModel ()
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

