namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccType : AbsOccData
{
	public PSOccurrenceType Occ_type => (PSOccurrenceType)GetProperty("occ_type").ModelObjectValue;

	public AbsOccType(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
