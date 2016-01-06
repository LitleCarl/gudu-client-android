
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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Android.Content.PM;

namespace Gudu
{
	[Activity (Label = "选择学校", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class SelectCampusActivity : Activity, INotifyPropertyChanged
	{
		ListView campusListView;

		List<CampusModel> campusList;
		public List<CampusModel> CampusList{
			get{ return campusList;}
			set { SetField(ref campusList, value); }
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
		//----------------------- PropertyChanged结束

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//RequestWindowFeature (WindowFeatures.NoTitle);
			SetContentView (Resource.Layout.select_campus_activity);
			// Create your application here
			initUI ();
			setUpTrigger ();
			fetchData ();
		}

		void initUI(){
			campusListView = FindViewById<ListView> (Resource.Id.campus_listview);
		}

		void setUpTrigger(){
			// 监听StoreList变化
			this.FromMyEvent<List<CampusModel>>("CampusList").Subscribe (
				(args) => {
					this.RunOnUiThread(
						()=>{
							if (args != null){
								campusListView.Adapter = new CampusListViewAdapter(this, args);
								campusListView.DeferNotifyDataSetChanged();
							}

						}
					);
				
				}
			);

			//选择了学校
			campusListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

				CampusListViewAdapter adapter = this.campusListView.Adapter as CampusListViewAdapter;
				if (adapter != null){
					var selectModel = adapter.items[e.Position] as CampusModel;
					if (selectModel.Id != null){
						if (Tool.StringForKey(SPConstant.SelectCampusIdKeyInSharedPreference) != null && Tool.StringForKey(SPConstant.SelectCampusIdKeyInSharedPreference) != selectModel.Id){
							//清空购物车
							CartItem.clearCart();
						}
						Tool.SetStringForKey(SPConstant.SelectCampusIdKeyInSharedPreference, selectModel.Id);
					}
				}


				Finish();
			};
		}

		void fetchData(){
			Tool.Get (URLConstant.kBaseUrl, URLConstant.kCampusUrl, null, this,
				(responseObject) => {
					if (Tool.CheckStatusCode(responseObject)){
						var storePart = JObject.Parse(responseObject).SelectToken("data").SelectToken("campuses").ToString();
						var unKnownPart = JObject.Parse(responseObject).SelectToken("dataaa");
						Console.WriteLine("-------未知part{0}--------", unKnownPart);
						Console.WriteLine("-------未知part = null{0}--------", unKnownPart == null);

						CampusList = JsonConvert.DeserializeObject<List<CampusModel>>(storePart, new JsonSerializerSettings
							{
								Error = (sender,errorArgs) =>
								{
									var currentError = errorArgs.ErrorContext.Error.Message;
									errorArgs.ErrorContext.Handled = true;
								}
							});
					}
					else
					{
						Console.WriteLine("状态码出错");
					}
				},
				(exception) => {
					Console.WriteLine("请求错误:{0}", exception.Message);
				}
			);
		}
	}


	public class CampusListViewAdapter : BaseAdapter<Object>, Gudu.Morning.Sectionlistview.PinnedSectionListView.IPinnedSectionListAdapter, INotifyPropertyChanged {
		public List<Object> items;
		Activity context;

		enum ItemType{
			HeaderType = 0,
			CampusType = 1,
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

		public CampusListViewAdapter(Activity context, List<CampusModel> campuses) : base() {
			this.context = context;

			if (campuses == null) {
				items = new List<Object> ();
			}
			else {
				items = new List<Object> ();


				var result = campuses.OrderBy(
					x => x.First_letter
					).GroupBy (
					x => x.First_letter
					).Select(
					(grp) => {

						var letter = "#";
						var firstObj = grp.ToList<CampusModel>().First<CampusModel>();
						if (firstObj != null){
							letter = firstObj.First_letter;
						}
						items.Add(letter);

						items.AddRange(grp.ToList());

						return letter;
					}
				).ToList();

			}

		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public bool IsItemViewTypePinned (int p0){
			if (this.GetItemViewType (p0) == (int)(ItemType.HeaderType)) {
				return true;
			} else {
				return false;
			}
		}
		public override Object this[int position] {  
			get { return items[position]; }
		}
		public override int Count {
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			int viewType = this.GetItemViewType (position);
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) { // otherwise create a new one
				if (viewType == (int)(ItemType.HeaderType)) {
					view = context.LayoutInflater.Inflate (Resource.Layout.search_section_header, parent, false);
				} 
				else {
					view = context.LayoutInflater.Inflate (Resource.Layout.CampusListCell, parent, false);
				} 

			}


			if (viewType == (int)(ItemType.HeaderType)) {
				string header = this[position] as string;
				if (header != null) {
					view.FindViewById<TextView> (Resource.Id.textView1).Text = header;
				}
			} 
			else{
				CampusModel campus = this [position] as CampusModel;
				if (campus != null){
					view.FindViewById<TextView>(Resource.Id.campus_name_textview).Text = campus.Name;
					view.FindViewById<TextView>(Resource.Id.campus_address_textview).Text = campus.Address;
				}

			} 

			return view;

		}

		public override int ViewTypeCount {
			get {
				return 2;
			}
		}

		// header->0
		// 商铺cell->1
		// 商品cell->2
		public override int GetItemViewType (int position)
		{
			var obj = this [position];
			if (obj is CampusModel) {
				return (int)(ItemType.CampusType);
			} else {
				return (int)(ItemType.HeaderType);
			}

		}

	}
}

