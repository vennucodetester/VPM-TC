using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CondValDataRevision : ValDataRevision
{
	public VerificationRule[] VerificationRules
	{
		get
		{
			IList modelObjectListValue = GetProperty("verificationRules").ModelObjectListValue;
			VerificationRule[] array = new VerificationRule[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public CondValDataRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
