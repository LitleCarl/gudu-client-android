
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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Gudu.CustomView;
using System.Runtime.CompilerServices;
using DSoft.Messaging;


namespace Gudu
{
	[Activity (Label = "SelectCouponActivity")]			
	public class SelectCouponActivity : BackButtonActivity
	{
		private decimal currentPrice;
		public decimal CurrentPrice {
			get;
			set;
		}


		private GridView _couponGridView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SelectCouponActivity);
			initUI ();
			setUpTrigger ();
			// Create your application here
		}
		void initUI(){
			_couponGridView = FindViewById<GridView> (Resource.Id.coupon_gridview);
			int padding = (int)DeviceInfo.dp2px (this, DeviceInfo.kScreenWidth (this) * 0.05f);
			_couponGridView.SetPadding(padding, padding, padding, padding);
			_couponGridView.SetHorizontalSpacing (2*padding);
			_couponGridView.SetVerticalSpacing (padding);
		}
		void setUpTrigger(){
			decimal totalPrice = decimal.Parse ("0.00");
			var items = CartItem.dbInstance.Table<CartItem> ().ToList ();
			items.ForEach (
				(item) => 
				{
					var tempPrice = Decimal.Multiply(Decimal.Parse(item.Price), new Decimal(item.Quantity));
					totalPrice = Decimal.Add(totalPrice, tempPrice);
				}
			);
			this.CurrentPrice = totalPrice;
			_couponGridView.Adapter = new SelectCouponGridViewAdapter (this);
			_couponGridView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				var coupon = (_couponGridView.Adapter as SelectCouponGridViewAdapter)[e.Position];
				if (coupon.Least_price <= CurrentPrice){
					MessageBus.Default.Post(
						new SelectCouponEvent(){
							coupon = coupon
						}
					);
					this.Finish();
				}
			};
			FindViewById<Button>(Resource.Id.not_use_coupon).Click += (object sender, EventArgs e) => {
				MessageBus.Default.Post(
					new SelectCouponEvent()
				);
				this.Finish();

			};
		}

	}

	public class SelectCouponGridViewAdapter : BaseAdapter<CouponModel>, INotifyPropertyChanged {
		private List<CouponModel> couponList;
		public List<CouponModel> CouponList{
			get{ 
				return couponList;
			}
			set { SetField(ref couponList, value); }
		}
		Activity context;

		protected void fetchData(){

			Tool.Get (
				URLConstant.kBaseUrl,
				URLConstant.kGetCouponsUrl.Replace (":user_id", UserSession.sharedInstance().User.Id)
				, null
				, this.context
				,
				(responseObject) => {
					if (Tool.CheckStatusCode(responseObject)){
						var couponsPart = JObject.Parse(responseObject).SelectToken("data").SelectToken("coupons").ToString();


						var coupons = JsonConvert.DeserializeObject<List<CouponModel>>(couponsPart, new JsonSerializerSettings
							{
								Error = (sender_clone,errorArgs) =>
								{
									var currentError = errorArgs.ErrorContext.Error.Message;
									errorArgs.ErrorContext.Handled = true;
								}}
						);
						if (coupons != null){
							this.CouponList = coupons;
						}
					}
				}
				,
				(exception) => {
				}
			);
		}

		public SelectCouponGridViewAdapter(Activity context) : base() {
			this.context = context;
			setUpTrigger ();
			fetchData ();
		}

		void setUpTrigger(){
			this.FromMyEvent<List<CouponModel>> ("CouponList").Subscribe (
				(coupons) => {
					if (coupons != null){
						this.NotifyDataSetChanged();
					}
					else{
						this.CouponList = new List<CouponModel>();
					}
				}
			);
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override CouponModel this[int position] {  
			get { return couponList[position]; }
		}
		public override int Count {
			get { 
				return couponList.Count; 
			}
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) { // otherwise create a new one
				view = context.LayoutInflater.Inflate (Resource.Layout.select_coupon_view_cell, null);
				view.LayoutParameters = (new GridView.LayoutParams ( (int)DeviceInfo.dp2px(this.context, DeviceInfo.kScreenWidth(this.context) * 0.4f), (int)DeviceInfo.dp2px(this.context, DeviceInfo.kScreenWidth(this.context) * 0.4f)));
			}
			var cell = view as SelectCouponViewCell;
			if (cell != null) {
				SelectCouponActivity activity = this.context as SelectCouponActivity;
				if (activity != null) {
					cell.CurrentPrice = activity.CurrentPrice;
				}
				cell.Coupon = this [position];
			}
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

