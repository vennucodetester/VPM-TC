using System;
using System.Collections.Generic;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Soa.Client.Model;

public class ConditionChoices<CCT>
{
	private List<Choice<CCT>> choices = null;

	private ConditionResolver resolver = null;

	public ConditionChoices()
	{
		choices = new List<Choice<CCT>>();
		resolver = ConditionResolver.GetResolver(null);
	}

	public ConditionChoices(Connection connection)
	{
		choices = new List<Choice<CCT>>();
		resolver = ConditionResolver.GetResolver(connection);
	}

	public void addChoice(CCT choice)
	{
		addChoice(ConditionResolver.IS_TRUE, choice);
	}

	public void addChoice(string condition, CCT choice)
	{
		Choice<CCT> item = new Choice<CCT>(condition, choice);
		choices.Add(item);
	}

	public CCT getFirst()
	{
		for (int i = 0; i < choices.Count; i++)
		{
			Choice<CCT> choice = choices[i];
			if (resolver.IsATrueCondition(choice.condition))
			{
				if (choice.element is DynamicLovInfo)
				{
					Type typeFromHandle = typeof(DynamicLovInfo);
					DynamicLovInfo dynamicLovInfo = (DynamicLovInfo)Convert.ChangeType(choice.element, typeFromHandle);
					object obj = dynamicLovInfo.Resolve();
					choice.element = (CCT)obj;
				}
				else if (choice.element is DynamicLov)
				{
					Type typeFromHandle2 = typeof(DynamicLov);
					DynamicLov dynamicLov = (DynamicLov)Convert.ChangeType(choice.element, typeFromHandle2);
					object obj2 = dynamicLov.Resolve();
					choice.element = (CCT)obj2;
				}
				return choice.element;
			}
		}
		return default(CCT);
	}

	public CCT peek()
	{
		if (choices.Count == 0)
		{
			return default(CCT);
		}
		return choices[0].element;
	}

	public string peekAtCondition()
	{
		if (choices.Count == 0)
		{
			return "";
		}
		return choices[0].condition;
	}

	public IList<CCT> getAll()
	{
		List<CCT> list = new List<CCT>();
		for (int i = 0; i < choices.Count; i++)
		{
			Choice<CCT> choice = choices[i];
			if (!resolver.IsATrueCondition(choice.condition))
			{
				continue;
			}
			if (choice.element is DynamicLovValues)
			{
				Type typeFromHandle = typeof(DynamicLovValues);
				DynamicLovValues dynamicLovValues = (DynamicLovValues)Convert.ChangeType(choice.element, typeFromHandle);
				IList<LovValue> list2 = dynamicLovValues.Resolve();
				choices.Remove(choice);
				foreach (LovValue item in list2)
				{
					addChoice((CCT)item);
				}
				return getAll();
			}
			list.Add(choice.element);
		}
		return list;
	}
}
