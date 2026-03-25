namespace Teamcenter.Soa.Client.Model.Strong;

public class DatumPointRevisionMaster : POM_object
{
	public string MajorFeatureVersion => GetProperty("MajorFeatureVersion").StringValue;

	public string MinorFeatureVersion => GetProperty("MinorFeatureVersion").StringValue;

	public DatumPointRevisionMaster(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
