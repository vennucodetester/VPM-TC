using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface LovInfo
{
	string Uid { get; }

	string Name { get; }

	string DisplayName { get; }

	string Description { get; }

	string DisplayDescription { get; }

	SoaType Type { get; }

	int ValueType { get; }

	Usage Usage { get; }

	IList<LovValue> Values { get; }
}
