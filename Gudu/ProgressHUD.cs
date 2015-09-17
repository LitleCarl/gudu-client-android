using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;


namespace Gudu {
	public class ProgressHUD : Dialog {
		public ProgressHUD(Context context):base(context) {
		}

		public ProgressHUD(Context context, int theme):base(context, theme){

		}


		public override void OnWindowFocusChanged(bool hasFocus){
			ImageView imageView = (ImageView) FindViewById(Resource.Id.spinnerImageView);
			AnimationDrawable spinner = (AnimationDrawable) imageView.Background;
			spinner.Start();
		}

		public void SetMessage(string message) {
			if(message != null && message.Length > 0) {

				FindViewById(Resource.Id.message).Visibility = ViewStates.Visible;			
				TextView txt = (TextView)FindViewById(Resource.Id.message);
				txt.Text = message;
				txt.Invalidate();
			}
		}

		public static ProgressHUD Show(Context context, string message, bool indeterminate, bool cancelable,
			EventHandler cancelListener) {
			ProgressHUD dialog = new ProgressHUD(context,Resource.Style.ProgressHUD);
			dialog.SetTitle("");
			dialog.SetContentView(Resource.Layout.progress_hud);
			if(message == null || message.Length == 0) {
				dialog.FindViewById(Resource.Id.message).Visibility = ViewStates.Gone;			
			} else {
				TextView txt = (TextView)dialog.FindViewById(Resource.Id.message);
				txt.Text = (message);
			}
			dialog.SetCancelable(cancelable);
			dialog.CancelEvent += (cancelListener);
			dialog.Window.Attributes.Gravity = GravityFlags.Center;
			WindowManagerLayoutParams lp = dialog.Window.Attributes;  
			lp.DimAmount = 0.2f;
			dialog.Window.Attributes = (lp); 
			dialog.Show();
			return dialog;
		}	
	}
}