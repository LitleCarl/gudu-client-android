using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Squareup.Picasso {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']"
	[global::Android.Runtime.Register ("com/squareup/picasso/Request", DoNotGenerateAcw=true)]
	public sealed partial class Request : global::Java.Lang.Object {


		static IntPtr centerCrop_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='centerCrop']"
		[Register ("centerCrop")]
		public bool CenterCrop {
			get {
				if (centerCrop_jfieldId == IntPtr.Zero)
					centerCrop_jfieldId = JNIEnv.GetFieldID (class_ref, "centerCrop", "Z");
				return JNIEnv.GetBooleanField (Handle, centerCrop_jfieldId);
			}
			set {
				if (centerCrop_jfieldId == IntPtr.Zero)
					centerCrop_jfieldId = JNIEnv.GetFieldID (class_ref, "centerCrop", "Z");
				try {
					JNIEnv.SetField (Handle, centerCrop_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr centerInside_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='centerInside']"
		[Register ("centerInside")]
		public bool CenterInside {
			get {
				if (centerInside_jfieldId == IntPtr.Zero)
					centerInside_jfieldId = JNIEnv.GetFieldID (class_ref, "centerInside", "Z");
				return JNIEnv.GetBooleanField (Handle, centerInside_jfieldId);
			}
			set {
				if (centerInside_jfieldId == IntPtr.Zero)
					centerInside_jfieldId = JNIEnv.GetFieldID (class_ref, "centerInside", "Z");
				try {
					JNIEnv.SetField (Handle, centerInside_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr config_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='config']"
		[Register ("config")]
		public global::Android.Graphics.Bitmap.Config Config {
			get {
				if (config_jfieldId == IntPtr.Zero)
					config_jfieldId = JNIEnv.GetFieldID (class_ref, "config", "Landroid/graphics/Bitmap$Config;");
				IntPtr __ret = JNIEnv.GetObjectField (Handle, config_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap.Config> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (config_jfieldId == IntPtr.Zero)
					config_jfieldId = JNIEnv.GetFieldID (class_ref, "config", "Landroid/graphics/Bitmap$Config;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (Handle, config_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr hasRotationPivot_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='hasRotationPivot']"
		[Register ("hasRotationPivot")]
		public bool HasRotationPivot {
			get {
				if (hasRotationPivot_jfieldId == IntPtr.Zero)
					hasRotationPivot_jfieldId = JNIEnv.GetFieldID (class_ref, "hasRotationPivot", "Z");
				return JNIEnv.GetBooleanField (Handle, hasRotationPivot_jfieldId);
			}
			set {
				if (hasRotationPivot_jfieldId == IntPtr.Zero)
					hasRotationPivot_jfieldId = JNIEnv.GetFieldID (class_ref, "hasRotationPivot", "Z");
				try {
					JNIEnv.SetField (Handle, hasRotationPivot_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr onlyScaleDown_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='onlyScaleDown']"
		[Register ("onlyScaleDown")]
		public bool OnlyScaleDown {
			get {
				if (onlyScaleDown_jfieldId == IntPtr.Zero)
					onlyScaleDown_jfieldId = JNIEnv.GetFieldID (class_ref, "onlyScaleDown", "Z");
				return JNIEnv.GetBooleanField (Handle, onlyScaleDown_jfieldId);
			}
			set {
				if (onlyScaleDown_jfieldId == IntPtr.Zero)
					onlyScaleDown_jfieldId = JNIEnv.GetFieldID (class_ref, "onlyScaleDown", "Z");
				try {
					JNIEnv.SetField (Handle, onlyScaleDown_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr priority_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='priority']"
		[Register ("priority")]
		public global::Com.Squareup.Picasso.Picasso.Priority Priority {
			get {
				if (priority_jfieldId == IntPtr.Zero)
					priority_jfieldId = JNIEnv.GetFieldID (class_ref, "priority", "Lcom/squareup/picasso/Picasso$Priority;");
				IntPtr __ret = JNIEnv.GetObjectField (Handle, priority_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Picasso.Priority> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (priority_jfieldId == IntPtr.Zero)
					priority_jfieldId = JNIEnv.GetFieldID (class_ref, "priority", "Lcom/squareup/picasso/Picasso$Priority;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (Handle, priority_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr resourceId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='resourceId']"
		[Register ("resourceId")]
		public int ResourceId {
			get {
				if (resourceId_jfieldId == IntPtr.Zero)
					resourceId_jfieldId = JNIEnv.GetFieldID (class_ref, "resourceId", "I");
				return JNIEnv.GetIntField (Handle, resourceId_jfieldId);
			}
			set {
				if (resourceId_jfieldId == IntPtr.Zero)
					resourceId_jfieldId = JNIEnv.GetFieldID (class_ref, "resourceId", "I");
				try {
					JNIEnv.SetField (Handle, resourceId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr rotationDegrees_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='rotationDegrees']"
		[Register ("rotationDegrees")]
		public float RotationDegrees {
			get {
				if (rotationDegrees_jfieldId == IntPtr.Zero)
					rotationDegrees_jfieldId = JNIEnv.GetFieldID (class_ref, "rotationDegrees", "F");
				return JNIEnv.GetFloatField (Handle, rotationDegrees_jfieldId);
			}
			set {
				if (rotationDegrees_jfieldId == IntPtr.Zero)
					rotationDegrees_jfieldId = JNIEnv.GetFieldID (class_ref, "rotationDegrees", "F");
				try {
					JNIEnv.SetField (Handle, rotationDegrees_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr rotationPivotX_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='rotationPivotX']"
		[Register ("rotationPivotX")]
		public float RotationPivotX {
			get {
				if (rotationPivotX_jfieldId == IntPtr.Zero)
					rotationPivotX_jfieldId = JNIEnv.GetFieldID (class_ref, "rotationPivotX", "F");
				return JNIEnv.GetFloatField (Handle, rotationPivotX_jfieldId);
			}
			set {
				if (rotationPivotX_jfieldId == IntPtr.Zero)
					rotationPivotX_jfieldId = JNIEnv.GetFieldID (class_ref, "rotationPivotX", "F");
				try {
					JNIEnv.SetField (Handle, rotationPivotX_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr rotationPivotY_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='rotationPivotY']"
		[Register ("rotationPivotY")]
		public float RotationPivotY {
			get {
				if (rotationPivotY_jfieldId == IntPtr.Zero)
					rotationPivotY_jfieldId = JNIEnv.GetFieldID (class_ref, "rotationPivotY", "F");
				return JNIEnv.GetFloatField (Handle, rotationPivotY_jfieldId);
			}
			set {
				if (rotationPivotY_jfieldId == IntPtr.Zero)
					rotationPivotY_jfieldId = JNIEnv.GetFieldID (class_ref, "rotationPivotY", "F");
				try {
					JNIEnv.SetField (Handle, rotationPivotY_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr stableKey_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='stableKey']"
		[Register ("stableKey")]
		public string StableKey {
			get {
				if (stableKey_jfieldId == IntPtr.Zero)
					stableKey_jfieldId = JNIEnv.GetFieldID (class_ref, "stableKey", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (Handle, stableKey_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stableKey_jfieldId == IntPtr.Zero)
					stableKey_jfieldId = JNIEnv.GetFieldID (class_ref, "stableKey", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (Handle, stableKey_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr targetHeight_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='targetHeight']"
		[Register ("targetHeight")]
		public int TargetHeight {
			get {
				if (targetHeight_jfieldId == IntPtr.Zero)
					targetHeight_jfieldId = JNIEnv.GetFieldID (class_ref, "targetHeight", "I");
				return JNIEnv.GetIntField (Handle, targetHeight_jfieldId);
			}
			set {
				if (targetHeight_jfieldId == IntPtr.Zero)
					targetHeight_jfieldId = JNIEnv.GetFieldID (class_ref, "targetHeight", "I");
				try {
					JNIEnv.SetField (Handle, targetHeight_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr targetWidth_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='targetWidth']"
		[Register ("targetWidth")]
		public int TargetWidth {
			get {
				if (targetWidth_jfieldId == IntPtr.Zero)
					targetWidth_jfieldId = JNIEnv.GetFieldID (class_ref, "targetWidth", "I");
				return JNIEnv.GetIntField (Handle, targetWidth_jfieldId);
			}
			set {
				if (targetWidth_jfieldId == IntPtr.Zero)
					targetWidth_jfieldId = JNIEnv.GetFieldID (class_ref, "targetWidth", "I");
				try {
					JNIEnv.SetField (Handle, targetWidth_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr transformations_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='transformations']"
		[Register ("transformations")]
		public global::System.Collections.IList Transformations {
			get {
				if (transformations_jfieldId == IntPtr.Zero)
					transformations_jfieldId = JNIEnv.GetFieldID (class_ref, "transformations", "Ljava/util/List;");
				IntPtr __ret = JNIEnv.GetObjectField (Handle, transformations_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (transformations_jfieldId == IntPtr.Zero)
					transformations_jfieldId = JNIEnv.GetFieldID (class_ref, "transformations", "Ljava/util/List;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (Handle, transformations_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr uri_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/field[@name='uri']"
		[Register ("uri")]
		public global::Android.Net.Uri Uri {
			get {
				if (uri_jfieldId == IntPtr.Zero)
					uri_jfieldId = JNIEnv.GetFieldID (class_ref, "uri", "Landroid/net/Uri;");
				IntPtr __ret = JNIEnv.GetObjectField (Handle, uri_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (uri_jfieldId == IntPtr.Zero)
					uri_jfieldId = JNIEnv.GetFieldID (class_ref, "uri", "Landroid/net/Uri;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (Handle, uri_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		// Metadata.xml XPath class reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']"
		[global::Android.Runtime.Register ("com/squareup/picasso/Request$Builder", DoNotGenerateAcw=true)]
		public sealed partial class Builder : global::Java.Lang.Object {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/squareup/picasso/Request$Builder", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Builder); }
			}

			internal Builder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_Landroid_net_Uri_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/constructor[@name='Request.Builder' and count(parameter)=1 and parameter[1][@type='android.net.Uri']]"
			[Register (".ctor", "(Landroid/net/Uri;)V", "")]
			public unsafe Builder (global::Android.Net.Uri p0)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (Handle != IntPtr.Zero)
					return;

				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					if (GetType () != typeof (Builder)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/net/Uri;)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Landroid/net/Uri;)V", __args);
						return;
					}

					if (id_ctor_Landroid_net_Uri_ == IntPtr.Zero)
						id_ctor_Landroid_net_Uri_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/net/Uri;)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_net_Uri_, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Landroid_net_Uri_, __args);
				} finally {
				}
			}

			static IntPtr id_ctor_I;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/constructor[@name='Request.Builder' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register (".ctor", "(I)V", "")]
			public unsafe Builder (int p0)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (Handle != IntPtr.Zero)
					return;

				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					if (GetType () != typeof (Builder)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(I)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(I)V", __args);
						return;
					}

					if (id_ctor_I == IntPtr.Zero)
						id_ctor_I = JNIEnv.GetMethodID (class_ref, "<init>", "(I)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_I, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_I, __args);
				} finally {
				}
			}

			static IntPtr id_build;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='build' and count(parameter)=0]"
			[Register ("build", "()Lcom/squareup/picasso/Request;", "")]
			public unsafe global::Com.Squareup.Picasso.Request Build ()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID (class_ref, "build", "()Lcom/squareup/picasso/Request;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request> (JNIEnv.CallObjectMethod  (Handle, id_build), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_centerCrop;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='centerCrop' and count(parameter)=0]"
			[Register ("centerCrop", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder CenterCrop ()
			{
				if (id_centerCrop == IntPtr.Zero)
					id_centerCrop = JNIEnv.GetMethodID (class_ref, "centerCrop", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_centerCrop), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_centerInside;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='centerInside' and count(parameter)=0]"
			[Register ("centerInside", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder CenterInside ()
			{
				if (id_centerInside == IntPtr.Zero)
					id_centerInside = JNIEnv.GetMethodID (class_ref, "centerInside", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_centerInside), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_clearCenterCrop;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='clearCenterCrop' and count(parameter)=0]"
			[Register ("clearCenterCrop", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder ClearCenterCrop ()
			{
				if (id_clearCenterCrop == IntPtr.Zero)
					id_clearCenterCrop = JNIEnv.GetMethodID (class_ref, "clearCenterCrop", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_clearCenterCrop), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_clearCenterInside;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='clearCenterInside' and count(parameter)=0]"
			[Register ("clearCenterInside", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder ClearCenterInside ()
			{
				if (id_clearCenterInside == IntPtr.Zero)
					id_clearCenterInside = JNIEnv.GetMethodID (class_ref, "clearCenterInside", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_clearCenterInside), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_clearOnlyScaleDown;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='clearOnlyScaleDown' and count(parameter)=0]"
			[Register ("clearOnlyScaleDown", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder ClearOnlyScaleDown ()
			{
				if (id_clearOnlyScaleDown == IntPtr.Zero)
					id_clearOnlyScaleDown = JNIEnv.GetMethodID (class_ref, "clearOnlyScaleDown", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_clearOnlyScaleDown), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_clearResize;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='clearResize' and count(parameter)=0]"
			[Register ("clearResize", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder ClearResize ()
			{
				if (id_clearResize == IntPtr.Zero)
					id_clearResize = JNIEnv.GetMethodID (class_ref, "clearResize", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_clearResize), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_clearRotation;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='clearRotation' and count(parameter)=0]"
			[Register ("clearRotation", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder ClearRotation ()
			{
				if (id_clearRotation == IntPtr.Zero)
					id_clearRotation = JNIEnv.GetMethodID (class_ref, "clearRotation", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_clearRotation), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_config_Landroid_graphics_Bitmap_Config_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='config' and count(parameter)=1 and parameter[1][@type='android.graphics.Bitmap.Config']]"
			[Register ("config", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder Config (global::Android.Graphics.Bitmap.Config p0)
			{
				if (id_config_Landroid_graphics_Bitmap_Config_ == IntPtr.Zero)
					id_config_Landroid_graphics_Bitmap_Config_ = JNIEnv.GetMethodID (class_ref, "config", "(Landroid/graphics/Bitmap$Config;)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					global::Com.Squareup.Picasso.Request.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_config_Landroid_graphics_Bitmap_Config_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static IntPtr id_onlyScaleDown;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='onlyScaleDown' and count(parameter)=0]"
			[Register ("onlyScaleDown", "()Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder OnlyScaleDown ()
			{
				if (id_onlyScaleDown == IntPtr.Zero)
					id_onlyScaleDown = JNIEnv.GetMethodID (class_ref, "onlyScaleDown", "()Lcom/squareup/picasso/Request$Builder;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_onlyScaleDown), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_priority_Lcom_squareup_picasso_Picasso_Priority_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='priority' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Picasso.Priority']]"
			[Register ("priority", "(Lcom/squareup/picasso/Picasso$Priority;)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder Priority (global::Com.Squareup.Picasso.Picasso.Priority p0)
			{
				if (id_priority_Lcom_squareup_picasso_Picasso_Priority_ == IntPtr.Zero)
					id_priority_Lcom_squareup_picasso_Picasso_Priority_ = JNIEnv.GetMethodID (class_ref, "priority", "(Lcom/squareup/picasso/Picasso$Priority;)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					global::Com.Squareup.Picasso.Request.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_priority_Lcom_squareup_picasso_Picasso_Priority_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static IntPtr id_resize_II;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='resize' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
			[Register ("resize", "(II)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder Resize (int p0, int p1)
			{
				if (id_resize_II == IntPtr.Zero)
					id_resize_II = JNIEnv.GetMethodID (class_ref, "resize", "(II)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [2];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_resize_II, __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_rotate_F;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='rotate' and count(parameter)=1 and parameter[1][@type='float']]"
			[Register ("rotate", "(F)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder Rotate (float p0)
			{
				if (id_rotate_F == IntPtr.Zero)
					id_rotate_F = JNIEnv.GetMethodID (class_ref, "rotate", "(F)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_rotate_F, __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_rotate_FFF;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='rotate' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='float'] and parameter[3][@type='float']]"
			[Register ("rotate", "(FFF)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder Rotate (float p0, float p1, float p2)
			{
				if (id_rotate_FFF == IntPtr.Zero)
					id_rotate_FFF = JNIEnv.GetMethodID (class_ref, "rotate", "(FFF)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [3];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					__args [2] = new JValue (p2);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_rotate_FFF, __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_setResourceId_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='setResourceId' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setResourceId", "(I)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder SetResourceId (int p0)
			{
				if (id_setResourceId_I == IntPtr.Zero)
					id_setResourceId_I = JNIEnv.GetMethodID (class_ref, "setResourceId", "(I)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_setResourceId_I, __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static IntPtr id_setUri_Landroid_net_Uri_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='setUri' and count(parameter)=1 and parameter[1][@type='android.net.Uri']]"
			[Register ("setUri", "(Landroid/net/Uri;)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder SetUri (global::Android.Net.Uri p0)
			{
				if (id_setUri_Landroid_net_Uri_ == IntPtr.Zero)
					id_setUri_Landroid_net_Uri_ = JNIEnv.GetMethodID (class_ref, "setUri", "(Landroid/net/Uri;)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					global::Com.Squareup.Picasso.Request.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_setUri_Landroid_net_Uri_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

			static IntPtr id_stableKey_Ljava_lang_String_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='stableKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("stableKey", "(Ljava/lang/String;)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder StableKey (string p0)
			{
				if (id_stableKey_Ljava_lang_String_ == IntPtr.Zero)
					id_stableKey_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "stableKey", "(Ljava/lang/String;)Lcom/squareup/picasso/Request$Builder;");
				IntPtr native_p0 = JNIEnv.NewString (p0);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_p0);
					global::Com.Squareup.Picasso.Request.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_stableKey_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}

			static IntPtr id_transform_Lcom_squareup_picasso_Transformation_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request.Builder']/method[@name='transform' and count(parameter)=1 and parameter[1][@type='com.squareup.picasso.Transformation']]"
			[Register ("transform", "(Lcom/squareup/picasso/Transformation;)Lcom/squareup/picasso/Request$Builder;", "")]
			public unsafe global::Com.Squareup.Picasso.Request.Builder Transform (global::Com.Squareup.Picasso.ITransformation p0)
			{
				if (id_transform_Lcom_squareup_picasso_Transformation_ == IntPtr.Zero)
					id_transform_Lcom_squareup_picasso_Transformation_ = JNIEnv.GetMethodID (class_ref, "transform", "(Lcom/squareup/picasso/Transformation;)Lcom/squareup/picasso/Request$Builder;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);
					global::Com.Squareup.Picasso.Request.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_transform_Lcom_squareup_picasso_Transformation_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/squareup/picasso/Request", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Request); }
		}

		internal Request (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_hasSize;
		public unsafe bool HasSize {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/method[@name='hasSize' and count(parameter)=0]"
			[Register ("hasSize", "()Z", "GetHasSizeHandler")]
			get {
				if (id_hasSize == IntPtr.Zero)
					id_hasSize = JNIEnv.GetMethodID (class_ref, "hasSize", "()Z");
				try {
					return JNIEnv.CallBooleanMethod  (Handle, id_hasSize);
				} finally {
				}
			}
		}

		static IntPtr id_buildUpon;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.squareup.picasso']/class[@name='Request']/method[@name='buildUpon' and count(parameter)=0]"
		[Register ("buildUpon", "()Lcom/squareup/picasso/Request$Builder;", "")]
		public unsafe global::Com.Squareup.Picasso.Request.Builder BuildUpon ()
		{
			if (id_buildUpon == IntPtr.Zero)
				id_buildUpon = JNIEnv.GetMethodID (class_ref, "buildUpon", "()Lcom/squareup/picasso/Request$Builder;");
			try {
				return global::Java.Lang.Object.GetObject<global::Com.Squareup.Picasso.Request.Builder> (JNIEnv.CallObjectMethod  (Handle, id_buildUpon), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
