package md5353c6c1028b70dfa1d3e1b2a263308e7;


public class ProgressHUD
	extends android.app.Dialog
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onWindowFocusChanged:(Z)V:GetOnWindowFocusChanged_ZHandler\n" +
			"";
		mono.android.Runtime.register ("Gudu.ProgressHUD, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ProgressHUD.class, __md_methods);
	}


	public ProgressHUD (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ProgressHUD.class)
			mono.android.TypeManager.Activate ("Gudu.ProgressHUD, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public ProgressHUD (android.content.Context p0, int p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == ProgressHUD.class)
			mono.android.TypeManager.Activate ("Gudu.ProgressHUD, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public void onWindowFocusChanged (boolean p0)
	{
		n_onWindowFocusChanged (p0);
	}

	private native void n_onWindowFocusChanged (boolean p0);

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
