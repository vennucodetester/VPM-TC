namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMLatestEntry : CFMRuleEntry
{
	public int Config_type => GetProperty("config_type").IntValue;

	public CFMLatestEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
