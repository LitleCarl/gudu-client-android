using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuduCommon
{
	public class UserModel :INotifyPropertyChanged
	{
		private string id;
		[JsonProperty("id")]
		public string Id {
			get{
				return id;
			}
			set { SetField(ref id, value); }
		}

		private string avatar;
		[JsonProperty("avatar")]
		public string Avatar {
			get{
				return avatar;
			}
			set { SetField(ref avatar, value); }
		}

		private string phone;
		[JsonProperty("phone")]
		public string Phone {
			get{
				return phone;
			}
			set { SetField(ref phone, value); }
		}

		private List<AddressModel> addresses;
		[JsonProperty("addresses")]
		public List<AddressModel> Addresses {
			get{
				return addresses;
			}
			set { SetField(ref addresses, value); }
		}

		public UserModel ()
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

