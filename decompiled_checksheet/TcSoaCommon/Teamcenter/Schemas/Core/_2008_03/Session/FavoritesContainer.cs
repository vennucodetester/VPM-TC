using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_03.Session;

[Serializable]
[DebuggerStepThrough]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-03/Session", IsNullable = false)]
public class FavoritesContainer
{
	private string ClientIdField;

	private string DisplayNameField;

	private string TypeField;

	private string ParentIdField;

	private string IdField;

	[XmlAttribute(AttributeName = "clientId")]
	public string ClientId
	{
		get
		{
			return ClientIdField;
		}
		set
		{
			ClientIdField = value;
		}
	}

	[XmlAttribute(AttributeName = "displayName")]
	public string DisplayName
	{
		get
		{
			return DisplayNameField;
		}
		set
		{
			DisplayNameField = value;
		}
	}

	[XmlAttribute(AttributeName = "type")]
	public string Type
	{
		get
		{
			return TypeField;
		}
		set
		{
			TypeField = value;
		}
	}

	[XmlAttribute(AttributeName = "parentId")]
	public string ParentId
	{
		get
		{
			return ParentIdField;
		}
		set
		{
			ParentIdField = value;
		}
	}

	[XmlAttribute(AttributeName = "id")]
	public string Id
	{
		get
		{
			return IdField;
		}
		set
		{
			IdField = value;
		}
	}

	public string getClientId()
	{
		return ClientIdField;
	}

	public void setClientId(string val)
	{
		ClientIdField = val;
	}

	public string getDisplayName()
	{
		return DisplayNameField;
	}

	public void setDisplayName(string val)
	{
		DisplayNameField = val;
	}

	public string getType()
	{
		return TypeField;
	}

	public void setType(string val)
	{
		TypeField = val;
	}

	public string getParentId()
	{
		return ParentIdField;
	}

	public void setParentId(string val)
	{
		ParentIdField = val;
	}

	public string getId()
	{
		return IdField;
	}

	public void setId(string val)
	{
		IdField = val;
	}
}
