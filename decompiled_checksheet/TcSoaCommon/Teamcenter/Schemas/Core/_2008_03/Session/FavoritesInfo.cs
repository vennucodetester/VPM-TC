using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_03.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-03/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class FavoritesInfo
{
	private FavoritesList CurFavoritesField;

	private FavoritesList NewFavoritesField;

	[XmlElement("curFavorites")]
	public FavoritesList CurFavorites
	{
		get
		{
			return CurFavoritesField;
		}
		set
		{
			CurFavoritesField = value;
		}
	}

	[XmlElement("newFavorites")]
	public FavoritesList NewFavorites
	{
		get
		{
			return NewFavoritesField;
		}
		set
		{
			NewFavoritesField = value;
		}
	}

	public FavoritesList getCurFavorites()
	{
		return CurFavoritesField;
	}

	public void setCurFavorites(FavoritesList val)
	{
		CurFavoritesField = val;
	}

	public FavoritesList getNewFavorites()
	{
		return NewFavoritesField;
	}

	public void setNewFavorites(FavoritesList val)
	{
		NewFavoritesField = val;
	}
}
