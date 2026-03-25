using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_03.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-03/Session", IsNullable = false)]
public class FavoritesList
{
	private FavoritesContainer[] ContainersField;

	private FavoritesObject[] ObjectsField;

	[XmlElement("containers")]
	public FavoritesContainer[] Containers
	{
		get
		{
			return ContainersField;
		}
		set
		{
			ContainersField = value;
		}
	}

	[XmlElement("objects")]
	public FavoritesObject[] Objects
	{
		get
		{
			return ObjectsField;
		}
		set
		{
			ObjectsField = value;
		}
	}

	public ArrayList getContainers()
	{
		if (ContainersField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ContainersField);
	}

	public void setContainers(ArrayList val)
	{
		ContainersField = new FavoritesContainer[val.Count];
		val.CopyTo(ContainersField);
	}

	public ArrayList getObjects()
	{
		if (ObjectsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ObjectsField);
	}

	public void setObjects(ArrayList val)
	{
		ObjectsField = new FavoritesObject[val.Count];
		val.CopyTo(ObjectsField);
	}
}
