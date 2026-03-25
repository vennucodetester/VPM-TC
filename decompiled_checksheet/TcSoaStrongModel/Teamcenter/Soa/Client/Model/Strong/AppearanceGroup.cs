namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceGroup : WorkspaceObject
{
	public MEAppearancePathRoot App_path_root => (MEAppearancePathRoot)GetProperty("app_path_root").ModelObjectValue;

	public string Fnd0clone_stable_id => GetProperty("fnd0clone_stable_id").StringValue;

	public ApprSearchCriteria Search_criteria => (ApprSearchCriteria)GetProperty("search_criteria").ModelObjectValue;

	public ModelObject[] IMAN_3D_snap_shot => GetProperty("IMAN_3D_snap_shot").ModelObjectArrayValue;

	public ModelObject[] TC_ProductManual => GetProperty("TC_ProductManual").ModelObjectArrayValue;

	public ModelObject[] Appearance_groups => GetProperty("appearance_groups").ModelObjectArrayValue;

	public ModelObject[] Appearances => GetProperty("appearances").ModelObjectArrayValue;

	public ModelObject[] Parents => GetProperty("parents").ModelObjectArrayValue;

	public ModelObject[] IMAN_reference => GetProperty("IMAN_reference").ModelObjectArrayValue;

	public ModelObject End_item => GetProperty("end_item").ModelObjectValue;

	public ModelObject[] IMAN_MEWorkInstruction => GetProperty("IMAN_MEWorkInstruction").ModelObjectArrayValue;

	public ModelObject[] VisSession => GetProperty("VisSession").ModelObjectArrayValue;

	public AppearanceGroup(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
