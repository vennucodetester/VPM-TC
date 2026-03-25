using System;
using Teamcenter.Services.Strong.Core._2007_01.ManagedRelations;
using Teamcenter.Services.Strong.Core._2008_06.ManagedRelations;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Core;

public abstract class ManagedRelationsService : Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelations, Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.ManagedRelations
{
	public static ManagedRelationsService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new ManagedRelationsRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ManagedRelationResponse CreateRelation(CreateManagedRelationInput[] Relationinfo)
	{
		throw new NotImplementedException();
	}

	public virtual TraceabilityReportOutput GetTraceReport(TraceabilityInfoInput Input)
	{
		throw new NotImplementedException();
	}

	public virtual ManagedRelationResponse ModifyRelation(ModifyManagedRelationInput[] NewInput)
	{
		throw new NotImplementedException();
	}

	public virtual GetManagedRelationResponse GetManagedRelations(GetManagedRelationInput Inputdata)
	{
		throw new NotImplementedException();
	}
}
