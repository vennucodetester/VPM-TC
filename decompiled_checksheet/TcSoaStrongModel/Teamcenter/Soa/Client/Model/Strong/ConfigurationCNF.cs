using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ConfigurationCNF : POM_object
{
	public int[] ClauseIDs => GetProperty("clauseIDs").IntArrayValue;

	public int Clause_count => GetProperty("clause_count").IntValue;

	public int Fingerprint => GetProperty("fingerprint").IntValue;

	public int Sequence => GetProperty("sequence").IntValue;

	public ConfigurationExprLiteral[] Clause_literals
	{
		get
		{
			IList modelObjectListValue = GetProperty("clause_literals").ModelObjectListValue;
			ConfigurationExprLiteral[] array = new ConfigurationExprLiteral[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ConfigurationCNF(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
