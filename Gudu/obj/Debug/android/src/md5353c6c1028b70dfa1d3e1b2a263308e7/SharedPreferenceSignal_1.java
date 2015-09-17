package md5353c6c1028b70dfa1d3e1b2a263308e7;


public class SharedPreferenceSignal_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.SharedPreferences.OnSharedPreferenceChangeListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onSharedPreferenceChanged:(Landroid/content/SharedPreferences;Ljava/lang/String;)V:GetOnSharedPreferenceChanged_Landroid_content_SharedPreferences_Ljava_lang_String_Handler:Android.Content.ISharedPreferencesOnSharedPreferenceChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Gudu.SharedPreferenceSignal`1, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SharedPreferenceSignal_1.class, __md_methods);
	}


	public SharedPreferenceSignal_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SharedPreferenceSignal_1.class)
			mono.android.TypeManager.Activate ("Gudu.SharedPreferenceSignal`1, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onSharedPreferenceChanged (android.content.SharedPreferences p0, java.lang.String p1)
	{
		n_onSharedPreferenceChanged (p0, p1);
	}

	private native void n_onSharedPreferenceChanged (android.content.SharedPreferences p0, java.lang.String p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
