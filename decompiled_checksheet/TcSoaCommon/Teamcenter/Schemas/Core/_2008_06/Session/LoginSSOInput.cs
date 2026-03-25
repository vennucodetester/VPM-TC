using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_06.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-06/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class LoginSSOInput
{
	private string LocaleField;

	private bool LocaleFieldSet = false;

	private string SessionDiscriminatorField;

	private string SsoCredentialsField;

	private string GroupField;

	private bool GroupFieldSet = false;

	private string RoleField;

	private bool RoleFieldSet = false;

	private string UsernameField;

	[XmlAttribute(AttributeName = "locale")]
	public string Locale
	{
		get
		{
			return LocaleField;
		}
		set
		{
			LocaleField = value;
			LocaleFieldSet = true;
		}
	}

	public bool IsLocaleSet => LocaleFieldSet;

	[XmlAttribute(AttributeName = "sessionDiscriminator")]
	public string SessionDiscriminator
	{
		get
		{
			return SessionDiscriminatorField;
		}
		set
		{
			SessionDiscriminatorField = value;
		}
	}

	[XmlAttribute(AttributeName = "ssoCredentials")]
	public string SsoCredentials
	{
		get
		{
			return SsoCredentialsField;
		}
		set
		{
			SsoCredentialsField = value;
		}
	}

	[XmlAttribute(AttributeName = "group")]
	public string Group
	{
		get
		{
			return GroupField;
		}
		set
		{
			GroupField = value;
			GroupFieldSet = true;
		}
	}

	public bool IsGroupSet => GroupFieldSet;

	[XmlAttribute(AttributeName = "role")]
	public string Role
	{
		get
		{
			return RoleField;
		}
		set
		{
			RoleField = value;
			RoleFieldSet = true;
		}
	}

	public bool IsRoleSet => RoleFieldSet;

	[XmlAttribute(AttributeName = "username")]
	public string Username
	{
		get
		{
			return UsernameField;
		}
		set
		{
			UsernameField = value;
		}
	}

	public string getLocale()
	{
		return LocaleField;
	}

	public void setLocale(string val)
	{
		LocaleField = val;
		LocaleFieldSet = true;
	}

	public string getSessionDiscriminator()
	{
		return SessionDiscriminatorField;
	}

	public void setSessionDiscriminator(string val)
	{
		SessionDiscriminatorField = val;
	}

	public string getSsoCredentials()
	{
		return SsoCredentialsField;
	}

	public void setSsoCredentials(string val)
	{
		SsoCredentialsField = val;
	}

	public string getGroup()
	{
		return GroupField;
	}

	public void setGroup(string val)
	{
		GroupField = val;
		GroupFieldSet = true;
	}

	public string getRole()
	{
		return RoleField;
	}

	public void setRole(string val)
	{
		RoleField = val;
		RoleFieldSet = true;
	}

	public string getUsername()
	{
		return UsernameField;
	}

	public void setUsername(string val)
	{
		UsernameField = val;
	}
}
