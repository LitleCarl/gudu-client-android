
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
using DSoft.Messaging;
using SQLite;
using Squareup.Picasso;
using Android.Views.InputMethods;
using Himanshusoni.ME.Quantityview;
using Android.Content.PM;
using Gudu.Morning.Alertview;

namespace Gudu
{
	[Activity (Label = "CartActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class CartActivity : Activity
	{
		private bool isPresented; //表明是否是由下至上弹出

		private ListView cartListView;
		public RelativeLayout submitArea;
		private TextView totalPriceTextview;
		private Button checkButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.cart_activity);

			var showMethod = this.Intent.GetStringExtra ("show_method");

			if (showMethod == ActivityShowMethod.PRESENT) {
				SetupWindowAnimations ();
				isPresented = true;
			}
			// Create your application here
			SetupWindowAnimations();
			initUI();
			setUpTrigger();
		}
		void initUI(){
			submitArea = FindViewById<RelativeLayout> (Resource.Id.submit_area);	

			cartListView = FindViewById<ListView> (Resource.Id.cart_listview);	
			View emptyView = this.LayoutInflater.Inflate(Resource.Layout.cart_empty_view, null);
			AddContentView(emptyView, cartListView.LayoutParameters); 

			totalPriceTextview = FindViewById<TextView> (Resource.Id.total_price_textview);
			cartListView.EmptyView = emptyView;
			cartListView.Adapter = new CartListViewAdapter (this);

			checkButton = FindViewById<Button> (Resource.Id.check_button);

		}

		private void SetupWindowAnimations() {
			OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
		}

		void setUpTrigger(){

			checkButton.Click += (object sender, EventArgs e) => {
				if (UserSession.sharedInstance().IsLogin == false) {
					Intent login = new Intent(this, typeof(LoginActivity));
					login.PutExtra("show_method", ActivityShowMethod.PRESENT);
					StartActivity(login);
					return;
				} 
				StartActivity(new Intent(this, typeof(SelectAddressAndPayMethodActivity)));
			};

			MessageBus.Default.Register<CartItemChangedEvent> ((obj, messageBusEvent) => {
				ReCalculatePrice();
			});
			MessageBus.Default.Register<NeedReCalculatePriceEvent> ((obj, messageBusEvent) => {
				ReCalculatePrice();
			});

			ReCalculatePrice ();
			CartListViewAdapter myAdapter = (CartListViewAdapter) cartListView.Adapter;
			myAdapter.RefetchData();

		}
		/// <summary>
		/// 计算价格
		/// </summary>
		void ReCalculatePrice(){
			this.RunOnUiThread (
				() => {
					decimal totalPrice = decimal.Parse ("0.00");
					var items = CartItem.dbInstance.Table<CartItem> ().ToList ();
						bool empty =items.Count < 1;
						Console.WriteLine("购物车空了:{0}?", empty);
						submitArea.Visibility = empty? ViewStates.Invisible : ViewStates.Visible;
					items.ForEach (
						(item) => 
						{
							var tempPrice = Decimal.Multiply(Decimal.Parse(item.Price), new Decimal(item.Quantity));
							totalPrice = Decimal.Add(totalPrice, tempPrice);
						}
					);
					totalPriceTextview.Text = string.Format ("¥{0:0.00}", totalPrice);	
				}
			);

		}

		bool doubleBackToExitPressedOnce = false;
		public override void OnBackPressed ()
		{
			if (this.isPresented) {
				base.OnBackPressed ();
				return;
			}

			if (doubleBackToExitPressedOnce) {
				base.OnBackPressed ();
				Java.Lang.JavaSystem.Exit(0);
				return;
			} 


			this.doubleBackToExitPressedOnce = true;
			Toast.MakeText(this, "再点一次退出",ToastLength.Short).Show();

			new Handler().PostDelayed(()=>{
				doubleBackToExitPressedOnce=false;
			},2000);
		}


	}

	public class CartListViewAdapter : BaseAdapter<CartItem>, View.IOnClickListener, Gudu.Morning.Alertview.IOnItemClickListener{
		List<CartItem> CartList;
		Activity context;
		int deletePosition = -1;
		public CartListViewAdapter(Activity context) : base() {
			this.context = context;
			this.RefetchData ();
			MessageBus.Default.Register<CartItemChangedEvent> ((obj, messageBusEvent) => {
				RefetchData();
			});
		}

		public void RefetchData(){
			context.RunOnUiThread (new Action(()=> { 
				var db = CartItem.dbInstance;
				this.CartList = db.Table<CartItem> ().ToList<CartItem> ();
//				MessageBus.Default.Post (
//					new CartEmptyEvent(){
//						Sender = null,
//						Data = new object[]{"购物车数量变化"},
//					}
//				);
				this.NotifyDataSetChanged ();
			}));

		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override CartItem this[int position] {  
			get { 
					return CartList [position];
			}
		}
		public override int Count {
			get {
				return CartList.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			CartItem cart = this [position];

			if (view == null) // otherwise create a new one
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.cart_cell, null);
				QuantityView quantityView = view.FindViewById<QuantityView> (Resource.Id.quantityView_default);
				quantityView.SetQuantityClickListener (this);
				quantityView.MinQuantity = 1;
				quantityView.Tag = position;
				quantityView.Quantity = cart.Quantity;

				view.FindViewById<Button> (Resource.Id.delete_cart_image_button).Click += (object sender, EventArgs e) => {
					AlertView alertview = new AlertView("确定删除?", "", "取消", new String[]{"确定"}, null, context, 
						AlertView.Style.Alert, this);
					
					int temPosition = (int)(quantityView.Tag.JavaCast<Java.Lang.Integer>());
					deletePosition = temPosition;
					alertview.Show();
				};

				quantityView.QuantityChanged += (object sender, QuantityView.QuantityChangedEventArgs e) => {
					Console.WriteLine("QuantityChanged:{0}", quantityView.Quantity);
					int temPosition = (int)(quantityView.Tag.JavaCast<Java.Lang.Integer>());
					CartItem temp = this[temPosition];
					var item = CartItem.dbInstance.Table<CartItem>().Where((_item) => _item.ProductAndSpecification == temp.ProductAndSpecification).FirstOrDefault();
									if (item != null) {
						item.Quantity = quantityView.Quantity;
										
						CartItem.dbInstance.Update(item);

						MessageBus.Default.Post (new NeedReCalculatePriceEvent (){
							Sender = null,
							Data = new object[]{"需要重新计算价格"},
						});
										
									}
				};
			}
			
			QuantityView quantityView2 = view.FindViewById<QuantityView> (Resource.Id.quantityView_default);
			quantityView2.Tag = position;
			view.FindViewById<TextView>(Resource.Id.product_name_textview).Text = cart.Name;
			view.FindViewById<TextView>(Resource.Id.specification_textview).Text = cart.SpecificationBrief;
			view.FindViewById<TextView>(Resource.Id.per_price_textview).Text = string.Format("单价:¥{0}元",cart.Price);
			quantityView2.Quantity = cart.Quantity;
			Picasso.With(context).Load(cart.Logo_filename).Into(view.FindViewById<ImageView>(Resource.Id.product_imageview));
			return view;
		}
		/// <summary>
		/// quantity点击事件
		/// </summary>
		/// <param name="v">V.</param>
		public void OnClick (View v){

		}

		public void OnItemClick (Java.Lang.Object p0, int p1){
			if (p1 != AlertView.Cancelposition) {
				CartItem temp = this[deletePosition];
				this.CartList.Remove(temp);
				CartItem.dbInstance.Delete(temp);
				MessageBus.Default.Post (new CartItemChangedEvent (){
					Sender = null,
					Data = new object[]{"删除了一件商品"},
				});
			}
			Console.WriteLine ("点击了alertview");
		}


	}
}

