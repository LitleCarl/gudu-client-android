using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace GuduCommon
{
	public class OwnerModel :INotifyPropertyChanged
	{
		private String id;
		[JsonProperty("id")]
		public String Id {
			get{ 

				return id;
			}
			set { SetField(ref id, value); }
		}

		private String username;
		[JsonProperty("username")]
		public String Username {
			get{ 

				return username;
			}
			set { SetField(ref username, value); }
		}

		private String contact_name;
		[JsonProperty("contact_name")]
		public String Contact_name {
			get{
				return contact_name;
			}
			set { SetField(ref contact_name, value); }
		}

		private String contact_phone;
		[JsonProperty("contact_phone")]
		public String Contact_phone {
			get{
				return contact_phone;
			}
			set { SetField(ref contact_phone, value); }
		}

		private StoreModel store;
		[JsonProperty("store")]
		public StoreModel Store {
			get{
				return store;
			}
			set { SetField(ref store, value); }
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
		public OwnerModel ()
		{
		}
	}
}

