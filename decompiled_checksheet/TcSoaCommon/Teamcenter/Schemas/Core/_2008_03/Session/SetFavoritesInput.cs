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
public class SetFavoritesInput
{
	private FavoritesInfo InputField;

	[XmlElement("input")]
	public FavoritesInfo Input
	{
		get
		{
			return InputField;
		}
		set
		{
			InputField = value;
		}
	}

	public FavoritesInfo getInput()
	{
		return InputField;
	}

	public void setInput(FavoritesInfo val)
	{
		InputField = val;
	}
}
