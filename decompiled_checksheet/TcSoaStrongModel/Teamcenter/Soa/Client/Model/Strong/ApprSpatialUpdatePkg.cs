using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSpatialUpdatePkg : ApprUpdChangePkg
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

	public AppearanceRoot Appr_root => (AppearanceRoot)GetProperty("appr_root").ModelObjectValue;

	public ApprSpatialUpdatePkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
