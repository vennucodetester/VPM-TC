using System;
using Teamcenter.Services.Strong.Cad._2007_01.StructureManagement;
using Teamcenter.Services.Strong.Cad._2007_06.StructureManagement;
using Teamcenter.Services.Strong.Cad._2007_09.StructureManagement;
using Teamcenter.Services.Strong.Cad._2007_12.StructureManagement;
using Teamcenter.Services.Strong.Cad._2008_03.StructureManagement;
using Teamcenter.Services.Strong.Cad._2008_06.StructureManagement;
using Teamcenter.Services.Strong.Cad._2009_04.StructureManagement;
using Teamcenter.Services.Strong.Cad._2013_05.StructureManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Cad;

public abstract class StructureManagementService : Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.StructureManagement, Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.StructureManagement
{
	public static StructureManagementService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new StructureManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual CloseBOMWindowsResponse CloseBOMWindows(BOMWindow[] BomWindows)
	{
		throw new NotImplementedException();
	}

	public virtual CreateBOMWindowsResponse CreateBOMWindows(CreateBOMWindowsInfo[] Info)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007, use the createOrUpdateAbsoluteStructure operation from the  207_12 namespace.", false)]
	public virtual CreateOrUpdateAbsoluteStructureResponse CreateOrUpdateAbsoluteStructure(CreateOrUpdateAbsoluteStructureInfo[] Info, string BomViewTypeName, bool Complete, CreateOrUpdateAbsoluteStructurePref Pref)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007, use the createOrUpdateRelativeStructure operation from the 2007_12 namespace.", false)]
	public virtual Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureInfo[] Inputs, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructurePref Pref)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007, use the deleteAssemblyArrangements operation from the 2007_12 namespace.", false)]
	public virtual DeleteAssemblyArrangementsResponse DeleteAssemblyArrangements(DeleteAssemblyArrangementsInfo[] Info, string BomViewTypeName)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007, use the deleteRelativeStructure operation from the 2007_12 namespace.", false)]
	public virtual DeleteRelativeStructureResponse DeleteRelativeStructure(DeleteRelativeStructureInfo[] Inputs, string BomViewTypeName, DeleteRelativeStructurePref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandPSAllLevelsResponse ExpandPSAllLevels(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsInfo Input, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandPSOneLevelResponse ExpandPSOneLevel(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelInfo Input, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual GetRevisionRulesResponse GetRevisionRules()
	{
		throw new NotImplementedException();
	}

	public virtual GetVariantRulesResponse GetVariantRules(ItemRevision[] ItemRevs)
	{
		throw new NotImplementedException();
	}

	public virtual GetConfiguredItemRevisionResponse GetConfiguredItemRevision(GetConfiguredItemRevisionInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData CreateOrUpdateClassicOptions(CreateUpdateClassicOptionsInput[] InputObjects)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007.1, use  the createOrUpdateVariantConditions2 operation.", false)]
	public virtual ServiceData CreateOrUpdateVariantConditions(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateOrUpdateVariantCondInput[] InputObjects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData DeleteClassicOptions(DelClassicOptionsInput[] InputObjects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData DeleteVariantConditions(DeleteVariantCondInput[] InputObjects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData CreateOrUpdateVariantConditions2(Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.CreateOrUpdateVariantCondInput[] InputObjects)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateAbsoluteStructureResponse CreateOrUpdateAbsoluteStructure(CreateOrUpdateAbsoluteStructureInfo2[] Info, string BomViewTypeName, bool Complete, CreateOrUpdateAbsoluteStructurePref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(CreateOrUpdateRelativeStructureInfo2[] Inputs, string BomViewTypeName, bool Complete, CreateOrUpdateRelativeStructurePref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual DeleteAssemblyArrangementsResponse DeleteAssemblyArrangements(DeleteAssemblyArrangementsInfo2[] Info, string BomViewTypeName, DeleteAssemblyArrangementsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual DeleteRelativeStructureResponse DeleteRelativeStructure(DeleteRelativeStructureInfo2[] Inputs, string BomViewTypeName, DeleteRelativeStructurePref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ClassicOptionsResponse QueryClassicOptions(ItemRevision[] InputRevisions)
	{
		throw new NotImplementedException();
	}

	public virtual VariantConditionResponse QueryVariantConditions(BOMLine[] InputBomLines)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10.1, the _2013_05 version of askChildPathBOMLine replaces this version.", false)]
	public virtual AskChildPathBOMLinesResponse AskChildPathBOMLines(AskChildPathBOMLinesInfo[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateAbsoluteStructureResponse2 CreateOrUpdateAbsoluteStructure(CreateOrUpdateAbsoluteStructureInfo3[] AbsOccInfos, string BomViewTypeName, bool Complete, CreateOrUpdateAbsoluteStructurePref3 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(CreateOrUpdateRelativeStructureInfo3[] Inputs, string BomViewTypeName, bool Complete, CreateOrUpdateRelativeStructurePref3 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual DeleteRelativeStructureResponse DeleteRelativeStructure(DeleteRelativeStructureInfo3[] Inputs, string BomViewTypeName, DeleteRelativeStructurePref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandPSAllLevelsResponse2 ExpandPSAllLevels(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsInfo Info, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandPSOneLevelResponse2 ExpandPSOneLevel(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelInfo Info, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual GetAbsoluteStructureDataResponse GetAbsoluteStructureData(AbsOccQualifierInfo[] AbsOccDataQualInfos, AbsOccDataPref AbsOccDataPref)
	{
		throw new NotImplementedException();
	}

	public virtual CreateVariantRulesResponse CreateVariantRules(CreateVariantRulesInfo[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual ReconfigureBOMWindowsResponse ReconfigureBOMWindows(ReconfigureBOMWindowsInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual SaveBOMWindowsResponse SaveBOMWindows(BOMWindow[] BomWindows)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10.1, this version of createOrUpdateRelativeStructure is replaced by the _2013_05 version.", false)]
	public virtual Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureInfo[] Inputs, Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual AskChildPathBOMLinesResponse2 AskChildPathBOMLines2(AskChildPathBOMLinesInfo[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(CreateOrUpdateRelativeStructureInfo4[] Inputs, Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual CreateBOMWindowsResponse CreateBOMWindows2(CreateWindowsInfo2[] Info)
	{
		throw new NotImplementedException();
	}
}
