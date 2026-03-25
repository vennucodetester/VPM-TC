namespace Teamcenter.Soa.Client.Model;

public interface RevNameRule
{
	string Name { get; }

	string StartingRevision { get; }

	string Description { get; }

	RuleType Type { get; }

	string SecondaryStartingRevision { get; }

	string SecondaryDescription { get; }

	RuleType SecondaryType { get; }

	bool ExludeSkipLetters { get; }

	string SkipLetters { get; }

	AlphabeticCase AlphabeticCase { get; }

	SupplementalRuleType SupplementalType { get; }
}
