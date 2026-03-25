using System;
using System.Collections;
using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface SoaType
{
	string Uid { get; }

	string Name { get; }

	SoaType Parent { get; }

	string UIFValue { get; }

	[Obsolete("As of 9.1. There is no replacement for this method as the data is not relevant")]
	bool MatchType { get; }

	string ClassName { get; }

	string TypeUid { get; }

	Hashtable PropDescs { get; }

	string OwningType { get; }

	Dictionary<string, string> Constants { get; }

	RevNameRule RevisionNamingRule { get; }

	RevisionRuleCategory RevisionNamingRuleCategory { get; }

	PropertyDescription GetPropDesc(string propName);

	List<string> GetClassNameHierarchy();

	bool IsInstanceOf(string className);

	string GetConstant(string name);
}
