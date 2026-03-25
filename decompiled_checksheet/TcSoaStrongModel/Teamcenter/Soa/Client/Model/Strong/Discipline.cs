namespace Teamcenter.Soa.Client.Model.Strong;

public class Discipline : POM_system_class
{
	public string Discipline_name => GetProperty("discipline_name").StringValue;

	public string Description => GetProperty("description").StringValue;

	public double Default_rate => GetProperty("default_rate").DoubleValue;

	public string Default_currency => GetProperty("default_currency").StringValue;

	public ModelObject[] TC_discipline_member => GetProperty("TC_discipline_member").ModelObjectArrayValue;

	public string Object_name => GetProperty("object_name").StringValue;

	public ModelObject[] Fnd0OrganizationAuditLogs => GetProperty("fnd0OrganizationAuditLogs").ModelObjectArrayValue;

	public Discipline(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
