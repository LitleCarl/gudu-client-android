using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']"
	[global::Android.Runtime.Register ("com/squareup/picasso/RequestCreator", DoNotGenerateAcw=true)]
	public partial class RequestCreator : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/RequestCreator", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RequestCreator); }
		}

		protected RequestCreator (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_centerCrop;
#pragma warning disable 0169
		static Delegate GetCenterCropHandler ()
		{
			if (cb_centerCrop == null)
				cb_centerCrop = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_CenterCrop);
			return cb_centerCrop;
		}

		static IntPtr n_CenterCrop (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.CenterCrop ());
		}
#pragma warning restore 0169

		static IntPtr id_centerCrop;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='centerCrop' and count(parameter)=0]"
		[Register ("centerCrop", "()Lcom/squareup/picasso/RequestCreator;", "GetCenterCropHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator CenterCrop ()
		{
			if (id_centerCrop == IntPtr.Zero)
				id_centerCrop = JNIEnv.GetMethodID (class_ref, "centerCrop", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_centerCrop), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "centerCrop", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_centerInside;
#pragma warning disable 0169
		static Delegate GetCenterInsideHandler ()
		{
			if (cb_centerInside == null)
				cb_centerInside = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_CenterInside);
			return cb_centerInside;
		}

		static IntPtr n_CenterInside (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.CenterInside ());
		}
#pragma warning restore 0169

		static IntPtr id_centerInside;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='centerInside' and count(parameter)=0]"
		[Register ("centerInside", "()Lcom/squareup/picasso/RequestCreator;", "GetCenterInsideHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator CenterInside ()
		{
			if (id_centerInside == IntPtr.Zero)
				id_centerInside = JNIEnv.GetMethodID (class_ref, "centerInside", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_centerInside), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "centerInside", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_config_Landroid_graphics_Bitmap_Config_;
#pragma warning disable 0169
		static Delegate GetConfig_Landroid_graphics_Bitmap_Config_Handler ()
		{
			if (cb_config_Landroid_graphics_Bitmap_Config_ == null)
				cb_config_Landroid_graphics_Bitmap_Config_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Config_Landroid_graphics_Bitmap_Config_);
			return cb_config_Landroid_graphics_Bitmap_Config_;
		}

		static IntPtr n_Config_Landroid_graphics_Bitmap_Config_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap.Config p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap.Config> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Config (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_config_Landroid_graphics_Bitmap_Config_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='config' and count(parameter)=1 and parameter[1][@type='android.graphics.Bitmap.Config']]"
		[Register ("config", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/RequestCreator;", "GetConfig_Landroid_graphics_Bitmap_Config_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Config (global::Android.Graphics.Bitmap.Config p0)
		{
			if (id_config_Landroid_graphics_Bitmap_Config_ == IntPtr.Zero)
				id_config_Landroid_graphics_Bitmap_Config_ = JNIEnv.GetMethodID (class_ref, "config", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_config_Landroid_graphics_Bitmap_Config_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "config", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_error_Landroid_graphics_drawable_Drawable_;
#pragma warning disable 0169
		static Delegate GetError_Landroid_graphics_drawable_Drawable_Handler ()
		{
			if (cb_error_Landroid_graphics_drawable_Drawable_ == null)
				cb_error_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Error_Landroid_graphics_drawable_Drawable_);
			return cb_error_Landroid_graphics_drawable_Drawable_;
		}

		static IntPtr n_Error_Landroid_graphics_drawable_Drawable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Drawables.Drawable p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Drawables.Drawable> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Error (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_error_Landroid_graphics_drawable_Drawable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='error' and count(parameter)=1 and parameter[1][@type='android.graphics.drawable.Drawable']]"
		[Register ("error", "(Landroid/graphics/drawable/Drawable;)Lcom/squareup/picasso/RequestCreator;", "GetError_Landroid_graphics_drawable_Drawable_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Error (global::Android.Graphics.Drawables.Drawable p0)
		{
			if (id_error_Landroid_graphics_drawable_Drawable_ == IntPtr.Zero)
				id_error_Landroid_graphics_drawable_Drawable_ = JNIEnv.GetMethodID (class_ref, "error", "(Landroid/graphics/drawable/Drawable;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_error_Landroid_graphics_drawable_Drawable_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "error", "(Landroid/graphics/drawable/Drawable;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_error_I;
#pragma warning disable 0169
		static Delegate GetError_IHandler ()
		{
			if (cb_error_I == null)
				cb_error_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_Error_I);
			return cb_error_I;
		}

		static IntPtr n_Error_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Error (p0));
		}
#pragma warning restore 0169

		static IntPtr id_error_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='error' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("error", "(I)Lcom/squareup/picasso/RequestCreator;", "GetError_IHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Error (int p0)
		{
			if (id_error_I == IntPtr.Zero)
				id_error_I = JNIEnv.GetMethodID (class_ref, "error", "(I)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_error_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "error", "(I)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_fetch;
#pragma warning disable 0169
		static Delegate GetFetchHandler ()
		{
			if (cb_fetch == null)
				cb_fetch = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Fetch);
			return cb_fetch;
		}

		static void n_Fetch (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Fetch ();
		}
#pragma warning restore 0169

		static IntPtr id_fetch;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='fetch' and count(parameter)=0]"
		[Register ("fetch", "()V", "GetFetchHandler")]
		public virtual unsafe void Fetch ()
		{
			if (id_fetch == IntPtr.Zero)
				id_fetch = JNIEnv.GetMethodID (class_ref, "fetch", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_fetch);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "fetch", "()V"));
			} finally {
			}
		}

		static Delegate cb_fetch_Lcom_squareup_picasso_Callback_;
#pragma warning disable 0169
		static Delegate GetFetch_Lcom_squareup_picasso_Callback_Handler ()
		{
			if (cb_fetch_Lcom_squareup_picasso_Callback_ == null)
				cb_fetch_Lcom_squareup_picasso_Callback_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Fetch_Lcom_squareup_picasso_Callback_);
			return cb_fetch_Lcom_squareup_picasso_Callback_;
		}

		static void n_Fetch_Lcom_squareup_picasso_Callback_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.ICallback p0 = (global::Com.Squareup.Picasso.ICallback)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ICallback> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Fetch (p0);
		}
#pragma warning restore 0169

		static IntPtr id_fetch_Lcom_squareup_picasso_Callback_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='fetch' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Callback']]"
		[Register ("fetch", "(Lcom/squareup/picasso/Callback;)V", "GetFetch_Lcom_squareup_picasso_Callback_Handler")]
		public virtual unsafe void Fetch (global::Com.Squareup.Picasso.ICallback p0)
		{
			if (id_fetch_Lcom_squareup_picasso_Callback_ == IntPtr.Zero)
				id_fetch_Lcom_squareup_picasso_Callback_ = JNIEnv.GetMethodID (class_ref, "fetch", "(Lcom/squareup/picasso/Callback;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_fetch_Lcom_squareup_picasso_Callback_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "fetch", "(Lcom/squareup/picasso/Callback;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_fit;
#pragma warning disable 0169
		static Delegate GetFitHandler ()
		{
			if (cb_fit == null)
				cb_fit = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Fit);
			return cb_fit;
		}

		static IntPtr n_Fit (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Fit ());
		}
#pragma warning restore 0169

		static IntPtr id_fit;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='fit' and count(parameter)=0]"
		[Register ("fit", "()Lcom/squareup/picasso/RequestCreator;", "GetFitHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Fit ()
		{
			if (id_fit == IntPtr.Zero)
				id_fit = JNIEnv.GetMethodID (class_ref, "fit", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_fit), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "fit", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get;
#pragma warning disable 0169
		static Delegate GetGetHandler ()
		{
			if (cb_get == null)
				cb_get = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get);
			return cb_get;
		}

		static IntPtr n_Get (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Get ());
		}
#pragma warning restore 0169

		static IntPtr id_get;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='get' and count(parameter)=0]"
		[Register ("get", "()Landroid/graphics/Bitmap;", "GetGetHandler")]
		public virtual unsafe global::Android.Graphics.Bitmap Get ()
		{
			if (id_get == IntPtr.Zero)
				id_get = JNIEnv.GetMethodID (class_ref, "get", "()Landroid/graphics/Bitmap;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallObjectMethod  (Handle, id_get), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get", "()Landroid/graphics/Bitmap;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_into_Landroid_widget_ImageView_;
#pragma warning disable 0169
		static Delegate GetInto_Landroid_widget_ImageView_Handler ()
		{
			if (cb_into_Landroid_widget_ImageView_ == null)
				cb_into_Landroid_widget_ImageView_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Into_Landroid_widget_ImageView_);
			return cb_into_Landroid_widget_ImageView_;
		}

		static void n_Into_Landroid_widget_ImageView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.ImageView p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.ImageView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Into (p0);
		}
#pragma warning restore 0169

		static IntPtr id_into_Landroid_widget_ImageView_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='into' and count(parameter)=1 and parameter[1][@type='android.widget.ImageView']]"
		[Register ("into", "(Landroid/widget/ImageView;)V", "GetInto_Landroid_widget_ImageView_Handler")]
		public virtual unsafe void Into (global::Android.Widget.ImageView p0)
		{
			if (id_into_Landroid_widget_ImageView_ == IntPtr.Zero)
				id_into_Landroid_widget_ImageView_ = JNIEnv.GetMethodID (class_ref, "into", "(Landroid/widget/ImageView;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_into_Landroid_widget_ImageView_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "into", "(Landroid/widget/ImageView;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_;
#pragma warning disable 0169
		static Delegate GetInto_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_Handler ()
		{
			if (cb_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_ == null)
				cb_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_Into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_);
			return cb_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_;
		}

		static void n_Into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.ImageView p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.ImageView> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.ICallback p1 = (global::Com.Squareup.Picasso.ICallback)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ICallback> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Into (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='into' and count(parameter)=2 and parameter[1][@type='android.widget.ImageView'] and parameter[2][@type='com.squareup.picasso.Callback']]"
		[Register ("into", "(Landroid/widget/ImageView;Lcom/squareup/picasso/Callback;)V", "GetInto_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_Handler")]
		public virtual unsafe void Into (global::Android.Widget.ImageView p0, global::Com.Squareup.Picasso.ICallback p1)
		{
			if (id_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_ == IntPtr.Zero)
				id_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_ = JNIEnv.GetMethodID (class_ref, "into", "(Landroid/widget/ImageView;Lcom/squareup/picasso/Callback;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_into_Landroid_widget_ImageView_Lcom_squareup_picasso_Callback_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "into", "(Landroid/widget/ImageView;Lcom/squareup/picasso/Callback;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_;
#pragma warning disable 0169
		static Delegate GetInto_Landroid_widget_RemoteViews_IILandroid_app_Notification_Handler ()
		{
			if (cb_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_ == null)
				cb_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, int, IntPtr>) n_Into_Landroid_widget_RemoteViews_IILandroid_app_Notification_);
			return cb_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_;
		}

		static void n_Into_Landroid_widget_RemoteViews_IILandroid_app_Notification_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, IntPtr native_p3)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RemoteViews p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RemoteViews> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.App.Notification p3 = global::Java.Lang.Object.GetObject<global::Android.App.Notification> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.Into (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='into' and count(parameter)=4 and parameter[1][@type='android.widget.RemoteViews'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='android.app.Notification']]"
		[Register ("into", "(Landroid/widget/RemoteViews;IILandroid/app/Notification;)V", "GetInto_Landroid_widget_RemoteViews_IILandroid_app_Notification_Handler")]
		public virtual unsafe void Into (global::Android.Widget.RemoteViews p0, int p1, int p2, global::Android.App.Notification p3)
		{
			if (id_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_ == IntPtr.Zero)
				id_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_ = JNIEnv.GetMethodID (class_ref, "into", "(Landroid/widget/RemoteViews;IILandroid/app/Notification;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_into_Landroid_widget_RemoteViews_IILandroid_app_Notification_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "into", "(Landroid/widget/RemoteViews;IILandroid/app/Notification;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_into_Landroid_widget_RemoteViews_IarrayI;
#pragma warning disable 0169
		static Delegate GetInto_Landroid_widget_RemoteViews_IarrayIHandler ()
		{
			if (cb_into_Landroid_widget_RemoteViews_IarrayI == null)
				cb_into_Landroid_widget_RemoteViews_IarrayI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, IntPtr>) n_Into_Landroid_widget_RemoteViews_IarrayI);
			return cb_into_Landroid_widget_RemoteViews_IarrayI;
		}

		static void n_Into_Landroid_widget_RemoteViews_IarrayI (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, IntPtr native_p2)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RemoteViews p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RemoteViews> (native_p0, JniHandleOwnership.DoNotTransfer);
			int[] p2 = (int[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (int));
			__this.Into (p0, p1, p2);
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
		}
#pragma warning restore 0169

		static IntPtr id_into_Landroid_widget_RemoteViews_IarrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='into' and count(parameter)=3 and parameter[1][@type='android.widget.RemoteViews'] and parameter[2][@type='int'] and parameter[3][@type='int[]']]"
		[Register ("into", "(Landroid/widget/RemoteViews;I[I)V", "GetInto_Landroid_widget_RemoteViews_IarrayIHandler")]
		public virtual unsafe void Into (global::Android.Widget.RemoteViews p0, int p1, int[] p2)
		{
			if (id_into_Landroid_widget_RemoteViews_IarrayI == IntPtr.Zero)
				id_into_Landroid_widget_RemoteViews_IarrayI = JNIEnv.GetMethodID (class_ref, "into", "(Landroid/widget/RemoteViews;I[I)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_into_Landroid_widget_RemoteViews_IarrayI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "into", "(Landroid/widget/RemoteViews;I[I)V"), __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_into_Lcom_squareup_picasso_Target_;
#pragma warning disable 0169
		static Delegate GetInto_Lcom_squareup_picasso_Target_Handler ()
		{
			if (cb_into_Lcom_squareup_picasso_Target_ == null)
				cb_into_Lcom_squareup_picasso_Target_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Into_Lcom_squareup_picasso_Target_);
			return cb_into_Lcom_squareup_picasso_Target_;
		}

		static void n_Into_Lcom_squareup_picasso_Target_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.ITarget p0 = (global::Com.Squareup.Picasso.ITarget)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITarget> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Into (p0);
		}
#pragma warning restore 0169

		static IntPtr id_into_Lcom_squareup_picasso_Target_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='into' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Target']]"
		[Register ("into", "(Lcom/squareup/picasso/Target;)V", "GetInto_Lcom_squareup_picasso_Target_Handler")]
		public virtual unsafe void Into (global::Com.Squareup.Picasso.ITarget p0)
		{
			if (id_into_Lcom_squareup_picasso_Target_ == IntPtr.Zero)
				id_into_Lcom_squareup_picasso_Target_ = JNIEnv.GetMethodID (class_ref, "into", "(Lcom/squareup/picasso/Target;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_into_Lcom_squareup_picasso_Target_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "into", "(Lcom/squareup/picasso/Target;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_;
#pragma warning disable 0169
		static Delegate GetMemoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_Handler ()
		{
			if (cb_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_ == null)
				cb_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_MemoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_);
			return cb_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_;
		}

		static IntPtr n_MemoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.MemoryPolicy p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.MemoryPolicy> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.MemoryPolicy[] p1 = (global::Com.Squareup.Picasso.MemoryPolicy[]) JNIEnv.GetArray (native_p1, JniHandleOwnership.DoNotTransfer, typeof (global::Com.Squareup.Picasso.MemoryPolicy));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.MemoryPolicy (p0, p1));
			if (p1 != null)
				JNIEnv.CopyArray (p1, native_p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='memoryPolicy' and count(parameter)=2 and parameter[1][@type='com.squareup.picasso.MemoryPolicy'] and parameter[2][@type='com.squareup.picasso.MemoryPolicy...']]"
		[Register ("memoryPolicy", "(Lcom/squareup/picasso/MemoryPolicy;[Lcom/squareup/picasso/MemoryPolicy;)Lcom/squareup/picasso/RequestCreator;", "GetMemoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator MemoryPolicy (global::Com.Squareup.Picasso.MemoryPolicy p0, params global:: Com.Squareup.Picasso.MemoryPolicy[] p1)
		{
			if (id_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_ == IntPtr.Zero)
				id_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_ = JNIEnv.GetMethodID (class_ref, "memoryPolicy", "(Lcom/squareup/picasso/MemoryPolicy;[Lcom/squareup/picasso/MemoryPolicy;)Lcom/squareup/picasso/RequestCreator;");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_memoryPolicy_Lcom_squareup_picasso_MemoryPolicy_arrayLcom_squareup_picasso_MemoryPolicy_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "memoryPolicy", "(Lcom/squareup/picasso/MemoryPolicy;[Lcom/squareup/picasso/MemoryPolicy;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static Delegate cb_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_;
#pragma warning disable 0169
		static Delegate GetNetworkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_Handler ()
		{
			if (cb_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_ == null)
				cb_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_NetworkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_);
			return cb_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_;
		}

		static IntPtr n_NetworkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.NetworkPolicy p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.NetworkPolicy> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.NetworkPolicy[] p1 = (global::Com.Squareup.Picasso.NetworkPolicy[]) JNIEnv.GetArray (native_p1, JniHandleOwnership.DoNotTransfer, typeof (global::Com.Squareup.Picasso.NetworkPolicy));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.NetworkPolicy (p0, p1));
			if (p1 != null)
				JNIEnv.CopyArray (p1, native_p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='networkPolicy' and count(parameter)=2 and parameter[1][@type='com.squareup.picasso.NetworkPolicy'] and parameter[2][@type='com.squareup.picasso.NetworkPolicy...']]"
		[Register ("networkPolicy", "(Lcom/squareup/picasso/NetworkPolicy;[Lcom/squareup/picasso/NetworkPolicy;)Lcom/squareup/picasso/RequestCreator;", "GetNetworkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator NetworkPolicy (global::Com.Squareup.Picasso.NetworkPolicy p0, params global:: Com.Squareup.Picasso.NetworkPolicy[] p1)
		{
			if (id_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_ == IntPtr.Zero)
				id_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_ = JNIEnv.GetMethodID (class_ref, "networkPolicy", "(Lcom/squareup/picasso/NetworkPolicy;[Lcom/squareup/picasso/NetworkPolicy;)Lcom/squareup/picasso/RequestCreator;");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_networkPolicy_Lcom_squareup_picasso_NetworkPolicy_arrayLcom_squareup_picasso_NetworkPolicy_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "networkPolicy", "(Lcom/squareup/picasso/NetworkPolicy;[Lcom/squareup/picasso/NetworkPolicy;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static Delegate cb_noFade;
#pragma warning disable 0169
		static Delegate GetNoFadeHandler ()
		{
			if (cb_noFade == null)
				cb_noFade = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_NoFade);
			return cb_noFade;
		}

		static IntPtr n_NoFade (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.NoFade ());
		}
#pragma warning restore 0169

		static IntPtr id_noFade;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='noFade' and count(parameter)=0]"
		[Register ("noFade", "()Lcom/squareup/picasso/RequestCreator;", "GetNoFadeHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator NoFade ()
		{
			if (id_noFade == IntPtr.Zero)
				id_noFade = JNIEnv.GetMethodID (class_ref, "noFade", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_noFade), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "noFade", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_noPlaceholder;
#pragma warning disable 0169
		static Delegate GetNoPlaceholderHandler ()
		{
			if (cb_noPlaceholder == null)
				cb_noPlaceholder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_NoPlaceholder);
			return cb_noPlaceholder;
		}

		static IntPtr n_NoPlaceholder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.NoPlaceholder ());
		}
#pragma warning restore 0169

		static IntPtr id_noPlaceholder;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='noPlaceholder' and count(parameter)=0]"
		[Register ("noPlaceholder", "()Lcom/squareup/picasso/RequestCreator;", "GetNoPlaceholderHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator NoPlaceholder ()
		{
			if (id_noPlaceholder == IntPtr.Zero)
				id_noPlaceholder = JNIEnv.GetMethodID (class_ref, "noPlaceholder", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_noPlaceholder), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "noPlaceholder", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_onlyScaleDown;
#pragma warning disable 0169
		static Delegate GetOnlyScaleDownHandler ()
		{
			if (cb_onlyScaleDown == null)
				cb_onlyScaleDown = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_OnlyScaleDown);
			return cb_onlyScaleDown;
		}

		static IntPtr n_OnlyScaleDown (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.OnlyScaleDown ());
		}
#pragma warning restore 0169

		static IntPtr id_onlyScaleDown;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='onlyScaleDown' and count(parameter)=0]"
		[Register ("onlyScaleDown", "()Lcom/squareup/picasso/RequestCreator;", "GetOnlyScaleDownHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator OnlyScaleDown ()
		{
			if (id_onlyScaleDown == IntPtr.Zero)
				id_onlyScaleDown = JNIEnv.GetMethodID (class_ref, "onlyScaleDown", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_onlyScaleDown), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onlyScaleDown", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_placeholder_Landroid_graphics_drawable_Drawable_;
#pragma warning disable 0169
		static Delegate GetPlaceholder_Landroid_graphics_drawable_Drawable_Handler ()
		{
			if (cb_placeholder_Landroid_graphics_drawable_Drawable_ == null)
				cb_placeholder_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Placeholder_Landroid_graphics_drawable_Drawable_);
			return cb_placeholder_Landroid_graphics_drawable_Drawable_;
		}

		static IntPtr n_Placeholder_Landroid_graphics_drawable_Drawable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Drawables.Drawable p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Drawables.Drawable> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Placeholder (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_placeholder_Landroid_graphics_drawable_Drawable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='placeholder' and count(parameter)=1 and parameter[1][@type='android.graphics.drawable.Drawable']]"
		[Register ("placeholder", "(Landroid/graphics/drawable/Drawable;)Lcom/squareup/picasso/RequestCreator;", "GetPlaceholder_Landroid_graphics_drawable_Drawable_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Placeholder (global::Android.Graphics.Drawables.Drawable p0)
		{
			if (id_placeholder_Landroid_graphics_drawable_Drawable_ == IntPtr.Zero)
				id_placeholder_Landroid_graphics_drawable_Drawable_ = JNIEnv.GetMethodID (class_ref, "placeholder", "(Landroid/graphics/drawable/Drawable;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_placeholder_Landroid_graphics_drawable_Drawable_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "placeholder", "(Landroid/graphics/drawable/Drawable;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_placeholder_I;
#pragma warning disable 0169
		static Delegate GetPlaceholder_IHandler ()
		{
			if (cb_placeholder_I == null)
				cb_placeholder_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_Placeholder_I);
			return cb_placeholder_I;
		}

		static IntPtr n_Placeholder_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Placeholder (p0));
		}
#pragma warning restore 0169

		static IntPtr id_placeholder_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='placeholder' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("placeholder", "(I)Lcom/squareup/picasso/RequestCreator;", "GetPlaceholder_IHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Placeholder (int p0)
		{
			if (id_placeholder_I == IntPtr.Zero)
				id_placeholder_I = JNIEnv.GetMethodID (class_ref, "placeholder", "(I)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_placeholder_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "placeholder", "(I)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_priority_Lcom_squareup_picasso_Picasso_Priority_;
#pragma warning disable 0169
		static Delegate GetPriority_Lcom_squareup_picasso_Picasso_Priority_Handler ()
		{
			if (cb_priority_Lcom_squareup_picasso_Picasso_Priority_ == null)
				cb_priority_Lcom_squareup_picasso_Picasso_Priority_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Priority_Lcom_squareup_picasso_Picasso_Priority_);
			return cb_priority_Lcom_squareup_picasso_Picasso_Priority_;
		}

		static IntPtr n_Priority_Lcom_squareup_picasso_Picasso_Priority_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.Picasso.Priority p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Priority> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Priority (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_priority_Lcom_squareup_picasso_Picasso_Priority_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='priority' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Picasso.Priority']]"
		[Register ("priority", "(Lcom/squareup/picasso/Picasso$Priority;)Lcom/squareup/picasso/RequestCreator;", "GetPriority_Lcom_squareup_picasso_Picasso_Priority_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Priority (global::Com.Squareup.Picasso.Picasso.Priority p0)
		{
			if (id_priority_Lcom_squareup_picasso_Picasso_Priority_ == IntPtr.Zero)
				id_priority_Lcom_squareup_picasso_Picasso_Priority_ = JNIEnv.GetMethodID (class_ref, "priority", "(Lcom/squareup/picasso/Picasso$Priority;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_priority_Lcom_squareup_picasso_Picasso_Priority_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "priority", "(Lcom/squareup/picasso/Picasso$Priority;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_resize_II;
#pragma warning disable 0169
		static Delegate GetResize_IIHandler ()
		{
			if (cb_resize_II == null)
				cb_resize_II = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr>) n_Resize_II);
			return cb_resize_II;
		}

		static IntPtr n_Resize_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Resize (p0, p1));
		}
#pragma warning restore 0169

		static IntPtr id_resize_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='resize' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("resize", "(II)Lcom/squareup/picasso/RequestCreator;", "GetResize_IIHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Resize (int p0, int p1)
		{
			if (id_resize_II == IntPtr.Zero)
				id_resize_II = JNIEnv.GetMethodID (class_ref, "resize", "(II)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_resize_II, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "resize", "(II)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_resizeDimen_II;
#pragma warning disable 0169
		static Delegate GetResizeDimen_IIHandler ()
		{
			if (cb_resizeDimen_II == null)
				cb_resizeDimen_II = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr>) n_ResizeDimen_II);
			return cb_resizeDimen_II;
		}

		static IntPtr n_ResizeDimen_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ResizeDimen (p0, p1));
		}
#pragma warning restore 0169

		static IntPtr id_resizeDimen_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='resizeDimen' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("resizeDimen", "(II)Lcom/squareup/picasso/RequestCreator;", "GetResizeDimen_IIHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator ResizeDimen (int p0, int p1)
		{
			if (id_resizeDimen_II == IntPtr.Zero)
				id_resizeDimen_II = JNIEnv.GetMethodID (class_ref, "resizeDimen", "(II)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_resizeDimen_II, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "resizeDimen", "(II)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_rotate_F;
#pragma warning disable 0169
		static Delegate GetRotate_FHandler ()
		{
			if (cb_rotate_F == null)
				cb_rotate_F = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, float, IntPtr>) n_Rotate_F);
			return cb_rotate_F;
		}

		static IntPtr n_Rotate_F (IntPtr jnienv, IntPtr native__this, float p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Rotate (p0));
		}
#pragma warning restore 0169

		static IntPtr id_rotate_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='rotate' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("rotate", "(F)Lcom/squareup/picasso/RequestCreator;", "GetRotate_FHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Rotate (float p0)
		{
			if (id_rotate_F == IntPtr.Zero)
				id_rotate_F = JNIEnv.GetMethodID (class_ref, "rotate", "(F)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_rotate_F, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "rotate", "(F)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_rotate_FFF;
#pragma warning disable 0169
		static Delegate GetRotate_FFFHandler ()
		{
			if (cb_rotate_FFF == null)
				cb_rotate_FFF = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, float, float, float, IntPtr>) n_Rotate_FFF);
			return cb_rotate_FFF;
		}

		static IntPtr n_Rotate_FFF (IntPtr jnienv, IntPtr native__this, float p0, float p1, float p2)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Rotate (p0, p1, p2));
		}
#pragma warning restore 0169

		static IntPtr id_rotate_FFF;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='rotate' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='float'] and parameter[3][@type='float']]"
		[Register ("rotate", "(FFF)Lcom/squareup/picasso/RequestCreator;", "GetRotate_FFFHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Rotate (float p0, float p1, float p2)
		{
			if (id_rotate_FFF == IntPtr.Zero)
				id_rotate_FFF = JNIEnv.GetMethodID (class_ref, "rotate", "(FFF)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_rotate_FFF, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "rotate", "(FFF)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_skipMemoryCache;
#pragma warning disable 0169
		static Delegate GetSkipMemoryCacheHandler ()
		{
			if (cb_skipMemoryCache == null)
				cb_skipMemoryCache = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_SkipMemoryCache);
			return cb_skipMemoryCache;
		}

		static IntPtr n_SkipMemoryCache (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.SkipMemoryCache ());
		}
#pragma warning restore 0169

		static IntPtr id_skipMemoryCache;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='skipMemoryCache' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("skipMemoryCache", "()Lcom/squareup/picasso/RequestCreator;", "GetSkipMemoryCacheHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator SkipMemoryCache ()
		{
			if (id_skipMemoryCache == IntPtr.Zero)
				id_skipMemoryCache = JNIEnv.GetMethodID (class_ref, "skipMemoryCache", "()Lcom/squareup/picasso/RequestCreator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_skipMemoryCache), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "skipMemoryCache", "()Lcom/squareup/picasso/RequestCreator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_stableKey_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetStableKey_Ljava_lang_String_Handler ()
		{
			if (cb_stableKey_Ljava_lang_String_ == null)
				cb_stableKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_StableKey_Ljava_lang_String_);
			return cb_stableKey_Ljava_lang_String_;
		}

		static IntPtr n_StableKey_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.StableKey (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_stableKey_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='stableKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("stableKey", "(Ljava/lang/String;)Lcom/squareup/picasso/RequestCreator;", "GetStableKey_Ljava_lang_String_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator StableKey (string p0)
		{
			if (id_stableKey_Ljava_lang_String_ == IntPtr.Zero)
				id_stableKey_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "stableKey", "(Ljava/lang/String;)Lcom/squareup/picasso/RequestCreator;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_stableKey_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "stableKey", "(Ljava/lang/String;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_tag_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetTag_Ljava_lang_Object_Handler ()
		{
			if (cb_tag_Ljava_lang_Object_ == null)
				cb_tag_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Tag_Ljava_lang_Object_);
			return cb_tag_Ljava_lang_Object_;
		}

		static IntPtr n_Tag_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Tag (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_tag_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='tag' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("tag", "(Ljava/lang/Object;)Lcom/squareup/picasso/RequestCreator;", "GetTag_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Tag (global::Java.Lang.Object p0)
		{
			if (id_tag_Ljava_lang_Object_ == IntPtr.Zero)
				id_tag_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "tag", "(Ljava/lang/Object;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_tag_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "tag", "(Ljava/lang/Object;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_transform_Lcom_squareup_picasso_Transformation_;
#pragma warning disable 0169
		static Delegate GetTransform_Lcom_squareup_picasso_Transformation_Handler ()
		{
			if (cb_transform_Lcom_squareup_picasso_Transformation_ == null)
				cb_transform_Lcom_squareup_picasso_Transformation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Transform_Lcom_squareup_picasso_Transformation_);
			return cb_transform_Lcom_squareup_picasso_Transformation_;
		}

		static IntPtr n_Transform_Lcom_squareup_picasso_Transformation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestCreator __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.ITransformation p0 = (global::Com.Squareup.Picasso.ITransformation)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITransformation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Transform (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_transform_Lcom_squareup_picasso_Transformation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestCreator']/method[@name='transform' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Transformation']]"
		[Register ("transform", "(Lcom/squareup/picasso/Transformation;)Lcom/squareup/picasso/RequestCreator;", "GetTransform_Lcom_squareup_picasso_Transformation_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Transform (global::Com.Squareup.Picasso.ITransformation p0)
		{
			if (id_transform_Lcom_squareup_picasso_Transformation_ == IntPtr.Zero)
				id_transform_Lcom_squareup_picasso_Transformation_ = JNIEnv.GetMethodID (class_ref, "transform", "(Lcom/squareup/picasso/Transformation;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_transform_Lcom_squareup_picasso_Transformation_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "transform", "(Lcom/squareup/picasso/Transformation;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
