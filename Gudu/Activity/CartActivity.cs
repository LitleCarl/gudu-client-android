
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

namespace Gudu
{
	[Activity (Label = "CartActivity")]			
	public class CartActivity : Activity
	{
		private ListView cartListView;
		public RelativeLayout submitArea;
		private TextView totalPriceTextview;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.cart_activity);
			// Create your application here
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

		}
		void setUpTrigger(){
			MessageBus.Default.Register<CartEmptyEvent> ((obj, messageBusEvent) => {
				this.RunOnUiThread (new Action(()=> { 
					bool empty = CartItem.dbInstance.Table<CartItem>().Count() < 1;
					Console.WriteLine("购物车空了:{0}?", empty);
					submitArea.Visibility = empty? ViewStates.Gone : ViewStates.Visible;
				}));

			});
			MessageBus.Default.Register<CartItemChangedEvent> ((obj, messageBusEvent) => {
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
			decimal totalPrice = decimal.Parse ("0.00");
			var items = CartItem.dbInstance.Table<CartItem> ().ToList ();
			items.ForEach (
				(item) => 
				{
					var tempPrice = Decimal.Multiply(Decimal.Parse(item.Price), new Decimal(item.Quantity));
					totalPrice = Decimal.Add(totalPrice, tempPrice);
				}
			);
			totalPriceTextview.Text = string.Format ("¥{0:0.00}", totalPrice);
		}



	}

	public class CartListViewAdapter : BaseAdapter<CartItem>, TextView.IOnEditorActionListener{
		List<CartItem> CartList;
		Activity context;
		public CartListViewAdapter(Activity context) : base() {
			this.context = context;
			this.RefetchData ();
			MessageBus.Default.Register<CartItemChangedEvent> ((obj, messageBusEvent) => {
				Console.WriteLine("购物车发生变化");
				RefetchData();
			});
		}

		public void RefetchData(){
			context.RunOnUiThread (new Action(()=> { 
				var db = CartItem.dbInstance;
				this.CartList = db.Table<CartItem> ().ToList<CartItem> ();
				MessageBus.Default.Post (
					new CartEmptyEvent(){
						Sender = null,
						Data = new object[]{"购物车数量变化"},
					}
				);
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
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.cart_cell, null);
			CartItem cart = this [position];

			view.FindViewById<TextView>(Resource.Id.product_name_textview).Text = cart.Name;
			view.FindViewById<TextView>(Resource.Id.specification_textview).Text = cart.SpecificationBrief;
			view.FindViewById<TextView>(Resource.Id.per_price_textview).Text = cart.Price;
			view.FindViewById<EditText>(Resource.Id.editText1).Text = cart.Quantity.ToString();
			view.FindViewById<EditText> (Resource.Id.editText1).ImeOptions = ImeAction.Done;
			view.FindViewById<EditText> (Resource.Id.editText1).Tag = cart.ProductAndSpecification;
			view.FindViewById<EditText> (Resource.Id.editText1).SetOnEditorActionListener (this);

			Picasso.With(context).Load(cart.Logo_filename).Into(view.FindViewById<ImageView>(Resource.Id.product_imageview));
			return view;
		}

		public bool OnEditorAction (TextView v, [GeneratedEnum] ImeAction actionId, KeyEvent e){
			if (actionId == ImeAction.Done)
			{
				string primaryKey = (string)v.Tag;
				var item = CartItem.dbInstance.Table<CartItem>().Where((_item) => _item.ProductAndSpecification == primaryKey).FirstOrDefault();
				if (item != null) {
					item.Quantity = int.Parse(((EditText)v).Text);
					if (item.Quantity < 1){
						CartItem.dbInstance.Delete(item);
					}
					else{
						CartItem.dbInstance.Update(item);
					}
					MessageBus.Default.Post (new CartItemChangedEvent (){
						Sender = null,
						Data = new object[]{"购物车商品变化"},
					});
					return true;
				}

			}
			return false;
		}


	}
}

