using System;
using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprItemRevOrder : POM_object
{
	public AppearanceRoot Appr_root => (AppearanceRoot)GetProperty("appr_root").ModelObjectValue;

	public DateTime[] Mod_dates => GetProperty("mod_dates").DateArrayValue;

	public ItemRevision[] Ordered_revs
	{
		get
		{
			IList modelObjectListValue = GetProperty("ordered_revs").ModelObjectListValue;
			ItemRevision[] array = new ItemRevision[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public Item Item => (Item)GetProperty("item").ModelObjectValue;

	public ApprItemRevOrder(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
