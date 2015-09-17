using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']"
	[global::Android.Runtime.Register ("com/squareup/picasso/NetworkPolicy", DoNotGenerateAcw=true)]
	public sealed partial class NetworkPolicy : global::Java.Lang.Enum {


		static IntPtr NO_CACHE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/field[@name='NO_CACHE']"
		[Register ("NO_CACHE")]
		public static global::Com.Squareup.Picasso.NetworkPolicy NoCache {
			get {
				if (NO_CACHE_jfieldId == IntPtr.Zero)
					NO_CACHE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NO_CACHE", "Lcom/squareup/picasso/NetworkPolicy;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NO_CACHE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.NetworkPolicy> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr NO_STORE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/field[@name='NO_STORE']"
		[Register ("NO_STORE")]
		public static global::Com.Squareup.Picasso.NetworkPolicy NoStore {
			get {
				if (NO_STORE_jfieldId == IntPtr.Zero)
					NO_STORE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NO_STORE", "Lcom/squareup/picasso/NetworkPolicy;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NO_STORE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.NetworkPolicy> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr OFFLINE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/field[@name='OFFLINE']"
		[Register ("OFFLINE")]
		public static global::Com.Squareup.Picasso.NetworkPolicy Offline {
			get {
				if (OFFLINE_jfieldId == IntPtr.Zero)
					OFFLINE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "OFFLINE", "Lcom/squareup/picasso/NetworkPolicy;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, OFFLINE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.NetworkPolicy> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/NetworkPolicy", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (NetworkPolicy); }
		}

		internal NetworkPolicy (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_isOfflineOnly_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/method[@name='isOfflineOnly' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("isOfflineOnly", "(I)Z", "")]
		public static unsafe bool IsOfflineOnly (int p0)
		{
			if (id_isOfflineOnly_I == IntPtr.Zero)
				id_isOfflineOnly_I = JNIEnv.GetStaticMethodID (class_ref, "isOfflineOnly", "(I)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isOfflineOnly_I, __args);
			} finally {
			}
		}

		static IntPtr id_shouldReadFromDiskCache_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/method[@name='shouldReadFromDiskCache' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("shouldReadFromDiskCache", "(I)Z", "")]
		public static unsafe bool ShouldReadFromDiskCache (int p0)
		{
			if (id_shouldReadFromDiskCache_I == IntPtr.Zero)
				id_shouldReadFromDiskCache_I = JNIEnv.GetStaticMethodID (class_ref, "shouldReadFromDiskCache", "(I)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_shouldReadFromDiskCache_I, __args);
			} finally {
			}
		}

		static IntPtr id_shouldWriteToDiskCache_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/method[@name='shouldWriteToDiskCache' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("shouldWriteToDiskCache", "(I)Z", "")]
		public static unsafe bool ShouldWriteToDiskCache (int p0)
		{
			if (id_shouldWriteToDiskCache_I == IntPtr.Zero)
				id_shouldWriteToDiskCache_I = JNIEnv.GetStaticMethodID (class_ref, "shouldWriteToDiskCache", "(I)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_shouldWriteToDiskCache_I, __args);
			} finally {
			}
		}

		static IntPtr id_valueOf_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/NetworkPolicy;", "")]
		public static unsafe global::Com.Squareup.Picasso.NetworkPolicy ValueOf (string p0)
		{
			if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
				id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/squareup/picasso/NetworkPolicy;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Squareup.Picasso.NetworkPolicy __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.NetworkPolicy> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_values;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='NetworkPolicy']/method[@name='values' and count(parameter)=0]"
		[Register ("values", "()[Lcom/squareup/picasso/NetworkPolicy;", "")]
		public static unsafe global::Com.Squareup.Picasso.NetworkPolicy[] Values ()
		{
			if (id_values == IntPtr.Zero)
				id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/squareup/picasso/NetworkPolicy;");
			try {
				return (global::Com.Squareup.Picasso.NetworkPolicy[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Squareup.Picasso.NetworkPolicy));
			} finally {
			}
		}

	}
}
