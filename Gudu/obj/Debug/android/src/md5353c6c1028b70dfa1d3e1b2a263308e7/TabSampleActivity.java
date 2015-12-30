package md5353c6c1028b70dfa1d3e1b2a263308e7;


public class TabSampleActivity
	extends android.app.TabActivity
	implements
		mono.android.IGCUserPeer,
		com.tencent.mm.sdk.openapi.IWXAPIEventHandler
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onReq:(Lcom/tencent/mm/sdk/modelbase/BaseReq;)V:GetOnReq_Lcom_tencent_mm_sdk_modelbase_BaseReq_Handler:Com.Tencent.MM.Sdk.Openapi.IWXAPIEventHandlerInvoker, PingPlusPlus\n" +
			"n_onResp:(Lcom/tencent/mm/sdk/modelbase/BaseResp;)V:GetOnResp_Lcom_tencent_mm_sdk_modelbase_BaseResp_Handler:Com.Tencent.MM.Sdk.Openapi.IWXAPIEventHandlerInvoker, PingPlusPlus\n" +
			"";
		mono.android.Runtime.register ("Gudu.TabSampleActivity, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TabSampleActivity.class, __md_methods);
	}


	public TabSampleActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TabSampleActivity.class)
			mono.android.TypeManager.Activate ("Gudu.TabSampleActivity, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onReq (com.tencent.mm.sdk.modelbase.BaseReq p0)
	{
		n_onReq (p0);
	}

	private native void n_onReq (com.tencent.mm.sdk.modelbase.BaseReq p0);


	public void onResp (com.tencent.mm.sdk.modelbase.BaseResp p0)
	{
		n_onResp (p0);
	}

	private native void n_onResp (com.tencent.mm.sdk.modelbase.BaseResp p0);

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
