using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ArroValidRevsHistoryEntry : ArroHistoryEntry
{
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

	public ArroValidRevsHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
