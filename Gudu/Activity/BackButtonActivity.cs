
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

namespace Gudu
{
	[Activity (Label = "BackButtonActivity")]			
	public class BackButtonActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
		}
		public virtual void SetContentView (int layoutResID){
			base.SetContentView (layoutResID);
			RelativeLayout top_bar = FindViewById<RelativeLayout> (Resource.Id.top_bar);
			ImageButton imgButton = new ImageButton(this);
			RelativeLayout.LayoutParams param = new RelativeLayout.LayoutParams
				((int)DeviceInfo.dp2px(this, 40), (int)DeviceInfo.dp2px(this, 40));
			imgButton.SetBackgroundResource (Resource.Color.transparent);
			param.AddRule(LayoutRules.CenterVertical);
			param.AddRule(LayoutRules.AlignParentLeft);
					imgButton.LayoutParameters = param;
					imgButton.SetImageResource(Resource.Drawable.ic_keyboard_arrow_left_white_48dp);
					top_bar.AddView(imgButton);
			imgButton.Click += (object sender, EventArgs e) => {
				this.Finish();
			};
		}
	}
}

