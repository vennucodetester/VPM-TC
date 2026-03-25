namespace Teamcenter.Soa.Internal.Client.Model;

public class Choice<CT>
{
	public readonly string condition;

	public CT element;

	public Choice(string lCondition, CT lElement)
	{
		condition = ((lCondition == null) ? ConditionResolver.IS_TRUE : lCondition);
		element = lElement;
	}
}
