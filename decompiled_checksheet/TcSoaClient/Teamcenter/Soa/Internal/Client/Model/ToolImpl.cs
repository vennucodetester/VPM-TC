using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ToolImpl : Tool
{
	private readonly string mName;

	private readonly string mDescription;

	private readonly string[] mInputFormats;

	private readonly string[] mOutputFormats;

	private readonly string mLaunchCommandMac;

	private readonly string mMimeType;

	private readonly string mPackageName;

	private readonly string mReleaseDate;

	private readonly string mSymbol;

	private readonly string mVendorName;

	private readonly string mVersion;

	private readonly bool mCallbackEnabled;

	private readonly bool mDigitalSignatureCapable;

	private readonly bool mDownloadRequired;

	private readonly bool mEmbedApplication;

	private readonly bool mMarkupCapable;

	private readonly bool mViewCapable;

	private readonly bool mVviRequired;

	private readonly IList<ToolAction> mActions;

	public string Name => mName;

	public IList<ToolAction> Actions => mActions;

	public string Description => mDescription;

	public string[] InputFormats => mInputFormats;

	public string[] OutputFormats => mOutputFormats;

	public string LaunchCommandMac => mLaunchCommandMac;

	public string MimeType => mMimeType;

	public string PackageName => mPackageName;

	public string ReleaseDate => mReleaseDate;

	public string Symbol => mSymbol;

	public string VendorName => mVendorName;

	public string Version => mVersion;

	public bool IsCallbackEnabled => mCallbackEnabled;

	public bool IsDigitalSignatureCapable => mDigitalSignatureCapable;

	public bool IsDownloadRequired => mDownloadRequired;

	public bool IsEmbedApplication => mEmbedApplication;

	public bool IsMarkupCapable => mMarkupCapable;

	public bool IsViewCapable => mViewCapable;

	public bool IsVviRequired => mVviRequired;

	public ToolImpl(string name, string description, string[] inputFormats, string[] outputFormats, string launchCommandMac, string mimeType, string packageName, string releaseDate, string symbol, string vendorName, string version, bool callbackEnabled, bool digitalSignatureCapable, bool downloadRequired, bool embedApplication, bool markupCapable, bool viewCapable, bool vviRequired, IList<ToolAction> actions)
	{
		mName = name;
		mDescription = description;
		mInputFormats = inputFormats;
		mOutputFormats = outputFormats;
		mLaunchCommandMac = launchCommandMac;
		mMimeType = mimeType;
		mPackageName = packageName;
		mReleaseDate = releaseDate;
		mSymbol = symbol;
		mVendorName = vendorName;
		mVersion = version;
		mCallbackEnabled = callbackEnabled;
		mDigitalSignatureCapable = digitalSignatureCapable;
		mDownloadRequired = downloadRequired;
		mEmbedApplication = embedApplication;
		mMarkupCapable = markupCapable;
		mViewCapable = viewCapable;
		mVviRequired = vviRequired;
		mActions = actions;
	}

	public ToolAction GetAction(string name)
	{
		foreach (ToolAction mAction in mActions)
		{
			if (mAction.Name.Equals(name))
			{
				return mAction;
			}
		}
		return null;
	}
}
