using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AllocationMap : Item
{
	public PSBOMView Source_bv_tag => (PSBOMView)GetProperty("source_bv_tag").ModelObjectValue;

	public PSBOMView Target_bv_tag => (PSBOMView)GetProperty("target_bv_tag").ModelObjectValue;

	public PSBOMView[] Product_rep_bvs_tag
	{
		get
		{
			IList modelObjectListValue = GetProperty("product_rep_bvs_tag").ModelObjectListValue;
			PSBOMView[] array = new PSBOMView[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AllocationMap(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
