using System;

namespace Teamcenter.Soa.Client.Model;

public interface LovValue
{
	object Value { get; }

	char CharacterValue { get; }

	DateTime DateTimeValue { get; }

	double DoubleValue { get; }

	int IntegerValue { get; }

	string StringValue { get; }

	ModelObject ModelObjectValue { get; }

	string DisplayValue { get; }

	bool HasDescription { get; }

	string Description { get; }

	string DisplayDescription { get; }

	LovInfo ChildLov { get; }

	string GetFullDisplayValue(string delimiter);
}
