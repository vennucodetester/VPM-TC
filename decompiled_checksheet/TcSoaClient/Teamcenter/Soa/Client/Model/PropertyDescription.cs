namespace Teamcenter.Soa.Client.Model;

public interface PropertyDescription
{
	string Name { get; }

	int Type { get; }

	bool Array { get; }

	bool Modifiable { get; }

	int MaxArraySize { get; }

	string UiName { get; }

	string TypeUid { get; }

	bool Displayable { get; }

	int MaxLength { get; }

	string MaxValue { get; }

	string MinValue { get; }

	int AttachedSpecifier { get; }

	string LovTypeUid { get; }

	bool Required { get; }

	bool Localizable { get; }

	string InitialValue { get; }

	int ServerType { get; }

	int ServerPropertyType { get; }

	bool Enabled { get; }

	PropertyFieldType FieldType { get; }

	string CompoundObjectType { get; }

	LovCategory LovCategory { get; }

	string[] PropDependants { get; }

	string LovUid { get; }

	Lov LovReference { get; }

	string RootLovPropertyName { get; }

	NamingRule NamingRule { get; }

	RuleCategory NamingRuleCategory { get; }

	string Renderer { get; }

	BasedOn BasedOn { get; }

	string GetConstant(string name);
}
