using System;
using Teamcenter.Services.Strong.Core._2008_06.StructureManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Core;

public abstract class StructureManagementService : StructureManagement
{
	public static StructureManagementService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new StructureManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual CreateInStructureAssociationResponse CreateInStructureAssociations(InStructureAssociationInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual GetPrimariesOfInStructureAssociationResponse GetPrimariesOfInStructureAssociation(GetPrimariesOfInStructureAssociationInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual GetSecondariesOfInStructureAssociationResponse GetSecondariesOfInStructureAssociation(GetSecondariesOfInStructureAssociationInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual RemoveInStructureAssociationsResponse RemoveInStructureAssociations(RemoveInStructureAssociationsInfo[] Inputs)
	{
		throw new NotImplementedException();
	}
}
