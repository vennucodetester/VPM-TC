using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Rapid_Check.My;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());

	public static MySettings Default => defaultInstance;

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue(".txt;.csv")]
	public string InputFileType
	{
		get
		{
			return Conversions.ToString(this["InputFileType"]);
		}
		set
		{
			this["InputFileType"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("http://STLV-HSMWEBTCP1:8080/tc")]
	public string TC_Url
	{
		get
		{
			return Conversions.ToString(this["TC_Url"]);
		}
		set
		{
			this["TC_Url"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("UserName")]
	public string TC_UserName
	{
		get
		{
			return Conversions.ToString(this["TC_UserName"]);
		}
		set
		{
			this["TC_UserName"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Password")]
	public string TC_Password
	{
		get
		{
			return Conversions.ToString(this["TC_Password"]);
		}
		set
		{
			this["TC_Password"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("#:\\?*<>%/|\"~!")]
	public string Illegal_Character
	{
		get
		{
			return Conversions.ToString(this["Illegal_Character"]);
		}
		set
		{
			this["Illegal_Character"] = value;
		}
	}
}
