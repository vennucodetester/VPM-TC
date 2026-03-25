using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AurvirForIncrChange : ApprUpdRevViewImpactsRoot
{
	public IncrementalChangeElement[] Change_elems
	{
		get
		{
			IList modelObjectListValue = GetProperty("change_elems").ModelObjectListValue;
			IncrementalChangeElement[] array = new IncrementalChangeElement[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AurvirForIncrChange(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
