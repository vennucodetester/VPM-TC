using System;
using Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Core;

public abstract class DispatcherManagementService : DispatcherManagement
{
	public static DispatcherManagementService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new DispatcherManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual CreateDispatcherRequestResponse CreateDispatcherRequest(CreateDispatcherRequestArgs[] Inputs)
	{
		throw new NotImplementedException();
	}
}
