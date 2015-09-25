using System;
using Android.App;


namespace Gudu
{
	public class ActivityAnimator
	{
		public void flipHorizontalAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.flip_horizontal_in, Resource.Animation.flip_horizontal_out);
		}

		public void flipVerticalAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.flip_vertical_in, Resource.Animation.flip_vertical_out);
		}

		public void fadeAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
		}

		public void disappearTopLeftAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.disappear_top_left_in, Resource.Animation.disappear_top_left_out);
		}

		public void appearTopLeftAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.appear_top_left_in, Resource.Animation.appear_top_left_out);
		}

		public void disappearBottomRightAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.disappear_bottom_right_in, Resource.Animation.disappear_bottom_right_out);
		}

		public void appearBottomRightAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.appear_bottom_right_in, Resource.Animation.appear_bottom_right_out);
		}

		public void unzoomAnimation(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.unzoom_in, Resource.Animation.unzoom_out);
		}

		public void PullRightPushLeft(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.pull_in_right, Resource.Animation.push_out_left);
		}
		public void PullLeftPushRight(Activity a)
		{
			a.OverridePendingTransition(Resource.Animation.pull_in_left, Resource.Animation.push_out_right);
		}
	}
}

