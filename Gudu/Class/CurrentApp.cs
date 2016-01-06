using System;
using System.Collections.Generic;
using Android.App;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Gudu.Morning.Alertview;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.Content;

namespace Gudu
{
	public class UpdateInfo: INotifyPropertyChanged{

		// 需要更新
		private bool need_update;
		[JsonProperty("need_update")]
		public bool Need_update {
			get{
				return need_update;
			}
			set { SetField(ref need_update, value); }
		}

		// 更新address
		private string download_url;
		[JsonProperty("download_url")]
		public string Download_url {
			get{
			return download_url;
			}
		set { SetField(ref download_url, value); }
		}

		// 更新说明
		private string update_message;
		[JsonProperty("update_message")]
		public string Update_message {
			get{
				return update_message;
			}
			set { SetField(ref update_message, value); }
		}
		// 添加一个触发 PropertyChanged 事件的通用方法
		public event PropertyChangedEventHandler PropertyChanged;

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
		// PropertyChanged结束

	}



	public class CurrentApp: IOnItemClickListener, IOnDismissListener
	{
		public static string APP_VERSION = "2.0.2";

		private static CurrentApp app;
		public static CurrentApp sharedApp(){
			if (app == null) {
				app = new CurrentApp ();
			}
			return app;
		}

		private UpdateInfo updateModel;
		private IAlertViewActivity activity;

		public void CheckAppUpdate(IAlertViewActivity activity){
			var param = new Dictionary<string, object>();
			param.Add ("APP_VERSION", APP_VERSION);

			Tool.Get (URLConstant.kBaseUrl, URLConstant.kCheckUpdateUrl, param, activity,
				(responseObject) => {
					activity.RunOnUiThread(
						() => {
							this.activity = activity;

							if (Tool.CheckStatusCode(responseObject)){
								var updatePart = JObject.Parse(responseObject).SelectToken("data").SelectToken("update_info");
								if (updatePart != null){
									updateModel =  JsonConvert.DeserializeObject<UpdateInfo>(updatePart.ToString(), new JsonSerializerSettings
										{
											Error = (sender,errorArgs) =>
											{
												var currentError = errorArgs.ErrorContext.Error.Message;
												errorArgs.ErrorContext.Handled = true;
											}}
									);

									if (activity.AlertIsShown){
									}
									else {
										if (updateModel.Need_update){
											activity.AlertIsShown = true;
											AlertView alertview = new AlertView("赏脸更新下呗", updateModel.Update_message, "下次", new String[]{"更新"}, null, activity,AlertView.Style.Alert, this);
											alertview.SetOnDismissListener(this);
											alertview.Show();
										}
									}


								}

							}
						});
				},
				(exception) => {
					
				},
				false);
		}

		public void OnItemClick (Java.Lang.Object p0, int p1){
			if (p1 != AlertView.Cancelposition) {
				Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(updateModel.Download_url));
				activity.StartActivity(browserIntent);
			}
		}

		public void OnDismiss (Object p0){
			activity.AlertIsShown = false;
		}

		public CurrentApp ()
		{
			
		}
	}
}

