
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
using MaterialUI.Widget;
using Android.Support.V4;
using Android.Support.V4.View;
using Android.Support.V4.App;
using GuduCommon;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Squareup.Picasso;
using System.Reactive;
using System.Reactive.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Gudu.CustomView;
using Android.Content.PM;

namespace Gudu
{
	[Activity (Label = "StoreIndexActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class StoreIndexActivity : FragmentActivity, INotifyPropertyChanged
	{
		private ViewPager viewPager;

		private RelativeLayout _menuContainer;
		private RelativeLayout _cardContainer;

		// CardView部分
		private Android.Widget.TextView _signatureTextView;
		private ImageView _logoImageView;
		private Android.Widget.TextView _storeNameTextView;
		private Android.Widget.TextView _monthSaleTextView;
		private Android.Widget.TextView _backRatioTextView;
		private Android.Widget.TextView _mainFoodListTextView;
		private Android.Widget.TextView _storeNameInCardViewTextView;

		private String store_id;
		public String Store_id {
			get { 
				return store_id;
			}
			set { SetField(ref store_id, value); }
		}

		private StoreModel store;
		public StoreModel Store {
			get{
				return store;
			}
			set { SetField(ref store, value); }
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.store_index_activity);
			if (this.Intent.Extras != null && this.Intent.Extras.GetString ("store_id") != null) {
				this.Store_id = this.Intent.Extras.GetString ("store_id");
			}
			initUI ();
			setUpTrigger ();
		}	

		void initUI(){
			this.Store = new StoreModel{
				Products =  new List<ProductModel> ()
			};
			MaterialUI.Widget.TabPageIndicator tab_indicator = FindViewById<MaterialUI.Widget.TabPageIndicator>(Resource.Id.tab_indicator);
			viewPager = FindViewById<Android.Support.V4.View.ViewPager> (Resource.Id.menuViewPager);
			viewPager.Adapter = new MenuPagerAdapter(SupportFragmentManager, this);
			tab_indicator.SetViewPager (viewPager);
			//viewPager.SetCurrentItem()
			_menuContainer = FindViewById<RelativeLayout> (Resource.Id.container_view);
			_cardContainer = FindViewById<RelativeLayout> (Resource.Id.container_view_for_cardview);

			_signatureTextView = FindViewById<Android.Widget.TextView> (Resource.Id.store_signature_textview);
			_logoImageView = FindViewById<ImageView> (Resource.Id.logo_imageview);
			_monthSaleTextView = FindViewById<Android.Widget.TextView>(Resource.Id.month_sale_textview);
			_backRatioTextView = FindViewById<Android.Widget.TextView> (Resource.Id.back_ratio_textview);
			_mainFoodListTextView = FindViewById<Android.Widget.TextView> (Resource.Id.main_food_list_textview);
			_storeNameTextView = FindViewById<Android.Widget.TextView> (Resource.Id.store_name_textview);
			_storeNameInCardViewTextView = FindViewById<Android.Widget.TextView> (Resource.Id.store_name_textview_in_cardview);


		}

		void setUpTrigger (){
			this.FromMyEvent<string> ("Store_id").Subscribe (
				(store_id) => {
					fetchData ();
				}
			);

			// 返回按钮点击
			this.FindViewById<Android.Widget.ImageButton>(Resource.Id.back_button).Click += (object sender, EventArgs e) => {
				this.Finish();
			};

			this.FromMyEvent<StoreModel> ("Store").Subscribe (
				(store) => {
					viewPager.Adapter.NotifyDataSetChanged();
					if (store != null){
						_signatureTextView.Text = store.Signature;
						_monthSaleTextView.Text = store.Month_sale;
						_backRatioTextView.Text = String.Format("{0}%", (int)(store.Back_ratio * 100));
						_mainFoodListTextView.Text = store.Main_food_list;
						_storeNameTextView.Text = store.Name;
						_storeNameInCardViewTextView.Text = store.Name;
						Picasso.With(this).Load(store.Logo_filename).Into(_logoImageView);
					}
				}
			);

			FindViewById<Android.Widget.RadioButton>(Resource.Id.radio_card).CheckedChange += (object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e) => {
				if (e.IsChecked){
					_cardContainer.Visibility = ViewStates.Visible;
				}
				else{
					_cardContainer.Visibility = ViewStates.Invisible;
				}
			};
			FindViewById<Android.Widget.RadioButton>(Resource.Id.radio_menu).CheckedChange += (object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e) => {
				if (e.IsChecked){
					_menuContainer.Visibility = ViewStates.Visible;
				}
				else{
					_menuContainer.Visibility = ViewStates.Invisible;
				}
			};

		}

		void fetchData (){
			if (this.Store_id != null) {
				Tool.Get (
					URLConstant.kBaseUrl,
					URLConstant.kStoreFindOneUrl.Replace(":store_id",this.Store_id),
					null,
					this,
					(string responseObject) => {
						var storePart = JObject.Parse(responseObject).SelectToken("data").SelectToken("store").ToString();
						StoreModel store = JsonConvert.DeserializeObject<StoreModel>(storePart, new JsonSerializerSettings
							{
								Error = (sender,errorArgs) =>
								{
									var currentError = errorArgs.ErrorContext.Error.Message;
									errorArgs.ErrorContext.Handled = true;
								}
							});

						this.Store = store;
					},
					(message) =>{},
					showHud:true
				);
			}
		}

		/// <summary>
		/// 开始Property监听
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		// 添加一个触发 PropertyChanged 事件的通用方法
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
	}

	/// <summary>
	/// view pager 适配器
	/// </summary>
	public class MenuPagerAdapter: Android.Support.V4.App.FragmentStatePagerAdapter{
		StoreIndexActivity activity;
		public MenuPagerAdapter(Android.Support.V4.App.FragmentManager fm, StoreIndexActivity activity): base(fm){
			this.activity = activity;
		}

		public override Android.Support.V4.App.Fragment GetItem (int position){
			FragmentForMenuListView fragment = new FragmentForMenuListView();
			fragment.menuList = (from product in activity.Store.Products
					where product.Category.Equals(this.titleForPosition(position))
				select product).ToList<ProductModel>();
			return fragment;
		}

		public override int GetItemPosition(Java.Lang.Object objectValue)
		{
				return PositionNone;
		}

		public override int Count{
			get{ 
				var categories = activity.Store.Products
					.Select (model => model.Category)
					.Distinct ().ToList<string>();
				return categories.Count;
			}
		}

		private string titleForPosition(int position){
			var categories = activity.Store.Products
				.Select (model => model.Category)
				.Distinct ().ToList<string>();
			if (categories.Count < 1)
				return "没有数据";
			return categories[position];
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position){
			
			return CharSequence.ArrayFromStringArray(new string[]{titleForPosition(position)})[0];
		}

	}
		
	/// <summary>
	/// fragment类型
	/// </summary>
	public class FragmentForMenuListView: Android.Support.V4.App.Fragment{

		public List<ProductModel> menuList;

		private Android.Widget.ListView menuListView;

		public FragmentForMenuListView(): base(){
			
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.store_menu_listview_fragment, container, false);
			menuListView = view.FindViewById<Android.Widget.ListView> (Resource.Id.menu_listview);
			menuListView.Adapter = new ProductListViewAdapter(this.Activity, menuList);
			menuListView.ItemClick += (sender, arg) => {
				Intent intent = new Intent(this.Activity, typeof(ProductDetailActivity));
				intent.PutExtra("product_id", ((ProductListViewAdapter)(menuListView.Adapter))[arg.Position].Id);
				this.Activity.StartActivity(intent);
			};
			return view;
		}
	}

	public class ProductListViewAdapter : BaseAdapter<ProductModel> {
		List<ProductModel> ProductList;
		Activity context;
		public ProductListViewAdapter(Activity context, List<ProductModel> items) : base() {
			this.context = context;
			this.ProductList = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override ProductModel this[int position] {  
			get { return ProductList[position]; }
		}
		public override int Count {
			get { return ProductList.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.StoreMenuListViewCell, null);
			ProductModel product = this [position];
			StoreMenuListViewCell cell = view as StoreMenuListViewCell;
			if (cell != null) {
				cell.Product = product;
			}
			return view;
		}
	}


}

