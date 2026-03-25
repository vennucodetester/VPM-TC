using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ADA_License : WorkspaceObject
{
	public string Id => GetProperty("id").StringValue;

	public string Reason => GetProperty("reason").StringValue;

	public DateTime Expiry => GetProperty("expiry").DateValue;

	public string[] Users => GetProperty("users").StringArrayValue;

	public string[] Groups => GetProperty("groups").StringArrayValue;

	public DateTime Lock_date => GetProperty("lock_date").DateValue;

	public string Qualifying_cfr => GetProperty("qualifying_cfr").StringValue;

	public string Fnd0license_category => GetProperty("fnd0license_category").StringValue;

	public string[] Fnd0user_citizenships => GetProperty("fnd0user_citizenships").StringArrayValue;

	public ModelObject[] Fnd0LicenseChangeAuditLogs => GetProperty("fnd0LicenseChangeAuditLogs").ModelObjectArrayValue;

	public ADA_License(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
