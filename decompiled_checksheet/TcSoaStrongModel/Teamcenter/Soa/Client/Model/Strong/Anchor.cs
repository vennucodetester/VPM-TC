using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class Anchor : POM_application_object
{
	public int Keep_limit => GetProperty("keep_limit").IntValue;

	public WorkspaceObject[] Managed_objects
	{
		get
		{
			IList modelObjectListValue = GetProperty("managed_objects").ModelObjectListValue;
			WorkspaceObject[] array = new WorkspaceObject[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public WorkspaceObject[] Immune_objects
	{
		get
		{
			IList modelObjectListValue = GetProperty("immune_objects").ModelObjectListValue;
			WorkspaceObject[] array = new WorkspaceObject[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public Anchor(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
