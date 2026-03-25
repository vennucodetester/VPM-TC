using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface DatasetType : SoaType
{
	IList<Tool> ViewTools { get; }

	IList<Tool> EditTools { get; }

	IList<Reference> References { get; }

	IList<string> ReferenceNames { get; }

	Tool GetViewTool(string name);

	Tool GetEditTool(string name);

	Reference GetReference(string name);
}
