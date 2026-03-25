namespace Teamcenter.Soa.Client.Model.Strong;

public class Document_Master : Form
{
	public string Title => GetProperty("Title").StringValue;

	public string Author => GetProperty("Author").StringValue;

	public string Subject => GetProperty("Subject").StringValue;

	public string[] Keywords => GetProperty("Keywords").StringArrayValue;

	public Document_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
