using System;
using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdChangePkg : POM_object
{
	public int Processing_status => GetProperty("processing_status").IntValue;

	public bool Processing_blocked => GetProperty("processing_blocked").BoolValue;

	public DateTime Order_by_date => GetProperty("order_by_date").DateValue;

	public DateTime Run_date => GetProperty("run_date").DateValue;

	public ApprUpdByApprRootPkg[] Secondary_queues
	{
		get
		{
			IList modelObjectListValue = GetProperty("secondary_queues").ModelObjectListValue;
			ApprUpdByApprRootPkg[] array = new ApprUpdByApprRootPkg[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ModelObject Cloned_for_appearance_root => GetProperty("cloned_for_appearance_root").ModelObjectValue;

	public ReleaseStatus Release_status => (ReleaseStatus)GetProperty("release_status").ModelObjectValue;

	public ApprUpdChangePkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
