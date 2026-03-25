namespace Teamcenter.Soa.Client.Model;

public interface ModelObject
{
	string Uid { get; }

	SoaType SoaType { get; }

	bool IsHistorical { get; }

	bool IsObsolete { get; }

	string[] PropertyNames { get; }

	bool HasSameObjectID(ModelObject targetObject);

	bool HasSameCParam(ModelObject targetObject);

	Property GetProperty(string name);

	string GetPropertyDisplayableValue(string name);

	string[] GetPropertyDisplayableValues(string name);
}
