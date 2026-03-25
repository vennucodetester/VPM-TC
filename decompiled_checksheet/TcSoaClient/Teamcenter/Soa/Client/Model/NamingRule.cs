using System;
using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface NamingRule
{
	[Obsolete("Deprecated 10.0. Use Patterns")]
	string Pattern { get; }

	RuleCase Case { get; }

	IList<RulePattern> Patterns { get; }
}
