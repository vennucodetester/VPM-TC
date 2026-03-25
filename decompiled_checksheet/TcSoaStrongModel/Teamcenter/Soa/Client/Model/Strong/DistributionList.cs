namespace Teamcenter.Soa.Client.Model.Strong;

public class DistributionList : WorkspaceObject
{
	public ModelObject[] ListOfMembers => GetProperty("listOfMembers").ModelObjectArrayValue;

	public DistributionList(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
