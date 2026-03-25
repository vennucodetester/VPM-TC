using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class LovInfoImpl : LovInfo
{
	private readonly string mUid;

	private readonly SoaType mType;

	private readonly int mValueType;

	private readonly string mName;

	private readonly string mDisplayName;

	private readonly string mDescription;

	private readonly string mDisplayDescription;

	private readonly Usage mUsage;

	private readonly ConditionChoices<LovValue> mValues;

	public string Uid => mUid;

	public string Name => mName;

	public string DisplayName => mDisplayName;

	public string Description => mDescription;

	public string DisplayDescription => mDisplayDescription;

	public SoaType Type => mType;

	public int ValueType => mValueType;

	public Usage Usage => mUsage;

	public IList<LovValue> Values => mValues.getAll();

	public LovInfoImpl(string uid, string name, string displayName, string description, string displayDescription, SoaType type, int valueType, Usage usage, ConditionChoices<LovValue> values)
	{
		mUid = uid;
		mName = name;
		mDisplayName = displayName;
		mDescription = description;
		mDisplayDescription = displayDescription;
		mType = type;
		mValueType = valueType;
		mUsage = usage;
		mValues = values;
	}
}
