using System;
using System.Collections;
using Teamcenter.Services.Strong.Core._2006_03.DataManagement;
using Teamcenter.Services.Strong.Core._2007_01.DataManagement;
using Teamcenter.Services.Strong.Core._2007_06.DataManagement;
using Teamcenter.Services.Strong.Core._2007_09.DataManagement;
using Teamcenter.Services.Strong.Core._2007_12.DataManagement;
using Teamcenter.Services.Strong.Core._2008_05.DataManagement;
using Teamcenter.Services.Strong.Core._2008_06.DataManagement;
using Teamcenter.Services.Strong.Core._2009_10.DataManagement;
using Teamcenter.Services.Strong.Core._2010_04.DataManagement;
using Teamcenter.Services.Strong.Core._2010_09.DataManagement;
using Teamcenter.Services.Strong.Core._2011_06.DataManagement;
using Teamcenter.Services.Strong.Core._2012_02.DataManagement;
using Teamcenter.Services.Strong.Core._2012_09.DataManagement;
using Teamcenter.Services.Strong.Core._2012_10.DataManagement;
using Teamcenter.Services.Strong.Core._2013_05.DataManagement;
using Teamcenter.Services.Strong.Core._2014_06.DataManagement;
using Teamcenter.Services.Strong.Core._2014_10.DataManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Core;

public abstract class DataManagementService : Teamcenter.Services.Strong.Core._2006_03.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2007_01.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2007_06.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2007_09.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2007_12.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2008_05.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2008_06.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2009_10.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2010_04.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2010_09.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2011_06.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2012_02.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2012_09.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2012_10.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2013_05.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2014_06.DataManagement.DataManagement, Teamcenter.Services.Strong.Core._2014_10.DataManagement.DataManagement
{
	public static DataManagementService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new DataManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ServiceData GetProperties(ModelObject[] Objects, string[] Attributes)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetDisplayProperties(ModelObject[] Objects, Hashtable Attributes)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Tc 8, use the createDatasets2 operation.", false)]
	public virtual Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse CreateDatasets(DatasetProperties[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual CreateFoldersResponse CreateFolders(CreateFolderInput[] Folders, ModelObject Container, string RelationType)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData ChangeOwnership(ObjectOwner[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual CreateItemsResponse CreateItems(ItemProperties[] Properties, ModelObject Container, string RelationType)
	{
		throw new NotImplementedException();
	}

	public virtual GenerateItemIdsAndInitialRevisionIdsResponse GenerateItemIdsAndInitialRevisionIds(GenerateItemIdsAndInitialRevisionIdsProperties[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual GenerateRevisionIdsResponse GenerateRevisionIds(GenerateRevisionIdsProperties[] Input)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Tc 8, use the revise2 operation.", false)]
	public virtual ReviseResponse Revise(Hashtable Input)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData DeleteObjects(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual CreateRelationsResponse CreateRelations(Relationship[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData DeleteRelations(Relationship[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetProperties(ModelObject[] Objects, Hashtable Attributes)
	{
		throw new NotImplementedException();
	}

	public virtual GenerateUIDResponse GenerateUID(int NUID)
	{
		throw new NotImplementedException();
	}

	public virtual GetDatasetCreationRelatedInfoResponse GetDatasetCreationRelatedInfo(string TypeName, ModelObject ParentObject)
	{
		throw new NotImplementedException();
	}

	public virtual MoveToNewFolderResponse MoveToNewFolder(MoveToNewFolderInfo[] MoveToNewFolderInfos)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateFormsResponse CreateOrUpdateForms(FormInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual GetItemCreationRelatedInfoResponse GetItemCreationRelatedInfo(string TypeName, ModelObject ParentObject)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Tc 8, use the getItemAndRelatedObjects operation.", false)]
	public virtual GetItemFromIdResponse GetItemFromId(GetItemFromIdInfo[] Infos, int NRev, GetItemFromIdPref Pref)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Tc 8, use the saveAsNewItem2 operation.", false)]
	public virtual SaveAsNewItemResponse SaveAsNewItem(Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual WhereReferencedResponse WhereReferenced(WorkspaceObject[] Objects, int NumLevels)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData RefreshObjects(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 9.1, use the whereUsed operation from the _2012_02 namespace.", false)]
	public virtual Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedResponse WhereUsed(ModelObject[] Objects, int NumLevels, bool WhereUsedPrecise, ModelObject Rule)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandGRMRelationsResponse ExpandGRMRelationsForPrimary(ModelObject[] PrimaryObjects, ExpandGRMRelationsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual GetAvailableTypesResponse GetAvailableTypes(BaseClassInput[] Classes)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData PurgeSequences(PurgeSequencesInfo[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetOrRemoveImmunity(SetOrRemoveImmunityInfo[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual DatasetTypeInfoResponse GetDatasetTypeInfo(string[] DatasetTypeNames)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10.1, use the validateValues operation.", false)]
	public virtual ValidateItemIdsAndRevIdsResponse ValidateItemIdsAndRevIds(ValidateIdsInfo[] Infos)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandGRMRelationsResponse ExpandGRMRelationsForSecondary(ModelObject[] SecondaryObjects, ExpandGRMRelationsPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual WhereReferencedByRelationNameResponse WhereReferencedByRelationName(WhereReferencedByRelationNameInfo[] Inputs, int NumLevels)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData LoadObjects(string[] Uids)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData RemoveNamedReferenceFromDataset(RemoveNamedReferenceFromDatasetInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandGRMRelationsResponse2 ExpandGRMRelationsForPrimary(ModelObject[] PrimaryObjects, ExpandGRMRelationsPref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ExpandGRMRelationsResponse2 ExpandGRMRelationsForSecondary(ModelObject[] SecondaryObjects, ExpandGRMRelationsPref2 Pref)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData CreateAlternateIdentifiers(AlternateIdentifiersInput[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual GetContextAndIdentifiersResponse GetContextsAndIdentifierTypes(ImanType[] TypeTags)
	{
		throw new NotImplementedException();
	}

	public virtual ListAlternateIdDisplayRulesResponse ListAlternateIdDisplayRules(ListAlternateIdDisplayRulesInfo Input)
	{
		throw new NotImplementedException();
	}

	public virtual ValidateAlternateIdResponse ValidateAlternateIds(ValidateAlternateIdInput[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData UnloadObjects(ModelObject[] ObjsToUnload)
	{
		throw new NotImplementedException();
	}

	public virtual DisplayableSubBOsResponse FindDisplayableSubBusinessObjects(BOWithExclusionIn[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse CreateDatasets2(DatasetProperties2[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual GetItemAndRelatedObjectsResponse GetItemAndRelatedObjects(GetItemAndRelatedObjectsInfo[] Infos)
	{
		throw new NotImplementedException();
	}

	public virtual ReviseResponse2 Revise2(ReviseInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual SaveAsNewItemResponse2 SaveAsNewItem2(Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual GetNextIdsResponse GetNextIds(InfoForNextId[] VInfoForNextId)
	{
		throw new NotImplementedException();
	}

	public virtual GetNRPatternsWithCountersResponse GetNRPatternsWithCounters(NRAttachInfo[] VAttachInfo)
	{
		throw new NotImplementedException();
	}

	public virtual GetRevNRAttachResponse GetRevNRAttachDetails(TypeAndItemRevInfo[] TypeAndItemRevInfos)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateRelationsResponse CreateOrUpdateRelations(CreateOrUpdateRelationsInfo[] Infos, bool Sync)
	{
		throw new NotImplementedException();
	}

	public virtual CreateConnectionsResponse CreateConnections(ConnectionProperties[] Properties, ModelObject Container, string RelationType)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateGDELinksResponse CreateOrUpdateGDELinks(GDELinkInfo[] GdeLinkInfos)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateItemElementsResponse CreateOrUpdateItemElements(ItemElementProperties[] Properties)
	{
		throw new NotImplementedException();
	}

	public virtual CreateResponse CreateObjects(CreateIn[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual AddParticipantOutput AddParticipants(AddParticipantInfo[] AddParticipantInfo)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData RemoveParticipants(Participants[] Participants)
	{
		throw new NotImplementedException();
	}

	public virtual GetTablePropertiesResponse GetTableProperties(Table[] Table)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetTableProperties(TableInfo[] TableData)
	{
		throw new NotImplementedException();
	}

	public virtual GetItemFromAttributeResponse GetItemFromAttribute(GetItemFromAttributeInfo[] Infos, int NRev, GetItemFromIdPref Pref)
	{
		throw new NotImplementedException();
	}

	public virtual DisplayableSubBusinessObjectsResponse FindDisplayableSubBusinessObjectsWithDisplayNames(BOWithExclusionIn[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual GetAvailableBusinessObjectTypesResponse GetAvailableTypesWithDisplayNames(BaseClassInput[] Classes)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2010_04.DataManagement.CreateDatasetsResponse CreateDatasets(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetInfo[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual GetDatasetCreationRelatedInfoResponse2 GetDatasetCreationRelatedInfo2(string TypeName, ModelObject ParentObject)
	{
		throw new NotImplementedException();
	}

	public virtual LocalizedPropertyValuesList GetLocalizedProperties(Teamcenter.Services.Strong.Core._2010_04.DataManagement.PropertyInfo[] Info)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 9, the isLocalizable information is part of propertydescriptor.", false)]
	public virtual LocalizableStatusResponse IsPropertyLocalizable(LocalizableStatusInput[] InputInfo)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetLocalizedProperties(LocalizedPropertyValuesInfo Info)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetLocalizedPropertyValues(LocalizedPropertyValuesInfo[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual SetPropertyResponse SetProperties(PropInfo[] Info, string[] Options)
	{
		throw new NotImplementedException();
	}

	public virtual VerifyExtensionResponse VerifyExtension(VerifyExtensionInfo[] ExtensionInfo)
	{
		throw new NotImplementedException();
	}

	public virtual CreateOrUpdateStaticTableDataResponse CreateOrUpdateStaticTableData(StaticTableInfo StaticTableInfo, RowData[] RowProperties)
	{
		throw new NotImplementedException();
	}

	public virtual StaticTableDataResponse GetStaticTableData(Fnd0StaticTable StaticTable)
	{
		throw new NotImplementedException();
	}

	public virtual EventTypesResponse GetEventTypes(EventObject[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual PostEventResponse PostEvent(PostEventObjectProperties[] Input, string EventTypeName)
	{
		throw new NotImplementedException();
	}

	public virtual ValidateRevIdsResponse ValidateRevIds(ValidateRevIdsInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual SaveAsObjectsResponse SaveAsObjects(SaveAsIn[] SaveAsIn)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10.1.2, use the getTraceReport2 operation. New getTraceReport operation returns BVR specific context line information also.", false)]
	public virtual TraceabilityReportOutput GetTraceReport(TraceabilityInfoInput Input)
	{
		throw new NotImplementedException();
	}

	public virtual ValidationResponse ValidateIdValue(CreateIn[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual CreateResponse BulkCreateObjects(BulkCreIn[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedResponse WhereUsed(WhereUsedInputData[] Input, WhereUsedConfigParameters ConfigParams)
	{
		throw new NotImplementedException();
	}

	public virtual SaveAsObjectsResponse SaveAsObjectAndRelate(SaveAsIn[] SaveAsInput, RelateInfoIn[] RelateInfo)
	{
		throw new NotImplementedException();
	}

	public virtual GetDatasetTypesWithFileExtensionResponse GetDatasetTypesWithFileExtension(string[] FileExtensions)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10.1.2, use the getTraceReport2 operation. New getTraceReport operation returns BVR specific context line information also.", false)]
	public virtual TraceabilityReportOutput1 GetTraceReport(TraceabilityInfoInput1[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData RefreshObjects2(ModelObject[] Objects, bool LockObjects)
	{
		throw new NotImplementedException();
	}

	public virtual GetPasteRelationsResponse GetPasteRelations(GetPasteRelationsInputData[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual ReviseObjectsResponse ReviseObjects(ReviseIn[] ReviseIn)
	{
		throw new NotImplementedException();
	}

	public virtual ValidateValuesResponse ValidateValues(ValidateInput[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual GetChildrenResponse GetChildren(GetChildrenInputData[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual SubTypeNamesResponse GetSubTypeNames(SubTypeNamesInput[] InBOTypeNames)
	{
		throw new NotImplementedException();
	}

	public virtual GenerateNextValuesResponse GenerateNextValues(GenerateNextValuesIn[] GenerateNextValuesIn)
	{
		throw new NotImplementedException();
	}

	public virtual TraceabilityReportOutput2 GetTraceReport2(TraceabilityInfoInput1[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual TraceabilityReportOutputLegacy GetTraceReportLegacy(TraceabilityInfoInput Input)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData AddChildren(ChildrenInputData[] InputData)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData RemoveChildren(ChildrenInputData[] InputData)
	{
		throw new NotImplementedException();
	}
}
