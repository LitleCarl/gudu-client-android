using System;
using Android.Widget;
using Android.Content;
using Android.Util;

namespace Gudu.CustomView
{
	public class HeightWidthHorizontalScrollView : HorizontalScrollView
	{
		public HeightWidthHorizontalScrollView(Context context) : base(context){
		}

		public HeightWidthHorizontalScrollView(Context context, IAttributeSet attrs): base(context, attrs) {
		}

		public HeightWidthHorizontalScrollView(Context context, IAttributeSet attrs, int defStyle): base(context,attrs, defStyle) {
		}

		protected override void OnMeasure(int widthSpec, int heightSpec) {
			base.OnMeasure(widthSpec, heightSpec);
			int size = this.MeasuredWidth;
			SetMeasuredDimension(size, size);
		}
	}
}

