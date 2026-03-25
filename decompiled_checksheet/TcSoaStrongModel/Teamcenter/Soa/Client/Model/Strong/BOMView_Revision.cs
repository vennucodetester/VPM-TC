namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMView_Revision : PSBOMViewRevision
{
	public ModelObject[] TC_Arrangement => GetProperty("TC_Arrangement").ModelObjectArrayValue;

	public ModelObject[] IMAN_external_object_link => GetProperty("IMAN_external_object_link").ModelObjectArrayValue;

	public ModelObject[] TC_BaseArrangementAnchor => GetProperty("TC_BaseArrangementAnchor").ModelObjectArrayValue;

	public ModelObject[] TC_DefaultArrangement => GetProperty("TC_DefaultArrangement").ModelObjectArrayValue;

	public BOMView_Revision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
