namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdByApprRootPkg : POM_object
{
	public int Corruption_threshold => GetProperty("corruption_threshold").IntValue;

	public bool Processing_complete => GetProperty("processing_complete").BoolValue;

	public bool Processing_blocked => GetProperty("processing_blocked").BoolValue;

	public ApprUpdByApprRootPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
