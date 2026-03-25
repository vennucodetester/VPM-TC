using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class GetSessionGroupMemberResponse
{
	private ModelObject GroupMemberField;

	private ServiceData ServiceDataField;

	[XmlElement("groupMember")]
	public ModelObject GroupMember
	{
		get
		{
			return GroupMemberField;
		}
		set
		{
			GroupMemberField = value;
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

	public ModelObject getGroupMember()
	{
		return GroupMemberField;
	}

	public void setGroupMember(ModelObject val)
	{
		GroupMemberField = val;
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
