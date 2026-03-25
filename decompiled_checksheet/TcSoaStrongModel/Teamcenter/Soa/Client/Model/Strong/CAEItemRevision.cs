namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEItemRevision : ItemRevision
{
	public ModelObject[] Fnd0CAE_GeneratedBy => GetProperty("Fnd0CAE_GeneratedBy").ModelObjectArrayValue;

	public CAEItemRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
