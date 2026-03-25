namespace Teamcenter.Soa.Client.Model.Strong;

public class CR_approver : POM_object
{
	public POM_object Accessor => (POM_object)GetProperty("accessor").ModelObjectValue;

	public CR_approver(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
