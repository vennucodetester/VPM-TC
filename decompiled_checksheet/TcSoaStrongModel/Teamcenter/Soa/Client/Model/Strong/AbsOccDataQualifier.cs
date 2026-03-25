namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccDataQualifier : POM_object
{
	public ModelObject Upper_qual_object => GetProperty("upper_qual_object").ModelObjectValue;

	public ModelObject Lower_qual_object => GetProperty("lower_qual_object").ModelObjectValue;

	public ModelObject Mo_qual_object => GetProperty("mo_qual_object").ModelObjectValue;

	public PSBOMViewRevision Qualifier_bvr => (PSBOMViewRevision)GetProperty("qualifier_bvr").ModelObjectValue;

	public AbsOccDataQualifier(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
