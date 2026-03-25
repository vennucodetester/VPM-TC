using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class GetAvailableServicesResponse
{
	private string[] ServiceNamesField;

	[XmlElement("serviceNames")]
	public string[] ServiceNames
	{
		get
		{
			return ServiceNamesField;
		}
		set
		{
			ServiceNamesField = value;
		}
	}

	public ArrayList getServiceNames()
	{
		if (ServiceNamesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ServiceNamesField);
	}

	public void setServiceNames(ArrayList val)
	{
		ServiceNamesField = new string[val.Count];
		val.CopyTo(ServiceNamesField);
	}
}
