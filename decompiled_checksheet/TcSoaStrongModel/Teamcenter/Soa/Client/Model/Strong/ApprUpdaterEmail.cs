using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdaterEmail : POM_object
{
	public ModelObject Package => GetProperty("package").ModelObjectValue;

	public DateTime When => GetProperty("when").DateValue;

	public string Recipient => GetProperty("recipient").StringValue;

	public ApprUpdaterEmail(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
