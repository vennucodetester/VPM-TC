using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Core._2008_03.Session;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
public class GetShortcutsResponse
{
	private FavoritesList FavoritesField;

	private LHNSectionComponentsMap[] ShortcutsField;

	private ServiceData ServiceDataField;

	[XmlElement("favorites")]
	public FavoritesList Favorites
	{
		get
		{
			return FavoritesField;
		}
		set
		{
			FavoritesField = value;
		}
	}

	[XmlElement("shortcuts")]
	public LHNSectionComponentsMap[] Shortcuts
	{
		get
		{
			return ShortcutsField;
		}
		set
		{
			ShortcutsField = value;
		}
	}

	[XmlElement(ElementName = "ServiceData", Namespace = "http://teamcenter.com/Schemas/Soa/2006-03/Base")]
	public ServiceData ServiceData
	{
		get
		{
			return ServiceDataField;
		}
		set
		{
			ServiceDataField = value;
		}
	}

	public FavoritesList getFavorites()
	{
		return FavoritesField;
	}

	public void setFavorites(FavoritesList val)
	{
		FavoritesField = val;
	}

	public ArrayList getShortcuts()
	{
		if (ShortcutsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ShortcutsField);
	}

	public void setShortcuts(ArrayList val)
	{
		ShortcutsField = new LHNSectionComponentsMap[val.Count];
		val.CopyTo(ShortcutsField);
	}

	public ServiceData getServiceData()
	{
		return ServiceDataField;
	}

	public void setServiceData(ServiceData val)
	{
		ServiceDataField = val;
	}
}
