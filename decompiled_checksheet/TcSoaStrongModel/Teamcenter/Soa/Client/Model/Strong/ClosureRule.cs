namespace Teamcenter.Soa.Client.Model.Strong;

public class ClosureRule : POM_object
{
	public string Name => GetProperty("name").StringValue;

	public string Description => GetProperty("description").StringValue;

	public int Scope => GetProperty("scope").IntValue;

	public string[] Clauses => GetProperty("clauses").StringArrayValue;

	public string[] Comments => GetProperty("comments").StringArrayValue;

	public int[] Depth => GetProperty("depth").IntArrayValue;

	public int Schema_format => GetProperty("schema_format").IntValue;

	public ClosureRule(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
