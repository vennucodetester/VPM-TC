namespace Teamcenter.Soa.Client.Model.Strong;

public class AuditDefinition : POM_object
{
	public ModelObject Object_type => GetProperty("object_type").ModelObjectValue;

	public ModelObject Event_type => GetProperty("event_type").ModelObjectValue;

	public ModelObject User_log_handler => GetProperty("user_log_handler").ModelObjectValue;

	public string[] Properties => GetProperty("properties").StringArrayValue;

	public ModelObject Archive_storage => GetProperty("archive_storage").ModelObjectValue;

	public int Days_kept => GetProperty("days_kept").IntValue;

	public int Storage_type => GetProperty("storage_type").IntValue;

	public AuditDefinition(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
