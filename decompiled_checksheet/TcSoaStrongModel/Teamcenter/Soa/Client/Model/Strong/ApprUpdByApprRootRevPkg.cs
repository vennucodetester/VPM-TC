using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdByApprRootRevPkg : ApprUpdByApprRootPkg
{
	public ApprUpdRevViewImpactsRoot[] Aurvir_list
	{
		get
		{
			IList modelObjectListValue = GetProperty("aurvir_list").ModelObjectListValue;
			ApprUpdRevViewImpactsRoot[] array = new ApprUpdRevViewImpactsRoot[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ApprUpdByApprRootRevPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
