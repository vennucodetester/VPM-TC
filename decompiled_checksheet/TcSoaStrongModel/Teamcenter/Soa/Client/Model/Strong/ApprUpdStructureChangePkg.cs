using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdStructureChangePkg : ApprUpdChangePkg
{
	public AppearanceRoot[] Filter_appearance_roots
	{
		get
		{
			IList modelObjectListValue = GetProperty("filter_appearance_roots").ModelObjectListValue;
			AppearanceRoot[] array = new AppearanceRoot[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ApprUpdStructureChangePkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
