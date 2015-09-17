using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']"
	[global::Android.Runtime.Register ("com/squareup/picasso/StatsSnapshot", DoNotGenerateAcw=true)]
	public partial class StatsSnapshot : global::Java.Lang.Object {


		static IntPtr averageDownloadSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='averageDownloadSize']"
		[Register ("averageDownloadSize")]
		public long AverageDownloadSize {
			get {
				if (averageDownloadSize_jfieldId == IntPtr.Zero)
					averageDownloadSize_jfieldId = JNIEnv.GetFieldID (class_ref, "averageDownloadSize", "J");
				return JNIEnv.GetLongField (Handle, averageDownloadSize_jfieldId);
			}
			set {
				if (averageDownloadSize_jfieldId == IntPtr.Zero)
					averageDownloadSize_jfieldId = JNIEnv.GetFieldID (class_ref, "averageDownloadSize", "J");
				try {
					JNIEnv.SetField (Handle, averageDownloadSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr averageOriginalBitmapSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='averageOriginalBitmapSize']"
		[Register ("averageOriginalBitmapSize")]
		public long AverageOriginalBitmapSize {
			get {
				if (averageOriginalBitmapSize_jfieldId == IntPtr.Zero)
					averageOriginalBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "averageOriginalBitmapSize", "J");
				return JNIEnv.GetLongField (Handle, averageOriginalBitmapSize_jfieldId);
			}
			set {
				if (averageOriginalBitmapSize_jfieldId == IntPtr.Zero)
					averageOriginalBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "averageOriginalBitmapSize", "J");
				try {
					JNIEnv.SetField (Handle, averageOriginalBitmapSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr averageTransformedBitmapSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='averageTransformedBitmapSize']"
		[Register ("averageTransformedBitmapSize")]
		public long AverageTransformedBitmapSize {
			get {
				if (averageTransformedBitmapSize_jfieldId == IntPtr.Zero)
					averageTransformedBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "averageTransformedBitmapSize", "J");
				return JNIEnv.GetLongField (Handle, averageTransformedBitmapSize_jfieldId);
			}
			set {
				if (averageTransformedBitmapSize_jfieldId == IntPtr.Zero)
					averageTransformedBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "averageTransformedBitmapSize", "J");
				try {
					JNIEnv.SetField (Handle, averageTransformedBitmapSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr cacheHits_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='cacheHits']"
		[Register ("cacheHits")]
		public long CacheHits {
			get {
				if (cacheHits_jfieldId == IntPtr.Zero)
					cacheHits_jfieldId = JNIEnv.GetFieldID (class_ref, "cacheHits", "J");
				return JNIEnv.GetLongField (Handle, cacheHits_jfieldId);
			}
			set {
				if (cacheHits_jfieldId == IntPtr.Zero)
					cacheHits_jfieldId = JNIEnv.GetFieldID (class_ref, "cacheHits", "J");
				try {
					JNIEnv.SetField (Handle, cacheHits_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr cacheMisses_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='cacheMisses']"
		[Register ("cacheMisses")]
		public long CacheMisses {
			get {
				if (cacheMisses_jfieldId == IntPtr.Zero)
					cacheMisses_jfieldId = JNIEnv.GetFieldID (class_ref, "cacheMisses", "J");
				return JNIEnv.GetLongField (Handle, cacheMisses_jfieldId);
			}
			set {
				if (cacheMisses_jfieldId == IntPtr.Zero)
					cacheMisses_jfieldId = JNIEnv.GetFieldID (class_ref, "cacheMisses", "J");
				try {
					JNIEnv.SetField (Handle, cacheMisses_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr downloadCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='downloadCount']"
		[Register ("downloadCount")]
		public int DownloadCount {
			get {
				if (downloadCount_jfieldId == IntPtr.Zero)
					downloadCount_jfieldId = JNIEnv.GetFieldID (class_ref, "downloadCount", "I");
				return JNIEnv.GetIntField (Handle, downloadCount_jfieldId);
			}
			set {
				if (downloadCount_jfieldId == IntPtr.Zero)
					downloadCount_jfieldId = JNIEnv.GetFieldID (class_ref, "downloadCount", "I");
				try {
					JNIEnv.SetField (Handle, downloadCount_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr maxSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='maxSize']"
		[Register ("maxSize")]
		public int MaxSize {
			get {
				if (maxSize_jfieldId == IntPtr.Zero)
					maxSize_jfieldId = JNIEnv.GetFieldID (class_ref, "maxSize", "I");
				return JNIEnv.GetIntField (Handle, maxSize_jfieldId);
			}
			set {
				if (maxSize_jfieldId == IntPtr.Zero)
					maxSize_jfieldId = JNIEnv.GetFieldID (class_ref, "maxSize", "I");
				try {
					JNIEnv.SetField (Handle, maxSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr originalBitmapCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='originalBitmapCount']"
		[Register ("originalBitmapCount")]
		public int OriginalBitmapCount {
			get {
				if (originalBitmapCount_jfieldId == IntPtr.Zero)
					originalBitmapCount_jfieldId = JNIEnv.GetFieldID (class_ref, "originalBitmapCount", "I");
				return JNIEnv.GetIntField (Handle, originalBitmapCount_jfieldId);
			}
			set {
				if (originalBitmapCount_jfieldId == IntPtr.Zero)
					originalBitmapCount_jfieldId = JNIEnv.GetFieldID (class_ref, "originalBitmapCount", "I");
				try {
					JNIEnv.SetField (Handle, originalBitmapCount_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr size_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='size']"
		[Register ("size")]
		public int Size {
			get {
				if (size_jfieldId == IntPtr.Zero)
					size_jfieldId = JNIEnv.GetFieldID (class_ref, "size", "I");
				return JNIEnv.GetIntField (Handle, size_jfieldId);
			}
			set {
				if (size_jfieldId == IntPtr.Zero)
					size_jfieldId = JNIEnv.GetFieldID (class_ref, "size", "I");
				try {
					JNIEnv.SetField (Handle, size_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr timeStamp_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='timeStamp']"
		[Register ("timeStamp")]
		public long TimeStamp {
			get {
				if (timeStamp_jfieldId == IntPtr.Zero)
					timeStamp_jfieldId = JNIEnv.GetFieldID (class_ref, "timeStamp", "J");
				return JNIEnv.GetLongField (Handle, timeStamp_jfieldId);
			}
			set {
				if (timeStamp_jfieldId == IntPtr.Zero)
					timeStamp_jfieldId = JNIEnv.GetFieldID (class_ref, "timeStamp", "J");
				try {
					JNIEnv.SetField (Handle, timeStamp_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr totalDownloadSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='totalDownloadSize']"
		[Register ("totalDownloadSize")]
		public long TotalDownloadSize {
			get {
				if (totalDownloadSize_jfieldId == IntPtr.Zero)
					totalDownloadSize_jfieldId = JNIEnv.GetFieldID (class_ref, "totalDownloadSize", "J");
				return JNIEnv.GetLongField (Handle, totalDownloadSize_jfieldId);
			}
			set {
				if (totalDownloadSize_jfieldId == IntPtr.Zero)
					totalDownloadSize_jfieldId = JNIEnv.GetFieldID (class_ref, "totalDownloadSize", "J");
				try {
					JNIEnv.SetField (Handle, totalDownloadSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr totalOriginalBitmapSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='totalOriginalBitmapSize']"
		[Register ("totalOriginalBitmapSize")]
		public long TotalOriginalBitmapSize {
			get {
				if (totalOriginalBitmapSize_jfieldId == IntPtr.Zero)
					totalOriginalBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "totalOriginalBitmapSize", "J");
				return JNIEnv.GetLongField (Handle, totalOriginalBitmapSize_jfieldId);
			}
			set {
				if (totalOriginalBitmapSize_jfieldId == IntPtr.Zero)
					totalOriginalBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "totalOriginalBitmapSize", "J");
				try {
					JNIEnv.SetField (Handle, totalOriginalBitmapSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr totalTransformedBitmapSize_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='totalTransformedBitmapSize']"
		[Register ("totalTransformedBitmapSize")]
		public long TotalTransformedBitmapSize {
			get {
				if (totalTransformedBitmapSize_jfieldId == IntPtr.Zero)
					totalTransformedBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "totalTransformedBitmapSize", "J");
				return JNIEnv.GetLongField (Handle, totalTransformedBitmapSize_jfieldId);
			}
			set {
				if (totalTransformedBitmapSize_jfieldId == IntPtr.Zero)
					totalTransformedBitmapSize_jfieldId = JNIEnv.GetFieldID (class_ref, "totalTransformedBitmapSize", "J");
				try {
					JNIEnv.SetField (Handle, totalTransformedBitmapSize_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr transformedBitmapCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/field[@name='transformedBitmapCount']"
		[Register ("transformedBitmapCount")]
		public int TransformedBitmapCount {
			get {
				if (transformedBitmapCount_jfieldId == IntPtr.Zero)
					transformedBitmapCount_jfieldId = JNIEnv.GetFieldID (class_ref, "transformedBitmapCount", "I");
				return JNIEnv.GetIntField (Handle, transformedBitmapCount_jfieldId);
			}
			set {
				if (transformedBitmapCount_jfieldId == IntPtr.Zero)
					transformedBitmapCount_jfieldId = JNIEnv.GetFieldID (class_ref, "transformedBitmapCount", "I");
				try {
					JNIEnv.SetField (Handle, transformedBitmapCount_jfieldId, value);
				} finally {
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/StatsSnapshot", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StatsSnapshot); }
		}

		protected StatsSnapshot (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_IIJJJJJJJJIIIJ;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/constructor[@name='StatsSnapshot' and count(parameter)=14 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='long'] and parameter[4][@type='long'] and parameter[5][@type='long'] and parameter[6][@type='long'] and parameter[7][@type='long'] and parameter[8][@type='long'] and parameter[9][@type='long'] and parameter[10][@type='long'] and parameter[11][@type='int'] and parameter[12][@type='int'] and parameter[13][@type='int'] and parameter[14][@type='long']]"
		[Register (".ctor", "(IIJJJJJJJJIIIJ)V", "")]
		public unsafe StatsSnapshot (int p0, int p1, long p2, long p3, long p4, long p5, long p6, long p7, long p8, long p9, int p10, int p11, int p12, long p13)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [14];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (p6);
				__args [7] = new JValue (p7);
				__args [8] = new JValue (p8);
				__args [9] = new JValue (p9);
				__args [10] = new JValue (p10);
				__args [11] = new JValue (p11);
				__args [12] = new JValue (p12);
				__args [13] = new JValue (p13);
				if (GetType () != typeof (StatsSnapshot)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(IIJJJJJJJJIIIJ)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(IIJJJJJJJJIIIJ)V", __args);
					return;
				}

				if (id_ctor_IIJJJJJJJJIIIJ == IntPtr.Zero)
					id_ctor_IIJJJJJJJJIIIJ = JNIEnv.GetMethodID (class_ref, "<init>", "(IIJJJJJJJJIIIJ)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_IIJJJJJJJJIIIJ, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_IIJJJJJJJJIIIJ, __args);
			} finally {
			}
		}

		static Delegate cb_dump;
#pragma warning disable 0169
		static Delegate GetDumpHandler ()
		{
			if (cb_dump == null)
				cb_dump = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Dump);
			return cb_dump;
		}

		static void n_Dump (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Squareup.Picasso.StatsSnapshot __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.StatsSnapshot> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Dump ();
		}
#pragma warning restore 0169

		static IntPtr id_dump;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/method[@name='dump' and count(parameter)=0]"
		[Register ("dump", "()V", "GetDumpHandler")]
		public virtual unsafe void Dump ()
		{
			if (id_dump == IntPtr.Zero)
				id_dump = JNIEnv.GetMethodID (class_ref, "dump", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_dump);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "dump", "()V"));
			} finally {
			}
		}

		static Delegate cb_dump_Ljava_io_PrintWriter_;
#pragma warning disable 0169
		static Delegate GetDump_Ljava_io_PrintWriter_Handler ()
		{
			if (cb_dump_Ljava_io_PrintWriter_ == null)
				cb_dump_Ljava_io_PrintWriter_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Dump_Ljava_io_PrintWriter_);
			return cb_dump_Ljava_io_PrintWriter_;
		}

		static void n_Dump_Ljava_io_PrintWriter_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Squareup.Picasso.StatsSnapshot __this = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.StatsSnapshot> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.PrintWriter p0 = global::Java.Lang.Object.GetObject<global::Java.IO.PrintWriter> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Dump (p0);
		}
#pragma warning restore 0169

		static IntPtr id_dump_Ljava_io_PrintWriter_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='StatsSnapshot']/method[@name='dump' and count(parameter)=1 and parameter[1][@type='java.io.PrintWriter']]"
		[Register ("dump", "(Ljava/io/PrintWriter;)V", "GetDump_Ljava_io_PrintWriter_Handler")]
		public virtual unsafe void Dump (global::Java.IO.PrintWriter p0)
		{
			if (id_dump_Ljava_io_PrintWriter_ == IntPtr.Zero)
				id_dump_Ljava_io_PrintWriter_ = JNIEnv.GetMethodID (class_ref, "dump", "(Ljava/io/PrintWriter;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_dump_Ljava_io_PrintWriter_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "dump", "(Ljava/io/PrintWriter;)V"), __args);
			} finally {
			}
		}

	}
}
