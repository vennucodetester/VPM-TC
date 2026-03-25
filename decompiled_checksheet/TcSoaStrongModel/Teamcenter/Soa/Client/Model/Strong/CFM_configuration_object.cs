namespace Teamcenter.Soa.Client.Model.Strong;

public class CFM_configuration_object : POM_object
{
	public ModelObject[] Revision_history => GetProperty("revision_history").ModelObjectArrayValue;

	public CFM_configuration_object(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
