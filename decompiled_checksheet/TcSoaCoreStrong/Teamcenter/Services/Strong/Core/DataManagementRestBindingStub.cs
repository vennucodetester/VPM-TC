using System;
using System.Collections;
using Teamcenter.Schemas.Core._2006_03.Datamanagement;
using Teamcenter.Schemas.Core._2007_01.Datamanagement;
using Teamcenter.Schemas.Core._2007_06.Datamanagement;
using Teamcenter.Schemas.Core._2007_09.Datamanagement;
using Teamcenter.Schemas.Core._2007_12.Datamanagement;
using Teamcenter.Schemas.Core._2008_05.Datamanagement;
using Teamcenter.Schemas.Core._2008_06.Datamanagement;
using Teamcenter.Schemas.Core._2009_10.Datamanagement;
using Teamcenter.Schemas.Core._2010_04.Datamanagement;
using Teamcenter.Schemas.Core._2010_09.Datamanagement;
using Teamcenter.Schemas.Core._2011_06.Datamanagement;
using Teamcenter.Schemas.Core._2012_02.Datamanagement;
using Teamcenter.Schemas.Core._2012_09.Datamanagement;
using Teamcenter.Schemas.Core._2012_10.Datamanagement;
using Teamcenter.Schemas.Core._2013_05.Datamanagement;
using Teamcenter.Schemas.Core._2014_06.Datamanagement;
using Teamcenter.Schemas.Core._2014_10.Datamanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Core._2006_03.DataManagement;
using Teamcenter.Services.Strong.Core._2007_01.DataManagement;
using Teamcenter.Services.Strong.Core._2007_06.DataManagement;
using Teamcenter.Services.Strong.Core._2007_09.DataManagement;
using Teamcenter.Services.Strong.Core._2007_12.DataManagement;
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
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class DataManagementRestBindingStub : DataManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string DATAMANAGEMENT_200603_PORT_NAME = "Core-2006-03-DataManagement";

	private static readonly string DATAMANAGEMENT_200701_PORT_NAME = "Core-2007-01-DataManagement";

	private static readonly string DATAMANAGEMENT_200706_PORT_NAME = "Core-2007-06-DataManagement";

	private static readonly string DATAMANAGEMENT_200709_PORT_NAME = "Core-2007-09-DataManagement";

	private static readonly string DATAMANAGEMENT_200712_PORT_NAME = "Core-2007-12-DataManagement";

	private static readonly string DATAMANAGEMENT_200805_PORT_NAME = "Core-2008-05-DataManagement";

	private static readonly string DATAMANAGEMENT_200806_PORT_NAME = "Core-2008-06-DataManagement";

	private static readonly string DATAMANAGEMENT_200910_PORT_NAME = "Core-2009-10-DataManagement";

	private static readonly string DATAMANAGEMENT_201004_PORT_NAME = "Core-2010-04-DataManagement";

	private static readonly string DATAMANAGEMENT_201009_PORT_NAME = "Core-2010-09-DataManagement";

	private static readonly string DATAMANAGEMENT_201106_PORT_NAME = "Core-2011-06-DataManagement";

	private static readonly string DATAMANAGEMENT_201202_PORT_NAME = "Core-2012-02-DataManagement";

	private static readonly string DATAMANAGEMENT_201209_PORT_NAME = "Core-2012-09-DataManagement";

	private static readonly string DATAMANAGEMENT_201210_PORT_NAME = "Core-2012-10-DataManagement";

	private static readonly string DATAMANAGEMENT_201305_PORT_NAME = "Core-2013-05-DataManagement";

	private static readonly string DATAMANAGEMENT_201406_PORT_NAME = "Core-2014-06-DataManagement";

	private static readonly string DATAMANAGEMENT_201410_PORT_NAME = "Core-2014-10-DataManagement";

	public DataManagementRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsOutput toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsOutput local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsOutput createDatasetsOutput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsOutput();
		createDatasetsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		createDatasetsOutput.setDataset(modelObject);
		return createDatasetsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsOutput toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsOutput createDatasetsOutput = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsOutput();
		createDatasetsOutput.ClientId = wire.getClientId();
		createDatasetsOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		return createDatasetsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse createDatasetsResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse();
		createDatasetsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createDatasetsResponse.Output = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createDatasetsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsOutput)output[i], modelManager);
		}
		return createDatasetsResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFolderInput toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFolderInput local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFolderInput createFolderInput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFolderInput();
		createFolderInput.setClientId(local.ClientId);
		createFolderInput.setName(local.Name);
		createFolderInput.setDesc(local.Desc);
		return createFolderInput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFolderInput toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFolderInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFolderInput createFolderInput = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFolderInput();
		createFolderInput.ClientId = wire.getClientId();
		createFolderInput.Name = wire.getName();
		createFolderInput.Desc = wire.getDesc();
		return createFolderInput;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersOutput toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersOutput local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersOutput createFoldersOutput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersOutput();
		createFoldersOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Folder.Uid);
		}
		createFoldersOutput.setFolder(modelObject);
		return createFoldersOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersOutput toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersOutput createFoldersOutput = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersOutput();
		createFoldersOutput.ClientId = wire.getClientId();
		createFoldersOutput.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		return createFoldersOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersResponse createFoldersResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersResponse();
		createFoldersResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createFoldersResponse.Output = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createFoldersResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersOutput)output[i], modelManager);
		}
		return createFoldersResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsOutput toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsOutput local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsOutput createItemsOutput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsOutput();
		createItemsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		createItemsOutput.setItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		createItemsOutput.setItemRev(modelObject2);
		return createItemsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsOutput toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsOutput createItemsOutput = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsOutput();
		createItemsOutput.ClientId = wire.getClientId();
		createItemsOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		createItemsOutput.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		return createItemsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsResponse createItemsResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsResponse();
		createItemsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createItemsResponse.Output = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createItemsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsOutput)output[i], modelManager);
		}
		return createItemsResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsOutput toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsOutput local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsOutput createRelationsOutput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsOutput();
		createRelationsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Relation == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Relation.Uid);
		}
		createRelationsOutput.setRelation(modelObject);
		return createRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsOutput toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsOutput createRelationsOutput = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsOutput();
		createRelationsOutput.ClientId = wire.getClientId();
		createRelationsOutput.Relation = (ImanRelation)modelManager.LoadObjectData(wire.getRelation());
		return createRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsResponse createRelationsResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsResponse();
		createRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createRelationsResponse.Output = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createRelationsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsOutput)output[i], modelManager);
		}
		return createRelationsResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.DatasetProperties toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.DatasetProperties local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.DatasetProperties datasetProperties = new Teamcenter.Schemas.Core._2006_03.Datamanagement.DatasetProperties();
		datasetProperties.setClientId(local.ClientId);
		datasetProperties.setType(local.Type);
		datasetProperties.setName(local.Name);
		datasetProperties.setDescription(local.Description);
		datasetProperties.setToolUsed(local.ToolUsed);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Container == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Container.Uid);
		}
		datasetProperties.setContainer(modelObject);
		datasetProperties.setRelationType(local.RelationType);
		return datasetProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.DatasetProperties toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.DatasetProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.DatasetProperties datasetProperties = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.DatasetProperties();
		datasetProperties.ClientId = wire.getClientId();
		datasetProperties.Type = wire.getType();
		datasetProperties.Name = wire.getName();
		datasetProperties.Description = wire.getDescription();
		datasetProperties.ToolUsed = wire.getToolUsed();
		datasetProperties.Container = modelManager.LoadObjectData(wire.getContainer());
		datasetProperties.RelationType = wire.getRelationType();
		return datasetProperties;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.ExtendedAttributes toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ExtendedAttributes local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.ExtendedAttributes extendedAttributes = new Teamcenter.Schemas.Core._2006_03.Datamanagement.ExtendedAttributes();
		extendedAttributes.setObjectType(local.ObjectType);
		extendedAttributes.setAttributes(toWireAttributeNameValueMap(local.Attributes));
		return extendedAttributes;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.ExtendedAttributes toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.ExtendedAttributes wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.ExtendedAttributes extendedAttributes = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ExtendedAttributes();
		extendedAttributes.ObjectType = wire.getObjectType();
		extendedAttributes.Attributes = toLocalAttributeNameValueMap(wire.getAttributes(), modelManager);
		return extendedAttributes;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsProperties toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsProperties local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsProperties generateItemIdsAndInitialRevisionIdsProperties = new Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsProperties();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		generateItemIdsAndInitialRevisionIdsProperties.setItem(modelObject);
		generateItemIdsAndInitialRevisionIdsProperties.setItemType(local.ItemType);
		generateItemIdsAndInitialRevisionIdsProperties.setCount(local.Count);
		return generateItemIdsAndInitialRevisionIdsProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsProperties toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsProperties generateItemIdsAndInitialRevisionIdsProperties = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsProperties();
		generateItemIdsAndInitialRevisionIdsProperties.Item = modelManager.LoadObjectData(wire.getItem());
		generateItemIdsAndInitialRevisionIdsProperties.ItemType = wire.getItemType();
		generateItemIdsAndInitialRevisionIdsProperties.Count = wire.getCount();
		return generateItemIdsAndInitialRevisionIdsProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsResponse generateItemIdsAndInitialRevisionIdsResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsResponse();
		generateItemIdsAndInitialRevisionIdsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		generateItemIdsAndInitialRevisionIdsResponse.OutputItemIdsAndInitialRevisionIds = toLocalIndexToIdMap(wire.getOutputItemIdsAndInitialRevisionIds(), modelManager);
		return generateItemIdsAndInitialRevisionIdsResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsProperties toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsProperties local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsProperties generateRevisionIdsProperties = new Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsProperties();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		generateRevisionIdsProperties.setItem(modelObject);
		generateRevisionIdsProperties.setItemType(local.ItemType);
		return generateRevisionIdsProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsProperties toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsProperties generateRevisionIdsProperties = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsProperties();
		generateRevisionIdsProperties.Item = modelManager.LoadObjectData(wire.getItem());
		generateRevisionIdsProperties.ItemType = wire.getItemType();
		return generateRevisionIdsProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsResponse generateRevisionIdsResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsResponse();
		generateRevisionIdsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		generateRevisionIdsResponse.OutputRevisionIds = toLocalIndexToRevIdMap(wire.getOutputRevisionIds(), modelManager);
		return generateRevisionIdsResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemIdsAndInitialRevisionIds toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemIdsAndInitialRevisionIds itemIdsAndInitialRevisionIds = new Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemIdsAndInitialRevisionIds();
		itemIdsAndInitialRevisionIds.setNewItemId(local.NewItemId);
		itemIdsAndInitialRevisionIds.setNewRevId(local.NewRevId);
		itemIdsAndInitialRevisionIds.setIsItemModify(local.IsItemModify);
		itemIdsAndInitialRevisionIds.setIsRevModify(local.IsRevModify);
		return itemIdsAndInitialRevisionIds;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemIdsAndInitialRevisionIds wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds itemIdsAndInitialRevisionIds = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds();
		itemIdsAndInitialRevisionIds.NewItemId = wire.getNewItemId();
		itemIdsAndInitialRevisionIds.NewRevId = wire.getNewRevId();
		itemIdsAndInitialRevisionIds.IsItemModify = wire.IsItemModify;
		itemIdsAndInitialRevisionIds.IsRevModify = wire.IsRevModify;
		return itemIdsAndInitialRevisionIds;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemProperties toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemProperties local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemProperties itemProperties = new Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemProperties();
		itemProperties.setClientId(local.ClientId);
		itemProperties.setItemId(local.ItemId);
		itemProperties.setName(local.Name);
		itemProperties.setType(local.Type);
		itemProperties.setRevId(local.RevId);
		itemProperties.setUom(local.Uom);
		itemProperties.setDescription(local.Description);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ExtendedAttributes.Length; i++)
		{
			arrayList.Add(toWire(local.ExtendedAttributes[i]));
		}
		itemProperties.setExtendedAttributes(arrayList);
		return itemProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemProperties toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemProperties itemProperties = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemProperties();
		itemProperties.ClientId = wire.getClientId();
		itemProperties.ItemId = wire.getItemId();
		itemProperties.Name = wire.getName();
		itemProperties.Type = wire.getType();
		itemProperties.RevId = wire.getRevId();
		itemProperties.Uom = wire.getUom();
		itemProperties.Description = wire.getDescription();
		IList extendedAttributes = wire.getExtendedAttributes();
		itemProperties.ExtendedAttributes = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ExtendedAttributes[extendedAttributes.Count];
		for (int i = 0; i < extendedAttributes.Count; i++)
		{
			itemProperties.ExtendedAttributes[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.ExtendedAttributes)extendedAttributes[i], modelManager);
		}
		return itemProperties;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.ObjectOwner toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ObjectOwner local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.ObjectOwner objectOwner = new Teamcenter.Schemas.Core._2006_03.Datamanagement.ObjectOwner();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		objectOwner.setObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Owner == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Owner.Uid);
		}
		objectOwner.setOwner(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Group == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.Group.Uid);
		}
		objectOwner.setGroup(modelObject3);
		return objectOwner;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.ObjectOwner toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.ObjectOwner wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.ObjectOwner objectOwner = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ObjectOwner();
		objectOwner.Object = modelManager.LoadObjectData(wire.getObject());
		objectOwner.Owner = (User)modelManager.LoadObjectData(wire.getOwner());
		objectOwner.Group = (Group)modelManager.LoadObjectData(wire.getGroup());
		return objectOwner;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.Relationship toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.Relationship local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.Relationship relationship = new Teamcenter.Schemas.Core._2006_03.Datamanagement.Relationship();
		relationship.setClientId(local.ClientId);
		relationship.setRelationType(local.RelationType);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryObject.Uid);
		}
		relationship.setPrimaryObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SecondaryObject == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.SecondaryObject.Uid);
		}
		relationship.setSecondaryObject(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.UserData == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.UserData.Uid);
		}
		relationship.setUserData(modelObject3);
		return relationship;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.Relationship toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.Relationship wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.Relationship relationship = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.Relationship();
		relationship.ClientId = wire.getClientId();
		relationship.RelationType = wire.getRelationType();
		relationship.PrimaryObject = modelManager.LoadObjectData(wire.getPrimaryObject());
		relationship.SecondaryObject = modelManager.LoadObjectData(wire.getSecondaryObject());
		relationship.UserData = modelManager.LoadObjectData(wire.getUserData());
		return relationship;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseProperties toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseProperties local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseProperties reviseProperties = new Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseProperties();
		reviseProperties.setRevId(local.RevId);
		reviseProperties.setName(local.Name);
		reviseProperties.setDescription(local.Description);
		reviseProperties.setExtendedAttributes(toWireAttributeNameValueMap(local.ExtendedAttributes));
		return reviseProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseProperties toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseProperties reviseProperties = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseProperties();
		reviseProperties.RevId = wire.getRevId();
		reviseProperties.Name = wire.getName();
		reviseProperties.Description = wire.getDescription();
		reviseProperties.ExtendedAttributes = toLocalAttributeNameValueMap(wire.getExtendedAttributes(), modelManager);
		return reviseProperties;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseResponse toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseResponse reviseResponse = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseResponse();
		reviseResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		reviseResponse.OldItemRevToNewItemRev = toLocalItemRevMap(wire.getOldItemRevToNewItemRev(), modelManager);
		return reviseResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Datamanagement.RevisionIds toWire(Teamcenter.Services.Strong.Core._2006_03.DataManagement.RevisionIds local)
	{
		Teamcenter.Schemas.Core._2006_03.Datamanagement.RevisionIds revisionIds = new Teamcenter.Schemas.Core._2006_03.Datamanagement.RevisionIds();
		revisionIds.setNewRevId(local.NewRevId);
		revisionIds.setIsModify(local.IsModify);
		return revisionIds;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.DataManagement.RevisionIds toLocal(Teamcenter.Schemas.Core._2006_03.Datamanagement.RevisionIds wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.DataManagement.RevisionIds revisionIds = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.RevisionIds();
		revisionIds.NewRevId = wire.getNewRevId();
		revisionIds.IsModify = wire.IsModify;
		return revisionIds;
	}

	public static ArrayList toWireAttributeNameValueMap(IDictionary AttributeNameValueMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in AttributeNameValueMap)
		{
			object key = item.Key;
			object value = item.Value;
			AttributeNameValueMap attributeNameValueMap = new AttributeNameValueMap();
			attributeNameValueMap.setKey(Convert.ToString(key));
			attributeNameValueMap.setValue(Convert.ToString(value));
			arrayList.Add(attributeNameValueMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalAttributeNameValueMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			AttributeNameValueMap attributeNameValueMap = (AttributeNameValueMap)wire[i];
			string key = attributeNameValueMap.getKey();
			string value = attributeNameValueMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireIndexToIdMap(IDictionary IndexToIdMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IndexToIdMap)
		{
			object key = item.Key;
			object value = item.Value;
			IndexToIdMap indexToIdMap = new IndexToIdMap();
			indexToIdMap.setKey((int)key);
			IList value2 = indexToIdMap.getValue();
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds[] array = (Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			indexToIdMap.setValue((ArrayList)value2);
			arrayList.Add(indexToIdMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalIndexToIdMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IndexToIdMap indexToIdMap = (IndexToIdMap)wire[i];
			int key = indexToIdMap.getKey();
			IList value = indexToIdMap.getValue();
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds[] array = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemIdsAndInitialRevisionIds[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.ItemIdsAndInitialRevisionIds)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireIndexToRevIdMap(IDictionary IndexToRevIdMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IndexToRevIdMap)
		{
			object key = item.Key;
			object value = item.Value;
			IndexToRevIdMap indexToRevIdMap = new IndexToRevIdMap();
			indexToRevIdMap.setKey((int)key);
			indexToRevIdMap.setValue(toWire((Teamcenter.Services.Strong.Core._2006_03.DataManagement.RevisionIds)value));
			arrayList.Add(indexToRevIdMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalIndexToRevIdMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IndexToRevIdMap indexToRevIdMap = (IndexToRevIdMap)wire[i];
			int key = indexToRevIdMap.getKey();
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.RevisionIds value = toLocal(indexToRevIdMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireItemRevMap(IDictionary ItemRevMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ItemRevMap)
		{
			object key = item.Key;
			object value = item.Value;
			ItemRevMap itemRevMap = new ItemRevMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			itemRevMap.setKey(modelObject);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			itemRevMap.setValue(modelObject2);
			arrayList.Add(itemRevMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalItemRevMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ItemRevMap itemRevMap = (ItemRevMap)wire[i];
			ItemRevision key = (ItemRevision)modelManager.LoadObjectData(itemRevMap.getKey());
			ItemRevision value = (ItemRevision)modelManager.LoadObjectData(itemRevMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireItemRevPropertyMap(IDictionary ItemRevPropertyMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ItemRevPropertyMap)
		{
			object key = item.Key;
			object value = item.Value;
			ItemRevPropertyMap itemRevPropertyMap = new ItemRevPropertyMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			itemRevPropertyMap.setKey(modelObject);
			itemRevPropertyMap.setValue(toWire((Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseProperties)value));
			arrayList.Add(itemRevPropertyMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalItemRevPropertyMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ItemRevPropertyMap itemRevPropertyMap = (ItemRevPropertyMap)wire[i];
			ItemRevision key = (ItemRevision)modelManager.LoadObjectData(itemRevPropertyMap.getKey());
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseProperties value = toLocal(itemRevPropertyMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData GetProperties(Teamcenter.Soa.Client.Model.ModelObject[] Objects, string[] Attributes)
	{
		try
		{
			restSender.PushRequestId();
			GetPropertiesInput getPropertiesInput = new GetPropertiesInput();
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
			getPropertiesInput.setObjects(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < Attributes.Length; i++)
			{
				arrayList2.Add(Attributes[i]);
			}
			getPropertiesInput.setAttributes(arrayList2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "GetProperties", getPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Soa.Client.Model.ServiceData SetDisplayProperties(Teamcenter.Soa.Client.Model.ModelObject[] Objects, Hashtable Attributes)
	{
		try
		{
			restSender.PushRequestId();
			SetDisplayPropertiesInput setDisplayPropertiesInput = new SetDisplayPropertiesInput();
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
			setDisplayPropertiesInput.setObjects(arrayList);
			setDisplayPropertiesInput.setAttributes(toWireAttributeNameValueMap(Attributes));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "SetDisplayProperties", setDisplayPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	[Obsolete("As of Tc 8, use the createDatasets2 operation.", false)]
	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse CreateDatasets(Teamcenter.Services.Strong.Core._2006_03.DataManagement.DatasetProperties[] Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsInput createDatasetsInput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createDatasetsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "CreateDatasets", createDatasetsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersResponse CreateFolders(Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFolderInput[] Folders, Teamcenter.Soa.Client.Model.ModelObject Container, string RelationType)
	{
		try
		{
			restSender.PushRequestId();
			CreateFoldersInput createFoldersInput = new CreateFoldersInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Folders.Length; i++)
			{
				arrayList.Add(toWire(Folders[i]));
			}
			createFoldersInput.setFolders(arrayList);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Container == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(Container.Uid);
			}
			createFoldersInput.setContainer(modelObject);
			createFoldersInput.setRelationType(RelationType);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "CreateFolders", createFoldersInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateFoldersResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateFoldersResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData ChangeOwnership(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ObjectOwner[] Input)
	{
		try
		{
			restSender.PushRequestId();
			ChangeOwnershipInput changeOwnershipInput = new ChangeOwnershipInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			changeOwnershipInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "ChangeOwnership", changeOwnershipInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsResponse CreateItems(Teamcenter.Services.Strong.Core._2006_03.DataManagement.ItemProperties[] Properties, Teamcenter.Soa.Client.Model.ModelObject Container, string RelationType)
	{
		try
		{
			restSender.PushRequestId();
			CreateItemsInput createItemsInput = new CreateItemsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Properties.Length; i++)
			{
				arrayList.Add(toWire(Properties[i]));
			}
			createItemsInput.setProperties(arrayList);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Container == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(Container.Uid);
			}
			createItemsInput.setContainer(modelObject);
			createItemsInput.setRelationType(RelationType);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "CreateItems", createItemsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateItemsResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateItemsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsResponse GenerateItemIdsAndInitialRevisionIds(Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsProperties[] Input)
	{
		try
		{
			restSender.PushRequestId();
			GenerateItemIdsAndInitialRevisionIdsInput generateItemIdsAndInitialRevisionIdsInput = new GenerateItemIdsAndInitialRevisionIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			generateItemIdsAndInitialRevisionIdsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "GenerateItemIdsAndInitialRevisionIds", generateItemIdsAndInitialRevisionIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateItemIdsAndInitialRevisionIdsResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateItemIdsAndInitialRevisionIdsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsResponse GenerateRevisionIds(Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsProperties[] Input)
	{
		try
		{
			restSender.PushRequestId();
			GenerateRevisionIdsInput generateRevisionIdsInput = new GenerateRevisionIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			generateRevisionIdsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "GenerateRevisionIds", generateRevisionIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.GenerateRevisionIdsResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.GenerateRevisionIdsResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Tc 8, use the revise2 operation.", false)]
	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseResponse Revise(Hashtable Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseInput reviseInput = new Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseInput();
			reviseInput.setInput(toWireItemRevPropertyMap(Input));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "Revise", reviseInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.ReviseResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.ReviseResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData DeleteObjects(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			DeleteObjectsInput deleteObjectsInput = new DeleteObjectsInput();
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
			deleteObjectsInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "DeleteObjects", deleteObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsResponse CreateRelations(Teamcenter.Services.Strong.Core._2006_03.DataManagement.Relationship[] Input)
	{
		try
		{
			restSender.PushRequestId();
			CreateRelationsInput createRelationsInput = new CreateRelationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createRelationsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "CreateRelations", createRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateRelationsResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateRelationsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData DeleteRelations(Teamcenter.Services.Strong.Core._2006_03.DataManagement.Relationship[] Input)
	{
		try
		{
			restSender.PushRequestId();
			DeleteRelationsInput deleteRelationsInput = new DeleteRelationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			deleteRelationsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200603_PORT_NAME, "DeleteRelations", deleteRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateFormsOutput toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateFormsOutput local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateFormsOutput createFormsOutput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateFormsOutput();
		createFormsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Form == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Form.Uid);
		}
		createFormsOutput.setForm(modelObject);
		return createFormsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateFormsOutput toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateFormsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateFormsOutput createFormsOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateFormsOutput();
		createFormsOutput.ClientId = wire.getClientId();
		createFormsOutput.Form = modelManager.LoadObjectData(wire.getForm());
		return createFormsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateOrUpdateFormsResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateOrUpdateFormsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateOrUpdateFormsResponse createOrUpdateFormsResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateOrUpdateFormsResponse();
		createOrUpdateFormsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList outputs = wire.getOutputs();
		createOrUpdateFormsResponse.Outputs = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateFormsOutput[outputs.Count];
		for (int i = 0; i < outputs.Count; i++)
		{
			createOrUpdateFormsResponse.Outputs[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateFormsOutput)outputs[i], modelManager);
		}
		return createOrUpdateFormsResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.FormAttributesInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormAttributesInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.FormAttributesInfo formAttributesInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.FormAttributesInfo();
		formAttributesInfo.setFormType(local.FormType);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.FormPDs.Length; i++)
		{
			arrayList.Add(toWire(local.FormPDs[i]));
		}
		formAttributesInfo.setFormPDs(arrayList);
		return formAttributesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormAttributesInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.FormAttributesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormAttributesInfo formAttributesInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormAttributesInfo();
		formAttributesInfo.FormType = wire.getFormType();
		IList formPDs = wire.getFormPDs();
		formAttributesInfo.FormPDs = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormPropDescriptor[formPDs.Count];
		for (int i = 0; i < formPDs.Count; i++)
		{
			formAttributesInfo.FormPDs[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.FormPropDescriptor)formPDs[i], modelManager);
		}
		return formAttributesInfo;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.FormInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.FormInfo formInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.FormInfo();
		formInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.FormObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.FormObject.Uid);
		}
		formInfo.setFormObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ParentObject == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ParentObject.Uid);
		}
		formInfo.setParentObject(modelObject2);
		formInfo.setRelationName(local.RelationName);
		formInfo.setSaveDB(local.SaveDB);
		formInfo.setName(local.Name);
		formInfo.setDescription(local.Description);
		formInfo.setFormType(local.FormType);
		formInfo.setAttributesMap(toWireStringArrayMap(local.AttributesMap));
		return formInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.FormInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormInfo formInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormInfo();
		formInfo.ClientId = wire.getClientId();
		formInfo.FormObject = modelManager.LoadObjectData(wire.getFormObject());
		formInfo.ParentObject = modelManager.LoadObjectData(wire.getParentObject());
		formInfo.RelationName = wire.getRelationName();
		formInfo.SaveDB = wire.SaveDB;
		formInfo.Name = wire.getName();
		formInfo.Description = wire.getDescription();
		formInfo.FormType = wire.getFormType();
		formInfo.AttributesMap = toLocalStringArrayMap(wire.getAttributesMap(), modelManager);
		return formInfo;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.FormPropDescriptor toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormPropDescriptor local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.FormPropDescriptor formPropDescriptor = new Teamcenter.Schemas.Core._2007_01.Datamanagement.FormPropDescriptor();
		formPropDescriptor.setPropName(local.PropName);
		formPropDescriptor.setDisplayName(local.DisplayName);
		formPropDescriptor.setPropValueType(local.PropValueType);
		formPropDescriptor.setPropType(local.PropType);
		formPropDescriptor.setIsDisplayable(local.IsDisplayable);
		formPropDescriptor.setIsArray(local.IsArray);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		formPropDescriptor.setLov(modelObject);
		formPropDescriptor.setIsRequired(local.IsRequired);
		formPropDescriptor.setIsEnabled(local.IsEnabled);
		formPropDescriptor.setIsModifiable(local.IsModifiable);
		formPropDescriptor.setAttachedSpecifier(local.AttachedSpecifier);
		formPropDescriptor.setMaxLength(local.MaxLength);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.InterdependentProps.Length; i++)
		{
			arrayList.Add(local.InterdependentProps[i]);
		}
		formPropDescriptor.setInterdependentProps(arrayList);
		return formPropDescriptor;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormPropDescriptor toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.FormPropDescriptor wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormPropDescriptor formPropDescriptor = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormPropDescriptor();
		formPropDescriptor.PropName = wire.getPropName();
		formPropDescriptor.DisplayName = wire.getDisplayName();
		formPropDescriptor.PropValueType = wire.getPropValueType();
		formPropDescriptor.PropType = wire.getPropType();
		formPropDescriptor.IsDisplayable = wire.IsDisplayable;
		formPropDescriptor.IsArray = wire.IsArray;
		formPropDescriptor.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		formPropDescriptor.IsRequired = wire.IsRequired;
		formPropDescriptor.IsEnabled = wire.IsEnabled;
		formPropDescriptor.IsModifiable = wire.IsModifiable;
		formPropDescriptor.AttachedSpecifier = wire.getAttachedSpecifier();
		formPropDescriptor.MaxLength = wire.getMaxLength();
		IList interdependentProps = wire.getInterdependentProps();
		formPropDescriptor.InterdependentProps = new string[interdependentProps.Count];
		for (int i = 0; i < interdependentProps.Count; i++)
		{
			formPropDescriptor.InterdependentProps[i] = Convert.ToString(interdependentProps[i]);
		}
		return formPropDescriptor;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GenerateUIDResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GenerateUIDResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GenerateUIDResponse generateUIDResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GenerateUIDResponse();
		generateUIDResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList uids = wire.getUids();
		generateUIDResponse.Uids = new string[uids.Count];
		for (int i = 0; i < uids.Count; i++)
		{
			generateUIDResponse.Uids[i] = Convert.ToString(uids[i]);
		}
		return generateUIDResponse;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetDatasetCreationRelatedInfoResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetDatasetCreationRelatedInfoResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetDatasetCreationRelatedInfoResponse getDatasetCreationRelatedInfoResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetDatasetCreationRelatedInfoResponse();
		getDatasetCreationRelatedInfoResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList toolNames = wire.getToolNames();
		getDatasetCreationRelatedInfoResponse.ToolNames = new string[toolNames.Count];
		for (int i = 0; i < toolNames.Count; i++)
		{
			getDatasetCreationRelatedInfoResponse.ToolNames[i] = Convert.ToString(toolNames[i]);
		}
		getDatasetCreationRelatedInfoResponse.NewDatasetName = wire.getNewDatasetName();
		getDatasetCreationRelatedInfoResponse.NameCanBeModified = wire.NameCanBeModified;
		IList initValuePropertyRules = wire.getInitValuePropertyRules();
		getDatasetCreationRelatedInfoResponse.InitValuePropertyRules = new string[initValuePropertyRules.Count];
		for (int i = 0; i < initValuePropertyRules.Count; i++)
		{
			getDatasetCreationRelatedInfoResponse.InitValuePropertyRules[i] = Convert.ToString(initValuePropertyRules[i]);
		}
		return getDatasetCreationRelatedInfoResponse;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemCreationRelatedInfoResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemCreationRelatedInfoResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemCreationRelatedInfoResponse getItemCreationRelatedInfoResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemCreationRelatedInfoResponse();
		getItemCreationRelatedInfoResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList complexValuePropertyRules = wire.getComplexValuePropertyRules();
		getItemCreationRelatedInfoResponse.ComplexValuePropertyRules = new string[complexValuePropertyRules.Count];
		for (int i = 0; i < complexValuePropertyRules.Count; i++)
		{
			getItemCreationRelatedInfoResponse.ComplexValuePropertyRules[i] = Convert.ToString(complexValuePropertyRules[i]);
		}
		IList initValuePropertyRules = wire.getInitValuePropertyRules();
		getItemCreationRelatedInfoResponse.InitValuePropertyRules = new string[initValuePropertyRules.Count];
		for (int i = 0; i < initValuePropertyRules.Count; i++)
		{
			getItemCreationRelatedInfoResponse.InitValuePropertyRules[i] = Convert.ToString(initValuePropertyRules[i]);
		}
		getItemCreationRelatedInfoResponse.PatternMap = toLocalStringArrayMap(wire.getPatternMap(), modelManager);
		IList uoms = wire.getUoms();
		getItemCreationRelatedInfoResponse.Uoms = new string[uoms.Count];
		for (int i = 0; i < uoms.Count; i++)
		{
			getItemCreationRelatedInfoResponse.Uoms[i] = Convert.ToString(uoms[i]);
		}
		IList formAttrs = wire.getFormAttrs();
		getItemCreationRelatedInfoResponse.FormAttrs = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormAttributesInfo[formAttrs.Count];
		for (int i = 0; i < formAttrs.Count; i++)
		{
			getItemCreationRelatedInfoResponse.FormAttrs[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.FormAttributesInfo)formAttrs[i], modelManager);
		}
		getItemCreationRelatedInfoResponse.RevTypeName = wire.getRevTypeName();
		return getItemCreationRelatedInfoResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdInfo getItemFromIdInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdInfo();
		getItemFromIdInfo.setItemId(local.ItemId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RevIds.Length; i++)
		{
			arrayList.Add(local.RevIds[i]);
		}
		getItemFromIdInfo.setRevIds(arrayList);
		return getItemFromIdInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdInfo getItemFromIdInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdInfo();
		getItemFromIdInfo.ItemId = wire.getItemId();
		IList revIds = wire.getRevIds();
		getItemFromIdInfo.RevIds = new string[revIds.Count];
		for (int i = 0; i < revIds.Count; i++)
		{
			getItemFromIdInfo.RevIds[i] = Convert.ToString(revIds[i]);
		}
		return getItemFromIdInfo;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemOutput toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemOutput local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemOutput getItemFromIdItemOutput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		getItemFromIdItemOutput.setItem(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemRevOutput.Length; i++)
		{
			arrayList.Add(toWire(local.ItemRevOutput[i]));
		}
		getItemFromIdItemOutput.setItemRevOutput(arrayList);
		return getItemFromIdItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemOutput toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemOutput getItemFromIdItemOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemOutput();
		getItemFromIdItemOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		IList itemRevOutput = wire.getItemRevOutput();
		getItemFromIdItemOutput.ItemRevOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemRevOutput[itemRevOutput.Count];
		for (int i = 0; i < itemRevOutput.Count; i++)
		{
			getItemFromIdItemOutput.ItemRevOutput[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemRevOutput)itemRevOutput[i], modelManager);
		}
		return getItemFromIdItemOutput;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemRevOutput toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemRevOutput local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemRevOutput getItemFromIdItemRevOutput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemRevOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		getItemFromIdItemRevOutput.setItemRevision(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Datasets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Datasets[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Datasets[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		getItemFromIdItemRevOutput.setDatasets(arrayList);
		return getItemFromIdItemRevOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemRevOutput toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemRevOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemRevOutput getItemFromIdItemRevOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemRevOutput();
		getItemFromIdItemRevOutput.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		IList datasets = wire.getDatasets();
		getItemFromIdItemRevOutput.Datasets = new Dataset[datasets.Count];
		for (int i = 0; i < datasets.Count; i++)
		{
			getItemFromIdItemRevOutput.Datasets[i] = (Dataset)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)datasets[i]);
		}
		return getItemFromIdItemRevOutput;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdPref toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdPref local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdPref getItemFromIdPref = new Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdPref();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Prefs.Length; i++)
		{
			arrayList.Add(toWire(local.Prefs[i]));
		}
		getItemFromIdPref.setPrefs(arrayList);
		return getItemFromIdPref;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdPref toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdPref getItemFromIdPref = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdPref();
		IList prefs = wire.getPrefs();
		getItemFromIdPref.Prefs = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.RelationFilter[prefs.Count];
		for (int i = 0; i < prefs.Count; i++)
		{
			getItemFromIdPref.Prefs[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.RelationFilter)prefs[i], modelManager);
		}
		return getItemFromIdPref;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdResponse getItemFromIdResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdResponse();
		getItemFromIdResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getItemFromIdResponse.Output = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdItemOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getItemFromIdResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdItemOutput)output[i], modelManager);
		}
		return getItemFromIdResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderInfo moveToNewFolderInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OldFolder == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OldFolder.Uid);
		}
		moveToNewFolderInfo.setOldFolder(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.NewFolder == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.NewFolder.Uid);
		}
		moveToNewFolderInfo.setNewFolder(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectsToMove.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ObjectsToMove[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.ObjectsToMove[i].Uid);
			}
			arrayList.Add(modelObject3);
		}
		moveToNewFolderInfo.setObjectsToMove(arrayList);
		return moveToNewFolderInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderInfo moveToNewFolderInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderInfo();
		moveToNewFolderInfo.OldFolder = (Folder)modelManager.LoadObjectData(wire.getOldFolder());
		moveToNewFolderInfo.NewFolder = (Folder)modelManager.LoadObjectData(wire.getNewFolder());
		IList objectsToMove = wire.getObjectsToMove();
		moveToNewFolderInfo.ObjectsToMove = new Teamcenter.Soa.Client.Model.ModelObject[objectsToMove.Count];
		for (int i = 0; i < objectsToMove.Count; i++)
		{
			moveToNewFolderInfo.ObjectsToMove[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objectsToMove[i]);
		}
		return moveToNewFolderInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderResponse moveToNewFolderResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderResponse();
		moveToNewFolderResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return moveToNewFolderResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.RelationFilter toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.RelationFilter local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.RelationFilter relationFilter = new Teamcenter.Schemas.Core._2007_01.Datamanagement.RelationFilter();
		relationFilter.setRelationTypeName(local.RelationTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectTypeNames.Length; i++)
		{
			arrayList.Add(local.ObjectTypeNames[i]);
		}
		relationFilter.setObjectTypeNames(arrayList);
		return relationFilter;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.RelationFilter toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.RelationFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.RelationFilter relationFilter = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.RelationFilter();
		relationFilter.RelationTypeName = wire.getRelationTypeName();
		IList objectTypeNames = wire.getObjectTypeNames();
		relationFilter.ObjectTypeNames = new string[objectTypeNames.Count];
		for (int i = 0; i < objectTypeNames.Count; i++)
		{
			relationFilter.ObjectTypeNames[i] = Convert.ToString(objectTypeNames[i]);
		}
		return relationFilter;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemInfo saveAsNewItemInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemInfo();
		saveAsNewItemInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		saveAsNewItemInfo.setItemRevision(modelObject);
		saveAsNewItemInfo.setItemId(local.ItemId);
		saveAsNewItemInfo.setRevId(local.RevId);
		saveAsNewItemInfo.setName(local.Name);
		saveAsNewItemInfo.setDescription(local.Description);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Folder.Uid);
		}
		saveAsNewItemInfo.setFolder(modelObject2);
		return saveAsNewItemInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemInfo saveAsNewItemInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemInfo();
		saveAsNewItemInfo.ClientId = wire.getClientId();
		saveAsNewItemInfo.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		saveAsNewItemInfo.ItemId = wire.getItemId();
		saveAsNewItemInfo.RevId = wire.getRevId();
		saveAsNewItemInfo.Name = wire.getName();
		saveAsNewItemInfo.Description = wire.getDescription();
		saveAsNewItemInfo.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		return saveAsNewItemInfo;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemOutput toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemOutput local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemOutput saveAsNewItemOutput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		saveAsNewItemOutput.setItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		saveAsNewItemOutput.setItemRev(modelObject2);
		return saveAsNewItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemOutput toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemOutput saveAsNewItemOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemOutput();
		saveAsNewItemOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		saveAsNewItemOutput.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		return saveAsNewItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemResponse saveAsNewItemResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemResponse();
		saveAsNewItemResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		saveAsNewItemResponse.InputToNewItem = toLocalInputToNewItemMap(wire.getInputToNewItem(), modelManager);
		return saveAsNewItemResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.VecStruct toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.VecStruct local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.VecStruct vecStruct = new Teamcenter.Schemas.Core._2007_01.Datamanagement.VecStruct();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.StringVec.Length; i++)
		{
			arrayList.Add(local.StringVec[i]);
		}
		vecStruct.setStringVec(arrayList);
		return vecStruct;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.VecStruct toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.VecStruct wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.VecStruct vecStruct = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.VecStruct();
		IList stringVec = wire.getStringVec();
		vecStruct.StringVec = new string[stringVec.Count];
		for (int i = 0; i < stringVec.Count; i++)
		{
			vecStruct.StringVec[i] = Convert.ToString(stringVec[i]);
		}
		return vecStruct;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedInfo whereReferencedInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Referencer == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Referencer.Uid);
		}
		whereReferencedInfo.setReferencer(modelObject);
		whereReferencedInfo.setRelation(local.Relation);
		whereReferencedInfo.setLevel(local.Level);
		return whereReferencedInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedInfo whereReferencedInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedInfo();
		whereReferencedInfo.Referencer = (WorkspaceObject)modelManager.LoadObjectData(wire.getReferencer());
		whereReferencedInfo.Relation = wire.getRelation();
		whereReferencedInfo.Level = wire.getLevel();
		return whereReferencedInfo;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedOutput toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedOutput local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedOutput whereReferencedOutput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		whereReferencedOutput.setInputObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		whereReferencedOutput.setInfo(arrayList);
		return whereReferencedOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedOutput toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedOutput whereReferencedOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedOutput();
		whereReferencedOutput.InputObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getInputObject());
		IList info = wire.getInfo();
		whereReferencedOutput.Info = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedInfo[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			whereReferencedOutput.Info[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedInfo)info[i], modelManager);
		}
		return whereReferencedOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedResponse whereReferencedResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedResponse();
		whereReferencedResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		whereReferencedResponse.Output = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			whereReferencedResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedOutput)output[i], modelManager);
		}
		return whereReferencedResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedOutput toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedOutput local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedOutput whereUsedOutput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		whereUsedOutput.setInputObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		whereUsedOutput.setInfo(arrayList);
		return whereUsedOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedOutput toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedOutput whereUsedOutput = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedOutput();
		whereUsedOutput.InputObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getInputObject());
		IList info = wire.getInfo();
		whereUsedOutput.Info = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedParentInfo[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			whereUsedOutput.Info[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedParentInfo)info[i], modelManager);
		}
		return whereUsedOutput;
	}

	public static Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedParentInfo toWire(Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedParentInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedParentInfo whereUsedParentInfo = new Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedParentInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ParentItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ParentItemRev.Uid);
		}
		whereUsedParentInfo.setParentItemRev(modelObject);
		whereUsedParentInfo.setLevel(local.Level);
		return whereUsedParentInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedParentInfo toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedParentInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedParentInfo whereUsedParentInfo = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedParentInfo();
		whereUsedParentInfo.ParentItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getParentItemRev());
		whereUsedParentInfo.Level = wire.getLevel();
		return whereUsedParentInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedResponse toLocal(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedResponse whereUsedResponse = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedResponse();
		whereUsedResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		whereUsedResponse.Output = new Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			whereUsedResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedOutput)output[i], modelManager);
		}
		return whereUsedResponse;
	}

	public static ArrayList toWireInputToNewItemMap(IDictionary InputToNewItemMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in InputToNewItemMap)
		{
			object key = item.Key;
			object value = item.Value;
			InputToNewItemMap inputToNewItemMap = new InputToNewItemMap();
			inputToNewItemMap.setKey(Convert.ToString(key));
			inputToNewItemMap.setValue(toWire((Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemOutput)value));
			arrayList.Add(inputToNewItemMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalInputToNewItemMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			InputToNewItemMap inputToNewItemMap = (InputToNewItemMap)wire[i];
			string key = inputToNewItemMap.getKey();
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemOutput value = toLocal(inputToNewItemMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireNameValueMap(IDictionary NameValueMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in NameValueMap)
		{
			object key = item.Key;
			object value = item.Value;
			NameValueMap nameValueMap = new NameValueMap();
			nameValueMap.setKey(Convert.ToString(key));
			nameValueMap.setValue(toWire((Teamcenter.Services.Strong.Core._2007_01.DataManagement.VecStruct)value));
			arrayList.Add(nameValueMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalNameValueMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			NameValueMap nameValueMap = (NameValueMap)wire[i];
			string key = nameValueMap.getKey();
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.VecStruct value = toLocal(nameValueMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireStringArrayMap(IDictionary StringArrayMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in StringArrayMap)
		{
			object key = item.Key;
			object value = item.Value;
			StringArrayMap stringArrayMap = new StringArrayMap();
			stringArrayMap.setKey(Convert.ToString(key));
			IList value2 = stringArrayMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			stringArrayMap.setValue((ArrayList)value2);
			arrayList.Add(stringArrayMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalStringArrayMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			StringArrayMap stringArrayMap = (StringArrayMap)wire[i];
			string key = stringArrayMap.getKey();
			IList value = stringArrayMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData SetProperties(Teamcenter.Soa.Client.Model.ModelObject[] Objects, Hashtable Attributes)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.SetPropertiesInput setPropertiesInput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.SetPropertiesInput();
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
			setPropertiesInput.setObjects(arrayList);
			setPropertiesInput.setAttributes(toWireNameValueMap(Attributes));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "SetProperties", setPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.GenerateUIDResponse GenerateUID(int NUID)
	{
		try
		{
			restSender.PushRequestId();
			GenerateUIDInput generateUIDInput = new GenerateUIDInput();
			generateUIDInput.setNUID(NUID);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.GenerateUIDResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GenerateUID", generateUIDInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.GenerateUIDResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.GenerateUIDResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.GenerateUIDResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetDatasetCreationRelatedInfoResponse GetDatasetCreationRelatedInfo(string TypeName, Teamcenter.Soa.Client.Model.ModelObject ParentObject)
	{
		try
		{
			restSender.PushRequestId();
			GetDatasetCreationRelatedInfoInput getDatasetCreationRelatedInfoInput = new GetDatasetCreationRelatedInfoInput();
			getDatasetCreationRelatedInfoInput.setTypeName(TypeName);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (ParentObject == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(ParentObject.Uid);
			}
			getDatasetCreationRelatedInfoInput.setParentObject(modelObject);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetDatasetCreationRelatedInfoResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GetDatasetCreationRelatedInfo", getDatasetCreationRelatedInfoInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.GetDatasetCreationRelatedInfoResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.GetDatasetCreationRelatedInfoResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetDatasetCreationRelatedInfoResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderResponse MoveToNewFolder(Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderInfo[] MoveToNewFolderInfos)
	{
		try
		{
			restSender.PushRequestId();
			MoveToNewFolderInput moveToNewFolderInput = new MoveToNewFolderInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < MoveToNewFolderInfos.Length; i++)
			{
				arrayList.Add(toWire(MoveToNewFolderInfos[i]));
			}
			moveToNewFolderInput.setMoveToNewFolderInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "MoveToNewFolder", moveToNewFolderInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.MoveToNewFolderResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.MoveToNewFolderResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateOrUpdateFormsResponse CreateOrUpdateForms(Teamcenter.Services.Strong.Core._2007_01.DataManagement.FormInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateFormsInput createOrUpdateFormsInput = new CreateOrUpdateFormsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdateFormsInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateOrUpdateFormsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "CreateOrUpdateForms", createOrUpdateFormsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateOrUpdateFormsResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.CreateOrUpdateFormsResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.CreateOrUpdateFormsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemCreationRelatedInfoResponse GetItemCreationRelatedInfo(string TypeName, Teamcenter.Soa.Client.Model.ModelObject ParentObject)
	{
		try
		{
			restSender.PushRequestId();
			GetItemCreationRelatedInfoInput getItemCreationRelatedInfoInput = new GetItemCreationRelatedInfoInput();
			getItemCreationRelatedInfoInput.setTypeName(TypeName);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (ParentObject == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(ParentObject.Uid);
			}
			getItemCreationRelatedInfoInput.setParentObject(modelObject);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemCreationRelatedInfoResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GetItemCreationRelatedInfo", getItemCreationRelatedInfoInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemCreationRelatedInfoResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemCreationRelatedInfoResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemCreationRelatedInfoResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Tc 8, use the getItemAndRelatedObjects operation.", false)]
	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdResponse GetItemFromId(Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdInfo[] Infos, int NRev, Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			GetItemFromIdInput getItemFromIdInput = new GetItemFromIdInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Infos.Length; i++)
			{
				arrayList.Add(toWire(Infos[i]));
			}
			getItemFromIdInput.setInfos(arrayList);
			getItemFromIdInput.setNRev(NRev);
			getItemFromIdInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "GetItemFromId", getItemFromIdInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.GetItemFromIdResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Tc 8, use the saveAsNewItem2 operation.", false)]
	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemResponse SaveAsNewItem(Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			SaveAsNewItemInput saveAsNewItemInput = new SaveAsNewItemInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			saveAsNewItemInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "SaveAsNewItem", saveAsNewItemInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.SaveAsNewItemResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.SaveAsNewItemResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedResponse WhereReferenced(WorkspaceObject[] Objects, int NumLevels)
	{
		try
		{
			restSender.PushRequestId();
			WhereReferencedInput whereReferencedInput = new WhereReferencedInput();
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
			whereReferencedInput.setObjects(arrayList);
			whereReferencedInput.setNumLevels(NumLevels);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "WhereReferenced", whereReferencedInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereReferencedResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereReferencedResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData RefreshObjects(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			RefreshObjectsInput refreshObjectsInput = new RefreshObjectsInput();
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
			refreshObjectsInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "RefreshObjects", refreshObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	[Obsolete("As of Teamcenter 9.1, use the whereUsed operation from the _2012_02 namespace.", false)]
	public override Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedResponse WhereUsed(Teamcenter.Soa.Client.Model.ModelObject[] Objects, int NumLevels, bool WhereUsedPrecise, Teamcenter.Soa.Client.Model.ModelObject Rule)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedInput whereUsedInput = new Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedInput();
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
			whereUsedInput.setObjects(arrayList);
			whereUsedInput.setNumLevels(NumLevels);
			whereUsedInput.setWhereUsedPrecise(WhereUsedPrecise);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Rule == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(Rule.Uid);
			}
			whereUsedInput.setRule(modelObject2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200701_PORT_NAME, "WhereUsed", whereUsedInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedResponse wire = (Teamcenter.Schemas.Core._2007_01.Datamanagement.WhereUsedResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.DataManagement.WhereUsedResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.AvailableTypeInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.AvailableTypeInfo availableTypeInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.AvailableTypeInfo();
		availableTypeInfo.setType(local.Type);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Hierarchies.Length; i++)
		{
			arrayList.Add(local.Hierarchies[i]);
		}
		availableTypeInfo.setHierarchies(arrayList);
		return availableTypeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.AvailableTypeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo availableTypeInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo();
		availableTypeInfo.Type = wire.getType();
		IList hierarchies = wire.getHierarchies();
		availableTypeInfo.Hierarchies = new string[hierarchies.Count];
		for (int i = 0; i < hierarchies.Count; i++)
		{
			availableTypeInfo.Hierarchies[i] = Convert.ToString(hierarchies[i]);
		}
		return availableTypeInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.BaseClassInput toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.BaseClassInput local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.BaseClassInput baseClassInput = new Teamcenter.Schemas.Core._2007_06.Datamanagement.BaseClassInput();
		baseClassInput.setBaseClass(local.BaseClass);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ExclusionTypes.Length; i++)
		{
			arrayList.Add(local.ExclusionTypes[i]);
		}
		baseClassInput.setExclusionTypes(arrayList);
		return baseClassInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.BaseClassInput toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.BaseClassInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.BaseClassInput baseClassInput = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.BaseClassInput();
		baseClassInput.BaseClass = wire.getBaseClass();
		IList exclusionTypes = wire.getExclusionTypes();
		baseClassInput.ExclusionTypes = new string[exclusionTypes.Count];
		for (int i = 0; i < exclusionTypes.Count; i++)
		{
			baseClassInput.ExclusionTypes[i] = Convert.ToString(exclusionTypes[i]);
		}
		return baseClassInput;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfo datasetTypeInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Tag == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Tag.Uid);
		}
		datasetTypeInfo.setTag(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RefInfos.Length; i++)
		{
			arrayList.Add(toWire(local.RefInfos[i]));
		}
		datasetTypeInfo.setRefInfos(arrayList);
		return datasetTypeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfo datasetTypeInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfo();
		datasetTypeInfo.Tag = (Teamcenter.Soa.Client.Model.Strong.DatasetType)modelManager.LoadObjectData(wire.getTag());
		IList refInfos = wire.getRefInfos();
		datasetTypeInfo.RefInfos = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ReferenceInfo[refInfos.Count];
		for (int i = 0; i < refInfos.Count; i++)
		{
			datasetTypeInfo.RefInfos[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.ReferenceInfo)refInfos[i], modelManager);
		}
		return datasetTypeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfoResponse toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfoResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfoResponse datasetTypeInfoResponse = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfoResponse();
		datasetTypeInfoResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList infos = wire.getInfos();
		datasetTypeInfoResponse.Infos = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfo[infos.Count];
		for (int i = 0; i < infos.Count; i++)
		{
			datasetTypeInfoResponse.Infos[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfo)infos[i], modelManager);
		}
		return datasetTypeInfoResponse;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsData toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsData local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsData expandGRMRelationsData = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsData();
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

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsData toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsData expandGRMRelationsData = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsData();
		IList otherSideObjects = wire.getOtherSideObjects();
		expandGRMRelationsData.OtherSideObjects = new Teamcenter.Soa.Client.Model.ModelObject[otherSideObjects.Count];
		for (int i = 0; i < otherSideObjects.Count; i++)
		{
			expandGRMRelationsData.OtherSideObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)otherSideObjects[i]);
		}
		expandGRMRelationsData.RelationName = wire.getRelationName();
		return expandGRMRelationsData;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsOutput toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsOutput local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsOutput expandGRMRelationsOutput = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsOutput();
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

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsOutput toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsOutput expandGRMRelationsOutput = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsOutput();
		expandGRMRelationsOutput.InputObject = modelManager.LoadObjectData(wire.getInputObject());
		IList otherSideObjData = wire.getOtherSideObjData();
		expandGRMRelationsOutput.OtherSideObjData = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsData[otherSideObjData.Count];
		for (int i = 0; i < otherSideObjData.Count; i++)
		{
			expandGRMRelationsOutput.OtherSideObjData[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsData)otherSideObjData[i], modelManager);
		}
		return expandGRMRelationsOutput;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsPref toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsPref local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsPref expandGRMRelationsPref = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsPref();
		expandGRMRelationsPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandGRMRelationsPref.setInfo(arrayList);
		return expandGRMRelationsPref;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsPref toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsPref expandGRMRelationsPref = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsPref();
		expandGRMRelationsPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandGRMRelationsPref.Info = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter2[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandGRMRelationsPref.Info[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter2)info[i], modelManager);
		}
		return expandGRMRelationsPref;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse expandGRMRelationsResponse = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse();
		expandGRMRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandGRMRelationsResponse.Output = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandGRMRelationsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsOutput)output[i], modelManager);
		}
		return expandGRMRelationsResponse;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.GetAvailableTypesResponse toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.GetAvailableTypesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.GetAvailableTypesResponse getAvailableTypesResponse = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.GetAvailableTypesResponse();
		getAvailableTypesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getAvailableTypesResponse.InputClassToTypes = toLocalClassToTypesMap(wire.getInputClassToTypes(), modelManager);
		return getAvailableTypesResponse;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.PurgeSequencesInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.PurgeSequencesInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.PurgeSequencesInfo purgeSequencesInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.PurgeSequencesInfo();
		purgeSequencesInfo.setValidateLatestFlag(local.ValidateLatestFlag);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		purgeSequencesInfo.setInputObject(modelObject);
		return purgeSequencesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.PurgeSequencesInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.PurgeSequencesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.PurgeSequencesInfo purgeSequencesInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.PurgeSequencesInfo();
		purgeSequencesInfo.ValidateLatestFlag = wire.ValidateLatestFlag;
		purgeSequencesInfo.InputObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getInputObject());
		return purgeSequencesInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.ReferenceInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ReferenceInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.ReferenceInfo referenceInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ReferenceInfo();
		referenceInfo.setReferenceName(local.ReferenceName);
		referenceInfo.setIsObject(local.IsObject);
		referenceInfo.setFileFormat(local.FileFormat);
		referenceInfo.setFileExtension(local.FileExtension);
		return referenceInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ReferenceInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ReferenceInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ReferenceInfo referenceInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ReferenceInfo();
		referenceInfo.ReferenceName = wire.getReferenceName();
		referenceInfo.IsObject = wire.IsObject;
		referenceInfo.FileFormat = wire.getFileFormat();
		referenceInfo.FileExtension = wire.getFileExtension();
		return referenceInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter();
		relationAndTypesFilter.setRelationTypeName(local.RelationTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OtherSideObjectTypes.Length; i++)
		{
			arrayList.Add(local.OtherSideObjectTypes[i]);
		}
		relationAndTypesFilter.setOtherSideObjectTypes(arrayList);
		return relationAndTypesFilter;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter();
		relationAndTypesFilter.RelationTypeName = wire.getRelationTypeName();
		IList otherSideObjectTypes = wire.getOtherSideObjectTypes();
		relationAndTypesFilter.OtherSideObjectTypes = new string[otherSideObjectTypes.Count];
		for (int i = 0; i < otherSideObjectTypes.Count; i++)
		{
			relationAndTypesFilter.OtherSideObjectTypes[i] = Convert.ToString(otherSideObjectTypes[i]);
		}
		return relationAndTypesFilter;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter2 toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter2 local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter2 relationAndTypesFilter = new Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter2();
		relationAndTypesFilter.setRelationName(local.RelationName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectTypeNames.Length; i++)
		{
			arrayList.Add(local.ObjectTypeNames[i]);
		}
		relationAndTypesFilter.setObjectTypeNames(arrayList);
		return relationAndTypesFilter;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter2 toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter2 relationAndTypesFilter = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter2();
		relationAndTypesFilter.RelationName = wire.getRelationName();
		IList objectTypeNames = wire.getObjectTypeNames();
		relationAndTypesFilter.ObjectTypeNames = new string[objectTypeNames.Count];
		for (int i = 0; i < objectTypeNames.Count; i++)
		{
			relationAndTypesFilter.ObjectTypeNames[i] = Convert.ToString(objectTypeNames[i]);
		}
		return relationAndTypesFilter;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.SetOrRemoveImmunityInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.SetOrRemoveImmunityInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.SetOrRemoveImmunityInfo setOrRemoveImmunityInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.SetOrRemoveImmunityInfo();
		setOrRemoveImmunityInfo.setSetOrRemoveFlag(local.SetOrRemoveFlag);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		setOrRemoveImmunityInfo.setInputObject(modelObject);
		return setOrRemoveImmunityInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.SetOrRemoveImmunityInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.SetOrRemoveImmunityInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.SetOrRemoveImmunityInfo setOrRemoveImmunityInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.SetOrRemoveImmunityInfo();
		setOrRemoveImmunityInfo.SetOrRemoveFlag = wire.SetOrRemoveFlag;
		setOrRemoveImmunityInfo.InputObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getInputObject());
		return setOrRemoveImmunityInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsInfo validateIdsInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsInfo();
		validateIdsInfo.setItemId(local.ItemId);
		validateIdsInfo.setRevId(local.RevId);
		validateIdsInfo.setItemType(local.ItemType);
		return validateIdsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsInfo validateIdsInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsInfo();
		validateIdsInfo.ItemId = wire.getItemId();
		validateIdsInfo.RevId = wire.getRevId();
		validateIdsInfo.ItemType = wire.getItemType();
		return validateIdsInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsOutput toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsOutput local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsOutput validateIdsOutput = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsOutput();
		validateIdsOutput.setModItemId(local.ModItemId);
		validateIdsOutput.setItemIdStatus(local.ItemIdStatus);
		validateIdsOutput.setModRevId(local.ModRevId);
		validateIdsOutput.setRevIdStatus(local.RevIdStatus);
		return validateIdsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsOutput toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsOutput validateIdsOutput = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsOutput();
		validateIdsOutput.ModItemId = wire.getModItemId();
		validateIdsOutput.ItemIdStatus = wire.getItemIdStatus();
		validateIdsOutput.ModRevId = wire.getModRevId();
		validateIdsOutput.RevIdStatus = wire.getRevIdStatus();
		return validateIdsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateItemIdsAndRevIdsResponse toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateItemIdsAndRevIdsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateItemIdsAndRevIdsResponse validateItemIdsAndRevIdsResponse = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateItemIdsAndRevIdsResponse();
		validateItemIdsAndRevIdsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		validateItemIdsAndRevIdsResponse.Output = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			validateItemIdsAndRevIdsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateIdsOutput)output[i], modelManager);
		}
		return validateItemIdsAndRevIdsResponse;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameInfo whereReferencedByRelationNameInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		whereReferencedByRelationNameInfo.setObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Filter.Length; i++)
		{
			arrayList.Add(toWire(local.Filter[i]));
		}
		whereReferencedByRelationNameInfo.setFilter(arrayList);
		return whereReferencedByRelationNameInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameInfo whereReferencedByRelationNameInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameInfo();
		whereReferencedByRelationNameInfo.Object = modelManager.LoadObjectData(wire.getObject());
		IList filter = wire.getFilter();
		whereReferencedByRelationNameInfo.Filter = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter[filter.Count];
		for (int i = 0; i < filter.Count; i++)
		{
			whereReferencedByRelationNameInfo.Filter[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter)filter[i], modelManager);
		}
		return whereReferencedByRelationNameInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutput toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutput local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutput whereReferencedByRelationNameOutput = new Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		whereReferencedByRelationNameOutput.setInputObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		whereReferencedByRelationNameOutput.setInfo(arrayList);
		return whereReferencedByRelationNameOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutput toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutput whereReferencedByRelationNameOutput = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutput();
		whereReferencedByRelationNameOutput.InputObject = modelManager.LoadObjectData(wire.getInputObject());
		IList info = wire.getInfo();
		whereReferencedByRelationNameOutput.Info = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutputInfo[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			whereReferencedByRelationNameOutput.Info[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutputInfo)info[i], modelManager);
		}
		return whereReferencedByRelationNameOutput;
	}

	public static Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutputInfo toWire(Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutputInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutputInfo whereReferencedByRelationNameOutputInfo = new Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutputInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Referencer == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Referencer.Uid);
		}
		whereReferencedByRelationNameOutputInfo.setReferencer(modelObject);
		whereReferencedByRelationNameOutputInfo.setRelationTypeName(local.RelationTypeName);
		whereReferencedByRelationNameOutputInfo.setLevel(local.Level);
		return whereReferencedByRelationNameOutputInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutputInfo toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutputInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutputInfo whereReferencedByRelationNameOutputInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutputInfo();
		whereReferencedByRelationNameOutputInfo.Referencer = modelManager.LoadObjectData(wire.getReferencer());
		whereReferencedByRelationNameOutputInfo.RelationTypeName = wire.getRelationTypeName();
		whereReferencedByRelationNameOutputInfo.Level = wire.getLevel();
		return whereReferencedByRelationNameOutputInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameResponse toLocal(Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameResponse whereReferencedByRelationNameResponse = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameResponse();
		whereReferencedByRelationNameResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		whereReferencedByRelationNameResponse.Output = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			whereReferencedByRelationNameResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameOutput)output[i], modelManager);
		}
		return whereReferencedByRelationNameResponse;
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
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo[] array = (Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
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
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo[] array = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.AvailableTypeInfo[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.AvailableTypeInfo)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse ExpandGRMRelationsForPrimary(Teamcenter.Soa.Client.Model.ModelObject[] PrimaryObjects, Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsForPrimaryInput expandGRMRelationsForPrimaryInput = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsForPrimaryInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PrimaryObjects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (PrimaryObjects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(PrimaryObjects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandGRMRelationsForPrimaryInput.setPrimaryObjects(arrayList);
			expandGRMRelationsForPrimaryInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "ExpandGRMRelationsForPrimary", expandGRMRelationsForPrimaryInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse wire = (Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_06.DataManagement.GetAvailableTypesResponse GetAvailableTypes(Teamcenter.Services.Strong.Core._2007_06.DataManagement.BaseClassInput[] Classes)
	{
		try
		{
			restSender.PushRequestId();
			GetAvailableTypesInput getAvailableTypesInput = new GetAvailableTypesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Classes.Length; i++)
			{
				arrayList.Add(toWire(Classes[i]));
			}
			getAvailableTypesInput.setClasses(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Datamanagement.GetAvailableTypesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "GetAvailableTypes", getAvailableTypesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.GetAvailableTypesResponse wire = (Teamcenter.Schemas.Core._2007_06.Datamanagement.GetAvailableTypesResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.GetAvailableTypesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData PurgeSequences(Teamcenter.Services.Strong.Core._2007_06.DataManagement.PurgeSequencesInfo[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			PurgeSequencesInput purgeSequencesInput = new PurgeSequencesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Objects.Length; i++)
			{
				arrayList.Add(toWire(Objects[i]));
			}
			purgeSequencesInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "PurgeSequences", purgeSequencesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Soa.Client.Model.ServiceData SetOrRemoveImmunity(Teamcenter.Services.Strong.Core._2007_06.DataManagement.SetOrRemoveImmunityInfo[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			SetOrRemoveImmunityInput setOrRemoveImmunityInput = new SetOrRemoveImmunityInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Objects.Length; i++)
			{
				arrayList.Add(toWire(Objects[i]));
			}
			setOrRemoveImmunityInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "SetOrRemoveImmunity", setOrRemoveImmunityInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfoResponse GetDatasetTypeInfo(string[] DatasetTypeNames)
	{
		try
		{
			restSender.PushRequestId();
			GetDatasetTypeInfoInput getDatasetTypeInfoInput = new GetDatasetTypeInfoInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < DatasetTypeNames.Length; i++)
			{
				arrayList.Add(DatasetTypeNames[i]);
			}
			getDatasetTypeInfoInput.setDatasetTypeNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfoResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "GetDatasetTypeInfo", getDatasetTypeInfoInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfoResponse wire = (Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfoResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfoResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Teamcenter 10.1, use the validateValues operation.", false)]
	public override Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateItemIdsAndRevIdsResponse ValidateItemIdsAndRevIds(Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateIdsInfo[] Infos)
	{
		try
		{
			restSender.PushRequestId();
			ValidateItemIdsAndRevIdsInput validateItemIdsAndRevIdsInput = new ValidateItemIdsAndRevIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Infos.Length; i++)
			{
				arrayList.Add(toWire(Infos[i]));
			}
			validateItemIdsAndRevIdsInput.setInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateItemIdsAndRevIdsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "ValidateItemIdsAndRevIds", validateItemIdsAndRevIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateItemIdsAndRevIdsResponse wire = (Teamcenter.Schemas.Core._2007_06.Datamanagement.ValidateItemIdsAndRevIdsResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.ValidateItemIdsAndRevIdsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse ExpandGRMRelationsForSecondary(Teamcenter.Soa.Client.Model.ModelObject[] SecondaryObjects, Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsForSecondaryInput expandGRMRelationsForSecondaryInput = new Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsForSecondaryInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < SecondaryObjects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (SecondaryObjects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(SecondaryObjects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandGRMRelationsForSecondaryInput.setSecondaryObjects(arrayList);
			expandGRMRelationsForSecondaryInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "ExpandGRMRelationsForSecondary", expandGRMRelationsForSecondaryInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse wire = (Teamcenter.Schemas.Core._2007_06.Datamanagement.ExpandGRMRelationsResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.ExpandGRMRelationsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameResponse WhereReferencedByRelationName(Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameInfo[] Inputs, int NumLevels)
	{
		try
		{
			restSender.PushRequestId();
			WhereReferencedByRelationNameInput whereReferencedByRelationNameInput = new WhereReferencedByRelationNameInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			whereReferencedByRelationNameInput.setInputs(arrayList);
			whereReferencedByRelationNameInput.setNumLevels(NumLevels);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200706_PORT_NAME, "WhereReferencedByRelationName", whereReferencedByRelationNameInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameResponse wire = (Teamcenter.Schemas.Core._2007_06.Datamanagement.WhereReferencedByRelationNameResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.DataManagement.WhereReferencedByRelationNameResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsData2 toWire(Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsData2 local)
	{
		Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsData2 expandGRMRelationsData = new Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsData2();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelationshipObjects.Length; i++)
		{
			arrayList.Add(toWire(local.RelationshipObjects[i]));
		}
		expandGRMRelationsData.setRelationshipObjects(arrayList);
		expandGRMRelationsData.setRelationName(local.RelationName);
		return expandGRMRelationsData;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsData2 toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsData2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsData2 expandGRMRelationsData = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsData2();
		IList relationshipObjects = wire.getRelationshipObjects();
		expandGRMRelationsData.RelationshipObjects = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationship[relationshipObjects.Count];
		for (int i = 0; i < relationshipObjects.Count; i++)
		{
			expandGRMRelationsData.RelationshipObjects[i] = toLocal((Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationship)relationshipObjects[i], modelManager);
		}
		expandGRMRelationsData.RelationName = wire.getRelationName();
		return expandGRMRelationsData;
	}

	public static Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationship toWire(Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationship local)
	{
		Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationship expandGRMRelationship = new Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationship();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OtherSideObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OtherSideObject.Uid);
		}
		expandGRMRelationship.setOtherSideObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Relation == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Relation.Uid);
		}
		expandGRMRelationship.setRelation(modelObject2);
		return expandGRMRelationship;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationship toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationship wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationship expandGRMRelationship = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationship();
		expandGRMRelationship.OtherSideObject = modelManager.LoadObjectData(wire.getOtherSideObject());
		expandGRMRelationship.Relation = (ImanRelation)modelManager.LoadObjectData(wire.getRelation());
		return expandGRMRelationship;
	}

	public static Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsOutput2 toWire(Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsOutput2 local)
	{
		Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsOutput2 expandGRMRelationsOutput = new Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsOutput2();
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
		for (int i = 0; i < local.RelationshipData.Length; i++)
		{
			arrayList.Add(toWire(local.RelationshipData[i]));
		}
		expandGRMRelationsOutput.setRelationshipData(arrayList);
		return expandGRMRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsOutput2 toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsOutput2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsOutput2 expandGRMRelationsOutput = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsOutput2();
		expandGRMRelationsOutput.InputObject = modelManager.LoadObjectData(wire.getInputObject());
		IList relationshipData = wire.getRelationshipData();
		expandGRMRelationsOutput.RelationshipData = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsData2[relationshipData.Count];
		for (int i = 0; i < relationshipData.Count; i++)
		{
			expandGRMRelationsOutput.RelationshipData[i] = toLocal((Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsData2)relationshipData[i], modelManager);
		}
		return expandGRMRelationsOutput;
	}

	public static Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsPref2 toWire(Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsPref2 local)
	{
		Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsPref2 expandGRMRelationsPref = new Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsPref2();
		expandGRMRelationsPref.setExpItemRev(local.ExpItemRev);
		expandGRMRelationsPref.setReturnRelations(local.ReturnRelations);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandGRMRelationsPref.setInfo(arrayList);
		return expandGRMRelationsPref;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsPref2 toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsPref2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsPref2 expandGRMRelationsPref = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsPref2();
		expandGRMRelationsPref.ExpItemRev = wire.ExpItemRev;
		expandGRMRelationsPref.ReturnRelations = wire.ReturnRelations;
		IList info = wire.getInfo();
		expandGRMRelationsPref.Info = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandGRMRelationsPref.Info[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.RelationAndTypesFilter)info[i], modelManager);
		}
		return expandGRMRelationsPref;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2 toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2 expandGRMRelationsResponse = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2();
		expandGRMRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandGRMRelationsResponse.Output = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsOutput2[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandGRMRelationsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsOutput2)output[i], modelManager);
		}
		return expandGRMRelationsResponse;
	}

	public static Teamcenter.Schemas.Core._2007_09.Datamanagement.NamedReferenceInfo toWire(Teamcenter.Services.Strong.Core._2007_09.DataManagement.NamedReferenceInfo local)
	{
		Teamcenter.Schemas.Core._2007_09.Datamanagement.NamedReferenceInfo namedReferenceInfo = new Teamcenter.Schemas.Core._2007_09.Datamanagement.NamedReferenceInfo();
		namedReferenceInfo.setClientId(local.ClientId);
		namedReferenceInfo.setType(local.Type);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		namedReferenceInfo.setTargetObject(modelObject);
		namedReferenceInfo.setDeleteTarget(local.DeleteTarget);
		return namedReferenceInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.NamedReferenceInfo toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.NamedReferenceInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.NamedReferenceInfo namedReferenceInfo = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.NamedReferenceInfo();
		namedReferenceInfo.ClientId = wire.getClientId();
		namedReferenceInfo.Type = wire.getType();
		namedReferenceInfo.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		namedReferenceInfo.DeleteTarget = wire.DeleteTarget;
		return namedReferenceInfo;
	}

	public static Teamcenter.Schemas.Core._2007_09.Datamanagement.RemoveNamedReferenceFromDatasetInfo toWire(Teamcenter.Services.Strong.Core._2007_09.DataManagement.RemoveNamedReferenceFromDatasetInfo local)
	{
		Teamcenter.Schemas.Core._2007_09.Datamanagement.RemoveNamedReferenceFromDatasetInfo removeNamedReferenceFromDatasetInfo = new Teamcenter.Schemas.Core._2007_09.Datamanagement.RemoveNamedReferenceFromDatasetInfo();
		removeNamedReferenceFromDatasetInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		removeNamedReferenceFromDatasetInfo.setDataset(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.NrInfo.Length; i++)
		{
			arrayList.Add(toWire(local.NrInfo[i]));
		}
		removeNamedReferenceFromDatasetInfo.setNrInfo(arrayList);
		return removeNamedReferenceFromDatasetInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.DataManagement.RemoveNamedReferenceFromDatasetInfo toLocal(Teamcenter.Schemas.Core._2007_09.Datamanagement.RemoveNamedReferenceFromDatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.DataManagement.RemoveNamedReferenceFromDatasetInfo removeNamedReferenceFromDatasetInfo = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.RemoveNamedReferenceFromDatasetInfo();
		removeNamedReferenceFromDatasetInfo.ClientId = wire.getClientId();
		removeNamedReferenceFromDatasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList nrInfo = wire.getNrInfo();
		removeNamedReferenceFromDatasetInfo.NrInfo = new Teamcenter.Services.Strong.Core._2007_09.DataManagement.NamedReferenceInfo[nrInfo.Count];
		for (int i = 0; i < nrInfo.Count; i++)
		{
			removeNamedReferenceFromDatasetInfo.NrInfo[i] = toLocal((Teamcenter.Schemas.Core._2007_09.Datamanagement.NamedReferenceInfo)nrInfo[i], modelManager);
		}
		return removeNamedReferenceFromDatasetInfo;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData LoadObjects(string[] Uids)
	{
		try
		{
			restSender.PushRequestId();
			LoadObjectsInput loadObjectsInput = new LoadObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Uids.Length; i++)
			{
				arrayList.Add(Uids[i]);
			}
			loadObjectsInput.setUids(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200709_PORT_NAME, "LoadObjects", loadObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Soa.Client.Model.ServiceData RemoveNamedReferenceFromDataset(Teamcenter.Services.Strong.Core._2007_09.DataManagement.RemoveNamedReferenceFromDatasetInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			RemoveNamedReferenceFromDatasetInput removeNamedReferenceFromDatasetInput = new RemoveNamedReferenceFromDatasetInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			removeNamedReferenceFromDatasetInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200709_PORT_NAME, "RemoveNamedReferenceFromDataset", removeNamedReferenceFromDatasetInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2 ExpandGRMRelationsForPrimary(Teamcenter.Soa.Client.Model.ModelObject[] PrimaryObjects, Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsPref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsForPrimaryInput expandGRMRelationsForPrimaryInput = new Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsForPrimaryInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PrimaryObjects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (PrimaryObjects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(PrimaryObjects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandGRMRelationsForPrimaryInput.setPrimaryObjects(arrayList);
			expandGRMRelationsForPrimaryInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200709_PORT_NAME, "ExpandGRMRelationsForPrimary", expandGRMRelationsForPrimaryInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2 wire = (Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2)obj;
			Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2 ExpandGRMRelationsForSecondary(Teamcenter.Soa.Client.Model.ModelObject[] SecondaryObjects, Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsPref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsForSecondaryInput expandGRMRelationsForSecondaryInput = new Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsForSecondaryInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < SecondaryObjects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (SecondaryObjects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(SecondaryObjects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			expandGRMRelationsForSecondaryInput.setSecondaryObjects(arrayList);
			expandGRMRelationsForSecondaryInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200709_PORT_NAME, "ExpandGRMRelationsForSecondary", expandGRMRelationsForSecondaryInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2 wire = (Teamcenter.Schemas.Core._2007_09.Datamanagement.ExpandGRMRelationsResponse2)obj;
			Teamcenter.Services.Strong.Core._2007_09.DataManagement.ExpandGRMRelationsResponse2 result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2007_12.Datamanagement.IdentifierData toWire(Teamcenter.Services.Strong.Core._2007_12.DataManagement.IdentifierData local)
	{
		Teamcenter.Schemas.Core._2007_12.Datamanagement.IdentifierData identifierData = new Teamcenter.Schemas.Core._2007_12.Datamanagement.IdentifierData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.IdentifiableObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.IdentifiableObject.Uid);
		}
		identifierData.setIdentifiableObject(modelObject);
		identifierData.setAlternateId(local.AlternateId);
		identifierData.setAdditionalProps(toWireNameValueMap2(local.AdditionalProps));
		identifierData.setMakeDefault(local.MakeDefault);
		return identifierData;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.IdentifierData toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.IdentifierData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.IdentifierData identifierData = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.IdentifierData();
		identifierData.IdentifiableObject = modelManager.LoadObjectData(wire.getIdentifiableObject());
		identifierData.AlternateId = wire.getAlternateId();
		identifierData.AdditionalProps = toLocalNameValueMap2(wire.getAdditionalProps(), modelManager);
		identifierData.MakeDefault = wire.MakeDefault;
		return identifierData;
	}

	public static Teamcenter.Schemas.Core._2007_12.Datamanagement.AlternateIdentifiersInput toWire(Teamcenter.Services.Strong.Core._2007_12.DataManagement.AlternateIdentifiersInput local)
	{
		Teamcenter.Schemas.Core._2007_12.Datamanagement.AlternateIdentifiersInput alternateIdentifiersInput = new Teamcenter.Schemas.Core._2007_12.Datamanagement.AlternateIdentifiersInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Context == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Context.Uid);
		}
		alternateIdentifiersInput.setContext(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.IdentifierType == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.IdentifierType.Uid);
		}
		alternateIdentifiersInput.setIdentifierType(modelObject2);
		alternateIdentifiersInput.setMainObject(toWire(local.MainObject));
		alternateIdentifiersInput.setRevObject(toWire(local.RevObject));
		return alternateIdentifiersInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.AlternateIdentifiersInput toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.AlternateIdentifiersInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.AlternateIdentifiersInput alternateIdentifiersInput = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.AlternateIdentifiersInput();
		alternateIdentifiersInput.Context = (IdContext)modelManager.LoadObjectData(wire.getContext());
		alternateIdentifiersInput.IdentifierType = (ImanType)modelManager.LoadObjectData(wire.getIdentifierType());
		alternateIdentifiersInput.MainObject = toLocal(wire.getMainObject(), modelManager);
		alternateIdentifiersInput.RevObject = toLocal(wire.getRevObject(), modelManager);
		return alternateIdentifiersInput;
	}

	public static Teamcenter.Schemas.Core._2007_12.Datamanagement.ContextAndIdentifierTypes toWire(Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes local)
	{
		Teamcenter.Schemas.Core._2007_12.Datamanagement.ContextAndIdentifierTypes contextAndIdentifierTypes = new Teamcenter.Schemas.Core._2007_12.Datamanagement.ContextAndIdentifierTypes();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Context == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Context.Uid);
		}
		contextAndIdentifierTypes.setContext(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.IdentfierTypes.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.IdentfierTypes[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.IdentfierTypes[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		contextAndIdentifierTypes.setIdentfierTypes(arrayList);
		return contextAndIdentifierTypes;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.ContextAndIdentifierTypes wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes contextAndIdentifierTypes = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes();
		contextAndIdentifierTypes.Context = (IdContext)modelManager.LoadObjectData(wire.getContext());
		IList identfierTypes = wire.getIdentfierTypes();
		contextAndIdentifierTypes.IdentfierTypes = new ImanType[identfierTypes.Count];
		for (int i = 0; i < identfierTypes.Count; i++)
		{
			contextAndIdentifierTypes.IdentfierTypes[i] = (ImanType)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)identfierTypes[i]);
		}
		return contextAndIdentifierTypes;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.GetContextAndIdentifiersResponse toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.GetContextAndIdentifiersResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.GetContextAndIdentifiersResponse getContextAndIdentifiersResponse = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.GetContextAndIdentifiersResponse();
		getContextAndIdentifiersResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getContextAndIdentifiersResponse.ContextAndIdentifierTypesMap = toLocalContextAndIdentifierTypesMap(wire.getContextAndIdentifierTypesMap(), modelManager);
		return getContextAndIdentifiersResponse;
	}

	public static Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesInfo toWire(Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesInfo local)
	{
		Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesInfo listAlternateIdDisplayRulesInfo = new Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Users.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Users[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.Users[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		listAlternateIdDisplayRulesInfo.setUsers(arrayList);
		listAlternateIdDisplayRulesInfo.setCurrentUser(local.CurrentUser);
		return listAlternateIdDisplayRulesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesInfo toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesInfo listAlternateIdDisplayRulesInfo = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesInfo();
		IList users = wire.getUsers();
		listAlternateIdDisplayRulesInfo.Users = new User[users.Count];
		for (int i = 0; i < users.Count; i++)
		{
			listAlternateIdDisplayRulesInfo.Users[i] = (User)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)users[i]);
		}
		listAlternateIdDisplayRulesInfo.CurrentUser = wire.CurrentUser;
		return listAlternateIdDisplayRulesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesResponse toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesResponse listAlternateIdDisplayRulesResponse = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesResponse();
		listAlternateIdDisplayRulesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		listAlternateIdDisplayRulesResponse.UserDisplayRuleMaps = toLocalUserDisplayRuleMap(wire.getUserDisplayRuleMaps(), modelManager);
		listAlternateIdDisplayRulesResponse.CurrentRuleInDB = (IdDispRule)modelManager.LoadObjectData(wire.getCurrentRuleInDB());
		return listAlternateIdDisplayRulesResponse;
	}

	public static Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdInput toWire(Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdInput local)
	{
		Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdInput validateAlternateIdInput = new Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdInput();
		validateAlternateIdInput.setClientId(local.ClientId);
		validateAlternateIdInput.setAlternateId(local.AlternateId);
		validateAlternateIdInput.setAlternateRevId(local.AlternateRevId);
		validateAlternateIdInput.setPatternName(local.PatternName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Context == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Context.Uid);
		}
		validateAlternateIdInput.setContext(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.IdentifierType == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.IdentifierType.Uid);
		}
		validateAlternateIdInput.setIdentifierType(modelObject2);
		return validateAlternateIdInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdInput toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdInput validateAlternateIdInput = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdInput();
		validateAlternateIdInput.ClientId = wire.getClientId();
		validateAlternateIdInput.AlternateId = wire.getAlternateId();
		validateAlternateIdInput.AlternateRevId = wire.getAlternateRevId();
		validateAlternateIdInput.PatternName = wire.getPatternName();
		validateAlternateIdInput.Context = (IdContext)modelManager.LoadObjectData(wire.getContext());
		validateAlternateIdInput.IdentifierType = (ImanType)modelManager.LoadObjectData(wire.getIdentifierType());
		return validateAlternateIdInput;
	}

	public static Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdOutput toWire(Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdOutput local)
	{
		Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdOutput validateAlternateIdOutput = new Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdOutput();
		validateAlternateIdOutput.setClientId(local.ClientId);
		validateAlternateIdOutput.setModifiedAltId(local.ModifiedAltId);
		validateAlternateIdOutput.setModifiedAltRevId(local.ModifiedAltRevId);
		validateAlternateIdOutput.setValidityId(local.ValidityId);
		validateAlternateIdOutput.setValidityRevId(local.ValidityRevId);
		return validateAlternateIdOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdOutput toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdOutput validateAlternateIdOutput = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdOutput();
		validateAlternateIdOutput.ClientId = wire.getClientId();
		validateAlternateIdOutput.ModifiedAltId = wire.getModifiedAltId();
		validateAlternateIdOutput.ModifiedAltRevId = wire.getModifiedAltRevId();
		validateAlternateIdOutput.ValidityId = wire.getValidityId();
		validateAlternateIdOutput.ValidityRevId = wire.getValidityRevId();
		return validateAlternateIdOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdResponse toLocal(Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdResponse validateAlternateIdResponse = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdResponse();
		validateAlternateIdResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		validateAlternateIdResponse.Output = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			validateAlternateIdResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdOutput)output[i], modelManager);
		}
		return validateAlternateIdResponse;
	}

	public static ArrayList toWireContextAndIdentifierTypesMap(IDictionary ContextAndIdentifierTypesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ContextAndIdentifierTypesMap)
		{
			object key = item.Key;
			object value = item.Value;
			ContextAndIdentifierTypesMap contextAndIdentifierTypesMap = new ContextAndIdentifierTypesMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			contextAndIdentifierTypesMap.setKey(modelObject);
			IList value2 = contextAndIdentifierTypesMap.getValue();
			Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes[] array = (Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			contextAndIdentifierTypesMap.setValue((ArrayList)value2);
			arrayList.Add(contextAndIdentifierTypesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalContextAndIdentifierTypesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ContextAndIdentifierTypesMap contextAndIdentifierTypesMap = (ContextAndIdentifierTypesMap)wire[i];
			ImanType key = (ImanType)modelManager.LoadObjectData(contextAndIdentifierTypesMap.getKey());
			IList value = contextAndIdentifierTypesMap.getValue();
			Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes[] array = new Teamcenter.Services.Strong.Core._2007_12.DataManagement.ContextAndIdentifierTypes[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2007_12.Datamanagement.ContextAndIdentifierTypes)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireNameValueMap2(IDictionary NameValueMap2)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in NameValueMap2)
		{
			object key = item.Key;
			object value = item.Value;
			NameValueMap2 nameValueMap = new NameValueMap2();
			nameValueMap.setKey(Convert.ToString(key));
			IList value2 = nameValueMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			nameValueMap.setValue((ArrayList)value2);
			arrayList.Add(nameValueMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalNameValueMap2(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			NameValueMap2 nameValueMap = (NameValueMap2)wire[i];
			string key = nameValueMap.getKey();
			IList value = nameValueMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireUserDisplayRuleMap(IDictionary UserDisplayRuleMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in UserDisplayRuleMap)
		{
			object key = item.Key;
			object value = item.Value;
			UserDisplayRuleMap userDisplayRuleMap = new UserDisplayRuleMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			userDisplayRuleMap.setKey(modelObject);
			IList value2 = userDisplayRuleMap.getValue();
			IdDispRule[] array = (IdDispRule[])value;
			for (int i = 0; i < array.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (array[i] == null)
				{
					modelObject2.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject2.setUid(((Teamcenter.Soa.Client.Model.ModelObject)array[i]).Uid);
				}
				value2.Add(modelObject2);
			}
			userDisplayRuleMap.setValue((ArrayList)value2);
			arrayList.Add(userDisplayRuleMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalUserDisplayRuleMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			UserDisplayRuleMap userDisplayRuleMap = (UserDisplayRuleMap)wire[i];
			User key = (User)modelManager.LoadObjectData(userDisplayRuleMap.getKey());
			IList value = userDisplayRuleMap.getValue();
			IdDispRule[] array = new IdDispRule[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (IdDispRule)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)value[j]);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData CreateAlternateIdentifiers(Teamcenter.Services.Strong.Core._2007_12.DataManagement.AlternateIdentifiersInput[] Input)
	{
		try
		{
			restSender.PushRequestId();
			CreateAlternateIdentifiersInput createAlternateIdentifiersInput = new CreateAlternateIdentifiersInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createAlternateIdentifiersInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200712_PORT_NAME, "CreateAlternateIdentifiers", createAlternateIdentifiersInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2007_12.DataManagement.GetContextAndIdentifiersResponse GetContextsAndIdentifierTypes(ImanType[] TypeTags)
	{
		try
		{
			restSender.PushRequestId();
			GetContextsAndIdentifierTypesInput getContextsAndIdentifierTypesInput = new GetContextsAndIdentifierTypesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TypeTags.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (TypeTags[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(TypeTags[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getContextsAndIdentifierTypesInput.setTypeTags(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_12.Datamanagement.GetContextAndIdentifiersResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200712_PORT_NAME, "GetContextsAndIdentifierTypes", getContextsAndIdentifierTypesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_12.Datamanagement.GetContextAndIdentifiersResponse wire = (Teamcenter.Schemas.Core._2007_12.Datamanagement.GetContextAndIdentifiersResponse)obj;
			Teamcenter.Services.Strong.Core._2007_12.DataManagement.GetContextAndIdentifiersResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesResponse ListAlternateIdDisplayRules(Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesInfo Input)
	{
		try
		{
			restSender.PushRequestId();
			ListAlternateIdDisplayRulesInput listAlternateIdDisplayRulesInput = new ListAlternateIdDisplayRulesInput();
			listAlternateIdDisplayRulesInput.setInput(toWire(Input));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200712_PORT_NAME, "ListAlternateIdDisplayRules", listAlternateIdDisplayRulesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesResponse wire = (Teamcenter.Schemas.Core._2007_12.Datamanagement.ListAlternateIdDisplayRulesResponse)obj;
			Teamcenter.Services.Strong.Core._2007_12.DataManagement.ListAlternateIdDisplayRulesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdResponse ValidateAlternateIds(Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdInput[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			ValidateAlternateIdsInput validateAlternateIdsInput = new ValidateAlternateIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			validateAlternateIdsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200712_PORT_NAME, "ValidateAlternateIds", validateAlternateIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdResponse wire = (Teamcenter.Schemas.Core._2007_12.Datamanagement.ValidateAlternateIdResponse)obj;
			Teamcenter.Services.Strong.Core._2007_12.DataManagement.ValidateAlternateIdResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData UnloadObjects(Teamcenter.Soa.Client.Model.ModelObject[] ObjsToUnload)
	{
		try
		{
			restSender.PushRequestId();
			UnloadObjectsInput unloadObjectsInput = new UnloadObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ObjsToUnload.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (ObjsToUnload[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(ObjsToUnload[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			unloadObjectsInput.setObjsToUnload(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200805_PORT_NAME, "UnloadObjects", unloadObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantInfo addParticipantInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRev.Uid);
		}
		addParticipantInfo.setItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParticipantInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ParticipantInfo[i]));
		}
		addParticipantInfo.setParticipantInfo(arrayList);
		return addParticipantInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantInfo addParticipantInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantInfo();
		addParticipantInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList participantInfo = wire.getParticipantInfo();
		addParticipantInfo.ParticipantInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ParticipantInfo[participantInfo.Count];
		for (int i = 0; i < participantInfo.Count; i++)
		{
			addParticipantInfo.ParticipantInfo[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.ParticipantInfo)participantInfo[i], modelManager);
		}
		return addParticipantInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantOutput addParticipantOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantOutput();
		addParticipantOutput.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList participantOutput = wire.getParticipantOutput();
		addParticipantOutput.ParticipantOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.Participants[participantOutput.Count];
		for (int i = 0; i < participantOutput.Count; i++)
		{
			addParticipantOutput.ParticipantOutput[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.Participants)participantOutput[i], modelManager);
		}
		return addParticipantOutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.AttrInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.AttrInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.AttrInfo attrInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.AttrInfo();
		attrInfo.setName(local.Name);
		attrInfo.setValue(local.Value);
		return attrInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.AttrInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.AttrInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.AttrInfo attrInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.AttrInfo();
		attrInfo.Name = wire.getName();
		attrInfo.Value = wire.getValue();
		return attrInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.BOHierarchy toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOHierarchy local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.BOHierarchy bOHierarchy = new Teamcenter.Schemas.Core._2008_06.Datamanagement.BOHierarchy();
		bOHierarchy.setBOName(local.BOName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BOParents.Length; i++)
		{
			arrayList.Add(local.BOParents[i]);
		}
		bOHierarchy.setBOParents(arrayList);
		return bOHierarchy;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOHierarchy toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.BOHierarchy wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOHierarchy bOHierarchy = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOHierarchy();
		bOHierarchy.BOName = wire.getBOName();
		IList bOParents = wire.getBOParents();
		bOHierarchy.BOParents = new string[bOParents.Count];
		for (int i = 0; i < bOParents.Count; i++)
		{
			bOHierarchy.BOParents[i] = Convert.ToString(bOParents[i]);
		}
		return bOHierarchy;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.BOWithExclusionIn toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOWithExclusionIn local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.BOWithExclusionIn bOWithExclusionIn = new Teamcenter.Schemas.Core._2008_06.Datamanagement.BOWithExclusionIn();
		bOWithExclusionIn.setBoTypeName(local.BoTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ExclusionBOTypeNames.Length; i++)
		{
			arrayList.Add(local.ExclusionBOTypeNames[i]);
		}
		bOWithExclusionIn.setExclusionBOTypeNames(arrayList);
		return bOWithExclusionIn;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOWithExclusionIn toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.BOWithExclusionIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOWithExclusionIn bOWithExclusionIn = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOWithExclusionIn();
		bOWithExclusionIn.BoTypeName = wire.getBoTypeName();
		IList exclusionBOTypeNames = wire.getExclusionBOTypeNames();
		bOWithExclusionIn.ExclusionBOTypeNames = new string[exclusionBOTypeNames.Count];
		for (int i = 0; i < exclusionBOTypeNames.Count; i++)
		{
			bOWithExclusionIn.ExclusionBOTypeNames[i] = Convert.ToString(exclusionBOTypeNames[i]);
		}
		return bOWithExclusionIn;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.BVROutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.BVROutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.BVROutput bVROutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.BVROutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Bvr == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Bvr.Uid);
		}
		bVROutput.setBvr(modelObject);
		bVROutput.setViewTypeName(local.ViewTypeName);
		return bVROutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.BVROutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.BVROutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.BVROutput bVROutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.BVROutput();
		bVROutput.Bvr = (PSBOMViewRevision)modelManager.LoadObjectData(wire.getBvr());
		bVROutput.ViewTypeName = wire.getViewTypeName();
		return bVROutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionOutput connectionOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionOutput();
		connectionOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Connection == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Connection.Uid);
		}
		connectionOutput.setConnection(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ConnectionRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ConnectionRev.Uid);
		}
		connectionOutput.setConnectionRev(modelObject2);
		return connectionOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionOutput connectionOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionOutput();
		connectionOutput.ClientId = wire.getClientId();
		connectionOutput.Connection = (PSConnection)modelManager.LoadObjectData(wire.getConnection());
		connectionOutput.ConnectionRev = (PSConnectionRevision)modelManager.LoadObjectData(wire.getConnectionRev());
		return connectionOutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionProperties toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionProperties local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionProperties connectionProperties = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionProperties();
		connectionProperties.setClientId(local.ClientId);
		connectionProperties.setConnId(local.ConnId);
		connectionProperties.setName(local.Name);
		connectionProperties.setType(local.Type);
		connectionProperties.setRevId(local.RevId);
		connectionProperties.setDescription(local.Description);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ExtendedAttributes.Length; i++)
		{
			arrayList.Add(toWire(local.ExtendedAttributes[i]));
		}
		connectionProperties.setExtendedAttributes(arrayList);
		return connectionProperties;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionProperties toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionProperties connectionProperties = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionProperties();
		connectionProperties.ClientId = wire.getClientId();
		connectionProperties.ConnId = wire.getConnId();
		connectionProperties.Name = wire.getName();
		connectionProperties.Type = wire.getType();
		connectionProperties.RevId = wire.getRevId();
		connectionProperties.Description = wire.getDescription();
		IList extendedAttributes = wire.getExtendedAttributes();
		connectionProperties.ExtendedAttributes = new Teamcenter.Services.Strong.Core._2006_03.DataManagement.ExtendedAttributes[extendedAttributes.Count];
		for (int i = 0; i < extendedAttributes.Count; i++)
		{
			connectionProperties.ExtendedAttributes[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Datamanagement.ExtendedAttributes)extendedAttributes[i], modelManager);
		}
		return connectionProperties;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateConnectionsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateConnectionsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateConnectionsResponse createConnectionsResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateConnectionsResponse();
		createConnectionsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createConnectionsResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createConnectionsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.ConnectionOutput)output[i], modelManager);
		}
		return createConnectionsResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateInput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateInput createInput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateInput();
		createInput.setBoName(local.BoName);
		createInput.setStringProps(toWireStringMap(local.StringProps));
		createInput.setStringArrayProps(toWireStringVectorMap(local.StringArrayProps));
		createInput.setDoubleProps(toWireDoubleMap(local.DoubleProps));
		createInput.setDoubleArrayProps(toWireDoubleVectorMap(local.DoubleArrayProps));
		createInput.setFloatProps(toWireFloatMap(local.FloatProps));
		createInput.setFloatArrayProps(toWireFloatVectorMap(local.FloatArrayProps));
		createInput.setIntProps(toWireIntMap(local.IntProps));
		createInput.setIntArrayProps(toWireIntVectorMap(local.IntArrayProps));
		createInput.setBoolProps(toWireBoolMap(local.BoolProps));
		createInput.setBoolArrayProps(toWireBoolVectorMap(local.BoolArrayProps));
		createInput.setDateProps(toWireDateMap(local.DateProps));
		createInput.setDateArrayProps(toWireDateVectorMap(local.DateArrayProps));
		createInput.setTagProps(toWireTagMap(local.TagProps));
		createInput.setTagArrayProps(toWireTagVectorMap(local.TagArrayProps));
		createInput.setCompoundCreateInput(toWireCreateInputMap(local.CompoundCreateInput));
		return createInput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput createInput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput();
		createInput.BoName = wire.getBoName();
		createInput.StringProps = toLocalStringMap(wire.getStringProps(), modelManager);
		createInput.StringArrayProps = toLocalStringVectorMap(wire.getStringArrayProps(), modelManager);
		createInput.DoubleProps = toLocalDoubleMap(wire.getDoubleProps(), modelManager);
		createInput.DoubleArrayProps = toLocalDoubleVectorMap(wire.getDoubleArrayProps(), modelManager);
		createInput.FloatProps = toLocalFloatMap(wire.getFloatProps(), modelManager);
		createInput.FloatArrayProps = toLocalFloatVectorMap(wire.getFloatArrayProps(), modelManager);
		createInput.IntProps = toLocalIntMap(wire.getIntProps(), modelManager);
		createInput.IntArrayProps = toLocalIntVectorMap(wire.getIntArrayProps(), modelManager);
		createInput.BoolProps = toLocalBoolMap(wire.getBoolProps(), modelManager);
		createInput.BoolArrayProps = toLocalBoolVectorMap(wire.getBoolArrayProps(), modelManager);
		createInput.DateProps = toLocalDateMap(wire.getDateProps(), modelManager);
		createInput.DateArrayProps = toLocalDateVectorMap(wire.getDateArrayProps(), modelManager);
		createInput.TagProps = toLocalTagMap(wire.getTagProps(), modelManager);
		createInput.TagArrayProps = toLocalTagVectorMap(wire.getTagArrayProps(), modelManager);
		createInput.CompoundCreateInput = toLocalCreateInputMap(wire.getCompoundCreateInput(), modelManager);
		return createInput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateIn toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateIn local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateIn createIn = new Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateIn();
		createIn.setClientId(local.ClientId);
		createIn.setData(toWire(local.Data));
		return createIn;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateIn toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateIn createIn = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateIn();
		createIn.ClientId = wire.getClientId();
		createIn.Data = toLocal(wire.getData(), modelManager);
		return createIn;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateGDELinksResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateGDELinksResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateGDELinksResponse createOrUpdateGDELinksResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateGDELinksResponse();
		createOrUpdateGDELinksResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		createOrUpdateGDELinksResponse.SuccessfullyProcessedGDELinks = toLocalSuccessfullyProcessedGDELinksMap(wire.getSuccessfullyProcessedGDELinks(), modelManager);
		return createOrUpdateGDELinksResponse;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateItemElementsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateItemElementsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateItemElementsResponse createOrUpdateItemElementsResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateItemElementsResponse();
		createOrUpdateItemElementsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createOrUpdateItemElementsResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createOrUpdateItemElementsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementsOutput)output[i], modelManager);
		}
		return createOrUpdateItemElementsResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsInfo createOrUpdateRelationsInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsInfo();
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
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.SecondaryData.Length; i++)
		{
			arrayList.Add(toWire(local.SecondaryData[i]));
		}
		createOrUpdateRelationsInfo.setSecondaryData(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Relations.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Relations[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Relations[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		createOrUpdateRelationsInfo.setRelations(arrayList2);
		return createOrUpdateRelationsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsInfo createOrUpdateRelationsInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsInfo();
		createOrUpdateRelationsInfo.ClientId = wire.getClientId();
		createOrUpdateRelationsInfo.RelationType = wire.getRelationType();
		createOrUpdateRelationsInfo.PrimaryObject = modelManager.LoadObjectData(wire.getPrimaryObject());
		IList secondaryData = wire.getSecondaryData();
		createOrUpdateRelationsInfo.SecondaryData = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.SecondaryData[secondaryData.Count];
		for (int i = 0; i < secondaryData.Count; i++)
		{
			createOrUpdateRelationsInfo.SecondaryData[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.SecondaryData)secondaryData[i], modelManager);
		}
		IList relations = wire.getRelations();
		createOrUpdateRelationsInfo.Relations = new ImanRelation[relations.Count];
		for (int i = 0; i < relations.Count; i++)
		{
			createOrUpdateRelationsInfo.Relations[i] = (ImanRelation)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)relations[i]);
		}
		return createOrUpdateRelationsInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsOutput createOrUpdateRelationsOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsOutput();
		createOrUpdateRelationsOutput.setClientId(local.ClientId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Relations.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Relations[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.Relations[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		createOrUpdateRelationsOutput.setRelations(arrayList);
		return createOrUpdateRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsOutput createOrUpdateRelationsOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsOutput();
		createOrUpdateRelationsOutput.ClientId = wire.getClientId();
		IList relations = wire.getRelations();
		createOrUpdateRelationsOutput.Relations = new ImanRelation[relations.Count];
		for (int i = 0; i < relations.Count; i++)
		{
			createOrUpdateRelationsOutput.Relations[i] = (ImanRelation)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)relations[i]);
		}
		return createOrUpdateRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsResponse createOrUpdateRelationsResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsResponse();
		createOrUpdateRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createOrUpdateRelationsResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createOrUpdateRelationsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsOutput)output[i], modelManager);
		}
		return createOrUpdateRelationsResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOut toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOut local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOut createOut = new Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOut();
		createOut.setClientId(local.ClientId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Objects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Objects[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.Objects[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		createOut.setObjects(arrayList);
		return createOut;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOut toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOut wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOut createOut = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOut();
		createOut.ClientId = wire.getClientId();
		IList objects = wire.getObjects();
		createOut.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			createOut.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		return createOut;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse createResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse();
		createResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOut[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOut)output[i], modelManager);
		}
		return createResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetFilter toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetFilter local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetFilter datasetFilter = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetFilter();
		datasetFilter.setUseNameFirst(local.UseNameFirst);
		datasetFilter.setProcessing(local.Processing);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.NrFilters.Length; i++)
		{
			arrayList.Add(toWire(local.NrFilters[i]));
		}
		datasetFilter.setNrFilters(arrayList);
		datasetFilter.setName(local.Name);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.RelationFilters.Length; i++)
		{
			arrayList2.Add(toWire(local.RelationFilters[i]));
		}
		datasetFilter.setRelationFilters(arrayList2);
		return datasetFilter;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetFilter toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetFilter datasetFilter = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetFilter();
		datasetFilter.UseNameFirst = wire.UseNameFirst;
		datasetFilter.Processing = wire.getProcessing();
		IList nrFilters = wire.getNrFilters();
		datasetFilter.NrFilters = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceFilter[nrFilters.Count];
		for (int i = 0; i < nrFilters.Count; i++)
		{
			datasetFilter.NrFilters[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceFilter)nrFilters[i], modelManager);
		}
		datasetFilter.Name = wire.getName();
		IList relationFilters = wire.getRelationFilters();
		datasetFilter.RelationFilters = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetRelationFilter[relationFilters.Count];
		for (int i = 0; i < relationFilters.Count; i++)
		{
			datasetFilter.RelationFilters[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetRelationFilter)relationFilters[i], modelManager);
		}
		return datasetFilter;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetInfo();
		datasetInfo.setClientId(local.ClientId);
		datasetInfo.setUid(local.Uid);
		datasetInfo.setFilter(toWire(local.Filter));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.NamedRefs.Length; i++)
		{
			arrayList.Add(toWire(local.NamedRefs[i]));
		}
		datasetInfo.setNamedRefs(arrayList);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Uid = wire.getUid();
		datasetInfo.Filter = toLocal(wire.getFilter(), modelManager);
		IList namedRefs = wire.getNamedRefs();
		datasetInfo.NamedRefs = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceList[namedRefs.Count];
		for (int i = 0; i < namedRefs.Count; i++)
		{
			datasetInfo.NamedRefs[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceList)namedRefs[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetOutput datasetOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetOutput();
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
		datasetOutput.setRelationTypeName(local.RelationTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.NamedReferenceOutput.Length; i++)
		{
			arrayList.Add(toWire(local.NamedReferenceOutput[i]));
		}
		datasetOutput.setNamedReferenceOutput(arrayList);
		return datasetOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetOutput datasetOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetOutput();
		datasetOutput.ClientId = wire.getClientId();
		datasetOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetOutput.RelationTypeName = wire.getRelationTypeName();
		IList namedReferenceOutput = wire.getNamedReferenceOutput();
		datasetOutput.NamedReferenceOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NROutput[namedReferenceOutput.Count];
		for (int i = 0; i < namedReferenceOutput.Count; i++)
		{
			datasetOutput.NamedReferenceOutput[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.NROutput)namedReferenceOutput[i], modelManager);
		}
		return datasetOutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetProperties2 toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetProperties2 local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetProperties2 datasetProperties = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetProperties2();
		datasetProperties.setClientId(local.ClientId);
		datasetProperties.setType(local.Type);
		datasetProperties.setName(local.Name);
		datasetProperties.setDescription(local.Description);
		datasetProperties.setToolUsed(local.ToolUsed);
		datasetProperties.setDatasetId(local.DatasetId);
		datasetProperties.setDatasetRev(local.DatasetRev);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Container == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Container.Uid);
		}
		datasetProperties.setContainer(modelObject);
		datasetProperties.setRelationType(local.RelationType);
		return datasetProperties;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetProperties2 toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetProperties2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetProperties2 datasetProperties = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetProperties2();
		datasetProperties.ClientId = wire.getClientId();
		datasetProperties.Type = wire.getType();
		datasetProperties.Name = wire.getName();
		datasetProperties.Description = wire.getDescription();
		datasetProperties.ToolUsed = wire.getToolUsed();
		datasetProperties.DatasetId = wire.getDatasetId();
		datasetProperties.DatasetRev = wire.getDatasetRev();
		datasetProperties.Container = modelManager.LoadObjectData(wire.getContainer());
		datasetProperties.RelationType = wire.getRelationType();
		return datasetProperties;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetRelationFilter toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetRelationFilter local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetRelationFilter datasetRelationFilter = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetRelationFilter();
		datasetRelationFilter.setRelationTypeName(local.RelationTypeName);
		datasetRelationFilter.setDatasetTypeName(local.DatasetTypeName);
		return datasetRelationFilter;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetRelationFilter toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetRelationFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetRelationFilter datasetRelationFilter = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetRelationFilter();
		datasetRelationFilter.RelationTypeName = wire.getRelationTypeName();
		datasetRelationFilter.DatasetTypeName = wire.getDatasetTypeName();
		return datasetRelationFilter;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DeepCopyData toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DeepCopyData local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DeepCopyData deepCopyData = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DeepCopyData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OtherSideObjectTag == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OtherSideObjectTag.Uid);
		}
		deepCopyData.setOtherSideObjectTag(modelObject);
		deepCopyData.setRelationTypeName(local.RelationTypeName);
		deepCopyData.setNewName(local.NewName);
		deepCopyData.setAction(local.Action);
		deepCopyData.setIsTargetPrimary(local.IsTargetPrimary);
		deepCopyData.setIsRequired(local.IsRequired);
		deepCopyData.setCopyRelations(local.CopyRelations);
		return deepCopyData;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DeepCopyData toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DeepCopyData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DeepCopyData deepCopyData = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DeepCopyData();
		deepCopyData.OtherSideObjectTag = modelManager.LoadObjectData(wire.getOtherSideObjectTag());
		deepCopyData.RelationTypeName = wire.getRelationTypeName();
		deepCopyData.NewName = wire.getNewName();
		deepCopyData.Action = wire.getAction();
		deepCopyData.IsTargetPrimary = wire.IsTargetPrimary;
		deepCopyData.IsRequired = wire.IsRequired;
		deepCopyData.CopyRelations = wire.CopyRelations;
		return deepCopyData;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableBOsOut toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableBOsOut local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableBOsOut displayableBOsOut = new Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableBOsOut();
		displayableBOsOut.setBoTypeName(local.BoTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DisplayableBOTypeNames.Length; i++)
		{
			arrayList.Add(toWire(local.DisplayableBOTypeNames[i]));
		}
		displayableBOsOut.setDisplayableBOTypeNames(arrayList);
		return displayableBOsOut;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableBOsOut toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableBOsOut wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableBOsOut displayableBOsOut = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableBOsOut();
		displayableBOsOut.BoTypeName = wire.getBoTypeName();
		IList displayableBOTypeNames = wire.getDisplayableBOTypeNames();
		displayableBOsOut.DisplayableBOTypeNames = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOHierarchy[displayableBOTypeNames.Count];
		for (int i = 0; i < displayableBOTypeNames.Count; i++)
		{
			displayableBOsOut.DisplayableBOTypeNames[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.BOHierarchy)displayableBOTypeNames[i], modelManager);
		}
		return displayableBOsOut;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableSubBOsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableSubBOsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableSubBOsResponse displayableSubBOsResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableSubBOsResponse();
		displayableSubBOsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		displayableSubBOsResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableBOsOut[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			displayableSubBOsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableBOsOut)output[i], modelManager);
		}
		return displayableSubBOsResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.GDELinkInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.GDELinkInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.GDELinkInfo gDELinkInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.GDELinkInfo();
		gDELinkInfo.setClientID(local.ClientID);
		gDELinkInfo.setName(local.Name);
		gDELinkInfo.setDescription(local.Description);
		gDELinkInfo.setType(local.Type);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.GdeLink == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.GdeLink.Uid);
		}
		gDELinkInfo.setGdeLink(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Attributes.Length; i++)
		{
			arrayList.Add(toWire(local.Attributes[i]));
		}
		gDELinkInfo.setAttributes(arrayList);
		return gDELinkInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GDELinkInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GDELinkInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GDELinkInfo gDELinkInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GDELinkInfo();
		gDELinkInfo.ClientID = wire.getClientID();
		gDELinkInfo.Name = wire.getName();
		gDELinkInfo.Description = wire.getDescription();
		gDELinkInfo.Type = wire.getType();
		gDELinkInfo.GdeLink = (GeneralDesignElementLink)modelManager.LoadObjectData(wire.getGdeLink());
		IList attributes = wire.getAttributes();
		gDELinkInfo.Attributes = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NameValueStruct[attributes.Count];
		for (int i = 0; i < attributes.Count; i++)
		{
			gDELinkInfo.Attributes[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.NameValueStruct)attributes[i], modelManager);
		}
		return gDELinkInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemInfo itemInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemInfo();
		itemInfo.setClientId(local.ClientId);
		itemInfo.setUseIdFirst(local.UseIdFirst);
		itemInfo.setUid(local.Uid);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Ids.Length; i++)
		{
			arrayList.Add(toWire(local.Ids[i]));
		}
		itemInfo.setIds(arrayList);
		return itemInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemInfo itemInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemInfo();
		itemInfo.ClientId = wire.getClientId();
		itemInfo.UseIdFirst = wire.UseIdFirst;
		itemInfo.Uid = wire.getUid();
		IList ids = wire.getIds();
		itemInfo.Ids = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.AttrInfo[ids.Count];
		for (int i = 0; i < ids.Count; i++)
		{
			itemInfo.Ids[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.AttrInfo)ids[i], modelManager);
		}
		return itemInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.RevInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.RevInfo revInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.RevInfo();
		revInfo.setClientId(local.ClientId);
		revInfo.setProcessing(local.Processing);
		revInfo.setUseIdFirst(local.UseIdFirst);
		revInfo.setUid(local.Uid);
		revInfo.setId(local.Id);
		revInfo.setNRevs(local.NRevs);
		revInfo.setRevisionRule(local.RevisionRule);
		return revInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.RevInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevInfo revInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevInfo();
		revInfo.ClientId = wire.getClientId();
		revInfo.Processing = wire.getProcessing();
		revInfo.UseIdFirst = wire.UseIdFirst;
		revInfo.Uid = wire.getUid();
		revInfo.Id = wire.getId();
		revInfo.NRevs = wire.getNRevs();
		revInfo.RevisionRule = wire.getRevisionRule();
		return revInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsInfo getItemAndRelatedObjectsInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsInfo();
		getItemAndRelatedObjectsInfo.setClientId(local.ClientId);
		getItemAndRelatedObjectsInfo.setItemInfo(toWire(local.ItemInfo));
		getItemAndRelatedObjectsInfo.setRevInfo(toWire(local.RevInfo));
		getItemAndRelatedObjectsInfo.setDatasetInfo(toWire(local.DatasetInfo));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BvrTypeNames.Length; i++)
		{
			arrayList.Add(local.BvrTypeNames[i]);
		}
		getItemAndRelatedObjectsInfo.setBvrTypeNames(arrayList);
		return getItemAndRelatedObjectsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsInfo getItemAndRelatedObjectsInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsInfo();
		getItemAndRelatedObjectsInfo.ClientId = wire.getClientId();
		getItemAndRelatedObjectsInfo.ItemInfo = toLocal(wire.getItemInfo(), modelManager);
		getItemAndRelatedObjectsInfo.RevInfo = toLocal(wire.getRevInfo(), modelManager);
		getItemAndRelatedObjectsInfo.DatasetInfo = toLocal(wire.getDatasetInfo(), modelManager);
		IList bvrTypeNames = wire.getBvrTypeNames();
		getItemAndRelatedObjectsInfo.BvrTypeNames = new string[bvrTypeNames.Count];
		for (int i = 0; i < bvrTypeNames.Count; i++)
		{
			getItemAndRelatedObjectsInfo.BvrTypeNames[i] = Convert.ToString(bvrTypeNames[i]);
		}
		return getItemAndRelatedObjectsInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsItemOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsItemOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsItemOutput getItemAndRelatedObjectsItemOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsItemOutput();
		getItemAndRelatedObjectsItemOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		getItemAndRelatedObjectsItemOutput.setItem(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemRevOutput.Length; i++)
		{
			arrayList.Add(toWire(local.ItemRevOutput[i]));
		}
		getItemAndRelatedObjectsItemOutput.setItemRevOutput(arrayList);
		return getItemAndRelatedObjectsItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsItemOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsItemOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsItemOutput getItemAndRelatedObjectsItemOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsItemOutput();
		getItemAndRelatedObjectsItemOutput.ClientId = wire.getClientId();
		getItemAndRelatedObjectsItemOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		IList itemRevOutput = wire.getItemRevOutput();
		getItemAndRelatedObjectsItemOutput.ItemRevOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevisionOutput[itemRevOutput.Count];
		for (int i = 0; i < itemRevOutput.Count; i++)
		{
			getItemAndRelatedObjectsItemOutput.ItemRevOutput[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.RevisionOutput)itemRevOutput[i], modelManager);
		}
		return getItemAndRelatedObjectsItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsResponse getItemAndRelatedObjectsResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsResponse();
		getItemAndRelatedObjectsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getItemAndRelatedObjectsResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsItemOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getItemAndRelatedObjectsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsItemOutput)output[i], modelManager);
		}
		return getItemAndRelatedObjectsResponse;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNextIdsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNextIdsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNextIdsResponse getNextIdsResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNextIdsResponse();
		getNextIdsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList nextIds = wire.getNextIds();
		getNextIdsResponse.NextIds = new string[nextIds.Count];
		for (int i = 0; i < nextIds.Count; i++)
		{
			getNextIdsResponse.NextIds[i] = Convert.ToString(nextIds[i]);
		}
		return getNextIdsResponse;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNRPatternsWithCountersResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNRPatternsWithCountersResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNRPatternsWithCountersResponse getNRPatternsWithCountersResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNRPatternsWithCountersResponse();
		getNRPatternsWithCountersResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList patterns = wire.getPatterns();
		getNRPatternsWithCountersResponse.Patterns = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.PatternsWithCounters[patterns.Count];
		for (int i = 0; i < patterns.Count; i++)
		{
			getNRPatternsWithCountersResponse.Patterns[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.PatternsWithCounters)patterns[i], modelManager);
		}
		IList preferredPattern = wire.getPreferredPattern();
		getNRPatternsWithCountersResponse.PreferredPattern = new string[preferredPattern.Count];
		for (int i = 0; i < preferredPattern.Count; i++)
		{
			getNRPatternsWithCountersResponse.PreferredPattern[i] = Convert.ToString(preferredPattern[i]);
		}
		IList condition = wire.getCondition();
		getNRPatternsWithCountersResponse.Condition = new string[condition.Count];
		for (int i = 0; i < condition.Count; i++)
		{
			getNRPatternsWithCountersResponse.Condition[i] = Convert.ToString(condition[i]);
		}
		return getNRPatternsWithCountersResponse;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetRevNRAttachResponse toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetRevNRAttachResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetRevNRAttachResponse getRevNRAttachResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetRevNRAttachResponse();
		getRevNRAttachResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList initRevDetails = wire.getInitRevDetails();
		getRevNRAttachResponse.InitRevDetails = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails[initRevDetails.Count];
		for (int i = 0; i < initRevDetails.Count; i++)
		{
			getRevNRAttachResponse.InitRevDetails[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails)initRevDetails[i], modelManager);
		}
		IList secRevDetails = wire.getSecRevDetails();
		getRevNRAttachResponse.SecRevDetails = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails[secRevDetails.Count];
		for (int i = 0; i < secRevDetails.Count; i++)
		{
			getRevNRAttachResponse.SecRevDetails[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails)secRevDetails[i], modelManager);
		}
		IList supplRevDetails = wire.getSupplRevDetails();
		getRevNRAttachResponse.SupplRevDetails = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails[supplRevDetails.Count];
		for (int i = 0; i < supplRevDetails.Count; i++)
		{
			getRevNRAttachResponse.SupplRevDetails[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails)supplRevDetails[i], modelManager);
		}
		IList excludedLetters = wire.getExcludedLetters();
		getRevNRAttachResponse.ExcludedLetters = new string[excludedLetters.Count];
		for (int i = 0; i < excludedLetters.Count; i++)
		{
			getRevNRAttachResponse.ExcludedLetters[i] = Convert.ToString(excludedLetters[i]);
		}
		return getRevNRAttachResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.InfoForNextId toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.InfoForNextId local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.InfoForNextId infoForNextId = new Teamcenter.Schemas.Core._2008_06.Datamanagement.InfoForNextId();
		infoForNextId.setTypeName(local.TypeName);
		infoForNextId.setPropName(local.PropName);
		infoForNextId.setPattern(local.Pattern);
		return infoForNextId;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.InfoForNextId toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.InfoForNextId wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.InfoForNextId infoForNextId = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.InfoForNextId();
		infoForNextId.TypeName = wire.getTypeName();
		infoForNextId.PropName = wire.getPropName();
		infoForNextId.Pattern = wire.getPattern();
		return infoForNextId;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementProperties toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementProperties local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementProperties itemElementProperties = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementProperties();
		itemElementProperties.setClientId(local.ClientId);
		itemElementProperties.setName(local.Name);
		itemElementProperties.setType(local.Type);
		itemElementProperties.setDescription(local.Description);
		itemElementProperties.setItemElemAttributes(toWireAttributeMap(local.ItemElemAttributes));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemElement == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemElement.Uid);
		}
		itemElementProperties.setItemElement(modelObject);
		return itemElementProperties;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementProperties toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementProperties itemElementProperties = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementProperties();
		itemElementProperties.ClientId = wire.getClientId();
		itemElementProperties.Name = wire.getName();
		itemElementProperties.Type = wire.getType();
		itemElementProperties.Description = wire.getDescription();
		itemElementProperties.ItemElemAttributes = toLocalAttributeMap(wire.getItemElemAttributes(), modelManager);
		itemElementProperties.ItemElement = modelManager.LoadObjectData(wire.getItemElement());
		return itemElementProperties;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementsOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementsOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementsOutput itemElementsOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementsOutput();
		itemElementsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemElem == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemElem.Uid);
		}
		itemElementsOutput.setItemElem(modelObject);
		return itemElementsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementsOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ItemElementsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementsOutput itemElementsOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementsOutput();
		itemElementsOutput.ClientId = wire.getClientId();
		itemElementsOutput.ItemElem = (GeneralDesignElement)modelManager.LoadObjectData(wire.getItemElem());
		return itemElementsOutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.MasterFormPropertiesInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.MasterFormPropertiesInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.MasterFormPropertiesInfo masterFormPropertiesInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.MasterFormPropertiesInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Form == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Form.Uid);
		}
		masterFormPropertiesInfo.setForm(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropertyValueInfo.Length; i++)
		{
			arrayList.Add(toWire(local.PropertyValueInfo[i]));
		}
		masterFormPropertiesInfo.setPropertyValueInfo(arrayList);
		return masterFormPropertiesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.MasterFormPropertiesInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.MasterFormPropertiesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.MasterFormPropertiesInfo masterFormPropertiesInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.MasterFormPropertiesInfo();
		masterFormPropertiesInfo.Form = (Form)modelManager.LoadObjectData(wire.getForm());
		IList propertyValueInfo = wire.getPropertyValueInfo();
		masterFormPropertiesInfo.PropertyValueInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.PropertyNameValueInfo[propertyValueInfo.Count];
		for (int i = 0; i < propertyValueInfo.Count; i++)
		{
			masterFormPropertiesInfo.PropertyValueInfo[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.PropertyNameValueInfo)propertyValueInfo[i], modelManager);
		}
		return masterFormPropertiesInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceFilter toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceFilter local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceFilter namedReferenceFilter = new Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceFilter();
		namedReferenceFilter.setNamedReference(local.NamedReference);
		namedReferenceFilter.setUidReferenced(local.UidReferenced);
		return namedReferenceFilter;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceFilter toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceFilter namedReferenceFilter = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceFilter();
		namedReferenceFilter.NamedReference = wire.getNamedReference();
		namedReferenceFilter.UidReferenced = wire.getUidReferenced();
		return namedReferenceFilter;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceList toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceList local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceList namedReferenceList = new Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceList();
		namedReferenceList.setNamedReference(local.NamedReference);
		namedReferenceList.setTicket(local.Ticket);
		return namedReferenceList;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceList toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.NamedReferenceList wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceList namedReferenceList = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NamedReferenceList();
		namedReferenceList.NamedReference = wire.getNamedReference();
		namedReferenceList.Ticket = wire.Ticket;
		return namedReferenceList;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.NameValueStruct toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.NameValueStruct local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.NameValueStruct nameValueStruct = new Teamcenter.Schemas.Core._2008_06.Datamanagement.NameValueStruct();
		nameValueStruct.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		nameValueStruct.setValues(arrayList);
		return nameValueStruct;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.NameValueStruct toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.NameValueStruct wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.NameValueStruct nameValueStruct = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NameValueStruct();
		nameValueStruct.Name = wire.getName();
		IList values = wire.getValues();
		nameValueStruct.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			nameValueStruct.Values[i] = Convert.ToString(values[i]);
		}
		return nameValueStruct;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.NRAttachInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.NRAttachInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.NRAttachInfo nRAttachInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.NRAttachInfo();
		nRAttachInfo.setTypeName(local.TypeName);
		nRAttachInfo.setPropName(local.PropName);
		return nRAttachInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.NRAttachInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.NRAttachInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.NRAttachInfo nRAttachInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NRAttachInfo();
		nRAttachInfo.TypeName = wire.getTypeName();
		nRAttachInfo.PropName = wire.getPropName();
		return nRAttachInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.NROutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.NROutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.NROutput nROutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.NROutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.NamedReference == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.NamedReference.Uid);
		}
		nROutput.setNamedReference(modelObject);
		nROutput.setNamedReferenceName(local.NamedReferenceName);
		nROutput.setTicket(local.Ticket);
		return nROutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.NROutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.NROutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.NROutput nROutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NROutput();
		nROutput.NamedReference = modelManager.LoadObjectData(wire.getNamedReference());
		nROutput.NamedReferenceName = wire.getNamedReferenceName();
		nROutput.Ticket = wire.getTicket();
		return nROutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ParticipantInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ParticipantInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ParticipantInfo participantInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ParticipantInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Assignee == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Assignee.Uid);
		}
		participantInfo.setAssignee(modelObject);
		participantInfo.setParticipantType(local.ParticipantType);
		participantInfo.setClientId(local.ClientId);
		return participantInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ParticipantInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ParticipantInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ParticipantInfo participantInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ParticipantInfo();
		participantInfo.Assignee = modelManager.LoadObjectData(wire.getAssignee());
		participantInfo.ParticipantType = wire.getParticipantType();
		participantInfo.ClientId = wire.getClientId();
		return participantInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.Participants toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.Participants local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.Participants participants = new Teamcenter.Schemas.Core._2008_06.Datamanagement.Participants();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRev.Uid);
		}
		participants.setItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Participant.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Participant[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Participant[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		participants.setParticipant(arrayList);
		return participants;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.Participants toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.Participants wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.Participants participants = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.Participants();
		participants.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList participant = wire.getParticipant();
		participants.Participant = new Participant[participant.Count];
		for (int i = 0; i < participant.Count; i++)
		{
			participants.Participant[i] = (Participant)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)participant[i]);
		}
		return participants;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.PatternsWithCounters toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.PatternsWithCounters local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.PatternsWithCounters patternsWithCounters = new Teamcenter.Schemas.Core._2008_06.Datamanagement.PatternsWithCounters();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PatternStrings.Length; i++)
		{
			arrayList.Add(local.PatternStrings[i]);
		}
		patternsWithCounters.setPatternStrings(arrayList);
		return patternsWithCounters;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.PatternsWithCounters toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.PatternsWithCounters wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.PatternsWithCounters patternsWithCounters = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.PatternsWithCounters();
		IList patternStrings = wire.getPatternStrings();
		patternsWithCounters.PatternStrings = new string[patternStrings.Count];
		for (int i = 0; i < patternStrings.Count; i++)
		{
			patternsWithCounters.PatternStrings[i] = Convert.ToString(patternStrings[i]);
		}
		return patternsWithCounters;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.PropertyNameValueInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.PropertyNameValueInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.PropertyNameValueInfo propertyNameValueInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.PropertyNameValueInfo();
		propertyNameValueInfo.setPropertyName(local.PropertyName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropertyValues.Length; i++)
		{
			arrayList.Add(local.PropertyValues[i]);
		}
		propertyNameValueInfo.setPropertyValues(arrayList);
		return propertyNameValueInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.PropertyNameValueInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.PropertyNameValueInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.PropertyNameValueInfo propertyNameValueInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.PropertyNameValueInfo();
		propertyNameValueInfo.PropertyName = wire.getPropertyName();
		IList propertyValues = wire.getPropertyValues();
		propertyNameValueInfo.PropertyValues = new string[propertyValues.Count];
		for (int i = 0; i < propertyValues.Count; i++)
		{
			propertyNameValueInfo.PropertyValues[i] = Convert.ToString(propertyValues[i]);
		}
		return propertyNameValueInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.RelatedObjectInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.RelatedObjectInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.RelatedObjectInfo relatedObjectInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.RelatedObjectInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RelatedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RelatedObject.Uid);
		}
		relatedObjectInfo.setRelatedObject(modelObject);
		relatedObjectInfo.setAction(local.Action);
		relatedObjectInfo.setIsSecondary(local.IsSecondary);
		return relatedObjectInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.RelatedObjectInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.RelatedObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.RelatedObjectInfo relatedObjectInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RelatedObjectInfo();
		relatedObjectInfo.RelatedObject = modelManager.LoadObjectData(wire.getRelatedObject());
		relatedObjectInfo.Action = wire.getAction();
		relatedObjectInfo.IsSecondary = wire.IsSecondary;
		return relatedObjectInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseInfo reviseInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseInfo();
		reviseInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BaseItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BaseItemRevision.Uid);
		}
		reviseInfo.setBaseItemRevision(modelObject);
		reviseInfo.setNewRevId(local.NewRevId);
		reviseInfo.setName(local.Name);
		reviseInfo.setDescription(local.Description);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DeepCopyInfo.Length; i++)
		{
			arrayList.Add(toWire(local.DeepCopyInfo[i]));
		}
		reviseInfo.setDeepCopyInfo(arrayList);
		reviseInfo.setNewItemRevisionMasterProperties(toWire(local.NewItemRevisionMasterProperties));
		return reviseInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseInfo reviseInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseInfo();
		reviseInfo.ClientId = wire.getClientId();
		reviseInfo.BaseItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getBaseItemRevision());
		reviseInfo.NewRevId = wire.getNewRevId();
		reviseInfo.Name = wire.getName();
		reviseInfo.Description = wire.getDescription();
		IList deepCopyInfo = wire.getDeepCopyInfo();
		reviseInfo.DeepCopyInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DeepCopyData[deepCopyInfo.Count];
		for (int i = 0; i < deepCopyInfo.Count; i++)
		{
			reviseInfo.DeepCopyInfo[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.DeepCopyData)deepCopyInfo[i], modelManager);
		}
		reviseInfo.NewItemRevisionMasterProperties = toLocal(wire.getNewItemRevisionMasterProperties(), modelManager);
		return reviseInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseOutput reviseOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.NewItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.NewItemRev.Uid);
		}
		reviseOutput.setNewItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelatedObjects.Length; i++)
		{
			arrayList.Add(toWire(local.RelatedObjects[i]));
		}
		reviseOutput.setRelatedObjects(arrayList);
		return reviseOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseOutput reviseOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseOutput();
		reviseOutput.NewItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getNewItemRev());
		IList relatedObjects = wire.getRelatedObjects();
		reviseOutput.RelatedObjects = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RelatedObjectInfo[relatedObjects.Count];
		for (int i = 0; i < relatedObjects.Count; i++)
		{
			reviseOutput.RelatedObjects[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.RelatedObjectInfo)relatedObjects[i], modelManager);
		}
		return reviseOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseResponse2 toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseResponse2 reviseResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseResponse2();
		reviseResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		reviseResponse.ReviseOutputMap = toLocalReviseOutputMap(wire.getReviseOutputMap(), modelManager);
		return reviseResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.RevisionOutput toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevisionOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.RevisionOutput revisionOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.RevisionOutput();
		revisionOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		revisionOutput.setItemRevision(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Bvrs.Length; i++)
		{
			arrayList.Add(toWire(local.Bvrs[i]));
		}
		revisionOutput.setBvrs(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.DatasetOutput.Length; i++)
		{
			arrayList2.Add(toWire(local.DatasetOutput[i]));
		}
		revisionOutput.setDatasetOutput(arrayList2);
		return revisionOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevisionOutput toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.RevisionOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevisionOutput revisionOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevisionOutput();
		revisionOutput.ClientId = wire.getClientId();
		revisionOutput.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		IList bvrs = wire.getBvrs();
		revisionOutput.Bvrs = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.BVROutput[bvrs.Count];
		for (int i = 0; i < bvrs.Count; i++)
		{
			revisionOutput.Bvrs[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.BVROutput)bvrs[i], modelManager);
		}
		IList datasetOutput = wire.getDatasetOutput();
		revisionOutput.DatasetOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetOutput[datasetOutput.Count];
		for (int i = 0; i < datasetOutput.Count; i++)
		{
			revisionOutput.DatasetOutput[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.DatasetOutput)datasetOutput[i], modelManager);
		}
		return revisionOutput;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails revOptionDetails = new Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails();
		revOptionDetails.setRevOption(local.RevOption);
		revOptionDetails.setRevFormat(local.RevFormat);
		return revOptionDetails;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.RevOptionDetails wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails revOptionDetails = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RevOptionDetails();
		revOptionDetails.RevOption = wire.getRevOption();
		revOptionDetails.RevFormat = wire.getRevFormat();
		return revOptionDetails;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemInfo saveAsNewItemInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemInfo();
		saveAsNewItemInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BaseItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BaseItemRevision.Uid);
		}
		saveAsNewItemInfo.setBaseItemRevision(modelObject);
		saveAsNewItemInfo.setNewItemId(local.NewItemId);
		saveAsNewItemInfo.setNewRevId(local.NewRevId);
		saveAsNewItemInfo.setName(local.Name);
		saveAsNewItemInfo.setDescription(local.Description);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DeepCopyInfo.Length; i++)
		{
			arrayList.Add(toWire(local.DeepCopyInfo[i]));
		}
		saveAsNewItemInfo.setDeepCopyInfo(arrayList);
		saveAsNewItemInfo.setNewItemMasterProperties(toWire(local.NewItemMasterProperties));
		saveAsNewItemInfo.setNewItemRevisionMasterProperties(toWire(local.NewItemRevisionMasterProperties));
		return saveAsNewItemInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemInfo saveAsNewItemInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemInfo();
		saveAsNewItemInfo.ClientId = wire.getClientId();
		saveAsNewItemInfo.BaseItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getBaseItemRevision());
		saveAsNewItemInfo.NewItemId = wire.getNewItemId();
		saveAsNewItemInfo.NewRevId = wire.getNewRevId();
		saveAsNewItemInfo.Name = wire.getName();
		saveAsNewItemInfo.Description = wire.getDescription();
		IList deepCopyInfo = wire.getDeepCopyInfo();
		saveAsNewItemInfo.DeepCopyInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.DeepCopyData[deepCopyInfo.Count];
		for (int i = 0; i < deepCopyInfo.Count; i++)
		{
			saveAsNewItemInfo.DeepCopyInfo[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.DeepCopyData)deepCopyInfo[i], modelManager);
		}
		saveAsNewItemInfo.NewItemMasterProperties = toLocal(wire.getNewItemMasterProperties(), modelManager);
		saveAsNewItemInfo.NewItemRevisionMasterProperties = toLocal(wire.getNewItemRevisionMasterProperties(), modelManager);
		return saveAsNewItemInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemOutput2 toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemOutput2 local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemOutput2 saveAsNewItemOutput = new Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemOutput2();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.NewItem == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.NewItem.Uid);
		}
		saveAsNewItemOutput.setNewItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.NewItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.NewItemRev.Uid);
		}
		saveAsNewItemOutput.setNewItemRev(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelatedObjects.Length; i++)
		{
			arrayList.Add(toWire(local.RelatedObjects[i]));
		}
		saveAsNewItemOutput.setRelatedObjects(arrayList);
		return saveAsNewItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemOutput2 toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemOutput2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemOutput2 saveAsNewItemOutput = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemOutput2();
		saveAsNewItemOutput.NewItem = (Item)modelManager.LoadObjectData(wire.getNewItem());
		saveAsNewItemOutput.NewItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getNewItemRev());
		IList relatedObjects = wire.getRelatedObjects();
		saveAsNewItemOutput.RelatedObjects = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.RelatedObjectInfo[relatedObjects.Count];
		for (int i = 0; i < relatedObjects.Count; i++)
		{
			saveAsNewItemOutput.RelatedObjects[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.RelatedObjectInfo)relatedObjects[i], modelManager);
		}
		return saveAsNewItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemResponse2 toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemResponse2 saveAsNewItemResponse = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemResponse2();
		saveAsNewItemResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		saveAsNewItemResponse.SaveAsOutputMap = toLocalSaveAsNewItemOutputMap(wire.getSaveAsOutputMap(), modelManager);
		return saveAsNewItemResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.SecondaryData toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.SecondaryData local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.SecondaryData secondaryData = new Teamcenter.Schemas.Core._2008_06.Datamanagement.SecondaryData();
		secondaryData.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Secondary == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Secondary.Uid);
		}
		secondaryData.setSecondary(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.UserData == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.UserData.Uid);
		}
		secondaryData.setUserData(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Properties.Length; i++)
		{
			arrayList.Add(toWire(local.Properties[i]));
		}
		secondaryData.setProperties(arrayList);
		return secondaryData;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.SecondaryData toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.SecondaryData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.SecondaryData secondaryData = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.SecondaryData();
		secondaryData.ClientId = wire.getClientId();
		secondaryData.Secondary = modelManager.LoadObjectData(wire.getSecondary());
		secondaryData.UserData = modelManager.LoadObjectData(wire.getUserData());
		IList properties = wire.getProperties();
		secondaryData.Properties = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.NameValueStruct[properties.Count];
		for (int i = 0; i < properties.Count; i++)
		{
			secondaryData.Properties[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.NameValueStruct)properties[i], modelManager);
		}
		return secondaryData;
	}

	public static Teamcenter.Schemas.Core._2008_06.Datamanagement.TypeAndItemRevInfo toWire(Teamcenter.Services.Strong.Core._2008_06.DataManagement.TypeAndItemRevInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Datamanagement.TypeAndItemRevInfo typeAndItemRevInfo = new Teamcenter.Schemas.Core._2008_06.Datamanagement.TypeAndItemRevInfo();
		typeAndItemRevInfo.setTypeName(local.TypeName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRev.Uid);
		}
		typeAndItemRevInfo.setItemRev(modelObject);
		return typeAndItemRevInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DataManagement.TypeAndItemRevInfo toLocal(Teamcenter.Schemas.Core._2008_06.Datamanagement.TypeAndItemRevInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DataManagement.TypeAndItemRevInfo typeAndItemRevInfo = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.TypeAndItemRevInfo();
		typeAndItemRevInfo.TypeName = wire.getTypeName();
		typeAndItemRevInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		return typeAndItemRevInfo;
	}

	public static ArrayList toWireAttributeMap(IDictionary AttributeMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in AttributeMap)
		{
			object key = item.Key;
			object value = item.Value;
			AttributeMap attributeMap = new AttributeMap();
			attributeMap.setKey(Convert.ToString(key));
			attributeMap.setValue(Convert.ToString(value));
			arrayList.Add(attributeMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalAttributeMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			AttributeMap attributeMap = (AttributeMap)wire[i];
			string key = attributeMap.getKey();
			string value = attributeMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
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

	public static ArrayList toWireCreateInputMap(IDictionary CreateInputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in CreateInputMap)
		{
			object key = item.Key;
			object value = item.Value;
			CreateInputMap createInputMap = new CreateInputMap();
			createInputMap.setKey(Convert.ToString(key));
			IList value2 = createInputMap.getValue();
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput[] array = (Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			createInputMap.setValue((ArrayList)value2);
			arrayList.Add(createInputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalCreateInputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			CreateInputMap createInputMap = (CreateInputMap)wire[i];
			string key = createInputMap.getKey();
			IList value = createInputMap.getValue();
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput[] array = new Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateInput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateInput)value[j], modelManager);
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

	public static ArrayList toWireReviseOutputMap(IDictionary ReviseOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ReviseOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			ReviseOutputMap reviseOutputMap = new ReviseOutputMap();
			reviseOutputMap.setKey(Convert.ToString(key));
			reviseOutputMap.setValue(toWire((Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseOutput)value));
			arrayList.Add(reviseOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalReviseOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ReviseOutputMap reviseOutputMap = (ReviseOutputMap)wire[i];
			string key = reviseOutputMap.getKey();
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseOutput value = toLocal(reviseOutputMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireSaveAsNewItemOutputMap(IDictionary SaveAsNewItemOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in SaveAsNewItemOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			SaveAsNewItemOutputMap saveAsNewItemOutputMap = new SaveAsNewItemOutputMap();
			saveAsNewItemOutputMap.setKey(Convert.ToString(key));
			saveAsNewItemOutputMap.setValue(toWire((Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemOutput2)value));
			arrayList.Add(saveAsNewItemOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalSaveAsNewItemOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			SaveAsNewItemOutputMap saveAsNewItemOutputMap = (SaveAsNewItemOutputMap)wire[i];
			string key = saveAsNewItemOutputMap.getKey();
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemOutput2 value = toLocal(saveAsNewItemOutputMap.getValue(), modelManager);
			hashtable.Add(key, value);
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

	public static ArrayList toWireSuccessfullyProcessedGDELinksMap(IDictionary SuccessfullyProcessedGDELinksMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in SuccessfullyProcessedGDELinksMap)
		{
			object key = item.Key;
			object value = item.Value;
			SuccessfullyProcessedGDELinksMap successfullyProcessedGDELinksMap = new SuccessfullyProcessedGDELinksMap();
			successfullyProcessedGDELinksMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			successfullyProcessedGDELinksMap.setValue(modelObject);
			arrayList.Add(successfullyProcessedGDELinksMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalSuccessfullyProcessedGDELinksMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			SuccessfullyProcessedGDELinksMap successfullyProcessedGDELinksMap = (SuccessfullyProcessedGDELinksMap)wire[i];
			string key = successfullyProcessedGDELinksMap.getKey();
			GeneralDesignElementLink value = (GeneralDesignElementLink)modelManager.LoadObjectData(successfullyProcessedGDELinksMap.getValue());
			hashtable.Add(key, value);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableSubBOsResponse FindDisplayableSubBusinessObjects(Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOWithExclusionIn[] Input)
	{
		try
		{
			restSender.PushRequestId();
			FindDisplayableSubBusinessObjectsInput findDisplayableSubBusinessObjectsInput = new FindDisplayableSubBusinessObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			findDisplayableSubBusinessObjectsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableSubBOsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "FindDisplayableSubBusinessObjects", findDisplayableSubBusinessObjectsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableSubBOsResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.DisplayableSubBOsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.DisplayableSubBOsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse CreateDatasets2(Teamcenter.Services.Strong.Core._2008_06.DataManagement.DatasetProperties2[] Input)
	{
		try
		{
			restSender.PushRequestId();
			CreateDatasets2Input createDatasets2Input = new CreateDatasets2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createDatasets2Input.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateDatasets2", createDatasets2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse wire = (Teamcenter.Schemas.Core._2006_03.Datamanagement.CreateDatasetsResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.DataManagement.CreateDatasetsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsResponse GetItemAndRelatedObjects(Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsInfo[] Infos)
	{
		try
		{
			restSender.PushRequestId();
			GetItemAndRelatedObjectsInput getItemAndRelatedObjectsInput = new GetItemAndRelatedObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Infos.Length; i++)
			{
				arrayList.Add(toWire(Infos[i]));
			}
			getItemAndRelatedObjectsInput.setInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "GetItemAndRelatedObjects", getItemAndRelatedObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.GetItemAndRelatedObjectsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetItemAndRelatedObjectsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseResponse2 Revise2(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			Revise2Input revise2Input = new Revise2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			revise2Input.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "Revise2", revise2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseResponse2 wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.ReviseResponse2)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.ReviseResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemResponse2 SaveAsNewItem2(Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			SaveAsNewItem2Input saveAsNewItem2Input = new SaveAsNewItem2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			saveAsNewItem2Input.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "SaveAsNewItem2", saveAsNewItem2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemResponse2 wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.SaveAsNewItemResponse2)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.SaveAsNewItemResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNextIdsResponse GetNextIds(Teamcenter.Services.Strong.Core._2008_06.DataManagement.InfoForNextId[] VInfoForNextId)
	{
		try
		{
			restSender.PushRequestId();
			GetNextIdsInput getNextIdsInput = new GetNextIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < VInfoForNextId.Length; i++)
			{
				arrayList.Add(toWire(VInfoForNextId[i]));
			}
			getNextIdsInput.setVInfoForNextId(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNextIdsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "GetNextIds", getNextIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNextIdsResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNextIdsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNextIdsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNRPatternsWithCountersResponse GetNRPatternsWithCounters(Teamcenter.Services.Strong.Core._2008_06.DataManagement.NRAttachInfo[] VAttachInfo)
	{
		try
		{
			restSender.PushRequestId();
			GetNRPatternsWithCountersInput getNRPatternsWithCountersInput = new GetNRPatternsWithCountersInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < VAttachInfo.Length; i++)
			{
				arrayList.Add(toWire(VAttachInfo[i]));
			}
			getNRPatternsWithCountersInput.setVAttachInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNRPatternsWithCountersResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "GetNRPatternsWithCounters", getNRPatternsWithCountersInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNRPatternsWithCountersResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.GetNRPatternsWithCountersResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetNRPatternsWithCountersResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetRevNRAttachResponse GetRevNRAttachDetails(Teamcenter.Services.Strong.Core._2008_06.DataManagement.TypeAndItemRevInfo[] TypeAndItemRevInfos)
	{
		try
		{
			restSender.PushRequestId();
			GetRevNRAttachDetailsInput getRevNRAttachDetailsInput = new GetRevNRAttachDetailsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TypeAndItemRevInfos.Length; i++)
			{
				arrayList.Add(toWire(TypeAndItemRevInfos[i]));
			}
			getRevNRAttachDetailsInput.setTypeAndItemRevInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.GetRevNRAttachResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "GetRevNRAttachDetails", getRevNRAttachDetailsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.GetRevNRAttachResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.GetRevNRAttachResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.GetRevNRAttachResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsResponse CreateOrUpdateRelations(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsInfo[] Infos, bool Sync)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateRelationsInput createOrUpdateRelationsInput = new CreateOrUpdateRelationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Infos.Length; i++)
			{
				arrayList.Add(toWire(Infos[i]));
			}
			createOrUpdateRelationsInput.setInfos(arrayList);
			createOrUpdateRelationsInput.setSync(Sync);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateOrUpdateRelations", createOrUpdateRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateRelationsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateRelationsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateConnectionsResponse CreateConnections(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ConnectionProperties[] Properties, Teamcenter.Soa.Client.Model.ModelObject Container, string RelationType)
	{
		try
		{
			restSender.PushRequestId();
			CreateConnectionsInput createConnectionsInput = new CreateConnectionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Properties.Length; i++)
			{
				arrayList.Add(toWire(Properties[i]));
			}
			createConnectionsInput.setProperties(arrayList);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Container == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(Container.Uid);
			}
			createConnectionsInput.setContainer(modelObject);
			createConnectionsInput.setRelationType(RelationType);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateConnectionsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateConnections", createConnectionsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateConnectionsResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateConnectionsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateConnectionsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateGDELinksResponse CreateOrUpdateGDELinks(Teamcenter.Services.Strong.Core._2008_06.DataManagement.GDELinkInfo[] GdeLinkInfos)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateGDELinksInput createOrUpdateGDELinksInput = new CreateOrUpdateGDELinksInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < GdeLinkInfos.Length; i++)
			{
				arrayList.Add(toWire(GdeLinkInfos[i]));
			}
			createOrUpdateGDELinksInput.setGdeLinkInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateGDELinksResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateOrUpdateGDELinks", createOrUpdateGDELinksInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateGDELinksResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateGDELinksResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateGDELinksResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateItemElementsResponse CreateOrUpdateItemElements(Teamcenter.Services.Strong.Core._2008_06.DataManagement.ItemElementProperties[] Properties)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateItemElementsInput createOrUpdateItemElementsInput = new CreateOrUpdateItemElementsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Properties.Length; i++)
			{
				arrayList.Add(toWire(Properties[i]));
			}
			createOrUpdateItemElementsInput.setProperties(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateItemElementsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateOrUpdateItemElements", createOrUpdateItemElementsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateItemElementsResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateOrUpdateItemElementsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateOrUpdateItemElementsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse CreateObjects(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateIn[] Input)
	{
		try
		{
			restSender.PushRequestId();
			CreateObjectsInput createObjectsInput = new CreateObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createObjectsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "CreateObjects", createObjectsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantOutput AddParticipants(Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantInfo[] AddParticipantInfo)
	{
		try
		{
			restSender.PushRequestId();
			AddParticipantsInput addParticipantsInput = new AddParticipantsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < AddParticipantInfo.Length; i++)
			{
				arrayList.Add(toWire(AddParticipantInfo[i]));
			}
			addParticipantsInput.setAddParticipantInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "AddParticipants", addParticipantsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantOutput wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.AddParticipantOutput)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.AddParticipantOutput result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData RemoveParticipants(Teamcenter.Services.Strong.Core._2008_06.DataManagement.Participants[] Participants)
	{
		try
		{
			restSender.PushRequestId();
			RemoveParticipantsInput removeParticipantsInput = new RemoveParticipantsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Participants.Length; i++)
			{
				arrayList.Add(toWire(Participants[i]));
			}
			removeParticipantsInput.setParticipants(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200806_PORT_NAME, "RemoveParticipants", removeParticipantsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeInfo toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeInfo getItemFromAttributeInfo = new Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeInfo();
		getItemFromAttributeInfo.setItemAttributes(toWireGetItemAttributeMap(local.ItemAttributes));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RevIds.Length; i++)
		{
			arrayList.Add(local.RevIds[i]);
		}
		getItemFromAttributeInfo.setRevIds(arrayList);
		return getItemFromAttributeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeInfo toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeInfo getItemFromAttributeInfo = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeInfo();
		getItemFromAttributeInfo.ItemAttributes = toLocalGetItemAttributeMap(wire.getItemAttributes(), modelManager);
		IList revIds = wire.getRevIds();
		getItemFromAttributeInfo.RevIds = new string[revIds.Count];
		for (int i = 0; i < revIds.Count; i++)
		{
			getItemFromAttributeInfo.RevIds[i] = Convert.ToString(revIds[i]);
		}
		return getItemFromAttributeInfo;
	}

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemOutput toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemOutput local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemOutput getItemFromAttributeItemOutput = new Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		getItemFromAttributeItemOutput.setItem(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemRevOutput.Length; i++)
		{
			arrayList.Add(toWire(local.ItemRevOutput[i]));
		}
		getItemFromAttributeItemOutput.setItemRevOutput(arrayList);
		return getItemFromAttributeItemOutput;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemOutput toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemOutput getItemFromAttributeItemOutput = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemOutput();
		getItemFromAttributeItemOutput.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		IList itemRevOutput = wire.getItemRevOutput();
		getItemFromAttributeItemOutput.ItemRevOutput = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemRevOutput[itemRevOutput.Count];
		for (int i = 0; i < itemRevOutput.Count; i++)
		{
			getItemFromAttributeItemOutput.ItemRevOutput[i] = toLocal((Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemRevOutput)itemRevOutput[i], modelManager);
		}
		return getItemFromAttributeItemOutput;
	}

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemRevOutput toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemRevOutput local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemRevOutput getItemFromAttributeItemRevOutput = new Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemRevOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		getItemFromAttributeItemRevOutput.setItemRevision(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Datasets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Datasets[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Datasets[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		getItemFromAttributeItemRevOutput.setDatasets(arrayList);
		return getItemFromAttributeItemRevOutput;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemRevOutput toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemRevOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemRevOutput getItemFromAttributeItemRevOutput = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemRevOutput();
		getItemFromAttributeItemRevOutput.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		IList datasets = wire.getDatasets();
		getItemFromAttributeItemRevOutput.Datasets = new Dataset[datasets.Count];
		for (int i = 0; i < datasets.Count; i++)
		{
			getItemFromAttributeItemRevOutput.Datasets[i] = (Dataset)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)datasets[i]);
		}
		return getItemFromAttributeItemRevOutput;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeResponse toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeResponse getItemFromAttributeResponse = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeResponse();
		getItemFromAttributeResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getItemFromAttributeResponse.Output = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeItemOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getItemFromAttributeResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeItemOutput)output[i], modelManager);
		}
		return getItemFromAttributeResponse;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetTablePropertiesResponse toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetTablePropertiesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetTablePropertiesResponse getTablePropertiesResponse = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetTablePropertiesResponse();
		getTablePropertiesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList tableInfo = wire.getTableInfo();
		getTablePropertiesResponse.TableInfo = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableInfo[tableInfo.Count];
		for (int i = 0; i < tableInfo.Count; i++)
		{
			getTablePropertiesResponse.TableInfo[i] = toLocal((Teamcenter.Schemas.Core._2009_10.Datamanagement.TableInfo)tableInfo[i], modelManager);
		}
		return getTablePropertiesResponse;
	}

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellValueTypeInfo toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellValueTypeInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellValueTypeInfo tableCellValueTypeInfo = new Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellValueTypeInfo();
		tableCellValueTypeInfo.setType(local.Type);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.StrValues.Length; i++)
		{
			arrayList.Add(local.StrValues[i]);
		}
		tableCellValueTypeInfo.setStrValues(arrayList);
		return tableCellValueTypeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellValueTypeInfo toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellValueTypeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellValueTypeInfo tableCellValueTypeInfo = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellValueTypeInfo();
		tableCellValueTypeInfo.Type = wire.getType();
		IList strValues = wire.getStrValues();
		tableCellValueTypeInfo.StrValues = new string[strValues.Count];
		for (int i = 0; i < strValues.Count; i++)
		{
			tableCellValueTypeInfo.StrValues[i] = Convert.ToString(strValues[i]);
		}
		return tableCellValueTypeInfo;
	}

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellInfo toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellInfo tableCellInfo = new Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellInfo();
		tableCellInfo.setRow(local.Row);
		tableCellInfo.setColumn(local.Column);
		tableCellInfo.setDesc(local.Desc);
		tableCellInfo.setValue(toWire(local.Value));
		return tableCellInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellInfo toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellInfo tableCellInfo = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellInfo();
		tableCellInfo.Row = wire.getRow();
		tableCellInfo.Column = wire.getColumn();
		tableCellInfo.Desc = wire.getDesc();
		tableCellInfo.Value = toLocal(wire.getValue(), modelManager);
		return tableCellInfo;
	}

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.TableDefInfo toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableDefInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.TableDefInfo tableDefInfo = new Teamcenter.Schemas.Core._2009_10.Datamanagement.TableDefInfo();
		tableDefInfo.setRows(local.Rows);
		tableDefInfo.setColumns(local.Columns);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RowLabels.Length; i++)
		{
			arrayList.Add(local.RowLabels[i]);
		}
		tableDefInfo.setRowLabels(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ColLabels.Length; i++)
		{
			arrayList2.Add(local.ColLabels[i]);
		}
		tableDefInfo.setColLabels(arrayList2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TableDef == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TableDef.Uid);
		}
		tableDefInfo.setTableDef(modelObject);
		return tableDefInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableDefInfo toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.TableDefInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableDefInfo tableDefInfo = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableDefInfo();
		tableDefInfo.Rows = wire.getRows();
		tableDefInfo.Columns = wire.getColumns();
		IList rowLabels = wire.getRowLabels();
		tableDefInfo.RowLabels = new string[rowLabels.Count];
		for (int i = 0; i < rowLabels.Count; i++)
		{
			tableDefInfo.RowLabels[i] = Convert.ToString(rowLabels[i]);
		}
		IList colLabels = wire.getColLabels();
		tableDefInfo.ColLabels = new string[colLabels.Count];
		for (int i = 0; i < colLabels.Count; i++)
		{
			tableDefInfo.ColLabels[i] = Convert.ToString(colLabels[i]);
		}
		tableDefInfo.TableDef = (TableDefinition)modelManager.LoadObjectData(wire.getTableDef());
		return tableDefInfo;
	}

	public static Teamcenter.Schemas.Core._2009_10.Datamanagement.TableInfo toWire(Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Datamanagement.TableInfo tableInfo = new Teamcenter.Schemas.Core._2009_10.Datamanagement.TableInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TableObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TableObject.Uid);
		}
		tableInfo.setTableObject(modelObject);
		tableInfo.setTableDefInfo(toWire(local.TableDefInfo));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.TableCells.Length; i++)
		{
			arrayList.Add(toWire(local.TableCells[i]));
		}
		tableInfo.setTableCells(arrayList);
		return tableInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableInfo toLocal(Teamcenter.Schemas.Core._2009_10.Datamanagement.TableInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableInfo tableInfo = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableInfo();
		tableInfo.TableObject = modelManager.LoadObjectData(wire.getTableObject());
		tableInfo.TableDefInfo = toLocal(wire.getTableDefInfo(), modelManager);
		IList tableCells = wire.getTableCells();
		tableInfo.TableCells = new Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableCellInfo[tableCells.Count];
		for (int i = 0; i < tableCells.Count; i++)
		{
			tableInfo.TableCells[i] = toLocal((Teamcenter.Schemas.Core._2009_10.Datamanagement.TableCellInfo)tableCells[i], modelManager);
		}
		return tableInfo;
	}

	public static ArrayList toWireGetItemAttributeMap(IDictionary GetItemAttributeMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in GetItemAttributeMap)
		{
			object key = item.Key;
			object value = item.Value;
			GetItemAttributeMap getItemAttributeMap = new GetItemAttributeMap();
			getItemAttributeMap.setKey(Convert.ToString(key));
			getItemAttributeMap.setValue(Convert.ToString(value));
			arrayList.Add(getItemAttributeMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalGetItemAttributeMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			GetItemAttributeMap getItemAttributeMap = (GetItemAttributeMap)wire[i];
			string key = getItemAttributeMap.getKey();
			string value = getItemAttributeMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetTablePropertiesResponse GetTableProperties(Table[] Table)
	{
		try
		{
			restSender.PushRequestId();
			GetTablePropertiesInput getTablePropertiesInput = new GetTablePropertiesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Table.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Table[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Table[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getTablePropertiesInput.setTable(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetTablePropertiesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200910_PORT_NAME, "GetTableProperties", getTablePropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2009_10.Datamanagement.GetTablePropertiesResponse wire = (Teamcenter.Schemas.Core._2009_10.Datamanagement.GetTablePropertiesResponse)obj;
			Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetTablePropertiesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData SetTableProperties(Teamcenter.Services.Strong.Core._2009_10.DataManagement.TableInfo[] TableData)
	{
		try
		{
			restSender.PushRequestId();
			SetTablePropertiesInput setTablePropertiesInput = new SetTablePropertiesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TableData.Length; i++)
			{
				arrayList.Add(toWire(TableData[i]));
			}
			setTablePropertiesInput.setTableData(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200910_PORT_NAME, "SetTableProperties", setTablePropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeResponse GetItemFromAttribute(Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeInfo[] Infos, int NRev, Teamcenter.Services.Strong.Core._2007_01.DataManagement.GetItemFromIdPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			GetItemFromAttributeInput getItemFromAttributeInput = new GetItemFromAttributeInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Infos.Length; i++)
			{
				arrayList.Add(toWire(Infos[i]));
			}
			getItemFromAttributeInput.setInfos(arrayList);
			getItemFromAttributeInput.setNRev(NRev);
			getItemFromAttributeInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_200910_PORT_NAME, "GetItemFromAttribute", getItemFromAttributeInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeResponse wire = (Teamcenter.Schemas.Core._2009_10.Datamanagement.GetItemFromAttributeResponse)obj;
			Teamcenter.Services.Strong.Core._2009_10.DataManagement.GetItemFromAttributeResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.AttributeInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.AttributeInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.AttributeInfo attributeInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.AttributeInfo();
		attributeInfo.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		attributeInfo.setValues(arrayList);
		return attributeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.AttributeInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.AttributeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.AttributeInfo attributeInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.AttributeInfo();
		attributeInfo.Name = wire.getName();
		IList values = wire.getValues();
		attributeInfo.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			attributeInfo.Values[i] = Convert.ToString(values[i]);
		}
		return attributeInfo;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.AvailableBusinessObjectTypeInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.AvailableBusinessObjectTypeInfo availableBusinessObjectTypeInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.AvailableBusinessObjectTypeInfo();
		availableBusinessObjectTypeInfo.setType(local.Type);
		availableBusinessObjectTypeInfo.setDisplayType(local.DisplayType);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Hierarchies.Length; i++)
		{
			arrayList.Add(local.Hierarchies[i]);
		}
		availableBusinessObjectTypeInfo.setHierarchies(arrayList);
		return availableBusinessObjectTypeInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.AvailableBusinessObjectTypeInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo availableBusinessObjectTypeInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo();
		availableBusinessObjectTypeInfo.Type = wire.getType();
		availableBusinessObjectTypeInfo.DisplayType = wire.getDisplayType();
		IList hierarchies = wire.getHierarchies();
		availableBusinessObjectTypeInfo.Hierarchies = new string[hierarchies.Count];
		for (int i = 0; i < hierarchies.Count; i++)
		{
			availableBusinessObjectTypeInfo.Hierarchies[i] = Convert.ToString(hierarchies[i]);
		}
		return availableBusinessObjectTypeInfo;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.BusinessObjectHierarchy toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.BusinessObjectHierarchy local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.BusinessObjectHierarchy businessObjectHierarchy = new Teamcenter.Schemas.Core._2010_04.Datamanagement.BusinessObjectHierarchy();
		businessObjectHierarchy.setBoName(local.BoName);
		businessObjectHierarchy.setBoDisplayName(local.BoDisplayName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BoParents.Length; i++)
		{
			arrayList.Add(local.BoParents[i]);
		}
		businessObjectHierarchy.setBoParents(arrayList);
		return businessObjectHierarchy;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.BusinessObjectHierarchy toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.BusinessObjectHierarchy wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.BusinessObjectHierarchy businessObjectHierarchy = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.BusinessObjectHierarchy();
		businessObjectHierarchy.BoName = wire.getBoName();
		businessObjectHierarchy.BoDisplayName = wire.getBoDisplayName();
		IList boParents = wire.getBoParents();
		businessObjectHierarchy.BoParents = new string[boParents.Count];
		for (int i = 0; i < boParents.Count; i++)
		{
			businessObjectHierarchy.BoParents[i] = Convert.ToString(boParents[i]);
		}
		return businessObjectHierarchy;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.CommitDatasetFileInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.CommitDatasetFileInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.CommitDatasetFileInfo();
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

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.CommitDatasetFileInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.CommitDatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.CommitDatasetFileInfo();
		commitDatasetFileInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		commitDatasetFileInfo.CreateNewVersion = wire.CreateNewVersion;
		IList datasetFileTicketInfos = wire.getDatasetFileTicketInfos();
		commitDatasetFileInfo.DatasetFileTicketInfos = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileTicketInfo[datasetFileTicketInfos.Count];
		for (int i = 0; i < datasetFileTicketInfos.Count; i++)
		{
			commitDatasetFileInfo.DatasetFileTicketInfos[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileTicketInfo)datasetFileTicketInfos[i], modelManager);
		}
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.CreateDatasetsResponse toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.CreateDatasetsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.CreateDatasetsResponse createDatasetsResponse = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.CreateDatasetsResponse();
		createDatasetsResponse.ServData = modelManager.LoadServiceData(wire.getServiceData());
		IList datasetOutput = wire.getDatasetOutput();
		createDatasetsResponse.DatasetOutput = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetOutput[datasetOutput.Count];
		for (int i = 0; i < datasetOutput.Count; i++)
		{
			createDatasetsResponse.DatasetOutput[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetOutput)datasetOutput[i], modelManager);
		}
		return createDatasetsResponse;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileInfo();
		datasetFileInfo.setClientId(local.ClientId);
		datasetFileInfo.setFileName(local.FileName);
		datasetFileInfo.setNamedReferenceName(local.NamedReferenceName);
		datasetFileInfo.setIsText(local.IsText);
		datasetFileInfo.setAllowReplace(local.AllowReplace);
		return datasetFileInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileInfo();
		datasetFileInfo.ClientId = wire.getClientId();
		datasetFileInfo.FileName = wire.getFileName();
		datasetFileInfo.NamedReferenceName = wire.getNamedReferenceName();
		datasetFileInfo.IsText = wire.IsText;
		datasetFileInfo.AllowReplace = wire.AllowReplace;
		return datasetFileInfo;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileTicketInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileTicketInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.setDatasetFileInfo(toWire(local.DatasetFileInfo));
		datasetFileTicketInfo.setTicket(local.Ticket);
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileTicketInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileTicketInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.DatasetFileInfo = toLocal(wire.getDatasetFileInfo(), modelManager);
		datasetFileTicketInfo.Ticket = wire.getTicket();
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetInfo();
		datasetInfo.setClientId(local.ClientId);
		datasetInfo.setName(local.Name);
		datasetInfo.setDescription(local.Description);
		datasetInfo.setType(local.Type);
		datasetInfo.setDatasetId(local.DatasetId);
		datasetInfo.setDatasetRev(local.DatasetRev);
		datasetInfo.setToolUsed(local.ToolUsed);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Attrs.Length; i++)
		{
			arrayList.Add(toWire(local.Attrs[i]));
		}
		datasetInfo.setAttrs(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList2.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.NrObjectInfos.Length; i++)
		{
			arrayList3.Add(toWire(local.NrObjectInfos[i]));
		}
		datasetInfo.setNrObjectInfos(arrayList3);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Container == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Container.Uid);
		}
		datasetInfo.setContainer(modelObject);
		datasetInfo.setRelationType(local.RelationType);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Name = wire.getName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.DatasetId = wire.getDatasetId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.ToolUsed = wire.getToolUsed();
		IList attrs = wire.getAttrs();
		datasetInfo.Attrs = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.AttributeInfo[attrs.Count];
		for (int i = 0; i < attrs.Count; i++)
		{
			datasetInfo.Attrs[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.AttributeInfo)attrs[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList nrObjectInfos = wire.getNrObjectInfos();
		datasetInfo.NrObjectInfos = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.NamedReferenceObjectInfo[nrObjectInfos.Count];
		for (int i = 0; i < nrObjectInfos.Count; i++)
		{
			datasetInfo.NrObjectInfos[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.NamedReferenceObjectInfo)nrObjectInfos[i], modelManager);
		}
		datasetInfo.Container = modelManager.LoadObjectData(wire.getContainer());
		datasetInfo.RelationType = wire.getRelationType();
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetOutput toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetOutput local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetOutput datasetOutput = new Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetOutput();
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
		return datasetOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetOutput toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.DatasetOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetOutput datasetOutput = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetOutput();
		datasetOutput.ClientId = wire.getClientId();
		datasetOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList commitInfo = wire.getCommitInfo();
		datasetOutput.CommitInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.CommitDatasetFileInfo[commitInfo.Count];
		for (int i = 0; i < commitInfo.Count; i++)
		{
			datasetOutput.CommitInfo[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.CommitDatasetFileInfo)commitInfo[i], modelManager);
		}
		return datasetOutput;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableBusinessObjectsOut toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableBusinessObjectsOut local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableBusinessObjectsOut displayableBusinessObjectsOut = new Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableBusinessObjectsOut();
		displayableBusinessObjectsOut.setBoTypeName(local.BoTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DisplayableBOTypeNames.Length; i++)
		{
			arrayList.Add(toWire(local.DisplayableBOTypeNames[i]));
		}
		displayableBusinessObjectsOut.setDisplayableBOTypeNames(arrayList);
		return displayableBusinessObjectsOut;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableBusinessObjectsOut toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableBusinessObjectsOut wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableBusinessObjectsOut displayableBusinessObjectsOut = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableBusinessObjectsOut();
		displayableBusinessObjectsOut.BoTypeName = wire.getBoTypeName();
		IList displayableBOTypeNames = wire.getDisplayableBOTypeNames();
		displayableBusinessObjectsOut.DisplayableBOTypeNames = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.BusinessObjectHierarchy[displayableBOTypeNames.Count];
		for (int i = 0; i < displayableBOTypeNames.Count; i++)
		{
			displayableBusinessObjectsOut.DisplayableBOTypeNames[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.BusinessObjectHierarchy)displayableBOTypeNames[i], modelManager);
		}
		return displayableBusinessObjectsOut;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableSubBusinessObjectsResponse toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableSubBusinessObjectsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableSubBusinessObjectsResponse displayableSubBusinessObjectsResponse = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableSubBusinessObjectsResponse();
		displayableSubBusinessObjectsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		displayableSubBusinessObjectsResponse.Output = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableBusinessObjectsOut[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			displayableSubBusinessObjectsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableBusinessObjectsOut)output[i], modelManager);
		}
		return displayableSubBusinessObjectsResponse;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetAvailableBusinessObjectTypesResponse toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.GetAvailableBusinessObjectTypesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetAvailableBusinessObjectTypesResponse getAvailableBusinessObjectTypesResponse = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetAvailableBusinessObjectTypesResponse();
		getAvailableBusinessObjectTypesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getAvailableBusinessObjectTypesResponse.InputClassToTypes = toLocalBusinessObjectClassToTypesMap(wire.getInputClassToTypes(), modelManager);
		return getAvailableBusinessObjectTypesResponse;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetDatasetCreationRelatedInfoResponse2 toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.GetDatasetCreationRelatedInfoResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetDatasetCreationRelatedInfoResponse2 getDatasetCreationRelatedInfoResponse = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetDatasetCreationRelatedInfoResponse2();
		getDatasetCreationRelatedInfoResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList toolNames = wire.getToolNames();
		getDatasetCreationRelatedInfoResponse.ToolNames = new string[toolNames.Count];
		for (int i = 0; i < toolNames.Count; i++)
		{
			getDatasetCreationRelatedInfoResponse.ToolNames[i] = Convert.ToString(toolNames[i]);
		}
		IList toolDisplayNames = wire.getToolDisplayNames();
		getDatasetCreationRelatedInfoResponse.ToolDisplayNames = new string[toolDisplayNames.Count];
		for (int i = 0; i < toolDisplayNames.Count; i++)
		{
			getDatasetCreationRelatedInfoResponse.ToolDisplayNames[i] = Convert.ToString(toolDisplayNames[i]);
		}
		getDatasetCreationRelatedInfoResponse.NewDatasetName = wire.getNewDatasetName();
		getDatasetCreationRelatedInfoResponse.NameCanBeModified = wire.NameCanBeModified;
		IList initValuePropertyRules = wire.getInitValuePropertyRules();
		getDatasetCreationRelatedInfoResponse.InitValuePropertyRules = new string[initValuePropertyRules.Count];
		for (int i = 0; i < initValuePropertyRules.Count; i++)
		{
			getDatasetCreationRelatedInfoResponse.InitValuePropertyRules[i] = Convert.ToString(initValuePropertyRules[i]);
		}
		return getDatasetCreationRelatedInfoResponse;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableResults toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableResults local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableResults localizableResults = new Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableResults();
		localizableResults.setPropName(local.PropName);
		localizableResults.setIslocalizable(local.Islocalizable);
		return localizableResults;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableResults toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableResults wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableResults localizableResults = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableResults();
		localizableResults.PropName = wire.getPropName();
		localizableResults.Islocalizable = wire.Islocalizable;
		return localizableResults;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusInput toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusInput local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusInput localizableStatusInput = new Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusInput();
		localizableStatusInput.setObjTypeName(local.ObjTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropNames.Length; i++)
		{
			arrayList.Add(local.PropNames[i]);
		}
		localizableStatusInput.setPropNames(arrayList);
		return localizableStatusInput;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusInput toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusInput localizableStatusInput = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusInput();
		localizableStatusInput.ObjTypeName = wire.getObjTypeName();
		IList propNames = wire.getPropNames();
		localizableStatusInput.PropNames = new string[propNames.Count];
		for (int i = 0; i < propNames.Count; i++)
		{
			localizableStatusInput.PropNames[i] = Convert.ToString(propNames[i]);
		}
		return localizableStatusInput;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusOutput toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusOutput local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusOutput localizableStatusOutput = new Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusOutput();
		localizableStatusOutput.setObjTypeName(local.ObjTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Results.Length; i++)
		{
			arrayList.Add(toWire(local.Results[i]));
		}
		localizableStatusOutput.setResults(arrayList);
		return localizableStatusOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusOutput toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusOutput localizableStatusOutput = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusOutput();
		localizableStatusOutput.ObjTypeName = wire.getObjTypeName();
		IList results = wire.getResults();
		localizableStatusOutput.Results = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableResults[results.Count];
		for (int i = 0; i < results.Count; i++)
		{
			localizableStatusOutput.Results[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableResults)results[i], modelManager);
		}
		return localizableStatusOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusResponse toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusResponse localizableStatusResponse = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusResponse();
		localizableStatusResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList results = wire.getResults();
		localizableStatusResponse.Results = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusOutput[results.Count];
		for (int i = 0; i < results.Count; i++)
		{
			localizableStatusResponse.Results[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusOutput)results[i], modelManager);
		}
		return localizableStatusResponse;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesInfo localizedPropertyValuesInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		localizedPropertyValuesInfo.setObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropertyValues.Length; i++)
		{
			arrayList.Add(toWire(local.PropertyValues[i]));
		}
		localizedPropertyValuesInfo.setPropertyValues(arrayList);
		return localizedPropertyValuesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo localizedPropertyValuesInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo();
		localizedPropertyValuesInfo.Object = modelManager.LoadObjectData(wire.getObject());
		IList propertyValues = wire.getPropertyValues();
		localizedPropertyValuesInfo.PropertyValues = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameValueLocaleStruct[propertyValues.Count];
		for (int i = 0; i < propertyValues.Count; i++)
		{
			localizedPropertyValuesInfo.PropertyValues[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.NameValueLocaleStruct)propertyValues[i], modelManager);
		}
		return localizedPropertyValuesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesList toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesList wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesList localizedPropertyValuesList = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesList();
		localizedPropertyValuesList.PartialErrors = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		localizedPropertyValuesList.Output = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			localizedPropertyValuesList.Output[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesInfo)output[i], modelManager);
		}
		return localizedPropertyValuesList;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.NamedReferenceObjectInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.NamedReferenceObjectInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.NamedReferenceObjectInfo();
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
		namedReferenceObjectInfo.setReferenceType(local.ReferenceType);
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.NamedReferenceObjectInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.NamedReferenceObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.ClientId = wire.getClientId();
		namedReferenceObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		namedReferenceObjectInfo.NamedReferenceName = wire.getNamedReferenceName();
		namedReferenceObjectInfo.ReferenceType = wire.getReferenceType();
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.NameLocaleStruct toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameLocaleStruct local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.NameLocaleStruct nameLocaleStruct = new Teamcenter.Schemas.Core._2010_04.Datamanagement.NameLocaleStruct();
		nameLocaleStruct.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Locales.Length; i++)
		{
			arrayList.Add(local.Locales[i]);
		}
		nameLocaleStruct.setLocales(arrayList);
		return nameLocaleStruct;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameLocaleStruct toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.NameLocaleStruct wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameLocaleStruct nameLocaleStruct = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameLocaleStruct();
		nameLocaleStruct.Name = wire.getName();
		IList locales = wire.getLocales();
		nameLocaleStruct.Locales = new string[locales.Count];
		for (int i = 0; i < locales.Count; i++)
		{
			nameLocaleStruct.Locales[i] = Convert.ToString(locales[i]);
		}
		return nameLocaleStruct;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.NameValueLocaleStruct toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameValueLocaleStruct local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.NameValueLocaleStruct nameValueLocaleStruct = new Teamcenter.Schemas.Core._2010_04.Datamanagement.NameValueLocaleStruct();
		nameValueLocaleStruct.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		nameValueLocaleStruct.setValues(arrayList);
		nameValueLocaleStruct.setLocale(local.Locale);
		nameValueLocaleStruct.setSeqNum(local.SeqNum);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Status.Length; i++)
		{
			arrayList2.Add(local.Status[i]);
		}
		nameValueLocaleStruct.setStatus(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.StatusDesc.Length; i++)
		{
			arrayList3.Add(local.StatusDesc[i]);
		}
		nameValueLocaleStruct.setStatusDesc(arrayList3);
		nameValueLocaleStruct.setMaster(local.Master);
		return nameValueLocaleStruct;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameValueLocaleStruct toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.NameValueLocaleStruct wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameValueLocaleStruct nameValueLocaleStruct = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameValueLocaleStruct();
		nameValueLocaleStruct.Name = wire.getName();
		IList values = wire.getValues();
		nameValueLocaleStruct.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			nameValueLocaleStruct.Values[i] = Convert.ToString(values[i]);
		}
		nameValueLocaleStruct.Locale = wire.getLocale();
		nameValueLocaleStruct.SeqNum = wire.getSeqNum();
		IList status = wire.getStatus();
		nameValueLocaleStruct.Status = new string[status.Count];
		for (int i = 0; i < status.Count; i++)
		{
			nameValueLocaleStruct.Status[i] = Convert.ToString(status[i]);
		}
		IList statusDesc = wire.getStatusDesc();
		nameValueLocaleStruct.StatusDesc = new string[statusDesc.Count];
		for (int i = 0; i < statusDesc.Count; i++)
		{
			nameValueLocaleStruct.StatusDesc[i] = Convert.ToString(statusDesc[i]);
		}
		nameValueLocaleStruct.Master = wire.Master;
		return nameValueLocaleStruct;
	}

	public static Teamcenter.Schemas.Core._2010_04.Datamanagement.PropertyInfo toWire(Teamcenter.Services.Strong.Core._2010_04.DataManagement.PropertyInfo local)
	{
		Teamcenter.Schemas.Core._2010_04.Datamanagement.PropertyInfo propertyInfo = new Teamcenter.Schemas.Core._2010_04.Datamanagement.PropertyInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		propertyInfo.setObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropsToget.Length; i++)
		{
			arrayList.Add(toWire(local.PropsToget[i]));
		}
		propertyInfo.setPropsToget(arrayList);
		return propertyInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.DataManagement.PropertyInfo toLocal(Teamcenter.Schemas.Core._2010_04.Datamanagement.PropertyInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.DataManagement.PropertyInfo propertyInfo = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.PropertyInfo();
		propertyInfo.Object = modelManager.LoadObjectData(wire.getObject());
		IList propsToget = wire.getPropsToget();
		propertyInfo.PropsToget = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.NameLocaleStruct[propsToget.Count];
		for (int i = 0; i < propsToget.Count; i++)
		{
			propertyInfo.PropsToget[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.NameLocaleStruct)propsToget[i], modelManager);
		}
		return propertyInfo;
	}

	public static ArrayList toWireBusinessObjectClassToTypesMap(IDictionary BusinessObjectClassToTypesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in BusinessObjectClassToTypesMap)
		{
			object key = item.Key;
			object value = item.Value;
			BusinessObjectClassToTypesMap businessObjectClassToTypesMap = new BusinessObjectClassToTypesMap();
			businessObjectClassToTypesMap.setKey(Convert.ToString(key));
			IList value2 = businessObjectClassToTypesMap.getValue();
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo[] array = (Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			businessObjectClassToTypesMap.setValue((ArrayList)value2);
			arrayList.Add(businessObjectClassToTypesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalBusinessObjectClassToTypesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			BusinessObjectClassToTypesMap businessObjectClassToTypesMap = (BusinessObjectClassToTypesMap)wire[i];
			string key = businessObjectClassToTypesMap.getKey();
			IList value = businessObjectClassToTypesMap.getValue();
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo[] array = new Teamcenter.Services.Strong.Core._2010_04.DataManagement.AvailableBusinessObjectTypeInfo[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2010_04.Datamanagement.AvailableBusinessObjectTypeInfo)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableSubBusinessObjectsResponse FindDisplayableSubBusinessObjectsWithDisplayNames(Teamcenter.Services.Strong.Core._2008_06.DataManagement.BOWithExclusionIn[] Input)
	{
		try
		{
			restSender.PushRequestId();
			FindDisplayableSubBusinessObjectsWithDisplayNamesInput findDisplayableSubBusinessObjectsWithDisplayNamesInput = new FindDisplayableSubBusinessObjectsWithDisplayNamesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			findDisplayableSubBusinessObjectsWithDisplayNamesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableSubBusinessObjectsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "FindDisplayableSubBusinessObjectsWithDisplayNames", findDisplayableSubBusinessObjectsWithDisplayNamesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableSubBusinessObjectsResponse wire = (Teamcenter.Schemas.Core._2010_04.Datamanagement.DisplayableSubBusinessObjectsResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.DisplayableSubBusinessObjectsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetAvailableBusinessObjectTypesResponse GetAvailableTypesWithDisplayNames(Teamcenter.Services.Strong.Core._2007_06.DataManagement.BaseClassInput[] Classes)
	{
		try
		{
			restSender.PushRequestId();
			GetAvailableTypesWithDisplayNamesInput getAvailableTypesWithDisplayNamesInput = new GetAvailableTypesWithDisplayNamesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Classes.Length; i++)
			{
				arrayList.Add(toWire(Classes[i]));
			}
			getAvailableTypesWithDisplayNamesInput.setClasses(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Datamanagement.GetAvailableBusinessObjectTypesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "GetAvailableTypesWithDisplayNames", getAvailableTypesWithDisplayNamesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Datamanagement.GetAvailableBusinessObjectTypesResponse wire = (Teamcenter.Schemas.Core._2010_04.Datamanagement.GetAvailableBusinessObjectTypesResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetAvailableBusinessObjectTypesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_04.DataManagement.CreateDatasetsResponse CreateDatasets(Teamcenter.Services.Strong.Core._2010_04.DataManagement.DatasetInfo[] Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2010_04.Datamanagement.CreateDatasetsInput createDatasetsInput = new Teamcenter.Schemas.Core._2010_04.Datamanagement.CreateDatasetsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createDatasetsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Datamanagement.CreateDatasetsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "CreateDatasets", createDatasetsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Datamanagement.CreateDatasetsResponse wire = (Teamcenter.Schemas.Core._2010_04.Datamanagement.CreateDatasetsResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.CreateDatasetsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetDatasetCreationRelatedInfoResponse2 GetDatasetCreationRelatedInfo2(string TypeName, Teamcenter.Soa.Client.Model.ModelObject ParentObject)
	{
		try
		{
			restSender.PushRequestId();
			GetDatasetCreationRelatedInfo2Input getDatasetCreationRelatedInfo2Input = new GetDatasetCreationRelatedInfo2Input();
			getDatasetCreationRelatedInfo2Input.setTypeName(TypeName);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (ParentObject == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(ParentObject.Uid);
			}
			getDatasetCreationRelatedInfo2Input.setParentObject(modelObject);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Datamanagement.GetDatasetCreationRelatedInfoResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "GetDatasetCreationRelatedInfo2", getDatasetCreationRelatedInfo2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Datamanagement.GetDatasetCreationRelatedInfoResponse2 wire = (Teamcenter.Schemas.Core._2010_04.Datamanagement.GetDatasetCreationRelatedInfoResponse2)obj;
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.GetDatasetCreationRelatedInfoResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesList GetLocalizedProperties(Teamcenter.Services.Strong.Core._2010_04.DataManagement.PropertyInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			GetLocalizedPropertiesInput getLocalizedPropertiesInput = new GetLocalizedPropertiesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			getLocalizedPropertiesInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesList);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "GetLocalizedProperties", getLocalizedPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesList wire = (Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizedPropertyValuesList)obj;
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesList result = toLocal(wire, modelManager);
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

	[Obsolete("As of Teamcenter 9, the isLocalizable information is part of propertydescriptor.", false)]
	public override Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusResponse IsPropertyLocalizable(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusInput[] InputInfo)
	{
		try
		{
			restSender.PushRequestId();
			IsPropertyLocalizableInput isPropertyLocalizableInput = new IsPropertyLocalizableInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputInfo.Length; i++)
			{
				arrayList.Add(toWire(InputInfo[i]));
			}
			isPropertyLocalizableInput.setInputInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "IsPropertyLocalizable", isPropertyLocalizableInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusResponse wire = (Teamcenter.Schemas.Core._2010_04.Datamanagement.LocalizableStatusResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizableStatusResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData SetLocalizedProperties(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo Info)
	{
		try
		{
			restSender.PushRequestId();
			SetLocalizedPropertiesInput setLocalizedPropertiesInput = new SetLocalizedPropertiesInput();
			setLocalizedPropertiesInput.setInfo(toWire(Info));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "SetLocalizedProperties", setLocalizedPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Soa.Client.Model.ServiceData SetLocalizedPropertyValues(Teamcenter.Services.Strong.Core._2010_04.DataManagement.LocalizedPropertyValuesInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			SetLocalizedPropertyValuesInput setLocalizedPropertyValuesInput = new SetLocalizedPropertyValuesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			setLocalizedPropertyValuesInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201004_PORT_NAME, "SetLocalizedPropertyValues", setLocalizedPropertyValuesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.CreateOrUpdateStaticTableDataResponse toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.CreateOrUpdateStaticTableDataResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.CreateOrUpdateStaticTableDataResponse createOrUpdateStaticTableDataResponse = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.CreateOrUpdateStaticTableDataResponse();
		createOrUpdateStaticTableDataResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		createOrUpdateStaticTableDataResponse.StaticTableObject = (Fnd0StaticTable)modelManager.LoadObjectData(wire.getStaticTableObject());
		return createOrUpdateStaticTableDataResponse;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.EventObject toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventObject local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.EventObject eventObject = new Teamcenter.Schemas.Core._2010_09.Datamanagement.EventObject();
		eventObject.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BusinessObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BusinessObject.Uid);
		}
		eventObject.setBusinessObject(modelObject);
		return eventObject;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventObject toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.EventObject wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventObject eventObject = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventObject();
		eventObject.ClientId = wire.getClientId();
		eventObject.BusinessObject = modelManager.LoadObjectData(wire.getBusinessObject());
		return eventObject;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesOutput toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesOutput local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesOutput eventTypesOutput = new Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesOutput();
		eventTypesOutput.setClientId(local.ClientId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AuditableEvents.Length; i++)
		{
			arrayList.Add(local.AuditableEvents[i]);
		}
		eventTypesOutput.setAuditableEvents(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.SubscribableEvents.Length; i++)
		{
			arrayList2.Add(local.SubscribableEvents[i]);
		}
		eventTypesOutput.setSubscribableEvents(arrayList2);
		return eventTypesOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesOutput toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesOutput eventTypesOutput = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesOutput();
		eventTypesOutput.ClientId = wire.getClientId();
		IList auditableEvents = wire.getAuditableEvents();
		eventTypesOutput.AuditableEvents = new string[auditableEvents.Count];
		for (int i = 0; i < auditableEvents.Count; i++)
		{
			eventTypesOutput.AuditableEvents[i] = Convert.ToString(auditableEvents[i]);
		}
		IList subscribableEvents = wire.getSubscribableEvents();
		eventTypesOutput.SubscribableEvents = new string[subscribableEvents.Count];
		for (int i = 0; i < subscribableEvents.Count; i++)
		{
			eventTypesOutput.SubscribableEvents[i] = Convert.ToString(subscribableEvents[i]);
		}
		return eventTypesOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesResponse toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesResponse eventTypesResponse = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesResponse();
		eventTypesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		eventTypesResponse.Output = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			eventTypesResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesOutput)output[i], modelManager);
		}
		return eventTypesResponse;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.NameValueStruct1 toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.NameValueStruct1 local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.NameValueStruct1 nameValueStruct = new Teamcenter.Schemas.Core._2010_09.Datamanagement.NameValueStruct1();
		nameValueStruct.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		nameValueStruct.setValues(arrayList);
		return nameValueStruct;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.NameValueStruct1 toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.NameValueStruct1 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.NameValueStruct1 nameValueStruct = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.NameValueStruct1();
		nameValueStruct.Name = wire.getName();
		IList values = wire.getValues();
		nameValueStruct.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			nameValueStruct.Values[i] = Convert.ToString(values[i]);
		}
		return nameValueStruct;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventObjectProperties toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventObjectProperties local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventObjectProperties postEventObjectProperties = new Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventObjectProperties();
		postEventObjectProperties.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryObject.Uid);
		}
		postEventObjectProperties.setPrimaryObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SecondaryObject == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.SecondaryObject.Uid);
		}
		postEventObjectProperties.setSecondaryObject(modelObject2);
		postEventObjectProperties.setPropertyCount(local.PropertyCount);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropertyNames.Length; i++)
		{
			arrayList.Add(local.PropertyNames[i]);
		}
		postEventObjectProperties.setPropertyNames(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.PropertyValues.Length; i++)
		{
			arrayList2.Add(local.PropertyValues[i]);
		}
		postEventObjectProperties.setPropertyValues(arrayList2);
		postEventObjectProperties.setErrorCode(local.ErrorCode);
		postEventObjectProperties.setErrorMessage(local.ErrorMessage);
		return postEventObjectProperties;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventObjectProperties toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventObjectProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventObjectProperties postEventObjectProperties = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventObjectProperties();
		postEventObjectProperties.ClientId = wire.getClientId();
		postEventObjectProperties.PrimaryObject = modelManager.LoadObjectData(wire.getPrimaryObject());
		postEventObjectProperties.SecondaryObject = modelManager.LoadObjectData(wire.getSecondaryObject());
		postEventObjectProperties.PropertyCount = wire.getPropertyCount();
		IList propertyNames = wire.getPropertyNames();
		postEventObjectProperties.PropertyNames = new string[propertyNames.Count];
		for (int i = 0; i < propertyNames.Count; i++)
		{
			postEventObjectProperties.PropertyNames[i] = Convert.ToString(propertyNames[i]);
		}
		IList propertyValues = wire.getPropertyValues();
		postEventObjectProperties.PropertyValues = new string[propertyValues.Count];
		for (int i = 0; i < propertyValues.Count; i++)
		{
			postEventObjectProperties.PropertyValues[i] = Convert.ToString(propertyValues[i]);
		}
		postEventObjectProperties.ErrorCode = wire.getErrorCode();
		postEventObjectProperties.ErrorMessage = wire.getErrorMessage();
		return postEventObjectProperties;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventOutput toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventOutput local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventOutput postEventOutput = new Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventOutput();
		postEventOutput.setClientId(local.ClientId);
		postEventOutput.setIfailError(local.IfailError);
		return postEventOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventOutput toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventOutput postEventOutput = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventOutput();
		postEventOutput.ClientId = wire.getClientId();
		postEventOutput.IfailError = wire.getIfailError();
		return postEventOutput;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventResponse toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventResponse postEventResponse = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventResponse();
		postEventResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		postEventResponse.Output = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			postEventResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventOutput)output[i], modelManager);
		}
		return postEventResponse;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.PropInfo toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.PropInfo local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.PropInfo propInfo = new Teamcenter.Schemas.Core._2010_09.Datamanagement.PropInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		propInfo.setObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.VecNameVal.Length; i++)
		{
			arrayList.Add(toWire(local.VecNameVal[i]));
		}
		propInfo.setVecNameVal(arrayList);
		propInfo.setTimestamp(TcServerDate.ToWire(local.Timestamp));
		return propInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.PropInfo toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.PropInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.PropInfo propInfo = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.PropInfo();
		propInfo.Object = modelManager.LoadObjectData(wire.getObject());
		IList vecNameVal = wire.getVecNameVal();
		propInfo.VecNameVal = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.NameValueStruct1[vecNameVal.Count];
		for (int i = 0; i < vecNameVal.Count; i++)
		{
			propInfo.VecNameVal[i] = toLocal((Teamcenter.Schemas.Core._2010_09.Datamanagement.NameValueStruct1)vecNameVal[i], modelManager);
		}
		propInfo.Timestamp = TcServerDate.ToLocal(wire.getTimestamp());
		return propInfo;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.RowData toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.RowData local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.RowData rowData = new Teamcenter.Schemas.Core._2010_09.Datamanagement.RowData();
		rowData.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RowObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RowObject.Uid);
		}
		rowData.setRowObject(modelObject);
		rowData.setRowType(local.RowType);
		rowData.setRowAttrValueMap(toWireRowAttrValueMap(local.RowAttrValueMap));
		return rowData;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.RowData toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.RowData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.RowData rowData = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.RowData();
		rowData.ClientId = wire.getClientId();
		rowData.RowObject = (POM_object)modelManager.LoadObjectData(wire.getRowObject());
		rowData.RowType = wire.getRowType();
		rowData.RowAttrValueMap = toLocalRowAttrValueMap(wire.getRowAttrValueMap(), modelManager);
		return rowData;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.SetPropertyResponse toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.SetPropertyResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.SetPropertyResponse setPropertyResponse = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.SetPropertyResponse();
		setPropertyResponse.Data = modelManager.LoadServiceData(wire.getServiceData());
		setPropertyResponse.ObjPropMap = toLocalObjectPropMap(wire.getObjPropMap(), modelManager);
		return setPropertyResponse;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableDataResponse toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableDataResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableDataResponse staticTableDataResponse = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableDataResponse();
		staticTableDataResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		staticTableDataResponse.ClientId = wire.getClientId();
		return staticTableDataResponse;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableInfo toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableInfo local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableInfo staticTableInfo = new Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableInfo();
		staticTableInfo.setTableType(local.TableType);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TableObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TableObject.Uid);
		}
		staticTableInfo.setTableObject(modelObject);
		return staticTableInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableInfo toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableInfo staticTableInfo = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableInfo();
		staticTableInfo.TableType = wire.getTableType();
		staticTableInfo.TableObject = (Fnd0StaticTable)modelManager.LoadObjectData(wire.getTableObject());
		return staticTableInfo;
	}

	public static Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionInfo toWire(Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionInfo local)
	{
		Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionInfo verifyExtensionInfo = new Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionInfo();
		verifyExtensionInfo.setTypeName(local.TypeName);
		verifyExtensionInfo.setOperationName(local.OperationName);
		verifyExtensionInfo.setExtensionName(local.ExtensionName);
		verifyExtensionInfo.setExtensionType(local.ExtensionType);
		return verifyExtensionInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionInfo toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionInfo verifyExtensionInfo = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionInfo();
		verifyExtensionInfo.TypeName = wire.getTypeName();
		verifyExtensionInfo.OperationName = wire.getOperationName();
		verifyExtensionInfo.ExtensionName = wire.getExtensionName();
		verifyExtensionInfo.ExtensionType = wire.getExtensionType();
		return verifyExtensionInfo;
	}

	public static Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionResponse toLocal(Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionResponse verifyExtensionResponse = new Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionResponse();
		verifyExtensionResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		verifyExtensionResponse.Output = new bool[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			verifyExtensionResponse.Output[i] = Convert.ToBoolean(output[i]);
		}
		return verifyExtensionResponse;
	}

	public static ArrayList toWireObjectPropMap(IDictionary ObjectPropMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ObjectPropMap)
		{
			object key = item.Key;
			object value = item.Value;
			ObjectPropMap objectPropMap = new ObjectPropMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			objectPropMap.setKey(modelObject);
			IList value2 = objectPropMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			objectPropMap.setValue((ArrayList)value2);
			arrayList.Add(objectPropMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalObjectPropMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ObjectPropMap objectPropMap = (ObjectPropMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(objectPropMap.getKey());
			IList value = objectPropMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireRowAttrValueMap(IDictionary RowAttrValueMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in RowAttrValueMap)
		{
			object key = item.Key;
			object value = item.Value;
			RowAttrValueMap rowAttrValueMap = new RowAttrValueMap();
			rowAttrValueMap.setKey(Convert.ToString(key));
			IList value2 = rowAttrValueMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			rowAttrValueMap.setValue((ArrayList)value2);
			arrayList.Add(rowAttrValueMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalRowAttrValueMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			RowAttrValueMap rowAttrValueMap = (RowAttrValueMap)wire[i];
			string key = rowAttrValueMap.getKey();
			IList value = rowAttrValueMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2010_09.DataManagement.SetPropertyResponse SetProperties(Teamcenter.Services.Strong.Core._2010_09.DataManagement.PropInfo[] Info, string[] Options)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2010_09.Datamanagement.SetPropertiesInput setPropertiesInput = new Teamcenter.Schemas.Core._2010_09.Datamanagement.SetPropertiesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			setPropertiesInput.setInfo(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < Options.Length; i++)
			{
				arrayList2.Add(Options[i]);
			}
			setPropertiesInput.setOptions(arrayList2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_09.Datamanagement.SetPropertyResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "SetProperties", setPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_09.Datamanagement.SetPropertyResponse wire = (Teamcenter.Schemas.Core._2010_09.Datamanagement.SetPropertyResponse)obj;
			Teamcenter.Services.Strong.Core._2010_09.DataManagement.SetPropertyResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionResponse VerifyExtension(Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionInfo[] ExtensionInfo)
	{
		try
		{
			restSender.PushRequestId();
			VerifyExtensionInput verifyExtensionInput = new VerifyExtensionInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ExtensionInfo.Length; i++)
			{
				arrayList.Add(toWire(ExtensionInfo[i]));
			}
			verifyExtensionInput.setExtensionInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "VerifyExtension", verifyExtensionInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionResponse wire = (Teamcenter.Schemas.Core._2010_09.Datamanagement.VerifyExtensionResponse)obj;
			Teamcenter.Services.Strong.Core._2010_09.DataManagement.VerifyExtensionResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_09.DataManagement.CreateOrUpdateStaticTableDataResponse CreateOrUpdateStaticTableData(Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableInfo StaticTableInfo, Teamcenter.Services.Strong.Core._2010_09.DataManagement.RowData[] RowProperties)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateStaticTableDataInput createOrUpdateStaticTableDataInput = new CreateOrUpdateStaticTableDataInput();
			createOrUpdateStaticTableDataInput.setStaticTableInfo(toWire(StaticTableInfo));
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < RowProperties.Length; i++)
			{
				arrayList.Add(toWire(RowProperties[i]));
			}
			createOrUpdateStaticTableDataInput.setRowProperties(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_09.Datamanagement.CreateOrUpdateStaticTableDataResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "CreateOrUpdateStaticTableData", createOrUpdateStaticTableDataInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_09.Datamanagement.CreateOrUpdateStaticTableDataResponse wire = (Teamcenter.Schemas.Core._2010_09.Datamanagement.CreateOrUpdateStaticTableDataResponse)obj;
			Teamcenter.Services.Strong.Core._2010_09.DataManagement.CreateOrUpdateStaticTableDataResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableDataResponse GetStaticTableData(Fnd0StaticTable StaticTable)
	{
		try
		{
			restSender.PushRequestId();
			GetStaticTableDataInput getStaticTableDataInput = new GetStaticTableDataInput();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (StaticTable == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(StaticTable.Uid);
			}
			getStaticTableDataInput.setStaticTable(modelObject);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableDataResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "GetStaticTableData", getStaticTableDataInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableDataResponse wire = (Teamcenter.Schemas.Core._2010_09.Datamanagement.StaticTableDataResponse)obj;
			Teamcenter.Services.Strong.Core._2010_09.DataManagement.StaticTableDataResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesResponse GetEventTypes(Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventObject[] Input)
	{
		try
		{
			restSender.PushRequestId();
			GetEventTypesInput getEventTypesInput = new GetEventTypesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			getEventTypesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "GetEventTypes", getEventTypesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesResponse wire = (Teamcenter.Schemas.Core._2010_09.Datamanagement.EventTypesResponse)obj;
			Teamcenter.Services.Strong.Core._2010_09.DataManagement.EventTypesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventResponse PostEvent(Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventObjectProperties[] Input, string EventTypeName)
	{
		try
		{
			restSender.PushRequestId();
			PostEventInput postEventInput = new PostEventInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			postEventInput.setInput(arrayList);
			postEventInput.setEventTypeName(EventTypeName);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201009_PORT_NAME, "PostEvent", postEventInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventResponse wire = (Teamcenter.Schemas.Core._2010_09.Datamanagement.PostEventResponse)obj;
			Teamcenter.Services.Strong.Core._2010_09.DataManagement.PostEventResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsInput toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsInput local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsInput saveAsInput = new Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsInput();
		saveAsInput.setBoName(local.BoName);
		saveAsInput.setStringProps(toWireStringMap1(local.StringProps));
		saveAsInput.setStringArrayProps(toWireStringVectorMap1(local.StringArrayProps));
		saveAsInput.setDoubleProps(toWireDoubleMap1(local.DoubleProps));
		saveAsInput.setDoubleArrayProps(toWireDoubleVectorMap1(local.DoubleArrayProps));
		saveAsInput.setFloatProps(toWireFloatMap1(local.FloatProps));
		saveAsInput.setFloatArrayProps(toWireFloatVectorMap1(local.FloatArrayProps));
		saveAsInput.setIntProps(toWireIntMap1(local.IntProps));
		saveAsInput.setIntArrayProps(toWireIntVectorMap1(local.IntArrayProps));
		saveAsInput.setBoolProps(toWireBoolMap1(local.BoolProps));
		saveAsInput.setBoolArrayProps(toWireBoolVectorMap1(local.BoolArrayProps));
		saveAsInput.setDateProps(toWireDateMap1(local.DateProps));
		saveAsInput.setDateArrayProps(toWireDateVectorMap1(local.DateArrayProps));
		saveAsInput.setTagProps(toWireTagMap1(local.TagProps));
		saveAsInput.setTagArrayProps(toWireTagVectorMap1(local.TagArrayProps));
		return saveAsInput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsInput toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsInput saveAsInput = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsInput();
		saveAsInput.BoName = wire.getBoName();
		saveAsInput.StringProps = toLocalStringMap1(wire.getStringProps(), modelManager);
		saveAsInput.StringArrayProps = toLocalStringVectorMap1(wire.getStringArrayProps(), modelManager);
		saveAsInput.DoubleProps = toLocalDoubleMap1(wire.getDoubleProps(), modelManager);
		saveAsInput.DoubleArrayProps = toLocalDoubleVectorMap1(wire.getDoubleArrayProps(), modelManager);
		saveAsInput.FloatProps = toLocalFloatMap1(wire.getFloatProps(), modelManager);
		saveAsInput.FloatArrayProps = toLocalFloatVectorMap1(wire.getFloatArrayProps(), modelManager);
		saveAsInput.IntProps = toLocalIntMap1(wire.getIntProps(), modelManager);
		saveAsInput.IntArrayProps = toLocalIntVectorMap1(wire.getIntArrayProps(), modelManager);
		saveAsInput.BoolProps = toLocalBoolMap1(wire.getBoolProps(), modelManager);
		saveAsInput.BoolArrayProps = toLocalBoolVectorMap1(wire.getBoolArrayProps(), modelManager);
		saveAsInput.DateProps = toLocalDateMap1(wire.getDateProps(), modelManager);
		saveAsInput.DateArrayProps = toLocalDateVectorMap1(wire.getDateArrayProps(), modelManager);
		saveAsInput.TagProps = toLocalTagMap1(wire.getTagProps(), modelManager);
		saveAsInput.TagArrayProps = toLocalTagVectorMap1(wire.getTagArrayProps(), modelManager);
		return saveAsInput;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.DeepCopyData toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.DeepCopyData local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.DeepCopyData deepCopyData = new Teamcenter.Schemas.Core._2011_06.Datamanagement.DeepCopyData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.AttachedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.AttachedObject.Uid);
		}
		deepCopyData.setAttachedObject(modelObject);
		deepCopyData.setPropertyName(local.PropertyName);
		deepCopyData.setPropertyType(local.PropertyType);
		deepCopyData.setCopyAction(local.CopyAction);
		deepCopyData.setIsTargetPrimary(local.IsTargetPrimary);
		deepCopyData.setIsRequired(local.IsRequired);
		deepCopyData.setCopyRelations(local.CopyRelations);
		deepCopyData.setSaveAsInputTypeName(local.SaveAsInputTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildDeepCopyData.Length; i++)
		{
			arrayList.Add(toWire(local.ChildDeepCopyData[i]));
		}
		deepCopyData.setChildDeepCopyData(arrayList);
		deepCopyData.setSaveAsInput(toWire(local.SaveAsInput));
		return deepCopyData;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.DeepCopyData toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.DeepCopyData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.DeepCopyData deepCopyData = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.DeepCopyData();
		deepCopyData.AttachedObject = modelManager.LoadObjectData(wire.getAttachedObject());
		deepCopyData.PropertyName = wire.getPropertyName();
		deepCopyData.PropertyType = wire.getPropertyType();
		deepCopyData.CopyAction = wire.getCopyAction();
		deepCopyData.IsTargetPrimary = wire.IsTargetPrimary;
		deepCopyData.IsRequired = wire.IsRequired;
		deepCopyData.CopyRelations = wire.CopyRelations;
		deepCopyData.SaveAsInputTypeName = wire.getSaveAsInputTypeName();
		IList childDeepCopyData = wire.getChildDeepCopyData();
		deepCopyData.ChildDeepCopyData = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.DeepCopyData[childDeepCopyData.Count];
		for (int i = 0; i < childDeepCopyData.Count; i++)
		{
			deepCopyData.ChildDeepCopyData[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.DeepCopyData)childDeepCopyData[i], modelManager);
		}
		deepCopyData.SaveAsInput = toLocal(wire.getSaveAsInput(), modelManager);
		return deepCopyData;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.ObjectInfo toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.ObjectInfo local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.ObjectInfo objectInfo = new Teamcenter.Schemas.Core._2011_06.Datamanagement.ObjectInfo();
		objectInfo.setContextName(local.ContextName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.DisplayObj == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.DisplayObj.Uid);
		}
		objectInfo.setDisplayObj(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Object.Uid);
		}
		objectInfo.setObject(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomView == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.BomView.Uid);
		}
		objectInfo.setBomView(modelObject3);
		return objectInfo;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.ObjectInfo toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.ObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.ObjectInfo objectInfo = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.ObjectInfo();
		objectInfo.ContextName = wire.getContextName();
		objectInfo.DisplayObj = (WorkspaceObject)modelManager.LoadObjectData(wire.getDisplayObj());
		objectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		objectInfo.BomView = (PSBOMView)modelManager.LoadObjectData(wire.getBomView());
		return objectInfo;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.Report toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.Report report = new Teamcenter.Schemas.Core._2011_06.Datamanagement.Report();
		report.setParent(toWire(local.Parent));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			arrayList.Add(toWire(local.Children[i]));
		}
		report.setChildren(arrayList);
		return report;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.Report wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report report = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report();
		report.Parent = toLocal(wire.getParent(), modelManager);
		IList children = wire.getChildren();
		report.Children = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.ObjectInfo[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			report.Children[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.ObjectInfo)children[i], modelManager);
		}
		return report;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsIn toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsIn local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsIn saveAsIn = new Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsIn();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		saveAsIn.setTargetObject(modelObject);
		saveAsIn.setSaveAsInput(toWire(local.SaveAsInput));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DeepCopyDatas.Length; i++)
		{
			arrayList.Add(toWire(local.DeepCopyDatas[i]));
		}
		saveAsIn.setDeepCopyDatas(arrayList);
		return saveAsIn;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsIn toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsIn saveAsIn = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsIn();
		saveAsIn.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		saveAsIn.SaveAsInput = toLocal(wire.getSaveAsInput(), modelManager);
		IList deepCopyDatas = wire.getDeepCopyDatas();
		saveAsIn.DeepCopyDatas = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.DeepCopyData[deepCopyDatas.Count];
		for (int i = 0; i < deepCopyDatas.Count; i++)
		{
			saveAsIn.DeepCopyDatas[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.DeepCopyData)deepCopyDatas[i], modelManager);
		}
		return saveAsIn;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse saveAsObjectsResponse = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse();
		saveAsObjectsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		saveAsObjectsResponse.Output = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsOut[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			saveAsObjectsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsOut)output[i], modelManager);
		}
		IList saveAsTrees = wire.getSaveAsTrees();
		saveAsObjectsResponse.SaveAsTrees = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsTree[saveAsTrees.Count];
		for (int i = 0; i < saveAsTrees.Count; i++)
		{
			saveAsObjectsResponse.SaveAsTrees[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsTree)saveAsTrees[i], modelManager);
		}
		return saveAsObjectsResponse;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsOut toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsOut local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsOut saveAsOut = new Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsOut();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		saveAsOut.setTargetObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Objects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Objects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Objects[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		saveAsOut.setObjects(arrayList);
		return saveAsOut;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsOut toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsOut wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsOut saveAsOut = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsOut();
		saveAsOut.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		IList objects = wire.getObjects();
		saveAsOut.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			saveAsOut.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		return saveAsOut;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsTree toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsTree local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsTree saveAsTree = new Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsTree();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OriginalObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OriginalObject.Uid);
		}
		saveAsTree.setOriginalObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectCopy == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ObjectCopy.Uid);
		}
		saveAsTree.setObjectCopy(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildSaveAsNodes.Length; i++)
		{
			arrayList.Add(toWire(local.ChildSaveAsNodes[i]));
		}
		saveAsTree.setChildSaveAsNodes(arrayList);
		return saveAsTree;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsTree toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsTree wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsTree saveAsTree = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsTree();
		saveAsTree.OriginalObject = modelManager.LoadObjectData(wire.getOriginalObject());
		saveAsTree.ObjectCopy = modelManager.LoadObjectData(wire.getObjectCopy());
		IList childSaveAsNodes = wire.getChildSaveAsNodes();
		saveAsTree.ChildSaveAsNodes = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsTree[childSaveAsNodes.Count];
		for (int i = 0; i < childSaveAsNodes.Count; i++)
		{
			saveAsTree.ChildSaveAsNodes[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsTree)childSaveAsNodes[i], modelManager);
		}
		return saveAsTree;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityInfoInput toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityInfoInput local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityInfoInput traceabilityInfoInput = new Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityInfoInput();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.SelectedObjs.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.SelectedObjs[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.SelectedObjs[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		traceabilityInfoInput.setSelectedObjs(arrayList);
		traceabilityInfoInput.setReportType(local.ReportType);
		traceabilityInfoInput.setReportDepth(local.ReportDepth);
		traceabilityInfoInput.setIsIndirectTraceReportNeeded(local.IsIndirectTraceReportNeeded);
		traceabilityInfoInput.setRelationTypeName(local.RelationTypeName);
		return traceabilityInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityInfoInput toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityInfoInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityInfoInput traceabilityInfoInput = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityInfoInput();
		IList selectedObjs = wire.getSelectedObjs();
		traceabilityInfoInput.SelectedObjs = new Teamcenter.Soa.Client.Model.ModelObject[selectedObjs.Count];
		for (int i = 0; i < selectedObjs.Count; i++)
		{
			traceabilityInfoInput.SelectedObjs[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)selectedObjs[i]);
		}
		traceabilityInfoInput.ReportType = wire.getReportType();
		traceabilityInfoInput.ReportDepth = wire.getReportDepth();
		traceabilityInfoInput.IsIndirectTraceReportNeeded = wire.IsIndirectTraceReportNeeded;
		traceabilityInfoInput.RelationTypeName = wire.getRelationTypeName();
		return traceabilityInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityReportOutput toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityReportOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityReportOutput traceabilityReportOutput = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityReportOutput();
		traceabilityReportOutput.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList traceReports = wire.getTraceReports();
		traceabilityReportOutput.TraceReports = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceReport[traceReports.Count];
		for (int i = 0; i < traceReports.Count; i++)
		{
			traceabilityReportOutput.TraceReports[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceReport)traceReports[i], modelManager);
		}
		return traceabilityReportOutput;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceReport toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceReport local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceReport traceReport = new Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceReport();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DefiningTree.Length; i++)
		{
			arrayList.Add(toWire(local.DefiningTree[i]));
		}
		traceReport.setDefiningTree(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.IndirectDefiningTree.Length; i++)
		{
			arrayList2.Add(toWire(local.IndirectDefiningTree[i]));
		}
		traceReport.setIndirectDefiningTree(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ComplyingTree.Length; i++)
		{
			arrayList3.Add(toWire(local.ComplyingTree[i]));
		}
		traceReport.setComplyingTree(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.IndirectComplyingTree.Length; i++)
		{
			arrayList4.Add(toWire(local.IndirectComplyingTree[i]));
		}
		traceReport.setIndirectComplyingTree(arrayList4);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SelectedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.SelectedObject.Uid);
		}
		traceReport.setSelectedObject(modelObject);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.PersistentObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PersistentObjects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.PersistentObjects[i].Uid);
			}
			arrayList5.Add(modelObject2);
		}
		traceReport.setPersistentObjects(arrayList5);
		return traceReport;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceReport toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceReport wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceReport traceReport = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceReport();
		IList definingTree = wire.getDefiningTree();
		traceReport.DefiningTree = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report[definingTree.Count];
		for (int i = 0; i < definingTree.Count; i++)
		{
			traceReport.DefiningTree[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.Report)definingTree[i], modelManager);
		}
		IList indirectDefiningTree = wire.getIndirectDefiningTree();
		traceReport.IndirectDefiningTree = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report[indirectDefiningTree.Count];
		for (int i = 0; i < indirectDefiningTree.Count; i++)
		{
			traceReport.IndirectDefiningTree[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.Report)indirectDefiningTree[i], modelManager);
		}
		IList complyingTree = wire.getComplyingTree();
		traceReport.ComplyingTree = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report[complyingTree.Count];
		for (int i = 0; i < complyingTree.Count; i++)
		{
			traceReport.ComplyingTree[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.Report)complyingTree[i], modelManager);
		}
		IList indirectComplyingTree = wire.getIndirectComplyingTree();
		traceReport.IndirectComplyingTree = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.Report[indirectComplyingTree.Count];
		for (int i = 0; i < indirectComplyingTree.Count; i++)
		{
			traceReport.IndirectComplyingTree[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.Report)indirectComplyingTree[i], modelManager);
		}
		traceReport.SelectedObject = modelManager.LoadObjectData(wire.getSelectedObject());
		IList persistentObjects = wire.getPersistentObjects();
		traceReport.PersistentObjects = new Teamcenter.Soa.Client.Model.ModelObject[persistentObjects.Count];
		for (int i = 0; i < persistentObjects.Count; i++)
		{
			traceReport.PersistentObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)persistentObjects[i]);
		}
		return traceReport;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsInfo toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsInfo local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsInfo validateRevIdsInfo = new Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsInfo();
		validateRevIdsInfo.setRevId(local.RevId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemObject.Uid);
		}
		validateRevIdsInfo.setItemObject(modelObject);
		validateRevIdsInfo.setItemType(local.ItemType);
		return validateRevIdsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsInfo toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsInfo validateRevIdsInfo = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsInfo();
		validateRevIdsInfo.RevId = wire.getRevId();
		validateRevIdsInfo.ItemObject = (Item)modelManager.LoadObjectData(wire.getItemObject());
		validateRevIdsInfo.ItemType = wire.getItemType();
		return validateRevIdsInfo;
	}

	public static Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsOutput toWire(Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsOutput local)
	{
		Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsOutput validateRevIdsOutput = new Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsOutput();
		validateRevIdsOutput.setModRevId(local.ModRevId);
		validateRevIdsOutput.setRevIdStatus(local.RevIdStatus);
		return validateRevIdsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsOutput toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsOutput validateRevIdsOutput = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsOutput();
		validateRevIdsOutput.ModRevId = wire.getModRevId();
		validateRevIdsOutput.RevIdStatus = wire.getRevIdStatus();
		return validateRevIdsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsResponse toLocal(Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsResponse validateRevIdsResponse = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsResponse();
		validateRevIdsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		validateRevIdsResponse.Output = new Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			validateRevIdsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsOutput)output[i], modelManager);
		}
		return validateRevIdsResponse;
	}

	public static ArrayList toWireBoolMap1(IDictionary BoolMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in BoolMap1)
		{
			object key = item.Key;
			object value = item.Value;
			BoolMap1 boolMap = new BoolMap1();
			boolMap.setKey(Convert.ToString(key));
			boolMap.setValue(Convert.ToBoolean(value));
			arrayList.Add(boolMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalBoolMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			BoolMap1 boolMap = (BoolMap1)wire[i];
			string key = boolMap.getKey();
			bool value = boolMap.Value;
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireBoolVectorMap1(IDictionary BoolVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in BoolVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			BoolVectorMap1 boolVectorMap = new BoolVectorMap1();
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

	public static Hashtable toLocalBoolVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			BoolVectorMap1 boolVectorMap = (BoolVectorMap1)wire[i];
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

	public static ArrayList toWireDateMap1(IDictionary DateMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DateMap1)
		{
			object key = item.Key;
			object value = item.Value;
			DateMap1 dateMap = new DateMap1();
			dateMap.setKey(Convert.ToString(key));
			dateMap.setValue(TcServerDate.ToWire((DateTime)value));
			arrayList.Add(dateMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDateMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DateMap1 dateMap = (DateMap1)wire[i];
			string key = dateMap.getKey();
			DateTime dateTime = TcServerDate.ToLocal(dateMap.getValue());
			hashtable.Add(key, dateTime);
		}
		return hashtable;
	}

	public static ArrayList toWireDateVectorMap1(IDictionary DateVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DateVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			DateVectorMap1 dateVectorMap = new DateVectorMap1();
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

	public static Hashtable toLocalDateVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DateVectorMap1 dateVectorMap = (DateVectorMap1)wire[i];
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

	public static ArrayList toWireDoubleMap1(IDictionary DoubleMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DoubleMap1)
		{
			object key = item.Key;
			object value = item.Value;
			DoubleMap1 doubleMap = new DoubleMap1();
			doubleMap.setKey(Convert.ToString(key));
			doubleMap.setValue(Convert.ToDouble(value));
			arrayList.Add(doubleMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDoubleMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DoubleMap1 doubleMap = (DoubleMap1)wire[i];
			string key = doubleMap.getKey();
			double value = doubleMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireDoubleVectorMap1(IDictionary DoubleVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DoubleVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			DoubleVectorMap1 doubleVectorMap = new DoubleVectorMap1();
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

	public static Hashtable toLocalDoubleVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DoubleVectorMap1 doubleVectorMap = (DoubleVectorMap1)wire[i];
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

	public static ArrayList toWireFloatMap1(IDictionary FloatMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in FloatMap1)
		{
			object key = item.Key;
			object value = item.Value;
			FloatMap1 floatMap = new FloatMap1();
			floatMap.setKey(Convert.ToString(key));
			floatMap.setValue(Convert.ToSingle(value));
			arrayList.Add(floatMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalFloatMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			FloatMap1 floatMap = (FloatMap1)wire[i];
			string key = floatMap.getKey();
			float value = floatMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireFloatVectorMap1(IDictionary FloatVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in FloatVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			FloatVectorMap1 floatVectorMap = new FloatVectorMap1();
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

	public static Hashtable toLocalFloatVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			FloatVectorMap1 floatVectorMap = (FloatVectorMap1)wire[i];
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

	public static ArrayList toWireIntMap1(IDictionary IntMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IntMap1)
		{
			object key = item.Key;
			object value = item.Value;
			IntMap1 intMap = new IntMap1();
			intMap.setKey(Convert.ToString(key));
			intMap.setValue((int)value);
			arrayList.Add(intMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalIntMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IntMap1 intMap = (IntMap1)wire[i];
			string key = intMap.getKey();
			int value = intMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireIntVectorMap1(IDictionary IntVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in IntVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			IntVectorMap1 intVectorMap = new IntVectorMap1();
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

	public static Hashtable toLocalIntVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			IntVectorMap1 intVectorMap = (IntVectorMap1)wire[i];
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

	public static ArrayList toWireStringMap1(IDictionary StringMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in StringMap1)
		{
			object key = item.Key;
			object value = item.Value;
			StringMap1 stringMap = new StringMap1();
			stringMap.setKey(Convert.ToString(key));
			stringMap.setValue(Convert.ToString(value));
			arrayList.Add(stringMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalStringMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			StringMap1 stringMap = (StringMap1)wire[i];
			string key = stringMap.getKey();
			string value = stringMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireStringVectorMap1(IDictionary StringVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in StringVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			StringVectorMap1 stringVectorMap = new StringVectorMap1();
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

	public static Hashtable toLocalStringVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			StringVectorMap1 stringVectorMap = (StringVectorMap1)wire[i];
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

	public static ArrayList toWireTagMap1(IDictionary TagMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TagMap1)
		{
			object key = item.Key;
			object value = item.Value;
			TagMap1 tagMap = new TagMap1();
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

	public static Hashtable toLocalTagMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			TagMap1 tagMap = (TagMap1)wire[i];
			string key = tagMap.getKey();
			Teamcenter.Soa.Client.Model.ModelObject value = modelManager.LoadObjectData(tagMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireTagVectorMap1(IDictionary TagVectorMap1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TagVectorMap1)
		{
			object key = item.Key;
			object value = item.Value;
			TagVectorMap1 tagVectorMap = new TagVectorMap1();
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

	public static Hashtable toLocalTagVectorMap1(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			TagVectorMap1 tagVectorMap = (TagVectorMap1)wire[i];
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

	public override Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsResponse ValidateRevIds(Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			ValidateRevIdsInput validateRevIdsInput = new ValidateRevIdsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			validateRevIdsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201106_PORT_NAME, "ValidateRevIds", validateRevIdsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsResponse wire = (Teamcenter.Schemas.Core._2011_06.Datamanagement.ValidateRevIdsResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.DataManagement.ValidateRevIdsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse SaveAsObjects(Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsIn[] SaveAsIn)
	{
		try
		{
			restSender.PushRequestId();
			SaveAsObjectsInput saveAsObjectsInput = new SaveAsObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < SaveAsIn.Length; i++)
			{
				arrayList.Add(toWire(SaveAsIn[i]));
			}
			saveAsObjectsInput.setSaveAsIn(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201106_PORT_NAME, "SaveAsObjects", saveAsObjectsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse wire = (Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Teamcenter 10.1.2, use the getTraceReport2 operation. New getTraceReport operation returns BVR specific context line information also.", false)]
	public override Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityReportOutput GetTraceReport(Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityInfoInput Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2011_06.Datamanagement.GetTraceReportInput getTraceReportInput = new Teamcenter.Schemas.Core._2011_06.Datamanagement.GetTraceReportInput();
			getTraceReportInput.setInput(toWire(Input));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityReportOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201106_PORT_NAME, "GetTraceReport", getTraceReportInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityReportOutput wire = (Teamcenter.Schemas.Core._2011_06.Datamanagement.TraceabilityReportOutput)obj;
			Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityReportOutput result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2012_02.Datamanagement.BulkCreIn toWire(Teamcenter.Services.Strong.Core._2012_02.DataManagement.BulkCreIn local)
	{
		Teamcenter.Schemas.Core._2012_02.Datamanagement.BulkCreIn bulkCreIn = new Teamcenter.Schemas.Core._2012_02.Datamanagement.BulkCreIn();
		bulkCreIn.setClientId(local.ClientId);
		bulkCreIn.setQuantity(local.Quantity);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Folder.Uid);
		}
		bulkCreIn.setFolder(modelObject);
		bulkCreIn.setData(toWire(local.Data));
		return bulkCreIn;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.BulkCreIn toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.BulkCreIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.BulkCreIn bulkCreIn = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.BulkCreIn();
		bulkCreIn.ClientId = wire.getClientId();
		bulkCreIn.Quantity = wire.getQuantity();
		bulkCreIn.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		bulkCreIn.Data = toLocal(wire.getData(), modelManager);
		return bulkCreIn;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.ValidationResponse toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.ValidationResponse validationResponse = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.ValidationResponse();
		validationResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		validationResponse.ValidationResult = toLocalValidationResult(wire.getValidationResult(), modelManager);
		return validationResponse;
	}

	public static Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedConfigParameters toWire(Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedConfigParameters local)
	{
		Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedConfigParameters whereUsedConfigParameters = new Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedConfigParameters();
		whereUsedConfigParameters.setStringMap(toWireWUStringMap(local.StringMap));
		whereUsedConfigParameters.setDoubleMap(toWireWUDoubleMap(local.DoubleMap));
		whereUsedConfigParameters.setIntMap(toWireWUIntMap(local.IntMap));
		whereUsedConfigParameters.setBoolMap(toWireWUBoolMap(local.BoolMap));
		whereUsedConfigParameters.setDateMap(toWireWUDateMap(local.DateMap));
		whereUsedConfigParameters.setTagMap(toWireWUTagMap(local.TagMap));
		whereUsedConfigParameters.setFloatMap(toWireWUFloatMap(local.FloatMap));
		return whereUsedConfigParameters;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedConfigParameters toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedConfigParameters wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedConfigParameters whereUsedConfigParameters = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedConfigParameters();
		whereUsedConfigParameters.StringMap = toLocalWUStringMap(wire.getStringMap(), modelManager);
		whereUsedConfigParameters.DoubleMap = toLocalWUDoubleMap(wire.getDoubleMap(), modelManager);
		whereUsedConfigParameters.IntMap = toLocalWUIntMap(wire.getIntMap(), modelManager);
		whereUsedConfigParameters.BoolMap = toLocalWUBoolMap(wire.getBoolMap(), modelManager);
		whereUsedConfigParameters.DateMap = toLocalWUDateMap(wire.getDateMap(), modelManager);
		whereUsedConfigParameters.TagMap = toLocalWUTagMap(wire.getTagMap(), modelManager);
		whereUsedConfigParameters.FloatMap = toLocalWUFloatMap(wire.getFloatMap(), modelManager);
		return whereUsedConfigParameters;
	}

	public static Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedInputData toWire(Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedInputData local)
	{
		Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedInputData whereUsedInputData = new Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedInputData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		whereUsedInputData.setInputObject(modelObject);
		whereUsedInputData.setUseLocalParams(local.UseLocalParams);
		whereUsedInputData.setInputParams(toWire(local.InputParams));
		whereUsedInputData.setClientId(local.ClientId);
		return whereUsedInputData;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedInputData toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedInputData whereUsedInputData = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedInputData();
		whereUsedInputData.InputObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getInputObject());
		whereUsedInputData.UseLocalParams = wire.UseLocalParams;
		whereUsedInputData.InputParams = toLocal(wire.getInputParams(), modelManager);
		whereUsedInputData.ClientId = wire.getClientId();
		return whereUsedInputData;
	}

	public static Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedOutputData toWire(Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedOutputData local)
	{
		Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedOutputData whereUsedOutputData = new Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedOutputData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputObject.Uid);
		}
		whereUsedOutputData.setInputObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		whereUsedOutputData.setInfo(arrayList);
		whereUsedOutputData.setClientId(local.ClientId);
		return whereUsedOutputData;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedOutputData toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedOutputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedOutputData whereUsedOutputData = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedOutputData();
		whereUsedOutputData.InputObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getInputObject());
		IList info = wire.getInfo();
		whereUsedOutputData.Info = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedParentInfo[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			whereUsedOutputData.Info[i] = toLocal((Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedParentInfo)info[i], modelManager);
		}
		whereUsedOutputData.ClientId = wire.getClientId();
		return whereUsedOutputData;
	}

	public static Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedParentInfo toWire(Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedParentInfo local)
	{
		Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedParentInfo whereUsedParentInfo = new Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedParentInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ParentObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ParentObject.Uid);
		}
		whereUsedParentInfo.setParentObject(modelObject);
		whereUsedParentInfo.setLevel(local.Level);
		return whereUsedParentInfo;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedParentInfo toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedParentInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedParentInfo whereUsedParentInfo = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedParentInfo();
		whereUsedParentInfo.ParentObject = (WorkspaceObject)modelManager.LoadObjectData(wire.getParentObject());
		whereUsedParentInfo.Level = wire.getLevel();
		return whereUsedParentInfo;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedResponse toLocal(Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedResponse whereUsedResponse = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedResponse();
		whereUsedResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		whereUsedResponse.Output = new Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedOutputData[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			whereUsedResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedOutputData)output[i], modelManager);
		}
		return whereUsedResponse;
	}

	public static ArrayList toWireValidationResult(IDictionary ValidationResult)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ValidationResult)
		{
			object key = item.Key;
			object value = item.Value;
			Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResult validationResult = new Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResult();
			validationResult.setKey(Convert.ToString(key));
			validationResult.setValue(Convert.ToBoolean(value));
			arrayList.Add(validationResult);
		}
		return arrayList;
	}

	public static Hashtable toLocalValidationResult(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResult validationResult = (Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResult)wire[i];
			string key = validationResult.getKey();
			bool value = validationResult.Value;
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWUBoolMap(IDictionary WUBoolMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUBoolMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUBoolMap wUBoolMap = new WUBoolMap();
			wUBoolMap.setKey(Convert.ToString(key));
			wUBoolMap.setValue(Convert.ToBoolean(value));
			arrayList.Add(wUBoolMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUBoolMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUBoolMap wUBoolMap = (WUBoolMap)wire[i];
			string key = wUBoolMap.getKey();
			bool value = wUBoolMap.Value;
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWUDateMap(IDictionary WUDateMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUDateMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUDateMap wUDateMap = new WUDateMap();
			wUDateMap.setKey(Convert.ToString(key));
			wUDateMap.setValue(TcServerDate.ToWire((DateTime)value));
			arrayList.Add(wUDateMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUDateMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUDateMap wUDateMap = (WUDateMap)wire[i];
			string key = wUDateMap.getKey();
			DateTime dateTime = TcServerDate.ToLocal(wUDateMap.getValue());
			hashtable.Add(key, dateTime);
		}
		return hashtable;
	}

	public static ArrayList toWireWUDoubleMap(IDictionary WUDoubleMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUDoubleMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUDoubleMap wUDoubleMap = new WUDoubleMap();
			wUDoubleMap.setKey(Convert.ToString(key));
			wUDoubleMap.setValue(Convert.ToDouble(value));
			arrayList.Add(wUDoubleMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUDoubleMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUDoubleMap wUDoubleMap = (WUDoubleMap)wire[i];
			string key = wUDoubleMap.getKey();
			double value = wUDoubleMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWUFloatMap(IDictionary WUFloatMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUFloatMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUFloatMap wUFloatMap = new WUFloatMap();
			wUFloatMap.setKey(Convert.ToString(key));
			wUFloatMap.setValue(Convert.ToSingle(value));
			arrayList.Add(wUFloatMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUFloatMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUFloatMap wUFloatMap = (WUFloatMap)wire[i];
			string key = wUFloatMap.getKey();
			float value = wUFloatMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWUIntMap(IDictionary WUIntMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUIntMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUIntMap wUIntMap = new WUIntMap();
			wUIntMap.setKey(Convert.ToString(key));
			wUIntMap.setValue((int)value);
			arrayList.Add(wUIntMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUIntMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUIntMap wUIntMap = (WUIntMap)wire[i];
			string key = wUIntMap.getKey();
			int value = wUIntMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWUStringMap(IDictionary WUStringMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUStringMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUStringMap wUStringMap = new WUStringMap();
			wUStringMap.setKey(Convert.ToString(key));
			wUStringMap.setValue(Convert.ToString(value));
			arrayList.Add(wUStringMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUStringMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUStringMap wUStringMap = (WUStringMap)wire[i];
			string key = wUStringMap.getKey();
			string value = wUStringMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWUTagMap(IDictionary WUTagMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WUTagMap)
		{
			object key = item.Key;
			object value = item.Value;
			WUTagMap wUTagMap = new WUTagMap();
			wUTagMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			wUTagMap.setValue(modelObject);
			arrayList.Add(wUTagMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWUTagMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WUTagMap wUTagMap = (WUTagMap)wire[i];
			string key = wUTagMap.getKey();
			Teamcenter.Soa.Client.Model.ModelObject value = modelManager.LoadObjectData(wUTagMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2012_02.DataManagement.ValidationResponse ValidateIdValue(Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateIn[] Input)
	{
		try
		{
			restSender.PushRequestId();
			ValidateIdValueInput validateIdValueInput = new ValidateIdValueInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			validateIdValueInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201202_PORT_NAME, "ValidateIdValue", validateIdValueInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResponse wire = (Teamcenter.Schemas.Core._2012_02.Datamanagement.ValidationResponse)obj;
			Teamcenter.Services.Strong.Core._2012_02.DataManagement.ValidationResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse BulkCreateObjects(Teamcenter.Services.Strong.Core._2012_02.DataManagement.BulkCreIn[] Input)
	{
		try
		{
			restSender.PushRequestId();
			BulkCreateObjectsInput bulkCreateObjectsInput = new BulkCreateObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			bulkCreateObjectsInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201202_PORT_NAME, "BulkCreateObjects", bulkCreateObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse wire = (Teamcenter.Schemas.Core._2008_06.Datamanagement.CreateResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DataManagement.CreateResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedResponse WhereUsed(Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedInputData[] Input, Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedConfigParameters ConfigParams)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedInput whereUsedInput = new Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			whereUsedInput.setInput(arrayList);
			whereUsedInput.setConfigParams(toWire(ConfigParams));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201202_PORT_NAME, "WhereUsed", whereUsedInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedResponse wire = (Teamcenter.Schemas.Core._2012_02.Datamanagement.WhereUsedResponse)obj;
			Teamcenter.Services.Strong.Core._2012_02.DataManagement.WhereUsedResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2012_09.Datamanagement.RelateInfoIn toWire(Teamcenter.Services.Strong.Core._2012_09.DataManagement.RelateInfoIn local)
	{
		Teamcenter.Schemas.Core._2012_09.Datamanagement.RelateInfoIn relateInfoIn = new Teamcenter.Schemas.Core._2012_09.Datamanagement.RelateInfoIn();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Target == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Target.Uid);
		}
		relateInfoIn.setTarget(modelObject);
		relateInfoIn.setPropertyName(local.PropertyName);
		relateInfoIn.setRelate(local.Relate);
		return relateInfoIn;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.DataManagement.RelateInfoIn toLocal(Teamcenter.Schemas.Core._2012_09.Datamanagement.RelateInfoIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.DataManagement.RelateInfoIn relateInfoIn = new Teamcenter.Services.Strong.Core._2012_09.DataManagement.RelateInfoIn();
		relateInfoIn.Target = modelManager.LoadObjectData(wire.getTarget());
		relateInfoIn.PropertyName = wire.getPropertyName();
		relateInfoIn.Relate = wire.Relate;
		return relateInfoIn;
	}

	public override Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse SaveAsObjectAndRelate(Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsIn[] SaveAsInput, Teamcenter.Services.Strong.Core._2012_09.DataManagement.RelateInfoIn[] RelateInfo)
	{
		try
		{
			restSender.PushRequestId();
			SaveAsObjectAndRelateInput saveAsObjectAndRelateInput = new SaveAsObjectAndRelateInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < SaveAsInput.Length; i++)
			{
				arrayList.Add(toWire(SaveAsInput[i]));
			}
			saveAsObjectAndRelateInput.setSaveAsInput(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < RelateInfo.Length; i++)
			{
				arrayList2.Add(toWire(RelateInfo[i]));
			}
			saveAsObjectAndRelateInput.setRelateInfo(arrayList2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201209_PORT_NAME, "SaveAsObjectAndRelate", saveAsObjectAndRelateInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse wire = (Teamcenter.Schemas.Core._2011_06.Datamanagement.SaveAsObjectsResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.DataManagement.SaveAsObjectsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionOutput toWire(Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionOutput local)
	{
		Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionOutput getDatasetTypesWithFileExtensionOutput = new Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionOutput();
		getDatasetTypesWithFileExtensionOutput.setFileExtension(local.FileExtension);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetTypesInfo.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetTypesInfo[i]));
		}
		getDatasetTypesWithFileExtensionOutput.setDatasetTypesInfo(arrayList);
		return getDatasetTypesWithFileExtensionOutput;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionOutput toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionOutput getDatasetTypesWithFileExtensionOutput = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionOutput();
		getDatasetTypesWithFileExtensionOutput.FileExtension = wire.getFileExtension();
		IList datasetTypesInfo = wire.getDatasetTypesInfo();
		getDatasetTypesWithFileExtensionOutput.DatasetTypesInfo = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.DatasetTypeInfo[datasetTypesInfo.Count];
		for (int i = 0; i < datasetTypesInfo.Count; i++)
		{
			getDatasetTypesWithFileExtensionOutput.DatasetTypesInfo[i] = toLocal((Teamcenter.Schemas.Core._2007_06.Datamanagement.DatasetTypeInfo)datasetTypesInfo[i], modelManager);
		}
		return getDatasetTypesWithFileExtensionOutput;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionResponse toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionResponse getDatasetTypesWithFileExtensionResponse = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionResponse();
		getDatasetTypesWithFileExtensionResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getDatasetTypesWithFileExtensionResponse.Output = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getDatasetTypesWithFileExtensionResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionOutput)output[i], modelManager);
		}
		return getDatasetTypesWithFileExtensionResponse;
	}

	public static Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityFilterInput toWire(Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityFilterInput local)
	{
		Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityFilterInput traceabilityFilterInput = new Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityFilterInput();
		traceabilityFilterInput.setLogicalOperatorType(local.LogicalOperatorType);
		traceabilityFilterInput.setPropertyName(local.PropertyName);
		traceabilityFilterInput.setOperatorType(local.OperatorType);
		traceabilityFilterInput.setPropertyValue(local.PropertyValue);
		return traceabilityFilterInput;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityFilterInput toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityFilterInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityFilterInput traceabilityFilterInput = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityFilterInput();
		traceabilityFilterInput.LogicalOperatorType = wire.getLogicalOperatorType();
		traceabilityFilterInput.PropertyName = wire.getPropertyName();
		traceabilityFilterInput.OperatorType = wire.getOperatorType();
		traceabilityFilterInput.PropertyValue = wire.getPropertyValue();
		return traceabilityFilterInput;
	}

	public static Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityInfoInput1 toWire(Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityInfoInput1 local)
	{
		Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityInfoInput1 traceabilityInfoInput = new Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityInfoInput1();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.SelectedObjs.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.SelectedObjs[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.SelectedObjs[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		traceabilityInfoInput.setSelectedObjs(arrayList);
		traceabilityInfoInput.setReportType(local.ReportType);
		traceabilityInfoInput.setReportDepth(local.ReportDepth);
		traceabilityInfoInput.setIsIndirectTraceReportNeeded(local.IsIndirectTraceReportNeeded);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.FilteredTraceLinkTypes.Length; i++)
		{
			arrayList2.Add(local.FilteredTraceLinkTypes[i]);
		}
		traceabilityInfoInput.setFilteredTraceLinkTypes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.FilteredObjectTypes.Length; i++)
		{
			arrayList3.Add(local.FilteredObjectTypes[i]);
		}
		traceabilityInfoInput.setFilteredObjectTypes(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.ScopeLines.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ScopeLines[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.ScopeLines[i].Uid);
			}
			arrayList4.Add(modelObject2);
		}
		traceabilityInfoInput.setScopeLines(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.PropertyFilterInput.Length; i++)
		{
			arrayList5.Add(toWire(local.PropertyFilterInput[i]));
		}
		traceabilityInfoInput.setPropertyFilterInput(arrayList5);
		traceabilityInfoInput.setSortPropName(local.SortPropName);
		traceabilityInfoInput.setSortDirection(local.SortDirection);
		traceabilityInfoInput.setExportTo(local.ExportTo);
		traceabilityInfoInput.setExportTemplate(local.ExportTemplate);
		ArrayList arrayList6 = new ArrayList();
		for (int i = 0; i < local.ExportColumnNames.Length; i++)
		{
			arrayList6.Add(local.ExportColumnNames[i]);
		}
		traceabilityInfoInput.setExportColumnNames(arrayList6);
		return traceabilityInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityInfoInput1 toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityInfoInput1 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityInfoInput1 traceabilityInfoInput = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityInfoInput1();
		IList selectedObjs = wire.getSelectedObjs();
		traceabilityInfoInput.SelectedObjs = new Teamcenter.Soa.Client.Model.ModelObject[selectedObjs.Count];
		for (int i = 0; i < selectedObjs.Count; i++)
		{
			traceabilityInfoInput.SelectedObjs[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)selectedObjs[i]);
		}
		traceabilityInfoInput.ReportType = wire.getReportType();
		traceabilityInfoInput.ReportDepth = wire.getReportDepth();
		traceabilityInfoInput.IsIndirectTraceReportNeeded = wire.IsIndirectTraceReportNeeded;
		IList filteredTraceLinkTypes = wire.getFilteredTraceLinkTypes();
		traceabilityInfoInput.FilteredTraceLinkTypes = new string[filteredTraceLinkTypes.Count];
		for (int i = 0; i < filteredTraceLinkTypes.Count; i++)
		{
			traceabilityInfoInput.FilteredTraceLinkTypes[i] = Convert.ToString(filteredTraceLinkTypes[i]);
		}
		IList filteredObjectTypes = wire.getFilteredObjectTypes();
		traceabilityInfoInput.FilteredObjectTypes = new string[filteredObjectTypes.Count];
		for (int i = 0; i < filteredObjectTypes.Count; i++)
		{
			traceabilityInfoInput.FilteredObjectTypes[i] = Convert.ToString(filteredObjectTypes[i]);
		}
		IList scopeLines = wire.getScopeLines();
		traceabilityInfoInput.ScopeLines = new Teamcenter.Soa.Client.Model.ModelObject[scopeLines.Count];
		for (int i = 0; i < scopeLines.Count; i++)
		{
			traceabilityInfoInput.ScopeLines[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)scopeLines[i]);
		}
		IList propertyFilterInput = wire.getPropertyFilterInput();
		traceabilityInfoInput.PropertyFilterInput = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityFilterInput[propertyFilterInput.Count];
		for (int i = 0; i < propertyFilterInput.Count; i++)
		{
			traceabilityInfoInput.PropertyFilterInput[i] = toLocal((Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityFilterInput)propertyFilterInput[i], modelManager);
		}
		traceabilityInfoInput.SortPropName = wire.getSortPropName();
		traceabilityInfoInput.SortDirection = wire.getSortDirection();
		traceabilityInfoInput.ExportTo = wire.getExportTo();
		traceabilityInfoInput.ExportTemplate = wire.getExportTemplate();
		IList exportColumnNames = wire.getExportColumnNames();
		traceabilityInfoInput.ExportColumnNames = new string[exportColumnNames.Count];
		for (int i = 0; i < exportColumnNames.Count; i++)
		{
			traceabilityInfoInput.ExportColumnNames[i] = Convert.ToString(exportColumnNames[i]);
		}
		return traceabilityInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityReportOutput1 toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityReportOutput1 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityReportOutput1 traceabilityReportOutput = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityReportOutput1();
		traceabilityReportOutput.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList traceReports = wire.getTraceReports();
		traceabilityReportOutput.TraceReports = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReport1[traceReports.Count];
		for (int i = 0; i < traceReports.Count; i++)
		{
			traceabilityReportOutput.TraceReports[i] = toLocal((Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReport1)traceReports[i], modelManager);
		}
		IList transientFileReadTickets = wire.getTransientFileReadTickets();
		traceabilityReportOutput.TransientFileReadTickets = new string[transientFileReadTickets.Count];
		for (int i = 0; i < transientFileReadTickets.Count; i++)
		{
			traceabilityReportOutput.TransientFileReadTickets[i] = Convert.ToString(transientFileReadTickets[i]);
		}
		return traceabilityReportOutput;
	}

	public static Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReportTreeNode toWire(Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReportTreeNode local)
	{
		Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReportTreeNode traceReportTreeNode = new Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReportTreeNode();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		traceReportTreeNode.setObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.DisplayObj == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.DisplayObj.Uid);
		}
		traceReportTreeNode.setDisplayObj(modelObject2);
		traceReportTreeNode.setSrcContextName(local.SrcContextName);
		traceReportTreeNode.setTarContextName(local.TarContextName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomView == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.BomView.Uid);
		}
		traceReportTreeNode.setBomView(modelObject3);
		traceReportTreeNode.setIsDirectLink(local.IsDirectLink);
		traceReportTreeNode.setIsTraceLinkObj(local.IsTraceLinkObj);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildNodes.Length; i++)
		{
			arrayList.Add(toWire(local.ChildNodes[i]));
		}
		traceReportTreeNode.setChildNodes(arrayList);
		return traceReportTreeNode;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReportTreeNode toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReportTreeNode wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReportTreeNode traceReportTreeNode = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReportTreeNode();
		traceReportTreeNode.Object = modelManager.LoadObjectData(wire.getObject());
		traceReportTreeNode.DisplayObj = (WorkspaceObject)modelManager.LoadObjectData(wire.getDisplayObj());
		traceReportTreeNode.SrcContextName = wire.getSrcContextName();
		traceReportTreeNode.TarContextName = wire.getTarContextName();
		traceReportTreeNode.BomView = (PSBOMView)modelManager.LoadObjectData(wire.getBomView());
		traceReportTreeNode.IsDirectLink = wire.IsDirectLink;
		traceReportTreeNode.IsTraceLinkObj = wire.IsTraceLinkObj;
		IList childNodes = wire.getChildNodes();
		traceReportTreeNode.ChildNodes = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReportTreeNode[childNodes.Count];
		for (int i = 0; i < childNodes.Count; i++)
		{
			traceReportTreeNode.ChildNodes[i] = toLocal((Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReportTreeNode)childNodes[i], modelManager);
		}
		return traceReportTreeNode;
	}

	public static Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReport1 toWire(Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReport1 local)
	{
		Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReport1 traceReport = new Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReport1();
		traceReport.setDefRootNode(toWire(local.DefRootNode));
		traceReport.setCompRootNode(toWire(local.CompRootNode));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SelectedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.SelectedObject.Uid);
		}
		traceReport.setSelectedObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PersistentObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PersistentObjects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.PersistentObjects[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		traceReport.setPersistentObjects(arrayList);
		return traceReport;
	}

	public static Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReport1 toLocal(Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceReport1 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReport1 traceReport = new Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceReport1();
		traceReport.DefRootNode = toLocal(wire.getDefRootNode(), modelManager);
		traceReport.CompRootNode = toLocal(wire.getCompRootNode(), modelManager);
		traceReport.SelectedObject = modelManager.LoadObjectData(wire.getSelectedObject());
		IList persistentObjects = wire.getPersistentObjects();
		traceReport.PersistentObjects = new Teamcenter.Soa.Client.Model.ModelObject[persistentObjects.Count];
		for (int i = 0; i < persistentObjects.Count; i++)
		{
			traceReport.PersistentObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)persistentObjects[i]);
		}
		return traceReport;
	}

	public override Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionResponse GetDatasetTypesWithFileExtension(string[] FileExtensions)
	{
		try
		{
			restSender.PushRequestId();
			GetDatasetTypesWithFileExtensionInput getDatasetTypesWithFileExtensionInput = new GetDatasetTypesWithFileExtensionInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < FileExtensions.Length; i++)
			{
				arrayList.Add(FileExtensions[i]);
			}
			getDatasetTypesWithFileExtensionInput.setFileExtensions(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DATAMANAGEMENT_201210_PORT_NAME, "GetDatasetTypesWithFileExtension", getDatasetTypesWithFileExtensionInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionResponse wire = (Teamcenter.Schemas.Core._2012_10.Datamanagement.GetDatasetTypesWithFileExtensionResponse)obj;
			Teamcenter.Services.Strong.Core._2012_10.DataManagement.GetDatasetTypesWithFileExtensionResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Teamcenter 10.1.2, use the getTraceReport2 operation. New getTraceReport operation returns BVR specific context line information also.", false)]
	public override Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityReportOutput1 GetTraceReport(Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityInfoInput1[] Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2012_10.Datamanagement.GetTraceReportInput getTraceReportInput = new Teamcenter.Schemas.Core._2012_10.Datamanagement.GetTraceReportInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			getTraceReportInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityReportOutput1);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201210_PORT_NAME, "GetTraceReport", getTraceReportInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityReportOutput1 wire = (Teamcenter.Schemas.Core._2012_10.Datamanagement.TraceabilityReportOutput1)obj;
			Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityReportOutput1 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData RefreshObjects2(Teamcenter.Soa.Client.Model.ModelObject[] Objects, bool LockObjects)
	{
		try
		{
			restSender.PushRequestId();
			RefreshObjects2Input refreshObjects2Input = new RefreshObjects2Input();
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
			refreshObjects2Input.setObjects(arrayList);
			refreshObjects2Input.setLockObjects(LockObjects);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201210_PORT_NAME, "RefreshObjects2", refreshObjects2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.DeepCopyData toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.DeepCopyData local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.DeepCopyData deepCopyData = new Teamcenter.Schemas.Core._2013_05.Datamanagement.DeepCopyData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.AttachedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.AttachedObject.Uid);
		}
		deepCopyData.setAttachedObject(modelObject);
		deepCopyData.setPropertyName(local.PropertyName);
		deepCopyData.setPropertyType(local.PropertyType);
		deepCopyData.setCopyAction(local.CopyAction);
		deepCopyData.setIsTargetPrimary(local.IsTargetPrimary);
		deepCopyData.setIsRequired(local.IsRequired);
		deepCopyData.setCopyRelations(local.CopyRelations);
		deepCopyData.setOperationInputTypeName(local.OperationInputTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildDeepCopyData.Length; i++)
		{
			arrayList.Add(toWire(local.ChildDeepCopyData[i]));
		}
		deepCopyData.setChildDeepCopyData(arrayList);
		deepCopyData.setOperationInputs(toWirePropertyValues(local.OperationInputs));
		return deepCopyData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.DeepCopyData toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.DeepCopyData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.DeepCopyData deepCopyData = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.DeepCopyData();
		deepCopyData.AttachedObject = modelManager.LoadObjectData(wire.getAttachedObject());
		deepCopyData.PropertyName = wire.getPropertyName();
		deepCopyData.PropertyType = wire.getPropertyType();
		deepCopyData.CopyAction = wire.getCopyAction();
		deepCopyData.IsTargetPrimary = wire.IsTargetPrimary;
		deepCopyData.IsRequired = wire.IsRequired;
		deepCopyData.CopyRelations = wire.CopyRelations;
		deepCopyData.OperationInputTypeName = wire.getOperationInputTypeName();
		IList childDeepCopyData = wire.getChildDeepCopyData();
		deepCopyData.ChildDeepCopyData = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.DeepCopyData[childDeepCopyData.Count];
		for (int i = 0; i < childDeepCopyData.Count; i++)
		{
			deepCopyData.ChildDeepCopyData[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.DeepCopyData)childDeepCopyData[i], modelManager);
		}
		deepCopyData.OperationInputs = toLocalPropertyValues(wire.getOperationInputs(), modelManager);
		return deepCopyData;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValue toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValue local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValue generatedValue = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValue();
		generatedValue.setErrorCode(local.ErrorCode);
		generatedValue.setNextValue(local.NextValue);
		generatedValue.setIsModifiable(local.IsModifiable);
		return generatedValue;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValue toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValue wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValue generatedValue = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValue();
		generatedValue.ErrorCode = wire.getErrorCode();
		generatedValue.NextValue = wire.getNextValue();
		generatedValue.IsModifiable = wire.IsModifiable;
		return generatedValue;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValuesOutput toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValuesOutput generatedValuesOutput = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValuesOutput();
		generatedValuesOutput.setClientId(local.ClientId);
		generatedValuesOutput.setGeneratedValues(toWireGeneratedValuesMap(local.GeneratedValues));
		generatedValuesOutput.setGeneratedValuesOfSecondaryObjects(toWireGeneratedValuesOfSecondaryObjectsMap(local.GeneratedValuesOfSecondaryObjects));
		return generatedValuesOutput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValuesOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput generatedValuesOutput = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput();
		generatedValuesOutput.ClientId = wire.getClientId();
		generatedValuesOutput.GeneratedValues = toLocalGeneratedValuesMap(wire.getGeneratedValues(), modelManager);
		generatedValuesOutput.GeneratedValuesOfSecondaryObjects = toLocalGeneratedValuesOfSecondaryObjectsMap(wire.getGeneratedValuesOfSecondaryObjects(), modelManager);
		return generatedValuesOutput;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesIn toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesIn generateNextValuesIn = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesIn();
		generateNextValuesIn.setClientId(local.ClientId);
		generateNextValuesIn.setOperationType(local.OperationType);
		generateNextValuesIn.setBusinessObjectName(local.BusinessObjectName);
		generateNextValuesIn.setPropertyNameWithSelectedPattern(toWirePropertyNameWithSelectedPatternMap(local.PropertyNameWithSelectedPattern));
		generateNextValuesIn.setPropValues(toWirePropValuesMap(local.PropValues));
		generateNextValuesIn.setAdditionalInputParams(toWireAdditionalInputParamsMap(local.AdditionalInputParams));
		generateNextValuesIn.setCompoundObjectInput(toWireCompoundObjectInputMap(local.CompoundObjectInput));
		return generateNextValuesIn;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn generateNextValuesIn = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn();
		generateNextValuesIn.ClientId = wire.getClientId();
		generateNextValuesIn.OperationType = wire.getOperationType();
		generateNextValuesIn.BusinessObjectName = wire.getBusinessObjectName();
		generateNextValuesIn.PropertyNameWithSelectedPattern = toLocalPropertyNameWithSelectedPatternMap(wire.getPropertyNameWithSelectedPattern(), modelManager);
		generateNextValuesIn.PropValues = toLocalPropValuesMap(wire.getPropValues(), modelManager);
		generateNextValuesIn.AdditionalInputParams = toLocalAdditionalInputParamsMap(wire.getAdditionalInputParams(), modelManager);
		generateNextValuesIn.CompoundObjectInput = toLocalCompoundObjectInputMap(wire.getCompoundObjectInput(), modelManager);
		return generateNextValuesIn;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesResponse toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesResponse generateNextValuesResponse = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesResponse();
		generateNextValuesResponse.Data = modelManager.LoadServiceData(wire.getServiceData());
		IList generatedValues = wire.getGeneratedValues();
		generateNextValuesResponse.GeneratedValues = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput[generatedValues.Count];
		for (int i = 0; i < generatedValues.Count; i++)
		{
			generateNextValuesResponse.GeneratedValues[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValuesOutput)generatedValues[i], modelManager);
		}
		return generateNextValuesResponse;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenInputData toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenInputData local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenInputData getChildrenInputData = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenInputData();
		getChildrenInputData.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Obj == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Obj.Uid);
		}
		getChildrenInputData.setObj(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropertyNames.Length; i++)
		{
			arrayList.Add(local.PropertyNames[i]);
		}
		getChildrenInputData.setPropertyNames(arrayList);
		return getChildrenInputData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenInputData toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenInputData getChildrenInputData = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenInputData();
		getChildrenInputData.ClientId = wire.getClientId();
		getChildrenInputData.Obj = modelManager.LoadObjectData(wire.getObj());
		IList propertyNames = wire.getPropertyNames();
		getChildrenInputData.PropertyNames = new string[propertyNames.Count];
		for (int i = 0; i < propertyNames.Count; i++)
		{
			getChildrenInputData.PropertyNames[i] = Convert.ToString(propertyNames[i]);
		}
		return getChildrenInputData;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenOutput toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenOutput getChildrenOutput = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenOutput();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Children[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.Children[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		getChildrenOutput.setChildren(arrayList);
		getChildrenOutput.setPropertyName(local.PropertyName);
		return getChildrenOutput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput getChildrenOutput = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput();
		IList children = wire.getChildren();
		getChildrenOutput.Children = new Teamcenter.Soa.Client.Model.ModelObject[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			getChildrenOutput.Children[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)children[i]);
		}
		getChildrenOutput.PropertyName = wire.getPropertyName();
		return getChildrenOutput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenResponse toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenResponse getChildrenResponse = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenResponse();
		getChildrenResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getChildrenResponse.ObjectWithChildren = toLocalGetChildrenOutputMap(wire.getObjectWithChildren(), modelManager);
		return getChildrenResponse;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsInputData toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsInputData local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsInputData getPasteRelationsInputData = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsInputData();
		getPasteRelationsInputData.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Obj == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Obj.Uid);
		}
		getPasteRelationsInputData.setObj(modelObject);
		getPasteRelationsInputData.setChildTypeName(local.ChildTypeName);
		return getPasteRelationsInputData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsInputData toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsInputData getPasteRelationsInputData = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsInputData();
		getPasteRelationsInputData.ClientId = wire.getClientId();
		getPasteRelationsInputData.Obj = modelManager.LoadObjectData(wire.getObj());
		getPasteRelationsInputData.ChildTypeName = wire.getChildTypeName();
		return getPasteRelationsInputData;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsOutput toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsOutput local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsOutput getPasteRelationsOutput = new Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsOutput();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PasteRelationsInfo.Length; i++)
		{
			arrayList.Add(toWire(local.PasteRelationsInfo[i]));
		}
		getPasteRelationsOutput.setPasteRelationsInfo(arrayList);
		getPasteRelationsOutput.setIndexOfPreferred(local.IndexOfPreferred);
		return getPasteRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsOutput toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsOutput getPasteRelationsOutput = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsOutput();
		IList pasteRelationsInfo = wire.getPasteRelationsInfo();
		getPasteRelationsOutput.PasteRelationsInfo = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.PasteRelationsInfo[pasteRelationsInfo.Count];
		for (int i = 0; i < pasteRelationsInfo.Count; i++)
		{
			getPasteRelationsOutput.PasteRelationsInfo[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.PasteRelationsInfo)pasteRelationsInfo[i], modelManager);
		}
		getPasteRelationsOutput.IndexOfPreferred = wire.getIndexOfPreferred();
		return getPasteRelationsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsResponse toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsResponse getPasteRelationsResponse = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsResponse();
		getPasteRelationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getPasteRelationsResponse.OutputMap = toLocalGetPasteRelationsOutputMap(wire.getOutputMap(), modelManager);
		return getPasteRelationsResponse;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.PasteRelationsInfo toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.PasteRelationsInfo local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.PasteRelationsInfo pasteRelationsInfo = new Teamcenter.Schemas.Core._2013_05.Datamanagement.PasteRelationsInfo();
		pasteRelationsInfo.setPasteRelationName(local.PasteRelationName);
		pasteRelationsInfo.setIsExpandable(local.IsExpandable);
		return pasteRelationsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.PasteRelationsInfo toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.PasteRelationsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.PasteRelationsInfo pasteRelationsInfo = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.PasteRelationsInfo();
		pasteRelationsInfo.PasteRelationName = wire.getPasteRelationName();
		pasteRelationsInfo.IsExpandable = wire.IsExpandable;
		return pasteRelationsInfo;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseIn toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseIn local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseIn reviseIn = new Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseIn();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		reviseIn.setTargetObject(modelObject);
		reviseIn.setReviseInputs(toWirePropertyValues(local.ReviseInputs));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DeepCopyDatas.Length; i++)
		{
			arrayList.Add(toWire(local.DeepCopyDatas[i]));
		}
		reviseIn.setDeepCopyDatas(arrayList);
		return reviseIn;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseIn toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseIn wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseIn reviseIn = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseIn();
		reviseIn.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		reviseIn.ReviseInputs = toLocalPropertyValues(wire.getReviseInputs(), modelManager);
		IList deepCopyDatas = wire.getDeepCopyDatas();
		reviseIn.DeepCopyDatas = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.DeepCopyData[deepCopyDatas.Count];
		for (int i = 0; i < deepCopyDatas.Count; i++)
		{
			reviseIn.DeepCopyDatas[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.DeepCopyData)deepCopyDatas[i], modelManager);
		}
		return reviseIn;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseObjectsResponse toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseObjectsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseObjectsResponse reviseObjectsResponse = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseObjectsResponse();
		reviseObjectsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		reviseObjectsResponse.Output = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseOut[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			reviseObjectsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseOut)output[i], modelManager);
		}
		IList reviseTrees = wire.getReviseTrees();
		reviseObjectsResponse.ReviseTrees = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseTree[reviseTrees.Count];
		for (int i = 0; i < reviseTrees.Count; i++)
		{
			reviseObjectsResponse.ReviseTrees[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseTree)reviseTrees[i], modelManager);
		}
		return reviseObjectsResponse;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseOut toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseOut local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseOut reviseOut = new Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseOut();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		reviseOut.setTargetObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Objects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Objects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Objects[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		reviseOut.setObjects(arrayList);
		return reviseOut;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseOut toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseOut wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseOut reviseOut = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseOut();
		reviseOut.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		IList objects = wire.getObjects();
		reviseOut.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			reviseOut.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		return reviseOut;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseTree toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseTree local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseTree reviseTree = new Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseTree();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OriginalObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OriginalObject.Uid);
		}
		reviseTree.setOriginalObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectCopy == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ObjectCopy.Uid);
		}
		reviseTree.setObjectCopy(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildReviseNodes.Length; i++)
		{
			arrayList.Add(toWire(local.ChildReviseNodes[i]));
		}
		reviseTree.setChildReviseNodes(arrayList);
		return reviseTree;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseTree toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseTree wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseTree reviseTree = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseTree();
		reviseTree.OriginalObject = modelManager.LoadObjectData(wire.getOriginalObject());
		reviseTree.ObjectCopy = modelManager.LoadObjectData(wire.getObjectCopy());
		IList childReviseNodes = wire.getChildReviseNodes();
		reviseTree.ChildReviseNodes = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseTree[childReviseNodes.Count];
		for (int i = 0; i < childReviseNodes.Count; i++)
		{
			reviseTree.ChildReviseNodes[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseTree)childReviseNodes[i], modelManager);
		}
		return reviseTree;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesInput toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesInput local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesInput subTypeNamesInput = new Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesInput();
		subTypeNamesInput.setTypeName(local.TypeName);
		subTypeNamesInput.setContextName(local.ContextName);
		subTypeNamesInput.setExclusionPreference(local.ExclusionPreference);
		return subTypeNamesInput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesInput toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesInput subTypeNamesInput = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesInput();
		subTypeNamesInput.TypeName = wire.getTypeName();
		subTypeNamesInput.ContextName = wire.getContextName();
		subTypeNamesInput.ExclusionPreference = wire.getExclusionPreference();
		return subTypeNamesInput;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesOut toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesOut local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesOut subTypeNamesOut = new Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesOut();
		subTypeNamesOut.setTypeName(local.TypeName);
		subTypeNamesOut.setContextName(local.ContextName);
		subTypeNamesOut.setExclusionPreference(local.ExclusionPreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.SubTypeNames.Length; i++)
		{
			arrayList.Add(local.SubTypeNames[i]);
		}
		subTypeNamesOut.setSubTypeNames(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.DisplayableSubTypeNames.Length; i++)
		{
			arrayList2.Add(local.DisplayableSubTypeNames[i]);
		}
		subTypeNamesOut.setDisplayableSubTypeNames(arrayList2);
		return subTypeNamesOut;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesOut toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesOut wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesOut subTypeNamesOut = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesOut();
		subTypeNamesOut.TypeName = wire.getTypeName();
		subTypeNamesOut.ContextName = wire.getContextName();
		subTypeNamesOut.ExclusionPreference = wire.getExclusionPreference();
		IList subTypeNames = wire.getSubTypeNames();
		subTypeNamesOut.SubTypeNames = new string[subTypeNames.Count];
		for (int i = 0; i < subTypeNames.Count; i++)
		{
			subTypeNamesOut.SubTypeNames[i] = Convert.ToString(subTypeNames[i]);
		}
		IList displayableSubTypeNames = wire.getDisplayableSubTypeNames();
		subTypeNamesOut.DisplayableSubTypeNames = new string[displayableSubTypeNames.Count];
		for (int i = 0; i < displayableSubTypeNames.Count; i++)
		{
			subTypeNamesOut.DisplayableSubTypeNames[i] = Convert.ToString(displayableSubTypeNames[i]);
		}
		return subTypeNamesOut;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesResponse toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesResponse subTypeNamesResponse = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesResponse();
		subTypeNamesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		subTypeNamesResponse.Output = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesOut[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			subTypeNamesResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesOut)output[i], modelManager);
		}
		return subTypeNamesResponse;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateInput toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateInput validateInput = new Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateInput();
		validateInput.setClientId(local.ClientId);
		validateInput.setOperationType(local.OperationType);
		validateInput.setBusinessObjectName(local.BusinessObjectName);
		validateInput.setPropValuesMap(toWirePropertyValues(local.PropValuesMap));
		validateInput.setCompoundObjectInput(toWireCompoundValidateInputMap(local.CompoundObjectInput));
		return validateInput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput validateInput = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput();
		validateInput.ClientId = wire.getClientId();
		validateInput.OperationType = wire.getOperationType();
		validateInput.BusinessObjectName = wire.getBusinessObjectName();
		validateInput.PropValuesMap = toLocalPropertyValues(wire.getPropValuesMap(), modelManager);
		validateInput.CompoundObjectInput = toLocalCompoundValidateInputMap(wire.getCompoundObjectInput(), modelManager);
		return validateInput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateValuesResponse toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateValuesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateValuesResponse validateValuesResponse = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateValuesResponse();
		validateValuesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		validateValuesResponse.ValidationResults = toLocalValidationResultsMap(wire.getValidationResults(), modelManager);
		return validateValuesResponse;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationResults toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationResults local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationResults validationResults = new Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationResults();
		validationResults.setUniqueID(local.UniqueID);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ValidationStatus.Length; i++)
		{
			arrayList.Add(toWire(local.ValidationStatus[i]));
		}
		validationResults.setValidationStatus(arrayList);
		return validationResults;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationResults toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationResults wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationResults validationResults = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationResults();
		validationResults.UniqueID = wire.UniqueID;
		IList validationStatus = wire.getValidationStatus();
		validationResults.ValidationStatus = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationStatus[validationStatus.Count];
		for (int i = 0; i < validationStatus.Count; i++)
		{
			validationResults.ValidationStatus[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationStatus)validationStatus[i], modelManager);
		}
		return validationResults;
	}

	public static Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationStatus toWire(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationStatus local)
	{
		Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationStatus validationStatus = new Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationStatus();
		validationStatus.setPropName(local.PropName);
		validationStatus.setValueStatus(local.ValueStatus);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ModifiedValue.Length; i++)
		{
			arrayList.Add(local.ModifiedValue[i]);
		}
		validationStatus.setModifiedValue(arrayList);
		return validationStatus;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationStatus toLocal(Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidationStatus wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationStatus validationStatus = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationStatus();
		validationStatus.PropName = wire.getPropName();
		validationStatus.ValueStatus = wire.getValueStatus();
		IList modifiedValue = wire.getModifiedValue();
		validationStatus.ModifiedValue = new string[modifiedValue.Count];
		for (int i = 0; i < modifiedValue.Count; i++)
		{
			validationStatus.ModifiedValue[i] = Convert.ToString(modifiedValue[i]);
		}
		return validationStatus;
	}

	public static ArrayList toWireAdditionalInputParamsMap(IDictionary AdditionalInputParamsMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in AdditionalInputParamsMap)
		{
			object key = item.Key;
			object value = item.Value;
			AdditionalInputParamsMap additionalInputParamsMap = new AdditionalInputParamsMap();
			additionalInputParamsMap.setKey(Convert.ToString(key));
			additionalInputParamsMap.setValue(Convert.ToString(value));
			arrayList.Add(additionalInputParamsMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalAdditionalInputParamsMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			AdditionalInputParamsMap additionalInputParamsMap = (AdditionalInputParamsMap)wire[i];
			string key = additionalInputParamsMap.getKey();
			string value = additionalInputParamsMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireCompoundObjectInputMap(IDictionary CompoundObjectInputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in CompoundObjectInputMap)
		{
			object key = item.Key;
			object value = item.Value;
			CompoundObjectInputMap compoundObjectInputMap = new CompoundObjectInputMap();
			compoundObjectInputMap.setKey(Convert.ToString(key));
			IList value2 = compoundObjectInputMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn[] array = (Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			compoundObjectInputMap.setValue((ArrayList)value2);
			arrayList.Add(compoundObjectInputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalCompoundObjectInputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			CompoundObjectInputMap compoundObjectInputMap = (CompoundObjectInputMap)wire[i];
			string key = compoundObjectInputMap.getKey();
			IList value = compoundObjectInputMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn[] array = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesIn)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireCompoundValidateInputMap(IDictionary CompoundValidateInputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in CompoundValidateInputMap)
		{
			object key = item.Key;
			object value = item.Value;
			CompoundValidateInputMap compoundValidateInputMap = new CompoundValidateInputMap();
			compoundValidateInputMap.setKey(Convert.ToString(key));
			IList value2 = compoundValidateInputMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput[] array = (Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			compoundValidateInputMap.setValue((ArrayList)value2);
			arrayList.Add(compoundValidateInputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalCompoundValidateInputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			CompoundValidateInputMap compoundValidateInputMap = (CompoundValidateInputMap)wire[i];
			string key = compoundValidateInputMap.getKey();
			IList value = compoundValidateInputMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput[] array = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateInput)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireGeneratedValuesMap(IDictionary GeneratedValuesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in GeneratedValuesMap)
		{
			object key = item.Key;
			object value = item.Value;
			GeneratedValuesMap generatedValuesMap = new GeneratedValuesMap();
			generatedValuesMap.setKey(Convert.ToString(key));
			generatedValuesMap.setValue(toWire((Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValue)value));
			arrayList.Add(generatedValuesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalGeneratedValuesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			GeneratedValuesMap generatedValuesMap = (GeneratedValuesMap)wire[i];
			string key = generatedValuesMap.getKey();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValue value = toLocal(generatedValuesMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireGeneratedValuesOfSecondaryObjectsMap(IDictionary GeneratedValuesOfSecondaryObjectsMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in GeneratedValuesOfSecondaryObjectsMap)
		{
			object key = item.Key;
			object value = item.Value;
			GeneratedValuesOfSecondaryObjectsMap generatedValuesOfSecondaryObjectsMap = new GeneratedValuesOfSecondaryObjectsMap();
			generatedValuesOfSecondaryObjectsMap.setKey(Convert.ToString(key));
			IList value2 = generatedValuesOfSecondaryObjectsMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput[] array = (Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			generatedValuesOfSecondaryObjectsMap.setValue((ArrayList)value2);
			arrayList.Add(generatedValuesOfSecondaryObjectsMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalGeneratedValuesOfSecondaryObjectsMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			GeneratedValuesOfSecondaryObjectsMap generatedValuesOfSecondaryObjectsMap = (GeneratedValuesOfSecondaryObjectsMap)wire[i];
			string key = generatedValuesOfSecondaryObjectsMap.getKey();
			IList value = generatedValuesOfSecondaryObjectsMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput[] array = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GeneratedValuesOutput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.GeneratedValuesOutput)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireGetChildrenOutputMap(IDictionary GetChildrenOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in GetChildrenOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			GetChildrenOutputMap getChildrenOutputMap = new GetChildrenOutputMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			getChildrenOutputMap.setKey(modelObject);
			IList value2 = getChildrenOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput[] array = (Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			getChildrenOutputMap.setValue((ArrayList)value2);
			arrayList.Add(getChildrenOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalGetChildrenOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			GetChildrenOutputMap getChildrenOutputMap = (GetChildrenOutputMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(getChildrenOutputMap.getKey());
			IList value = getChildrenOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput[] array = new Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenOutput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenOutput)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireGetPasteRelationsOutputMap(IDictionary GetPasteRelationsOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in GetPasteRelationsOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			GetPasteRelationsOutputMap getPasteRelationsOutputMap = new GetPasteRelationsOutputMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			getPasteRelationsOutputMap.setKey(modelObject);
			getPasteRelationsOutputMap.setValue(toWire((Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsOutput)value));
			arrayList.Add(getPasteRelationsOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalGetPasteRelationsOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			GetPasteRelationsOutputMap getPasteRelationsOutputMap = (GetPasteRelationsOutputMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(getPasteRelationsOutputMap.getKey());
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsOutput value = toLocal(getPasteRelationsOutputMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWirePropertyNameWithSelectedPatternMap(IDictionary PropertyNameWithSelectedPatternMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in PropertyNameWithSelectedPatternMap)
		{
			object key = item.Key;
			object value = item.Value;
			PropertyNameWithSelectedPatternMap propertyNameWithSelectedPatternMap = new PropertyNameWithSelectedPatternMap();
			propertyNameWithSelectedPatternMap.setKey(Convert.ToString(key));
			propertyNameWithSelectedPatternMap.setValue(Convert.ToString(value));
			arrayList.Add(propertyNameWithSelectedPatternMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalPropertyNameWithSelectedPatternMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			PropertyNameWithSelectedPatternMap propertyNameWithSelectedPatternMap = (PropertyNameWithSelectedPatternMap)wire[i];
			string key = propertyNameWithSelectedPatternMap.getKey();
			string value = propertyNameWithSelectedPatternMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWirePropertyValues(IDictionary PropertyValues)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry PropertyValue in PropertyValues)
		{
			object key = PropertyValue.Key;
			object value = PropertyValue.Value;
			PropertyValues propertyValues = new PropertyValues();
			propertyValues.setKey(Convert.ToString(key));
			IList value2 = propertyValues.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			propertyValues.setValue((ArrayList)value2);
			arrayList.Add(propertyValues);
		}
		return arrayList;
	}

	public static Hashtable toLocalPropertyValues(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			PropertyValues propertyValues = (PropertyValues)wire[i];
			string key = propertyValues.getKey();
			IList value = propertyValues.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWirePropValuesMap(IDictionary PropValuesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in PropValuesMap)
		{
			object key = item.Key;
			object value = item.Value;
			PropValuesMap propValuesMap = new PropValuesMap();
			propValuesMap.setKey(Convert.ToString(key));
			IList value2 = propValuesMap.getValue();
			string[] array = (string[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(array[i]);
			}
			propValuesMap.setValue((ArrayList)value2);
			arrayList.Add(propValuesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalPropValuesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			PropValuesMap propValuesMap = (PropValuesMap)wire[i];
			string key = propValuesMap.getKey();
			IList value = propValuesMap.getValue();
			string[] array = new string[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (string)value[j];
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireValidationResultsMap(IDictionary ValidationResultsMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ValidationResultsMap)
		{
			object key = item.Key;
			object value = item.Value;
			ValidationResultsMap validationResultsMap = new ValidationResultsMap();
			validationResultsMap.setKey(Convert.ToString(key));
			validationResultsMap.setValue(toWire((Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationResults)value));
			arrayList.Add(validationResultsMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalValidationResultsMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ValidationResultsMap validationResultsMap = (ValidationResultsMap)wire[i];
			string key = validationResultsMap.getKey();
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidationResults value = toLocal(validationResultsMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsResponse GetPasteRelations(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsInputData[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetPasteRelationsInput getPasteRelationsInput = new GetPasteRelationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getPasteRelationsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201305_PORT_NAME, "GetPasteRelations", getPasteRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsResponse wire = (Teamcenter.Schemas.Core._2013_05.Datamanagement.GetPasteRelationsResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetPasteRelationsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseObjectsResponse ReviseObjects(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseIn[] ReviseIn)
	{
		try
		{
			restSender.PushRequestId();
			ReviseObjectsInput reviseObjectsInput = new ReviseObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ReviseIn.Length; i++)
			{
				arrayList.Add(toWire(ReviseIn[i]));
			}
			reviseObjectsInput.setReviseIn(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseObjectsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201305_PORT_NAME, "ReviseObjects", reviseObjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseObjectsResponse wire = (Teamcenter.Schemas.Core._2013_05.Datamanagement.ReviseObjectsResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.ReviseObjectsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateValuesResponse ValidateValues(Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateInput[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			ValidateValuesInput validateValuesInput = new ValidateValuesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			validateValuesInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateValuesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201305_PORT_NAME, "ValidateValues", validateValuesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateValuesResponse wire = (Teamcenter.Schemas.Core._2013_05.Datamanagement.ValidateValuesResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.ValidateValuesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenResponse GetChildren(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenInputData[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetChildrenInput getChildrenInput = new GetChildrenInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getChildrenInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201305_PORT_NAME, "GetChildren", getChildrenInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenResponse wire = (Teamcenter.Schemas.Core._2013_05.Datamanagement.GetChildrenResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GetChildrenResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesResponse GetSubTypeNames(Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesInput[] InBOTypeNames)
	{
		try
		{
			restSender.PushRequestId();
			GetSubTypeNamesInput getSubTypeNamesInput = new GetSubTypeNamesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InBOTypeNames.Length; i++)
			{
				arrayList.Add(toWire(InBOTypeNames[i]));
			}
			getSubTypeNamesInput.setInBOTypeNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201305_PORT_NAME, "GetSubTypeNames", getSubTypeNamesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesResponse wire = (Teamcenter.Schemas.Core._2013_05.Datamanagement.SubTypeNamesResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.SubTypeNamesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesResponse GenerateNextValues(Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesIn[] GenerateNextValuesIn)
	{
		try
		{
			restSender.PushRequestId();
			GenerateNextValuesInput generateNextValuesInput = new GenerateNextValuesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < GenerateNextValuesIn.Length; i++)
			{
				arrayList.Add(toWire(GenerateNextValuesIn[i]));
			}
			generateNextValuesInput.setGenerateNextValuesIn(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201305_PORT_NAME, "GenerateNextValues", generateNextValuesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesResponse wire = (Teamcenter.Schemas.Core._2013_05.Datamanagement.GenerateNextValuesResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.DataManagement.GenerateNextValuesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2014_06.Datamanagement.ObjectInfoLegacy toWire(Teamcenter.Services.Strong.Core._2014_06.DataManagement.ObjectInfoLegacy local)
	{
		Teamcenter.Schemas.Core._2014_06.Datamanagement.ObjectInfoLegacy objectInfoLegacy = new Teamcenter.Schemas.Core._2014_06.Datamanagement.ObjectInfoLegacy();
		objectInfoLegacy.setContextName(local.ContextName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.DisplayObj == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.DisplayObj.Uid);
		}
		objectInfoLegacy.setDisplayObj(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Object.Uid);
		}
		objectInfoLegacy.setObject(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomView == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.BomView.Uid);
		}
		objectInfoLegacy.setBomView(modelObject3);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject4 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextLineObj == null)
		{
			modelObject4.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject4.setUid(local.ContextLineObj.Uid);
		}
		objectInfoLegacy.setContextLineObj(modelObject4);
		return objectInfoLegacy;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.ObjectInfoLegacy toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.ObjectInfoLegacy wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.ObjectInfoLegacy objectInfoLegacy = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ObjectInfoLegacy();
		objectInfoLegacy.ContextName = wire.getContextName();
		objectInfoLegacy.DisplayObj = (WorkspaceObject)modelManager.LoadObjectData(wire.getDisplayObj());
		objectInfoLegacy.Object = modelManager.LoadObjectData(wire.getObject());
		objectInfoLegacy.BomView = modelManager.LoadObjectData(wire.getBomView());
		objectInfoLegacy.ContextLineObj = modelManager.LoadObjectData(wire.getContextLineObj());
		return objectInfoLegacy;
	}

	public static Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy toWire(Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy local)
	{
		Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy reportLegacy = new Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy();
		reportLegacy.setParent(toWire(local.Parent));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			arrayList.Add(toWire(local.Children[i]));
		}
		reportLegacy.setChildren(arrayList);
		return reportLegacy;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy reportLegacy = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy();
		reportLegacy.Parent = toLocal(wire.getParent(), modelManager);
		IList children = wire.getChildren();
		reportLegacy.Children = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ObjectInfoLegacy[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			reportLegacy.Children[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.ObjectInfoLegacy)children[i], modelManager);
		}
		return reportLegacy;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutput2 toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutput2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutput2 traceabilityReportOutput = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutput2();
		traceabilityReportOutput.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList traceReports = wire.getTraceReports();
		traceabilityReportOutput.TraceReports = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReport2[traceReports.Count];
		for (int i = 0; i < traceReports.Count; i++)
		{
			traceabilityReportOutput.TraceReports[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReport2)traceReports[i], modelManager);
		}
		IList transientFileReadTickets = wire.getTransientFileReadTickets();
		traceabilityReportOutput.TransientFileReadTickets = new string[transientFileReadTickets.Count];
		for (int i = 0; i < transientFileReadTickets.Count; i++)
		{
			traceabilityReportOutput.TransientFileReadTickets[i] = Convert.ToString(transientFileReadTickets[i]);
		}
		return traceabilityReportOutput;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutputLegacy toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutputLegacy wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutputLegacy traceabilityReportOutputLegacy = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutputLegacy();
		traceabilityReportOutputLegacy.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList traceReports = wire.getTraceReports();
		traceabilityReportOutputLegacy.TraceReports = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportLegacy[traceReports.Count];
		for (int i = 0; i < traceReports.Count; i++)
		{
			traceabilityReportOutputLegacy.TraceReports[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportLegacy)traceReports[i], modelManager);
		}
		return traceabilityReportOutputLegacy;
	}

	public static Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportTreeNode2 toWire(Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportTreeNode2 local)
	{
		Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportTreeNode2 traceReportTreeNode = new Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportTreeNode2();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		traceReportTreeNode.setObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.DisplayObj == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.DisplayObj.Uid);
		}
		traceReportTreeNode.setDisplayObj(modelObject2);
		traceReportTreeNode.setSrcContextName(local.SrcContextName);
		traceReportTreeNode.setTarContextName(local.TarContextName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomView == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.BomView.Uid);
		}
		traceReportTreeNode.setBomView(modelObject3);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject4 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextLineObj == null)
		{
			modelObject4.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject4.setUid(local.ContextLineObj.Uid);
		}
		traceReportTreeNode.setContextLineObj(modelObject4);
		traceReportTreeNode.setIsDirectLink(local.IsDirectLink);
		traceReportTreeNode.setIsTraceLinkObj(local.IsTraceLinkObj);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildNodes.Length; i++)
		{
			arrayList.Add(toWire(local.ChildNodes[i]));
		}
		traceReportTreeNode.setChildNodes(arrayList);
		return traceReportTreeNode;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportTreeNode2 toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportTreeNode2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportTreeNode2 traceReportTreeNode = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportTreeNode2();
		traceReportTreeNode.Object = modelManager.LoadObjectData(wire.getObject());
		traceReportTreeNode.DisplayObj = (WorkspaceObject)modelManager.LoadObjectData(wire.getDisplayObj());
		traceReportTreeNode.SrcContextName = wire.getSrcContextName();
		traceReportTreeNode.TarContextName = wire.getTarContextName();
		traceReportTreeNode.BomView = modelManager.LoadObjectData(wire.getBomView());
		traceReportTreeNode.ContextLineObj = modelManager.LoadObjectData(wire.getContextLineObj());
		traceReportTreeNode.IsDirectLink = wire.IsDirectLink;
		traceReportTreeNode.IsTraceLinkObj = wire.IsTraceLinkObj;
		IList childNodes = wire.getChildNodes();
		traceReportTreeNode.ChildNodes = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportTreeNode2[childNodes.Count];
		for (int i = 0; i < childNodes.Count; i++)
		{
			traceReportTreeNode.ChildNodes[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportTreeNode2)childNodes[i], modelManager);
		}
		return traceReportTreeNode;
	}

	public static Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReport2 toWire(Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReport2 local)
	{
		Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReport2 traceReport = new Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReport2();
		traceReport.setDefRootNode(toWire(local.DefRootNode));
		traceReport.setCompRootNode(toWire(local.CompRootNode));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SelectedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.SelectedObject.Uid);
		}
		traceReport.setSelectedObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PersistentObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PersistentObjects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.PersistentObjects[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		traceReport.setPersistentObjects(arrayList);
		return traceReport;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReport2 toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReport2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReport2 traceReport = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReport2();
		traceReport.DefRootNode = toLocal(wire.getDefRootNode(), modelManager);
		traceReport.CompRootNode = toLocal(wire.getCompRootNode(), modelManager);
		traceReport.SelectedObject = modelManager.LoadObjectData(wire.getSelectedObject());
		IList persistentObjects = wire.getPersistentObjects();
		traceReport.PersistentObjects = new Teamcenter.Soa.Client.Model.ModelObject[persistentObjects.Count];
		for (int i = 0; i < persistentObjects.Count; i++)
		{
			traceReport.PersistentObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)persistentObjects[i]);
		}
		return traceReport;
	}

	public static Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportLegacy toWire(Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportLegacy local)
	{
		Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportLegacy traceReportLegacy = new Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportLegacy();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DefiningTree.Length; i++)
		{
			arrayList.Add(toWire(local.DefiningTree[i]));
		}
		traceReportLegacy.setDefiningTree(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.IndirectDefiningTree.Length; i++)
		{
			arrayList2.Add(toWire(local.IndirectDefiningTree[i]));
		}
		traceReportLegacy.setIndirectDefiningTree(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ComplyingTree.Length; i++)
		{
			arrayList3.Add(toWire(local.ComplyingTree[i]));
		}
		traceReportLegacy.setComplyingTree(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.IndirectComplyingTree.Length; i++)
		{
			arrayList4.Add(toWire(local.IndirectComplyingTree[i]));
		}
		traceReportLegacy.setIndirectComplyingTree(arrayList4);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SelectedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.SelectedObject.Uid);
		}
		traceReportLegacy.setSelectedObject(modelObject);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.PersistentObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PersistentObjects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.PersistentObjects[i].Uid);
			}
			arrayList5.Add(modelObject2);
		}
		traceReportLegacy.setPersistentObjects(arrayList5);
		return traceReportLegacy;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportLegacy toLocal(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceReportLegacy wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportLegacy traceReportLegacy = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceReportLegacy();
		IList definingTree = wire.getDefiningTree();
		traceReportLegacy.DefiningTree = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy[definingTree.Count];
		for (int i = 0; i < definingTree.Count; i++)
		{
			traceReportLegacy.DefiningTree[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy)definingTree[i], modelManager);
		}
		IList indirectDefiningTree = wire.getIndirectDefiningTree();
		traceReportLegacy.IndirectDefiningTree = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy[indirectDefiningTree.Count];
		for (int i = 0; i < indirectDefiningTree.Count; i++)
		{
			traceReportLegacy.IndirectDefiningTree[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy)indirectDefiningTree[i], modelManager);
		}
		IList complyingTree = wire.getComplyingTree();
		traceReportLegacy.ComplyingTree = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy[complyingTree.Count];
		for (int i = 0; i < complyingTree.Count; i++)
		{
			traceReportLegacy.ComplyingTree[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy)complyingTree[i], modelManager);
		}
		IList indirectComplyingTree = wire.getIndirectComplyingTree();
		traceReportLegacy.IndirectComplyingTree = new Teamcenter.Services.Strong.Core._2014_06.DataManagement.ReportLegacy[indirectComplyingTree.Count];
		for (int i = 0; i < indirectComplyingTree.Count; i++)
		{
			traceReportLegacy.IndirectComplyingTree[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Datamanagement.ReportLegacy)indirectComplyingTree[i], modelManager);
		}
		traceReportLegacy.SelectedObject = modelManager.LoadObjectData(wire.getSelectedObject());
		IList persistentObjects = wire.getPersistentObjects();
		traceReportLegacy.PersistentObjects = new Teamcenter.Soa.Client.Model.ModelObject[persistentObjects.Count];
		for (int i = 0; i < persistentObjects.Count; i++)
		{
			traceReportLegacy.PersistentObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)persistentObjects[i]);
		}
		return traceReportLegacy;
	}

	public override Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutput2 GetTraceReport2(Teamcenter.Services.Strong.Core._2012_10.DataManagement.TraceabilityInfoInput1[] Input)
	{
		try
		{
			restSender.PushRequestId();
			GetTraceReport2Input getTraceReport2Input = new GetTraceReport2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			getTraceReport2Input.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutput2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201406_PORT_NAME, "GetTraceReport2", getTraceReport2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutput2 wire = (Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutput2)obj;
			Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutput2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutputLegacy GetTraceReportLegacy(Teamcenter.Services.Strong.Core._2011_06.DataManagement.TraceabilityInfoInput Input)
	{
		try
		{
			restSender.PushRequestId();
			GetTraceReportLegacyInput getTraceReportLegacyInput = new GetTraceReportLegacyInput();
			getTraceReportLegacyInput.setInput(toWire(Input));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutputLegacy);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201406_PORT_NAME, "GetTraceReportLegacy", getTraceReportLegacyInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutputLegacy wire = (Teamcenter.Schemas.Core._2014_06.Datamanagement.TraceabilityReportOutputLegacy)obj;
			Teamcenter.Services.Strong.Core._2014_06.DataManagement.TraceabilityReportOutputLegacy result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2014_10.Datamanagement.ChildrenInputData toWire(Teamcenter.Services.Strong.Core._2014_10.DataManagement.ChildrenInputData local)
	{
		Teamcenter.Schemas.Core._2014_10.Datamanagement.ChildrenInputData childrenInputData = new Teamcenter.Schemas.Core._2014_10.Datamanagement.ChildrenInputData();
		childrenInputData.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ParentObj == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ParentObj.Uid);
		}
		childrenInputData.setParentObj(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildrenObj.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ChildrenObj[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.ChildrenObj[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		childrenInputData.setChildrenObj(arrayList);
		childrenInputData.setPropertyName(local.PropertyName);
		return childrenInputData;
	}

	public static Teamcenter.Services.Strong.Core._2014_10.DataManagement.ChildrenInputData toLocal(Teamcenter.Schemas.Core._2014_10.Datamanagement.ChildrenInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_10.DataManagement.ChildrenInputData childrenInputData = new Teamcenter.Services.Strong.Core._2014_10.DataManagement.ChildrenInputData();
		childrenInputData.ClientId = wire.getClientId();
		childrenInputData.ParentObj = modelManager.LoadObjectData(wire.getParentObj());
		IList childrenObj = wire.getChildrenObj();
		childrenInputData.ChildrenObj = new Teamcenter.Soa.Client.Model.ModelObject[childrenObj.Count];
		for (int i = 0; i < childrenObj.Count; i++)
		{
			childrenInputData.ChildrenObj[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)childrenObj[i]);
		}
		childrenInputData.PropertyName = wire.getPropertyName();
		return childrenInputData;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData AddChildren(Teamcenter.Services.Strong.Core._2014_10.DataManagement.ChildrenInputData[] InputData)
	{
		try
		{
			restSender.PushRequestId();
			AddChildrenInput addChildrenInput = new AddChildrenInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputData.Length; i++)
			{
				arrayList.Add(toWire(InputData[i]));
			}
			addChildrenInput.setInputData(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201410_PORT_NAME, "AddChildren", addChildrenInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override Teamcenter.Soa.Client.Model.ServiceData RemoveChildren(Teamcenter.Services.Strong.Core._2014_10.DataManagement.ChildrenInputData[] InputData)
	{
		try
		{
			restSender.PushRequestId();
			RemoveChildrenInput removeChildrenInput = new RemoveChildrenInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputData.Length; i++)
			{
				arrayList.Add(toWire(InputData[i]));
			}
			removeChildrenInput.setInputData(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DATAMANAGEMENT_201410_PORT_NAME, "RemoveChildren", removeChildrenInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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
