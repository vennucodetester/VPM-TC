using System;
using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprRevRelation : POM_object
{
	public DateTime Creation_date => GetProperty("creation_date").DateValue;

	public Appearance[] Appearances
	{
		get
		{
			IList modelObjectListValue = GetProperty("appearances").ModelObjectListValue;
			Appearance[] array = new Appearance[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AppearanceRoot Appr_root => (AppearanceRoot)GetProperty("appr_root").ModelObjectValue;

	public ItemRevision[] Valid_revs
	{
		get
		{
			IList modelObjectListValue = GetProperty("valid_revs").ModelObjectListValue;
			ItemRevision[] array = new ItemRevision[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ItemRevision[] Impacting_incr_change_revs
	{
		get
		{
			IList modelObjectListValue = GetProperty("impacting_incr_change_revs").ModelObjectListValue;
			ItemRevision[] array = new ItemRevision[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ApprRevRelation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
