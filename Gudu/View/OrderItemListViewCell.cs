
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

namespace Gudu.CustomView
{
	public class OrderItemListViewCell : RelativeLayout, INotifyPropertyChanged
	{
		private Context _myContext;
		private TextView _orderItemNameTextView;
		private TextView _orderItemPerPriceTextView;
		private TextView _orderItemQuantityTextView;
		private ImageView _orderItemImageView;
		private TextView _orderItemCategoryTextView;

		private OrderItemModel orderItem;
		public OrderItemModel OrderItem {
			get{
				return orderItem;
			}
			set { SetField(ref orderItem, value); }
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

		public OrderItemListViewCell (Context context) :
			base (context)
		{
			Initialize (context);
		}

		public OrderItemListViewCell (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize (context);
		}

		public OrderItemListViewCell (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize (context);
		}

		void Initialize (Context context)
		{
			this._myContext = context;
			setUpTrigger ();
		}

		protected override void OnFinishInflate(){
			base.OnFinishInflate ();
			_orderItemPerPriceTextView = FindViewById<TextView>(Resource.Id.order_item_per_price_textview);
			_orderItemImageView = FindViewById<ImageView>(Resource.Id.order_item_product_imageview);
			_orderItemNameTextView = FindViewById<TextView>(Resource.Id.order_item_name_textview);
			_orderItemQuantityTextView = FindViewById<TextView> (Resource.Id.order_item_quantity_textview);
			_orderItemCategoryTextView = FindViewById<TextView> (Resource.Id.order_item_category_textview);
		}
		void setUpTrigger(){
			this.FromMyEvent<OrderItemModel> ("OrderItem").Subscribe (
				(orderItemModel) => {
					if (orderItemModel != null){
						using (var h = new Handler (Looper.MainLooper)){
							h.Post(
								()=>{
									_orderItemCategoryTextView.Text = String.Format("{0}:{1}", orderItemModel.Specification.Name, orderItemModel.Specification.SpecificationValue);
									Picasso.With(_myContext).Load(orderItemModel.Product.Logo_filename).Into(_orderItemImageView);
									_orderItemNameTextView.Text = orderItemModel.Product.Name;
									_orderItemPerPriceTextView.Text = String.Format("¥{0}", orderItemModel.Price_snapshot);
									_orderItemQuantityTextView.Text = String.Format("x{0}", orderItemModel.Quantity);
								}
							);
						}
					}
				}
			);
		}
	}
}

