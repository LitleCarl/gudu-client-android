
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

namespace Gudu
{
	[Activity (Label = "StoreIndexActivity")]			
	public class StoreIndexActivity : FragmentActivity, INotifyPropertyChanged
	{
		private ViewPager viewPager;

		private String store_id;
		public String Store_id {
			get { 
				return store_id;
			}
			set { SetField(ref store_id, value); }
		}

		private List<ProductModel> modelList;
		public List<ProductModel> ModelList {
			get{
				return modelList;
			}
			set { SetField(ref modelList, value); }
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.store_index_activity);
			if (this.Intent.Extras != null && this.Intent.Extras.GetString ("store_id") != null) {
				this.Store_id = this.Intent.Extras.GetString ("store_id");
			}
			initUI ();
			setUpTrigger ();
		}	
		void initUI(){
			this.ModelList = new List<ProductModel>();
			TabPageIndicator tab_indicator = FindViewById<TabPageIndicator>(Resource.Id.tab_indicator);
			viewPager = FindViewById<Android.Support.V4.View.ViewPager> (Resource.Id.menuViewPager);
			viewPager.Adapter = new MenuPagerAdapter(SupportFragmentManager, this);
			tab_indicator.SetViewPager (viewPager);
		}

		void setUpTrigger (){
			this.FromMyEvent<string> ("Store_id").Subscribe (
				(store_id) => {
					fetchData ();
				}
			);
			this.FromMyEvent<List<ProductModel>> ("ModelList").Subscribe (
				(productList) => {
					viewPager.Adapter.NotifyDataSetChanged();
				}
			);
		}

		void fetchData (){
			if (this.Store_id != null) {
				string url = Tool.BuildUrl (URLConstant.kBaseUrl, URLConstant.kStoreFindOneUrl.Replace(":store_id",this.Store_id), null);
				Tool.Get (
					url,
					null,
					this,
					(string responseObject) => {
						var productsPart = JObject.Parse(responseObject).SelectToken("data").SelectToken("products").ToString();
						List<ProductModel> list = JsonConvert.DeserializeObject<List<ProductModel>>(productsPart, new JsonSerializerSettings
							{
								Error = (sender,errorArgs) =>
								{
									var currentError = errorArgs.ErrorContext.Error.Message;
									errorArgs.ErrorContext.Handled = true;
								}
							});

						this.ModelList = list;
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
			fragment.productList = (from product in activity.ModelList
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
				var categories = activity.ModelList
					.Select (model => model.Category)
					.Distinct ().ToList<string>();
				return categories.Count;
			}
		}

		private string titleForPosition(int position){
			var categories = activity.ModelList
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

		public List<ProductModel> productList;

		private Android.Widget.ListView menuListView;

		public FragmentForMenuListView(): base(){
			
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.store_menu_listview_fragment, container, false);
			menuListView = view.FindViewById<Android.Widget.ListView> (Resource.Id.menu_listview);
			menuListView.Adapter = new ProductListViewAdapter(this.Activity, productList);
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
			view.FindViewById<Android.Widget.TextView>(Resource.Id.product_name_textview).Text = product.Name;
			view.FindViewById<Android.Widget.TextView>(Resource.Id.price_textview).Text = String.Format("¥{0}~{1}",product.Min_price, product.Max_price) ;
			Picasso.With(context).Load(product.Logo_filename).Into(view.FindViewById<ImageView>(Resource.Id.product_logo_image));
			return view;
		}
	}


}

