using System;
using System.Collections;
using Teamcenter.Schemas.Core._2008_06.Structuremanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Strong.Core._2008_06.StructureManagement;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class StructureManagementRestBindingStub : StructureManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string STRUCTUREMANAGEMENT_200806_PORT_NAME = "Core-2008-06-StructureManagement";

	public StructureManagementRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.CreateInStructureAssociationResponse toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.CreateInStructureAssociationResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.CreateInStructureAssociationResponse createInStructureAssociationResponse = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.CreateInStructureAssociationResponse();
		createInStructureAssociationResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return createInStructureAssociationResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationInfo toWire(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationInfo getPrimariesOfInStructureAssociationInfo = new Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Secondary == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Secondary.Uid);
		}
		getPrimariesOfInStructureAssociationInfo.setSecondary(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ContextBOMLine.Uid);
		}
		getPrimariesOfInStructureAssociationInfo.setContextBOMLine(modelObject2);
		getPrimariesOfInStructureAssociationInfo.setAssociationType(local.AssociationType);
		return getPrimariesOfInStructureAssociationInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationInfo toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationInfo getPrimariesOfInStructureAssociationInfo = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationInfo();
		getPrimariesOfInStructureAssociationInfo.Secondary = modelManager.LoadObjectData(wire.getSecondary());
		getPrimariesOfInStructureAssociationInfo.ContextBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getContextBOMLine());
		getPrimariesOfInStructureAssociationInfo.AssociationType = wire.getAssociationType();
		return getPrimariesOfInStructureAssociationInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationResponse toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationResponse getPrimariesOfInStructureAssociationResponse = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationResponse();
		getPrimariesOfInStructureAssociationResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList primariesInfo = wire.getPrimariesInfo();
		getPrimariesOfInStructureAssociationResponse.PrimariesInfo = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.PrimariesOfInStructureAssociation[primariesInfo.Count];
		for (int i = 0; i < primariesInfo.Count; i++)
		{
			getPrimariesOfInStructureAssociationResponse.PrimariesInfo[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Structuremanagement.PrimariesOfInStructureAssociation)primariesInfo[i], modelManager);
		}
		return getPrimariesOfInStructureAssociationResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationInfo toWire(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationInfo getSecondariesOfInStructureAssociationInfo = new Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryBOMLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryBOMLine.Uid);
		}
		getSecondariesOfInStructureAssociationInfo.setPrimaryBOMLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ContextBOMLine.Uid);
		}
		getSecondariesOfInStructureAssociationInfo.setContextBOMLine(modelObject2);
		getSecondariesOfInStructureAssociationInfo.setAssociationType(local.AssociationType);
		return getSecondariesOfInStructureAssociationInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationInfo toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationInfo getSecondariesOfInStructureAssociationInfo = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationInfo();
		getSecondariesOfInStructureAssociationInfo.PrimaryBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getPrimaryBOMLine());
		getSecondariesOfInStructureAssociationInfo.ContextBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getContextBOMLine());
		getSecondariesOfInStructureAssociationInfo.AssociationType = wire.getAssociationType();
		return getSecondariesOfInStructureAssociationInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationResponse toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationResponse getSecondariesOfInStructureAssociationResponse = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationResponse();
		getSecondariesOfInStructureAssociationResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList secondariesInfo = wire.getSecondariesInfo();
		getSecondariesOfInStructureAssociationResponse.SecondariesInfo = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.SecondariesOfInStructureAssociation[secondariesInfo.Count];
		for (int i = 0; i < secondariesInfo.Count; i++)
		{
			getSecondariesOfInStructureAssociationResponse.SecondariesInfo[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Structuremanagement.SecondariesOfInStructureAssociation)secondariesInfo[i], modelManager);
		}
		return getSecondariesOfInStructureAssociationResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Structuremanagement.InStructureAssociationInfo toWire(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.InStructureAssociationInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Structuremanagement.InStructureAssociationInfo inStructureAssociationInfo = new Teamcenter.Schemas.Core._2008_06.Structuremanagement.InStructureAssociationInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryBOMLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryBOMLine.Uid);
		}
		inStructureAssociationInfo.setPrimaryBOMLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ContextBOMLine.Uid);
		}
		inStructureAssociationInfo.setContextBOMLine(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Secondaries.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Secondaries[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.Secondaries[i].Uid);
			}
			arrayList.Add(modelObject3);
		}
		inStructureAssociationInfo.setSecondaries(arrayList);
		inStructureAssociationInfo.setAssociationType(local.AssociationType);
		return inStructureAssociationInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.InStructureAssociationInfo toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.InStructureAssociationInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.InStructureAssociationInfo inStructureAssociationInfo = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.InStructureAssociationInfo();
		inStructureAssociationInfo.PrimaryBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getPrimaryBOMLine());
		inStructureAssociationInfo.ContextBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getContextBOMLine());
		IList secondaries = wire.getSecondaries();
		inStructureAssociationInfo.Secondaries = new Teamcenter.Soa.Client.Model.ModelObject[secondaries.Count];
		for (int i = 0; i < secondaries.Count; i++)
		{
			inStructureAssociationInfo.Secondaries[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)secondaries[i]);
		}
		inStructureAssociationInfo.AssociationType = wire.getAssociationType();
		return inStructureAssociationInfo;
	}

	public static Teamcenter.Schemas.Core._2008_06.Structuremanagement.PrimariesOfInStructureAssociation toWire(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.PrimariesOfInStructureAssociation local)
	{
		Teamcenter.Schemas.Core._2008_06.Structuremanagement.PrimariesOfInStructureAssociation primariesOfInStructureAssociation = new Teamcenter.Schemas.Core._2008_06.Structuremanagement.PrimariesOfInStructureAssociation();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Secondary == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Secondary.Uid);
		}
		primariesOfInStructureAssociation.setSecondary(modelObject);
		primariesOfInStructureAssociation.setAssociationType(local.AssociationType);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.PrimaryBOMLine.Uid);
		}
		primariesOfInStructureAssociation.setPrimaryBOMLine(modelObject2);
		return primariesOfInStructureAssociation;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.PrimariesOfInStructureAssociation toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.PrimariesOfInStructureAssociation wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.PrimariesOfInStructureAssociation primariesOfInStructureAssociation = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.PrimariesOfInStructureAssociation();
		primariesOfInStructureAssociation.Secondary = modelManager.LoadObjectData(wire.getSecondary());
		primariesOfInStructureAssociation.AssociationType = wire.getAssociationType();
		primariesOfInStructureAssociation.PrimaryBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getPrimaryBOMLine());
		return primariesOfInStructureAssociation;
	}

	public static Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsInfo toWire(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsInfo local)
	{
		Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsInfo removeInStructureAssociationsInfo = new Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryBOMLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryBOMLine.Uid);
		}
		removeInStructureAssociationsInfo.setPrimaryBOMLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ContextBOMLine.Uid);
		}
		removeInStructureAssociationsInfo.setContextBOMLine(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Secondaries.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Secondaries[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.Secondaries[i].Uid);
			}
			arrayList.Add(modelObject3);
		}
		removeInStructureAssociationsInfo.setSecondaries(arrayList);
		removeInStructureAssociationsInfo.setAssociationType(local.AssociationType);
		return removeInStructureAssociationsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsInfo toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsInfo removeInStructureAssociationsInfo = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsInfo();
		removeInStructureAssociationsInfo.PrimaryBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getPrimaryBOMLine());
		removeInStructureAssociationsInfo.ContextBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getContextBOMLine());
		IList secondaries = wire.getSecondaries();
		removeInStructureAssociationsInfo.Secondaries = new Teamcenter.Soa.Client.Model.ModelObject[secondaries.Count];
		for (int i = 0; i < secondaries.Count; i++)
		{
			removeInStructureAssociationsInfo.Secondaries[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)secondaries[i]);
		}
		removeInStructureAssociationsInfo.AssociationType = wire.getAssociationType();
		return removeInStructureAssociationsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsResponse removeInStructureAssociationsResponse = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsResponse();
		removeInStructureAssociationsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return removeInStructureAssociationsResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Structuremanagement.SecondariesOfInStructureAssociation toWire(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.SecondariesOfInStructureAssociation local)
	{
		Teamcenter.Schemas.Core._2008_06.Structuremanagement.SecondariesOfInStructureAssociation secondariesOfInStructureAssociation = new Teamcenter.Schemas.Core._2008_06.Structuremanagement.SecondariesOfInStructureAssociation();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.PrimaryBOMLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.PrimaryBOMLine.Uid);
		}
		secondariesOfInStructureAssociation.setPrimaryBOMLine(modelObject);
		secondariesOfInStructureAssociation.setAssociationType(local.AssociationType);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Secondaries.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Secondaries[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Secondaries[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		secondariesOfInStructureAssociation.setSecondaries(arrayList);
		return secondariesOfInStructureAssociation;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.StructureManagement.SecondariesOfInStructureAssociation toLocal(Teamcenter.Schemas.Core._2008_06.Structuremanagement.SecondariesOfInStructureAssociation wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.StructureManagement.SecondariesOfInStructureAssociation secondariesOfInStructureAssociation = new Teamcenter.Services.Strong.Core._2008_06.StructureManagement.SecondariesOfInStructureAssociation();
		secondariesOfInStructureAssociation.PrimaryBOMLine = (BOMLine)modelManager.LoadObjectData(wire.getPrimaryBOMLine());
		secondariesOfInStructureAssociation.AssociationType = wire.getAssociationType();
		IList secondaries = wire.getSecondaries();
		secondariesOfInStructureAssociation.Secondaries = new Teamcenter.Soa.Client.Model.ModelObject[secondaries.Count];
		for (int i = 0; i < secondaries.Count; i++)
		{
			secondariesOfInStructureAssociation.Secondaries[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)secondaries[i]);
		}
		return secondariesOfInStructureAssociation;
	}

	public override Teamcenter.Services.Strong.Core._2008_06.StructureManagement.CreateInStructureAssociationResponse CreateInStructureAssociations(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.InStructureAssociationInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			CreateInStructureAssociationsInput createInStructureAssociationsInput = new CreateInStructureAssociationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createInStructureAssociationsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Structuremanagement.CreateInStructureAssociationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "CreateInStructureAssociations", createInStructureAssociationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Structuremanagement.CreateInStructureAssociationResponse wire = (Teamcenter.Schemas.Core._2008_06.Structuremanagement.CreateInStructureAssociationResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.StructureManagement.CreateInStructureAssociationResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationResponse GetPrimariesOfInStructureAssociation(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetPrimariesOfInStructureAssociationInput getPrimariesOfInStructureAssociationInput = new GetPrimariesOfInStructureAssociationInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getPrimariesOfInStructureAssociationInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "GetPrimariesOfInStructureAssociation", getPrimariesOfInStructureAssociationInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationResponse wire = (Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetPrimariesOfInStructureAssociationResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetPrimariesOfInStructureAssociationResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationResponse GetSecondariesOfInStructureAssociation(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetSecondariesOfInStructureAssociationInput getSecondariesOfInStructureAssociationInput = new GetSecondariesOfInStructureAssociationInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getSecondariesOfInStructureAssociationInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "GetSecondariesOfInStructureAssociation", getSecondariesOfInStructureAssociationInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationResponse wire = (Teamcenter.Schemas.Core._2008_06.Structuremanagement.GetSecondariesOfInStructureAssociationResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.StructureManagement.GetSecondariesOfInStructureAssociationResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsResponse RemoveInStructureAssociations(Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			RemoveInStructureAssociationsInput removeInStructureAssociationsInput = new RemoveInStructureAssociationsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			removeInStructureAssociationsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "RemoveInStructureAssociations", removeInStructureAssociationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsResponse wire = (Teamcenter.Schemas.Core._2008_06.Structuremanagement.RemoveInStructureAssociationsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.StructureManagement.RemoveInStructureAssociationsResponse result = toLocal(wire, modelManager);
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
