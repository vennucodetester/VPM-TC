using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ArroApprsHistoryEntry : ArroHistoryEntry
{
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

	public ArroApprsHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
