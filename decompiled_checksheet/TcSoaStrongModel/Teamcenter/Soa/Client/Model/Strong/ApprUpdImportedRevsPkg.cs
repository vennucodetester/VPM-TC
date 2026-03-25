using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdImportedRevsPkg : ApprUpdChangedRevsPkg
{
	public DateTime Import_date => GetProperty("import_date").DateValue;

	public ApprUpdImportedRevsPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
