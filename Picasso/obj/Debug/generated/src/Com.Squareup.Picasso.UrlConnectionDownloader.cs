using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='UrlConnectionDownloader']"
	[global::Android.Runtime.Register ("com/squareup/picasso/UrlConnectionDownloader", DoNotGenerateAcw=true)]
	public partial class UrlConnectionDownloader : global::Java.Lang.Object, global::Com.Squareup.Picasso.IDownloader {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='UrlConnectionDownloader.ResponseCacheIcs']"
		[global::Android.Runtime.Register ("com/squareup/picasso/UrlConnectionDownloader$ResponseCacheIcs", DoNotGenerateAcw=true)]
		public partial class ResponseCacheIcs : global::Java.Lang.Object {

			protected ResponseCacheIcs (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/UrlConnectionDownloader", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (UrlConnectionDownloader); }
		}

		protected UrlConnectionDownloader (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='UrlConnectionDownloader']/constructor[@name='UrlConnectionDownloader' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe UrlConnectionDownloader (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (UrlConnectionDownloader)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Landroid/content/Context;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static Delegate cb_load_Landroid_net_Uri_I;
#pragma warning disable 0169
		static Delegate GetLoad_Landroid_net_Uri_IHandler ()
		{
			if (cb_load_Landroid_net_Uri_I == null)
				cb_load_Landroid_net_Uri_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, IntPtr>) n_Load_Landroid_net_Uri_I);
			return cb_load_Landroid_net_Uri_I;
		}

		static IntPtr n_Load_Landroid_net_Uri_I (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			global::Com.Squareup.Picasso.UrlConnectionDownloader __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.UrlConnectionDownloader> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri p0 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Load (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_load_Landroid_net_Uri_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='UrlConnectionDownloader']/method[@name='load' and count(parameter)=2 and parameter[1][@type='android.net.Uri'] and parameter[2][@type='int']]"
		[Register ("load", "(Landroid/net/Uri;I)Lcom/squareup/picasso/Downloader$Response;", "GetLoad_Landroid_net_Uri_IHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.DownloaderResponse Load (global::Android.Net.Uri p0, int p1)
		{
			if (id_load_Landroid_net_Uri_I == IntPtr.Zero)
				id_load_Landroid_net_Uri_I = JNIEnv.GetMethodID (class_ref, "load", "(Landroid/net/Uri;I)Lcom/squareup/picasso/Downloader$Response;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Com.Squareup.Picasso.DownloaderResponse __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.DownloaderResponse> (JNIEnv.CallObjectMethod  (Handle, id_load_Landroid_net_Uri_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.DownloaderResponse> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "load", "(Landroid/net/Uri;I)Lcom/squareup/picasso/Downloader$Response;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_openConnection_Landroid_net_Uri_;
#pragma warning disable 0169
		static Delegate GetOpenConnection_Landroid_net_Uri_Handler ()
		{
			if (cb_openConnection_Landroid_net_Uri_ == null)
				cb_openConnection_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_OpenConnection_Landroid_net_Uri_);
			return cb_openConnection_Landroid_net_Uri_;
		}

		static IntPtr n_OpenConnection_Landroid_net_Uri_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.UrlConnectionDownloader __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.UrlConnectionDownloader> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri p0 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OpenConnection (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_openConnection_Landroid_net_Uri_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='UrlConnectionDownloader']/method[@name='openConnection' and count(parameter)=1 and parameter[1][@type='android.net.Uri']]"
		[Register ("openConnection", "(Landroid/net/Uri;)Ljava/net/HttpURLConnection;", "GetOpenConnection_Landroid_net_Uri_Handler")]
		protected virtual unsafe global::Java.Net.HttpURLConnection OpenConnection (global::Android.Net.Uri p0)
		{
			if (id_openConnection_Landroid_net_Uri_ == IntPtr.Zero)
				id_openConnection_Landroid_net_Uri_ = JNIEnv.GetMethodID (class_ref, "openConnection", "(Landroid/net/Uri;)Ljava/net/HttpURLConnection;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Java.Net.HttpURLConnection __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Java.Net.HttpURLConnection> (JNIEnv.CallObjectMethod  (Handle, id_openConnection_Landroid_net_Uri_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Java.Net.HttpURLConnection> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "openConnection", "(Landroid/net/Uri;)Ljava/net/HttpURLConnection;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_shutdown;
#pragma warning disable 0169
		static Delegate GetShutdownHandler ()
		{
			if (cb_shutdown == null)
				cb_shutdown = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Shutdown);
			return cb_shutdown;
		}

		static void n_Shutdown (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.UrlConnectionDownloader __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.UrlConnectionDownloader> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Shutdown ();
		}
#pragma warning restore 0169

		static IntPtr id_shutdown;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='UrlConnectionDownloader']/method[@name='shutdown' and count(parameter)=0]"
		[Register ("shutdown", "()V", "GetShutdownHandler")]
		public virtual unsafe void Shutdown ()
		{
			if (id_shutdown == IntPtr.Zero)
				id_shutdown = JNIEnv.GetMethodID (class_ref, "shutdown", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_shutdown);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "shutdown", "()V"));
			} finally {
			}
		}

	}
}
