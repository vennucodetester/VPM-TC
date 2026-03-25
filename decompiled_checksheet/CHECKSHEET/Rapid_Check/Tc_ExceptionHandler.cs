using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Exceptions;

namespace Rapid_Check;

public class Tc_ExceptionHandler : ExceptionHandler
{
	public void HandleException(InternalServerException ise)
	{
	}

	void ExceptionHandler.HandleException(InternalServerException ise)
	{
		//ILSpy generated this explicit interface implementation from .override directive in HandleException
		this.HandleException(ise);
	}

	public void HandleException(CanceledOperationException coe)
	{
	}

	void ExceptionHandler.HandleException(CanceledOperationException coe)
	{
		//ILSpy generated this explicit interface implementation from .override directive in HandleException
		this.HandleException(coe);
	}
}
