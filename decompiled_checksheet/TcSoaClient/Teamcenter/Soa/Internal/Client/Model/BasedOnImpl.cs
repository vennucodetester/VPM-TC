using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class BasedOnImpl : BasedOn
{
	private readonly string mSourceType;

	private readonly string mSourceProperty;

	public string SourceType => mSourceType;

	public string SourceProperty => mSourceProperty;

	public BasedOnImpl(string sourceType, string sourceProperty)
	{
		mSourceType = sourceType;
		mSourceProperty = sourceProperty;
	}
}
