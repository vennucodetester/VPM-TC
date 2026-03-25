using System;
using Teamcenter.Services.Strong.Cad._2007_01.DataManagement;
using Teamcenter.Services.Strong.Cad._2007_12.DataManagement;
using Teamcenter.Services.Strong.Cad._2008_03.DataManagement;
using Teamcenter.Services.Strong.Cad._2008_06.DataManagement;
using Teamcenter.Services.Strong.Cad._2010_09.DataManagement;
using Teamcenter.Services.Strong.Cad._2011_06.DataManagement;
using Teamcenter.Services.Strong.Cad._2012_09.DataManagement;
using Teamcenter.Services.Strong.Cad._2014_10.DataManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Cad;

public abstract class DataManagementService : Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2007_12.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2008_03.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2011_06.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2012_09.DataManagement.DataManagement, Teamcenter.Services.Strong.Cad._2014_10.DataManagement.DataManagement
{
	public static DataManagementService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new DataManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	[Obsolete("As of tc2007, use the createOrUpdateParts operation from the _2007_12 namespace.", false)]
	public virtual Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PartInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateRelationsResponse CreateOrUpdateRelations(CreateOrUpdateRelationsInfo[] Info, bool Complete, CreateOrUpdateRelationsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandFoldersForCADResponse ExpandFoldersForCAD(Folder[] Folders, ExpandFolderForCADPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandGRMRelationsResponse ExpandGRMRelations(ModelObject[] Objects, ExpandGRMRelationsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandPrimaryObjectsResponse ExpandPrimaryObjects(ModelObject[] Objects, ExpandPrimaryObjectsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual GenerateAlternateIdsResponse GenerateAlternateIds(GenerateAlternateIdsProperties[] Input)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 9, use the getAllAttrMappings2 operation.", false)]
	public virtual Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAllAttrMappingsResponse GetAllAttrMappings()
	{
		throw new NotImplementedException();
	}

	public virtual GetAttrMappingsForDatasetTypeResponse GetAttrMappingsForDatasetType(GetAttrMappingsForDatasetTypeCriteria[] Info)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007, use the getAvailabelTypes operation from the Core DataManagement service.", false)]
	public virtual GetAvailableTypesResponse GetAvailableTypes(string[] Classes)
	{
		throw new NotImplementedException();
	}

	public virtual ResolveAttrMappingsForDatasetResponse ResolveAttrMappingsForDataset(ResolveAttrMappingsForDatasetInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(PartInfo2[] Info, CreateOrUpdatePartsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(PartInfo3[] Info, CreateOrUpdatePartsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ResolveAttrMappingsResponse ResolveAttrMappings(ResolveAttrMappingsInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.PartInfo[] PartInput, CreateOrUpdatePartsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandFoldersForCADResponse2 ExpandFoldersForCAD(Folder[] Folders, ExpandFolderForCADPref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2010_09.DataManagement.PartInfo[] PartInput, CreateOrUpdatePartsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2011_06.DataManagement.GetAllAttrMappingsResponse GetAllAttrMappings2()
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.PartInfo[] PartInput, CreateOrUpdatePartsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual GetAttrMappingsResponse GetAttrMappings(GetAttrMappingsFilter[] Filter)
	{
		throw new NotImplementedException();
	}
}
