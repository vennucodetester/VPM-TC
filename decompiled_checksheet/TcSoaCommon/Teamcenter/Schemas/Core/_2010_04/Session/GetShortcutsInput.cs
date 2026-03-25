using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
public class GetShortcutsInput
{
	private LHNShortcutInputs[] ShortcutInputsField;

	[XmlElement("shortcutInputs")]
	public LHNShortcutInputs[] ShortcutInputs
	{
		get
		{
			return ShortcutInputsField;
		}
		set
		{
			ShortcutInputsField = value;
		}
	}

	public ArrayList getShortcutInputs()
	{
		if (ShortcutInputsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ShortcutInputsField);
	}

	public void setShortcutInputs(ArrayList val)
	{
		ShortcutInputsField = new LHNShortcutInputs[val.Count];
		val.CopyTo(ShortcutInputsField);
	}
}
