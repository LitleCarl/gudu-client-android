using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace GuduCommon
{
	public class CityModel: INotifyPropertyChanged
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

		private String abbreviation;
		[JsonProperty("abbreviation")]
		public String Abbreviation {
			get{ 

				return abbreviation;
			}
			set { SetField(ref abbreviation, value); }
		}

		private DateTime createdAt;
		[JsonProperty("createdAt")]
		public DateTime CreatedAt {
			get{ 

				return createdAt;
			}
			set { SetField(ref createdAt, value); }
		}
		private DateTime updatedAt;
		[JsonProperty("updatedAt")]
		public DateTime UpdatedAt {
			get{ 

				return updatedAt;
			}
			set { SetField(ref updatedAt, value); }
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
		public CityModel ()
		{
		}
	}
}

