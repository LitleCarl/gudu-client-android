
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
using Android.Graphics;

namespace Gudu.CustomView
{
	public class FullHeightListView : ListView
	{
		private Android.Views.ViewGroup.LayoutParams param;
		private int old_count = 0;

		protected override void OnDraw(Canvas canvas){
			if (this.Count != old_count) {
				old_count = this.Count;
				param = this.LayoutParameters;
				param.Height = this.Count * (old_count > 0 ? GetChildAt (0).Height : 0);
				this.LayoutParameters = param;
			}
			base.OnDraw (canvas);
		}
		public FullHeightListView (Context context) :
			base (context)
		{
			Initialize ();
		}

		public FullHeightListView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public FullHeightListView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
	}
}

