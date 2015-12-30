
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
using Android.Content.PM;

namespace Gudu
{
	[Activity (Label = "AddressManagementActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class AddressManagementActivity : BackButtonActivity
	{
		private ListView _addressListView;
		private Button _addAddressButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.address_manage_activity);
			initUI ();
			setUpTrigger ();
			// Create your application here
		}
		void initUI(){
			_addressListView = FindViewById<ListView> (Resource.Id.address_listview);
			_addAddressButton = FindViewById<Button> (Resource.Id.add_address_button);
		}
		void setUpTrigger(){
			var emptyView = this.LayoutInflater.Inflate (Resource.Layout.address_listview_emptyview, null);
			AddContentView(emptyView, _addressListView.LayoutParameters); 
			_addressListView.EmptyView = emptyView;
			EventHandler addAddressAction = (object sender, EventArgs e) => {
				StartActivity(new Intent(this, typeof(AddAddressActivity)));
			};
			_addressListView.EmptyView.FindViewById<Button> (Resource.Id.add_address_button).Click += addAddressAction;
			_addressListView.Adapter = new AddressManageListViewAdapter (this);
			_addAddressButton.Click += addAddressAction;

			_addressListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				int position = e.Position;
				AddressModel selectAddress = ((AddressManageListViewAdapter)(this._addressListView.Adapter))[position];
				Intent intent = new Intent(this, typeof(EditAddressActivity));
				intent.PutExtra("address_id", selectAddress.Id);
				StartActivity(intent);
			};
		
		}
	}

	public class AddressManageListViewAdapter : BaseAdapter<AddressModel>, INotifyPropertyChanged {
		Activity context;

		private List<AddressModel> addressList;
		public List<AddressModel> AddressList {
			get{
				return addressList;
			}
			set { SetField(ref addressList, value); }
		}

		void setUpTrigger(){
			this.FromMyEvent<List<AddressModel>> ("AddressList").Subscribe (
				(list) => {
					if (list != null){
						context.RunOnUiThread(
							() => {
								this.NotifyDataSetChanged();

							}
						);
					}
				}
			);

			UserSession.sharedInstance ().FromMyEvent<UserModel>("User").Subscribe(
				(user) => {
					this.AddressList = user.Addresses;
				}
			);

		}

		public AddressManageListViewAdapter(Activity context) : base() {
			this.context = context;
			this.AddressList = new List<AddressModel>();
			setUpTrigger ();
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override AddressModel this[int position] {  
			get { return AddressList[position]; }
		}

		public override int Count {
			get { return AddressList.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.address_list_cell_view, null);
			AddressModel address = this [position];
			Console.WriteLine("address count:{0}", AddressList.Count);
			view.FindViewById<TextView>(Resource.Id.name_textview).Text = address.Name;
			view.FindViewById<TextView>(Resource.Id.address_textview).Text = address.Address;
			view.FindViewById<TextView>(Resource.Id.phone_textview).Text = address.Phone;
			if (address.DefaultAddress) {
				view.FindViewById<TextView> (Resource.Id.default_address_indicator).Visibility = ViewStates.Visible;
			} else {
				view.FindViewById<TextView> (Resource.Id.default_address_indicator).Visibility = ViewStates.Gone;
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

