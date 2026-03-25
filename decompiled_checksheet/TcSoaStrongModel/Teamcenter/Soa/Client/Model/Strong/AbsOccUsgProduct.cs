namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccUsgProduct : AbsOccData
{
	public string[] Usg_product_list => GetProperty("usg_product_list").StringArrayValue;

	public AbsOccUsgProduct(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
