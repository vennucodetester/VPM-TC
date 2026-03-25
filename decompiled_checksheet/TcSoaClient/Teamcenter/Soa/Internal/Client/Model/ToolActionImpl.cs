using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ToolActionImpl : ToolAction
{
	private readonly string mName;

	private readonly Dictionary<string, ActionReference> mReferences;

	public string Name => mName;

	public IList<ActionReference> ActionReferences
	{
		get
		{
			IList<ActionReference> list = new List<ActionReference>();
			foreach (KeyValuePair<string, ActionReference> mReference in mReferences)
			{
				list.Add(mReference.Value);
			}
			return list;
		}
	}

	public IList<string> ActionReferenceNames
	{
		get
		{
			IList<string> list = new List<string>();
			foreach (KeyValuePair<string, ActionReference> mReference in mReferences)
			{
				list.Add(mReference.Key);
			}
			return list;
		}
	}

	public ToolActionImpl(string name, Dictionary<string, ActionReference> references)
	{
		mName = name;
		mReferences = references;
	}

	public ActionReference GetActionReference(string name)
	{
		if (mReferences.ContainsKey(name))
		{
			return mReferences[name];
		}
		return null;
	}
}
