namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEGeometryRevision : CAEItemRevision
{
	public string Pre_processor_type => GetProperty("pre_processor_type").StringValue;

	public string[] Analysis_types => GetProperty("analysis_types").StringArrayValue;

	public CAEGeometryRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
