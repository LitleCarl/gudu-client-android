using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GuduCommon;
using Gudu;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Squareup.Picasso;
using Android.Preferences;

namespace Gudu
{
	[Activity (Label = "咕嘟早餐")]
	public class MainActivity : Activity, INotifyPropertyChanged
	{
		// View Outlets
		ListView storeListView;
		TextView campusNameTextView;

		List<StoreModel> storeList;
		public List<StoreModel> StoreList{
			get{ return storeList;}
			set { SetField(ref storeList, value); }
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
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			initUI ();
			setUpTrigger ();
		}

		/// <summary>
		/// 初始化ui
		/// </summary>
		private void initUI() {
			storeListView = FindViewById<ListView> (Resource.Id.store_listview);
			campusNameTextView = FindViewById<TextView> (Resource.Id.campus_name_textview);
		}



		private void setUpTrigger(){
			StoreList = new List<StoreModel> ();

			// 监听StoreList变化
			this.FromMyEvent<object>("StoreList").Subscribe (
				(args) => {
					storeListView.Adapter = new StoreListViewAdapter(this, (List<StoreModel>)args);
					storeListView.DeferNotifyDataSetChanged();
				}
			);

			storeListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				StartActivity(new Intent(this, typeof(StoreIndexActivity)));
			};

			//监听shared preference变化
			var signal = SharedPreferenceSignal<String>.rac_listen_for_key<String>(SPConstant.SelectCampusIdKeyInSharedPreference);
			signal.Subscribe (
				(campus_id) =>
				{
					if (campus_id == null){
						StartActivity(new Intent(this, typeof(SelectCampusActivity)));
					}
					else{
						fetchData(campus_id);
					}
				}
			);
				
		}

		private void fetchData(string campus_id){
			Tool.Get ("https://gudu-sails.tunnel.mobi/campus/"+campus_id, null, this,
				(responseObject) => {
					if (Tool.CheckStatusCode(responseObject)){
						var campusPart = JObject.Parse(responseObject).SelectToken("data");
						campusNameTextView.Text = campusPart.SelectToken("name").Value<String>();

						var storePart = campusPart.SelectToken("stores").ToString();
						StoreList = JsonConvert.DeserializeObject<List<StoreModel>>(storePart, new JsonSerializerSettings
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


	public class StoreListViewAdapter : BaseAdapter<StoreModel> {
		List<StoreModel> StoreList;
		Activity context;
		public StoreListViewAdapter(Activity context, List<StoreModel> items) : base() {
			this.context = context;
			this.StoreList = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override StoreModel this[int position] {  
			get { return StoreList[position]; }
		}
		public override int Count {
			get { return StoreList.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.StoreListCell, null);
			StoreModel store = this [position];

			view.FindViewById<TextView>(Resource.Id.store_name_textview_id).Text = store.Name;
			view.FindViewById<TextView>(Resource.Id.store_brief_textview_id).Text = store.Brief;

			Picasso.With(context).Load(store.Logo_filename).Into(view.FindViewById<ImageView>(Resource.Id.store_logo_image));
			return view;
		}
	}
}
	
