namespace Teamcenter.Soa.Client.Model.Strong;

public class DatumPointRevision : PSConnectionRevision
{
	public ModelObject[] TC_Feature_Form_Relation => GetProperty("TC_Feature_Form_Relation").ModelObjectArrayValue;

	public ModelObject[] Mfg0TCContextFeatureFormRel => GetProperty("Mfg0TCContextFeatureFormRel").ModelObjectArrayValue;

	public DatumPointRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
