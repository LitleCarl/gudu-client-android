package md5a37e5488d17a641ac766b61370daf6c9;


public class CacheDispatcher
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("VolleyCSharp.CacheCom.CacheDispatcher, VolleyCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CacheDispatcher.class, __md_methods);
	}


	public CacheDispatcher () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CacheDispatcher.class)
			mono.android.TypeManager.Activate ("VolleyCSharp.CacheCom.CacheDispatcher, VolleyCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
