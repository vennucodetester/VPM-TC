namespace Teamcenter.Soa.Client.Model.Strong;

public class ConfigurationFamily : POM_object
{
	public string Namespace => GetProperty("namespace").StringValue;

	public string Name => GetProperty("name").StringValue;

	public int Mode => GetProperty("mode").IntValue;

	public UnitOfMeasure Uom => (UnitOfMeasure)GetProperty("uom").ModelObjectValue;

	public string Description => GetProperty("description").StringValue;

	public bool IsMandatory => GetProperty("isMandatory").BoolValue;

	public bool IsModelFamily => GetProperty("isModelFamily").BoolValue;

	public string Fnd0valueScope => GetProperty("fnd0valueScope").StringValue;

	public ConfigurationFamily(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
