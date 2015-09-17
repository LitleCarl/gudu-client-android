package md5dbbd6b369491364c051c56a6b9d99b12;


public class NetworkDispatcher
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("VolleyCSharp.NetCom.NetworkDispatcher, VolleyCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NetworkDispatcher.class, __md_methods);
	}


	public NetworkDispatcher () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NetworkDispatcher.class)
			mono.android.TypeManager.Activate ("VolleyCSharp.NetCom.NetworkDispatcher, VolleyCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
