namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceConfigContext : POM_object
{
	public int Config_mode => GetProperty("config_mode").IntValue;

	public bool Has_precise => GetProperty("has_precise").BoolValue;

	public RevisionRule Revision_rule => (RevisionRule)GetProperty("revision_rule").ModelObjectValue;

	public AppearanceConfigContext(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
