package md5353c6c1028b70dfa1d3e1b2a263308e7;


public class SelectCampusActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Gudu.SelectCampusActivity, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SelectCampusActivity.class, __md_methods);
	}


	public SelectCampusActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SelectCampusActivity.class)
			mono.android.TypeManager.Activate ("Gudu.SelectCampusActivity, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
