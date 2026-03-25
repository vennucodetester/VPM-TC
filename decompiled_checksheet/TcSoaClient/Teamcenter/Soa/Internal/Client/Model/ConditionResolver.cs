using System.Collections.Generic;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ConditionResolver : SessionHandler
{
	public static readonly string IS_TRUE = "isTrue";

	private static Dictionary<Connection, ConditionResolver> conditionResolvers = new Dictionary<Connection, ConditionResolver>();

	private static ConditionResolver isTrueResolver = new ConditionResolver();

	private Dictionary<string, string> trueConditions;

	public ConditionResolver()
	{
		trueConditions = new Dictionary<string, string>();
		trueConditions[IS_TRUE] = IS_TRUE;
	}

	public override void LocalSessionChange(ModelObject userSession)
	{
		setTrueCondtions(userSession);
	}

	public override void SharedSessionChange(ModelObject userSession)
	{
		setTrueCondtions(userSession);
	}

	private void setTrueCondtions(ModelObject userSession)
	{
		trueConditions.Clear();
		trueConditions[IS_TRUE] = IS_TRUE;
		try
		{
			string[] stringArrayValue = userSession.GetProperty("fnd0isTrueConditions").StringArrayValue;
			for (int i = 0; i < stringArrayValue.Length; i++)
			{
				trueConditions[stringArrayValue[i]] = stringArrayValue[i];
			}
		}
		catch (NotLoadedException)
		{
		}
	}

	public bool IsATrueCondition(string condition)
	{
		return trueConditions.ContainsKey(condition);
	}

	public static ConditionResolver GetResolver(Connection connection)
	{
		if (connection == null)
		{
			return isTrueResolver;
		}
		if (!conditionResolvers.ContainsKey(connection))
		{
			ConditionResolver conditionResolver = new ConditionResolver();
			ModelObject userSessionObject = connection.ModelManager.GetUserSessionObject();
			if (userSessionObject != null)
			{
				conditionResolver.LocalSessionChange(userSessionObject);
			}
			connection.ModelManager.AddSharedSessionHandler(conditionResolver);
			conditionResolvers[connection] = conditionResolver;
		}
		return conditionResolvers[connection];
	}
}
