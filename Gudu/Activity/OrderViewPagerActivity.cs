
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
using Android.Support.V4.View;
using Android.Support.V4.App;
using GuduCommon;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Gudu.CustomView;
using System.Reactive.Linq;
using Newtonsoft.Json.Linq;
using DSoft.Messaging;
using Com.Costum.Android.Widget;
using AndroidHUD;
using Android.Content.PM;


namespace Gudu
{
	[Activity (Label = "OrderViewPagerActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class OrderViewPagerActivity : FragmentActivity, ViewPager.IOnPageChangeListener
	{
		private int REQUEST_CODE_PAYMENT = 23145;

		private OrderStatus initOrderStatus;
		private PullAndLoadListView _orderListView;
		private OrderListViewAdapter _orderListViewAdapter;
		private MaterialUI.Widget.TabPageIndicator _pageIndicator;
		private ViewPager _virtualViewPager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.initOrderStatus = (OrderStatus)(this.Intent.GetIntExtra("order_status", (int) OrderStatus.All));
			SetContentView (Resource.Layout.order_view_pager_activity);
			initUI ();
			setUpTrigger ();
		}

		void initUI(){
			_orderListView = FindViewById<PullAndLoadListView> (Resource.Id.order_listview);
			_pageIndicator = FindViewById<MaterialUI.Widget.TabPageIndicator> (Resource.Id.tab_indicator);
			_virtualViewPager = FindViewById<ViewPager> (Resource.Id.menuViewPager);

			_orderListViewAdapter = new OrderListViewAdapter(this, initOrderStatus);
			_orderListView.Adapter = _orderListViewAdapter;

			RelativeLayout top_bar = FindViewById<RelativeLayout> (Resource.Id.top_bar);
			ImageButton imgButton = new ImageButton(this);
			RelativeLayout.LayoutParams param = new RelativeLayout.LayoutParams
				((int)DeviceInfo.dp2px(this, 40), (int)DeviceInfo.dp2px(this, 40));
			imgButton.SetBackgroundResource (Resource.Color.transparent);
			param.AddRule(LayoutRules.CenterVertical);
			param.AddRule(LayoutRules.AlignParentLeft);
			imgButton.LayoutParameters = param;
			imgButton.SetImageResource(Resource.Drawable.ic_keyboard_arrow_left_white_48dp);
			top_bar.AddView(imgButton);
			imgButton.Click += (object sender, EventArgs e) => {
				this.Finish();
			};
		}
		void setUpTrigger(){
			_virtualViewPager.Adapter = new VirtualPagerAdapter (SupportFragmentManager);
			_pageIndicator.SetViewPager (_virtualViewPager);
			_pageIndicator.SetOnPageChangeListener (this);
			var emptyView = this.LayoutInflater.Inflate (Resource.Layout.OrderListViewEmptyView, null);
			AddContentView(emptyView, _orderListView.LayoutParameters); 
			_orderListView.EmptyView = emptyView;

			_orderListView.Refresh += (object sender, EventArgs e) => {
				OrderListViewAdapter adapter = this._orderListViewAdapter;
				adapter.page = 0;
				adapter.fetchData(adapter.Status);
			};
			_orderListView.LoadMore += (object sender, EventArgs e) => {
				OrderListViewAdapter adapter = this._orderListViewAdapter;
				adapter.fetchData(adapter.Status ,loadMore: true);
			};

			MessageBus.Default.Register<OrderRefreshOverEvent> (
				(sender, theEvent) => {
					this.RunOnUiThread(
						() => {
							this._orderListView.OnRefreshComplete();
						}
					);
				}
			);
			MessageBus.Default.Register<OrderLoadMoreOverEvent> (
				(sender, theEvent) => {
					this.RunOnUiThread(
						() => {
							this._orderListView.OnLoadMoreComplete();
						}
					);
				}
			);
			_orderListView.ChoiceMode = ChoiceMode.Single;
			_orderListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				OrderListViewAdapter adapter = this._orderListViewAdapter;
				adapter.seeOrderDetail(e.Position);
			};

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

					if (result == "success") {
						AndHUD.Shared.ShowToast (this, "支付成功", MaskType.Clear, TimeSpan.FromSeconds (2));
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

		public void OnPageScrolled (int position, float positionOffset, int positionOffsetPixels){
			
		}

		public void OnPageScrollStateChanged (int state){
			
		}

		public void OnPageSelected (int position){
			OrderListViewAdapter adapter = this._orderListViewAdapter;
			OrderStatus status = OrderStatus.All;
			if (position == 0) {
				status = OrderStatus.All;
			} else if (position == 1) {
				status = OrderStatus.notPaid;
			} else if (position == 2) {
				status = OrderStatus.notDelivered;
			} else if (position == 3) {
				status = OrderStatus.notReceived;
			} else if (position == 4) {
				status = OrderStatus.notCommented;
			}
			adapter.Status = status;
		}

	}

	/// <summary>
	/// view pager 适配器
	/// </summary>
	public class VirtualPagerAdapter: Android.Support.V4.App.FragmentStatePagerAdapter{
		public VirtualPagerAdapter(Android.Support.V4.App.FragmentManager fm): base(fm){
		}

		public override Android.Support.V4.App.Fragment GetItem (int position){
			VirtualFragment fragment = new VirtualFragment();
			return fragment;
		}

		public override int GetItemPosition(Java.Lang.Object objectValue)
		{
			return PositionNone;
		}

		public override int Count{
			get{ 
				return 5;
			}
		}

		private string titleForPosition(int position){
			if (position == 0) {
				return "全部";
			}
			else if(position == 1){
				return "待付款";
			}
			else if(position == 2){
				return "待发货";
			}
			else if(position == 3){
				return "待收货";
			}
			else{
				return "待评价";
			}
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position){

			return CharSequence.ArrayFromStringArray(new string[]{titleForPosition(position)})[0];
		}

	}

	/// <summary>
	/// fragment类型
	/// </summary>
	public class VirtualFragment: Android.Support.V4.App.Fragment{

		private Android.Widget.ListView menuListView;

		public VirtualFragment(): base(){

		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.store_menu_listview_fragment, container, false);
			return view;
		}
	}

	public class OrderListViewAdapter : BaseAdapter<OrderModel>, INotifyPropertyChanged {
		public int page = 0;
		private int limit = 10;
		Activity context;

		private OrderStatus status;
		public OrderStatus Status {
			get{
				return status;
			}
			set { SetField(ref status, value); }
		}

		private List<OrderModel> orderList;
		public List<OrderModel> OrderList {
			get{
				return orderList;
			}
			set { SetField(ref orderList, value); }
		}

		public OrderListViewAdapter(Activity context, OrderStatus initOrderStatus = OrderStatus.All) : base() {
			this.context = context;
			setUpTrigger ();
			this.Status = initOrderStatus;
		}

		 void setUpTrigger(){
			this.FromMyEvent<List<OrderModel>> ("OrderList").Subscribe (
				(list) => {
					context.RunOnUiThread(
						()=>{
							if (list == null) {
								this.OrderList = new List<OrderModel>();
							}
							this.NotifyDataSetChanged();
						}
					);
				}
			);
			this.FromMyEvent<OrderStatus> ("Status").Skip(1).Subscribe (
				(orderStatus) => {
					this.page = 0;
					fetchData(orderStatus);
				}
			);
		
		}

		public void seeOrderDetail(int position){
			
		}

		// 
		public void fetchData(OrderStatus status = OrderStatus.All, bool loadMore = false){
			context.RunOnUiThread (
				()=>{
					Dictionary<string, object> dict = new Dictionary<string, object> ();
					if (status != OrderStatus.All){
						dict.Add ("status", (int)status);
					}
					dict.Add("page", this.page + 1);
					dict.Add("limit", this.limit);

					Tool.Get (
						URLConstant.kBaseUrl,
						URLConstant.kGetOrdersUrl, 
						dict,
						context,
						(responseObject) => {
							if (loadMore){
								MessageBus.Default.Post(new OrderLoadMoreOverEvent());
							}
							else{
								MessageBus.Default.Post(new OrderRefreshOverEvent());
							}
							if (Tool.CheckStatusCode(responseObject)){
								

								Console.WriteLine("获取到了订单数据:{0}", responseObject);
								var data = JObject.Parse(responseObject).SelectToken("data");
//								bool lastPage = data.SelectToken("last_page").Value<bool>();
									
								this.page = data.SelectToken("page").Value<int>();
								this.limit = data.SelectToken("limit").Value<int>();

								var ordersPart = data.SelectToken("orders");

								var ordersData = JsonConvert.DeserializeObject<List<OrderModel>>(ordersPart.ToString(), new JsonSerializerSettings
									{
										Error = (sender,errorArgs) =>
										{
											var currentError = errorArgs.ErrorContext.Error.Message;
											errorArgs.ErrorContext.Handled = true;
										}}
								);
								if (ordersData.Count < 1){
									AndHUD.Shared.ShowToast(this.context, "没有更多数据", MaskType.Clear, TimeSpan.FromSeconds(1));
								}
								if (loadMore){
									this.OrderList.AddRange(ordersData);
									this.NotifyDataSetChanged();
								}
								else{
									this.OrderList = ordersData;
								}

							}
						},
						(exception) => {

						}
					);
				}
			);

		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override OrderModel this[int position] {  
			get { return OrderList[position]; }
		}
		public override int Count {
			get { return OrderList.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.OrderListCellView, null);

			var cellView = view as OrderCellView;
			if (cellView != null) {
				cellView.Order = this[position];
			}
			//OrderModel store = this [position];

			//view.FindViewById<TextView>(Resource.Id.store_name_textview_id).Text = store.Name;
			//view.FindViewById<TextView>(Resource.Id.store_brief_textview_id).Text = store.Brief;

			//Picasso.With(context).Load(store.Logo_filename).Into(view.FindViewById<ImageView>(Resource.Id.store_logo_image));
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
