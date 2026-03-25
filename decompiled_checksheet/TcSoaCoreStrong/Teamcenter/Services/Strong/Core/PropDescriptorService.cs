using System;
using Teamcenter.Services.Strong.Core._2007_06.PropDescriptor;
using Teamcenter.Services.Strong.Core._2008_06.PropDescriptor;
using Teamcenter.Services.Strong.Core._2011_06.PropDescriptor;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Core;

public abstract class PropDescriptorService : Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescriptor, Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDescriptor, Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescriptor
{
	public static PropDescriptorService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new PropDescriptorRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	[Obsolete("As of Teamcenter 9, use the getAttachedPropDescs2 operation.", false)]
	public virtual Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.AttachedPropDescsResponse GetAttachedPropDescs(PropDescInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual CreateDescResponse GetCreateDesc(string[] BusinessObjectTypeNames)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.AttachedPropDescsResponse GetAttachedPropDescs2(PropDescInfo[] Inputs)
	{
		throw new NotImplementedException();
	}
}
