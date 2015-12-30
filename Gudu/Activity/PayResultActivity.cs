
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GuduCommon;
using System.Reactive.Linq;
using Newtonsoft.Json.Linq;
using Com.Pingplusplus.Android;
using AndroidHUD;
using Newtonsoft.Json;
using Com.Tencent.MM.Sdk.Modelmsg;
using Gudu.CustomView;

namespace Gudu
{
	[Activity (Label = "PayResultActivity")]			
	public class PayResultActivity : BackButtonActivity, INotifyPropertyChanged
	{
		private int REQUEST_CODE_PAYMENT = 23145;

		private ImageButton sendRedPackButton;
		private Button rePayButton;
		private Button _advice_button;
		private ImageView _avatarView;

		private TextView _phoneTextView;
		private TextView _addressTextView;
		private TextView _deliveryTimeTextView;

		private ListView _listView;

		private OrderModel order;
		public OrderModel Order{
			get{ return order;}
			set { SetField(ref order, value); }
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.pay_result_activity);

			initUI ();
			setUpTrigger ();

			string order_id = this.Intent.GetStringExtra ("order_id");
			loadOrderData (order_id);
		}

		void initUI(){
			rePayButton = FindViewById<Button> (Resource.Id.repay_button);
			sendRedPackButton = FindViewById<ImageButton> (Resource.Id.send_red_pack_id);
			_advice_button = FindViewById<Button> (Resource.Id.advice_button);

			_phoneTextView = FindViewById<TextView> (Resource.Id.telephone_textview);
			_addressTextView = FindViewById<TextView> (Resource.Id.address_textview);
			_deliveryTimeTextView = FindViewById<TextView> (Resource.Id.deliver_time_textview);
			_listView = FindViewById<ListView> (Resource.Id.order_item_listview);
			_avatarView = FindViewById<ImageView> (Resource.Id.avatar);
			_avatarView.SetMinimumWidth((int)DeviceInfo.dp2px (this, 80));
			_avatarView.SetMinimumHeight((int)DeviceInfo.dp2px (this, 80));
		}

		void setUpTrigger(){
			var red_pack_available_signal = BasicConfigManager.sharedManager (this).FromMyEvent<bool> ("Red_pack_available");
			var payDoneSignal = this.FromMyEvent<OrderModel> ("Order").Select<OrderModel, bool>(
				(order_temp) => {
					return order_temp != null && order_temp.Payment != null;
				}
			);
			var list = new List<IObservable<bool>> ();
			list.Add (red_pack_available_signal);
			list.Add (payDoneSignal);
			Observable.CombineLatest (list).Subscribe(
				(boolList) => {
					this.RunOnUiThread(
						()=>{
							bool could_send_red_pack = boolList[0] && boolList[1];
							if (could_send_red_pack){
								sendRedPackButton.Visibility = ViewStates.Visible;
							}
							else {
								sendRedPackButton.Visibility = ViewStates.Invisible;
							}
						}
					);

				}
			);
			rePayButton.Click += (object sender, EventArgs e) => {
				Tool.Get(URLConstant.kBaseUrl, URLConstant.kPayOrderUrl.Replace(":order_id", order.Id), null, this,
					(responseObject) => {
						if (Tool.CheckStatusCode(responseObject)){
							CartItem.clearCart();
							string charge = JObject.Parse(responseObject).SelectToken("data").SelectToken("charge").ToString();
							Intent intent = new Intent(this, typeof(PaymentActivity));

							intent.PutExtra(PaymentActivity.ExtraCharge, charge);
							this.StartActivityForResult(intent, REQUEST_CODE_PAYMENT);
						}
					},
					(exception) => {

					}
				);
			};
			payDoneSignal.Subscribe (
				(payDone) => {
					this.RunOnUiThread(
						()=> {
							if (payDone){
								rePayButton.Visibility = ViewStates.Invisible;
							}
							else {
								rePayButton.Visibility = ViewStates.Visible;

								if (this.Order != null){
									rePayButton.Enabled = true;
								}
								else {
									rePayButton.Enabled = false;
								}

							}
						}
					);

				}
			);

			sendRedPackButton.Click += (object sender, EventArgs e) => {
				WXWebpageObject web = new WXWebpageObject();
				web.WebpageUrl = string.Format("{0}/authorizations/get_coupon?order_number={1}", URLConstant.kBaseUrl, this.Order.Order_number);
				web.WebpageUrl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx98e5b3cd70319417&redirect_uri={0}&response_type=code&scope=snsapi_userinfo&state=zaocan84#wechat_redirect", web.WebpageUrl);
				WXMediaMessage message = new WXMediaMessage(web);
				message.Title = "早餐巴士";
				message.Description = "点击直接领取早餐红包啦~";

				SendMessageToWX.Req req = new SendMessageToWX.Req();
				req.Message = message;
				req.Scene = SendMessageToWX.Req.WXSceneSession;

				var api = WXApiManager.manager(this).api;
				api.SendReq(req);
			};

			this.FromMyEvent<OrderModel> ("Order").Subscribe (
				(order)=>{
					if (order != null){
						this.RunOnUiThread(
							() =>{
								this._listView.Adapter = new OrderItemListViewAdapter(this, this.Order.Order_items);
								this._listView.LayoutParameters.Height = Math.Max((int)DeviceInfo.dp2px(this, 30) * this.Order.Order_items.Count, (int)DeviceInfo.dp2px(this, 80));
								this._addressTextView.Text = this.Order.Receiver_address;
								this._phoneTextView.Text = this.Order.Receiver_phone;
								this._deliveryTimeTextView.Text = this.Order.Delivery_time;
							}
						);
					}
				}
			);

			_advice_button.Click += (object sender, EventArgs e) => {
				Intent callIntent = new Intent(Intent.ActionCall);
				callIntent.SetData(Android.Net.Uri.Parse(string.Format("tel:{0}", BasicConfigManager.sharedManager(this).Kefu_phone)));
				this.StartActivity(callIntent);
			};

			loadOrderData ();

		}

		void loadOrderData(string order_id = null){
			if (this.Order != null || order_id != null) {
				string temp_order_id = null;
				if (this.Order != null) {
					temp_order_id = this.order.Id;
				} else {
					temp_order_id = order_id;
				}

				Tool.Get (URLConstant.kBaseUrl, URLConstant.kOrderShowUrl.Replace(":order_id", temp_order_id), null, this,
					(responseObject) => {
						this.RunOnUiThread(
							() => {
								if (Tool.CheckStatusCode(responseObject)){
									var orderPart = JObject.Parse(responseObject).SelectToken("data").SelectToken("order").ToString();
									this.Order = JsonConvert.DeserializeObject<OrderModel>(orderPart, new JsonSerializerSettings
										{
											Error = (sender,errorArgs) =>
											{
												var currentError = errorArgs.ErrorContext.Error.Message;
												errorArgs.ErrorContext.Handled = true;
											}}
									);
								}

							}
						);
					},
					(exception) => {
						
					}
				);
				
			}
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

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
			base.OnActivityResult(requestCode, resultCode, data);
			//支付页面返回处理
			if (requestCode == REQUEST_CODE_PAYMENT) {
				if (resultCode == Result.Ok) {
					String result = data.Extras.GetString ("pay_result");
					/* 处理返回值
             * "success" - payment succeed
             * "fail"    - payment failed
             * "cancel"  - user canceld
             * "invalid" - payment plugin not installed
             *
             * 如果是银联渠道返回 invalid，调用 UPPayAssistEx.installUPPayPlugin(this); 安装银联安全支付控件。
             */				
					String errorMsg = data.Extras.GetString ("error_msg"); // 错误信息
					String extraMsg = data.Extras.GetString ("extra_msg"); // 错误信息
					Console.WriteLine ("result:{0}", result);
					Console.WriteLine ("errorMsg:{0}", errorMsg);
					Console.WriteLine ("extraMsg:{0}", extraMsg);

					if (result.Equals("success")) {
						AndHUD.Shared.ShowToast (this, "支付成功", MaskType.Clear, TimeSpan.FromSeconds (2));
						loadOrderData ();
					}
					else if(errorMsg.Equals(PingPPConstant.WeixinNotInstalled)){
						AndHUD.Shared.ShowToast(this, PingPPConstant.WeixinNotInstalledReason, MaskType.Clear, TimeSpan.FromSeconds(2));
					}
					else {
						AndHUD.Shared.ShowToast(this, "支付失败,请重试", MaskType.Clear, TimeSpan.FromSeconds(2));
					}


				} 
			}
		}
	}



	public class OrderItemListViewAdapter : BaseAdapter<OrderItemModel> {
		List<OrderItemModel> OrderItemList;
		Activity context;
		public OrderItemListViewAdapter(Activity context, List<OrderItemModel> items) : base() {
			this.context = context;
			this.OrderItemList = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override OrderItemModel this[int position] {  
			get { return OrderItemList[position]; }
		}
		public override int Count {
			get { return OrderItemList.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) { // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.PayResultTableViewCell, parent, false);
				view.LayoutParameters.Height = (int)DeviceInfo.dp2px (this.context, 30);
			}
			OrderItemModel orderItem = this [position];
			OrderItemCellForPayResultActivity cell = view as OrderItemCellForPayResultActivity;
			if (cell != null) {
				cell.OrderItem = orderItem;
			}

			return view;
		}
	}
}

