using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
public class GetGroupMembershipResponse
{
	private ModelObject[] GroupMembersField;

	private ServiceData ServiceDataField;

	[XmlElement("groupMembers")]
	public ModelObject[] GroupMembers
	{
		get
		{
			return GroupMembersField;
		}
		set
		{
			GroupMembersField = value;
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

	public ArrayList getGroupMembers()
	{
		if (GroupMembersField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(GroupMembersField);
	}

	public void setGroupMembers(ArrayList val)
	{
		GroupMembersField = new ModelObject[val.Count];
		val.CopyTo(GroupMembersField);
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
