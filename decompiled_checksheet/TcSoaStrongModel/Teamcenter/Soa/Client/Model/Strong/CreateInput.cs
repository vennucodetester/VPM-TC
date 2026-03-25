namespace Teamcenter.Soa.Client.Model.Strong;

public class CreateInput : OperationInput
{
	public CreateInput(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
