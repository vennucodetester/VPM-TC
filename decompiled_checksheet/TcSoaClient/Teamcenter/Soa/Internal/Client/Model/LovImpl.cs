using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class LovImpl : Lov
{
	private readonly Style mStyle;

	private readonly IList<string> mDependProps;

	private readonly IList<Style> mDependStyles;

	private readonly int mSpecifier;

	private LovInfo mLovInfo;

	private readonly string mUid;

	public Style Style => mStyle;

	public IList<string> DependantProperties => mDependProps;

	public IList<Style> DependantStyles => mDependStyles;

	public string Uid => mUid;

	public int Specifier => mSpecifier;

	public LovInfo LovInfo
	{
		get
		{
			if (mLovInfo is DynamicLovInfo)
			{
				mLovInfo = ((DynamicLovInfo)mLovInfo).Resolve();
			}
			return mLovInfo;
		}
	}

	public LovImpl(Style style, IList<string> dependProps, IList<Style> dependStyles, string uid, int specifier, LovInfo lovinfo)
	{
		mStyle = style;
		mDependProps = dependProps;
		mDependStyles = dependStyles;
		mLovInfo = lovinfo;
		mUid = uid;
		mSpecifier = specifier;
	}
}
