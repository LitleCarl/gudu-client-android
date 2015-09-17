package md50b929c4e18162664392e3bffeb749157;


public class SegmentedRadioGroup
	extends android.widget.RadioGroup
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFinishInflate:()V:GetOnFinishInflateHandler\n" +
			"";
		mono.android.Runtime.register ("Gudu.CustomView.SegmentedRadioGroup, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SegmentedRadioGroup.class, __md_methods);
	}


	public SegmentedRadioGroup (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == SegmentedRadioGroup.class)
			mono.android.TypeManager.Activate ("Gudu.CustomView.SegmentedRadioGroup, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public SegmentedRadioGroup (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == SegmentedRadioGroup.class)
			mono.android.TypeManager.Activate ("Gudu.CustomView.SegmentedRadioGroup, Gudu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public void onFinishInflate ()
	{
		n_onFinishInflate ();
	}

	private native void n_onFinishInflate ();

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
