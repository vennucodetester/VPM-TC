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

public class DynamicLovInfo : LovInfo
{
	private static ILog logger = LogManager.GetLogger(typeof(DynamicLov));

	private static Dictionary<Connection, string> sLovPolicies = new Dictionary<Connection, string>();

	private static readonly string LovUsage = "lov_usage";

	private static readonly string LovName = "lov_name";

	private static readonly string LovDesc = "lov_desc";

	private static readonly string LovAttachedProps = "lov_attached_properties";

	private static readonly string LovAttachedSpecs = "lov_attached_specifiers";

	private static readonly string LovAttachedTypes = "lov_attached_types";

	private static readonly string BasedOnLov = "based_on_lov";

	private static readonly string ShownValueIdexes = "shown_value_indexes";

	private readonly string mUid;

	private readonly SoaType mType;

	private readonly Connection mConnection;

	private readonly string mOwningType;

	private readonly string mOwningProp;

	public string Uid
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public string Name
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public string DisplayName
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public string Description
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public string DisplayDescription
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public SoaType Type
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public int ValueType
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public Usage Usage
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public IList<LovValue> Values
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLovInfo as a pure LovInfo implemenation.");
		}
	}

	public DynamicLovInfo(string uid, SoaType type, Connection connection, string owningType, string owningProp)
	{
		mUid = uid;
		mType = type;
		mConnection = connection;
		mOwningType = owningType;
		mOwningProp = owningProp;
	}

	public LovInfo Resolve()
	{
		ClientDataModel clientDataModel = mConnection.ClientDataModel;
		ClientMetaModel clientMetaModel = mConnection.ClientMetaModel;
		if (clientMetaModel.ContainsLovInfo(mUid) && clientDataModel.ContainsObject(mUid))
		{
			return clientMetaModel.GetLovInfo(mUid, mType, mConnection);
		}
		return Resolve(haveFetched: false);
	}

	private LovInfo Resolve(bool haveFetched)
	{
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
			string stringValue = modelObject.GetProperty(LovName).StringValue;
			string displayableValue = modelObject.GetProperty(LovName).DisplayableValue;
			string[] stringArrayValue = modelObject.GetProperty(LovAttachedProps).StringArrayValue;
			int[] intArrayValue = modelObject.GetProperty(LovAttachedSpecs).IntArrayValue;
			string[] stringArrayValue2 = modelObject.GetProperty(LovAttachedTypes).StringArrayValue;
			int intValue = modelObject.GetProperty(LovUsage).IntValue;
			string stringValue2 = modelObject.GetProperty(LovDesc).StringValue;
			string displayableValue2 = modelObject.GetProperty(LovDesc).DisplayableValue;
			Usage usage = DefaultClientMetaModel.ParseUsage(Convert.ToString(intValue));
			IList<string> propNames = ToList(stringArrayValue);
			IList<string> typeNames = ToList(stringArrayValue2);
			IList<int> specifiers = ToList(intArrayValue);
			SoaType soaType = modelObject.SoaType;
			if (soaType.IsInstanceOf("ListOfValuesFilter"))
			{
				ModelObject modelObjectValue = modelObject.GetProperty(BasedOnLov).ModelObjectValue;
				soaType = modelObjectValue.SoaType;
			}
			int lovValueType = DefaultClientMetaModel.GetLovValueType(soaType);
			ConditionChoices<LovValue> conditionChoices = new ConditionChoices<LovValue>();
			LovValue choice = new DynamicLovValues(modelObject.Uid, stringValue, modelObject.SoaType, usage, mConnection);
			conditionChoices.addChoice(choice);
			LovInfo lovInfo = objectFactory.ConstructLovInfo(modelObject.Uid, stringValue, displayableValue, stringValue2, displayableValue2, modelObject.SoaType, lovValueType, usage, typeNames, propNames, specifiers, conditionChoices);
			DefaultClientMetaModel defaultClientMetaModel = (DefaultClientMetaModel)mConnection.ClientMetaModel;
			defaultClientMetaModel.AddDynamicLovInfo(lovInfo);
			return lovInfo;
		}
		catch (NotLoadedException ex2)
		{
			if (!haveFetched)
			{
				logger.Info("Resolving LovInfo for " + mOwningType + "/" + mOwningProp);
				GetLOVProperties(new ModelObject[1] { modelObject });
				return Resolve(haveFetched: true);
			}
			logger.Warn("Failed to load properties for LovInfo " + mOwningType + "/" + mOwningProp + " (" + mUid + ")\n" + ex2.Message);
			return null;
		}
	}

	private IList<string> ToList(string[] a)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < a.Length; i++)
		{
			list.Add(a[i]);
		}
		return list;
	}

	private IList<int> ToList(int[] a)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < a.Length; i++)
		{
			list.Add(a[i]);
		}
		return list;
	}

	private void InitializePolicy()
	{
		if (sLovPolicies.ContainsKey(mConnection))
		{
			return;
		}
		string[] properties = new string[6] { LovUsage, LovName, LovDesc, LovAttachedProps, LovAttachedSpecs, LovAttachedTypes };
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		objectPropertyPolicy.AddType("ListOfValues", properties);
		PolicyType policyType = new PolicyType("ListOfValuesFilter");
		policyType.AddProperty(new PolicyProperty(BasedOnLov, new string[1] { PolicyProperty.WITH_PROPERTIES }));
		policyType.AddProperty(new PolicyProperty(ShownValueIdexes));
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
}
