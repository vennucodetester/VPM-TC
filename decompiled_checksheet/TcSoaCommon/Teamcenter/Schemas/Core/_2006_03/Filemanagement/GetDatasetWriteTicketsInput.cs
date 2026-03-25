using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class GetDatasetWriteTicketsInput
{
	private GetDatasetWriteTicketsInputData[] InputsField;

	[XmlElement("inputs")]
	public GetDatasetWriteTicketsInputData[] Inputs
	{
		get
		{
			return InputsField;
		}
		set
		{
			InputsField = value;
		}
	}

	public ArrayList getInputs()
	{
		if (InputsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(InputsField);
	}

	public void setInputs(ArrayList val)
	{
		InputsField = new GetDatasetWriteTicketsInputData[val.Count];
		val.CopyTo(InputsField);
	}
}
