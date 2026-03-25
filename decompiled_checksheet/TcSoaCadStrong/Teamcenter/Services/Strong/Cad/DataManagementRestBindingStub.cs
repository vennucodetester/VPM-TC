using System;
using System.Collections;
using Teamcenter.Schemas.Cad._2007_01.Datamanagement;
using Teamcenter.Schemas.Cad._2007_12.Datamanagement;
using Teamcenter.Schemas.Cad._2008_03.Datamanagement;
using Teamcenter.Schemas.Cad._2008_06.Datamanagement;
using Teamcenter.Schemas.Cad._2010_09.Datamanagement;
using Teamcenter.Schemas.Cad._2011_06.Datamanagement;
using Teamcenter.Schemas.Cad._2012_09.Datamanagement;
using Teamcenter.Schemas.Cad._2014_10.Datamanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Cad._2007_01.DataManagement;
using Teamcenter.Services.Strong.Cad._2007_12.DataManagement;
using Teamcenter.Services.Strong.Cad._2008_03.DataManagement;
using Teamcenter.Services.Strong.Cad._2008_06.DataManagement;
using Teamcenter.Services.Strong.Cad._2010_09.DataManagement;
using Teamcenter.Services.Strong.Cad._2011_06.DataManagement;
using Teamcenter.Services.Strong.Cad._2012_09.DataManagement;
using Teamcenter.Services.Strong.Cad._2014_10.DataManagement;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Cad;

public class DataManagementRestBindingStub : DataManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string DATAMANAGEMENT_200701_PORT_NAME = "Cad-2007-01-DataManagement";

	private static readonly string DATAMANAGEMENT_200712_PORT_NAME = "Cad-2007-12-DataManagement";

	private static readonly string DATAMANAGEMENT_200803_PORT_NAME = "Cad-2008-03-DataManagement";

	private static readonly string DATAMANAGEMENT_200806_PORT_NAME = "Cad-2008-06-DataManagement";

	private static readonly string DATAMANAGEMENT_201009_PORT_NAME = "Cad-2010-09-DataManagement";

	private static readonly string DATAMANAGEMENT_201106_PORT_NAME = "Cad-2011-06-DataManagement";

	private static readonly string DATAMANAGEMENT_201209_PORT_NAME = "Cad-2012-09-DataManagement";

	private static readonly string DATAMANAGEMENT_201410_PORT_NAME = "Cad-2014-10-DataManagement";

	public DataManagementRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo attributeInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo();
		attributeInfo.setName(local.Name);
		attributeInfo.setValue(local.Value);
		return attributeInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo attributeInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo();
		attributeInfo.Name = wire.getName();
		attributeInfo.Value = wire.getValue();
		return attributeInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.PropDescriptor toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PropDescriptor local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.PropDescriptor propDescriptor = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.PropDescriptor();
		propDescriptor.setPropName(local.PropName);
		propDescriptor.setDisplayName(local.DisplayName);
		propDescriptor.setDefaultValue(local.DefaultValue);
		propDescriptor.setPropValueType(local.PropValueType);
		propDescriptor.setPropType(local.PropType);
		propDescriptor.setIsDisplayable(local.IsDisplayable);
		propDescriptor.setIsArray(local.IsArray);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		propDescriptor.setLov(modelObject);
		propDescriptor.setIsRequired(local.IsRequired);
		propDescriptor.setIsEnabled(local.IsEnabled);
		propDescriptor.setIsModifiable(local.IsModifiable);
		propDescriptor.setAttachedSpecifier(local.AttachedSpecifier);
		propDescriptor.setMaxLength(local.MaxLength);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.InterdependentProps.Length; i++)
		{
			arrayList.Add(local.InterdependentProps[i]);
		}
		propDescriptor.setInterdependentProps(arrayList);
		return propDescriptor;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PropDescriptor toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.PropDescriptor wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PropDescriptor propDescriptor = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PropDescriptor();
		propDescriptor.PropName = wire.getPropName();
		propDescriptor.DisplayName = wire.getDisplayName();
		propDescriptor.DefaultValue = wire.getDefaultValue();
		propDescriptor.PropValueType = wire.getPropValueType();
		propDescriptor.PropType = wire.getPropType();
		propDescriptor.IsDisplayable = wire.IsDisplayable;
		propDescriptor.IsArray = wire.IsArray;
		propDescriptor.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		propDescriptor.IsRequired = wire.IsRequired;
		propDescriptor.IsEnabled = wire.IsEnabled;
		propDescriptor.IsModifiable = wire.IsModifiable;
		propDescriptor.AttachedSpecifier = wire.getAttachedSpecifier();
		propDescriptor.MaxLength = wire.getMaxLength();
		IList interdependentProps = wire.getInterdependentProps();
		propDescriptor.InterdependentProps = new string[interdependentProps.Count];
		for (int i = 0; i < interdependentProps.Count; i++)
		{
			propDescriptor.InterdependentProps[i] = Convert.ToString(interdependentProps[i]);
		}
		return propDescriptor;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttrMappingInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttrMappingInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttrMappingInfo attrMappingInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttrMappingInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.CadAttrMappingDefinition == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.CadAttrMappingDefinition.Uid);
		}
		attrMappingInfo.setCadAttrMappingDefinition(modelObject);
		attrMappingInfo.setPropDesc(toWire(local.PropDesc));
		return attrMappingInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttrMappingInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttrMappingInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttrMappingInfo attrMappingInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttrMappingInfo();
		attrMappingInfo.CadAttrMappingDefinition = (CadAttrMappingDefinition)modelManager.LoadObjectData(wire.getCadAttrMappingDefinition());
		attrMappingInfo.PropDesc = toLocal(wire.getPropDesc(), modelManager);
		return attrMappingInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.CommitDatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CommitDatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.CommitDatasetFileInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		commitDatasetFileInfo.setDataset(modelObject);
		commitDatasetFileInfo.setCreateNewVersion(local.CreateNewVersion);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetFileTicketInfos.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetFileTicketInfos[i]));
		}
		commitDatasetFileInfo.setDatasetFileTicketInfos(arrayList);
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CommitDatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CommitDatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CommitDatasetFileInfo();
		commitDatasetFileInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		commitDatasetFileInfo.CreateNewVersion = wire.CreateNewVersion;
		IList datasetFileTicketInfos = wire.getDatasetFileTicketInfos();
		commitDatasetFileInfo.DatasetFileTicketInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileTicketInfo[datasetFileTicketInfos.Count];
		for (int i = 0; i < datasetFileTicketInfos.Count; i++)
		{
			commitDatasetFileInfo.DatasetFileTicketInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileTicketInfo)datasetFileTicketInfos[i], modelManager);
		}
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsOutput createOrUpdatePartsOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsOutput();
		createOrUpdatePartsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		createOrUpdatePartsOutput.setItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		createOrUpdatePartsOutput.setItemRev(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetOutput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetOutput[i]));
		}
		createOrUpdatePartsOutput.setDatasetOutput(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraItemObjs.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraItemObjs[i]));
		}
		createOrUpdatePartsOutput.setExtraItemObjs(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraItemRevObjs.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraItemRevObjs[i]));
		}
		createOrUpdatePartsOutput.setExtraItemRevObjs(arrayList3);
		return createOrUpdatePartsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsOutput createOrUpdatePartsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsOutput();
		createOrUpdatePartsOutput.ClientId = wire.getClientId();
		createOrUpdatePartsOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		createOrUpdatePartsOutput.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList datasetOutput = wire.getDatasetOutput();
		createOrUpdatePartsOutput.DatasetOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetOutput[datasetOutput.Count];
		for (int i = 0; i < datasetOutput.Count; i++)
		{
			createOrUpdatePartsOutput.DatasetOutput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetOutput)datasetOutput[i], modelManager);
		}
		IList extraItemObjs = wire.getExtraItemObjs();
		createOrUpdatePartsOutput.ExtraItemObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[extraItemObjs.Count];
		for (int i = 0; i < extraItemObjs.Count; i++)
		{
			createOrUpdatePartsOutput.ExtraItemObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)extraItemObjs[i], modelManager);
		}
		IList extraItemRevObjs = wire.getExtraItemRevObjs();
		createOrUpdatePartsOutput.ExtraItemRevObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[extraItemRevObjs.Count];
		for (int i = 0; i < extraItemRevObjs.Count; i++)
		{
			createOrUpdatePartsOutput.ExtraItemRevObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)extraItemRevObjs[i], modelManager);
		}
		return createOrUpdatePartsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse createOrUpdatePartsResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse();
		createOrUpdatePartsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createOrUpdatePartsResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createOrUpdatePartsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsOutput)output[i], modelManager);
		}
		return createOrUpdatePartsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsInfo createOrUpdateRelationsInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsInfo();
		createOrUpdateRelationsInfo.setClientId(local.ClientId);
		createOrUpdateRelationsInfo.setRelationType(local.RelationType);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryObject.Uid);
		}
		createOrUpdateRelationsInfo.setPrimaryObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SecondaryObject == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.SecondaryObject.Uid);
		}
		createOrUpdateRelationsInfo.setSecondaryObject(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Relation == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.Relation.Uid);
		}
		createOrUpdateRelationsInfo.setRelation(modelObject3);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject4 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.UserData == null)
		{
			modelObject4.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject4.setUid(local.UserData.Uid);
		}
		createOrUpdateRelationsInfo.setUserData(modelObject4);
		return createOrUpdateRelationsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsInfo createOrUpdateRelationsInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsInfo();
		createOrUpdateRelationsInfo.ClientId = wire.getClientId();
		createOrUpdateRelationsInfo.RelationType = wire.getRelationType();
		createOrUpdateRelationsInfo.PrimaryObject = modelManager.LoadObjectData(wire.getPrimaryObject());
		createOrUpdateRelationsInfo.SecondaryObject = modelManager.LoadObjectData(wire.getSecondaryObject());
		createOrUpdateRelationsInfo.Relation = (ImanRelation)modelManager.LoadObjectData(wire.getRelation());
		createOrUpdateRelationsInfo.UserData = modelManager.LoadObjectData(wire.getUserData());
		return createOrUpdateRelationsInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsOutput createOrUpdateRelationsOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsOutput();
		createOrUpdateRelationsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Relation == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Relation.Uid);
		}
		createOrUpdateRelationsOutput.setRelation(modelObject);
		return createOrUpdateRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsOutput createOrUpdateRelationsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsOutput();
		createOrUpdateRelationsOutput.ClientId = wire.getClientId();
		createOrUpdateRelationsOutput.Relation = (ImanRelation)modelManager.LoadObjectData(wire.getRelation());
		return createOrUpdateRelationsOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsPref toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsPref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsPref createOrUpdateRelationsPref = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsPref();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		createOrUpdateRelationsPref.setInfo(arrayList);
		return createOrUpdateRelationsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsPref toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsPref createOrUpdateRelationsPref = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsPref();
		IList info = wire.getInfo();
		createOrUpdateRelationsPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			createOrUpdateRelationsPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2)info[i], modelManager);
		}
		return createOrUpdateRelationsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsResponse createOrUpdateRelationsResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsResponse();
		createOrUpdateRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createOrUpdateRelationsResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createOrUpdateRelationsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsOutput)output[i], modelManager);
		}
		return createOrUpdateRelationsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo();
		datasetFileInfo.setClientId(local.ClientId);
		datasetFileInfo.setFileName(local.FileName);
		datasetFileInfo.setNamedReferencedName(local.NamedReferencedName);
		datasetFileInfo.setIsText(local.IsText);
		datasetFileInfo.setAllowReplace(local.AllowReplace);
		return datasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo();
		datasetFileInfo.ClientId = wire.getClientId();
		datasetFileInfo.FileName = wire.getFileName();
		datasetFileInfo.NamedReferencedName = wire.getNamedReferencedName();
		datasetFileInfo.IsText = wire.IsText;
		datasetFileInfo.AllowReplace = wire.AllowReplace;
		return datasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileTicketInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileTicketInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.setDatasetFileInfo(toWire(local.DatasetFileInfo));
		datasetFileTicketInfo.setTicket(local.Ticket);
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileTicketInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileTicketInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.DatasetFileInfo = toLocal(wire.getDatasetFileInfo(), modelManager);
		datasetFileTicketInfo.Ticket = wire.getTicket();
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetInfo();
		datasetInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetInfo.setDataset(modelObject);
		datasetInfo.setName(local.Name);
		datasetInfo.setDescription(local.Description);
		datasetInfo.setType(local.Type);
		datasetInfo.setId(local.Id);
		datasetInfo.setDatasetRev(local.DatasetRev);
		datasetInfo.setItemRevRelationName(local.ItemRevRelationName);
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		datasetInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.MappingAttributes.Length; i++)
		{
			arrayList2.Add(toWire(local.MappingAttributes[i]));
		}
		datasetInfo.setMappingAttributes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraObject[i]));
		}
		datasetInfo.setExtraObject(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList4.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList5.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList5);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetInfo.Name = wire.getName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.Id = wire.getId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.ItemRevRelationName = wire.getItemRevRelationName();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList attrList = wire.getAttrList();
		datasetInfo.AttrList = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			datasetInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList mappingAttributes = wire.getMappingAttributes();
		datasetInfo.MappingAttributes = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[mappingAttributes.Count];
		for (int i = 0; i < mappingAttributes.Count; i++)
		{
			datasetInfo.MappingAttributes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)mappingAttributes[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		datasetInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			datasetInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.NamedReferenceObjectInfo[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.NamedReferenceObjectInfo)namedReferenceObjectInfos[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetOutput datasetOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetOutput();
		datasetOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetOutput.setDataset(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.CommitInfo.Length; i++)
		{
			arrayList.Add(toWire(local.CommitInfo[i]));
		}
		datasetOutput.setCommitInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObjs.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObjs[i]));
		}
		datasetOutput.setExtraObjs(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.NamedRefObjs.Length; i++)
		{
			arrayList3.Add(toWire(local.NamedRefObjs[i]));
		}
		datasetOutput.setNamedRefObjs(arrayList3);
		return datasetOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetOutput datasetOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetOutput();
		datasetOutput.ClientId = wire.getClientId();
		datasetOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList commitInfo = wire.getCommitInfo();
		datasetOutput.CommitInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CommitDatasetFileInfo[commitInfo.Count];
		for (int i = 0; i < commitInfo.Count; i++)
		{
			datasetOutput.CommitInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.CommitDatasetFileInfo)commitInfo[i], modelManager);
		}
		IList extraObjs = wire.getExtraObjs();
		datasetOutput.ExtraObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[extraObjs.Count];
		for (int i = 0; i < extraObjs.Count; i++)
		{
			datasetOutput.ExtraObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)extraObjs[i], modelManager);
		}
		IList namedRefObjs = wire.getNamedRefObjs();
		datasetOutput.NamedRefObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[namedRefObjs.Count];
		for (int i = 0; i < namedRefObjs.Count; i++)
		{
			datasetOutput.NamedRefObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)namedRefObjs[i], modelManager);
		}
		return datasetOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFolderForCADPref toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFolderForCADPref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFolderForCADPref expandFolderForCADPref = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFolderForCADPref();
		expandFolderForCADPref.setExpItemRev(local.ExpItemRev);
		expandFolderForCADPref.setLatestNRevs(local.LatestNRevs);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandFolderForCADPref.setInfo(arrayList);
		return expandFolderForCADPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFolderForCADPref toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFolderForCADPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFolderForCADPref expandFolderForCADPref = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFolderForCADPref();
		expandFolderForCADPref.ExpItemRev = wire.ExpItemRev;
		expandFolderForCADPref.LatestNRevs = wire.getLatestNRevs();
		IList info = wire.getInfo();
		expandFolderForCADPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandFolderForCADPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2)info[i], modelManager);
		}
		return expandFolderForCADPref;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemOutput expandFoldersForCADItemOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OutputItem == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OutputItem.Uid);
		}
		expandFoldersForCADItemOutput.setOutputItem(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemRevsOutput.Length; i++)
		{
			arrayList.Add(toWire(local.ItemRevsOutput[i]));
		}
		expandFoldersForCADItemOutput.setItemRevsOutput(arrayList);
		return expandFoldersForCADItemOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemOutput expandFoldersForCADItemOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemOutput();
		expandFoldersForCADItemOutput.OutputItem = (Item)modelManager.LoadObjectData(wire.getOutputItem());
		IList itemRevsOutput = wire.getItemRevsOutput();
		expandFoldersForCADItemOutput.ItemRevsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput[itemRevsOutput.Count];
		for (int i = 0; i < itemRevsOutput.Count; i++)
		{
			expandFoldersForCADItemOutput.ItemRevsOutput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput)itemRevsOutput[i], modelManager);
		}
		return expandFoldersForCADItemOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput expandFoldersForCADItemRevOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OutputItemRevs == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OutputItemRevs.Uid);
		}
		expandFoldersForCADItemRevOutput.setOutputItemRevs(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OutputDatasets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.OutputDatasets[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.OutputDatasets[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		expandFoldersForCADItemRevOutput.setOutputDatasets(arrayList);
		return expandFoldersForCADItemRevOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput expandFoldersForCADItemRevOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput();
		expandFoldersForCADItemRevOutput.OutputItemRevs = (ItemRevision)modelManager.LoadObjectData(wire.getOutputItemRevs());
		IList outputDatasets = wire.getOutputDatasets();
		expandFoldersForCADItemRevOutput.OutputDatasets = new Dataset[outputDatasets.Count];
		for (int i = 0; i < outputDatasets.Count; i++)
		{
			expandFoldersForCADItemRevOutput.OutputDatasets[i] = (Dataset)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)outputDatasets[i]);
		}
		return expandFoldersForCADItemRevOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADOutput expandFoldersForCADOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputFolder == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputFolder.Uid);
		}
		expandFoldersForCADOutput.setInputFolder(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.FstlvlFolders.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.FstlvlFolders[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.FstlvlFolders[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		expandFoldersForCADOutput.setFstlvlFolders(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ItemsOutput.Length; i++)
		{
			arrayList2.Add(toWire(local.ItemsOutput[i]));
		}
		expandFoldersForCADOutput.setItemsOutput(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ItemRevsOutput.Length; i++)
		{
			arrayList3.Add(toWire(local.ItemRevsOutput[i]));
		}
		expandFoldersForCADOutput.setItemRevsOutput(arrayList3);
		return expandFoldersForCADOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADOutput expandFoldersForCADOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADOutput();
		expandFoldersForCADOutput.InputFolder = (Folder)modelManager.LoadObjectData(wire.getInputFolder());
		IList fstlvlFolders = wire.getFstlvlFolders();
		expandFoldersForCADOutput.FstlvlFolders = new Folder[fstlvlFolders.Count];
		for (int i = 0; i < fstlvlFolders.Count; i++)
		{
			expandFoldersForCADOutput.FstlvlFolders[i] = (Folder)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)fstlvlFolders[i]);
		}
		IList itemsOutput = wire.getItemsOutput();
		expandFoldersForCADOutput.ItemsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemOutput[itemsOutput.Count];
		for (int i = 0; i < itemsOutput.Count; i++)
		{
			expandFoldersForCADOutput.ItemsOutput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemOutput)itemsOutput[i], modelManager);
		}
		IList itemRevsOutput = wire.getItemRevsOutput();
		expandFoldersForCADOutput.ItemRevsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput[itemRevsOutput.Count];
		for (int i = 0; i < itemRevsOutput.Count; i++)
		{
			expandFoldersForCADOutput.ItemRevsOutput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput)itemRevsOutput[i], modelManager);
		}
		return expandFoldersForCADOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADResponse expandFoldersForCADResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADResponse();
		expandFoldersForCADResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandFoldersForCADResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandFoldersForCADResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADOutput)output[i], modelManager);
		}
		return expandFoldersForCADResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsData toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsData local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsData expandGRMRelationsData = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsData();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OtherSideObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.OtherSideObjects[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.OtherSideObjects[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		expandGRMRelationsData.setOtherSideObjects(arrayList);
		expandGRMRelationsData.setRelationName(local.RelationName);
		return expandGRMRelationsData;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsData toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsData expandGRMRelationsData = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsData();
		IList otherSideObjects = wire.getOtherSideObjects();
		expandGRMRelationsData.OtherSideObjects = new Teamcenter.Soa.Client.Model.ModelObject[otherSideObjects.Count];
		for (int i = 0; i < otherSideObjects.Count; i++)
		{
			expandGRMRelationsData.OtherSideObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)otherSideObjects[i]);
		}
		expandGRMRelationsData.RelationName = wire.getRelationName();
		return expandGRMRelationsData;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsOutput expandGRMRelationsOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		expandGRMRelationsOutput.setInputObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OtherSideObjData.Length; i++)
		{
			arrayList.Add(toWire(local.OtherSideObjData[i]));
		}
		expandGRMRelationsOutput.setOtherSideObjData(arrayList);
		return expandGRMRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsOutput expandGRMRelationsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsOutput();
		expandGRMRelationsOutput.InputObject = modelManager.LoadObjectData(wire.getInputObject());
		IList otherSideObjData = wire.getOtherSideObjData();
		expandGRMRelationsOutput.OtherSideObjData = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsData[otherSideObjData.Count];
		for (int i = 0; i < otherSideObjData.Count; i++)
		{
			expandGRMRelationsOutput.OtherSideObjData[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsData)otherSideObjData[i], modelManager);
		}
		return expandGRMRelationsOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsPref toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsPref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsPref expandGRMRelationsPref = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsPref();
		expandGRMRelationsPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandGRMRelationsPref.setInfo(arrayList);
		return expandGRMRelationsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsPref toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsPref expandGRMRelationsPref = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsPref();
		expandGRMRelationsPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandGRMRelationsPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandGRMRelationsPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2)info[i], modelManager);
		}
		return expandGRMRelationsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsResponse expandGRMRelationsResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsResponse();
		expandGRMRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandGRMRelationsResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandGRMRelationsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsOutput)output[i], modelManager);
		}
		return expandGRMRelationsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsData toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsData local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsData expandPrimaryObjectsData = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsData();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OtherSideObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.OtherSideObjects[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.OtherSideObjects[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		expandPrimaryObjectsData.setOtherSideObjects(arrayList);
		expandPrimaryObjectsData.setRelationName(local.RelationName);
		return expandPrimaryObjectsData;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsData toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsData expandPrimaryObjectsData = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsData();
		IList otherSideObjects = wire.getOtherSideObjects();
		expandPrimaryObjectsData.OtherSideObjects = new Teamcenter.Soa.Client.Model.ModelObject[otherSideObjects.Count];
		for (int i = 0; i < otherSideObjects.Count; i++)
		{
			expandPrimaryObjectsData.OtherSideObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)otherSideObjects[i]);
		}
		expandPrimaryObjectsData.RelationName = wire.getRelationName();
		return expandPrimaryObjectsData;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsOutput expandPrimaryObjectsOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		expandPrimaryObjectsOutput.setInputObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OtherSideObjData.Length; i++)
		{
			arrayList.Add(toWire(local.OtherSideObjData[i]));
		}
		expandPrimaryObjectsOutput.setOtherSideObjData(arrayList);
		return expandPrimaryObjectsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsOutput expandPrimaryObjectsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsOutput();
		expandPrimaryObjectsOutput.InputObject = modelManager.LoadObjectData(wire.getInputObject());
		IList otherSideObjData = wire.getOtherSideObjData();
		expandPrimaryObjectsOutput.OtherSideObjData = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsData[otherSideObjData.Count];
		for (int i = 0; i < otherSideObjData.Count; i++)
		{
			expandPrimaryObjectsOutput.OtherSideObjData[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsData)otherSideObjData[i], modelManager);
		}
		return expandPrimaryObjectsOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsPref toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsPref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsPref expandPrimaryObjectsPref = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsPref();
		expandPrimaryObjectsPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandPrimaryObjectsPref.setInfo(arrayList);
		return expandPrimaryObjectsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsPref toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsPref expandPrimaryObjectsPref = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsPref();
		expandPrimaryObjectsPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandPrimaryObjectsPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandPrimaryObjectsPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2)info[i], modelManager);
		}
		return expandPrimaryObjectsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsResponse expandPrimaryObjectsResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsResponse();
		expandPrimaryObjectsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandPrimaryObjectsResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandPrimaryObjectsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsOutput)output[i], modelManager);
		}
		return expandPrimaryObjectsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo extraObjectInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		extraObjectInfo.setObject(modelObject);
		extraObjectInfo.setClientId(local.ClientId);
		extraObjectInfo.setRelationTypeName(local.RelationTypeName);
		extraObjectInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrNameValuePairs.Length; i++)
		{
			arrayList.Add(toWire(local.AttrNameValuePairs[i]));
		}
		extraObjectInfo.setAttrNameValuePairs(arrayList);
		return extraObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo extraObjectInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo();
		extraObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		extraObjectInfo.ClientId = wire.getClientId();
		extraObjectInfo.RelationTypeName = wire.getRelationTypeName();
		extraObjectInfo.TypeName = wire.getTypeName();
		IList attrNameValuePairs = wire.getAttrNameValuePairs();
		extraObjectInfo.AttrNameValuePairs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrNameValuePairs.Count];
		for (int i = 0; i < attrNameValuePairs.Count; i++)
		{
			extraObjectInfo.AttrNameValuePairs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrNameValuePairs[i], modelManager);
		}
		return extraObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput extraObjectOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput();
		extraObjectOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		extraObjectOutput.setObject(modelObject);
		return extraObjectOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput extraObjectOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput();
		extraObjectOutput.ClientId = wire.getClientId();
		extraObjectOutput.Object = modelManager.LoadObjectData(wire.getObject());
		return extraObjectOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsProperties toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsProperties local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsProperties generateAlternateIdsProperties = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsProperties();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.IdContext == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.IdContext.Uid);
		}
		generateAlternateIdsProperties.setIdContext(modelObject);
		generateAlternateIdsProperties.setPattern(local.Pattern);
		generateAlternateIdsProperties.setAltIdType(local.AltIdType);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ParentAltId == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ParentAltId.Uid);
		}
		generateAlternateIdsProperties.setParentAltId(modelObject2);
		generateAlternateIdsProperties.setCount(local.Count);
		return generateAlternateIdsProperties;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsProperties toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsProperties generateAlternateIdsProperties = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsProperties();
		generateAlternateIdsProperties.IdContext = modelManager.LoadObjectData(wire.getIdContext());
		generateAlternateIdsProperties.Pattern = wire.getPattern();
		generateAlternateIdsProperties.AltIdType = wire.getAltIdType();
		generateAlternateIdsProperties.ParentAltId = modelManager.LoadObjectData(wire.getParentAltId());
		generateAlternateIdsProperties.Count = wire.getCount();
		return generateAlternateIdsProperties;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsResponse generateAlternateIdsResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsResponse();
		generateAlternateIdsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		generateAlternateIdsResponse.InputIndexToAltId = toLocalIndexToAltId(wire.getInputIndexToAltId(), modelManager);
		return generateAlternateIdsResponse;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAllAttrMappingsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAllAttrMappingsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAllAttrMappingsResponse getAllAttrMappingsResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAllAttrMappingsResponse();
		getAllAttrMappingsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList attrMappingInfos = wire.getAttrMappingInfos();
		getAllAttrMappingsResponse.AttrMappingInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttrMappingInfo[attrMappingInfos.Count];
		for (int i = 0; i < attrMappingInfos.Count; i++)
		{
			getAllAttrMappingsResponse.AttrMappingInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttrMappingInfo)attrMappingInfos[i], modelManager);
		}
		return getAllAttrMappingsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeCriteria toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeCriteria local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeCriteria getAttrMappingsForDatasetTypeCriteria = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeCriteria();
		getAttrMappingsForDatasetTypeCriteria.setDatasetTypeName(local.DatasetTypeName);
		getAttrMappingsForDatasetTypeCriteria.setItemTypeName(local.ItemTypeName);
		getAttrMappingsForDatasetTypeCriteria.setExact(local.Exact);
		return getAttrMappingsForDatasetTypeCriteria;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeCriteria toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeCriteria wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeCriteria getAttrMappingsForDatasetTypeCriteria = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeCriteria();
		getAttrMappingsForDatasetTypeCriteria.DatasetTypeName = wire.getDatasetTypeName();
		getAttrMappingsForDatasetTypeCriteria.ItemTypeName = wire.getItemTypeName();
		getAttrMappingsForDatasetTypeCriteria.Exact = wire.Exact;
		return getAttrMappingsForDatasetTypeCriteria;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeOutput getAttrMappingsForDatasetTypeOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeOutput();
		getAttrMappingsForDatasetTypeOutput.setCriteria(toWire(local.Criteria));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrMappingInfos.Length; i++)
		{
			arrayList.Add(toWire(local.AttrMappingInfos[i]));
		}
		getAttrMappingsForDatasetTypeOutput.setAttrMappingInfos(arrayList);
		return getAttrMappingsForDatasetTypeOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeOutput getAttrMappingsForDatasetTypeOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeOutput();
		getAttrMappingsForDatasetTypeOutput.Criteria = toLocal(wire.getCriteria(), modelManager);
		IList attrMappingInfos = wire.getAttrMappingInfos();
		getAttrMappingsForDatasetTypeOutput.AttrMappingInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttrMappingInfo[attrMappingInfos.Count];
		for (int i = 0; i < attrMappingInfos.Count; i++)
		{
			getAttrMappingsForDatasetTypeOutput.AttrMappingInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttrMappingInfo)attrMappingInfos[i], modelManager);
		}
		return getAttrMappingsForDatasetTypeOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeResponse getAttrMappingsForDatasetTypeResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeResponse();
		getAttrMappingsForDatasetTypeResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getAttrMappingsForDatasetTypeResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getAttrMappingsForDatasetTypeResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeOutput)output[i], modelManager);
		}
		return getAttrMappingsForDatasetTypeResponse;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAvailableTypesResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAvailableTypesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAvailableTypesResponse getAvailableTypesResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAvailableTypesResponse();
		getAvailableTypesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getAvailableTypesResponse.InputClassToTypes = toLocalClassToTypesMap(wire.getInputClassToTypes(), modelManager);
		return getAvailableTypesResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemInfo itemInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		itemInfo.setItem(modelObject);
		itemInfo.setItemId(local.ItemId);
		itemInfo.setItemType(local.ItemType);
		itemInfo.setName(local.Name);
		itemInfo.setDescription(local.Description);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		itemInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObject[i]));
		}
		itemInfo.setExtraObject(arrayList2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Folder.Uid);
		}
		itemInfo.setFolder(modelObject2);
		return itemInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemInfo itemInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemInfo();
		itemInfo.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		itemInfo.ItemId = wire.getItemId();
		itemInfo.ItemType = wire.getItemType();
		itemInfo.Name = wire.getName();
		itemInfo.Description = wire.getDescription();
		IList attrList = wire.getAttrList();
		itemInfo.AttrList = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			itemInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		itemInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			itemInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		itemInfo.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		return itemInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemRevInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemRevInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemRevInfo itemRevInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemRevInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		itemRevInfo.setItemRevision(modelObject);
		itemRevInfo.setRevId(local.RevId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		itemRevInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObject[i]));
		}
		itemRevInfo.setExtraObject(arrayList2);
		return itemRevInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemRevInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ItemRevInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemRevInfo itemRevInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ItemRevInfo();
		itemRevInfo.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		itemRevInfo.RevId = wire.getRevId();
		IList attrList = wire.getAttrList();
		itemRevInfo.AttrList = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			itemRevInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		itemRevInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			itemRevInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		return itemRevInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.MappedDatasetAttrProperty toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.MappedDatasetAttrProperty local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.MappedDatasetAttrProperty mappedDatasetAttrProperty = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.MappedDatasetAttrProperty();
		mappedDatasetAttrProperty.setAttrTitle(local.AttrTitle);
		mappedDatasetAttrProperty.setDatasetTypeName(local.DatasetTypeName);
		mappedDatasetAttrProperty.setItemTypeName(local.ItemTypeName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ResolvedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ResolvedObject.Uid);
		}
		mappedDatasetAttrProperty.setResolvedObject(modelObject);
		mappedDatasetAttrProperty.setResolvedPropertyName(local.ResolvedPropertyName);
		return mappedDatasetAttrProperty;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.MappedDatasetAttrProperty toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.MappedDatasetAttrProperty wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.MappedDatasetAttrProperty mappedDatasetAttrProperty = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.MappedDatasetAttrProperty();
		mappedDatasetAttrProperty.AttrTitle = wire.getAttrTitle();
		mappedDatasetAttrProperty.DatasetTypeName = wire.getDatasetTypeName();
		mappedDatasetAttrProperty.ItemTypeName = wire.getItemTypeName();
		mappedDatasetAttrProperty.ResolvedObject = modelManager.LoadObjectData(wire.getResolvedObject());
		mappedDatasetAttrProperty.ResolvedPropertyName = wire.getResolvedPropertyName();
		return mappedDatasetAttrProperty;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.NamedReferenceObjectInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.NamedReferenceObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		namedReferenceObjectInfo.setObject(modelObject);
		namedReferenceObjectInfo.setNamedReferenceName(local.NamedReferenceName);
		namedReferenceObjectInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrNameValuePairs.Length; i++)
		{
			arrayList.Add(toWire(local.AttrNameValuePairs[i]));
		}
		namedReferenceObjectInfo.setAttrNameValuePairs(arrayList);
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.NamedReferenceObjectInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.NamedReferenceObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.ClientId = wire.getClientId();
		namedReferenceObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		namedReferenceObjectInfo.NamedReferenceName = wire.getNamedReferenceName();
		namedReferenceObjectInfo.TypeName = wire.getTypeName();
		IList attrNameValuePairs = wire.getAttrNameValuePairs();
		namedReferenceObjectInfo.AttrNameValuePairs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrNameValuePairs.Count];
		for (int i = 0; i < attrNameValuePairs.Count; i++)
		{
			namedReferenceObjectInfo.AttrNameValuePairs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrNameValuePairs[i], modelManager);
		}
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.PartInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PartInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.PartInfo partInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.PartInfo();
		partInfo.setClientId(local.ClientId);
		partInfo.setItemInput(toWire(local.ItemInput));
		partInfo.setItemRevInput(toWire(local.ItemRevInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetInput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetInput[i]));
		}
		partInfo.setDatasetInput(arrayList);
		return partInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PartInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.PartInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PartInfo partInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PartInfo();
		partInfo.ClientId = wire.getClientId();
		partInfo.ItemInput = toLocal(wire.getItemInput(), modelManager);
		partInfo.ItemRevInput = toLocal(wire.getItemRevInput(), modelManager);
		IList datasetInput = wire.getDatasetInput();
		partInfo.DatasetInput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetInfo[datasetInput.Count];
		for (int i = 0; i < datasetInput.Count; i++)
		{
			partInfo.DatasetInput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetInfo)datasetInput[i], modelManager);
		}
		return partInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2 toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2 local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2 relationAndTypesFilter = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2();
		relationAndTypesFilter.setRelationName(local.RelationName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectTypeNames.Length; i++)
		{
			arrayList.Add(local.ObjectTypeNames[i]);
		}
		relationAndTypesFilter.setObjectTypeNames(arrayList);
		return relationAndTypesFilter;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2 toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2 relationAndTypesFilter = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2();
		relationAndTypesFilter.RelationName = wire.getRelationName();
		IList objectTypeNames = wire.getObjectTypeNames();
		relationAndTypesFilter.ObjectTypeNames = new string[objectTypeNames.Count];
		for (int i = 0; i < objectTypeNames.Count; i++)
		{
			relationAndTypesFilter.ObjectTypeNames[i] = Convert.ToString(objectTypeNames[i]);
		}
		return relationAndTypesFilter;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetInfo resolveAttrMappingsForDatasetInfo = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		resolveAttrMappingsForDatasetInfo.setDataset(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		resolveAttrMappingsForDatasetInfo.setItemRev(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.CadAttrMappingDefinitions.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.CadAttrMappingDefinitions[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.CadAttrMappingDefinitions[i].Uid);
			}
			arrayList.Add(modelObject3);
		}
		resolveAttrMappingsForDatasetInfo.setCadAttrMappingDefinitions(arrayList);
		return resolveAttrMappingsForDatasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetInfo resolveAttrMappingsForDatasetInfo = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetInfo();
		resolveAttrMappingsForDatasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		resolveAttrMappingsForDatasetInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList cadAttrMappingDefinitions = wire.getCadAttrMappingDefinitions();
		resolveAttrMappingsForDatasetInfo.CadAttrMappingDefinitions = new CadAttrMappingDefinition[cadAttrMappingDefinitions.Count];
		for (int i = 0; i < cadAttrMappingDefinitions.Count; i++)
		{
			resolveAttrMappingsForDatasetInfo.CadAttrMappingDefinitions[i] = (CadAttrMappingDefinition)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)cadAttrMappingDefinitions[i]);
		}
		return resolveAttrMappingsForDatasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetOutput resolveAttrMappingsForDatasetOutput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		resolveAttrMappingsForDatasetOutput.setDataset(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.MappedProperties.Length; i++)
		{
			arrayList.Add(toWire(local.MappedProperties[i]));
		}
		resolveAttrMappingsForDatasetOutput.setMappedProperties(arrayList);
		return resolveAttrMappingsForDatasetOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetOutput resolveAttrMappingsForDatasetOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetOutput();
		resolveAttrMappingsForDatasetOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList mappedProperties = wire.getMappedProperties();
		resolveAttrMappingsForDatasetOutput.MappedProperties = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.MappedDatasetAttrProperty[mappedProperties.Count];
		for (int i = 0; i < mappedProperties.Count; i++)
		{
			resolveAttrMappingsForDatasetOutput.MappedProperties[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.MappedDatasetAttrProperty)mappedProperties[i], modelManager);
		}
		return resolveAttrMappingsForDatasetOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetResponse resolveAttrMappingsForDatasetResponse = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetResponse();
		resolveAttrMappingsForDatasetResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		resolveAttrMappingsForDatasetResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			resolveAttrMappingsForDatasetResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetOutput)output[i], modelManager);
		}
		return resolveAttrMappingsForDatasetResponse;
	}

	public static ArrayList toWireClassToTypesMap(IDictionary ClassToTypesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClassToTypesMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClassToTypesMap classToTypesMap = new ClassToTypesMap();
			classToTypesMap.setKey(Convert.ToString(key));
			IList value2 = classToTypesMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			classToTypesMap.setValue((ArrayList)value2);
			arrayList.Add(classToTypesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClassToTypesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClassToTypesMap classToTypesMap = (ClassToTypesMap)wire[i];
			string key = classToTypesMap.getKey();
			IList value = classToTypesMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireIndexToAltId(IDictionary IndexToAltId)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IndexToAltId)
		{
			object key = item.Key;
			object value = item.Value;
			IndexToAltId indexToAltId = new IndexToAltId();
			indexToAltId.setKey((int)key);
			IList value2 = indexToAltId.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			indexToAltId.setValue((ArrayList)value2);
			arrayList.Add(indexToAltId);
		}
		return arrayList;
	}

	public static Hashtable toLocalIndexToAltId(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IndexToAltId indexToAltId = (IndexToAltId)wire[i];
			int key = indexToAltId.getKey();
			IList value = indexToAltId.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	[Obsolete("As of tc2007, use the createOrUpdateParts operation from the _2007_12 namespace.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.PartInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsInput createOrUpdatePartsInput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdatePartsInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "CreateOrUpdateParts", createOrUpdatePartsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsResponse CreateOrUpdateRelations(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsInfo[] Info, bool Complete, Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateRelationsInput createOrUpdateRelationsInput = new CreateOrUpdateRelationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdateRelationsInput.setInfo(arrayList);
			createOrUpdateRelationsInput.setComplete(Complete);
			createOrUpdateRelationsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "CreateOrUpdateRelations", createOrUpdateRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdateRelationsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdateRelationsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADResponse ExpandFoldersForCAD(Folder[] Folders, Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFolderForCADPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADInput expandFoldersForCADInput = new Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Folders.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Folders[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Folders[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandFoldersForCADInput.setFolders(arrayList);
			expandFoldersForCADInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "ExpandFoldersForCAD", expandFoldersForCADInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsResponse ExpandGRMRelations(Teamcenter.Soa.Client.Model.ModelObject[] Objects, Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			ExpandGRMRelationsInput expandGRMRelationsInput = new ExpandGRMRelationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Objects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Objects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Objects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandGRMRelationsInput.setObjects(arrayList);
			expandGRMRelationsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "ExpandGRMRelations", expandGRMRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandGRMRelationsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandGRMRelationsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsResponse ExpandPrimaryObjects(Teamcenter.Soa.Client.Model.ModelObject[] Objects, Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			ExpandPrimaryObjectsInput expandPrimaryObjectsInput = new ExpandPrimaryObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Objects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Objects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Objects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandPrimaryObjectsInput.setObjects(arrayList);
			expandPrimaryObjectsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "ExpandPrimaryObjects", expandPrimaryObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandPrimaryObjectsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandPrimaryObjectsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsResponse GenerateAlternateIds(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsProperties[] Input)
	{
		try
		{
			restSender.PushRequestId();
			GenerateAlternateIdsInput generateAlternateIdsInput = new GenerateAlternateIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			generateAlternateIdsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GenerateAlternateIds", generateAlternateIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.GenerateAlternateIdsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GenerateAlternateIdsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	[Obsolete("As of Teamcenter 9, use the getAllAttrMappings2 operation.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAllAttrMappingsResponse GetAllAttrMappings()
	{
		try
		{
			restSender.PushRequestId();
			GetAllAttrMappingsInput requestObject = new GetAllAttrMappingsInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAllAttrMappingsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GetAllAttrMappings", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAllAttrMappingsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAllAttrMappingsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAllAttrMappingsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeResponse GetAttrMappingsForDatasetType(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeCriteria[] Info)
	{
		try
		{
			restSender.PushRequestId();
			GetAttrMappingsForDatasetTypeInput getAttrMappingsForDatasetTypeInput = new GetAttrMappingsForDatasetTypeInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			getAttrMappingsForDatasetTypeInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GetAttrMappingsForDatasetType", getAttrMappingsForDatasetTypeInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAttrMappingsForDatasetTypeResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAttrMappingsForDatasetTypeResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	[Obsolete("As of tc2007, use the getAvailabelTypes operation from the Core DataManagement service.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAvailableTypesResponse GetAvailableTypes(string[] Classes)
	{
		try
		{
			restSender.PushRequestId();
			GetAvailableTypesInput getAvailableTypesInput = new GetAvailableTypesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Classes.Length; i++)
			{
				arrayList.Add(Classes[i]);
			}
			getAvailableTypesInput.setClasses(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAvailableTypesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GetAvailableTypes", getAvailableTypesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAvailableTypesResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.GetAvailableTypesResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.GetAvailableTypesResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetResponse ResolveAttrMappingsForDataset(Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			ResolveAttrMappingsForDatasetInput resolveAttrMappingsForDatasetInput = new ResolveAttrMappingsForDatasetInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			resolveAttrMappingsForDatasetInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "ResolveAttrMappingsForDataset", resolveAttrMappingsForDatasetInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.ResolveAttrMappingsForDatasetResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ResolveAttrMappingsForDatasetResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Cad._2007_12.Datamanagement.CreateOrUpdatePartsPref toWire(Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref local)
	{
		Teamcenter.Schemas.Cad._2007_12.Datamanagement.CreateOrUpdatePartsPref createOrUpdatePartsPref = new Teamcenter.Schemas.Cad._2007_12.Datamanagement.CreateOrUpdatePartsPref();
		createOrUpdatePartsPref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		return createOrUpdatePartsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref toLocal(Teamcenter.Schemas.Cad._2007_12.Datamanagement.CreateOrUpdatePartsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref createOrUpdatePartsPref = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref();
		createOrUpdatePartsPref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		return createOrUpdatePartsPref;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Datamanagement.DatasetInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.DataManagement.DatasetInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Datamanagement.DatasetInfo2 datasetInfo = new Teamcenter.Schemas.Cad._2007_12.Datamanagement.DatasetInfo2();
		datasetInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetInfo.setDataset(modelObject);
		datasetInfo.setName(local.Name);
		datasetInfo.setBasisName(local.BasisName);
		datasetInfo.setDescription(local.Description);
		datasetInfo.setType(local.Type);
		datasetInfo.setLastModifiedOfDataset(TcServerDate.ToWire(local.LastModifiedOfDataset));
		datasetInfo.setId(local.Id);
		datasetInfo.setDatasetRev(local.DatasetRev);
		datasetInfo.setItemRevRelationName(local.ItemRevRelationName);
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		datasetInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.MappingAttributes.Length; i++)
		{
			arrayList2.Add(toWire(local.MappingAttributes[i]));
		}
		datasetInfo.setMappingAttributes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraObject[i]));
		}
		datasetInfo.setExtraObject(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList4.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList5.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList5);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.DataManagement.DatasetInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Datamanagement.DatasetInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.DataManagement.DatasetInfo2 datasetInfo = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.DatasetInfo2();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetInfo.Name = wire.getName();
		datasetInfo.BasisName = wire.getBasisName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.LastModifiedOfDataset = TcServerDate.ToLocal(wire.getLastModifiedOfDataset());
		datasetInfo.Id = wire.getId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.ItemRevRelationName = wire.getItemRevRelationName();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList attrList = wire.getAttrList();
		datasetInfo.AttrList = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			datasetInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList mappingAttributes = wire.getMappingAttributes();
		datasetInfo.MappingAttributes = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[mappingAttributes.Count];
		for (int i = 0; i < mappingAttributes.Count; i++)
		{
			datasetInfo.MappingAttributes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)mappingAttributes[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		datasetInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			datasetInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.NamedReferenceObjectInfo2[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_12.Datamanagement.NamedReferenceObjectInfo2)namedReferenceObjectInfos[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Datamanagement.NamedReferenceObjectInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.DataManagement.NamedReferenceObjectInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Datamanagement.NamedReferenceObjectInfo2 namedReferenceObjectInfo = new Teamcenter.Schemas.Cad._2007_12.Datamanagement.NamedReferenceObjectInfo2();
		namedReferenceObjectInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		namedReferenceObjectInfo.setObject(modelObject);
		namedReferenceObjectInfo.setNamedReferenceName(local.NamedReferenceName);
		namedReferenceObjectInfo.setNamedReferenceType(local.NamedReferenceType);
		namedReferenceObjectInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrNameValuePairs.Length; i++)
		{
			arrayList.Add(toWire(local.AttrNameValuePairs[i]));
		}
		namedReferenceObjectInfo.setAttrNameValuePairs(arrayList);
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.DataManagement.NamedReferenceObjectInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Datamanagement.NamedReferenceObjectInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.DataManagement.NamedReferenceObjectInfo2 namedReferenceObjectInfo = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.NamedReferenceObjectInfo2();
		namedReferenceObjectInfo.ClientId = wire.getClientId();
		namedReferenceObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		namedReferenceObjectInfo.NamedReferenceName = wire.getNamedReferenceName();
		namedReferenceObjectInfo.NamedReferenceType = wire.getNamedReferenceType();
		namedReferenceObjectInfo.TypeName = wire.getTypeName();
		IList attrNameValuePairs = wire.getAttrNameValuePairs();
		namedReferenceObjectInfo.AttrNameValuePairs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrNameValuePairs.Count];
		for (int i = 0; i < attrNameValuePairs.Count; i++)
		{
			namedReferenceObjectInfo.AttrNameValuePairs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrNameValuePairs[i], modelManager);
		}
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Datamanagement.PartInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.DataManagement.PartInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Datamanagement.PartInfo2 partInfo = new Teamcenter.Schemas.Cad._2007_12.Datamanagement.PartInfo2();
		partInfo.setClientId(local.ClientId);
		partInfo.setItemInput(toWire(local.ItemInput));
		partInfo.setItemRevInput(toWire(local.ItemRevInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetInput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetInput[i]));
		}
		partInfo.setDatasetInput(arrayList);
		return partInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.DataManagement.PartInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Datamanagement.PartInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.DataManagement.PartInfo2 partInfo = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.PartInfo2();
		partInfo.ClientId = wire.getClientId();
		partInfo.ItemInput = toLocal(wire.getItemInput(), modelManager);
		partInfo.ItemRevInput = toLocal(wire.getItemRevInput(), modelManager);
		IList datasetInput = wire.getDatasetInput();
		partInfo.DatasetInput = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.DatasetInfo2[datasetInput.Count];
		for (int i = 0; i < datasetInput.Count; i++)
		{
			partInfo.DatasetInput[i] = toLocal((Teamcenter.Schemas.Cad._2007_12.Datamanagement.DatasetInfo2)datasetInput[i], modelManager);
		}
		return partInfo;
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2007_12.DataManagement.PartInfo2[] Info, Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_12.Datamanagement.CreateOrUpdatePartsInput createOrUpdatePartsInput = new Teamcenter.Schemas.Cad._2007_12.Datamanagement.CreateOrUpdatePartsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdatePartsInput.setInfo(arrayList);
			createOrUpdatePartsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200712_PORT_NAME, "CreateOrUpdateParts", createOrUpdatePartsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Cad._2008_03.Datamanagement.CadAttrMappingDefinitionInfo toWire(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.CadAttrMappingDefinitionInfo local)
	{
		Teamcenter.Schemas.Cad._2008_03.Datamanagement.CadAttrMappingDefinitionInfo cadAttrMappingDefinitionInfo = new Teamcenter.Schemas.Cad._2008_03.Datamanagement.CadAttrMappingDefinitionInfo();
		cadAttrMappingDefinitionInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.CadAttrMappingDefinition == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.CadAttrMappingDefinition.Uid);
		}
		cadAttrMappingDefinitionInfo.setCadAttrMappingDefinition(modelObject);
		return cadAttrMappingDefinitionInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.DataManagement.CadAttrMappingDefinitionInfo toLocal(Teamcenter.Schemas.Cad._2008_03.Datamanagement.CadAttrMappingDefinitionInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.DataManagement.CadAttrMappingDefinitionInfo cadAttrMappingDefinitionInfo = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.CadAttrMappingDefinitionInfo();
		cadAttrMappingDefinitionInfo.ClientId = wire.getClientId();
		cadAttrMappingDefinitionInfo.CadAttrMappingDefinition = (CadAttrMappingDefinition)modelManager.LoadObjectData(wire.getCadAttrMappingDefinition());
		return cadAttrMappingDefinitionInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_03.Datamanagement.DatasetInfo3 toWire(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.DatasetInfo3 local)
	{
		Teamcenter.Schemas.Cad._2008_03.Datamanagement.DatasetInfo3 datasetInfo = new Teamcenter.Schemas.Cad._2008_03.Datamanagement.DatasetInfo3();
		datasetInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetInfo.setDataset(modelObject);
		datasetInfo.setName(local.Name);
		datasetInfo.setBasisName(local.BasisName);
		datasetInfo.setDescription(local.Description);
		datasetInfo.setType(local.Type);
		datasetInfo.setLastModifiedOfDataset(TcServerDate.ToWire(local.LastModifiedOfDataset));
		datasetInfo.setId(local.Id);
		datasetInfo.setDatasetRev(local.DatasetRev);
		datasetInfo.setItemRevRelationName(local.ItemRevRelationName);
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setMapAttributesWithoutDataset(local.MapAttributesWithoutDataset);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		datasetInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.MappingAttributes.Length; i++)
		{
			arrayList2.Add(toWire(local.MappingAttributes[i]));
		}
		datasetInfo.setMappingAttributes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraObject[i]));
		}
		datasetInfo.setExtraObject(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList4.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList5.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList5);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.DataManagement.DatasetInfo3 toLocal(Teamcenter.Schemas.Cad._2008_03.Datamanagement.DatasetInfo3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.DataManagement.DatasetInfo3 datasetInfo = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.DatasetInfo3();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetInfo.Name = wire.getName();
		datasetInfo.BasisName = wire.getBasisName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.LastModifiedOfDataset = TcServerDate.ToLocal(wire.getLastModifiedOfDataset());
		datasetInfo.Id = wire.getId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.ItemRevRelationName = wire.getItemRevRelationName();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.MapAttributesWithoutDataset = wire.MapAttributesWithoutDataset;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList attrList = wire.getAttrList();
		datasetInfo.AttrList = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			datasetInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList mappingAttributes = wire.getMappingAttributes();
		datasetInfo.MappingAttributes = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.AttributeInfo[mappingAttributes.Count];
		for (int i = 0; i < mappingAttributes.Count; i++)
		{
			datasetInfo.MappingAttributes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.AttributeInfo)mappingAttributes[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		datasetInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			datasetInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2007_12.DataManagement.NamedReferenceObjectInfo2[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_12.Datamanagement.NamedReferenceObjectInfo2)namedReferenceObjectInfos[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_03.Datamanagement.MappedDatasetAttrPropertyInfo toWire(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.MappedDatasetAttrPropertyInfo local)
	{
		Teamcenter.Schemas.Cad._2008_03.Datamanagement.MappedDatasetAttrPropertyInfo mappedDatasetAttrPropertyInfo = new Teamcenter.Schemas.Cad._2008_03.Datamanagement.MappedDatasetAttrPropertyInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.CadAttrMappingDefinition == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.CadAttrMappingDefinition.Uid);
		}
		mappedDatasetAttrPropertyInfo.setCadAttrMappingDefinition(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ResolvedObject == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ResolvedObject.Uid);
		}
		mappedDatasetAttrPropertyInfo.setResolvedObject(modelObject2);
		mappedDatasetAttrPropertyInfo.setResolvedPropertyName(local.ResolvedPropertyName);
		return mappedDatasetAttrPropertyInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.DataManagement.MappedDatasetAttrPropertyInfo toLocal(Teamcenter.Schemas.Cad._2008_03.Datamanagement.MappedDatasetAttrPropertyInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.DataManagement.MappedDatasetAttrPropertyInfo mappedDatasetAttrPropertyInfo = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.MappedDatasetAttrPropertyInfo();
		mappedDatasetAttrPropertyInfo.CadAttrMappingDefinition = (CadAttrMappingDefinition)modelManager.LoadObjectData(wire.getCadAttrMappingDefinition());
		mappedDatasetAttrPropertyInfo.ResolvedObject = modelManager.LoadObjectData(wire.getResolvedObject());
		mappedDatasetAttrPropertyInfo.ResolvedPropertyName = wire.getResolvedPropertyName();
		return mappedDatasetAttrPropertyInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_03.Datamanagement.PartInfo3 toWire(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.PartInfo3 local)
	{
		Teamcenter.Schemas.Cad._2008_03.Datamanagement.PartInfo3 partInfo = new Teamcenter.Schemas.Cad._2008_03.Datamanagement.PartInfo3();
		partInfo.setClientId(local.ClientId);
		partInfo.setItemInput(toWire(local.ItemInput));
		partInfo.setItemRevInput(toWire(local.ItemRevInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetInput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetInput[i]));
		}
		partInfo.setDatasetInput(arrayList);
		return partInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.DataManagement.PartInfo3 toLocal(Teamcenter.Schemas.Cad._2008_03.Datamanagement.PartInfo3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.DataManagement.PartInfo3 partInfo = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.PartInfo3();
		partInfo.ClientId = wire.getClientId();
		partInfo.ItemInput = toLocal(wire.getItemInput(), modelManager);
		partInfo.ItemRevInput = toLocal(wire.getItemRevInput(), modelManager);
		IList datasetInput = wire.getDatasetInput();
		partInfo.DatasetInput = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.DatasetInfo3[datasetInput.Count];
		for (int i = 0; i < datasetInput.Count; i++)
		{
			partInfo.DatasetInput[i] = toLocal((Teamcenter.Schemas.Cad._2008_03.Datamanagement.DatasetInfo3)datasetInput[i], modelManager);
		}
		return partInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsInfo toWire(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsInfo local)
	{
		Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsInfo resolveAttrMappingsInfo = new Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		resolveAttrMappingsInfo.setDataset(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		resolveAttrMappingsInfo.setItemRev(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.MappingDefinitionInfos.Length; i++)
		{
			arrayList.Add(toWire(local.MappingDefinitionInfos[i]));
		}
		resolveAttrMappingsInfo.setMappingDefinitionInfos(arrayList);
		return resolveAttrMappingsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsInfo toLocal(Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsInfo resolveAttrMappingsInfo = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsInfo();
		resolveAttrMappingsInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		resolveAttrMappingsInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList mappingDefinitionInfos = wire.getMappingDefinitionInfos();
		resolveAttrMappingsInfo.MappingDefinitionInfos = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.CadAttrMappingDefinitionInfo[mappingDefinitionInfos.Count];
		for (int i = 0; i < mappingDefinitionInfos.Count; i++)
		{
			resolveAttrMappingsInfo.MappingDefinitionInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_03.Datamanagement.CadAttrMappingDefinitionInfo)mappingDefinitionInfos[i], modelManager);
		}
		return resolveAttrMappingsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsResponse toLocal(Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsResponse resolveAttrMappingsResponse = new Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsResponse();
		resolveAttrMappingsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		resolveAttrMappingsResponse.ResolvedMappingsMap = toLocalResolveAttrMappingsOutputMap(wire.getResolvedMappingsMap(), modelManager);
		return resolveAttrMappingsResponse;
	}

	public static ArrayList toWireResolveAttrMappingsOutputMap(IDictionary ResolveAttrMappingsOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ResolveAttrMappingsOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			ResolveAttrMappingsOutputMap resolveAttrMappingsOutputMap = new ResolveAttrMappingsOutputMap();
			resolveAttrMappingsOutputMap.setKey(Convert.ToString(key));
			resolveAttrMappingsOutputMap.setValue(toWire((Teamcenter.Services.Strong.Cad._2008_03.DataManagement.MappedDatasetAttrPropertyInfo)value));
			arrayList.Add(resolveAttrMappingsOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalResolveAttrMappingsOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ResolveAttrMappingsOutputMap resolveAttrMappingsOutputMap = (ResolveAttrMappingsOutputMap)wire[i];
			string key = resolveAttrMappingsOutputMap.getKey();
			Teamcenter.Services.Strong.Cad._2008_03.DataManagement.MappedDatasetAttrPropertyInfo value = toLocal(resolveAttrMappingsOutputMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.PartInfo3[] Info, Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_03.Datamanagement.CreateOrUpdatePartsInput createOrUpdatePartsInput = new Teamcenter.Schemas.Cad._2008_03.Datamanagement.CreateOrUpdatePartsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdatePartsInput.setInfo(arrayList);
			createOrUpdatePartsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200803_PORT_NAME, "CreateOrUpdateParts", createOrUpdatePartsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Datamanagement.CreateOrUpdatePartsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.DataManagement.CreateOrUpdatePartsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsResponse ResolveAttrMappings(Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			ResolveAttrMappingsInput resolveAttrMappingsInput = new ResolveAttrMappingsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			resolveAttrMappingsInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200803_PORT_NAME, "ResolveAttrMappings", resolveAttrMappingsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsResponse wire = (Teamcenter.Schemas.Cad._2008_03.Datamanagement.ResolveAttrMappingsResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_03.DataManagement.ResolveAttrMappingsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo attributeInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo();
		attributeInfo.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		attributeInfo.setValues(arrayList);
		return attributeInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo attributeInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo();
		attributeInfo.Name = wire.getName();
		IList values = wire.getValues();
		attributeInfo.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			attributeInfo.Values[i] = Convert.ToString(values[i]);
		}
		return attributeInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.BoundingBox toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.BoundingBox local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.BoundingBox boundingBox = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.BoundingBox();
		boundingBox.setXmin(local.Xmin);
		boundingBox.setYmin(local.Ymin);
		boundingBox.setZmin(local.Zmin);
		boundingBox.setXmax(local.Xmax);
		boundingBox.setYmax(local.Ymax);
		boundingBox.setZmax(local.Zmax);
		return boundingBox;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.BoundingBox toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.BoundingBox wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.BoundingBox boundingBox = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.BoundingBox();
		boundingBox.Xmin = Convert.ToDouble(wire.getXmin());
		boundingBox.Ymin = Convert.ToDouble(wire.getYmin());
		boundingBox.Zmin = Convert.ToDouble(wire.getZmin());
		boundingBox.Xmax = Convert.ToDouble(wire.getXmax());
		boundingBox.Ymax = Convert.ToDouble(wire.getYmax());
		boundingBox.Zmax = Convert.ToDouble(wire.getZmax());
		return boundingBox;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.CommitDatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CommitDatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.CommitDatasetFileInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		commitDatasetFileInfo.setDataset(modelObject);
		commitDatasetFileInfo.setCreateNewVersion(local.CreateNewVersion);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetFileTicketInfos.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetFileTicketInfos[i]));
		}
		commitDatasetFileInfo.setDatasetFileTicketInfos(arrayList);
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CommitDatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.CommitDatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CommitDatasetFileInfo();
		commitDatasetFileInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		commitDatasetFileInfo.CreateNewVersion = wire.CreateNewVersion;
		IList datasetFileTicketInfos = wire.getDatasetFileTicketInfos();
		commitDatasetFileInfo.DatasetFileTicketInfos = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileTicketInfo[datasetFileTicketInfos.Count];
		for (int i = 0; i < datasetFileTicketInfos.Count; i++)
		{
			commitDatasetFileInfo.DatasetFileTicketInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileTicketInfo)datasetFileTicketInfos[i], modelManager);
		}
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsOutput createOrUpdatePartsOutput = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsOutput();
		createOrUpdatePartsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		createOrUpdatePartsOutput.setItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		createOrUpdatePartsOutput.setItemRev(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetOutput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetOutput[i]));
		}
		createOrUpdatePartsOutput.setDatasetOutput(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraItemObjs.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraItemObjs[i]));
		}
		createOrUpdatePartsOutput.setExtraItemObjs(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraItemRevObjs.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraItemRevObjs[i]));
		}
		createOrUpdatePartsOutput.setExtraItemRevObjs(arrayList3);
		return createOrUpdatePartsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsOutput createOrUpdatePartsOutput = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsOutput();
		createOrUpdatePartsOutput.ClientId = wire.getClientId();
		createOrUpdatePartsOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		createOrUpdatePartsOutput.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList datasetOutput = wire.getDatasetOutput();
		createOrUpdatePartsOutput.DatasetOutput = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetOutput[datasetOutput.Count];
		for (int i = 0; i < datasetOutput.Count; i++)
		{
			createOrUpdatePartsOutput.DatasetOutput[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetOutput)datasetOutput[i], modelManager);
		}
		IList extraItemObjs = wire.getExtraItemObjs();
		createOrUpdatePartsOutput.ExtraItemObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[extraItemObjs.Count];
		for (int i = 0; i < extraItemObjs.Count; i++)
		{
			createOrUpdatePartsOutput.ExtraItemObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)extraItemObjs[i], modelManager);
		}
		IList extraItemRevObjs = wire.getExtraItemRevObjs();
		createOrUpdatePartsOutput.ExtraItemRevObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[extraItemRevObjs.Count];
		for (int i = 0; i < extraItemRevObjs.Count; i++)
		{
			createOrUpdatePartsOutput.ExtraItemRevObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)extraItemRevObjs[i], modelManager);
		}
		return createOrUpdatePartsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse createOrUpdatePartsResponse = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse();
		createOrUpdatePartsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createOrUpdatePartsResponse.Output = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createOrUpdatePartsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsOutput)output[i], modelManager);
		}
		return createOrUpdatePartsResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileInfo();
		datasetFileInfo.setClientId(local.ClientId);
		datasetFileInfo.setFileName(local.FileName);
		datasetFileInfo.setNamedReferencedName(local.NamedReferencedName);
		datasetFileInfo.setIsText(local.IsText);
		datasetFileInfo.setAllowReplace(local.AllowReplace);
		datasetFileInfo.setBoundingBoxesAvailable(local.BoundingBoxesAvailable);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BoundingBoxes.Length; i++)
		{
			arrayList.Add(toWire(local.BoundingBoxes[i]));
		}
		datasetFileInfo.setBoundingBoxes(arrayList);
		return datasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileInfo();
		datasetFileInfo.ClientId = wire.getClientId();
		datasetFileInfo.FileName = wire.getFileName();
		datasetFileInfo.NamedReferencedName = wire.getNamedReferencedName();
		datasetFileInfo.IsText = wire.IsText;
		datasetFileInfo.AllowReplace = wire.AllowReplace;
		datasetFileInfo.BoundingBoxesAvailable = wire.BoundingBoxesAvailable;
		IList boundingBoxes = wire.getBoundingBoxes();
		datasetFileInfo.BoundingBoxes = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.BoundingBox[boundingBoxes.Count];
		for (int i = 0; i < boundingBoxes.Count; i++)
		{
			datasetFileInfo.BoundingBoxes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.BoundingBox)boundingBoxes[i], modelManager);
		}
		return datasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileTicketInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileTicketInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.setDatasetFileInfo(toWire(local.DatasetFileInfo));
		datasetFileTicketInfo.setTicket(local.Ticket);
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileTicketInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileTicketInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.DatasetFileInfo = toLocal(wire.getDatasetFileInfo(), modelManager);
		datasetFileTicketInfo.Ticket = wire.getTicket();
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetInfo();
		datasetInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetInfo.setDataset(modelObject);
		datasetInfo.setName(local.Name);
		datasetInfo.setBasisName(local.BasisName);
		datasetInfo.setDescription(local.Description);
		datasetInfo.setType(local.Type);
		datasetInfo.setLastModifiedOfDataset(TcServerDate.ToWire(local.LastModifiedOfDataset));
		datasetInfo.setId(local.Id);
		datasetInfo.setDatasetRev(local.DatasetRev);
		datasetInfo.setItemRevRelationName(local.ItemRevRelationName);
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setMapAttributesWithoutDataset(local.MapAttributesWithoutDataset);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		datasetInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.MappingAttributes.Length; i++)
		{
			arrayList2.Add(toWire(local.MappingAttributes[i]));
		}
		datasetInfo.setMappingAttributes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraObject[i]));
		}
		datasetInfo.setExtraObject(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList4.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList5.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList5);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetInfo.Name = wire.getName();
		datasetInfo.BasisName = wire.getBasisName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.LastModifiedOfDataset = TcServerDate.ToLocal(wire.getLastModifiedOfDataset());
		datasetInfo.Id = wire.getId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.ItemRevRelationName = wire.getItemRevRelationName();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.MapAttributesWithoutDataset = wire.MapAttributesWithoutDataset;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList attrList = wire.getAttrList();
		datasetInfo.AttrList = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			datasetInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList mappingAttributes = wire.getMappingAttributes();
		datasetInfo.MappingAttributes = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[mappingAttributes.Count];
		for (int i = 0; i < mappingAttributes.Count; i++)
		{
			datasetInfo.MappingAttributes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)mappingAttributes[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		datasetInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			datasetInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.NamedReferenceObjectInfo[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.NamedReferenceObjectInfo)namedReferenceObjectInfos[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetOutput datasetOutput = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetOutput();
		datasetOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetOutput.setDataset(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.CommitInfo.Length; i++)
		{
			arrayList.Add(toWire(local.CommitInfo[i]));
		}
		datasetOutput.setCommitInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObjs.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObjs[i]));
		}
		datasetOutput.setExtraObjs(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.NamedRefObjs.Length; i++)
		{
			arrayList3.Add(toWire(local.NamedRefObjs[i]));
		}
		datasetOutput.setNamedRefObjs(arrayList3);
		return datasetOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetOutput datasetOutput = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetOutput();
		datasetOutput.ClientId = wire.getClientId();
		datasetOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList commitInfo = wire.getCommitInfo();
		datasetOutput.CommitInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CommitDatasetFileInfo[commitInfo.Count];
		for (int i = 0; i < commitInfo.Count; i++)
		{
			datasetOutput.CommitInfo[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.CommitDatasetFileInfo)commitInfo[i], modelManager);
		}
		IList extraObjs = wire.getExtraObjs();
		datasetOutput.ExtraObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[extraObjs.Count];
		for (int i = 0; i < extraObjs.Count; i++)
		{
			datasetOutput.ExtraObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)extraObjs[i], modelManager);
		}
		IList namedRefObjs = wire.getNamedRefObjs();
		datasetOutput.NamedRefObjs = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExtraObjectOutput[namedRefObjs.Count];
		for (int i = 0; i < namedRefObjs.Count; i++)
		{
			datasetOutput.NamedRefObjs[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExtraObjectOutput)namedRefObjs[i], modelManager);
		}
		return datasetOutput;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFolderForCADPref2 toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFolderForCADPref2 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFolderForCADPref2 expandFolderForCADPref = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFolderForCADPref2();
		expandFolderForCADPref.setExpItemRev(local.ExpItemRev);
		expandFolderForCADPref.setLatestNRevs(local.LatestNRevs);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandFolderForCADPref.setInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ContentTypesFilter.Length; i++)
		{
			arrayList2.Add(local.ContentTypesFilter[i]);
		}
		expandFolderForCADPref.setContentTypesFilter(arrayList2);
		return expandFolderForCADPref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFolderForCADPref2 toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFolderForCADPref2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFolderForCADPref2 expandFolderForCADPref = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFolderForCADPref2();
		expandFolderForCADPref.ExpItemRev = wire.ExpItemRev;
		expandFolderForCADPref.LatestNRevs = wire.getLatestNRevs();
		IList info = wire.getInfo();
		expandFolderForCADPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.RelationAndTypesFilter2[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandFolderForCADPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.RelationAndTypesFilter2)info[i], modelManager);
		}
		IList contentTypesFilter = wire.getContentTypesFilter();
		expandFolderForCADPref.ContentTypesFilter = new string[contentTypesFilter.Count];
		for (int i = 0; i < contentTypesFilter.Count; i++)
		{
			expandFolderForCADPref.ContentTypesFilter[i] = Convert.ToString(contentTypesFilter[i]);
		}
		return expandFolderForCADPref;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADOutput2 toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADOutput2 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADOutput2 expandFoldersForCADOutput = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADOutput2();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputFolder == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputFolder.Uid);
		}
		expandFoldersForCADOutput.setInputFolder(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.FstlvlFolders.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.FstlvlFolders[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.FstlvlFolders[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		expandFoldersForCADOutput.setFstlvlFolders(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ItemsOutput.Length; i++)
		{
			arrayList2.Add(toWire(local.ItemsOutput[i]));
		}
		expandFoldersForCADOutput.setItemsOutput(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ItemRevsOutput.Length; i++)
		{
			arrayList3.Add(toWire(local.ItemRevsOutput[i]));
		}
		expandFoldersForCADOutput.setItemRevsOutput(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.Contents.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Contents[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.Contents[i].Uid);
			}
			arrayList4.Add(modelObject3);
		}
		expandFoldersForCADOutput.setContents(arrayList4);
		return expandFoldersForCADOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADOutput2 toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADOutput2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADOutput2 expandFoldersForCADOutput = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADOutput2();
		expandFoldersForCADOutput.InputFolder = (Folder)modelManager.LoadObjectData(wire.getInputFolder());
		IList fstlvlFolders = wire.getFstlvlFolders();
		expandFoldersForCADOutput.FstlvlFolders = new Folder[fstlvlFolders.Count];
		for (int i = 0; i < fstlvlFolders.Count; i++)
		{
			expandFoldersForCADOutput.FstlvlFolders[i] = (Folder)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)fstlvlFolders[i]);
		}
		IList itemsOutput = wire.getItemsOutput();
		expandFoldersForCADOutput.ItemsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemOutput[itemsOutput.Count];
		for (int i = 0; i < itemsOutput.Count; i++)
		{
			expandFoldersForCADOutput.ItemsOutput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemOutput)itemsOutput[i], modelManager);
		}
		IList itemRevsOutput = wire.getItemRevsOutput();
		expandFoldersForCADOutput.ItemRevsOutput = new Teamcenter.Services.Strong.Cad._2007_01.DataManagement.ExpandFoldersForCADItemRevOutput[itemRevsOutput.Count];
		for (int i = 0; i < itemRevsOutput.Count; i++)
		{
			expandFoldersForCADOutput.ItemRevsOutput[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Datamanagement.ExpandFoldersForCADItemRevOutput)itemRevsOutput[i], modelManager);
		}
		IList contents = wire.getContents();
		expandFoldersForCADOutput.Contents = new WorkspaceObject[contents.Count];
		for (int i = 0; i < contents.Count; i++)
		{
			expandFoldersForCADOutput.Contents[i] = (WorkspaceObject)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)contents[i]);
		}
		return expandFoldersForCADOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADResponse2 toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADResponse2 expandFoldersForCADResponse = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADResponse2();
		expandFoldersForCADResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandFoldersForCADResponse.Output = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADOutput2[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandFoldersForCADResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADOutput2)output[i], modelManager);
		}
		return expandFoldersForCADResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo extraObjectInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		extraObjectInfo.setObject(modelObject);
		extraObjectInfo.setClientId(local.ClientId);
		extraObjectInfo.setRelationTypeName(local.RelationTypeName);
		extraObjectInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrNameValuePairs.Length; i++)
		{
			arrayList.Add(toWire(local.AttrNameValuePairs[i]));
		}
		extraObjectInfo.setAttrNameValuePairs(arrayList);
		return extraObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo extraObjectInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo();
		extraObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		extraObjectInfo.ClientId = wire.getClientId();
		extraObjectInfo.RelationTypeName = wire.getRelationTypeName();
		extraObjectInfo.TypeName = wire.getTypeName();
		IList attrNameValuePairs = wire.getAttrNameValuePairs();
		extraObjectInfo.AttrNameValuePairs = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[attrNameValuePairs.Count];
		for (int i = 0; i < attrNameValuePairs.Count; i++)
		{
			extraObjectInfo.AttrNameValuePairs[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)attrNameValuePairs[i], modelManager);
		}
		return extraObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemInfo itemInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		itemInfo.setItem(modelObject);
		itemInfo.setItemId(local.ItemId);
		itemInfo.setItemType(local.ItemType);
		itemInfo.setName(local.Name);
		itemInfo.setDescription(local.Description);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		itemInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObject[i]));
		}
		itemInfo.setExtraObject(arrayList2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Folder.Uid);
		}
		itemInfo.setFolder(modelObject2);
		return itemInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemInfo itemInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemInfo();
		itemInfo.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		itemInfo.ItemId = wire.getItemId();
		itemInfo.ItemType = wire.getItemType();
		itemInfo.Name = wire.getName();
		itemInfo.Description = wire.getDescription();
		IList attrList = wire.getAttrList();
		itemInfo.AttrList = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			itemInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		itemInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			itemInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		itemInfo.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		return itemInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemRevInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemRevInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemRevInfo itemRevInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemRevInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		itemRevInfo.setItemRevision(modelObject);
		itemRevInfo.setRevId(local.RevId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		itemRevInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObject[i]));
		}
		itemRevInfo.setExtraObject(arrayList2);
		return itemRevInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemRevInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ItemRevInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemRevInfo itemRevInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ItemRevInfo();
		itemRevInfo.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		itemRevInfo.RevId = wire.getRevId();
		IList attrList = wire.getAttrList();
		itemRevInfo.AttrList = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			itemRevInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		itemRevInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			itemRevInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		return itemRevInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.NamedReferenceObjectInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.NamedReferenceObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		namedReferenceObjectInfo.setObject(modelObject);
		namedReferenceObjectInfo.setNamedReferenceName(local.NamedReferenceName);
		namedReferenceObjectInfo.setNamedReferenceType(local.NamedReferenceType);
		namedReferenceObjectInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrNameValuePairs.Length; i++)
		{
			arrayList.Add(toWire(local.AttrNameValuePairs[i]));
		}
		namedReferenceObjectInfo.setAttrNameValuePairs(arrayList);
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.NamedReferenceObjectInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.NamedReferenceObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.ClientId = wire.getClientId();
		namedReferenceObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		namedReferenceObjectInfo.NamedReferenceName = wire.getNamedReferenceName();
		namedReferenceObjectInfo.NamedReferenceType = wire.getNamedReferenceType();
		namedReferenceObjectInfo.TypeName = wire.getTypeName();
		IList attrNameValuePairs = wire.getAttrNameValuePairs();
		namedReferenceObjectInfo.AttrNameValuePairs = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[attrNameValuePairs.Count];
		for (int i = 0; i < attrNameValuePairs.Count; i++)
		{
			namedReferenceObjectInfo.AttrNameValuePairs[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)attrNameValuePairs[i], modelManager);
		}
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Datamanagement.PartInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.PartInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Datamanagement.PartInfo partInfo = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.PartInfo();
		partInfo.setClientId(local.ClientId);
		partInfo.setItemInput(toWire(local.ItemInput));
		partInfo.setItemRevInput(toWire(local.ItemRevInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetInput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetInput[i]));
		}
		partInfo.setDatasetInput(arrayList);
		return partInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.DataManagement.PartInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Datamanagement.PartInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.DataManagement.PartInfo partInfo = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.PartInfo();
		partInfo.ClientId = wire.getClientId();
		partInfo.ItemInput = toLocal(wire.getItemInput(), modelManager);
		partInfo.ItemRevInput = toLocal(wire.getItemRevInput(), modelManager);
		IList datasetInput = wire.getDatasetInput();
		partInfo.DatasetInput = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.DatasetInfo[datasetInput.Count];
		for (int i = 0; i < datasetInput.Count; i++)
		{
			partInfo.DatasetInput[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.DatasetInfo)datasetInput[i], modelManager);
		}
		return partInfo;
	}

	public override Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2008_06.DataManagement.PartInfo[] PartInput, Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsInput createOrUpdatePartsInput = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PartInput.Length; i++)
			{
				arrayList.Add(toWire(PartInput[i]));
			}
			createOrUpdatePartsInput.setPartInput(arrayList);
			createOrUpdatePartsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateOrUpdateParts", createOrUpdatePartsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse wire = (Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADResponse2 ExpandFoldersForCAD(Folder[] Folders, Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFolderForCADPref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADInput expandFoldersForCADInput = new Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Folders.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Folders[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Folders[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandFoldersForCADInput.setFolders(arrayList);
			expandFoldersForCADInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "ExpandFoldersForCAD", expandFoldersForCADInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADResponse2 wire = (Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExpandFoldersForCADResponse2)obj;
			Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExpandFoldersForCADResponse2 result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetFileInfo();
		datasetFileInfo.setClientId(local.ClientId);
		datasetFileInfo.setFileName(local.FileName);
		datasetFileInfo.setNamedReferencedName(local.NamedReferencedName);
		datasetFileInfo.setIsText(local.IsText);
		datasetFileInfo.setAllowReplace(local.AllowReplace);
		datasetFileInfo.setBoundingBoxesAvailable(local.BoundingBoxesAvailable);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.DestinationVolume == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.DestinationVolume.Uid);
		}
		datasetFileInfo.setDestinationVolume(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BoundingBoxes.Length; i++)
		{
			arrayList.Add(toWire(local.BoundingBoxes[i]));
		}
		datasetFileInfo.setBoundingBoxes(arrayList);
		return datasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetFileInfo();
		datasetFileInfo.ClientId = wire.getClientId();
		datasetFileInfo.FileName = wire.getFileName();
		datasetFileInfo.NamedReferencedName = wire.getNamedReferencedName();
		datasetFileInfo.IsText = wire.IsText;
		datasetFileInfo.AllowReplace = wire.AllowReplace;
		datasetFileInfo.BoundingBoxesAvailable = wire.BoundingBoxesAvailable;
		datasetFileInfo.DestinationVolume = (ImanVolume)modelManager.LoadObjectData(wire.getDestinationVolume());
		IList boundingBoxes = wire.getBoundingBoxes();
		datasetFileInfo.BoundingBoxes = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.BoundingBox[boundingBoxes.Count];
		for (int i = 0; i < boundingBoxes.Count; i++)
		{
			datasetFileInfo.BoundingBoxes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.BoundingBox)boundingBoxes[i], modelManager);
		}
		return datasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetInfo();
		datasetInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		datasetInfo.setDataset(modelObject);
		datasetInfo.setName(local.Name);
		datasetInfo.setBasisName(local.BasisName);
		datasetInfo.setDescription(local.Description);
		datasetInfo.setType(local.Type);
		datasetInfo.setLastModifiedOfDataset(TcServerDate.ToWire(local.LastModifiedOfDataset));
		datasetInfo.setId(local.Id);
		datasetInfo.setDatasetRev(local.DatasetRev);
		datasetInfo.setItemRevRelationName(local.ItemRevRelationName);
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setMapAttributesWithoutDataset(local.MapAttributesWithoutDataset);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrList.Length; i++)
		{
			arrayList.Add(toWire(local.AttrList[i]));
		}
		datasetInfo.setAttrList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.MappingAttributes.Length; i++)
		{
			arrayList2.Add(toWire(local.MappingAttributes[i]));
		}
		datasetInfo.setMappingAttributes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList3.Add(toWire(local.ExtraObject[i]));
		}
		datasetInfo.setExtraObject(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList4.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList5.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList5);
		datasetInfo.setDatasetTool(local.DatasetTool);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetInfo toLocal(Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetInfo.Name = wire.getName();
		datasetInfo.BasisName = wire.getBasisName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.LastModifiedOfDataset = TcServerDate.ToLocal(wire.getLastModifiedOfDataset());
		datasetInfo.Id = wire.getId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.ItemRevRelationName = wire.getItemRevRelationName();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.MapAttributesWithoutDataset = wire.MapAttributesWithoutDataset;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList attrList = wire.getAttrList();
		datasetInfo.AttrList = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[attrList.Count];
		for (int i = 0; i < attrList.Count; i++)
		{
			datasetInfo.AttrList[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)attrList[i], modelManager);
		}
		IList mappingAttributes = wire.getMappingAttributes();
		datasetInfo.MappingAttributes = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[mappingAttributes.Count];
		for (int i = 0; i < mappingAttributes.Count; i++)
		{
			datasetInfo.MappingAttributes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)mappingAttributes[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		datasetInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			datasetInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.NamedReferenceObjectInfo[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.NamedReferenceObjectInfo)namedReferenceObjectInfos[i], modelManager);
		}
		datasetInfo.DatasetTool = wire.getDatasetTool();
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2010_09.Datamanagement.PartInfo toWire(Teamcenter.Services.Strong.Cad._2010_09.DataManagement.PartInfo local)
	{
		Teamcenter.Schemas.Cad._2010_09.Datamanagement.PartInfo partInfo = new Teamcenter.Schemas.Cad._2010_09.Datamanagement.PartInfo();
		partInfo.setClientId(local.ClientId);
		partInfo.setItemInput(toWire(local.ItemInput));
		partInfo.setItemRevInput(toWire(local.ItemRevInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetInput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetInput[i]));
		}
		partInfo.setDatasetInput(arrayList);
		return partInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2010_09.DataManagement.PartInfo toLocal(Teamcenter.Schemas.Cad._2010_09.Datamanagement.PartInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2010_09.DataManagement.PartInfo partInfo = new Teamcenter.Services.Strong.Cad._2010_09.DataManagement.PartInfo();
		partInfo.ClientId = wire.getClientId();
		partInfo.ItemInput = toLocal(wire.getItemInput(), modelManager);
		partInfo.ItemRevInput = toLocal(wire.getItemRevInput(), modelManager);
		IList datasetInput = wire.getDatasetInput();
		partInfo.DatasetInput = new Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetInfo[datasetInput.Count];
		for (int i = 0; i < datasetInput.Count; i++)
		{
			partInfo.DatasetInput[i] = toLocal((Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetInfo)datasetInput[i], modelManager);
		}
		return partInfo;
	}

	public override Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2010_09.DataManagement.PartInfo[] PartInput, Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2010_09.Datamanagement.CreateOrUpdatePartsInput createOrUpdatePartsInput = new Teamcenter.Schemas.Cad._2010_09.Datamanagement.CreateOrUpdatePartsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PartInput.Length; i++)
			{
				arrayList.Add(toWire(PartInput[i]));
			}
			createOrUpdatePartsInput.setPartInput(arrayList);
			createOrUpdatePartsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "CreateOrUpdateParts", createOrUpdatePartsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse wire = (Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Cad._2011_06.Datamanagement.PropDescriptor toWire(Teamcenter.Services.Strong.Cad._2011_06.DataManagement.PropDescriptor local)
	{
		Teamcenter.Schemas.Cad._2011_06.Datamanagement.PropDescriptor propDescriptor = new Teamcenter.Schemas.Cad._2011_06.Datamanagement.PropDescriptor();
		propDescriptor.setPropName(local.PropName);
		propDescriptor.setDisplayName(local.DisplayName);
		propDescriptor.setDefaultValue(local.DefaultValue);
		propDescriptor.setPropValueType(local.PropValueType);
		propDescriptor.setPropType(local.PropType);
		propDescriptor.setIsDisplayable(local.IsDisplayable);
		propDescriptor.setIsArray(local.IsArray);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		propDescriptor.setLov(modelObject);
		propDescriptor.setIsRequired(local.IsRequired);
		propDescriptor.setIsEnabled(local.IsEnabled);
		propDescriptor.setIsModifiable(local.IsModifiable);
		propDescriptor.setAttachedSpecifier(local.AttachedSpecifier);
		propDescriptor.setMaxLength(local.MaxLength);
		propDescriptor.setLovAttachmentsCategory(local.LovAttachmentsCategory);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.InterdependentProps.Length; i++)
		{
			arrayList.Add(local.InterdependentProps[i]);
		}
		propDescriptor.setInterdependentProps(arrayList);
		return propDescriptor;
	}

	public static Teamcenter.Services.Strong.Cad._2011_06.DataManagement.PropDescriptor toLocal(Teamcenter.Schemas.Cad._2011_06.Datamanagement.PropDescriptor wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2011_06.DataManagement.PropDescriptor propDescriptor = new Teamcenter.Services.Strong.Cad._2011_06.DataManagement.PropDescriptor();
		propDescriptor.PropName = wire.getPropName();
		propDescriptor.DisplayName = wire.getDisplayName();
		propDescriptor.DefaultValue = wire.getDefaultValue();
		propDescriptor.PropValueType = wire.getPropValueType();
		propDescriptor.PropType = wire.getPropType();
		propDescriptor.IsDisplayable = wire.IsDisplayable;
		propDescriptor.IsArray = wire.IsArray;
		propDescriptor.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		propDescriptor.IsRequired = wire.IsRequired;
		propDescriptor.IsEnabled = wire.IsEnabled;
		propDescriptor.IsModifiable = wire.IsModifiable;
		propDescriptor.AttachedSpecifier = wire.getAttachedSpecifier();
		propDescriptor.MaxLength = wire.getMaxLength();
		propDescriptor.LovAttachmentsCategory = wire.getLovAttachmentsCategory();
		IList interdependentProps = wire.getInterdependentProps();
		propDescriptor.InterdependentProps = new string[interdependentProps.Count];
		for (int i = 0; i < interdependentProps.Count; i++)
		{
			propDescriptor.InterdependentProps[i] = Convert.ToString(interdependentProps[i]);
		}
		return propDescriptor;
	}

	public static Teamcenter.Schemas.Cad._2011_06.Datamanagement.AttrMappingInfo toWire(Teamcenter.Services.Strong.Cad._2011_06.DataManagement.AttrMappingInfo local)
	{
		Teamcenter.Schemas.Cad._2011_06.Datamanagement.AttrMappingInfo attrMappingInfo = new Teamcenter.Schemas.Cad._2011_06.Datamanagement.AttrMappingInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.CadAttrMappingDefinition == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.CadAttrMappingDefinition.Uid);
		}
		attrMappingInfo.setCadAttrMappingDefinition(modelObject);
		attrMappingInfo.setPropDesc(toWire(local.PropDesc));
		return attrMappingInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2011_06.DataManagement.AttrMappingInfo toLocal(Teamcenter.Schemas.Cad._2011_06.Datamanagement.AttrMappingInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2011_06.DataManagement.AttrMappingInfo attrMappingInfo = new Teamcenter.Services.Strong.Cad._2011_06.DataManagement.AttrMappingInfo();
		attrMappingInfo.CadAttrMappingDefinition = (CadAttrMappingDefinition)modelManager.LoadObjectData(wire.getCadAttrMappingDefinition());
		attrMappingInfo.PropDesc = toLocal(wire.getPropDesc(), modelManager);
		return attrMappingInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2011_06.DataManagement.GetAllAttrMappingsResponse toLocal(Teamcenter.Schemas.Cad._2011_06.Datamanagement.GetAllAttrMappingsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2011_06.DataManagement.GetAllAttrMappingsResponse getAllAttrMappingsResponse = new Teamcenter.Services.Strong.Cad._2011_06.DataManagement.GetAllAttrMappingsResponse();
		getAllAttrMappingsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList attrMappingInfos = wire.getAttrMappingInfos();
		getAllAttrMappingsResponse.AttrMappingInfos = new Teamcenter.Services.Strong.Cad._2011_06.DataManagement.AttrMappingInfo[attrMappingInfos.Count];
		for (int i = 0; i < attrMappingInfos.Count; i++)
		{
			getAllAttrMappingsResponse.AttrMappingInfos[i] = toLocal((Teamcenter.Schemas.Cad._2011_06.Datamanagement.AttrMappingInfo)attrMappingInfos[i], modelManager);
		}
		return getAllAttrMappingsResponse;
	}

	public override Teamcenter.Services.Strong.Cad._2011_06.DataManagement.GetAllAttrMappingsResponse GetAllAttrMappings2()
	{
		try
		{
			restSender.PushRequestId();
			GetAllAttrMappings2Input requestObject = new GetAllAttrMappings2Input();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2011_06.Datamanagement.GetAllAttrMappingsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201106_PORT_NAME, "GetAllAttrMappings2", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2011_06.Datamanagement.GetAllAttrMappingsResponse wire = (Teamcenter.Schemas.Cad._2011_06.Datamanagement.GetAllAttrMappingsResponse)obj;
			Teamcenter.Services.Strong.Cad._2011_06.DataManagement.GetAllAttrMappingsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdateInput toWire(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput local)
	{
		Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdateInput createOrUpdateInput = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdateInput();
		createOrUpdateInput.setBoName(local.BoName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BoReference == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BoReference.Uid);
		}
		createOrUpdateInput.setBoReference(modelObject);
		createOrUpdateInput.setStringProps(toWireStringMap(local.StringProps));
		createOrUpdateInput.setStringArrayProps(toWireStringVectorMap(local.StringArrayProps));
		createOrUpdateInput.setDoubleProps(toWireDoubleMap(local.DoubleProps));
		createOrUpdateInput.setDoubleArrayProps(toWireDoubleVectorMap(local.DoubleArrayProps));
		createOrUpdateInput.setFloatProps(toWireFloatMap(local.FloatProps));
		createOrUpdateInput.setFloatArrayProps(toWireFloatVectorMap(local.FloatArrayProps));
		createOrUpdateInput.setIntProps(toWireIntMap(local.IntProps));
		createOrUpdateInput.setIntArrayProps(toWireIntVectorMap(local.IntArrayProps));
		createOrUpdateInput.setBoolProps(toWireBoolMap(local.BoolProps));
		createOrUpdateInput.setBoolArrayProps(toWireBoolVectorMap(local.BoolArrayProps));
		createOrUpdateInput.setDateProps(toWireDateMap(local.DateProps));
		createOrUpdateInput.setDateArrayProps(toWireDateVectorMap(local.DateArrayProps));
		createOrUpdateInput.setTagProps(toWireTagMap(local.TagProps));
		createOrUpdateInput.setTagArrayProps(toWireTagVectorMap(local.TagArrayProps));
		createOrUpdateInput.setCompoundCreateOrUpdateInput(toWireCreateOrUpdateInputMap(local.CompoundCreateOrUpdateInput));
		return createOrUpdateInput;
	}

	public static Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput toLocal(Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdateInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput createOrUpdateInput = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput();
		createOrUpdateInput.BoName = wire.getBoName();
		createOrUpdateInput.BoReference = modelManager.LoadObjectData(wire.getBoReference());
		createOrUpdateInput.StringProps = toLocalStringMap(wire.getStringProps(), modelManager);
		createOrUpdateInput.StringArrayProps = toLocalStringVectorMap(wire.getStringArrayProps(), modelManager);
		createOrUpdateInput.DoubleProps = toLocalDoubleMap(wire.getDoubleProps(), modelManager);
		createOrUpdateInput.DoubleArrayProps = toLocalDoubleVectorMap(wire.getDoubleArrayProps(), modelManager);
		createOrUpdateInput.FloatProps = toLocalFloatMap(wire.getFloatProps(), modelManager);
		createOrUpdateInput.FloatArrayProps = toLocalFloatVectorMap(wire.getFloatArrayProps(), modelManager);
		createOrUpdateInput.IntProps = toLocalIntMap(wire.getIntProps(), modelManager);
		createOrUpdateInput.IntArrayProps = toLocalIntVectorMap(wire.getIntArrayProps(), modelManager);
		createOrUpdateInput.BoolProps = toLocalBoolMap(wire.getBoolProps(), modelManager);
		createOrUpdateInput.BoolArrayProps = toLocalBoolVectorMap(wire.getBoolArrayProps(), modelManager);
		createOrUpdateInput.DateProps = toLocalDateMap(wire.getDateProps(), modelManager);
		createOrUpdateInput.DateArrayProps = toLocalDateVectorMap(wire.getDateArrayProps(), modelManager);
		createOrUpdateInput.TagProps = toLocalTagMap(wire.getTagProps(), modelManager);
		createOrUpdateInput.TagArrayProps = toLocalTagVectorMap(wire.getTagArrayProps(), modelManager);
		createOrUpdateInput.CompoundCreateOrUpdateInput = toLocalCreateOrUpdateInputMap(wire.getCompoundCreateOrUpdateInput(), modelManager);
		return createOrUpdateInput;
	}

	public static Teamcenter.Schemas.Cad._2012_09.Datamanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Cad._2012_09.Datamanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.DatasetInfo();
		datasetInfo.setClientId(local.ClientId);
		datasetInfo.setCreateOrUpdateInput(toWire(local.CreateOrUpdateInput));
		datasetInfo.setBasisName(local.BasisName);
		datasetInfo.setLastModifiedOfDataset(TcServerDate.ToWire(local.LastModifiedOfDataset));
		datasetInfo.setItemRevRelationName(local.ItemRevRelationName);
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setMapAttributesWithoutDataset(local.MapAttributesWithoutDataset);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.MappingAttributes.Length; i++)
		{
			arrayList.Add(toWire(local.MappingAttributes[i]));
		}
		datasetInfo.setMappingAttributes(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExtraObject.Length; i++)
		{
			arrayList2.Add(toWire(local.ExtraObject[i]));
		}
		datasetInfo.setExtraObject(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList3.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList4.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList4);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2012_09.DataManagement.DatasetInfo toLocal(Teamcenter.Schemas.Cad._2012_09.Datamanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2012_09.DataManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.CreateOrUpdateInput = toLocal(wire.getCreateOrUpdateInput(), modelManager);
		datasetInfo.BasisName = wire.getBasisName();
		datasetInfo.LastModifiedOfDataset = TcServerDate.ToLocal(wire.getLastModifiedOfDataset());
		datasetInfo.ItemRevRelationName = wire.getItemRevRelationName();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.MapAttributesWithoutDataset = wire.MapAttributesWithoutDataset;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList mappingAttributes = wire.getMappingAttributes();
		datasetInfo.MappingAttributes = new Teamcenter.Services.Strong.Cad._2008_06.DataManagement.AttributeInfo[mappingAttributes.Count];
		for (int i = 0; i < mappingAttributes.Count; i++)
		{
			datasetInfo.MappingAttributes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Datamanagement.AttributeInfo)mappingAttributes[i], modelManager);
		}
		IList extraObject = wire.getExtraObject();
		datasetInfo.ExtraObject = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo[extraObject.Count];
		for (int i = 0; i < extraObject.Count; i++)
		{
			datasetInfo.ExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo)extraObject[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2010_09.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2010_09.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.NamedReferenceObjectInfo[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2012_09.Datamanagement.NamedReferenceObjectInfo)namedReferenceObjectInfos[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo toWire(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo extraObjectInfo = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo();
		extraObjectInfo.setClientId(local.ClientId);
		extraObjectInfo.setCreateOrUpdateInput(toWire(local.CreateOrUpdateInput));
		extraObjectInfo.setRelationTypeName(local.RelationTypeName);
		return extraObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo toLocal(Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo extraObjectInfo = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo();
		extraObjectInfo.ClientId = wire.getClientId();
		extraObjectInfo.CreateOrUpdateInput = toLocal(wire.getCreateOrUpdateInput(), modelManager);
		extraObjectInfo.RelationTypeName = wire.getRelationTypeName();
		return extraObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2012_09.Datamanagement.ItemInfo toWire(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ItemInfo local)
	{
		Teamcenter.Schemas.Cad._2012_09.Datamanagement.ItemInfo itemInfo = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.ItemInfo();
		itemInfo.setCreateOrUpdateInput(toWire(local.CreateOrUpdateInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemExtraObject.Length; i++)
		{
			arrayList.Add(toWire(local.ItemExtraObject[i]));
		}
		itemInfo.setItemExtraObject(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ItemRevisionExtraObject.Length; i++)
		{
			arrayList2.Add(toWire(local.ItemRevisionExtraObject[i]));
		}
		itemInfo.setItemRevisionExtraObject(arrayList2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Folder.Uid);
		}
		itemInfo.setFolder(modelObject);
		return itemInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ItemInfo toLocal(Teamcenter.Schemas.Cad._2012_09.Datamanagement.ItemInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ItemInfo itemInfo = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ItemInfo();
		itemInfo.CreateOrUpdateInput = toLocal(wire.getCreateOrUpdateInput(), modelManager);
		IList itemExtraObject = wire.getItemExtraObject();
		itemInfo.ItemExtraObject = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo[itemExtraObject.Count];
		for (int i = 0; i < itemExtraObject.Count; i++)
		{
			itemInfo.ItemExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo)itemExtraObject[i], modelManager);
		}
		IList itemRevisionExtraObject = wire.getItemRevisionExtraObject();
		itemInfo.ItemRevisionExtraObject = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.ExtraObjectInfo[itemRevisionExtraObject.Count];
		for (int i = 0; i < itemRevisionExtraObject.Count; i++)
		{
			itemInfo.ItemRevisionExtraObject[i] = toLocal((Teamcenter.Schemas.Cad._2012_09.Datamanagement.ExtraObjectInfo)itemRevisionExtraObject[i], modelManager);
		}
		itemInfo.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		return itemInfo;
	}

	public static Teamcenter.Schemas.Cad._2012_09.Datamanagement.NamedReferenceObjectInfo toWire(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.NamedReferenceObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2012_09.Datamanagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.setClientId(local.ClientId);
		namedReferenceObjectInfo.setCreateOrUpdateInput(toWire(local.CreateOrUpdateInput));
		namedReferenceObjectInfo.setNamedReferenceName(local.NamedReferenceName);
		namedReferenceObjectInfo.setNamedReferenceType(local.NamedReferenceType);
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2012_09.DataManagement.NamedReferenceObjectInfo toLocal(Teamcenter.Schemas.Cad._2012_09.Datamanagement.NamedReferenceObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2012_09.DataManagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.ClientId = wire.getClientId();
		namedReferenceObjectInfo.CreateOrUpdateInput = toLocal(wire.getCreateOrUpdateInput(), modelManager);
		namedReferenceObjectInfo.NamedReferenceName = wire.getNamedReferenceName();
		namedReferenceObjectInfo.NamedReferenceType = wire.getNamedReferenceType();
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2012_09.Datamanagement.PartInfo toWire(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.PartInfo local)
	{
		Teamcenter.Schemas.Cad._2012_09.Datamanagement.PartInfo partInfo = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.PartInfo();
		partInfo.setClientId(local.ClientId);
		partInfo.setItemInput(toWire(local.ItemInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetInput.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetInput[i]));
		}
		partInfo.setDatasetInput(arrayList);
		return partInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2012_09.DataManagement.PartInfo toLocal(Teamcenter.Schemas.Cad._2012_09.Datamanagement.PartInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2012_09.DataManagement.PartInfo partInfo = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.PartInfo();
		partInfo.ClientId = wire.getClientId();
		partInfo.ItemInput = toLocal(wire.getItemInput(), modelManager);
		IList datasetInput = wire.getDatasetInput();
		partInfo.DatasetInput = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.DatasetInfo[datasetInput.Count];
		for (int i = 0; i < datasetInput.Count; i++)
		{
			partInfo.DatasetInput[i] = toLocal((Teamcenter.Schemas.Cad._2012_09.Datamanagement.DatasetInfo)datasetInput[i], modelManager);
		}
		return partInfo;
	}

	public static ArrayList toWireBoolMap(IDictionary BoolMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in BoolMap)
		{
			object key = item.Key;
			object value = item.Value;
			BoolMap boolMap = new BoolMap();
			boolMap.setKey(Convert.ToString(key));
			boolMap.setValue(Convert.ToBoolean(value));
			arrayList.Add(boolMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalBoolMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			BoolMap boolMap = (BoolMap)wire[i];
			string key = boolMap.getKey();
			bool value = boolMap.Value;
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireBoolVectorMap(IDictionary BoolVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in BoolVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			BoolVectorMap boolVectorMap = new BoolVectorMap();
			boolVectorMap.setKey(Convert.ToString(key));
			IList value2 = boolVectorMap.getValue();
			bool[] array = (bool[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			boolVectorMap.setValue((ArrayList)value2);
			arrayList.Add(boolVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalBoolVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			BoolVectorMap boolVectorMap = (BoolVectorMap)wire[i];
			string key = boolVectorMap.getKey();
			IList value = boolVectorMap.getValue();
			bool[] array = new bool[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (bool)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireCreateOrUpdateInputMap(IDictionary CreateOrUpdateInputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in CreateOrUpdateInputMap)
		{
			object key = item.Key;
			object value = item.Value;
			CreateOrUpdateInputMap createOrUpdateInputMap = new CreateOrUpdateInputMap();
			createOrUpdateInputMap.setKey(Convert.ToString(key));
			IList value2 = createOrUpdateInputMap.getValue();
			Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput[] array = (Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			createOrUpdateInputMap.setValue((ArrayList)value2);
			arrayList.Add(createOrUpdateInputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalCreateOrUpdateInputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			CreateOrUpdateInputMap createOrUpdateInputMap = (CreateOrUpdateInputMap)wire[i];
			string key = createOrUpdateInputMap.getKey();
			IList value = createOrUpdateInputMap.getValue();
			Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput[] array = new Teamcenter.Services.Strong.Cad._2012_09.DataManagement.CreateOrUpdateInput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdateInput)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireDateMap(IDictionary DateMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DateMap)
		{
			object key = item.Key;
			object value = item.Value;
			DateMap dateMap = new DateMap();
			dateMap.setKey(Convert.ToString(key));
			dateMap.setValue(TcServerDate.ToWire((DateTime)value));
			arrayList.Add(dateMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDateMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DateMap dateMap = (DateMap)wire[i];
			string key = dateMap.getKey();
			DateTime dateTime = TcServerDate.ToLocal(dateMap.getValue());
			hashtable.Add(key, dateTime);
		}
		return hashtable;
	}

	public static ArrayList toWireDateVectorMap(IDictionary DateVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DateVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			DateVectorMap dateVectorMap = new DateVectorMap();
			dateVectorMap.setKey(Convert.ToString(key));
			IList value2 = dateVectorMap.getValue();
			DateTime[] array = (DateTime[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			dateVectorMap.setValue((ArrayList)value2);
			arrayList.Add(dateVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDateVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DateVectorMap dateVectorMap = (DateVectorMap)wire[i];
			string key = dateVectorMap.getKey();
			IList value = dateVectorMap.getValue();
			DateTime[] array = new DateTime[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				ref DateTime reference = ref array[j];
				reference = (DateTime)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireDoubleMap(IDictionary DoubleMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DoubleMap)
		{
			object key = item.Key;
			object value = item.Value;
			DoubleMap doubleMap = new DoubleMap();
			doubleMap.setKey(Convert.ToString(key));
			doubleMap.setValue(Convert.ToDouble(value));
			arrayList.Add(doubleMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDoubleMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DoubleMap doubleMap = (DoubleMap)wire[i];
			string key = doubleMap.getKey();
			double value = doubleMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireDoubleVectorMap(IDictionary DoubleVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DoubleVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			DoubleVectorMap doubleVectorMap = new DoubleVectorMap();
			doubleVectorMap.setKey(Convert.ToString(key));
			IList value2 = doubleVectorMap.getValue();
			double[] array = (double[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			doubleVectorMap.setValue((ArrayList)value2);
			arrayList.Add(doubleVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDoubleVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DoubleVectorMap doubleVectorMap = (DoubleVectorMap)wire[i];
			string key = doubleVectorMap.getKey();
			IList value = doubleVectorMap.getValue();
			double[] array = new double[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (double)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireFloatMap(IDictionary FloatMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in FloatMap)
		{
			object key = item.Key;
			object value = item.Value;
			FloatMap floatMap = new FloatMap();
			floatMap.setKey(Convert.ToString(key));
			floatMap.setValue(Convert.ToSingle(value));
			arrayList.Add(floatMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalFloatMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			FloatMap floatMap = (FloatMap)wire[i];
			string key = floatMap.getKey();
			float value = floatMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireFloatVectorMap(IDictionary FloatVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in FloatVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			FloatVectorMap floatVectorMap = new FloatVectorMap();
			floatVectorMap.setKey(Convert.ToString(key));
			IList value2 = floatVectorMap.getValue();
			float[] array = (float[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			floatVectorMap.setValue((ArrayList)value2);
			arrayList.Add(floatVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalFloatVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			FloatVectorMap floatVectorMap = (FloatVectorMap)wire[i];
			string key = floatVectorMap.getKey();
			IList value = floatVectorMap.getValue();
			float[] array = new float[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (float)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireIntMap(IDictionary IntMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IntMap)
		{
			object key = item.Key;
			object value = item.Value;
			IntMap intMap = new IntMap();
			intMap.setKey(Convert.ToString(key));
			intMap.setValue((int)value);
			arrayList.Add(intMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalIntMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IntMap intMap = (IntMap)wire[i];
			string key = intMap.getKey();
			int value = intMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireIntVectorMap(IDictionary IntVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IntVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			IntVectorMap intVectorMap = new IntVectorMap();
			intVectorMap.setKey(Convert.ToString(key));
			IList value2 = intVectorMap.getValue();
			int[] array = (int[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			intVectorMap.setValue((ArrayList)value2);
			arrayList.Add(intVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalIntVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IntVectorMap intVectorMap = (IntVectorMap)wire[i];
			string key = intVectorMap.getKey();
			IList value = intVectorMap.getValue();
			int[] array = new int[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (int)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireStringMap(IDictionary StringMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in StringMap)
		{
			object key = item.Key;
			object value = item.Value;
			StringMap stringMap = new StringMap();
			stringMap.setKey(Convert.ToString(key));
			stringMap.setValue(Convert.ToString(value));
			arrayList.Add(stringMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalStringMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			StringMap stringMap = (StringMap)wire[i];
			string key = stringMap.getKey();
			string value = stringMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireStringVectorMap(IDictionary StringVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in StringVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			StringVectorMap stringVectorMap = new StringVectorMap();
			stringVectorMap.setKey(Convert.ToString(key));
			IList value2 = stringVectorMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			stringVectorMap.setValue((ArrayList)value2);
			arrayList.Add(stringVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalStringVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			StringVectorMap stringVectorMap = (StringVectorMap)wire[i];
			string key = stringVectorMap.getKey();
			IList value = stringVectorMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireTagMap(IDictionary TagMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TagMap)
		{
			object key = item.Key;
			object value = item.Value;
			TagMap tagMap = new TagMap();
			tagMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			tagMap.setValue(modelObject);
			arrayList.Add(tagMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalTagMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			TagMap tagMap = (TagMap)wire[i];
			string key = tagMap.getKey();
			Teamcenter.Soa.Client.Model.ModelObject value = modelManager.LoadObjectData(tagMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireTagVectorMap(IDictionary TagVectorMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TagVectorMap)
		{
			object key = item.Key;
			object value = item.Value;
			TagVectorMap tagVectorMap = new TagVectorMap();
			tagVectorMap.setKey(Convert.ToString(key));
			IList value2 = tagVectorMap.getValue();
			Teamcenter.Soa.Client.Model.ModelObject[] array = (Teamcenter.Soa.Client.Model.ModelObject[])value;
			for (int i = 0; i < array.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (array[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(array[i].Uid);
				}
				value2.Add(modelObject);
			}
			tagVectorMap.setValue((ArrayList)value2);
			arrayList.Add(tagVectorMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalTagVectorMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			TagVectorMap tagVectorMap = (TagVectorMap)wire[i];
			string key = tagVectorMap.getKey();
			IList value = tagVectorMap.getValue();
			Teamcenter.Soa.Client.Model.ModelObject[] array = new Teamcenter.Soa.Client.Model.ModelObject[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)value[j]);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse CreateOrUpdateParts(Teamcenter.Services.Strong.Cad._2012_09.DataManagement.PartInfo[] PartInput, Teamcenter.Services.Strong.Cad._2007_12.DataManagement.CreateOrUpdatePartsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdatePartsInput createOrUpdatePartsInput = new Teamcenter.Schemas.Cad._2012_09.Datamanagement.CreateOrUpdatePartsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PartInput.Length; i++)
			{
				arrayList.Add(toWire(PartInput[i]));
			}
			createOrUpdatePartsInput.setPartInput(arrayList);
			createOrUpdatePartsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201209_PORT_NAME, "CreateOrUpdateParts", createOrUpdatePartsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse wire = (Teamcenter.Schemas.Cad._2008_06.Datamanagement.CreateOrUpdatePartsResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.DataManagement.CreateOrUpdatePartsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static PropDescInfo toWire(PropDescInfo local)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		PropDescInfo val = new PropDescInfo();
		val.setBoTypeName(local.BoTypeName);
		val.setPropDescName(local.PropDescName);
		return val;
	}

	public static PropDescInfo toLocal(PropDescInfo wire, PopulateModel modelManager)
	{
		PropDescInfo propDescInfo = new PropDescInfo();
		propDescInfo.BoTypeName = wire.getBoTypeName();
		propDescInfo.PropDescName = wire.getPropDescName();
		return propDescInfo;
	}

	public static AttrMappingInfo toWire(Teamcenter.Services.Strong.Cad._2014_10.DataManagement.AttrMappingInfo local)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		AttrMappingInfo val = new AttrMappingInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.CadAttrMappingDefinition == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.CadAttrMappingDefinition.Uid);
		}
		val.setCadAttrMappingDefinition(modelObject);
		val.setPropDescInfo(toWire(local.PropDescInfo));
		val.setClientId(local.ClientId);
		return val;
	}

	public static Teamcenter.Services.Strong.Cad._2014_10.DataManagement.AttrMappingInfo toLocal(AttrMappingInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2014_10.DataManagement.AttrMappingInfo attrMappingInfo = new Teamcenter.Services.Strong.Cad._2014_10.DataManagement.AttrMappingInfo();
		attrMappingInfo.CadAttrMappingDefinition = (CadAttrMappingDefinition)modelManager.LoadObjectData(wire.getCadAttrMappingDefinition());
		attrMappingInfo.PropDescInfo = toLocal(wire.getPropDescInfo(), modelManager);
		attrMappingInfo.ClientId = wire.getClientId();
		return attrMappingInfo;
	}

	public static GetAttrMappingsFilter toWire(GetAttrMappingsFilter local)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		GetAttrMappingsFilter val = new GetAttrMappingsFilter();
		val.setItemTypeName(local.ItemTypeName);
		val.setDatasetTypeName(local.DatasetTypeName);
		val.setClientId(local.ClientId);
		return val;
	}

	public static GetAttrMappingsFilter toLocal(GetAttrMappingsFilter wire, PopulateModel modelManager)
	{
		GetAttrMappingsFilter getAttrMappingsFilter = new GetAttrMappingsFilter();
		getAttrMappingsFilter.ItemTypeName = wire.getItemTypeName();
		getAttrMappingsFilter.DatasetTypeName = wire.getDatasetTypeName();
		getAttrMappingsFilter.ClientId = wire.getClientId();
		return getAttrMappingsFilter;
	}

	public static GetAttrMappingsResponse toLocal(GetAttrMappingsResponse wire, PopulateModel modelManager)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		GetAttrMappingsResponse getAttrMappingsResponse = new GetAttrMappingsResponse();
		getAttrMappingsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList attrMappingInfos = wire.getAttrMappingInfos();
		getAttrMappingsResponse.AttrMappingInfos = new Teamcenter.Services.Strong.Cad._2014_10.DataManagement.AttrMappingInfo[attrMappingInfos.Count];
		for (int i = 0; i < attrMappingInfos.Count; i++)
		{
			getAttrMappingsResponse.AttrMappingInfos[i] = DataManagementRestBindingStub.toLocal((AttrMappingInfo)attrMappingInfos[i], modelManager);
		}
		return getAttrMappingsResponse;
	}

	public override GetAttrMappingsResponse GetAttrMappings(GetAttrMappingsFilter[] Filter)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		try
		{
			restSender.PushRequestId();
			GetAttrMappingsInput val = new GetAttrMappingsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Filter.Length; i++)
			{
				arrayList.Add(toWire(Filter[i]));
			}
			val.setFilter(arrayList);
			Type typeFromHandle = typeof(GetAttrMappingsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201410_PORT_NAME, "GetAttrMappings", val, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			GetAttrMappingsResponse wire = (GetAttrMappingsResponse)obj;
			GetAttrMappingsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}
}
