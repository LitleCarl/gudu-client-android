using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler']"
	[global::Android.Runtime.Register ("com/squareup/picasso/RequestHandler", DoNotGenerateAcw=true)]
	public abstract partial class RequestHandler : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler.Result']"
		[global::Android.Runtime.Register ("com/squareup/picasso/RequestHandler$Result", DoNotGenerateAcw=true)]
		public sealed partial class Result : global::Java.Lang.Object {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/squareup/picasso/RequestHandler$Result", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Result); }
			}

			internal Result (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler.Result']/constructor[@name='RequestHandler.Result' and count(parameter)=2 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='com.squareup.picasso.Picasso.LoadedFrom']]"
			[Register (".ctor", "(Landroid/graphics/Bitmap;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", "")]
			public unsafe Result (global::Android.Graphics.Bitmap p0, global::Com.Squareup.Picasso.Picasso.LoadedFrom p1)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (Handle != IntPtr.Zero)
					return;

				try {
					JValue* __args = stackalloc JValue [2];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					if (GetType () != typeof (Result)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/graphics/Bitmap;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Landroid/graphics/Bitmap;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", __args);
						return;
					}

					if (id_ctor_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ == IntPtr.Zero)
						id_ctor_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/graphics/Bitmap;Lcom/squareup/picasso/Picasso$LoadedFrom;)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Landroid_graphics_Bitmap_Lcom_squareup_picasso_Picasso_LoadedFrom_, __args);
				} finally {
				}
			}

			static IntPtr id_ctor_Ljava_io_InputStream_Lcom_squareup_picasso_Picasso_LoadedFrom_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler.Result']/constructor[@name='RequestHandler.Result' and count(parameter)=2 and parameter[1][@type='java.io.InputStream'] and parameter[2][@type='com.squareup.picasso.Picasso.LoadedFrom']]"
			[Register (".ctor", "(Ljava/io/InputStream;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", "")]
			public unsafe Result (global::System.IO.Stream p0, global::Com.Squareup.Picasso.Picasso.LoadedFrom p1)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (Handle != IntPtr.Zero)
					return;

				IntPtr native_p0 = global::Android.Runtime.InputStreamAdapter.ToLocalJniHandle (p0);
				try {
					JValue* __args = stackalloc JValue [2];
					__args [0] = new JValue (native_p0);
					__args [1] = new JValue (p1);
					if (GetType () != typeof (Result)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/io/InputStream;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Ljava/io/InputStream;Lcom/squareup/picasso/Picasso$LoadedFrom;)V", __args);
						return;
					}

					if (id_ctor_Ljava_io_InputStream_Lcom_squareup_picasso_Picasso_LoadedFrom_ == IntPtr.Zero)
						id_ctor_Ljava_io_InputStream_Lcom_squareup_picasso_Picasso_LoadedFrom_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/io/InputStream;Lcom/squareup/picasso/Picasso$LoadedFrom;)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_io_InputStream_Lcom_squareup_picasso_Picasso_LoadedFrom_, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Ljava_io_InputStream_Lcom_squareup_picasso_Picasso_LoadedFrom_, __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}

			static IntPtr id_getBitmap;
			public unsafe global::Android.Graphics.Bitmap Bitmap {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler.Result']/method[@name='getBitmap' and count(parameter)=0]"
				[Register ("getBitmap", "()Landroid/graphics/Bitmap;", "GetGetBitmapHandler")]
				get {
					if (id_getBitmap == IntPtr.Zero)
						id_getBitmap = JNIEnv.GetMethodID (class_ref, "getBitmap", "()Landroid/graphics/Bitmap;");
					try {
						return global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallObjectMethod  (Handle, id_getBitmap), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getLoadedFrom;
			public unsafe global::Com.Squareup.Picasso.Picasso.LoadedFrom LoadedFrom {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler.Result']/method[@name='getLoadedFrom' and count(parameter)=0]"
				[Register ("getLoadedFrom", "()Lcom/squareup/picasso/Picasso$LoadedFrom;", "GetGetLoadedFromHandler")]
				get {
					if (id_getLoadedFrom == IntPtr.Zero)
						id_getLoadedFrom = JNIEnv.GetMethodID (class_ref, "getLoadedFrom", "()Lcom/squareup/picasso/Picasso$LoadedFrom;");
					try {
						return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.LoadedFrom> (JNIEnv.CallObjectMethod  (Handle, id_getLoadedFrom), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getStream;
			public unsafe global::System.IO.Stream Stream {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler.Result']/method[@name='getStream' and count(parameter)=0]"
				[Register ("getStream", "()Ljava/io/InputStream;", "GetGetStreamHandler")]
				get {
					if (id_getStream == IntPtr.Zero)
						id_getStream = JNIEnv.GetMethodID (class_ref, "getStream", "()Ljava/io/InputStream;");
					try {
						return global::Android.Runtime.InputStreamInvoker.FromJniHandle (JNIEnv.CallObjectMethod  (Handle, id_getStream), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/RequestHandler", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RequestHandler); }
		}

		protected RequestHandler (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler']/constructor[@name='RequestHandler' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe RequestHandler ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (RequestHandler)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "()V");
					return;
				}

				if (id_ctor == IntPtr.Zero)
					id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor);
			} finally {
			}
		}

		static Delegate cb_canHandleRequest_Lcom_squareup_picasso_Request_;
#pragma warning disable 0169
		static Delegate GetCanHandleRequest_Lcom_squareup_picasso_Request_Handler ()
		{
			if (cb_canHandleRequest_Lcom_squareup_picasso_Request_ == null)
				cb_canHandleRequest_Lcom_squareup_picasso_Request_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_CanHandleRequest_Lcom_squareup_picasso_Request_);
			return cb_canHandleRequest_Lcom_squareup_picasso_Request_;
		}

		static bool n_CanHandleRequest_Lcom_squareup_picasso_Request_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.RequestHandler __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.Request p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.CanHandleRequest (p0);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler']/method[@name='canHandleRequest' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Request']]"
		[Register ("canHandleRequest", "(Lcom/squareup/picasso/Request;)Z", "GetCanHandleRequest_Lcom_squareup_picasso_Request_Handler")]
		public abstract bool CanHandleRequest (global::Com.Squareup.Picasso.Request p0);

		static Delegate cb_load_Lcom_squareup_picasso_Request_I;
#pragma warning disable 0169
		static Delegate GetLoad_Lcom_squareup_picasso_Request_IHandler ()
		{
			if (cb_load_Lcom_squareup_picasso_Request_I == null)
				cb_load_Lcom_squareup_picasso_Request_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, IntPtr>) n_Load_Lcom_squareup_picasso_Request_I);
			return cb_load_Lcom_squareup_picasso_Request_I;
		}

		static IntPtr n_Load_Lcom_squareup_picasso_Request_I (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
		{
			global::Com.Squareup.Picasso.RequestHandler __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Squareup.Picasso.Request p0 = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Load (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler']/method[@name='load' and count(parameter)=2 and parameter[1][@type='com.squareup.picasso.Request'] and parameter[2][@type='int']]"
		[Register ("load", "(Lcom/squareup/picasso/Request;I)Lcom/squareup/picasso/RequestHandler$Result;", "GetLoad_Lcom_squareup_picasso_Request_IHandler")]
		public abstract global::Com.Squareup.Picasso.RequestHandler.Result Load (global::Com.Squareup.Picasso.Request p0, int p1);

	}

	[global::Android.Runtime.Register ("com/squareup/picasso/RequestHandler", DoNotGenerateAcw=true)]
	internal partial class RequestHandlerInvoker : RequestHandler {

		public RequestHandlerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (handle, transfer) {}

		protected override global::System.Type ThresholdType {
			get { return typeof (RequestHandlerInvoker); }
		}

		static IntPtr id_canHandleRequest_Lcom_squareup_picasso_Request_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler']/method[@name='canHandleRequest' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Request']]"
		[Register ("canHandleRequest", "(Lcom/squareup/picasso/Request;)Z", "GetCanHandleRequest_Lcom_squareup_picasso_Request_Handler")]
		public override unsafe bool CanHandleRequest (global::Com.Squareup.Picasso.Request p0)
		{
			if (id_canHandleRequest_Lcom_squareup_picasso_Request_ == IntPtr.Zero)
				id_canHandleRequest_Lcom_squareup_picasso_Request_ = JNIEnv.GetMethodID (class_ref, "canHandleRequest", "(Lcom/squareup/picasso/Request;)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				bool __ret = JNIEnv.CallBooleanMethod  (Handle, id_canHandleRequest_Lcom_squareup_picasso_Request_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_load_Lcom_squareup_picasso_Request_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='RequestHandler']/method[@name='load' and count(parameter)=2 and parameter[1][@type='com.squareup.picasso.Request'] and parameter[2][@type='int']]"
		[Register ("load", "(Lcom/squareup/picasso/Request;I)Lcom/squareup/picasso/RequestHandler$Result;", "GetLoad_Lcom_squareup_picasso_Request_IHandler")]
		public override unsafe global::Com.Squareup.Picasso.RequestHandler.Result Load (global::Com.Squareup.Picasso.Request p0, int p1)
		{
			if (id_load_Lcom_squareup_picasso_Request_I == IntPtr.Zero)
				id_load_Lcom_squareup_picasso_Request_I = JNIEnv.GetMethodID (class_ref, "load", "(Lcom/squareup/picasso/Request;I)Lcom/squareup/picasso/RequestHandler$Result;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Com.Squareup.Picasso.RequestHandler.Result __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.RequestHandler.Result> (JNIEnv.CallObjectMethod  (Handle, id_load_Lcom_squareup_picasso_Request_I, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}

}
