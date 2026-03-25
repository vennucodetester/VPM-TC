namespace Teamcenter.Soa.Client.Model.Strong;

public class Drawing_Revision : ItemRevision
{
	public string Author => GetProperty("author").StringValue;

	public ModelObject[] TC_DrawingOf => GetProperty("TC_DrawingOf").ModelObjectArrayValue;

	public ModelObject[] TC_DrawingUsing => GetProperty("TC_DrawingUsing").ModelObjectArrayValue;

	public Drawing_Revision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
