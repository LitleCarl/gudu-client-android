
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
using GuduCommon;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Reactive.Linq;
using DSoft.Messaging;
using Com.Cocosw.Bottomsheet;
using Com.Pingplusplus.Android;
using Newtonsoft.Json.Linq;
using AndroidHUD;
using Android.Content.PM;


namespace Gudu
{
	public enum PayStatus{
		None,
		Waiting,//支付请求等待响应
		PayDone,//支付成功
		PayFailed//支付失败
	}

	[Activity (Label = "SelectAddressAndPayMethodActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class SelectAddressAndPayMethodActivity : BackButtonActivity, INotifyPropertyChanged, IMenuItemOnMenuItemClickListener
	{
		private int REQUEST_CODE_PAYMENT = 23145;
		private ListView addressListView;
		private Dialog _hud;
		private Button _payButton;
		private Button _selectPaymentButton;
		private Button _selectDeliveryTimeButton;
		private Button _selectCouponButton;

		private TextView _deliveryTextView;
		private TextView _payMethodTextView;
		private TextView _couponTextView;

		private CouponModel currentSelectCoupon;
		public CouponModel CurrentSelectCoupon {
			get{
				return currentSelectCoupon;
			}
			set { SetField(ref currentSelectCoupon, value); }
		}

		private OrderModel order;
		public OrderModel Order {
			get{
				return order;
			}
			set { SetField(ref order, value); }
		}

		private PayStatus status;
		public PayStatus Status {
			get{
				return status;
			}
			set { SetField(ref status, value); }
		}

		private List<String> availableDeliveryTime;
		public List<String> AvailableDeliveryTime {
			get{
				return availableDeliveryTime;
			}
			set { SetField(ref availableDeliveryTime, value); }
		}

		private List<PaymentModel> availablePayMethod;
		public List<PaymentModel> AvailablePayMethod {
			get{
				return availablePayMethod;
			}
			set { SetField(ref availablePayMethod, value); }
		}

		private int deliveryTimeIndex;
		public int DeliveryTimeIndex {
			get{
				return deliveryTimeIndex;
			}
			set { SetField(ref deliveryTimeIndex, value); }
		}

		private int payMethodIndex;
		public int PayMethodIndex {
			get{
				return payMethodIndex;
			}
			set { SetField(ref payMethodIndex, value); }
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

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.select_address_and_pay_method_activity);
			initUI ();
			setUpTrigger ();
		}

		void initUI(){
			addressListView = FindViewById<ListView> (Resource.Id.address_listview);
			addressListView.ChoiceMode = ChoiceMode.Single;
			addressListView.Adapter = new AddressListViewAdapter (this, new List<AddressModel> ());
			_payButton = FindViewById<Button> (Resource.Id.pay_button);
			_selectPaymentButton = FindViewById<Button> (Resource.Id.select_payment_method);
			_selectDeliveryTimeButton = FindViewById<Button> (Resource.Id.select_delivery_time);
			_selectCouponButton = FindViewById<Button> (Resource.Id.select_coupon_button);
			_deliveryTextView = FindViewById<TextView> (Resource.Id.delivery_time_textview);
			_payMethodTextView = FindViewById<TextView> (Resource.Id.payment_textview);
			_couponTextView = FindViewById<TextView> (Resource.Id.current_coupon_textview);

			EventHandler addAddressAction = (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(AddAddressActivity)));
			};
			var emptyView = this.LayoutInflater.Inflate (Resource.Layout.address_listview_emptyview, null);
			AddContentView(emptyView, addressListView.LayoutParameters); 
			addressListView.EmptyView = emptyView;
			addressListView.EmptyView.FindViewById<Button> (Resource.Id.add_address_button).Click += addAddressAction;

		}

		void setUpTrigger(){
			this.FromMyEvent<PayStatus> ("Status").Subscribe (
				(status) => {

					this.RunOnUiThread(
						() => {
							if (status == PayStatus.None){

							}
							else if (status == PayStatus.Waiting){
								if (_hud != null){
									_hud.Dismiss();
								}
								_hud = ProgressHUD.Show(this, "请等待", true, false, null);
							}
							else if (status == PayStatus.PayDone){
								if (_hud != null){
									_hud.Dismiss();
								}	
							}
							else if(status == PayStatus.PayFailed){
								if (_hud != null){
									_hud.Dismiss();
								}	
								Console.WriteLine("支付失败");
							}
						}
					);


				}
			);

			MessageBus.Default.Register<PaymentDoneEvent> (
				(sender, theEvent) => {
					PaymentDoneEvent payEvent = theEvent as PaymentDoneEvent;
					if (payEvent != null){
						if (payEvent.PayDone){
							this.status = PayStatus.PayDone;
						}
						else {
							this.status = PayStatus.PayFailed;
						}
					}
				}
			);

			var signalOfPayMethodIndex = this.FromMyEvent<int> ("PayMethodIndex");
			var signalOfDeliveryTimeIndex = this.FromMyEvent<int> ("DeliveryTimeIndex");
			var signalOfAddressList = UserSession.sharedInstance ().FromMyEvent<UserModel> ("User").Select<UserModel, int> (
				                          (user) => {
					if (user != null && user.Addresses != null) {
						return user.Addresses.Count;
					} else {
						return 0;
					}
				}
			                          );
			signalOfAddressList.Subscribe (
				(listCount) => {
					this.RunOnUiThread(
						() => {
							if (listCount > 0){
								// 查找默认地址
								int selectIndex = 0;
								var defaultAddress = (from address in UserSession.sharedInstance().User.Addresses where address.DefaultAddress select address).FirstOrDefault<AddressModel>();
								if (defaultAddress != null){
									selectIndex = UserSession.sharedInstance().User.Addresses.IndexOf(defaultAddress);
								}
								this.addressListView.SetItemChecked(selectIndex, true);
							}

						}
					);
				}
			);
			Observable.CombineLatest (signalOfPayMethodIndex, signalOfDeliveryTimeIndex, signalOfAddressList).Subscribe (
				(IList<int> values) => {
					this.RunOnUiThread(
						() => {
							if (values[0] >=0 && values[1] >= 0 && values[2] > 0){

								_payButton.Enabled = true;
							}
							else {
								_payButton.Enabled = false;
							}
						}
					);
				}
			);

			this.PayMethodIndex = -1;
			this.DeliveryTimeIndex = -1;
			this.FromMyEvent<List<String>> ("AvailableDeliveryTime").Subscribe (
				(timeList) => {
					this.RunOnUiThread(
						() => {
							_selectDeliveryTimeButton.Enabled = timeList != null;
						}
					);
				}
			);

			this.FromMyEvent<List<PaymentModel>> ("AvailablePayMethod").Subscribe (
				(payMethodList) => {
					this.RunOnUiThread(
						() => {
							_selectPaymentButton.Enabled = payMethodList != null;
						}
					);
				}
			);

			this.FromMyEvent<int> ("PayMethodIndex").Subscribe (
				(indexOfPayMethod) => {
					if (indexOfPayMethod >= 0){
						this.RunOnUiThread(
							() => {
								_payMethodTextView.Text = this.AvailablePayMethod[indexOfPayMethod].Name;
							}
						);
					}
				}
			);

			this.FromMyEvent<int> ("DeliveryTimeIndex").Subscribe (
				(indexOfDeliveryTime) => {
					if (indexOfDeliveryTime >= 0){
						this.RunOnUiThread(
							() => {
								_deliveryTextView.Text = this.AvailableDeliveryTime[indexOfDeliveryTime];
							}
						);
					}
				}
			);
			BasicConfigManager.sharedManager (this).FromMyEvent<List<String>> ("DeliveryTimeSet").Subscribe (
				(timeSet) => {
					this.AvailableDeliveryTime = timeSet;
					if (timeSet != null && timeSet.Count >0){
						this.DeliveryTimeIndex = 0;
					}
				}
			);
			BasicConfigManager.sharedManager (this).FromMyEvent<List<PaymentModel>> ("PayMethodSet").Subscribe (
				(payList) => {
					this.AvailablePayMethod = payList;
					if (payList != null && payList.Count >0){
						this.PayMethodIndex = 0;
					}
				}
			);
					
			_selectPaymentButton.Click += (object sender, EventArgs e) => {
				BottomSheet builder = new BottomSheet.Builder(this).Title("支付方式").Sheet(Resource.Menu.noicon).Listener(this).Build();
				for(int i = 0; i < this.AvailablePayMethod.Count; i++){
					builder.Menu.Add(0, 100 + i, Menu.None, this.AvailablePayMethod[i].Name);
				}
				builder.Show();
			};
			_selectDeliveryTimeButton.Click += (object sender, EventArgs e) => {
				BottomSheet builder = new BottomSheet.Builder(this).Title("送餐时间").Sheet(Resource.Menu.noicon).Listener(this).Build();
				for(int i = 0; i < this.AvailableDeliveryTime.Count; i++){
					builder.Menu.Add(0, i, Menu.None, this.AvailableDeliveryTime[i]);
				}
				builder.Show();
			};

			_payButton.Click += (object sender, EventArgs e) => {
				AddressModel address = ((AddressListViewAdapter)this.addressListView.Adapter)[this.addressListView.CheckedItemPosition];
				var db = CartItem.dbInstance;
				List<CartItem> cartItems = db.Table<CartItem> ().ToList<CartItem> ();

				var hash = new Dictionary<string, object>();
				hash.Add("delivery_time", this.AvailableDeliveryTime[this.DeliveryTimeIndex]);
				hash.Add("pay_method", this.AvailablePayMethod[this.PayMethodIndex].Code);
				hash.Add("receiver_address", address.Address);
				hash.Add("receiver_phone", address.Phone);
				hash.Add("receiver_name", address.Name);
				hash.Add("cart_items", cartItems);
				hash.Add("campus", Tool.StringForKey(SPConstant.SelectCampusIdKeyInSharedPreference));
				if(currentSelectCoupon != null){
					hash.Add("coupon_id", currentSelectCoupon.Id);
				}
				var postJsonBody = JsonConvert.SerializeObject(hash);
				Tool.Post(URLConstant.kBaseUrl,
					URLConstant.kOrderPlaceOrderUrl, 
					this,
					postJsonBody,
					(responseObject) => {
						if (Tool.CheckStatusCode(responseObject)){
							CartItem.clearCart();
							string charge = JObject.Parse(responseObject).SelectToken("data").SelectToken("charge").ToString();
							Console.WriteLine("支付charge:{0}", charge);
							//String packageName = this.PackageName;
							//ComponentName componentName = new ComponentName(packageName, packageName + ".wxapi.WXPayEntryActivity");
							this.Order = JsonConvert.DeserializeObject<OrderModel>(JObject.Parse(responseObject).SelectToken("data").SelectToken("order").ToString(), new JsonSerializerSettings
								{
									Error = (sender2,errorArgs) =>
									{
										var currentError = errorArgs.ErrorContext.Error.Message;
										errorArgs.ErrorContext.Handled = true;
									}}
							);
								

							Intent intent = new Intent(this, typeof(PaymentActivity));

							intent.PutExtra(PaymentActivity.ExtraCharge, charge);
							StartActivityForResult(intent, REQUEST_CODE_PAYMENT);
						}
						else if(Tool.GetStatusMessage(responseObject) != null){
							AndHUD.Shared.ShowToast (this, Tool.GetStatusMessage(responseObject), MaskType.Clear, TimeSpan.FromSeconds (1.5));
						}

					},
					(exception) => {
						
					}
					,showHud:true);
					
			};

			// 选择优惠券
			_selectCouponButton.Click += (object sender, EventArgs e) => {
				StartActivity(typeof(SelectCouponActivity));
			};

			this.FromMyEvent<CouponModel> ("CurrentSelectCoupon").Subscribe (
				(coupon) => {
					if (coupon != null){
						_couponTextView.Text = String.Format("优惠:￥{0}元", coupon.Discount);
					}
					else {
						_couponTextView.Text = "不使用";
					}
				}
			);

			MessageBus.Default.Register<SelectCouponEvent> (
				(obj, evt) => {
					this.RunOnUiThread(
						() => {
							if(evt is SelectCouponEvent){
								var theEvent = evt as SelectCouponEvent;
								if (theEvent.coupon == null){
									_couponTextView.Text = "不使用";
								}
								else if(evt is SelectCouponEvent) {
									_couponTextView.Text = String.Format("优惠:￥{0}元", theEvent.coupon.Discount);
									this.CurrentSelectCoupon = theEvent.coupon;
								}
							}
						}
					);
				}
			);
		}

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
						AndHUD.Shared.ShowToast (this, "支付成功", MaskType.Clear, TimeSpan.FromSeconds (1.5));
						Observable.Timer(TimeSpan.FromSeconds(2.1)).Subscribe(
							(time) => {
								AndHUD.Shared.ShowToast(this, "支付成功", MaskType.Clear, TimeSpan.FromSeconds(2));
								var intent = new Intent (this, typeof(PayResultActivity));
								intent.PutExtra ("order_id", this.Order.Id);
								StartActivity (intent);
							}
						);

					}
					else if(errorMsg.Equals(PingPPConstant.WeixinNotInstalled)){
						AndHUD.Shared.ShowToast(this, PingPPConstant.WeixinNotInstalledReason, MaskType.Clear, TimeSpan.FromSeconds(2));
					}
					else {
						AndHUD.Shared.ShowToast(this, "支付失败,请重试", MaskType.Clear, TimeSpan.FromSeconds(2));
						var intent = new Intent (this, typeof(PayResultActivity));
						intent.PutExtra ("order_id", this.order.Id);
						StartActivity (intent);
					}


				}
			}
		}

		public bool OnMenuItemClick (IMenuItem item){
			if (item.ItemId >= 100) {
				// 表明是选择支付方式
				int id = item.ItemId - 100;
				this.PayMethodIndex = id;
			} else {
				int id = item.ItemId;
				this.DeliveryTimeIndex = id;
			}
			//this.CurrentSelectSpecification = this.Product.Specifications[item.ItemId];
			return true;
		}

	
	}

	public class AddressListViewAdapter : BaseAdapter<AddressModel>, INotifyPropertyChanged {
		Activity context;
		 
		private List<AddressModel> addressList;
		public List<AddressModel> AddressList {
			get{
				return addressList;
			}
			set { SetField(ref addressList, value); }
		}

		void setUpTrigger(){
			this.FromMyEvent<List<AddressModel>> ("AddressList").Subscribe (
				(list) => {
					if (list != null){
						context.RunOnUiThread(
							() => {
								this.NotifyDataSetChanged();

							}
						);
					}
				}
			);

			UserSession.sharedInstance ().FromMyEvent<UserModel>("User").Subscribe(
				(user) => {
					this.AddressList = user.Addresses;
				}
			);

		}

		public AddressListViewAdapter(Activity context, List<AddressModel> items) : base() {
			this.context = context;
			this.AddressList = items;

			setUpTrigger ();
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override AddressModel this[int position] {  
			get { return AddressList[position]; }
		}

		public override int Count {
			get { return AddressList.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.address_list_cell_view, null);
			AddressModel address = this [position];
			Console.WriteLine("address count:{0}", AddressList.Count);
			view.FindViewById<TextView>(Resource.Id.name_textview).Text = address.Name;
			view.FindViewById<TextView>(Resource.Id.address_textview).Text = address.Address;
			view.FindViewById<TextView>(Resource.Id.phone_textview).Text = address.Phone;
			view.FindViewById<TextView> (Resource.Id.default_address_indicator).Visibility = ViewStates.Gone;
			return view;
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

}

