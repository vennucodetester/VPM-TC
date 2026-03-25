using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ConfigurationExprLiteral : POM_object
{
	public ConfigurationFamily Family => (ConfigurationFamily)GetProperty("family").ModelObjectValue;

	public int Operator => GetProperty("operator").IntValue;

	public double Value_numeric => GetProperty("value_numeric").DoubleValue;

	public string Value_text => GetProperty("value_text").StringValue;

	public DateTime Value_date => GetProperty("value_date").DateValue;

	public ConfigurationExprLiteral(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
