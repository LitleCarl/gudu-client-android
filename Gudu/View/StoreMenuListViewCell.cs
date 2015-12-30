using System;
using Android.Widget;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using GuduCommon;
using Android.Content;
using Android.Util;
using Android.OS;
using Squareup.Picasso;

namespace Gudu.CustomView
{
	public class StoreMenuListViewCell : RelativeLayout, INotifyPropertyChanged
	{
		private TextView _productNameTextView;
		private TextView _priceTextView;
		private ImageView _productLogoImageView;
		private Context _context;
		private TextView _productMonthSaleTextView;

		private ProductModel product;
		public ProductModel Product{
			get { 
				return product;
			}
			set { SetField(ref product, value); }
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
			_productNameTextView = this.FindViewById<TextView> (Resource.Id.product_name_textview);
			_priceTextView = this.FindViewById<TextView> (Resource.Id.price_textview);
			_productLogoImageView = this.FindViewById<ImageView> (Resource.Id.product_logo_image);
			_productMonthSaleTextView = this.FindViewById<TextView> (Resource.Id.month_sale_textview);

		}

		public StoreMenuListViewCell (Context context) :
		base (context)
		{
			_context = context;
			Initialize ();
		}

		public StoreMenuListViewCell (Context context, IAttributeSet attrs) :
		base (context, attrs)
		{
			_context = context;

			Initialize ();
		}

		public StoreMenuListViewCell (Context context, IAttributeSet attrs, int defStyle) :
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
			this.FromMyEvent<ProductModel> ("Product").Subscribe (
				(product) => {
					if (product != null){
						using (var h = new Handler (Looper.MainLooper)){
							h.Post(
								()=>{
									_productMonthSaleTextView.Text = String.Format("月售:{0}", product.Month_sale);
									_productNameTextView.Text = product.Name;
									_priceTextView.Text = String.Format("¥{0}~{1}",product.Min_price, product.Max_price) ;
									Picasso.With(_context).Load(product.Logo_filename).Into(_productLogoImageView);
								}
							);
						}
					}
				}
			);
		}
	}
}

