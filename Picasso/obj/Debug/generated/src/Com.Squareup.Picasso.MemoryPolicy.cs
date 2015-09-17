using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='MemoryPolicy']"
	[global::Android.Runtime.Register ("com/squareup/picasso/MemoryPolicy", DoNotGenerateAcw=true)]
	public sealed partial class MemoryPolicy : global::Java.Lang.Enum {


		static IntPtr NO_CACHE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='MemoryPolicy']/field[@name='NO_CACHE']"
		[Register ("NO_CACHE")]
		public static global::Com.Squareup.Picasso.MemoryPolicy NoCache {
			get {
				if (NO_CACHE_jfieldId == IntPtr.Zero)
					NO_CACHE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NO_CACHE", "Lcom/squareup/picasso/MemoryPolicy;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NO_CACHE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.MemoryPolicy> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr NO_STORE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='MemoryPolicy']/field[@name='NO_STORE']"
		[Register ("NO_STORE")]
		public static global::Com.Squareup.Picasso.MemoryPolicy NoStore {
			get {
				if (NO_STORE_jfieldId == IntPtr.Zero)
					NO_STORE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NO_STORE", "Lcom/squareup/picasso/MemoryPolicy;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NO_STORE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.MemoryPolicy> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/MemoryPolicy", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MemoryPolicy); }
		}

		internal MemoryPolicy (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_valueOf_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='MemoryPolicy']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/MemoryPolicy;", "")]
		public static unsafe global::Com.Squareup.Picasso.MemoryPolicy ValueOf (string p0)
		{
			if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
				id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/MemoryPolicy;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Squareup.Picasso.MemoryPolicy __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.MemoryPolicy> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_values;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='MemoryPolicy']/method[@name='values' and count(parameter)=0]"
		[Register ("values", "()[Lcom/squareup/picasso/MemoryPolicy;", "")]
		public static unsafe global::Com.Squareup.Picasso.MemoryPolicy[] Values ()
		{
			if (id_values == IntPtr.Zero)
				id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/squareup/picasso/MemoryPolicy;");
			try {
				return (global::Com.Squareup.Picasso.MemoryPolicy[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Squareup.Picasso.MemoryPolicy));
			} finally {
			}
		}

	}
}
