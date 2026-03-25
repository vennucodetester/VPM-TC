using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CSYS_Interface_Form : Form
{
	public string Name => GetProperty("Name").StringValue;

	public string Description => GetProperty("Description").StringValue;

	public string Type => GetProperty("Type").StringValue;

	public string Status => GetProperty("Status").StringValue;

	public string Parent_Part => GetProperty("Parent_Part").StringValue;

	public DateTime Modified_Date => GetProperty("Modified_Date").DateValue;

	public string GCS_Index => GetProperty("GCS_Index").StringValue;

	public string[] Fnd0sync_checksums => GetProperty("fnd0sync_checksums").StringArrayValue;

	public CSYS_Interface_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
