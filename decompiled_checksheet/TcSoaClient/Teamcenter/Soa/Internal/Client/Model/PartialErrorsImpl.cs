using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PartialErrorsImpl : PartialErrors
{
	private ErrorStack[] errorStacks = new ErrorStack[0];

	public int sizeOfPartialErrors()
	{
		return errorStacks.Length;
	}

	public ErrorStack GetPartialError(int index)
	{
		return errorStacks[index];
	}

	public void SetPartialErrors(ErrorStack[] errors)
	{
		errorStacks = errors;
	}
}
