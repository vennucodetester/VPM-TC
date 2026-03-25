using System;
using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdRevViewImpactsRoot : POM_object
{
	public AppearanceRoot Ap_root => (AppearanceRoot)GetProperty("ap_root").ModelObjectValue;

	public Appearance[] Parent_aps
	{
		get
		{
			IList modelObjectListValue = GetProperty("parent_aps").ModelObjectListValue;
			Appearance[] array = new Appearance[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public DateTime Release_date => GetProperty("release_date").DateValue;

	public ItemRevision Changed_item_revision => (ItemRevision)GetProperty("changed_item_revision").ModelObjectValue;

	public PSBOMView Bom_view => (PSBOMView)GetProperty("bom_view").ModelObjectValue;

	public ApprUpdRevViewImpactsRoot(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
