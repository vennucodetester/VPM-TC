using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface Reference
{
	string Name { get; }

	IList<string> Templates { get; }

	IList<string> Formats { get; }
}
