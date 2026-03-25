namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMRuleEntry : POM_object
{
	public string Entry_text => GetProperty("entry_text").StringValue;

	public CFMRuleEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
