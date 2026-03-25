using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client.Model;
using log4net;

namespace Teamcenter.Soa.Client;

public abstract class SessionHandler
{
	private static ILog _logger = LogManager.GetLogger(typeof(SessionHandler));

	public virtual void LocalSessionChange(ModelObject userSession)
	{
	}

	public virtual void SharedSessionChange(ModelObject userSession)
	{
	}

	public virtual void HandleException(InternalServerException e)
	{
	}
}
