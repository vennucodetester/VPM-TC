using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface Lov
{
	Style Style { get; }

	IList<string> DependantProperties { get; }

	IList<Style> DependantStyles { get; }

	string Uid { get; }

	int Specifier { get; }

	LovInfo LovInfo { get; }
}
