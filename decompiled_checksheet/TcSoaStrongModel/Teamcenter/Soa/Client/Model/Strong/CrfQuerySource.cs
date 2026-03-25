namespace Teamcenter.Soa.Client.Model.Strong;

public class CrfQuerySource : POM_object
{
	public int Qry_src_type => GetProperty("qry_src_type").IntValue;

	public ModelObject Qry_src_generic_data_source => GetProperty("qry_src_generic_data_source").ModelObjectValue;

	public ImanQuery Qry_src_tc_qry => (ImanQuery)GetProperty("qry_src_tc_qry").ModelObjectValue;

	public TransferMode Qry_src_tc_transfer_mode => (TransferMode)GetProperty("qry_src_tc_transfer_mode").ModelObjectValue;

	public CrfQuerySource(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
