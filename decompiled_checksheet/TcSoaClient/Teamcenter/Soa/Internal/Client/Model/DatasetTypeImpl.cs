using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class DatasetTypeImpl : SoaTypeImpl, DatasetType, SoaType
{
	private readonly IList<Tool> mViewTools;

	private readonly IList<Tool> mEditTools;

	private readonly IList<Reference> mReferences;

	public IList<Tool> ViewTools => mViewTools;

	public IList<Tool> EditTools => mEditTools;

	public IList<Reference> References => mReferences;

	public IList<string> ReferenceNames
	{
		get
		{
			IList<string> list = new List<string>();
			foreach (Reference mReference in mReferences)
			{
				list.Add(mReference.Name);
			}
			return list;
		}
	}

	public DatasetTypeImpl(string uid, string typeUid, string name, string displayName, string className, IList<string> classNameHierarchy, SoaType parent, string owningType, Dictionary<string, PropertyDescription> properties, Dictionary<string, string> constants, ConditionChoices<RevNameRule> revRules, RevisionRuleCategory ruleCategory, IList<Tool> viewTools, IList<Tool> editTools, IList<Reference> references)
		: base(uid, typeUid, name, displayName, className, classNameHierarchy, parent, owningType, properties, constants, revRules, ruleCategory)
	{
		mViewTools = viewTools;
		mEditTools = editTools;
		mReferences = references;
	}

	public Tool GetViewTool(string name)
	{
		foreach (Tool mViewTool in mViewTools)
		{
			if (mViewTool.Name.Equals(name))
			{
				return mViewTool;
			}
		}
		return null;
	}

	public Tool GetEditTool(string name)
	{
		foreach (Tool mEditTool in mEditTools)
		{
			if (mEditTool.Name.Equals(name))
			{
				return mEditTool;
			}
		}
		return null;
	}

	public Reference GetReference(string name)
	{
		foreach (Reference mReference in mReferences)
		{
			if (name.Equals(mReference.Name))
			{
				return mReference;
			}
		}
		return null;
	}
}
