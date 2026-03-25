using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class NamingRuleImpl : NamingRule
{
	private readonly string mPattern;

	private readonly RuleCase mCase;

	private readonly IList<RulePattern> mPatterns;

	public string Pattern => mPattern;

	public RuleCase Case => mCase;

	public IList<RulePattern> Patterns => mPatterns;

	public NamingRuleImpl(string pattern, RuleCase caze, IList<RulePattern> patterns)
	{
		mPattern = pattern;
		mCase = caze;
		mPatterns = patterns;
	}
}
