package md5353c6c1028b70dfa1d3e1b2a263308e7;


public class MainActivity
	extends md5353c6c1028b70dfa1d3e1b2a263308e7.IAlertViewActivity
	implements
		mono.android.IGCUserPeer,
		pull2refresh.zaocan84.com.pulltorefresh.PullToRefreshBase.OnRefreshListener2
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"n_onPullDownToRefresh:(Lpull2refresh/zaocan84/com/pulltorefresh/PullToRefreshBase;)V:GetOnPullDownToRefresh_Lpull2refresh_zaocan84_com_pulltorefresh_PullToRefreshBase_Handler:Pull2refresh.Zaocan84.Com.Pulltorefresh.PullToRefreshBase/IOnRefreshListener2Invoker, TsaoPullToRefresh\n" +
			"n_onPullUpToRefresh:(Lpull2refresh/zaocan84/com/pulltorefresh/PullToRefreshBase;)V:GetOnPullUpToRefresh_Lpull2refresh_zaocan84_com_pulltorefresh_PullToRefreshBase_Handler:Pull2refresh.Zaocan84.Com.Pulltorefresh.PullToRefreshBase/IOnRefreshListener2Invoker, TsaoPullToRefresh\n" +
			"";
		mono.android.Runtime.register ("Gudu.MainActivity, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("Gudu.MainActivity, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();


	public void onPullDownToRefresh (pull2refresh.zaocan84.com.pulltorefresh.PullToRefreshBase p0)
	{
		n_onPullDownToRefresh (p0);
	}

	private native void n_onPullDownToRefresh (pull2refresh.zaocan84.com.pulltorefresh.PullToRefreshBase p0);


	public void onPullUpToRefresh (pull2refresh.zaocan84.com.pulltorefresh.PullToRefreshBase p0)
	{
		n_onPullUpToRefresh (p0);
	}

	private native void n_onPullUpToRefresh (pull2refresh.zaocan84.com.pulltorefresh.PullToRefreshBase p0);

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
