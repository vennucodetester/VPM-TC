namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccChildItem : AbsOccData
{
	public ModelObject Child_item => GetProperty("child_item").ModelObjectValue;

	public PSBOMView Child_bv => (PSBOMView)GetProperty("child_bv").ModelObjectValue;

	public AbsOccChildItem(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
