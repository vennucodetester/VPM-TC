namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEExportNode : POM_object
{
	public int Export_comp => GetProperty("export_comp").IntValue;

	public int Export_children => GetProperty("export_children").IntValue;

	public int Co_comp => GetProperty("co_comp").IntValue;

	public int Co_children => GetProperty("co_children").IntValue;

	public bool Expanded => GetProperty("expanded").BoolValue;

	public string Owning_assy_ref => GetProperty("owning_assy_ref").StringValue;

	public int Num_children => GetProperty("num_children").IntValue;

	public ModelObject[] Child_refs => GetProperty("child_refs").ModelObjectArrayValue;

	public ModelObject Parent_ref => GetProperty("parent_ref").ModelObjectValue;

	public AIEComponentInfo Comp_ref => (AIEComponentInfo)GetProperty("comp_ref").ModelObjectValue;

	public AIEExportNode(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
