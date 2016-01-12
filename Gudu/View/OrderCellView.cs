
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GuduCommon;
using Android.Text;
using Android.Text.Style;
using Android.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Com.Pingplusplus.Android;

namespace Gudu.CustomView
{
	public class OrderCellView : RelativeLayout, INotifyPropertyChanged
	{
		private int REQUEST_CODE_PAYMENT = 23145;

		private Context _myContext;
		private TextView _campusNameTextView;
		private TextView _orderStatusTextView;
		private ListView _orderListView;
		private TextView _totalPriceTextView;
		private TextView _totalItemCountTextView;
		private TextView _receiverAddressTextView;
		private TextView _receiverPhoneTextView;
		private TextView _orderNumberTextView;
		private TextView _orderPaidTimeTextView;
		private ImageView _payChannelImageView;
		private TextView _campus_name_textview;

		private Button _payButton;
		private Button _warmReminder;
		private Button _rateOrderButton;
		private Button _see_order_detail_button;
		private OrderModel order;
		public OrderModel Order {
			get{
				return order;
			}
			set { SetField(ref order, value); }
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

		public OrderCellView (Context context) :
			base (context)
		{
			Initialize (context);
		}

		public OrderCellView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize (context);
		}

		public OrderCellView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize (context);
		}

		void Initialize (Context context)
		{
			this._myContext = (Activity)context;
			initUI ();
		}

		protected override void OnFinishInflate(){
			base.OnFinishInflate ();
			_campusNameTextView = FindViewById<TextView>(Resource.Id.campus_name_textview);
			_orderStatusTextView = FindViewById<TextView>(Resource.Id.order_status_textview);
			_orderListView = FindViewById<ListView>(Resource.Id.order_item_listview);
			_orderListView.SetScrollContainer (false);
			_totalPriceTextView = FindViewById<TextView> (Resource.Id.order_total_price_textview);
			_totalItemCountTextView = FindViewById<TextView> (Resource.Id.total_item_count_textview);
			_payButton = FindViewById<Button> (Resource.Id.pay_button);
			_rateOrderButton = FindViewById<Button> (Resource.Id.rate_order_button);
			_warmReminder = FindViewById<Button> (Resource.Id.remind_text);
			_receiverAddressTextView = FindViewById<TextView> (Resource.Id.order_receiver_name_textview);
			_receiverPhoneTextView = FindViewById<TextView> (Resource.Id.order_receiver_phone_textview);
			_orderNumberTextView = FindViewById<TextView> (Resource.Id.order_number_textview);
			_orderPaidTimeTextView = FindViewById<TextView> (Resource.Id.order_time_paid_textview);
			_payChannelImageView = FindViewById<ImageView> (Resource.Id.pay_channel_icon_imageview);
			_campus_name_textview = FindViewById<TextView> (Resource.Id.campus_name_textview);
			_see_order_detail_button = FindViewById<Button> (Resource.Id.see_order_detail_button);
			setUpTrigger ();
			 
		}

		void initUI(){
			}
		void setUpTrigger(){
			this._payButton.Click += (object sender, EventArgs e) => {
				Tool.Get(URLConstant.kBaseUrl, URLConstant.kPayOrderUrl.Replace(":order_id", order.Id), null, this._myContext,
					(responseObject) => {
						if (Tool.CheckStatusCode(responseObject)){
							CartItem.clearCart();
							string charge = JObject.Parse(responseObject).SelectToken("data").SelectToken("charge").ToString();
							Intent intent = new Intent(this._myContext, typeof(PaymentActivity));

							intent.PutExtra(PaymentActivity.ExtraCharge, charge);
							(((Activity)this._myContext)).StartActivityForResult(intent, REQUEST_CODE_PAYMENT);
						}
					},
					(exception) => {
						
					}
				);
			};
			this._rateOrderButton.Click += (object sender, EventArgs e) => {

			};
			this.FromMyEvent<OrderModel> ("Order").Subscribe (
				(orderModel) => {
					if (orderModel != null){
						using (var h = new Handler (Looper.MainLooper)){
							h.Post(
								()=>{
									if (orderModel.Campus != null){
										this._campusNameTextView.Text = orderModel.Campus.Name;
									}
//									string statusMessage = null;
//									if (orderModel.Status == OrderStatus.Dead){
//										statusMessage = @"已取消";
//									}
//									else if (orderModel.Status == OrderStatus.notPaid) {
//										statusMessage = @"待付款";
//									}
//									else if (orderModel.Status == OrderStatus.notDelivered){
//										statusMessage = @"待发货";
//									}
//									else if (orderModel.Status == OrderStatus.notReceived){
//										statusMessage = @"待收货";
//									}
//									else if (orderModel.Status == OrderStatus.notCommented){
//										statusMessage = @"未评价";
//									}
//									else {
//										statusMessage = @"交易成功";
//									}


									if (orderModel.Status == OrderStatus.notPaid){
										_payButton.Visibility = ViewStates.Visible;
										//_payButton.LayoutParameters.Width = (int) DeviceInfo.dp2px((Activity)(this._myContext), 70);
									}
									else {
//										_payButton.LayoutParameters.Width = 1;
										_payButton.Visibility = ViewStates.Gone;
									}

									if (orderModel.Status == OrderStatus.notCommented){
										_rateOrderButton.Visibility = ViewStates.Visible;
//										_rateOrderButton.LayoutParameters.Width = (int) DeviceInfo.dp2px((Activity)(this._myContext), 70);
									}
									else {
										_rateOrderButton.Visibility = ViewStates.Gone;
//										_rateOrderButton.LayoutParameters.Width = 1;
									}

									if (orderModel.Status == OrderStatus.notDelivered || orderModel.Status == OrderStatus.notReceived){
										//_warmReminder.LayoutParameters.Width = (int) DeviceInfo.dp2px((Activity)(this._myContext), 70);
										_warmReminder.Visibility = ViewStates.Visible;
									}
									else {
										_warmReminder.Visibility = ViewStates.Gone;
//										_warmReminder.LayoutParameters.Width = 1;
									}

									SpannableString totalPriceString = new SpannableString(String.Format("实付:¥{0}", orderModel.Pay_price));
									totalPriceString.SetSpan(new ForegroundColorSpan(new Color(94, 94, 94)), 0, 3, SpanTypes.ExclusiveExclusive); 
									totalPriceString.SetSpan(new RelativeSizeSpan(0.9f), 0, 3, SpanTypes.ExclusiveExclusive); 
									totalPriceString.SetSpan(new ForegroundColorSpan(Color.Black), 4, totalPriceString.Length(), SpanTypes.ExclusiveExclusive); 
									totalPriceString.SetSpan(new RelativeSizeSpan(1.2f), 4, totalPriceString.Length(), SpanTypes.ExclusiveExclusive); 
									_totalPriceTextView.SetText(totalPriceString, TextView.BufferType.Spannable);

									SpannableString totalCountString = new SpannableString(String.Format("共{0}件商品", orderModel.Order_items.Count));
									totalCountString.SetSpan(new ForegroundColorSpan(new Color(94, 94, 94)), 0, totalCountString.Length(), SpanTypes.ExclusiveExclusive); 
									totalCountString.SetSpan(new RelativeSizeSpan(0.9f), 0, totalCountString.Length(), SpanTypes.ExclusiveExclusive); 
									totalCountString.SetSpan(new ForegroundColorSpan(Color.Black), 1, 1 + orderModel.Order_items.Count.ToString().Length, SpanTypes.ExclusiveExclusive); 
									totalCountString.SetSpan(new RelativeSizeSpan(1.2f), 1, 1 + orderModel.Order_items.Count.ToString().Length, SpanTypes.ExclusiveExclusive); 
									_totalItemCountTextView.SetText(totalCountString, TextView.BufferType.Spannable);
									//_campus_name_textview.Text = this.order.Campus.Name;

									this._orderStatusTextView.Text = order.Status_desc;

									_orderListView.Adapter = new OrderItemListViewAdapter(_myContext, this.Order.Order_items);

									_receiverAddressTextView.Text = order.Receiver_address;
									_receiverPhoneTextView.Text = order.Receiver_phone;
									_orderNumberTextView.Text = String.Format("订单编号:{0}", order.Order_number);
									if (order.Payment == null){
										_orderPaidTimeTextView.Visibility = ViewStates.Invisible;
									}
									else{
										_orderPaidTimeTextView.Visibility = ViewStates.Visible;
										_orderPaidTimeTextView.Text = String.Format("成交时间:{0}", order.Payment.Time_paid);
									}

									if (order.Pay_method.Equals("wx")) {
										_payChannelImageView.SetImageDrawable(_myContext.Resources.GetDrawable(Resource.Drawable.pay_weixin));
										_payChannelImageView.Visibility = ViewStates.Visible;
									}
									else if (order.Pay_method.Equals("alipay")) {
										_payChannelImageView.SetImageDrawable(_myContext.Resources.GetDrawable(Resource.Drawable.pay_ali));
										_payChannelImageView.Visibility = ViewStates.Visible;
									}
									else {
										_payChannelImageView.Visibility = ViewStates.Invisible;
									}

									_see_order_detail_button.SetHeight(this.Height);

								}
							);
						}
					}
				}
			);

			this._see_order_detail_button.Click += (object sender, EventArgs e) => {
				var intent = new Intent(_myContext, typeof(PayResultActivity));
				intent.PutExtra ("order_id", this.order.Id);
				_myContext.StartActivity (intent);
			};
		}

	}


	public class OrderItemListViewAdapter : BaseAdapter<OrderItemModel> {
		List<OrderItemModel> OrderItemList;
		Context context;
		public OrderItemListViewAdapter(Context context, List<OrderItemModel> items) : base() {
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
			if (view == null) // otherwise create a new one
				view = LayoutInflater.FromContext(this.context).Inflate(Resource.Layout.OrderItemListViewCell, parent, false);
			var cellView = view as Gudu.CustomView.OrderItemListViewCell;
			if (cellView != null) {
				cellView.OrderItem = this [position];
			}

			return view;
		}
	}
}

