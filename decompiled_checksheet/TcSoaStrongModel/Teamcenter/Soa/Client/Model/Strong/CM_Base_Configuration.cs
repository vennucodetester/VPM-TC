using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CM_Base_Configuration : Form
{
	public string End_item_str => GetProperty("end_item_str").StringValue;

	public int Unit_no => GetProperty("unit_no").IntValue;

	public DateTime From_date => GetProperty("from_date").DateValue;

	public CM_Base_Configuration(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
