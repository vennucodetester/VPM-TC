using System.Collections.Generic;
using Teamcenter.Soa.Common;

namespace Teamcenter.Soa.Client;

public interface ObjectPropertyPolicyManager
{
	IList<string> AvailablePolices { get; }

	string CurrentPolicy { get; }

	string PreviousPolicy { get; }

	string AddPolicy(string policyName, PolicyStyle style);

	string AddPolicy(ObjectPropertyPolicy policy, bool useRefCounting);

	void SetPolicy(string policyName);

	void SetPolicyPerThread(string policyName);

	void ClearPolicyPerThread();

	void UpdatePolicy(string policyName, bool applyToRootTypes, IList<PolicyType> addProperties, IList<PolicyType> removeProperties);

	ObjectPropertyPolicy GetPolicy(string policyName);
}
