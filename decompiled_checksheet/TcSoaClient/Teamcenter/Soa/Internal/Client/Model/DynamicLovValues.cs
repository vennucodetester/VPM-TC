using System;
using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Internal.Loose.Core;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common;
using Teamcenter.Soa.Exceptions;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class DynamicLovValues : LovValue
{
	private static ILog logger = LogManager.GetLogger(typeof(DynamicLovValues));

	private static Dictionary<Connection, string> sLovPolicies = new Dictionary<Connection, string>();

	private static readonly string LovValues = "lov_values";

	private static readonly string LovValueFilters = "value_filters";

	private static readonly string LovValueFiltersIndexs = "value_filters_indexes";

	private static readonly string LovValueDescriptions = "lov_value_descriptions";

	private static readonly string LovLowerLimit = "lov_lower_limit";

	private static readonly string LovUpperLimit = "lov_upper_limit";

	private static readonly string BasedOnLov = "based_on_lov";

	private static readonly string ShownValueIdexes = "shown_value_indexes";

	private readonly string mUid;

	private readonly string mLovName;

	private readonly SoaType mType;

	private readonly Usage mUsage;

	private readonly Connection mConnection;

	public object Value
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public string DisplayValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public bool HasDescription
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public string Description
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public string DisplayDescription
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public LovInfo ChildLov
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public char CharacterValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public DateTime DateTimeValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public double DoubleValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public int IntegerValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public string StringValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public ModelObject ModelObjectValue
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
		}
	}

	public DynamicLovValues(string uid, string lovName, SoaType type, Usage useage, Connection connection)
	{
		mUid = uid;
		mLovName = lovName;
		mType = type;
		mUsage = useage;
		mConnection = connection;
	}

	public IList<LovValue> Resolve()
	{
		return Resolve(haveFetched: false);
	}

	private IList<LovValue> Resolve(bool haveFetched)
	{
		List<LovValue> list = new List<LovValue>();
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		ClientDataModel clientDataModel = mConnection.ClientDataModel;
		ModelObject modelObject;
		try
		{
			modelObject = clientDataModel.GetObject(mUid);
		}
		catch (ArgumentException)
		{
			modelObject = clientDataModel.ConstructObject(mType, mUid);
		}
		try
		{
			ModelObject modelObject2 = null;
			ModelObject modelObject3 = modelObject;
			SoaType soaType = modelObject.SoaType;
			if (soaType.IsInstanceOf("ListOfValuesFilter"))
			{
				modelObject2 = modelObject.GetProperty(BasedOnLov).ModelObjectValue;
				modelObject3 = modelObject2;
			}
			int type = modelObject3.SoaType.GetPropDesc(LovValues).Type;
			if (mUsage == Usage.Range)
			{
				ConditionChoices<LovInfo> childLovChoices = new ConditionChoices<LovInfo>();
				string sValue = modelObject3.GetProperty(LovLowerLimit).ToNeutralString();
				string sValue2 = modelObject3.GetProperty(LovUpperLimit).ToNeutralString();
				string dislayValue = modelObject3.GetProperty(LovLowerLimit).DisplayableValue;
				string dislayValue2 = modelObject3.GetProperty(LovUpperLimit).DisplayableValue;
				object obj = DefaultClientMetaModel.ParseLovValue(type, sValue, mConnection);
				object obj2 = DefaultClientMetaModel.ParseLovValue(type, sValue2, mConnection);
				if (obj is DateTime dateTime)
				{
					dislayValue = dateTime.ToString(mConnection.ClientMetaModel.GetDateDisplayFormat());
					dislayValue2 = ((DateTime)obj2).ToString(mConnection.ClientMetaModel.GetDateDisplayFormat());
				}
				if (obj is double num)
				{
					dislayValue = num.ToString(mConnection.ClientMetaModel.GetDoublePrecision());
					dislayValue2 = ((double)obj2).ToString(mConnection.ClientMetaModel.GetDoublePrecision());
				}
				LovValue item = objectFactory.ConstructLovValue(obj, dislayValue, "", "", childLovChoices);
				LovValue item2 = objectFactory.ConstructLovValue(obj2, dislayValue2, "", "", childLovChoices);
				list.Add(item);
				list.Add(item2);
				return list;
			}
			string[] displayableValues = modelObject3.GetProperty(LovValues).DisplayableValues;
			IList<string> list2 = modelObject3.GetProperty(LovValues).ToNeutralStrings();
			string[] stringArrayValue = modelObject3.GetProperty(LovValueDescriptions).StringArrayValue;
			string[] displayableValues2 = modelObject3.GetProperty(LovValueDescriptions).DisplayableValues;
			ModelObject[] modelObjectArrayValue = modelObject.GetProperty(LovValueFilters).ModelObjectArrayValue;
			int[] intArrayValue = modelObject.GetProperty(LovValueFiltersIndexs).IntArrayValue;
			if (list2.Count != displayableValues.Length)
			{
				logger.Warn("Have ListOfValues instance in the Client Data Model, but don't have the UI Values");
				throw new NotLoadedException("Display values do not match DB values");
			}
			if (type == 1)
			{
				DateTime[] dateArrayValue = modelObject3.GetProperty(LovValues).DateArrayValue;
				string dateDisplayFormat = mConnection.ClientMetaModel.GetDateDisplayFormat();
				for (int i = 0; i < dateArrayValue.Length; i++)
				{
					displayableValues[i] = dateArrayValue[i].ToString(dateDisplayFormat);
				}
			}
			int[] array;
			if (modelObject2 == null)
			{
				array = new int[list2.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = i;
				}
			}
			else
			{
				array = modelObject.GetProperty(ShownValueIdexes).IntArrayValue;
			}
			if (stringArrayValue.Length <= 0 && sortModelObjectValuesNeeded(type, soaType))
			{
				SortModelObjectValues(list2, displayableValues);
			}
			for (int i = 0; i < array.Length; i++)
			{
				int num2 = array[i];
				ConditionChoices<LovInfo> childLovChoices = new ConditionChoices<LovInfo>();
				for (int j = 0; j < intArrayValue.Length; j++)
				{
					if (i == intArrayValue[j])
					{
						LovInfo choice = new DynamicLovInfo(modelObjectArrayValue[j].Uid, modelObjectArrayValue[j].SoaType, mConnection, "", "");
						childLovChoices.addChoice(choice);
						break;
					}
				}
				string description = ((stringArrayValue.Length > num2) ? stringArrayValue[num2] : "");
				string displayDescription = ((displayableValues2.Length > num2) ? displayableValues2[num2] : "");
				object value = DefaultClientMetaModel.ParseLovValue(type, list2[num2], mConnection);
				LovValue item3 = objectFactory.ConstructLovValue(value, displayableValues[num2], description, displayDescription, childLovChoices);
				list.Add(item3);
			}
			return list;
		}
		catch (NotLoadedException ex2)
		{
			if (!haveFetched)
			{
				logger.Info("Resolving LovValues for " + mLovName);
				GetLOVProperties(new ModelObject[1] { modelObject });
				return Resolve(haveFetched: true);
			}
			logger.Error("Failed to load properties for LovValues " + mLovName + " (" + mUid + ")\n" + ex2.Message);
			return list;
		}
	}

	private void InitializePolicy()
	{
		if (sLovPolicies.ContainsKey(mConnection))
		{
			return;
		}
		string[] properties = new string[4] { LovValues, LovValueDescriptions, LovValueFilters, LovValueFiltersIndexs };
		string[] properties2 = new string[6] { LovValues, LovValueDescriptions, LovValueFilters, LovValueFiltersIndexs, LovLowerLimit, LovUpperLimit };
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		objectPropertyPolicy.AddType("ListOfValuesChar", properties2);
		objectPropertyPolicy.AddType("ListOfValuesDate", properties2);
		objectPropertyPolicy.AddType("ListOfValuesDouble", properties2);
		objectPropertyPolicy.AddType("ListOfValuesInteger", properties2);
		objectPropertyPolicy.AddType("ListOfValuesString", properties2);
		objectPropertyPolicy.AddType("ListOfValuesTag", properties);
		PolicyType policyType = new PolicyType("ListOfValuesFilter");
		policyType.AddProperty(new PolicyProperty(BasedOnLov, new string[1] { PolicyProperty.WITH_PROPERTIES }));
		policyType.AddProperty(new PolicyProperty(ShownValueIdexes));
		policyType.AddProperty(new PolicyProperty(LovValueFilters));
		policyType.AddProperty(new PolicyProperty(LovValueFiltersIndexs));
		objectPropertyPolicy.AddType(policyType);
		try
		{
			string value = mConnection.ObjectPropertyPolicyManager.AddPolicy(objectPropertyPolicy, useRefCounting: false);
			sLovPolicies[mConnection] = value;
		}
		catch (ServiceException)
		{
		}
	}

	private void GetLOVProperties(ModelObject[] listOfValues)
	{
		InitializePolicy();
		try
		{
			SessionService service = SessionService.getService(mConnection);
			mConnection.ObjectPropertyPolicyManager.SetPolicyPerThread(sLovPolicies[mConnection]);
			service.GetProperties(listOfValues, new string[0]);
		}
		catch (ServiceException)
		{
		}
		finally
		{
			mConnection.ObjectPropertyPolicyManager.ClearPolicyPerThread();
		}
	}

	public string GetFullDisplayValue(string delimiter)
	{
		throw new ArgumentException("Do not use DynamicLovValues as a pure LOV implemenation.");
	}

	private static bool sortModelObjectValuesNeeded(int valueType, SoaType lovType)
	{
		if (valueType == 8 || lovType.Name.Equals("ListOfValuesStringExtent"))
		{
			return true;
		}
		return false;
	}

	private static void SortModelObjectValues(IList<string> values, string[] displayValues)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < displayValues.Length; i++)
		{
			dictionary[displayValues[i]] = values[i];
		}
		Array.Sort(displayValues, new JavaStyleStringCompare());
		values.Clear();
		for (int j = 0; j < displayValues.Length; j++)
		{
			values.Add(dictionary[displayValues[j]]);
		}
	}
}
