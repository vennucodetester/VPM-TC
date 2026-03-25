namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccUsgPartID : AbsOccData
{
	public string[] Usg_part_id_list => GetProperty("usg_part_id_list").StringArrayValue;

	public AbsOccUsgPartID(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
