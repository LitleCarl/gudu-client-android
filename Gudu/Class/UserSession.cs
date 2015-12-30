using System;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using GuduCommon;
using DSoft.Messaging;
using Android.OS;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Android.App;

namespace Gudu
{
	public class UserSession : INotifyPropertyChanged
	{
		private bool isLogin;
		public bool IsLogin {
			get{
				return isLogin;
			}
			set { SetField(ref isLogin, value); }
		}

		private string sessionToken;
		public string SessionToken {
			get{
				return sessionToken;
			}
			set { SetField(ref sessionToken, value); }
		}

		private UserModel user;
		public UserModel User {
			get{
				return user;
			}
			set { SetField(ref user, value); }
		}

		private static UserSession session;

		public static UserSession sharedInstance(){
			if (session == null){
				session = new UserSession ();
			}
			return session;
		}

		private UserSession ()
		{
			SetUpTrigger ();
		}

		void SetUpTrigger(){
			// 一旦sharedPreference发现登录,立马修改var 而不是property，防止陷入循环
			SharedPreferenceSignal<string>.rac_listen_for_key<string> (SPConstant.LoginToken).Subscribe (
				(token) =>{
					sessionToken = token;
				}
			);


			// 属性变化导致sharedPreference跟着变化
			this.FromMyEvent<string> ("SessionToken").Subscribe (
				(token) =>{
					Tool.SetStringForKey(SPConstant.LoginToken, token);
					if (token == null){
						this.IsLogin = false;
					}
					else {
						this.ReFetchUserInfo();
					}
				}
			);

//			SharedPreferenceSignal<string>.rac_listen_for_key<string> (SPConstant.LoginToken).Subscribe (
//				(token) =>{
//				}
//			);

			MessageBus.Default.Register<NeedFetchUserInfoEvent> (
				(sender, theEvent) => {
					using (var h = new Handler (Looper.MainLooper)){
						h.Post(
							()=>{
								this.ReFetchUserInfo();
							}
						);
					}
				}
			);

		}

		void ReFetchUserInfo(){
			Tool.Get (URLConstant.kBaseUrl, URLConstant.kUserFindOneWithTokenUrl, null, Application.Context, 
				(responseObject) => {
					if (Tool.CheckStatusCode(responseObject)){
						var userPart = JObject.Parse(responseObject).SelectToken("data").SelectToken("user").ToString();
						this.User = JsonConvert.DeserializeObject<UserModel>(userPart, new JsonSerializerSettings
							{
								Error = (sender,errorArgs) =>
								{
									var currentError = errorArgs.ErrorContext.Error.Message;
									errorArgs.ErrorContext.Handled = true;
								}
							});
						this.IsLogin = (User != null);

					}
					else if(Tool.GetStatusCode(responseObject) == (int)(ResponseStatusCode.SessionInvalid)){
						Tool.SetStringForKey(SPConstant.LoginToken, null);
					}
				},
				(exception) => {
					
				},
				showHud: false);
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

