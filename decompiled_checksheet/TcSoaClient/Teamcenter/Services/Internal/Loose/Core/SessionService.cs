using System;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Internal.Loose.Core._2006_03.Types;
using Teamcenter.Services.Internal.Loose.Core._2007_05.Session;
using Teamcenter.Services.Internal.Loose.Core._2007_12.Session;
using Teamcenter.Services.Internal.Loose.Core._2008_03.Session;
using Teamcenter.Services.Internal.Loose.Core._2008_06.Session;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Services.Internal.Loose.Core;

public abstract class SessionService : Types, Teamcenter.Services.Internal.Loose.Core._2007_05.Session.Session, Teamcenter.Services.Internal.Loose.Core._2007_12.Session.Session, Teamcenter.Services.Internal.Loose.Core._2008_03.Session.Session, Teamcenter.Services.Internal.Loose.Core._2008_06.Session.Session
{
	public static SessionService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new SessionRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ModelSchema InitTypeByNames(string[] TypeNames)
	{
		throw new NotImplementedException();
	}

	public virtual ModelSchema InitTypeByUids(string[] Uids)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007.1, use the published refreshPOMCachePerRequest operation.", false)]
	public virtual bool RefreshPOMCachePerRequest(bool Refresh)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Soa.Client.Model.ServiceData GetProperties(Teamcenter.Soa.Client.Model.ModelObject[] Objects, string[] Attributes)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 9, session states is shared across the clients connecting to same instance of tcserver.", false)]
	public virtual Teamcenter.Soa.Client.Model.ServiceData DisableUserSessionState(string[] Names)
	{
		throw new NotImplementedException();
	}

	public virtual bool CancelOperation(string Id)
	{
		throw new NotImplementedException();
	}
}
