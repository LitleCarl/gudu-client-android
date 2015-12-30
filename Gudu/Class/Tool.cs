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
using System.Diagnostics;
using System.Text;
using Flurl;
using RestSharp;
using Android.OS;
using Newtonsoft.Json;


namespace Gudu
{

	public enum ResponseStatusCode{
		Normal = 200,
		SessionInvalid = 800,
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
					obs.OnNext((T)(src.GetType().GetProperty(propertyName).GetValue(src, null)));
					Console.WriteLine("value:{0}1", src.GetType().GetProperty(propertyName));
					src.PropertyChanged += handler;
					return () => src.PropertyChanged -= handler;
				});
			return signal;
		}
	}

	public class Tool
	{ 
		private static string TokenNameInHeader = "x-access-token";

		public static ISharedPreferences sharedInstance;
		public static void SetStringForKey(string key, string value){
			
			ISharedPreferencesEditor editor = sharedInstance.Edit ();
			editor.PutString (key, value);
			editor.Commit ();
		}
		public static string StringForKey(string key){

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

		public static String GetStatusMessage (string responseObject) {

			var message = JObject.Parse (responseObject).SelectToken ("status").SelectToken ("message").Value<String>();
			return message;

		}

		public static bool CheckStatusCode (string responseObject) {

			bool valid = Tool.GetStatusCode (responseObject) == (int)ResponseStatusCode.Normal;
			return valid;

		}


		public static String BuildUrl(string baseUrl, string path,Dictionary<string, string> queryParam){
			return baseUrl.AppendPathSegment(path).SetQueryParams(queryParam);
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
		public static void Get (String baseUrl, String resourceUrl,Dictionary<string, object> param, Context context, Action<String> completionBlock, Action<Exception> errorBlock, bool showHud = true){

				using (var h = new Handler (Looper.MainLooper)){
					h.Post(
						()=>{
							var client = new RestClient(baseUrl);
							var request = new RestRequest(resourceUrl, Method.GET);

							if (param != null) {
								foreach(KeyValuePair<string, object> entry in param)
								{
									request.AddParameter(entry.Key, entry.Value);
								}
							}

							ProgressHUD hud = null;
							if (showHud) {

								hud = ProgressHUD.Show(context, "请等待", true, false, null);
							}

							// 添加token（如果存在的话）
							if (Tool.StringForKey(SPConstant.LoginToken) != null){
								request.AddHeader (TokenNameInHeader, Tool.StringForKey(SPConstant.LoginToken));
							}

							client.ExecuteAsync(request, response => {

								using (var hh = new Handler (Looper.MainLooper)){
									hh.Post(
										()=>{
											if (showHud){
												hud.Dismiss();
											}
											if (response.ErrorException != null){
												errorBlock(response.ErrorException);
											}
											else{
												completionBlock(response.Content);
											}
										}
									);
								}
							});
						}
					);
				}

		}



		public static void Post (String baseUrl, String resourceUrl, Context context, object body, Action<String> completionBlock, Action<Exception> errorBlock, bool showHud = true){
			using (var h = new Handler (Looper.MainLooper)){
				h.Post(
					()=>{
			var client = new RestClient(baseUrl);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);

			var request = new RestRequest(resourceUrl, Method.POST);
			//request.AddJsonBody (body);
			request.AddHeader("header", "application/json");
			if (body == null) {
			
			}
			else if (body.GetType() == typeof(String)) {
				request.AddParameter ("application/json", body, ParameterType.RequestBody);
			} else {
				request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
			}
			ProgressHUD hud = null;
			if (showHud) {
				hud = ProgressHUD.Show(context, "请等待", true, false, null);
			}

			// 添加token（如果存在的话）
			if (Tool.StringForKey(SPConstant.LoginToken) != null){
				request.AddHeader (TokenNameInHeader, Tool.StringForKey(SPConstant.LoginToken));
			}

			client.ExecuteAsync(request, response => {
				using (var hh = new Handler (Looper.MainLooper)){
					hh.Post(
						()=>{
							if (showHud){
								hud.Dismiss();
							}
							if (response.ErrorException != null){
								errorBlock(response.ErrorException);
							}
							else{
								completionBlock(response.Content);
							}
						}
					);
				}

			});
					});
			}
		}

		public static void Put (String baseUrl, String resourceUrl, Context context, object body, Action<String> completionBlock, Action<Exception> errorBlock, bool showHud = true){
			var client = new RestClient(baseUrl);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);

			var request = new RestRequest(resourceUrl, Method.PUT);
			//request.AddJsonBody (body);
			request.AddHeader("header", "application/json");
			if (body.GetType() == typeof(String)) {
				request.AddParameter ("application/json", body, ParameterType.RequestBody);
			} else {
				request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
			}
			ProgressHUD hud = null;
			if (showHud) {
				hud = ProgressHUD.Show(context, "请等待", true, false, null);
			}

			// 添加token（如果存在的话）
			if (Tool.StringForKey(SPConstant.LoginToken) != null){
				request.AddHeader (TokenNameInHeader, Tool.StringForKey(SPConstant.LoginToken));
			}

			client.ExecuteAsync(request, response => {
				using (var h = new Handler (Looper.MainLooper)){
					h.Post(
						()=>{
							if (showHud){
								hud.Dismiss();
							}
							if (response.ErrorException != null){
								errorBlock(response.ErrorException);
							}
							else{
								completionBlock(response.Content);
							}
						}
					);
				}

			});

		}

	}
}

