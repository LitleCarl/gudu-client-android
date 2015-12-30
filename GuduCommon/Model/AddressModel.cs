using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuduCommon
{
	public class AddressModel: INotifyPropertyChanged
	{

		private string id;
		[JsonProperty("id")]
		public string Id {
			get{
				return id;
			}
			set { SetField(ref id, value); }
		}

		private bool defaultAddress;
		[JsonProperty("default_address")]
		public bool DefaultAddress {
			get{
				return defaultAddress;
			}
			set { SetField(ref defaultAddress, value); }
		}

		private string name;
		[JsonProperty("name")]
		public string Name {
			get{
				return name;
			}
			set { SetField(ref name, value); }
		}
		private string phone;
		[JsonProperty("phone")]
		public string Phone {
			get{
				return phone;
			}
			set { SetField(ref phone, value); }
		}

		private string address;
		[JsonProperty("address")]
		public string Address {
			get{
				return address;
			}
			set { SetField(ref address, value); }
		}

		private UserModel user;
		[JsonProperty("user")]
		public UserModel User {
			get{
				return user;
			}
			set { SetField(ref user, value); }
		}

		public AddressModel ()
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

		public AddressModel Clone(){
			AddressModel clone = new AddressModel ();
			clone.Id = this.Id;
			clone.Name = this.Name;
			clone.Phone = this.Phone;
			clone.Address = this.Address;
			return clone;
		}
	}
}

