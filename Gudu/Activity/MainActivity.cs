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
	[Activity (Label = "早餐巴士", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity, INotifyPropertyChanged
	{
		// View Outlets
		PullToRefresharp.Android.Widget.ListView storeListView;
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
//			RequestWindowFeature (WindowFeatures.ActionBar);

			SetContentView (Resource.Layout.Main);
			initUI ();
			setUpTrigger ();
		}

		/// <summary>
		/// 初始化ui
		/// </summary>
		private void initUI() {
			storeListView = FindViewById<PullToRefresharp.Android.Widget.ListView> (Resource.Id.store_listview);
			campusNameTextView = FindViewById<TextView> (Resource.Id.campus_name_textview);
		}



		private void setUpTrigger(){
			StoreList = new List<StoreModel> ();
			this.FindViewById<ImageButton> (Resource.Id.search_button).Click += (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(SearchActivity)));
			};;
			// 监听StoreList变化
			this.FromMyEvent<object>("StoreList").Subscribe (
				(args) => {
					this.RunOnUiThread(
						() => {
							Console.WriteLine("list:count{0}", args);
							storeListView.Adapter = new StoreListViewAdapter(this, (List<StoreModel>)args);
						}
					);

				}
			);

			storeListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				Intent intent = new Intent(this, typeof(StoreIndexActivity));
				StoreModel model = ((StoreListViewAdapter)(storeListView.Adapter))[e.Position];
				intent.PutExtra("store_id", model.Id);
				StartActivity(intent);
			};

			//监听shared preference变化
			var signal = SharedPreferenceSignal<String>.rac_listen_for_key<String>(SPConstant.SelectCampusIdKeyInSharedPreference);
			signal.Subscribe (
				(campus_id) =>
				{
					if (campus_id == null){
						new Handler ().PostDelayed (
							() => {
								StartActivity(new Intent(this, typeof(SelectCampusActivity)));
							}, 500
						);
					}
					else{
						fetchData(campus_id);
					}
				}
			);

			storeListView.RefreshActivated += (object sender, EventArgs e) => {
				this.fetchData(Tool.StringForKey(SPConstant.SelectCampusIdKeyInSharedPreference));
			};

			// 切换学校
			FindViewById<Button>(Resource.Id.toggle_campus_button).Click += (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(SelectCampusActivity)));
			};

			FindViewById<ImageButton> (Resource.Id.random_recommend_button).Click += (object sender, EventArgs e) => {
				var param = new Dictionary<string, object> ();
				param.Add ("campus_id", Tool.StringForKey(SPConstant.SelectCampusIdKeyInSharedPreference));


				Tool.Get (URLConstant.kBaseUrl, URLConstant.kRandomRecommendUrl, param, this,
					(responseObject) => {
						this.RunOnUiThread(
							() => {
								var rootView = FindViewById<ViewGroup>(Android.Resource.Id.Content);
								View contentView = this.LayoutInflater.Inflate (Resource.Layout.cardview_activity, rootView, false);
								AlertDialog.Builder builder = new AlertDialog.Builder(this);
								builder.SetView(contentView);
								Dialog alertDialog = builder.Create();
								alertDialog.RequestWindowFeature((int)(WindowFeatures.NoTitle));
								alertDialog.Show();
								alertDialog.Window.SetLayout((int)DeviceInfo.dp2px(this, DeviceInfo.kScreenWidth(this) * 0.8f), (int)DeviceInfo.dp2px(this, DeviceInfo.kScreenHeight(this) * 0.7f)); //Controlling width and height.
								alertDialog.SetCanceledOnTouchOutside(true);

								if (Tool.CheckStatusCode(responseObject)){
									var storePart = JObject.Parse(responseObject).SelectToken("data").SelectToken("store").ToString();


									var store = JsonConvert.DeserializeObject<StoreModel>(storePart, new JsonSerializerSettings
										{
											Error = (sender_clone,errorArgs) =>
											{
												var currentError = errorArgs.ErrorContext.Error.Message;
												errorArgs.ErrorContext.Handled = true;
											}}
									);
									contentView.FindViewById<TextView>(Resource.Id.store_signature_textview).Text = store.Signature;
									contentView.FindViewById<TextView>(Resource.Id.back_ratio_textview).Text = String.Format("{0}%", (int)(store.Back_ratio * 100));
									contentView.FindViewById<TextView>(Resource.Id.month_sale_textview).Text = store.Month_sale;
									contentView.FindViewById<TextView>(Resource.Id.store_name_textview).Text = store.Name;
									contentView.FindViewById<TextView>(Resource.Id.store_signature_textview).Text = store.Signature;
									Picasso.With(this).Load(store.Logo_filename).Into(contentView.FindViewById<ImageView>(Resource.Id.logo_imageview));
									contentView.FindViewById<Button>(Resource.Id.enter_store_button).Click += (object obj, EventArgs evt) => {
										Intent intent = new Intent(this, typeof(StoreIndexActivity));
										intent.PutExtra("store_id", store.Id);
										StartActivity(intent);
									};

								}
							}
						);

					},
					(exception) => {

					});
			};
		}
			
		private void fetchData(string campus_id){
			Tool.Get (URLConstant.kBaseUrl, URLConstant.kStoresInCampusUrl.Replace(":campus_id", campus_id), null, this, 
				(responseObject) => {
					this.RunOnUiThread(
						() => {
							storeListView.OnRefreshCompleted();
							if (Tool.CheckStatusCode(responseObject)){
								var storesPart = JObject.Parse(responseObject).SelectToken("data").SelectToken("stores").ToString();

								StoreList = JsonConvert.DeserializeObject<List<StoreModel>>(storesPart, new JsonSerializerSettings
									{
										Error = (sender,errorArgs) =>
										{
											var currentError = errorArgs.ErrorContext.Error.Message;
											errorArgs.ErrorContext.Handled = true;
										}}
								);

							}
							else
							{
								Console.WriteLine("状态码出错");
							}
						}
					);
				},
				(exception) => {
					Console.WriteLine("请求错误:{0}", exception.Message);
				}
			);
			Tool.Get (URLConstant.kBaseUrl, URLConstant.kCampusFindOneUrl.Replace(":campus_id", campus_id), null, this,
				(responseObject) => {
					this.RunOnUiThread(
						() => {
							if (Tool.CheckStatusCode(responseObject)){
								var campusPart = JObject.Parse(responseObject).SelectToken("data").SelectToken("campus");
								campusNameTextView.Text = campusPart.SelectToken("name").Value<String>();

							}
							else
							{
								Console.WriteLine("状态码出错");
							}
						}
					);

				},
				(exception) => {
					Console.WriteLine("请求错误:{0}", exception.Message);
				}
			);
		}

		bool doubleBackToExitPressedOnce = false;
		public override void OnBackPressed ()
		{
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
			StoreListViewCell cell = view as StoreListViewCell;
			if (cell != null) {
				cell.Store = store;
			}

			return view;
		}
	}
}
	
