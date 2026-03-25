using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdByApprRootEffPkg : ApprUpdByApprRootPkg
{
	public AppearanceRoot Appr_root => (AppearanceRoot)GetProperty("appr_root").ModelObjectValue;

	public ApprRevRelation[] Impacted_arros
	{
		get
		{
			IList modelObjectListValue = GetProperty("impacted_arros").ModelObjectListValue;
			ApprRevRelation[] array = new ApprRevRelation[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ApprUpdByApprRootEffPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
