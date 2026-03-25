using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
public class LoginSSOInput
{
	private string SessionDiscriminatorField;

	private string SsoCredentialsField;

	private string GroupField;

	private string RoleField;

	private string UsernameField;

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
		}
	}

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
		}
	}

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
	}

	public string getRole()
	{
		return RoleField;
	}

	public void setRole(string val)
	{
		RoleField = val;
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
