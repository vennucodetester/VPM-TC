using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Teamcenter.Schemas.Core._2007_01.Session;
using Teamcenter.Schemas.Core._2008_06.Session;
using Teamcenter.Schemas.Core._2011_06.Session;
using Teamcenter.Schemas.Core._2012_02.Session;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Loose.Core;
using Teamcenter.Services.Loose.Core._2012_02.Session;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common;
using Teamcenter.Soa.Internal.Common;
using log4net;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class PolicyManager : ObjectPropertyPolicyManager
{
	private static ILog connectionLogger = LogManager.GetLogger(typeof(Connection));

	public static ILog logger = LogManager.GetLogger(typeof(PolicyManager));

	private static readonly Teamcenter.Soa.Common.Version v91 = new Teamcenter.Soa.Common.Version(9000, 1, 0);

	private static readonly Teamcenter.Soa.Common.Version v80 = new Teamcenter.Soa.Common.Version(8000, 0, 0);

	private static readonly string SESSION_0701_SERVICE = "Core-2007-01-Session";

	private static readonly string SESSION_0806_SERVICE = "Core-2008-06-Session";

	private static readonly string SESSION_1106_SERVICE = "Core-2011-06-Session";

	private static readonly string SESSION_1202_SERVICE = "Core-2012-02-Session";

	private static readonly string SET_POLICY_METHOD_0701 = SESSION_0701_SERVICE + ".SetObjectPropertyPolicy";

	private static readonly string SET_POLICY_METHOD_0806 = SESSION_0806_SERVICE + ".SetObjectPropertyPolicy";

	private static readonly string SET_POLICY_METHOD_1202 = SESSION_1202_SERVICE + ".SetObjectPropertyPolicy";

	private static readonly string UPDATE_POLICY_METHOD = SESSION_1106_SERVICE + ".UpdateObjectPropertyPolicy";

	private static Dictionary<Thread, Thread> managedRequests = new Dictionary<Thread, Thread>();

	private Connection mConnection;

	private string mCurrentPolicy;

	private string mPreviousPolicy;

	private Dictionary<Thread, string> mPerThreadPolicies = new Dictionary<Thread, string>();

	private Dictionary<string, string> mValidPolicies = new Dictionary<string, string>();

	private Dictionary<string, DynamicPolicy> mOjbectPropertyPolicies = new Dictionary<string, DynamicPolicy>();

	public IList<string> AvailablePolices
	{
		get
		{
			List<string> list = new List<string>();
			foreach (string key in mValidPolicies.Keys)
			{
				list.Add(key);
			}
			return list;
		}
	}

	public string PreviousPolicy => mPreviousPolicy;

	public string CurrentPolicy => mCurrentPolicy;

	public string Active
	{
		get
		{
			if (mPerThreadPolicies.ContainsKey(Thread.CurrentThread))
			{
				return mValidPolicies[mPerThreadPolicies[Thread.CurrentThread]];
			}
			return GetRealId(mCurrentPolicy);
		}
	}

	public PolicyManager(Connection connection)
	{
		mConnection = connection;
		Initialize("Default", "Default");
		mValidPolicies["Default"] = "Default";
		mValidPolicies["Empty"] = "Empty";
		mValidPolicies["empty"] = "empty";
	}

	public void Initialize(string current, string previous)
	{
		connectionLogger.Info(LogCorrelation.GetId() + ": initializePolicy " + previous + "/" + current);
		mCurrentPolicy = current;
		mPreviousPolicy = previous;
	}

	public string AddPolicy(string policyName, PolicyStyle style)
	{
		if (mValidPolicies.ContainsKey(policyName))
		{
			return policyName;
		}
		try
		{
			managedRequests[Thread.CurrentThread] = Thread.CurrentThread;
			SessionService service = SessionService.getService(mConnection);
			if (style.Equals(PolicyStyle.Fixed))
			{
				service.SetObjectPropertyPolicy(policyName);
				mValidPolicies[policyName] = policyName;
				return policyName;
			}
			if (mConnection.ServerVersion < v91)
			{
				string text = "The Object Property Policy Manager requires a 9.1 or newer Teamcenter server to use Dynamic policies.";
				connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
				throw new ServiceException(text, 535, 3);
			}
			bool useRefCounting = (style.Equals(PolicyStyle.RefCounted) ? true : false);
			Teamcenter.Services.Loose.Core._2012_02.Session.SetPolicyResponse setPolicyResponse = service.SetObjectPropertyPolicy(policyName, useRefCounting);
			mValidPolicies[setPolicyResponse.PolicyId] = setPolicyResponse.PolicyId;
			DynamicPolicy value = new DynamicPolicy(setPolicyResponse.PolicyId, setPolicyResponse.Policy, useRefCounting);
			mOjbectPropertyPolicies[setPolicyResponse.PolicyId] = value;
			return setPolicyResponse.PolicyId;
		}
		finally
		{
			managedRequests.Remove(Thread.CurrentThread);
		}
	}

	public string AddPolicy(ObjectPropertyPolicy policy, bool useRefCounting)
	{
		if (mConnection.ServerVersion < v80)
		{
			string text = "The Object Property Policy Manager requires a 8.0 or newer Teamcenter server to use client defined policies.";
			connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
			throw new ServiceException(text, 536, 3);
		}
		try
		{
			managedRequests[Thread.CurrentThread] = Thread.CurrentThread;
			SessionService service = SessionService.getService(mConnection);
			string text2 = service.SetObjectPropertyPolicy(policy);
			mValidPolicies[text2] = text2;
			DynamicPolicy value = new DynamicPolicy(text2, policy, useRefCounting);
			mOjbectPropertyPolicies[text2] = value;
			return text2;
		}
		finally
		{
			managedRequests.Remove(Thread.CurrentThread);
		}
	}

	public void SetPolicy(string policyName)
	{
		if (!mValidPolicies.ContainsKey(policyName))
		{
			string text = "The policy " + policyName + " must first be added to the Object Property Policy Manager through the addPolicy method.";
			connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
			throw new ServiceException(text, 537, 3);
		}
		if (!policyName.Equals(mCurrentPolicy))
		{
			string text2 = (mValidPolicies[policyName].Equals(policyName) ? "" : ("/" + mValidPolicies[policyName]));
			connectionLogger.Info(LogCorrelation.GetId() + ": Setting Object Property Policy (" + policyName + text2 + ")");
			mPreviousPolicy = mCurrentPolicy;
			mCurrentPolicy = policyName;
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void SetPolicyPerThread(string policyName)
	{
		if (!mValidPolicies.ContainsKey(policyName))
		{
			string text = "The policy " + policyName + " must first be added to the Object Property Policy Manager through the addPolicy method.";
			connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
			throw new ServiceException(text, 537, 3);
		}
		string text2 = (mValidPolicies[policyName].Equals(policyName) ? "" : ("/" + mValidPolicies[policyName]));
		connectionLogger.Info(LogCorrelation.GetId() + ": Setting Object Property Policy for this thread (" + policyName + text2 + ")");
		mPerThreadPolicies[Thread.CurrentThread] = policyName;
	}

	public void ClearPolicyPerThread()
	{
		mPerThreadPolicies.Remove(Thread.CurrentThread);
		connectionLogger.Info(LogCorrelation.GetId() + ": Clearing Object Property Policy for this thread (" + CurrentPolicy + ")");
	}

	public void UpdatePolicy(string policyName, bool applyToRootTypes, IList<PolicyType> addProperties, IList<PolicyType> removeProperties)
	{
		if (!mValidPolicies.ContainsKey(policyName))
		{
			string text = "The policy " + policyName + " must first be added to the Object Property Policy Manager through the addPolicy method.";
			connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
			throw new ServiceException(text, 537, 3);
		}
		DynamicPolicy dynamicPolicy = GetDynamicPolicy(policyName);
		if (dynamicPolicy == null)
		{
			string text = "The policy " + policyName + " is not Dynamic and cannot be updated.";
			connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
			throw new ServiceException(text, 538, 3);
		}
		ClientMetaModel clientMetaModel = mConnection.ClientMetaModel;
		foreach (PolicyType addProperty in addProperties)
		{
			string name = addProperty.Name;
			if (null == clientMetaModel.GetType(name, mConnection))
			{
				string text = name + " is not a valid type in the Client Meta Model.";
				connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
				throw new ServiceException(text, 539, 3);
			}
		}
		foreach (PolicyType removeProperty in removeProperties)
		{
			dynamicPolicy.RemoveProperties(removeProperty, colllectUpdates: true);
		}
		foreach (PolicyType addProperty2 in addProperties)
		{
			dynamicPolicy.AddProperties(addProperty2, collectUpdates: true);
		}
	}

	public ObjectPropertyPolicy GetPolicy(string policyName)
	{
		return GetDynamicPolicy(policyName)?.mThePolicy;
	}

	public void SendPendingUpdate()
	{
		if (managedRequests.ContainsKey(Thread.CurrentThread))
		{
			return;
		}
		DynamicPolicy dynamicPolicy = GetDynamicPolicy(Active);
		if (dynamicPolicy == null || (dynamicPolicy.mPendingAdds.Count == 0 && dynamicPolicy.mPendingRemoves.Count == 0))
		{
			return;
		}
		PolicyType[] array = new PolicyType[dynamicPolicy.mPendingAdds.Count];
		PolicyType[] array2 = new PolicyType[dynamicPolicy.mPendingRemoves.Count];
		int num = 0;
		foreach (PolicyType value in dynamicPolicy.mPendingAdds.Values)
		{
			array[num++] = value;
		}
		dynamicPolicy.mPendingAdds.Clear();
		num = 0;
		foreach (PolicyType value2 in dynamicPolicy.mPendingRemoves.Values)
		{
			array2[num++] = value2;
		}
		dynamicPolicy.mPendingRemoves.Clear();
		SessionService service = SessionService.getService(mConnection);
		try
		{
			managedRequests[Thread.CurrentThread] = Thread.CurrentThread;
			service.UpdateObjectPropertyPolicy(dynamicPolicy.mPolicyName, array, array2);
		}
		catch (ServiceException ex)
		{
			string text = "Failed to update the policy (" + dynamicPolicy.mPolicyName + "). " + ex.Message;
			connectionLogger.Error(LogCorrelation.GetId() + ": " + text);
			throw new InternalServerException(text, 558, 3);
		}
		finally
		{
			managedRequests.Remove(Thread.CurrentThread);
		}
	}

	public string GetRealId(string policyId)
	{
		if (mValidPolicies.ContainsKey(policyId))
		{
			return mValidPolicies[policyId];
		}
		return policyId;
	}

	public void RestoreServerPolicies()
	{
		if (mOjbectPropertyPolicies.Count == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (connectionLogger.IsInfoEnabled)
		{
			stringBuilder.Append("Current:  " + mCurrentPolicy + "\n");
			stringBuilder.Append("Previous: " + mPreviousPolicy + "\n");
			stringBuilder.Append("Valid Policies Before:\n");
			foreach (string key in mValidPolicies.Keys)
			{
				stringBuilder.Append(key + ": " + mValidPolicies[key] + "\n");
			}
		}
		SessionService service = SessionService.getService(mConnection);
		string[] array = new string[mValidPolicies.Keys.Count];
		mValidPolicies.Keys.CopyTo(array, 0);
		string[] array2 = array;
		foreach (string text in array2)
		{
			DynamicPolicy dynamicPolicy = GetDynamicPolicy(text);
			if (dynamicPolicy != null)
			{
				dynamicPolicy.mPendingAdds.Clear();
				dynamicPolicy.mPendingRemoves.Clear();
				managedRequests[Thread.CurrentThread] = Thread.CurrentThread;
				string text2 = service.SetObjectPropertyPolicy(dynamicPolicy.mThePolicy);
				managedRequests.Remove(Thread.CurrentThread);
				mValidPolicies[text] = text2;
				mOjbectPropertyPolicies.Remove(text);
				mOjbectPropertyPolicies[text2] = dynamicPolicy;
			}
		}
		if (!connectionLogger.IsInfoEnabled)
		{
			return;
		}
		stringBuilder.Append("Valid Policies After:\n");
		foreach (string key2 in mValidPolicies.Keys)
		{
			stringBuilder.Append(key2 + ": " + mValidPolicies[key2] + "\n");
		}
		stringBuilder.Append("\n");
		connectionLogger.Info(LogCorrelation.GetId() + ": Policies After Server Reassignment:\n" + stringBuilder.ToString());
	}

	public void CacheStateInformation(string service, string operation, object requestObject, object responseObject)
	{
		if (managedRequests.ContainsKey(Thread.CurrentThread))
		{
			return;
		}
		string text = service + "." + operation;
		if (text.Equals(SET_POLICY_METHOD_0701))
		{
			Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyInput setObjectPropertyPolicyInput = (Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyInput)requestObject;
			string policyName = setObjectPropertyPolicyInput.getPolicyName();
			mValidPolicies[policyName] = policyName;
			try
			{
				SetPolicy(policyName);
			}
			catch (ServiceException)
			{
			}
		}
		DynamicPolicy value;
		if (text.Equals(SET_POLICY_METHOD_0806))
		{
			Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyInput setObjectPropertyPolicyInput2 = (Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyInput)requestObject;
			ObjectPropertyPolicy policy = PolicyMarshaller.ToLocal(setObjectPropertyPolicyInput2.ObjectPropertyPolicy);
			Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyOutput setObjectPropertyPolicyOutput = (Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyOutput)responseObject;
			string policyName = setObjectPropertyPolicyOutput.Out;
			mValidPolicies[policyName] = policyName;
			value = new DynamicPolicy(policyName, policy, useRefCounting: false);
			mOjbectPropertyPolicies[policyName] = value;
			try
			{
				SetPolicy(policyName);
			}
			catch (ServiceException)
			{
			}
		}
		if (text.Equals(SET_POLICY_METHOD_1202))
		{
			Teamcenter.Schemas.Core._2012_02.Session.SetObjectPropertyPolicyInput setObjectPropertyPolicyInput3 = (Teamcenter.Schemas.Core._2012_02.Session.SetObjectPropertyPolicyInput)requestObject;
			Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse setPolicyResponse = (Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse)responseObject;
			ObjectPropertyPolicy policy = PolicyMarshaller.ToLocal(setPolicyResponse.ObjectPropertyPolicy);
			string policyName = setPolicyResponse.PolicyId;
			mValidPolicies[policyName] = policyName;
			value = new DynamicPolicy(policyName, policy, setObjectPropertyPolicyInput3.UseRefCounting);
			mOjbectPropertyPolicies[policyName] = value;
			try
			{
				SetPolicy(policyName);
			}
			catch (ServiceException)
			{
			}
		}
		if (!text.Equals(UPDATE_POLICY_METHOD))
		{
			return;
		}
		UpdateObjectPropertyPolicyInput updateObjectPropertyPolicyInput = (UpdateObjectPropertyPolicyInput)requestObject;
		value = GetDynamicPolicy(updateObjectPropertyPolicyInput.PolicyID);
		for (int i = 0; i < updateObjectPropertyPolicyInput.RemoveProperties.Length; i++)
		{
			value.RemoveProperties(PolicyMarshaller.ToLocal(updateObjectPropertyPolicyInput.RemoveProperties[i]), colllectUpdates: false);
		}
		for (int i = 0; i < updateObjectPropertyPolicyInput.AddProperties.Length; i++)
		{
			value.AddProperties(PolicyMarshaller.ToLocal(updateObjectPropertyPolicyInput.AddProperties[i]), collectUpdates: false);
		}
		try
		{
			SetPolicy(GetPolicyId(updateObjectPropertyPolicyInput.PolicyID));
		}
		catch (ServiceException)
		{
		}
	}

	private string GetPolicyId(string realId)
	{
		foreach (KeyValuePair<string, string> mValidPolicy in mValidPolicies)
		{
			if (mValidPolicy.Value.Equals(realId))
			{
				return mValidPolicy.Key;
			}
		}
		return realId;
	}

	private DynamicPolicy GetDynamicPolicy(string policyName)
	{
		string key = policyName;
		if (mValidPolicies.ContainsKey(policyName))
		{
			key = mValidPolicies[policyName];
		}
		if (mOjbectPropertyPolicies.ContainsKey(key))
		{
			return mOjbectPropertyPolicies[key];
		}
		return null;
	}
}
