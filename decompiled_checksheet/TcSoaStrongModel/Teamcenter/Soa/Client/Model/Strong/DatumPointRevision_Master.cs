namespace Teamcenter.Soa.Client.Model.Strong;

public class DatumPointRevision_Master : Form
{
	public string MajorFeatureVersion => GetProperty("MajorFeatureVersion").StringValue;

	public string MinorFeatureVersion => GetProperty("MinorFeatureVersion").StringValue;

	public DatumPointRevision_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
