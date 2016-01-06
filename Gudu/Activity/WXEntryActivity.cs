
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tencent.MM.Sdk.Modelbase;
using Com.Tencent.MM.Sdk.Openapi;
using Com.Tencent.MM.Sdk.Modelmsg;
using Newtonsoft.Json.Linq;
using AndroidHUD;
using System.Reactive.Linq;

namespace Gudu.Wxapi
{
	[Activity (Label = "WXEntryActivity", Name = "gudu.wxapi.WXEntryActivity")]			
	public class WXEntryActivity : Activity, IWXAPIEventHandler
	{
		private IWXAPI api;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
//			SetContentView (Resource.Layout.address_manage_activity);
			api = WXApiManager.manager(this).api;
			api.HandleIntent(this.Intent, this);

			// Create your application here
		}

		public void OnReq (BaseReq p0){
			Console.WriteLine ("微信返回结果");
		}

		public void OnResp (BaseResp p0){

			SendAuth.Resp authResp = null;
			SendMessageToWX.Resp messageResp = null;
			try{
				 authResp = p0.JavaCast<SendAuth.Resp> ();
				if (authResp != null) {
					Console.WriteLine ("微信登录code:{0}", authResp.Code);
					var param = new Dictionary<string ,object> ();
					param.Add ("code", authResp.Code);

					Tool.Post(URLConstant.kBaseUrl, URLConstant.kWeixinLoginUrl, this, param,
						(responseObject) => {
							if (Tool.CheckStatusCode(responseObject)){

								var data = JObject.Parse(responseObject).SelectToken("data"); 
								string tokenPart = "";
								var tokenPartJson = data.SelectToken("token");
								if (tokenPartJson != null){
									tokenPart = tokenPartJson.ToString();
								}
								var authPart = data.SelectToken("auth").ToString();

								Console.WriteLine("tokenPart:{0}, authPart:{1}", tokenPart, authPart);

								if (tokenPart != null && tokenPart.Length > 0){

									UserSession.sharedInstance().SessionToken = tokenPart;
									this.Finish();
								}
								else if (authPart != null && authPart.Length > 0){
									var union_id = data.SelectToken("auth").SelectToken("union_id").Value<string>();
									if (union_id != null){
										var intent = new Intent (this, typeof(BindUserActivity));
										intent.PutExtra ("union_id", union_id);
										StartActivity (intent);	
										this.Finish();
									}
								}

							}
							else{
								var message = JObject.Parse(responseObject).SelectToken("status").SelectToken("message").Value<string>();
								if (message == null){
									message = "系统异常,请稍后重试";
								}
								AndHUD.Shared.ShowToast (this, message, MaskType.Clear, TimeSpan.FromSeconds (2.0));
								Observable.Timer(TimeSpan.FromSeconds(2.1)).Subscribe(
									(time) => {
										this.Finish();
									}
								);
							}
						},
						(exception) =>{

						}

					);


				}
			}
			catch(Exception e){
			
			}


			try{
				messageResp = p0.JavaCast<SendMessageToWX.Resp> ();
				this.Finish();

			}
			catch(Exception e){
			
			}

		}

	}
}

