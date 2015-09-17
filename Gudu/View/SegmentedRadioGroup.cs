using System;
using Android.Content;
using Android.Util;
using Android.Widget;
namespace Gudu.CustomView {
	public class SegmentedRadioGroup : RadioGroup {

		public SegmentedRadioGroup(Context context):base(context) {
			
		}

		public SegmentedRadioGroup(Context context, IAttributeSet attrs):base (context, attrs) {
			
		}


		protected override void OnFinishInflate() {
			base.OnFinishInflate();
			ChangeButtonsImages();
		}

		private void ChangeButtonsImages(){
			int count = base.ChildCount;

			if(count > 1){
				base.GetChildAt(0).SetBackgroundResource(Resource.Drawable.segment_radio_left);
				for(int i=1; i < count-1; i++){
					base.GetChildAt(i).SetBackgroundResource(Resource.Drawable.segment_radio_middle);
				}
				base.GetChildAt(count-1).SetBackgroundResource(Resource.Drawable.segment_radio_right);
			}else if (count == 1){
				base.GetChildAt(0).SetBackgroundResource(Resource.Drawable.segment_button);
			}
		}
	}
}