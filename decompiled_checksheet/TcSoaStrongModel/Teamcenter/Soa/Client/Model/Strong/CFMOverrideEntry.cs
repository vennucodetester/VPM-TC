namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMOverrideEntry : CFMRuleEntry
{
	public Folder Folder => (Folder)GetProperty("folder").ModelObjectValue;

	public CFMOverrideEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
