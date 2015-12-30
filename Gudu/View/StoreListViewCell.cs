
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GuduCommon;
using Squareup.Picasso;

namespace Gudu
{
	public class StoreListViewCell : RelativeLayout, INotifyPropertyChanged
	{
		private TextView _storeNameTextView;
		private TextView _briefTextVIew;
		private ImageView _logoView;

		private Context _context;

		private StoreModel store;
		public StoreModel Store {
			get{
				return store;
			}
			set { SetField(ref store, value); }
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

		protected override void OnFinishInflate(){
			base.OnFinishInflate ();
			_storeNameTextView = this.FindViewById<TextView>(Resource.Id.store_name_textview_id);
			_briefTextVIew = this.FindViewById<TextView> (Resource.Id.store_brief_textview_id);
			_logoView = this.FindViewById<ImageView> (Resource.Id.store_logo_image);
		}

		public StoreListViewCell (Context context) :
			base (context)
		{
			_context = context;
			Initialize ();
		}

		public StoreListViewCell (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			_context = context;

			Initialize ();
		}

		public StoreListViewCell (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			_context = context;

			Initialize ();
		}

		void Initialize ()
		{

			setUpTrigger ();
		}

		void setUpTrigger(){
			this.FromMyEvent<StoreModel> ("Store").Subscribe (
				(store) => {
					if (store != null){
						using (var h = new Handler (Looper.MainLooper)){
							h.Post(
								()=>{
									_storeNameTextView.Text = this.Store.Name;
									_briefTextVIew.Text = this.Store.Brief;
									Picasso.With(_context).Load(store.Logo_filename).Into(_logoView);

								}
							);
						}
					}
				}
			);
		}
	}
}

