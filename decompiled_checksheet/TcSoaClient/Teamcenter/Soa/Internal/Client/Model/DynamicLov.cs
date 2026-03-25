using System;
using System.Collections.Generic;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class DynamicLov : Lov
{
	private static ILog logger = LogManager.GetLogger(typeof(DynamicLov));

	private IList<string> mDependProps;

	private IList<Style> mDependStyles;

	private readonly int mSpecifier;

	private readonly string mUid;

	private readonly Connection mConnection;

	private readonly string mOwningTypeName;

	private readonly string mOwningProperty;

	private readonly SoaType mType;

	public IList<string> DependantProperties => mDependProps;

	public string Uid => mUid;

	public int Specifier => mSpecifier;

	public Style Style
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLov as a pure LOV implemenation.");
		}
	}

	public LovInfo LovInfo
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLov as a pure LOV implemenation.");
		}
	}

	public IList<Style> DependantStyles
	{
		get
		{
			throw new ArgumentException("Do not use DynamicLov as a pure LOV implemenation.");
		}
	}

	public DynamicLov(string uid, SoaType type, int specifier, IList<string> dependProps, IList<Style> dependStyles, string owningTypeName, string owningProperty, Connection connection)
	{
		mDependProps = dependProps;
		mDependStyles = dependStyles;
		mUid = uid;
		mSpecifier = specifier;
		mType = type;
		mOwningTypeName = owningTypeName;
		mOwningProperty = owningProperty;
		mConnection = connection;
	}

	public Lov Resolve()
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		LovInfo lovInfo = new DynamicLovInfo(mUid, mType, mConnection, mOwningTypeName, mOwningProperty).Resolve();
		Style style = CalculateStyle(0, lovInfo);
		ModelManagerImpl.LogDebug(ClassNames.DynamicLov, logger, "ObjectFactory.constructLov", mOwningProperty);
		return objectFactory.ConstructLov(style, mDependProps, mDependStyles, mUid, mSpecifier, lovInfo);
	}

	private Style CalculateStyle(int level, LovInfo lovInfo)
	{
		IList<LovValue> values = lovInfo.Values;
		if (level > 0 && values.Count > 1 && mDependStyles[0] != Style.Interdependent)
		{
			for (int i = 0; i < mDependStyles.Count; i++)
			{
				if (mDependStyles[i] == Style.Coordinated)
				{
					mDependStyles[i] = Style.Interdependent;
				}
			}
		}
		bool flag = false;
		foreach (LovValue item in values)
		{
			LovInfo childLov = item.ChildLov;
			if (childLov != null)
			{
				flag = true;
				CalculateStyle(level + 1, childLov);
			}
		}
		Style style = mDependStyles[0];
		if (level == 0)
		{
			if (mDependStyles.Count == 1 && (mDependStyles[0] == Style.Interdependent || mDependStyles[0] == Style.Coordinated))
			{
				mDependStyles[0] = Style.Hierarchical;
			}
			if (!flag)
			{
				if (mDependStyles.Count > 1)
				{
					if (mDependStyles[1] != Style.Description)
					{
						logger.Error("This looks like a Description LOV, but the second Sytle is not Description");
						throw new ArgumentException("This looks like a Description LOV, but the second Sytle is not Description");
					}
					mDependStyles[0] = Style.Interdependent;
				}
			}
			else if (mDependStyles.Count == 1 && mDependStyles[0] == Style.Standard)
			{
				mDependStyles[0] = Style.Hierarchical;
			}
			style = mDependStyles[0];
			if (style == Style.Standard || style == Style.Hierarchical)
			{
				mDependStyles.Clear();
				mDependProps.Clear();
			}
		}
		return style;
	}
}
