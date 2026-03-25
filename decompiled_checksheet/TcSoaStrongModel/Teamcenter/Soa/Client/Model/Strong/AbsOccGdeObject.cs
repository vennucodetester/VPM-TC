namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccGdeObject : AbsOccData
{
	public GeneralDesignElement Gde_object => (GeneralDesignElement)GetProperty("gde_object").ModelObjectValue;

	public AbsOccGdeObject(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
