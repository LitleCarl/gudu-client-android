using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Target']"
	[Register ("com/squareup/picasso/Target", "", "Com.Squareup.Picasso.ITargetInvoker")]
	public partial interface ITarget : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Target']/method[@name='onBitmapFailed' and count(parameter)=1 and parameter[1][@type='android.graphics.drawable.Drawable']]"
		[Register ("onBitmapFailed", "(Landroid/graphics/drawable/Drawable;)V", "GetOnBitmapFailed_Landroid_graphics_drawable_Drawable_Handler:Com.Squareup.Picasso.ITargetInvoker, Picasso")]
		void OnBitmapFailed (global::Android.Graphics.Drawables.Drawable p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Target']/method[@name='onBitmapLoaded' and count(parameter)=2 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='com.squareup.picasso.Picasso.LoadedFrom']]"
		[Register ("onBitmapLoaded", "(Landroid/graphics/Bitmap;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", "GetOnBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_Handler:Com.Squareup.Picasso.ITargetInvoker, Picasso")]
		void OnBitmapLoaded (global::Android.Graphics.Bitmap p0, global::Com.Squareup.Picasso.Picasso.LoadedFrom p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Target']/method[@name='onPrepareLoad' and count(parameter)=1 and parameter[1][@type='android.graphics.drawable.Drawable']]"
		[Register ("onPrepareLoad", "(Landroid/graphics/drawable/Drawable;)V", "GetOnPrepareLoad_Landroid_graphics_drawable_Drawable_Handler:Com.Squareup.Picasso.ITargetInvoker, Picasso")]
		void OnPrepareLoad (global::Android.Graphics.Drawables.Drawable p0);

	}

	[global::Android.Runtime.Register ("com/squareup/picasso/Target", DoNotGenerateAcw=true)]
	internal class ITargetInvoker : global::Java.Lang.Object, ITarget {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/squareup/picasso/Target");
		IntPtr class_ref;

		public static ITarget GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ITarget> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.squareup.picasso.Target"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ITargetInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ITargetInvoker); }
		}

		static Delegate cb_onBitmapFailed_Landroid_graphics_drawable_Drawable_;
#pragma warning disable 0169
		static Delegate GetOnBitmapFailed_Landroid_graphics_drawable_Drawable_Handler ()
		{
			if (cb_onBitmapFailed_Landroid_graphics_drawable_Drawable_ == null)
				cb_onBitmapFailed_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnBitmapFailed_Landroid_graphics_drawable_Drawable_);
			return cb_onBitmapFailed_Landroid_graphics_drawable_Drawable_;
		}

		static void n_OnBitmapFailed_Landroid_graphics_drawable_Drawable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.ITarget __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITarget> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Drawables.Drawable p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Drawables.Drawable> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnBitmapFailed (p0);
		}
#pragma warning restore 0169

		IntPtr id_onBitmapFailed_Landroid_graphics_drawable_Drawable_;
		public unsafe void OnBitmapFailed (global::Android.Graphics.Drawables.Drawable p0)
		{
			if (id_onBitmapFailed_Landroid_graphics_drawable_Drawable_ == IntPtr.Zero)
				id_onBitmapFailed_Landroid_graphics_drawable_Drawable_ = JNIEnv.GetMethodID (class_ref, "onBitmapFailed", "(Landroid/graphics/drawable/Drawable;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (Handle, id_onBitmapFailed_Landroid_graphics_drawable_Drawable_, __args);
		}

		static Delegate cb_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_;
#pragma warning disable 0169
		static Delegate GetOnBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_Handler ()
		{
			if (cb_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ == null)
				cb_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_OnBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_);
			return cb_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_;
		}

		static void n_OnBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Squareup.Picasso.ITarget __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITarget> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.Picasso.LoadedFrom p1 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.LoadedFrom> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.OnBitmapLoaded (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_;
		public unsafe void OnBitmapLoaded (global::Android.Graphics.Bitmap p0, global::Com.Squareup.Picasso.Picasso.LoadedFrom p1)
		{
			if (id_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ == IntPtr.Zero)
				id_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ = JNIEnv.GetMethodID (class_ref, "onBitmapLoaded", "(Landroid/graphics/Bitmap;Lcom/squareup/picasso/Picasso$LoadedFrom;)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (Handle, id_onBitmapLoaded_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_, __args);
		}

		static Delegate cb_onPrepareLoad_Landroid_graphics_drawable_Drawable_;
#pragma warning disable 0169
		static Delegate GetOnPrepareLoad_Landroid_graphics_drawable_Drawable_Handler ()
		{
			if (cb_onPrepareLoad_Landroid_graphics_drawable_Drawable_ == null)
				cb_onPrepareLoad_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnPrepareLoad_Landroid_graphics_drawable_Drawable_);
			return cb_onPrepareLoad_Landroid_graphics_drawable_Drawable_;
		}

		static void n_OnPrepareLoad_Landroid_graphics_drawable_Drawable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.ITarget __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITarget> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Drawables.Drawable p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Drawables.Drawable> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnPrepareLoad (p0);
		}
#pragma warning restore 0169

		IntPtr id_onPrepareLoad_Landroid_graphics_drawable_Drawable_;
		public unsafe void OnPrepareLoad (global::Android.Graphics.Drawables.Drawable p0)
		{
			if (id_onPrepareLoad_Landroid_graphics_drawable_Drawable_ == IntPtr.Zero)
				id_onPrepareLoad_Landroid_graphics_drawable_Drawable_ = JNIEnv.GetMethodID (class_ref, "onPrepareLoad", "(Landroid/graphics/drawable/Drawable;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (Handle, id_onPrepareLoad_Landroid_graphics_drawable_Drawable_, __args);
		}

	}

}
