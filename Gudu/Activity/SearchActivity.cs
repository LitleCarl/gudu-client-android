
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
using Gudu.Morning.Sectionlistview;
using GuduCommon;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reactive.Linq;
using Gudu.CustomView;
using Android.Content.PM;

namespace Gudu
{
	[Activity (Label = "SearchActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class SearchActivity : Activity
	{
		private ImageButton _backButton;
		private PinnedSectionListView _listview;
		private EditText _searchTextField;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.search_activity);
			// Create your application here
			initUI ();
			setUpTrigger ();
		}
		void initUI(){
			_searchTextField = FindViewById<EditText> (Resource.Id.search_edittext);
			_listview = FindViewById<PinnedSectionListView> (Resource.Id.section_listview);
			_backButton = FindViewById<ImageButton> (Resource.Id.back_button);
		}
		void setUpTrigger(){
			_listview.Adapter = new SearchResultAdapter (this);
			_searchTextField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				var adapter = _listview.Adapter as SearchResultAdapter;
				if (adapter != null){
					adapter.FetchData(_searchTextField.Text);
				}
			};
			_backButton.Click += (object sender, EventArgs e) => {
				this.Finish();
			};

			_listview.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				int position = e.Position;
				SearchResultAdapter adapter = this._listview.Adapter as SearchResultAdapter;
				if (adapter != null){
					int viewType = adapter.GetItemViewType(position) ;
					if (viewType == 1){
						// 进店铺
						Intent intent = new Intent(this, typeof(StoreIndexActivity));
						StoreModel model = adapter[position] as StoreModel;
						if (model != null){
							intent.PutExtra("store_id", model.Id);
							StartActivity(intent);
						}

					}
					else if (viewType == 2){
						// 进商品
						Intent intent = new Intent(this, typeof(ProductDetailActivity));
						ProductModel model = adapter[position] as ProductModel;
						if (model != null){
							intent.PutExtra("product_id", model.Id);
							this.StartActivity(intent);
						}

					}
				}
			};
		}
	}

	public class SearchResultAdapter : BaseAdapter<Object>, Gudu.Morning.Sectionlistview.PinnedSectionListView.IPinnedSectionListAdapter, INotifyPropertyChanged {
		int storeNum; //返回店铺数量
		int productNum; //返回商品数量
		IObservable<string> signal;

		private List<Object> searchResult;
		public List<Object> SearchResult {
			get { 
				return searchResult;
			}
			set { SetField(ref searchResult, value); }
		}

		Activity context;
		public SearchResultAdapter(Activity context) : base() {
			this.context = context;
			SetUpTrigger ();
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public bool IsItemViewTypePinned (int p0){
			if (this.GetItemViewType (p0) == 0) {
				return true;
			} else {
				return false;
			}
		}
		public override Object this[int position] {  
			get { return SearchResult[position]; }
		}
		public override int Count {
			get { 
				return SearchResult.Count;
			}
		}

		void SetUpTrigger(){
			this.SearchResult = new List<Object> ();
			this.FromMyEvent<List<Object>> ("SearchResult").Subscribe (
				(result) => {
					if (result != null){
						this.context.RunOnUiThread(
							() => {
								Console.WriteLine("当前的list:{0}", searchResult);
								this.NotifyDataSetChanged();
							}
						);
					}
				}
			);
		}

		public void FetchData(String searchString){
			signal = System.Reactive.Linq.Observable.Create<IObservable<string>>((obs) =>
					{
						Dictionary<String, Object> param = new Dictionary<String, Object>();
						param.Add ("keyword", searchString);
						param.Add ("campus_id", Tool.StringForKey(SPConstant.SelectCampusIdKeyInSharedPreference));
						Tool.Get (URLConstant.kBaseUrl, URLConstant.kSearchUrl, param, this.context,
							(responseObject) => {
								var newSignal = System.Reactive.Linq.Observable.Create<string>((newObs) =>{
									newObs.OnNext(responseObject);
									return () => {};
								});
								obs.OnNext(newSignal);
							},
							(exception) => {

							},
							showHud: false);
						return () => {};
					}).Switch<String>();
			signal.Subscribe (
				(responseObject)=>{
					this.context.RunOnUiThread(
						() => {
							Console.WriteLine("响应了一次");
							if (Tool.CheckStatusCode(responseObject)){
								var data = JObject.Parse(responseObject).SelectToken("data");
								List<StoreModel> stores = JsonConvert.DeserializeObject<List<StoreModel>>(data.SelectToken("stores").ToString(), new JsonSerializerSettings
									{
										Error = (sender,errorArgs) =>
										{
											var currentError = errorArgs.ErrorContext.Error.Message;
											errorArgs.ErrorContext.Handled = true;
										}}
								);
								storeNum = (stores != null)? stores.Count : 0;

								List<ProductModel> products = JsonConvert.DeserializeObject<List<ProductModel>>(data.SelectToken("products").ToString(), new JsonSerializerSettings
									{
										Error = (sender,errorArgs) =>
										{
											var currentError = errorArgs.ErrorContext.Error.Message;
											errorArgs.ErrorContext.Handled = true;
										}}
								);
								productNum = (products != null)? products.Count : 0;

								var list = new List<Object>();

								if (storeNum > 0){
									SectionHeader header = new SectionHeader{
										headerTitle = string.Format( "店铺({0})", storeNum)
									};
									list.Add(header);
									list.AddRange(stores);

								}

								if (productNum > 0){
									SectionHeader header = new SectionHeader{
										headerTitle = string.Format( "商品({0})", productNum)
									};
									list.Add(header);
									list.AddRange(products);

								}

								SearchResult = list;
							}
						}
					);

				}
			);

			
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			int viewType = this.GetItemViewType (position);
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) { // otherwise create a new one
				if (viewType == 0) {
					view = context.LayoutInflater.Inflate (Resource.Layout.search_section_header, parent, false);
				} else if (viewType == 1) {
					view = context.LayoutInflater.Inflate (Resource.Layout.StoreListCell, parent, false);
				} else if (viewType == 2) {
					view = context.LayoutInflater.Inflate (Resource.Layout.StoreMenuListViewCell, parent, false);
				}

			}


			if (viewType == 0) {
				SectionHeader header = this [position] as SectionHeader;
				if (header != null) {
					view.FindViewById<TextView> (Resource.Id.textView1).Text = header.headerTitle;
				}
			} else if (viewType == 1) {
				StoreModel model = this [position] as StoreModel;
				StoreListViewCell cell = view as StoreListViewCell;
				if (model != null && cell != null) {
					cell.Store = model;
				}
			} else if (viewType == 2){
				ProductModel model = this [position] as ProductModel;

				StoreMenuListViewCell cell = view as StoreMenuListViewCell;
				if (cell != null) {
					cell.Product = model;
				}
			
			}
//			Object store = this [position];
//
//			view.FindViewById<TextView>(Resource.Id.store_name_textview_id).Text = store.Name;
//			view.FindViewById<TextView>(Resource.Id.store_brief_textview_id).Text = store.Brief;
//
//			Picasso.With(context).Load(store.Logo_filename).Into(view.FindViewById<ImageView>(Resource.Id.store_logo_image));
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
		 //PropertyChanged结束

		public override int ViewTypeCount {
			get {
				return 3;
			}
		}

		// header->0
		// 商铺cell->1
		// 商品cell->2
		public override int GetItemViewType (int position)
		{
			if (position == 0) {
				return 0;
			} else if (storeNum > 0 && position <= storeNum) {
				return 1;
			} else if (position == (storeNum + 1) && storeNum != 0) {
				return 0;
			} else {
				return 2;
			}

		}

	}

	class SectionHeader{
		public String headerTitle;
		public SectionHeader(){
			
		}
	}

}

