namespace Teamcenter.Soa.Client.Model.Strong;

public class ArcWeldRevisionMaster : POM_object
{
	public string MajorFeatureVersion => GetProperty("MajorFeatureVersion").StringValue;

	public string MinorFeatureVersion => GetProperty("MinorFeatureVersion").StringValue;

	public ArcWeldRevisionMaster(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
