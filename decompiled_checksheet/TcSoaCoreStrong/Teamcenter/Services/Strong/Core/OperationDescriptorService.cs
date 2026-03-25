using System;
using Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor;
using Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public abstract class OperationDescriptorService : Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.OperationDescriptor, Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.OperationDescriptor
{
	public static OperationDescriptorService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new OperationDescriptorRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual SaveAsDescResponse GetSaveAsDesc(ModelObject[] TargetObjects)
	{
		throw new NotImplementedException();
	}

	public virtual GetDeepCopyDataResponse GetDeepCopyData(DeepCopyDataInput[] DeepCopyDataInput)
	{
		throw new NotImplementedException();
	}
}
