using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Transformation']"
	[Register ("com/squareup/picasso/Transformation", "", "Com.Squareup.Picasso.ITransformationInvoker")]
	public partial interface ITransformation : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Transformation']/method[@name='key' and count(parameter)=0]"
		[Register ("key", "()Ljava/lang/String;", "GetKeyHandler:Com.Squareup.Picasso.ITransformationInvoker, Picasso")]
		string Key ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Transformation']/method[@name='transform' and count(parameter)=1 and parameter[1][@type='android.graphics.Bitmap']]"
		[Register ("transform", "(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;", "GetTransform_Landroid_graphics_Bitmap_Handler:Com.Squareup.Picasso.ITransformationInvoker, Picasso")]
		global::Android.Graphics.Bitmap Transform (global::Android.Graphics.Bitmap p0);

	}

	[global::Android.Runtime.Register ("com/squareup/picasso/Transformation", DoNotGenerateAcw=true)]
	internal class ITransformationInvoker : global::Java.Lang.Object, ITransformation {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/squareup/picasso/Transformation");
		IntPtr class_ref;

		public static ITransformation GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ITransformation> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.squareup.picasso.Transformation"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ITransformationInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ITransformationInvoker); }
		}

		static Delegate cb_key;
#pragma warning disable 0169
		static Delegate GetKeyHandler ()
		{
			if (cb_key == null)
				cb_key = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Key);
			return cb_key;
		}

		static IntPtr n_Key (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.ITransformation __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITransformation> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Key ());
		}
#pragma warning restore 0169

		IntPtr id_key;
		public unsafe string Key ()
		{
			if (id_key == IntPtr.Zero)
				id_key = JNIEnv.GetMethodID (class_ref, "key", "()Ljava/lang/String;");
			return JNIEnv.GetString (JNIEnv.CallObjectMethod (Handle, id_key), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_transform_Landroid_graphics_Bitmap_;
#pragma warning disable 0169
		static Delegate GetTransform_Landroid_graphics_Bitmap_Handler ()
		{
			if (cb_transform_Landroid_graphics_Bitmap_ == null)
				cb_transform_Landroid_graphics_Bitmap_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Transform_Landroid_graphics_Bitmap_);
			return cb_transform_Landroid_graphics_Bitmap_;
		}

		static IntPtr n_Transform_Landroid_graphics_Bitmap_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.ITransformation __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITransformation> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Transform (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_transform_Landroid_graphics_Bitmap_;
		public unsafe global::Android.Graphics.Bitmap Transform (global::Android.Graphics.Bitmap p0)
		{
			if (id_transform_Landroid_graphics_Bitmap_ == IntPtr.Zero)
				id_transform_Landroid_graphics_Bitmap_ = JNIEnv.GetMethodID (class_ref, "transform", "(Landroid/graphics/Bitmap;)Landroid/graphics/Bitmap;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallObjectMethod (Handle, id_transform_Landroid_graphics_Bitmap_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

	}

}
