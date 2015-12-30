
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GuduCommon;
using Squareup.Picasso;

namespace Gudu
{
	[Activity (Label = "StoreCardViewController")]			
	public class StoreCardViewController : Activity, INotifyPropertyChanged
	{
		private StoreModel store;
		public StoreModel Store{
			get{ return store;}
			set { SetField(ref store, value); }
		}

		private TextView _signatureView;
		private ImageView _logoImageView;
		private TextView _monthSaleTextView;
		private TextView _backRatioTextView;
		private TextView _mainFoodListTextView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.cardview_activity);
			initUI ();
			setUpTrigger ();
			// Create your application here
		}

		void initUI(){
			_signatureView = FindViewById<TextView> (Resource.Id.store_signature_textview);
			_logoImageView = FindViewById<ImageView> (Resource.Id.logo_imageview);
			_monthSaleTextView = FindViewById<TextView>(Resource.Id.month_sale_textview);
			_backRatioTextView = FindViewById<TextView> (Resource.Id.back_ratio_textview);
			_mainFoodListTextView = FindViewById<TextView> (Resource.Id.main_food_list_textview);
		}

		void setUpTrigger(){
			this.FromMyEvent<StoreModel> ("Store").Subscribe(
				(store) =>{

					if (store != null){
						_signatureView.Text = store.Signature;
						_monthSaleTextView.Text = store.Month_sale;
						_backRatioTextView.Text = String.Format("{0}%", (int)(store.Back_ratio * 100));
						_mainFoodListTextView.Text = store.Main_food_list;
						Picasso.With(this).Load(store.Logo_filename).Into(_logoImageView);

					}

				}

			);
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

