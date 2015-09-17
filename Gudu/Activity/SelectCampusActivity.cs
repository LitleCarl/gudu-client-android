
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

namespace Gudu
{
	[Activity (Label = "选择学校")]			
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
			RequestWindowFeature (WindowFeatures.NoTitle);
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
					campusListView.Adapter = new CampusListViewAdapter(this, (List<CampusModel>)args);
					campusListView.DeferNotifyDataSetChanged();
				}
			);

			//选择了学校
			campusListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				CampusModel selectModel = CampusList[e.Position];
						Tool.SetStringForKey(SPConstant.SelectCampusIdKeyInSharedPreference, selectModel.Id);
				Finish();
			};
		}

		void fetchData(){
			Tool.Get ("https://gudu-sails.tunnel.mobi/campus", null, this,
				(responseObject) => {
					if (Tool.CheckStatusCode(responseObject)){
						var storePart = JObject.Parse(responseObject).SelectToken("data").ToString();
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


	public class CampusListViewAdapter : BaseAdapter<CampusModel> {
		List<CampusModel> campusList;
		Activity context;
		public CampusListViewAdapter(Activity context, List<CampusModel> items) : base() {
			this.context = context;
			this.campusList = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override CampusModel this[int position] {  
			get { return campusList[position]; }
		}
		public override int Count {
			get { return campusList.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.CampusListCell, null);
			CampusModel campus = this [position];
			view.FindViewById<TextView>(Resource.Id.campus_name_textview).Text = campus.Name;
			view.FindViewById<TextView>(Resource.Id.campus_address_textview).Text = campus.Address;
			//view.FindViewById<TextView>(Resource.Id.store_brief_textview_id).Text = store.Brief;

			return view;
		}
	}
}

