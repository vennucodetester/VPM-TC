using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface ToolAction
{
	string Name { get; }

	IList<ActionReference> ActionReferences { get; }

	IList<string> ActionReferenceNames { get; }

	ActionReference GetActionReference(string name);
}
