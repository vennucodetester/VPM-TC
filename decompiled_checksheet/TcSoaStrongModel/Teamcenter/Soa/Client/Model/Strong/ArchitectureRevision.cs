namespace Teamcenter.Soa.Client.Model.Strong;

public class ArchitectureRevision : ItemRevision
{
	public string Generic_component_id => GetProperty("generic_component_id").StringValue;

	public ArchitectureRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
