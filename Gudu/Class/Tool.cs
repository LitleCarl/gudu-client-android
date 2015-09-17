using System;
using System.Collections.Generic;
using VolleyCSharp;
using VolleyCSharp.ToolBox;
using Android.Util;
using Android.Views;
using System.Reactive;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Linq.Expressions;
using VolleyCSharp.MainCom;
using Android.Content;
using Newtonsoft.Json.Linq;
using Android.Preferences;


namespace Gudu
{
	public enum ResponseStatusCode{
		Normal = 200
	}
	public static class RxExt
	{
		public static IObservable<T> FromMyEvent<T>(this INotifyPropertyChanged src, string propertyName)
		{
			IObservable<T> signal = System.Reactive.Linq.Observable.Create<T>((obs) =>
				{
					PropertyChangedEventHandler handler = (object sender, PropertyChangedEventArgs e) => {

						if (e.PropertyName.Equals(propertyName)){

							obs.OnNext((T)(src.GetType().GetProperty(propertyName).GetValue(src, null)));
						}

					};
					//obs.OnNext((T)(src.GetType().GetProperty(propertyName).GetValue(src, null)));
					Console.WriteLine("value:{0}1", src.GetType().GetProperty(propertyName));
					src.PropertyChanged += handler;
					return () => src.PropertyChanged -= handler;
				});
			return signal;
		}
	}

	public class Tool
	{
		 
		public static ISharedPreferences sharedInstance;
		public static void SetStringForKey(string key, string value){
			
			ISharedPreferencesEditor editor = sharedInstance.Edit ();
			editor.PutString (key, value);
			editor.Commit ();
		}
		public static string StringForKey(Context context,string key){

			return sharedInstance.GetString(key, null);
		}

		/// <summary>
		/// 提取response中的状态码
		/// </summary>
		/// <param name="responseObject">Response json.</param>
		public static int GetStatusCode (string responseObject) {
		
			var statusCode = JObject.Parse (responseObject).SelectToken ("status").SelectToken ("code").Value<int>();
			Console.WriteLine ("statusCode:{0},type:{1}", statusCode, statusCode.GetType());
			return statusCode;

		}
		public static bool CheckStatusCode (string responseObject) {

			var statusCode = Tool.GetStatusCode (responseObject);
			Console.WriteLine ("statusCode:{0},type:{1}", statusCode, statusCode.GetType());
			bool valid = Tool.GetStatusCode (responseObject) == (int)ResponseStatusCode.Normal;
			return valid;

		}
		/// <summary>
		/// 发送Get请求
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="param">参数.</param>
		/// <param name="context">Context.</param>
		/// <param name="completionBlock">Completion block.</param>
		/// <param name="errorBlock">Error block.</param>
		/// <param name="showHud">是否显示hud</param>
		public static void Get (String url, Object param, Context context, Action<String> completionBlock, Action<Exception> errorBlock, bool showHud = true){
			RequestQueue queue = Volley.NewRequestQueue(context);
			queue.Start();
			ProgressHUD hud = null;
			if (showHud) {
				hud = ProgressHUD.Show(context, "请等待", true, false, null);
			}
			var request = new StringRequest(VolleyCSharp.MainCom.Request.Method.GET, url, (x) =>
				{
					queue.Stop();
					if (showHud){
						hud.Dismiss();
					}
					completionBlock(x);
				},
				(x) =>
				{
					Console.WriteLine("Get Error:{0}", x.ToString());
					queue.Stop();
					if (showHud){
						hud.Dismiss();
					}
					errorBlock(x);
				});
			request.SetRetryPolicy (new DefaultRetryPolicy(
				30 * 1000, 
				DefaultRetryPolicy.DEFAULT_MAX_RETRIES, 
				DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));
			queue.Add (request);
		}



	}
}

