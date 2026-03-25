using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class SetSessionGroupMemberInput
{
	private ModelObject GroupMemberField;

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

	public ModelObject getGroupMember()
	{
		return GroupMemberField;
	}

	public void setGroupMember(ModelObject val)
	{
		GroupMemberField = val;
	}
}
