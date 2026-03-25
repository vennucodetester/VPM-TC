using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ErrorValueImpl : Teamcenter.Soa.Client.Model.ErrorValue
{
	private Teamcenter.Schemas.Soa._2006_03.Base.ErrorValue wireError;

	public int Code => wireError.Code;

	public int Level => wireError.Level;

	public string Message => wireError.Message;

	public ErrorValueImpl(Teamcenter.Schemas.Soa._2006_03.Base.ErrorValue wireError)
	{
		this.wireError = wireError;
	}
}
