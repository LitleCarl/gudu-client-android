
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

namespace Gudu.CustomView
{
	public class SelectCouponViewCell : RelativeLayout, INotifyPropertyChanged
	{
		private Context _context;

		private TextView _discountTextView;
		private TextView _leastPriceTextView;
		private TextView _remainingTimeTextView;

		private decimal currentPrice;
		public decimal CurrentPrice {
			get{
				return currentPrice;
			}
			set { SetField(ref currentPrice, value); }
		}

		private CouponModel coupon;
		public CouponModel Coupon {
			get{
				return coupon;
			}
			set { SetField(ref coupon, value); }
		}

		public SelectCouponViewCell (Context context) :
		base (context)
		{
			Initialize (context);
		}

		public SelectCouponViewCell (Context context, IAttributeSet attrs) :
		base (context, attrs)
		{
			Initialize (context);
		}

		public SelectCouponViewCell (Context context, IAttributeSet attrs, int defStyle) :
		base (context, attrs, defStyle)
		{
			Initialize (context);
		}

		void Initialize (Context context)
		{
			_context = context;
		}

		protected override void OnFinishInflate(){
			base.OnFinishInflate ();
			_discountTextView = FindViewById<TextView>(Resource.Id.discount_textview);
			_leastPriceTextView = FindViewById<TextView>(Resource.Id.least_pirce_textview);
			_remainingTimeTextView = FindViewById<TextView>(Resource.Id.remaining_time_textview);
			setUpTrigger ();

		}

		void setUpTrigger(){
			this.FromMyEvent<CouponModel> ("Coupon").Subscribe (
				(coupon) => {
					if (coupon != null){
						_discountTextView.Text = string.Format("￥{0}元", coupon.Discount);
						_leastPriceTextView.Text = string.Format("(最低消费:{0}元)", coupon.Least_price);
						_remainingTimeTextView.Text = coupon.Expired_date;
						if (CurrentPrice >= coupon.Least_price){
							this.FindViewById<RelativeLayout>(Resource.Id.color_background).SetBackgroundResource(Resource.Drawable.coupon_cell_background);
						}
						else{
							this.FindViewById<RelativeLayout>(Resource.Id.color_background).SetBackgroundResource(Resource.Drawable.disable_coupon_cell);
						}
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

