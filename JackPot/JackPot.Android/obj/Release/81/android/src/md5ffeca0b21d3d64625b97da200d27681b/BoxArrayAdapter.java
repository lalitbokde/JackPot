package md5ffeca0b21d3d64625b97da200d27681b;


public class BoxArrayAdapter
	extends android.widget.ArrayAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getFilter:()Landroid/widget/Filter;:GetGetFilterHandler\n" +
			"";
		mono.android.Runtime.register ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", BoxArrayAdapter.class, __md_methods);
	}


	public BoxArrayAdapter (android.content.Context p0, int p1, java.util.List p2)
	{
		super (p0, p1, p2);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Collections.IList, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public android.widget.Filter getFilter ()
	{
		return n_getFilter ();
	}

	private native android.widget.Filter n_getFilter ();

	private java.util.ArrayList refList;
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
