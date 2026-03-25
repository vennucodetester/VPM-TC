namespace Teamcenter.Soa.Client.Model.Strong;

public class DocumentRevision : ItemRevision
{
	public string DocumentTitle => GetProperty("DocumentTitle").StringValue;

	public string DocumentAuthor => GetProperty("DocumentAuthor").StringValue;

	public string DocumentSubject => GetProperty("DocumentSubject").StringValue;

	public DocumentRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
