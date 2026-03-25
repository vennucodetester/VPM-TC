namespace Teamcenter.Soa.Client.Model;

public interface ActionReference
{
	string Name { get; }

	Reference Reference { get; }

	bool IsExport { get; }
}
