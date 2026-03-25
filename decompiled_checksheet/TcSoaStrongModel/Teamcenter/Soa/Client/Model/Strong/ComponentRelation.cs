namespace Teamcenter.Soa.Client.Model.Strong;

public class ComponentRelation : ImanRelation
{
	public int Rel_subtype => GetProperty("rel_subtype").IntValue;

	public ComponentRelation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
