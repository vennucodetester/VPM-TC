namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccViewQualifier : POM_object
{
	public AbsOccurrence Absocc_tag => (AbsOccurrence)GetProperty("absocc_tag").ModelObjectValue;

	public PSBOMView Bomview_tag => (PSBOMView)GetProperty("bomview_tag").ModelObjectValue;

	public AbsOccViewQualifier(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
