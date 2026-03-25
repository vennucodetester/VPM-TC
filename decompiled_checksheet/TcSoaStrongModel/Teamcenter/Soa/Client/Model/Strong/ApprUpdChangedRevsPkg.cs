using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdChangedRevsPkg : ApprUpdStructureChangePkg
{
	public ItemRevision[] Changed_item_revs
	{
		get
		{
			IList modelObjectListValue = GetProperty("changed_item_revs").ModelObjectListValue;
			ItemRevision[] array = new ItemRevision[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ApprUpdChangedRevsPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
