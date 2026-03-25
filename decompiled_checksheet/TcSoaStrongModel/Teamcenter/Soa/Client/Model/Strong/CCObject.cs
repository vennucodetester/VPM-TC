namespace Teamcenter.Soa.Client.Model.Strong;

public class CCObject : WorkspaceObject
{
	public ConfigurationContext Config_context => (ConfigurationContext)GetProperty("config_context").ModelObjectValue;

	public ModelObject Self => GetProperty("self").ModelObjectValue;

	public ModelObject[] IMAN_manifestation => GetProperty("IMAN_manifestation").ModelObjectArrayValue;

	public ModelObject[] IMAN_CCContext => GetProperty("IMAN_CCContext").ModelObjectArrayValue;

	public ModelObject[] IMAN_specification => GetProperty("IMAN_specification").ModelObjectArrayValue;

	public ModelObject Top_line => GetProperty("top_line").ModelObjectValue;

	public ModelObject[] Structure_contexts => GetProperty("structure_contexts").ModelObjectArrayValue;

	public ModelObject Working_context => GetProperty("working_context").ModelObjectValue;

	public ModelObject[] IMAN_reference => GetProperty("IMAN_reference").ModelObjectArrayValue;

	public ModelObject[] IMAN_requirement => GetProperty("IMAN_requirement").ModelObjectArrayValue;

	public CCObject(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
