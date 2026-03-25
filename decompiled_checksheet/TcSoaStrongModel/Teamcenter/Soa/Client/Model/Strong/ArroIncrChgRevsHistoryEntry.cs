using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ArroIncrChgRevsHistoryEntry : ArroHistoryEntry
{
	public ItemRevision[] Incr_change_revs
	{
		get
		{
			IList modelObjectListValue = GetProperty("incr_change_revs").ModelObjectListValue;
			ItemRevision[] array = new ItemRevision[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ArroIncrChgRevsHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
