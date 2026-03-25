namespace Teamcenter.Soa.Client.Model.Strong;

public class Bldb0 : POM_object
{
	public string Cid => GetProperty("cid").StringValue;

	public string Sid => GetProperty("sid").StringValue;

	public int Type => GetProperty("type").IntValue;

	public string Name => GetProperty("name").StringValue;

	public string Sname => GetProperty("sname").StringValue;

	public string Gfile => GetProperty("gfile").StringValue;

	public int Sflags => GetProperty("sflags").IntValue;

	public string Ext_1 => GetProperty("ext_1").StringValue;

	public string Ext_2 => GetProperty("ext_2").StringValue;

	public string Descr => GetProperty("descr").StringValue;

	public string Comment => GetProperty("comment").StringValue;

	public string[] Shared_sites => GetProperty("shared_sites").StringArrayValue;

	public ModelObject Default_template => GetProperty("default_template").ModelObjectValue;

	public string Cr_uid => GetProperty("cr_uid").StringValue;

	public string Cr_gid => GetProperty("cr_gid").StringValue;

	public string Cr_date => GetProperty("cr_date").StringValue;

	public string Mod_uid => GetProperty("mod_uid").StringValue;

	public string Mod_date => GetProperty("mod_date").StringValue;

	public int Gac => GetProperty("gac").IntValue;

	public int Wac => GetProperty("wac").IntValue;

	public string ConceptID => GetProperty("conceptID").StringValue;

	public Bldb0(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
