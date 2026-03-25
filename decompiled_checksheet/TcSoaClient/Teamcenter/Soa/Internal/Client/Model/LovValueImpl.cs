using System;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class LovValueImpl : LovValue
{
	private readonly object mValue;

	private readonly string mDisplayValue;

	private readonly string mDescription;

	private readonly string mDisplayDescription;

	private readonly ConditionChoices<LovInfo> mChildLovChoices;

	public object Value => mValue;

	public char CharacterValue => (char)mValue;

	public DateTime DateTimeValue => (DateTime)mValue;

	public double DoubleValue => (double)mValue;

	public int IntegerValue => (int)mValue;

	public string StringValue => (string)mValue;

	public ModelObject ModelObjectValue => (ModelObject)mValue;

	public string DisplayValue => mDisplayValue;

	public bool HasDescription => mDescription != null;

	public string Description => mDescription;

	public string DisplayDescription => mDisplayDescription;

	public LovInfo ChildLov => mChildLovChoices.getFirst();

	public LovValueImpl(object value, string displayValue, string description, string dipslayDescription, ConditionChoices<LovInfo> childLovChoices)
	{
		mValue = value;
		mDisplayValue = displayValue;
		mDescription = description;
		mDisplayDescription = dipslayDescription;
		mChildLovChoices = childLovChoices;
	}

	public string GetFullDisplayValue(string delimiter)
	{
		string text = mDisplayValue;
		if (mDisplayDescription != null)
		{
			text = text + delimiter + " " + mDisplayDescription;
		}
		return text;
	}
}
