using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DesignerCategory("code")]
public class LoginInput
{
	private string SessionDiscriminatorField;

	private string PasswordField;

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

	[XmlAttribute(AttributeName = "password")]
	public string Password
	{
		get
		{
			return PasswordField;
		}
		set
		{
			PasswordField = value;
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

	public string getPassword()
	{
		return PasswordField;
	}

	public void setPassword(string val)
	{
		PasswordField = val;
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
