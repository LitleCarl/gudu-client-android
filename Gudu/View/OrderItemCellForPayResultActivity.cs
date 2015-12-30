
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
using Android.Util;
using System.Runtime.CompilerServices;
using Android.Graphics;

namespace Gudu.CustomView
{
	[Activity (Label = "OrderItemCellForPayResultActivity")]			
	public class OrderItemCellForPayResultActivity : LinearLayout, INotifyPropertyChanged
	{
		private Context _myContext;
		private TextView _productNameTextView;
		private TextView _quantityTextView;
		private TextView _priceTextView;

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

		public OrderItemCellForPayResultActivity (Context context) :
		base (context)
		{
			Initialize (context);
		}

		public OrderItemCellForPayResultActivity (Context context, IAttributeSet attrs) :
		base (context, attrs)
		{
			Initialize (context);
		}

		public OrderItemCellForPayResultActivity (Context context, IAttributeSet attrs, int defStyle) :
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
			_productNameTextView = FindViewById<TextView>(Resource.Id.product_name_textview);
			_quantityTextView = FindViewById<TextView> (Resource.Id.quantity_textview);
			_priceTextView = FindViewById<TextView> (Resource.Id.price_textview);
		}
		void setUpTrigger(){
			this.FromMyEvent<OrderItemModel> ("OrderItem").Subscribe (
				(orderItemModel) => {
					if (orderItemModel != null){
						using (var h = new Handler (Looper.MainLooper)){
							h.Post(
								()=>{
									_productNameTextView.Text = orderItem.Product.Name;
									_priceTextView.Text = string.Format("¥{0}", orderItem.Price_snapshot);
									_quantityTextView.Text = string.Format("x{0}", orderItem.Quantity);
								}
							);
						}
					}
				}
			);
		}
	}
}

