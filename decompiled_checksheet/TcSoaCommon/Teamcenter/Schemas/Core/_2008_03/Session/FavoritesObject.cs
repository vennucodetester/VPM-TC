using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2008_03.Session;

[Serializable]
[DebuggerStepThrough]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-03/Session", IsNullable = false)]
public class FavoritesObject
{
	private string ClientIdField;

	private string DisplayNameField;

	private string ParentIdField;

	private ModelObject ObjectTagField;

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

	[XmlElement("objectTag")]
	public ModelObject ObjectTag
	{
		get
		{
			return ObjectTagField;
		}
		set
		{
			ObjectTagField = value;
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

	public string getParentId()
	{
		return ParentIdField;
	}

	public void setParentId(string val)
	{
		ParentIdField = val;
	}

	public ModelObject getObjectTag()
	{
		return ObjectTagField;
	}

	public void setObjectTag(ModelObject val)
	{
		ObjectTagField = val;
	}
}
