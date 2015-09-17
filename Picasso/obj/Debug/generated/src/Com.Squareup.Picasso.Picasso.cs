using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']"
	[global::Android.Runtime.Register ("com/squareup/picasso/Picasso", DoNotGenerateAcw=true)]
	public partial class Picasso : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']"
		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$Builder", DoNotGenerateAcw=true)]
		public partial class Builder : global::Java.Lang.Object {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/squareup/picasso/Picasso$Builder", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Builder); }
			}

			protected Builder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_Landroid_content_Context_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/constructor[@name='Picasso.Builder' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
			[Register (".ctor", "(Landroid/content/Context;)V", "")]
			public unsafe Builder (global::Android.Content.Context p0)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (Handle != IntPtr.Zero)
					return;

				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					if (GetType () != typeof (Builder)) {
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

			static Delegate cb_addRequestHandler_Lcom_squareup_picasso_RequestHandler_;
#pragma warning disable 0169
			static Delegate GetAddRequestHandler_Lcom_squareup_picasso_RequestHandler_Handler ()
			{
				if (cb_addRequestHandler_Lcom_squareup_picasso_RequestHandler_ == null)
					cb_addRequestHandler_Lcom_squareup_picasso_RequestHandler_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddRequestHandler_Lcom_squareup_picasso_RequestHandler_);
				return cb_addRequestHandler_Lcom_squareup_picasso_RequestHandler_;
			}

			static IntPtr n_AddRequestHandler_Lcom_squareup_picasso_RequestHandler_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.RequestHandler p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestHandler> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.AddRequestHandler (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_addRequestHandler_Lcom_squareup_picasso_RequestHandler_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='addRequestHandler' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.RequestHandler']]"
			[Register ("addRequestHandler", "(Lcom/squareup/picasso/RequestHandler;)Lcom/squareup/picasso/Picasso$Builder;", "GetAddRequestHandler_Lcom_squareup_picasso_RequestHandler_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder AddRequestHandler (global::Com.Squareup.Picasso.RequestHandler p0)
			{
				if (id_addRequestHandler_Lcom_squareup_picasso_RequestHandler_ == IntPtr.Zero)
					id_addRequestHandler_Lcom_squareup_picasso_RequestHandler_ = JNIEnv.GetMethodID (class_ref, "addRequestHandler", "(Lcom/squareup/picasso/RequestHandler;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_addRequestHandler_Lcom_squareup_picasso_RequestHandler_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addRequestHandler", "(Lcom/squareup/picasso/RequestHandler;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static Delegate cb_build;
#pragma warning disable 0169
			static Delegate GetBuildHandler ()
			{
				if (cb_build == null)
					cb_build = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Build);
				return cb_build;
			}

			static IntPtr n_Build (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.Build ());
			}
#pragma warning restore 0169

			static IntPtr id_build;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='build' and count(parameter)=0]"
			[Register ("build", "()Lcom/squareup/picasso/Picasso;", "GetBuildHandler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso Build ()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID (class_ref, "build", "()Lcom/squareup/picasso/Picasso;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (JNIEnv.CallObjectMethod  (Handle, id_build), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "build", "()Lcom/squareup/picasso/Picasso;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static Delegate cb_debugging_Z;
#pragma warning disable 0169
			static Delegate GetDebugging_ZHandler ()
			{
				if (cb_debugging_Z == null)
					cb_debugging_Z = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool, IntPtr>) n_Debugging_Z);
				return cb_debugging_Z;
			}

			static IntPtr n_Debugging_Z (IntPtr jnienv, IntPtr native__this, bool p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.Debugging (p0));
			}
#pragma warning restore 0169

			static IntPtr id_debugging_Z;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='debugging' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Obsolete (@"deprecated")]
			[Register ("debugging", "(Z)Lcom/squareup/picasso/Picasso$Builder;", "GetDebugging_ZHandler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder Debugging (bool p0)
			{
				if (id_debugging_Z == IntPtr.Zero)
					id_debugging_Z = JNIEnv.GetMethodID (class_ref, "debugging", "(Z)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_debugging_Z, __args), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "debugging", "(Z)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static Delegate cb_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_;
#pragma warning disable 0169
			static Delegate GetDefaultBitmapConfig_Landroid_graphics_Bitmap_Config_Handler ()
			{
				if (cb_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_ == null)
					cb_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_DefaultBitmapConfig_Landroid_graphics_Bitmap_Config_);
				return cb_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_;
			}

			static IntPtr n_DefaultBitmapConfig_Landroid_graphics_Bitmap_Config_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Android.Graphics.Bitmap.Config p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap.Config> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.DefaultBitmapConfig (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='defaultBitmapConfig' and count(parameter)=1 and parameter[1][@type='android.graphics.Bitmap.Config']]"
			[Register ("defaultBitmapConfig", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/Picasso$Builder;", "GetDefaultBitmapConfig_Landroid_graphics_Bitmap_Config_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder DefaultBitmapConfig (global::Android.Graphics.Bitmap.Config p0)
			{
				if (id_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_ == IntPtr.Zero)
					id_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_ = JNIEnv.GetMethodID (class_ref, "defaultBitmapConfig", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_defaultBitmapConfig_Landroid_graphics_Bitmap_Config_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "defaultBitmapConfig", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static Delegate cb_downloader_Lcom_squareup_picasso_Downloader_;
#pragma warning disable 0169
			static Delegate GetDownloader_Lcom_squareup_picasso_Downloader_Handler ()
			{
				if (cb_downloader_Lcom_squareup_picasso_Downloader_ == null)
					cb_downloader_Lcom_squareup_picasso_Downloader_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Downloader_Lcom_squareup_picasso_Downloader_);
				return cb_downloader_Lcom_squareup_picasso_Downloader_;
			}

			static IntPtr n_Downloader_Lcom_squareup_picasso_Downloader_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.IDownloader p0 = (global::Com.Squareup.Picasso.IDownloader)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.IDownloader> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Downloader (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_downloader_Lcom_squareup_picasso_Downloader_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='downloader' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Downloader']]"
			[Register ("downloader", "(Lcom/squareup/picasso/Downloader;)Lcom/squareup/picasso/Picasso$Builder;", "GetDownloader_Lcom_squareup_picasso_Downloader_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder Downloader (global::Com.Squareup.Picasso.IDownloader p0)
			{
				if (id_downloader_Lcom_squareup_picasso_Downloader_ == IntPtr.Zero)
					id_downloader_Lcom_squareup_picasso_Downloader_ = JNIEnv.GetMethodID (class_ref, "downloader", "(Lcom/squareup/picasso/Downloader;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_downloader_Lcom_squareup_picasso_Downloader_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "downloader", "(Lcom/squareup/picasso/Downloader;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static Delegate cb_executor_Ljava_util_concurrent_ExecutorService_;
#pragma warning disable 0169
			static Delegate GetExecutor_Ljava_util_concurrent_ExecutorService_Handler ()
			{
				if (cb_executor_Ljava_util_concurrent_ExecutorService_ == null)
					cb_executor_Ljava_util_concurrent_ExecutorService_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Executor_Ljava_util_concurrent_ExecutorService_);
				return cb_executor_Ljava_util_concurrent_ExecutorService_;
			}

			static IntPtr n_Executor_Ljava_util_concurrent_ExecutorService_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Java.Util.Concurrent.IExecutorService p0 = (global::Java.Util.Concurrent.IExecutorService)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutorService> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Executor (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_executor_Ljava_util_concurrent_ExecutorService_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='executor' and count(parameter)=1 and parameter[1][@type='java.util.concurrent.ExecutorService']]"
			[Register ("executor", "(Ljava/util/concurrent/ExecutorService;)Lcom/squareup/picasso/Picasso$Builder;", "GetExecutor_Ljava_util_concurrent_ExecutorService_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder Executor (global::Java.Util.Concurrent.IExecutorService p0)
			{
				if (id_executor_Ljava_util_concurrent_ExecutorService_ == IntPtr.Zero)
					id_executor_Ljava_util_concurrent_ExecutorService_ = JNIEnv.GetMethodID (class_ref, "executor", "(Ljava/util/concurrent/ExecutorService;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_executor_Ljava_util_concurrent_ExecutorService_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "executor", "(Ljava/util/concurrent/ExecutorService;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static Delegate cb_indicatorsEnabled_Z;
#pragma warning disable 0169
			static Delegate GetIndicatorsEnabled_ZHandler ()
			{
				if (cb_indicatorsEnabled_Z == null)
					cb_indicatorsEnabled_Z = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool, IntPtr>) n_IndicatorsEnabled_Z);
				return cb_indicatorsEnabled_Z;
			}

			static IntPtr n_IndicatorsEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.IndicatorsEnabled (p0));
			}
#pragma warning restore 0169

			static IntPtr id_indicatorsEnabled_Z;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='indicatorsEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("indicatorsEnabled", "(Z)Lcom/squareup/picasso/Picasso$Builder;", "GetIndicatorsEnabled_ZHandler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder IndicatorsEnabled (bool p0)
			{
				if (id_indicatorsEnabled_Z == IntPtr.Zero)
					id_indicatorsEnabled_Z = JNIEnv.GetMethodID (class_ref, "indicatorsEnabled", "(Z)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_indicatorsEnabled_Z, __args), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "indicatorsEnabled", "(Z)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static Delegate cb_listener_Lcom_squareup_picasso_Picasso_Listener_;
#pragma warning disable 0169
			static Delegate GetListener_Lcom_squareup_picasso_Picasso_Listener_Handler ()
			{
				if (cb_listener_Lcom_squareup_picasso_Picasso_Listener_ == null)
					cb_listener_Lcom_squareup_picasso_Picasso_Listener_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Listener_Lcom_squareup_picasso_Picasso_Listener_);
				return cb_listener_Lcom_squareup_picasso_Picasso_Listener_;
			}

			static IntPtr n_Listener_Lcom_squareup_picasso_Picasso_Listener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.Picasso.IListener p0 = (global::Com.Squareup.Picasso.Picasso.IListener)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.IListener> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Listener (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_listener_Lcom_squareup_picasso_Picasso_Listener_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='listener' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Picasso.Listener']]"
			[Register ("listener", "(Lcom/squareup/picasso/Picasso$Listener;)Lcom/squareup/picasso/Picasso$Builder;", "GetListener_Lcom_squareup_picasso_Picasso_Listener_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder Listener (global::Com.Squareup.Picasso.Picasso.IListener p0)
			{
				if (id_listener_Lcom_squareup_picasso_Picasso_Listener_ == IntPtr.Zero)
					id_listener_Lcom_squareup_picasso_Picasso_Listener_ = JNIEnv.GetMethodID (class_ref, "listener", "(Lcom/squareup/picasso/Picasso$Listener;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_listener_Lcom_squareup_picasso_Picasso_Listener_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "listener", "(Lcom/squareup/picasso/Picasso$Listener;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static Delegate cb_loggingEnabled_Z;
#pragma warning disable 0169
			static Delegate GetLoggingEnabled_ZHandler ()
			{
				if (cb_loggingEnabled_Z == null)
					cb_loggingEnabled_Z = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool, IntPtr>) n_LoggingEnabled_Z);
				return cb_loggingEnabled_Z;
			}

			static IntPtr n_LoggingEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.LoggingEnabled (p0));
			}
#pragma warning restore 0169

			static IntPtr id_loggingEnabled_Z;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='loggingEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("loggingEnabled", "(Z)Lcom/squareup/picasso/Picasso$Builder;", "GetLoggingEnabled_ZHandler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder LoggingEnabled (bool p0)
			{
				if (id_loggingEnabled_Z == IntPtr.Zero)
					id_loggingEnabled_Z = JNIEnv.GetMethodID (class_ref, "loggingEnabled", "(Z)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_loggingEnabled_Z, __args), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "loggingEnabled", "(Z)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static Delegate cb_memoryCache_Lcom_squareup_picasso_Cache_;
#pragma warning disable 0169
			static Delegate GetMemoryCache_Lcom_squareup_picasso_Cache_Handler ()
			{
				if (cb_memoryCache_Lcom_squareup_picasso_Cache_ == null)
					cb_memoryCache_Lcom_squareup_picasso_Cache_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_MemoryCache_Lcom_squareup_picasso_Cache_);
				return cb_memoryCache_Lcom_squareup_picasso_Cache_;
			}

			static IntPtr n_MemoryCache_Lcom_squareup_picasso_Cache_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.ICache p0 = (global::Com.Squareup.Picasso.ICache)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ICache> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.MemoryCache (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_memoryCache_Lcom_squareup_picasso_Cache_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='memoryCache' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Cache']]"
			[Register ("memoryCache", "(Lcom/squareup/picasso/Cache;)Lcom/squareup/picasso/Picasso$Builder;", "GetMemoryCache_Lcom_squareup_picasso_Cache_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder MemoryCache (global::Com.Squareup.Picasso.ICache p0)
			{
				if (id_memoryCache_Lcom_squareup_picasso_Cache_ == IntPtr.Zero)
					id_memoryCache_Lcom_squareup_picasso_Cache_ = JNIEnv.GetMethodID (class_ref, "memoryCache", "(Lcom/squareup/picasso/Cache;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_memoryCache_Lcom_squareup_picasso_Cache_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "memoryCache", "(Lcom/squareup/picasso/Cache;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static Delegate cb_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_;
#pragma warning disable 0169
			static Delegate GetRequestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_Handler ()
			{
				if (cb_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_ == null)
					cb_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_RequestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_);
				return cb_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_;
			}

			static IntPtr n_RequestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.Builder __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.Picasso.IRequestTransformer p0 = (global::Com.Squareup.Picasso.Picasso.IRequestTransformer)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.IRequestTransformer> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.RequestTransformer (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Builder']/method[@name='requestTransformer' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Picasso.RequestTransformer']]"
			[Register ("requestTransformer", "(Lcom/squareup/picasso/Picasso$RequestTransformer;)Lcom/squareup/picasso/Picasso$Builder;", "GetRequestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Picasso.Builder RequestTransformer (global::Com.Squareup.Picasso.Picasso.IRequestTransformer p0)
			{
				if (id_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_ == IntPtr.Zero)
					id_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_ = JNIEnv.GetMethodID (class_ref, "requestTransformer", "(Lcom/squareup/picasso/Picasso$RequestTransformer;)Lcom/squareup/picasso/Picasso$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Picasso.Builder __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallObjectMethod  (Handle, id_requestTransformer_Lcom_squareup_picasso_Picasso_RequestTransformer_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Builder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "requestTransformer", "(Lcom/squareup/picasso/Picasso$RequestTransformer;)Lcom/squareup/picasso/Picasso$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.CleanupThread']"
		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$CleanupThread", DoNotGenerateAcw=true)]
		public partial class CleanupThread : global::Java.Lang.Thread {

			protected CleanupThread (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Picasso.Listener']"
		[Register ("com/squareup/picasso/Picasso$Listener", "", "Com.Squareup.Picasso.Picasso/IListenerInvoker")]
		public partial interface IListener : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Picasso.Listener']/method[@name='onImageLoadFailed' and count(parameter)=3 and parameter[1][@type='com.squareup.picasso.Picasso'] and parameter[2][@type='android.net.Uri'] and parameter[3][@type='java.lang.Exception']]"
			[Register ("onImageLoadFailed", "(Lcom/squareup/picasso/Picasso;Landroid/net/Uri;Ljava/lang/Exception;)V", "GetOnImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_Handler:Com.Squareup.Picasso.Picasso/IListenerInvoker, Picasso")]
			void OnImageLoadFailed (global::Com.Squareup.Picasso.Picasso p0, global::Android.Net.Uri p1, global::Java.Lang.Exception p2);

		}

		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$Listener", DoNotGenerateAcw=true)]
		internal class IListenerInvoker : global::Java.Lang.Object, IListener {

			static IntPtr java_class_ref = JNIEnv.FindClass ("com/squareup/picasso/Picasso$Listener");
			IntPtr class_ref;

			public static IListener GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<IListener> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
								JNIEnv.GetClassNameFromInstance (handle), "com.squareup.picasso.Picasso.Listener"));
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public IListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (IListenerInvoker); }
			}

			static Delegate cb_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_;
#pragma warning disable 0169
			static Delegate GetOnImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_Handler ()
			{
				if (cb_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_ == null)
					cb_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_);
				return cb_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_;
			}

			static void n_OnImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				global::Com.Squareup.Picasso.Picasso.IListener __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.IListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.Picasso p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (native_p0, JniHandleOwnership.DoNotTransfer);
				global::Android.Net.Uri p1 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p1, JniHandleOwnership.DoNotTransfer);
				global::Java.Lang.Exception p2 = global::Java.Lang.Object.GetObject<global::Java.Lang.Exception> (native_p2, JniHandleOwnership.DoNotTransfer);
				__this.OnImageLoadFailed (p0, p1, p2);
			}
#pragma warning restore 0169

			IntPtr id_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_;
			public unsafe void OnImageLoadFailed (global::Com.Squareup.Picasso.Picasso p0, global::Android.Net.Uri p1, global::Java.Lang.Exception p2)
			{
				if (id_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_ == IntPtr.Zero)
					id_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_ = JNIEnv.GetMethodID (class_ref, "onImageLoadFailed", "(Lcom/squareup/picasso/Picasso;Landroid/net/Uri;Ljava/lang/Exception;)V");
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallVoidMethod (Handle, id_onImageLoadFailed_Lcom_squareup_picasso_Picasso_Landroid_net_Uri_Ljava_lang_Exception_, __args);
			}

		}

		public partial class EventArgs : global::System.EventArgs {

			public EventArgs (global::Com.Squareup.Picasso.Picasso p0, global::Android.Net.Uri p1, global::Java.Lang.Exception p2)
			{
				this.p0 = p0;
				this.p1 = p1;
				this.p2 = p2;
			}

			global::Com.Squareup.Picasso.Picasso p0;
			public global::Com.Squareup.Picasso.Picasso P0 {
				get { return p0; }
			}

			global::Android.Net.Uri p1;
			public global::Android.Net.Uri P1 {
				get { return p1; }
			}

			global::Java.Lang.Exception p2;
			public global::Java.Lang.Exception P2 {
				get { return p2; }
			}
		}

		[global::Android.Runtime.Register ("mono/com/squareup/picasso/Picasso_ListenerImplementor")]
		internal sealed partial class IListenerImplementor : global::Java.Lang.Object, IListener {

			object sender;

			public IListenerImplementor (object sender)
				: base (
					global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/squareup/picasso/Picasso_ListenerImplementor", "()V"),
					JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "()V");
				this.sender = sender;
			}

#pragma warning disable 0649
			public EventHandler<EventArgs> Handler;
#pragma warning restore 0649

			public void OnImageLoadFailed (global::Com.Squareup.Picasso.Picasso p0, global::Android.Net.Uri p1, global::Java.Lang.Exception p2)
			{
				var __h = Handler;
				if (__h != null)
					__h (sender, new EventArgs (p0, p1, p2));
			}

			internal static bool __IsEmpty (IListenerImplementor value)
			{
				return value.Handler == null;
			}
		}


		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.LoadedFrom']"
		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$LoadedFrom", DoNotGenerateAcw=true)]
		public sealed partial class LoadedFrom : global::Java.Lang.Enum {


			static IntPtr DISK_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.LoadedFrom']/field[@name='DISK']"
			[Register ("DISK")]
			public static global::Com.Squareup.Picasso.Picasso.LoadedFrom Disk {
				get {
					if (DISK_jfieldId == IntPtr.Zero)
						DISK_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "DISK", "Lcom/squareup/picasso/Picasso$LoadedFrom;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, DISK_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.LoadedFrom> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr MEMORY_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.LoadedFrom']/field[@name='MEMORY']"
			[Register ("MEMORY")]
			public static global::Com.Squareup.Picasso.Picasso.LoadedFrom Memory {
				get {
					if (MEMORY_jfieldId == IntPtr.Zero)
						MEMORY_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "MEMORY", "Lcom/squareup/picasso/Picasso$LoadedFrom;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, MEMORY_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.LoadedFrom> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr NETWORK_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.LoadedFrom']/field[@name='NETWORK']"
			[Register ("NETWORK")]
			public static global::Com.Squareup.Picasso.Picasso.LoadedFrom Network {
				get {
					if (NETWORK_jfieldId == IntPtr.Zero)
						NETWORK_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NETWORK", "Lcom/squareup/picasso/Picasso$LoadedFrom;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NETWORK_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.LoadedFrom> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/squareup/picasso/Picasso$LoadedFrom", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (LoadedFrom); }
			}

			internal LoadedFrom (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_valueOf_Ljava_lang_String_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.LoadedFrom']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/Picasso$LoadedFrom;", "")]
			public static unsafe global::Com.Squareup.Picasso.Picasso.LoadedFrom ValueOf (string p0)
			{
				if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
					id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/Picasso$LoadedFrom;");
				IntPtr native_p0 = JNIEnv.NewString (p0);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_p0);
					global::Com.Squareup.Picasso.Picasso.LoadedFrom __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.LoadedFrom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}

			static IntPtr id_values;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.LoadedFrom']/method[@name='values' and count(parameter)=0]"
			[Register ("values", "()[Lcom/squareup/picasso/Picasso$LoadedFrom;", "")]
			public static unsafe global::Com.Squareup.Picasso.Picasso.LoadedFrom[] Values ()
			{
				if (id_values == IntPtr.Zero)
					id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/squareup/picasso/Picasso$LoadedFrom;");
				try {
					return (global::Com.Squareup.Picasso.Picasso.LoadedFrom[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Squareup.Picasso.Picasso.LoadedFrom));
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Priority']"
		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$Priority", DoNotGenerateAcw=true)]
		public sealed partial class Priority : global::Java.Lang.Enum {


			static IntPtr HIGH_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Priority']/field[@name='HIGH']"
			[Register ("HIGH")]
			public static global::Com.Squareup.Picasso.Picasso.Priority High {
				get {
					if (HIGH_jfieldId == IntPtr.Zero)
						HIGH_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "HIGH", "Lcom/squareup/picasso/Picasso$Priority;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, HIGH_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Priority> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr LOW_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Priority']/field[@name='LOW']"
			[Register ("LOW")]
			public static global::Com.Squareup.Picasso.Picasso.Priority Low {
				get {
					if (LOW_jfieldId == IntPtr.Zero)
						LOW_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "LOW", "Lcom/squareup/picasso/Picasso$Priority;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, LOW_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Priority> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr NORMAL_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Priority']/field[@name='NORMAL']"
			[Register ("NORMAL")]
			public static global::Com.Squareup.Picasso.Picasso.Priority Normal {
				get {
					if (NORMAL_jfieldId == IntPtr.Zero)
						NORMAL_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NORMAL", "Lcom/squareup/picasso/Picasso$Priority;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NORMAL_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Priority> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/squareup/picasso/Picasso$Priority", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Priority); }
			}

			internal Priority (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_valueOf_Ljava_lang_String_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Priority']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/Picasso$Priority;", "")]
			public static unsafe global::Com.Squareup.Picasso.Picasso.Priority ValueOf (string p0)
			{
				if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
					id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/Picasso$Priority;");
				IntPtr native_p0 = JNIEnv.NewString (p0);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_p0);
					global::Com.Squareup.Picasso.Picasso.Priority __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Priority> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}

			static IntPtr id_values;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.Priority']/method[@name='values' and count(parameter)=0]"
			[Register ("values", "()[Lcom/squareup/picasso/Picasso$Priority;", "")]
			public static unsafe global::Com.Squareup.Picasso.Picasso.Priority[] Values ()
			{
				if (id_values == IntPtr.Zero)
					id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/squareup/picasso/Picasso$Priority;");
				try {
					return (global::Com.Squareup.Picasso.Picasso.Priority[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Squareup.Picasso.Picasso.Priority));
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.RequestTransformer.1']"
		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$RequestTransformer$1", DoNotGenerateAcw=true)]
		public partial class RequestTransformer1 : global::Java.Lang.Object, global::Com.Squareup.Picasso.Picasso.IRequestTransformer {


			public static class InterfaceConsts {

				// The following are fields from: com.squareup.picasso.Picasso.RequestTransformer

				static IntPtr IDENTITY_jfieldId;

				// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Picasso.RequestTransformer']/field[@name='IDENTITY']"
				[Register ("IDENTITY")]
				public static global::Com.Squareup.Picasso.Picasso.IRequestTransformer Identity {
					get {
						if (IDENTITY_jfieldId == IntPtr.Zero)
							IDENTITY_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "IDENTITY", "Lcom/squareup/picasso/Picasso$RequestTransformer;");
						IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, IDENTITY_jfieldId);
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.IRequestTransformer> (__ret, JniHandleOwnership.TransferLocalRef);
					}
				}
			}

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/squareup/picasso/Picasso$RequestTransformer$1", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (RequestTransformer1); }
			}

			protected RequestTransformer1 (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static Delegate cb_transformRequest_Lcom_squareup_picasso_Request_;
#pragma warning disable 0169
			static Delegate GetTransformRequest_Lcom_squareup_picasso_Request_Handler ()
			{
				if (cb_transformRequest_Lcom_squareup_picasso_Request_ == null)
					cb_transformRequest_Lcom_squareup_picasso_Request_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_TransformRequest_Lcom_squareup_picasso_Request_);
				return cb_transformRequest_Lcom_squareup_picasso_Request_;
			}

			static IntPtr n_TransformRequest_Lcom_squareup_picasso_Request_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.RequestTransformer1 __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.RequestTransformer1> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.Request p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.TransformRequest (p0));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_transformRequest_Lcom_squareup_picasso_Request_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso.RequestTransformer.1']/method[@name='transformRequest' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Request']]"
			[Register ("transformRequest", "(Lcom/squareup/picasso/Request;)Lcom/squareup/picasso/Request;", "GetTransformRequest_Lcom_squareup_picasso_Request_Handler")]
			public virtual unsafe global::Com.Squareup.Picasso.Request TransformRequest (global::Com.Squareup.Picasso.Request p0)
			{
				if (id_transformRequest_Lcom_squareup_picasso_Request_ == IntPtr.Zero)
					id_transformRequest_Lcom_squareup_picasso_Request_ = JNIEnv.GetMethodID (class_ref, "transformRequest", "(Lcom/squareup/picasso/Request;)Lcom/squareup/picasso/Request;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					global::Com.Squareup.Picasso.Request __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (JNIEnv.CallObjectMethod  (Handle, id_transformRequest_Lcom_squareup_picasso_Request_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "transformRequest", "(Lcom/squareup/picasso/Request;)Lcom/squareup/picasso/Request;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

		}

		[Register ("com/squareup/picasso/Picasso$RequestTransformer")]
		public abstract class RequestTransformer {

			internal RequestTransformer ()
			{
			}

			static IntPtr IDENTITY_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Picasso.RequestTransformer']/field[@name='IDENTITY']"
			[Register ("IDENTITY")]
			public static global::Com.Squareup.Picasso.Picasso.IRequestTransformer Identity {
				get {
					if (IDENTITY_jfieldId == IntPtr.Zero)
						IDENTITY_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "IDENTITY", "Lcom/squareup/picasso/Picasso$RequestTransformer;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, IDENTITY_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.IRequestTransformer> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr class_ref = JNIEnv.FindClass ("com/squareup/picasso/Picasso$RequestTransformer");
		}

		[global::System.Obsolete ("Use the 'RequestTransformer' type. This type will be removed in a future release.")]
		public abstract class RequestTransformerConsts : RequestTransformer {

			private RequestTransformerConsts ()
			{
			}
		}

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Picasso.RequestTransformer']"
		[Register ("com/squareup/picasso/Picasso$RequestTransformer", "", "Com.Squareup.Picasso.Picasso/IRequestTransformerInvoker")]
		public partial interface IRequestTransformer : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/interface[@name='Picasso.RequestTransformer']/method[@name='transformRequest' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Request']]"
			[Register ("transformRequest", "(Lcom/squareup/picasso/Request;)Lcom/squareup/picasso/Request;", "GetTransformRequest_Lcom_squareup_picasso_Request_Handler:Com.Squareup.Picasso.Picasso/IRequestTransformerInvoker, Picasso")]
			global::Com.Squareup.Picasso.Request TransformRequest (global::Com.Squareup.Picasso.Request p0);

		}

		[global::Android.Runtime.Register ("com/squareup/picasso/Picasso$RequestTransformer", DoNotGenerateAcw=true)]
		internal class IRequestTransformerInvoker : global::Java.Lang.Object, IRequestTransformer {

			static IntPtr java_class_ref = JNIEnv.FindClass ("com/squareup/picasso/Picasso$RequestTransformer");
			IntPtr class_ref;

			public static IRequestTransformer GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<IRequestTransformer> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
								JNIEnv.GetClassNameFromInstance (handle), "com.squareup.picasso.Picasso.RequestTransformer"));
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public IRequestTransformerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (IRequestTransformerInvoker); }
			}

			static Delegate cb_transformRequest_Lcom_squareup_picasso_Request_;
#pragma warning disable 0169
			static Delegate GetTransformRequest_Lcom_squareup_picasso_Request_Handler ()
			{
				if (cb_transformRequest_Lcom_squareup_picasso_Request_ == null)
					cb_transformRequest_Lcom_squareup_picasso_Request_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_TransformRequest_Lcom_squareup_picasso_Request_);
				return cb_transformRequest_Lcom_squareup_picasso_Request_;
			}

			static IntPtr n_TransformRequest_Lcom_squareup_picasso_Request_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				global::Com.Squareup.Picasso.Picasso.IRequestTransformer __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.IRequestTransformer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Com.Squareup.Picasso.Request p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (native_p0, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.TransformRequest (p0));
				return __ret;
			}
#pragma warning restore 0169

			IntPtr id_transformRequest_Lcom_squareup_picasso_Request_;
			public unsafe global::Com.Squareup.Picasso.Request TransformRequest (global::Com.Squareup.Picasso.Request p0)
			{
				if (id_transformRequest_Lcom_squareup_picasso_Request_ == IntPtr.Zero)
					id_transformRequest_Lcom_squareup_picasso_Request_ = JNIEnv.GetMethodID (class_ref, "transformRequest", "(Lcom/squareup/picasso/Request;)Lcom/squareup/picasso/Request;");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Squareup.Picasso.Request __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (JNIEnv.CallObjectMethod (Handle, id_transformRequest_Lcom_squareup_picasso_Request_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}

		}


		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/Picasso", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Picasso); }
		}

		protected Picasso (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_isDebugging;
#pragma warning disable 0169
		static Delegate GetIsDebuggingHandler ()
		{
			if (cb_isDebugging == null)
				cb_isDebugging = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsDebugging);
			return cb_isDebugging;
		}

		static bool n_IsDebugging (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Debugging;
		}
#pragma warning restore 0169

		static Delegate cb_setDebugging_Z;
#pragma warning disable 0169
		static Delegate GetSetDebugging_ZHandler ()
		{
			if (cb_setDebugging_Z == null)
				cb_setDebugging_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetDebugging_Z);
			return cb_setDebugging_Z;
		}

		static void n_SetDebugging_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Debugging = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isDebugging;
		static IntPtr id_setDebugging_Z;
		[Obsolete (@"deprecated")]
		public virtual unsafe bool Debugging {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='isDebugging' and count(parameter)=0]"
			[Register ("isDebugging", "()Z", "GetIsDebuggingHandler")]
			get {
				if (id_isDebugging == IntPtr.Zero)
					id_isDebugging = JNIEnv.GetMethodID (class_ref, "isDebugging", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod  (Handle, id_isDebugging);
					else
						return JNIEnv.CallNonvirtualBooleanMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isDebugging", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='setDebugging' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setDebugging", "(Z)V", "GetSetDebugging_ZHandler")]
			set {
				if (id_setDebugging_Z == IntPtr.Zero)
					id_setDebugging_Z = JNIEnv.GetMethodID (class_ref, "setDebugging", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod  (Handle, id_setDebugging_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setDebugging", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isLoggingEnabled;
#pragma warning disable 0169
		static Delegate GetIsLoggingEnabledHandler ()
		{
			if (cb_isLoggingEnabled == null)
				cb_isLoggingEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsLoggingEnabled);
			return cb_isLoggingEnabled;
		}

		static bool n_IsLoggingEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.LoggingEnabled;
		}
#pragma warning restore 0169

		static Delegate cb_setLoggingEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetLoggingEnabled_ZHandler ()
		{
			if (cb_setLoggingEnabled_Z == null)
				cb_setLoggingEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetLoggingEnabled_Z);
			return cb_setLoggingEnabled_Z;
		}

		static void n_SetLoggingEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.LoggingEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isLoggingEnabled;
		static IntPtr id_setLoggingEnabled_Z;
		public virtual unsafe bool LoggingEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='isLoggingEnabled' and count(parameter)=0]"
			[Register ("isLoggingEnabled", "()Z", "GetIsLoggingEnabledHandler")]
			get {
				if (id_isLoggingEnabled == IntPtr.Zero)
					id_isLoggingEnabled = JNIEnv.GetMethodID (class_ref, "isLoggingEnabled", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod  (Handle, id_isLoggingEnabled);
					else
						return JNIEnv.CallNonvirtualBooleanMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isLoggingEnabled", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='setLoggingEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setLoggingEnabled", "(Z)V", "GetSetLoggingEnabled_ZHandler")]
			set {
				if (id_setLoggingEnabled_Z == IntPtr.Zero)
					id_setLoggingEnabled_Z = JNIEnv.GetMethodID (class_ref, "setLoggingEnabled", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod  (Handle, id_setLoggingEnabled_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setLoggingEnabled", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getSnapshot;
#pragma warning disable 0169
		static Delegate GetGetSnapshotHandler ()
		{
			if (cb_getSnapshot == null)
				cb_getSnapshot = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSnapshot);
			return cb_getSnapshot;
		}

		static IntPtr n_GetSnapshot (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Snapshot);
		}
#pragma warning restore 0169

		static IntPtr id_getSnapshot;
		public virtual unsafe global::Com.Squareup.Picasso.StatsSnapshot Snapshot {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='getSnapshot' and count(parameter)=0]"
			[Register ("getSnapshot", "()Lcom/squareup/picasso/StatsSnapshot;", "GetGetSnapshotHandler")]
			get {
				if (id_getSnapshot == IntPtr.Zero)
					id_getSnapshot = JNIEnv.GetMethodID (class_ref, "getSnapshot", "()Lcom/squareup/picasso/StatsSnapshot;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.StatsSnapshot> (JNIEnv.CallObjectMethod  (Handle, id_getSnapshot), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.StatsSnapshot> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSnapshot", "()Lcom/squareup/picasso/StatsSnapshot;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_areIndicatorsEnabled;
#pragma warning disable 0169
		static Delegate GetAreIndicatorsEnabledHandler ()
		{
			if (cb_areIndicatorsEnabled == null)
				cb_areIndicatorsEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_AreIndicatorsEnabled);
			return cb_areIndicatorsEnabled;
		}

		static bool n_AreIndicatorsEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.AreIndicatorsEnabled ();
		}
#pragma warning restore 0169

		static IntPtr id_areIndicatorsEnabled;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='areIndicatorsEnabled' and count(parameter)=0]"
		[Register ("areIndicatorsEnabled", "()Z", "GetAreIndicatorsEnabledHandler")]
		public virtual unsafe bool AreIndicatorsEnabled ()
		{
			if (id_areIndicatorsEnabled == IntPtr.Zero)
				id_areIndicatorsEnabled = JNIEnv.GetMethodID (class_ref, "areIndicatorsEnabled", "()Z");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.CallBooleanMethod  (Handle, id_areIndicatorsEnabled);
				else
					return JNIEnv.CallNonvirtualBooleanMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "areIndicatorsEnabled", "()Z"));
			} finally {
			}
		}

		static Delegate cb_cancelRequest_Landroid_widget_ImageView_;
#pragma warning disable 0169
		static Delegate GetCancelRequest_Landroid_widget_ImageView_Handler ()
		{
			if (cb_cancelRequest_Landroid_widget_ImageView_ == null)
				cb_cancelRequest_Landroid_widget_ImageView_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_CancelRequest_Landroid_widget_ImageView_);
			return cb_cancelRequest_Landroid_widget_ImageView_;
		}

		static void n_CancelRequest_Landroid_widget_ImageView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.ImageView p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.ImageView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CancelRequest (p0);
		}
#pragma warning restore 0169

		static IntPtr id_cancelRequest_Landroid_widget_ImageView_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='cancelRequest' and count(parameter)=1 and parameter[1][@type='android.widget.ImageView']]"
		[Register ("cancelRequest", "(Landroid/widget/ImageView;)V", "GetCancelRequest_Landroid_widget_ImageView_Handler")]
		public virtual unsafe void CancelRequest (global::Android.Widget.ImageView p0)
		{
			if (id_cancelRequest_Landroid_widget_ImageView_ == IntPtr.Zero)
				id_cancelRequest_Landroid_widget_ImageView_ = JNIEnv.GetMethodID (class_ref, "cancelRequest", "(Landroid/widget/ImageView;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_cancelRequest_Landroid_widget_ImageView_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelRequest", "(Landroid/widget/ImageView;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_cancelRequest_Landroid_widget_RemoteViews_I;
#pragma warning disable 0169
		static Delegate GetCancelRequest_Landroid_widget_RemoteViews_IHandler ()
		{
			if (cb_cancelRequest_Landroid_widget_RemoteViews_I == null)
				cb_cancelRequest_Landroid_widget_RemoteViews_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int>) n_CancelRequest_Landroid_widget_RemoteViews_I);
			return cb_cancelRequest_Landroid_widget_RemoteViews_I;
		}

		static void n_CancelRequest_Landroid_widget_RemoteViews_I (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RemoteViews p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RemoteViews> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CancelRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_cancelRequest_Landroid_widget_RemoteViews_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='cancelRequest' and count(parameter)=2 and parameter[1][@type='android.widget.RemoteViews'] and parameter[2][@type='int']]"
		[Register ("cancelRequest", "(Landroid/widget/RemoteViews;I)V", "GetCancelRequest_Landroid_widget_RemoteViews_IHandler")]
		public virtual unsafe void CancelRequest (global::Android.Widget.RemoteViews p0, int p1)
		{
			if (id_cancelRequest_Landroid_widget_RemoteViews_I == IntPtr.Zero)
				id_cancelRequest_Landroid_widget_RemoteViews_I = JNIEnv.GetMethodID (class_ref, "cancelRequest", "(Landroid/widget/RemoteViews;I)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_cancelRequest_Landroid_widget_RemoteViews_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelRequest", "(Landroid/widget/RemoteViews;I)V"), __args);
			} finally {
			}
		}

		static Delegate cb_cancelRequest_Lcom_squareup_picasso_Target_;
#pragma warning disable 0169
		static Delegate GetCancelRequest_Lcom_squareup_picasso_Target_Handler ()
		{
			if (cb_cancelRequest_Lcom_squareup_picasso_Target_ == null)
				cb_cancelRequest_Lcom_squareup_picasso_Target_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_CancelRequest_Lcom_squareup_picasso_Target_);
			return cb_cancelRequest_Lcom_squareup_picasso_Target_;
		}

		static void n_CancelRequest_Lcom_squareup_picasso_Target_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.ITarget p0 = (global::Com.Squareup.Picasso.ITarget)global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.ITarget> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CancelRequest (p0);
		}
#pragma warning restore 0169

		static IntPtr id_cancelRequest_Lcom_squareup_picasso_Target_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='cancelRequest' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Target']]"
		[Register ("cancelRequest", "(Lcom/squareup/picasso/Target;)V", "GetCancelRequest_Lcom_squareup_picasso_Target_Handler")]
		public virtual unsafe void CancelRequest (global::Com.Squareup.Picasso.ITarget p0)
		{
			if (id_cancelRequest_Lcom_squareup_picasso_Target_ == IntPtr.Zero)
				id_cancelRequest_Lcom_squareup_picasso_Target_ = JNIEnv.GetMethodID (class_ref, "cancelRequest", "(Lcom/squareup/picasso/Target;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_cancelRequest_Lcom_squareup_picasso_Target_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelRequest", "(Lcom/squareup/picasso/Target;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_cancelTag_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetCancelTag_Ljava_lang_Object_Handler ()
		{
			if (cb_cancelTag_Ljava_lang_Object_ == null)
				cb_cancelTag_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_CancelTag_Ljava_lang_Object_);
			return cb_cancelTag_Ljava_lang_Object_;
		}

		static void n_CancelTag_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CancelTag (p0);
		}
#pragma warning restore 0169

		static IntPtr id_cancelTag_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='cancelTag' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("cancelTag", "(Ljava/lang/Object;)V", "GetCancelTag_Ljava_lang_Object_Handler")]
		public virtual unsafe void CancelTag (global::Java.Lang.Object p0)
		{
			if (id_cancelTag_Ljava_lang_Object_ == IntPtr.Zero)
				id_cancelTag_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "cancelTag", "(Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_cancelTag_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelTag", "(Ljava/lang/Object;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_invalidate_Landroid_net_Uri_;
#pragma warning disable 0169
		static Delegate GetInvalidate_Landroid_net_Uri_Handler ()
		{
			if (cb_invalidate_Landroid_net_Uri_ == null)
				cb_invalidate_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Invalidate_Landroid_net_Uri_);
			return cb_invalidate_Landroid_net_Uri_;
		}

		static void n_Invalidate_Landroid_net_Uri_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri p0 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Invalidate (p0);
		}
#pragma warning restore 0169

		static IntPtr id_invalidate_Landroid_net_Uri_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='invalidate' and count(parameter)=1 and parameter[1][@type='android.net.Uri']]"
		[Register ("invalidate", "(Landroid/net/Uri;)V", "GetInvalidate_Landroid_net_Uri_Handler")]
		public virtual unsafe void Invalidate (global::Android.Net.Uri p0)
		{
			if (id_invalidate_Landroid_net_Uri_ == IntPtr.Zero)
				id_invalidate_Landroid_net_Uri_ = JNIEnv.GetMethodID (class_ref, "invalidate", "(Landroid/net/Uri;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_invalidate_Landroid_net_Uri_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "invalidate", "(Landroid/net/Uri;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_invalidate_Ljava_io_File_;
#pragma warning disable 0169
		static Delegate GetInvalidate_Ljava_io_File_Handler ()
		{
			if (cb_invalidate_Ljava_io_File_ == null)
				cb_invalidate_Ljava_io_File_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Invalidate_Ljava_io_File_);
			return cb_invalidate_Ljava_io_File_;
		}

		static void n_Invalidate_Ljava_io_File_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Invalidate (p0);
		}
#pragma warning restore 0169

		static IntPtr id_invalidate_Ljava_io_File_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='invalidate' and count(parameter)=1 and parameter[1][@type='java.io.File']]"
		[Register ("invalidate", "(Ljava/io/File;)V", "GetInvalidate_Ljava_io_File_Handler")]
		public virtual unsafe void Invalidate (global::Java.IO.File p0)
		{
			if (id_invalidate_Ljava_io_File_ == IntPtr.Zero)
				id_invalidate_Ljava_io_File_ = JNIEnv.GetMethodID (class_ref, "invalidate", "(Ljava/io/File;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_invalidate_Ljava_io_File_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "invalidate", "(Ljava/io/File;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_invalidate_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetInvalidate_Ljava_lang_String_Handler ()
		{
			if (cb_invalidate_Ljava_lang_String_ == null)
				cb_invalidate_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Invalidate_Ljava_lang_String_);
			return cb_invalidate_Ljava_lang_String_;
		}

		static void n_Invalidate_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Invalidate (p0);
		}
#pragma warning restore 0169

		static IntPtr id_invalidate_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='invalidate' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("invalidate", "(Ljava/lang/String;)V", "GetInvalidate_Ljava_lang_String_Handler")]
		public virtual unsafe void Invalidate (string p0)
		{
			if (id_invalidate_Ljava_lang_String_ == IntPtr.Zero)
				id_invalidate_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "invalidate", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_invalidate_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "invalidate", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_load_Landroid_net_Uri_;
#pragma warning disable 0169
		static Delegate GetLoad_Landroid_net_Uri_Handler ()
		{
			if (cb_load_Landroid_net_Uri_ == null)
				cb_load_Landroid_net_Uri_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Load_Landroid_net_Uri_);
			return cb_load_Landroid_net_Uri_;
		}

		static IntPtr n_Load_Landroid_net_Uri_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri p0 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Load (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_load_Landroid_net_Uri_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='load' and count(parameter)=1 and parameter[1][@type='android.net.Uri']]"
		[Register ("load", "(Landroid/net/Uri;)Lcom/squareup/picasso/RequestCreator;", "GetLoad_Landroid_net_Uri_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Load (global::Android.Net.Uri p0)
		{
			if (id_load_Landroid_net_Uri_ == IntPtr.Zero)
				id_load_Landroid_net_Uri_ = JNIEnv.GetMethodID (class_ref, "load", "(Landroid/net/Uri;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_load_Landroid_net_Uri_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "load", "(Landroid/net/Uri;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_load_I;
#pragma warning disable 0169
		static Delegate GetLoad_IHandler ()
		{
			if (cb_load_I == null)
				cb_load_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_Load_I);
			return cb_load_I;
		}

		static IntPtr n_Load_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Load (p0));
		}
#pragma warning restore 0169

		static IntPtr id_load_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='load' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("load", "(I)Lcom/squareup/picasso/RequestCreator;", "GetLoad_IHandler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Load (int p0)
		{
			if (id_load_I == IntPtr.Zero)
				id_load_I = JNIEnv.GetMethodID (class_ref, "load", "(I)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_load_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "load", "(I)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_load_Ljava_io_File_;
#pragma warning disable 0169
		static Delegate GetLoad_Ljava_io_File_Handler ()
		{
			if (cb_load_Ljava_io_File_ == null)
				cb_load_Ljava_io_File_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Load_Ljava_io_File_);
			return cb_load_Ljava_io_File_;
		}

		static IntPtr n_Load_Ljava_io_File_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Load (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_load_Ljava_io_File_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='load' and count(parameter)=1 and parameter[1][@type='java.io.File']]"
		[Register ("load", "(Ljava/io/File;)Lcom/squareup/picasso/RequestCreator;", "GetLoad_Ljava_io_File_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Load (global::Java.IO.File p0)
		{
			if (id_load_Ljava_io_File_ == IntPtr.Zero)
				id_load_Ljava_io_File_ = JNIEnv.GetMethodID (class_ref, "load", "(Ljava/io/File;)Lcom/squareup/picasso/RequestCreator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_load_Ljava_io_File_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "load", "(Ljava/io/File;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_load_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetLoad_Ljava_lang_String_Handler ()
		{
			if (cb_load_Ljava_lang_String_ == null)
				cb_load_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Load_Ljava_lang_String_);
			return cb_load_Ljava_lang_String_;
		}

		static IntPtr n_Load_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Load (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_load_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='load' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("load", "(Ljava/lang/String;)Lcom/squareup/picasso/RequestCreator;", "GetLoad_Ljava_lang_String_Handler")]
		public virtual unsafe global::Com.Squareup.Picasso.RequestCreator Load (string p0)
		{
			if (id_load_Ljava_lang_String_ == IntPtr.Zero)
				id_load_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "load", "(Ljava/lang/String;)Lcom/squareup/picasso/RequestCreator;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Squareup.Picasso.RequestCreator __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallObjectMethod  (Handle, id_load_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestCreator> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "load", "(Ljava/lang/String;)Lcom/squareup/picasso/RequestCreator;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_pauseTag_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetPauseTag_Ljava_lang_Object_Handler ()
		{
			if (cb_pauseTag_Ljava_lang_Object_ == null)
				cb_pauseTag_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_PauseTag_Ljava_lang_Object_);
			return cb_pauseTag_Ljava_lang_Object_;
		}

		static void n_PauseTag_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PauseTag (p0);
		}
#pragma warning restore 0169

		static IntPtr id_pauseTag_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='pauseTag' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("pauseTag", "(Ljava/lang/Object;)V", "GetPauseTag_Ljava_lang_Object_Handler")]
		public virtual unsafe void PauseTag (global::Java.Lang.Object p0)
		{
			if (id_pauseTag_Ljava_lang_Object_ == IntPtr.Zero)
				id_pauseTag_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "pauseTag", "(Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_pauseTag_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pauseTag", "(Ljava/lang/Object;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_resumeTag_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetResumeTag_Ljava_lang_Object_Handler ()
		{
			if (cb_resumeTag_Ljava_lang_Object_ == null)
				cb_resumeTag_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ResumeTag_Ljava_lang_Object_);
			return cb_resumeTag_Ljava_lang_Object_;
		}

		static void n_ResumeTag_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ResumeTag (p0);
		}
#pragma warning restore 0169

		static IntPtr id_resumeTag_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='resumeTag' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("resumeTag", "(Ljava/lang/Object;)V", "GetResumeTag_Ljava_lang_Object_Handler")]
		public virtual unsafe void ResumeTag (global::Java.Lang.Object p0)
		{
			if (id_resumeTag_Ljava_lang_Object_ == IntPtr.Zero)
				id_resumeTag_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "resumeTag", "(Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_resumeTag_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "resumeTag", "(Ljava/lang/Object;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setIndicatorsEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetIndicatorsEnabled_ZHandler ()
		{
			if (cb_setIndicatorsEnabled_Z == null)
				cb_setIndicatorsEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetIndicatorsEnabled_Z);
			return cb_setIndicatorsEnabled_Z;
		}

		static void n_SetIndicatorsEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetIndicatorsEnabled (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setIndicatorsEnabled_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='setIndicatorsEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setIndicatorsEnabled", "(Z)V", "GetSetIndicatorsEnabled_ZHandler")]
		public virtual unsafe void SetIndicatorsEnabled (bool p0)
		{
			if (id_setIndicatorsEnabled_Z == IntPtr.Zero)
				id_setIndicatorsEnabled_Z = JNIEnv.GetMethodID (class_ref, "setIndicatorsEnabled", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_setIndicatorsEnabled_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setIndicatorsEnabled", "(Z)V"), __args);
			} finally {
			}
		}

		static IntPtr id_setSingletonInstance_Lcom_squareup_picasso_Picasso_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='setSingletonInstance' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Picasso']]"
		[Register ("setSingletonInstance", "(Lcom/squareup/picasso/Picasso;)V", "")]
		public static unsafe void SetSingletonInstance (global::Com.Squareup.Picasso.Picasso p0)
		{
			if (id_setSingletonInstance_Lcom_squareup_picasso_Picasso_ == IntPtr.Zero)
				id_setSingletonInstance_Lcom_squareup_picasso_Picasso_ = JNIEnv.GetStaticMethodID (class_ref, "setSingletonInstance", "(Lcom/squareup/picasso/Picasso;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setSingletonInstance_Lcom_squareup_picasso_Picasso_, __args);
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
			global::Com.Squareup.Picasso.Picasso __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Shutdown ();
		}
#pragma warning restore 0169

		static IntPtr id_shutdown;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='shutdown' and count(parameter)=0]"
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

		static IntPtr id_with_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Picasso']/method[@name='with' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("with", "(Landroid/content/Context;)Lcom/squareup/picasso/Picasso;", "")]
		public static unsafe global::Com.Squareup.Picasso.Picasso With (global::Android.Content.Context p0)
		{
			if (id_with_Landroid_content_Context_ == IntPtr.Zero)
				id_with_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "with", "(Landroid/content/Context;)Lcom/squareup/picasso/Picasso;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Squareup.Picasso.Picasso __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso> (JNIEnv.CallStaticObjectMethod  (class_ref, id_with_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
