namespace Teamcenter.Soa.Client.Model.Strong;

public class DgtSignatureByUserRelation : ImanRelation
{
	public bool IsSignatureValid => GetProperty("isSignatureValid").BoolValue;

	public string SignatureTimeFromTool => GetProperty("signatureTimeFromTool").StringValue;

	public DgtSignatureByUserRelation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
