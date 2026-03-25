using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Client;

public interface ExceptionHandler
{
	void HandleException(InternalServerException ise);

	void HandleException(CanceledOperationException coe);
}
