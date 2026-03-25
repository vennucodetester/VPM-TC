namespace Teamcenter.Soa.Client.Model.Strong;

public class AppGroupBOPLine : ImanItemBOPLine
{
	public ModelObject Appgrpbl_get_appgrpline => GetProperty("appgrpbl_get_appgrpline").ModelObjectValue;

	public ModelObject[] Bl_occgrp_visible_lines => GetProperty("bl_occgrp_visible_lines").ModelObjectArrayValue;

	public AppGroupBOPLine(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
