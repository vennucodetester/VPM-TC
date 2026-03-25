using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class RevNameRuleImpl : RevNameRule
{
	private readonly string mName;

	private readonly string mInitStart;

	private readonly string mInitDescription;

	private readonly RuleType mInitType;

	private readonly string mSecondStart;

	private readonly string mSecondDescription;

	private readonly RuleType mSecondType;

	private readonly bool mExcludeLetters;

	private readonly string mSkipLetters;

	private readonly AlphabeticCase mAlphaCase;

	private readonly SupplementalRuleType mSuppType;

	public string Name => mName;

	public string StartingRevision => mInitStart;

	public RuleType Type => mInitType;

	public bool ExludeSkipLetters => mExcludeLetters;

	public string Description => mInitDescription;

	public string SecondaryStartingRevision => mSecondStart;

	public string SecondaryDescription => mSecondDescription;

	public RuleType SecondaryType => mSecondType;

	public string SkipLetters => mSkipLetters;

	public AlphabeticCase AlphabeticCase => mAlphaCase;

	public SupplementalRuleType SupplementalType => mSuppType;

	public static RuleType ConstructRuleType(int value)
	{
		return value switch
		{
			1 => RuleType.Numeric, 
			2 => RuleType.Alphabetic, 
			3 => RuleType.Alphanumeric, 
			_ => RuleType.NoSecondaryFormat, 
		};
	}

	public static SupplementalRuleType ConstructSuppRuleType(int value)
	{
		return value switch
		{
			1 => SupplementalRuleType.NumericNoZeroFill, 
			2 => SupplementalRuleType.FixedTwoDigitsZeroFill, 
			3 => SupplementalRuleType.FixedThreeDigitsZeroFill, 
			4 => SupplementalRuleType.FixedFourDigitsZeroFill, 
			5 => SupplementalRuleType.CurrentRevLetterNumericNoZeroFill, 
			6 => SupplementalRuleType.CurrentRevLetterFixedOneDigit, 
			7 => SupplementalRuleType.CurrentRevLetterFixedTwoDigitsZeroFill, 
			8 => SupplementalRuleType.NextRevLetterNumericNoZeroFill, 
			9 => SupplementalRuleType.NextRevLetterFixedOneDigit, 
			10 => SupplementalRuleType.NextRevLetterFixedTwoDigitsZeroFill, 
			_ => SupplementalRuleType.NoSupplFormat, 
		};
	}

	public static AlphabeticCase ConstructAlphaCase(int value)
	{
		return value switch
		{
			1 => AlphabeticCase.Lower, 
			2 => AlphabeticCase.Upper, 
			_ => AlphabeticCase.Mixed, 
		};
	}

	public RevNameRuleImpl(string name, string initStart, string initDescription, RuleType initType, string secondStart, string secondDescription, RuleType secondType, bool excludeLetters, string skipLetters, AlphabeticCase alphaCase, SupplementalRuleType suppRuleType)
	{
		mName = name;
		mInitStart = initStart;
		mInitDescription = initDescription;
		mInitType = initType;
		mSecondStart = secondStart;
		mSecondDescription = secondDescription;
		mSecondType = secondType;
		mExcludeLetters = excludeLetters;
		mSkipLetters = skipLetters;
		mAlphaCase = alphaCase;
		mSuppType = suppRuleType;
	}
}
