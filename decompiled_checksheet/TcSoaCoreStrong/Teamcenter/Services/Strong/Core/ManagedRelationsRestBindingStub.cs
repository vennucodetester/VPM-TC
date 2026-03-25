using System;
using System.Collections;
using Teamcenter.Schemas.Core._2007_01.Managedrelations;
using Teamcenter.Schemas.Core._2008_06.Managedrelations;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Strong.Core._2007_01.ManagedRelations;
using Teamcenter.Services.Strong.Core._2008_06.ManagedRelations;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class ManagedRelationsRestBindingStub : ManagedRelationsService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string MANAGEDRELATIONS_200701_PORT_NAME = "Core-2007-01-ManagedRelations";

	private static readonly string MANAGEDRELATIONS_200806_PORT_NAME = "Core-2008-06-ManagedRelations";

	public ManagedRelationsRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.ComplyingReport toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ComplyingReport local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.ComplyingReport complyingReport = new Teamcenter.Schemas.Core._2007_01.Managedrelations.ComplyingReport();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		complyingReport.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Children[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Children[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		complyingReport.setChildren(arrayList);
		return complyingReport;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ComplyingReport toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.ComplyingReport wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ComplyingReport complyingReport = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ComplyingReport();
		complyingReport.Parent = modelManager.LoadObjectData(wire.getParent());
		IList children = wire.getChildren();
		complyingReport.Children = new Teamcenter.Soa.Client.Model.ModelObject[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			complyingReport.Children[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)children[i]);
		}
		return complyingReport;
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.CreateManagedRelationInput toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.CreateManagedRelationInput local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.CreateManagedRelationInput createManagedRelationInput = new Teamcenter.Schemas.Core._2007_01.Managedrelations.CreateManagedRelationInput();
		createManagedRelationInput.setName(local.Name);
		createManagedRelationInput.setType(local.Type);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PrimaryTagList.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PrimaryTagList[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.PrimaryTagList[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		createManagedRelationInput.setPrimaryTagList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.SecondaryTagList.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.SecondaryTagList[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.SecondaryTagList[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		createManagedRelationInput.setSecondaryTagList(arrayList2);
		return createManagedRelationInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.CreateManagedRelationInput toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.CreateManagedRelationInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.CreateManagedRelationInput createManagedRelationInput = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.CreateManagedRelationInput();
		createManagedRelationInput.Name = wire.getName();
		createManagedRelationInput.Type = wire.getType();
		IList primaryTagList = wire.getPrimaryTagList();
		createManagedRelationInput.PrimaryTagList = new Teamcenter.Soa.Client.Model.ModelObject[primaryTagList.Count];
		for (int i = 0; i < primaryTagList.Count; i++)
		{
			createManagedRelationInput.PrimaryTagList[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)primaryTagList[i]);
		}
		IList secondaryTagList = wire.getSecondaryTagList();
		createManagedRelationInput.SecondaryTagList = new Teamcenter.Soa.Client.Model.ModelObject[secondaryTagList.Count];
		for (int i = 0; i < secondaryTagList.Count; i++)
		{
			createManagedRelationInput.SecondaryTagList[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)secondaryTagList[i]);
		}
		return createManagedRelationInput;
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.DefiningReport toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.DefiningReport local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.DefiningReport definingReport = new Teamcenter.Schemas.Core._2007_01.Managedrelations.DefiningReport();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		definingReport.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Children[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Children[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		definingReport.setChildren(arrayList);
		return definingReport;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.DefiningReport toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.DefiningReport wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.DefiningReport definingReport = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.DefiningReport();
		definingReport.Parent = modelManager.LoadObjectData(wire.getParent());
		IList children = wire.getChildren();
		definingReport.Children = new Teamcenter.Soa.Client.Model.ModelObject[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			definingReport.Children[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)children[i]);
		}
		return definingReport;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse managedRelationResponse = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse();
		managedRelationResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList managedRelationObjects = wire.getManagedRelationObjects();
		managedRelationResponse.ManagedRelationObjects = new TraceLink[managedRelationObjects.Count];
		for (int i = 0; i < managedRelationObjects.Count; i++)
		{
			managedRelationResponse.ManagedRelationObjects[i] = (TraceLink)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)managedRelationObjects[i]);
		}
		return managedRelationResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifySources toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifySources local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifySources modifySources = new Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifySources();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AddSources.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.AddSources[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.AddSources[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		modifySources.setAddSources(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.RemoveSources.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.RemoveSources[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.RemoveSources[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		modifySources.setRemoveSources(arrayList2);
		return modifySources;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifySources toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifySources wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifySources modifySources = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifySources();
		IList addSources = wire.getAddSources();
		modifySources.AddSources = new Teamcenter.Soa.Client.Model.ModelObject[addSources.Count];
		for (int i = 0; i < addSources.Count; i++)
		{
			modifySources.AddSources[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)addSources[i]);
		}
		IList removeSources = wire.getRemoveSources();
		modifySources.RemoveSources = new Teamcenter.Soa.Client.Model.ModelObject[removeSources.Count];
		for (int i = 0; i < removeSources.Count; i++)
		{
			modifySources.RemoveSources[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)removeSources[i]);
		}
		return modifySources;
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyTargets toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyTargets local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyTargets modifyTargets = new Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyTargets();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AddTargets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.AddTargets[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.AddTargets[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		modifyTargets.setAddTargets(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.RemoveTargets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.RemoveTargets[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.RemoveTargets[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		modifyTargets.setRemoveTargets(arrayList2);
		return modifyTargets;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyTargets toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyTargets wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyTargets modifyTargets = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyTargets();
		IList addTargets = wire.getAddTargets();
		modifyTargets.AddTargets = new Teamcenter.Soa.Client.Model.ModelObject[addTargets.Count];
		for (int i = 0; i < addTargets.Count; i++)
		{
			modifyTargets.AddTargets[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)addTargets[i]);
		}
		IList removeTargets = wire.getRemoveTargets();
		modifyTargets.RemoveTargets = new Teamcenter.Soa.Client.Model.ModelObject[removeTargets.Count];
		for (int i = 0; i < removeTargets.Count; i++)
		{
			modifyTargets.RemoveTargets[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)removeTargets[i]);
		}
		return modifyTargets;
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyManagedRelationInput toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyManagedRelationInput local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyManagedRelationInput modifyManagedRelationInput = new Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyManagedRelationInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RelationTag == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RelationTag.Uid);
		}
		modifyManagedRelationInput.setRelationTag(modelObject);
		modifyManagedRelationInput.setSetSourcesInput(toWire(local.SetSourcesInput));
		modifyManagedRelationInput.setSetTargetsInput(toWire(local.SetTargetsInput));
		return modifyManagedRelationInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyManagedRelationInput toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.ModifyManagedRelationInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyManagedRelationInput modifyManagedRelationInput = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyManagedRelationInput();
		modifyManagedRelationInput.RelationTag = modelManager.LoadObjectData(wire.getRelationTag());
		modifyManagedRelationInput.SetSourcesInput = toLocal(wire.getSetSourcesInput(), modelManager);
		modifyManagedRelationInput.SetTargetsInput = toLocal(wire.getSetTargetsInput(), modelManager);
		return modifyManagedRelationInput;
	}

	public static Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityInfoInput toWire(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityInfoInput local)
	{
		Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityInfoInput traceabilityInfoInput = new Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityInfoInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.InputTag == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.InputTag.Uid);
		}
		traceabilityInfoInput.setInputTag(modelObject);
		traceabilityInfoInput.setReportType(local.ReportType);
		traceabilityInfoInput.setReportDepth(local.ReportDepth);
		return traceabilityInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityInfoInput toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityInfoInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityInfoInput traceabilityInfoInput = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityInfoInput();
		traceabilityInfoInput.InputTag = modelManager.LoadObjectData(wire.getInputTag());
		traceabilityInfoInput.ReportType = wire.getReportType();
		traceabilityInfoInput.ReportDepth = wire.getReportDepth();
		return traceabilityInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityReportOutput toLocal(Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityReportOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityReportOutput traceabilityReportOutput = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityReportOutput();
		traceabilityReportOutput.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList definingTree = wire.getDefiningTree();
		traceabilityReportOutput.DefiningTree = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.DefiningReport[definingTree.Count];
		for (int i = 0; i < definingTree.Count; i++)
		{
			traceabilityReportOutput.DefiningTree[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Managedrelations.DefiningReport)definingTree[i], modelManager);
		}
		IList indirectDefiningTree = wire.getIndirectDefiningTree();
		traceabilityReportOutput.IndirectDefiningTree = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.DefiningReport[indirectDefiningTree.Count];
		for (int i = 0; i < indirectDefiningTree.Count; i++)
		{
			traceabilityReportOutput.IndirectDefiningTree[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Managedrelations.DefiningReport)indirectDefiningTree[i], modelManager);
		}
		IList complyingTree = wire.getComplyingTree();
		traceabilityReportOutput.ComplyingTree = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ComplyingReport[complyingTree.Count];
		for (int i = 0; i < complyingTree.Count; i++)
		{
			traceabilityReportOutput.ComplyingTree[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Managedrelations.ComplyingReport)complyingTree[i], modelManager);
		}
		IList indirectComplyingTree = wire.getIndirectComplyingTree();
		traceabilityReportOutput.IndirectComplyingTree = new Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ComplyingReport[indirectComplyingTree.Count];
		for (int i = 0; i < indirectComplyingTree.Count; i++)
		{
			traceabilityReportOutput.IndirectComplyingTree[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Managedrelations.ComplyingReport)indirectComplyingTree[i], modelManager);
		}
		return traceabilityReportOutput;
	}

	public override Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse CreateRelation(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.CreateManagedRelationInput[] Relationinfo)
	{
		try
		{
			restSender.PushRequestId();
			CreateRelationInput createRelationInput = new CreateRelationInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Relationinfo.Length; i++)
			{
				arrayList.Add(toWire(Relationinfo[i]));
			}
			createRelationInput.setRelationinfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(MANAGEDRELATIONS_200701_PORT_NAME, "CreateRelation", createRelationInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse wire = (Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityReportOutput GetTraceReport(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityInfoInput Input)
	{
		try
		{
			restSender.PushRequestId();
			GetTraceReportInput getTraceReportInput = new GetTraceReportInput();
			getTraceReportInput.setInput(toWire(Input));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityReportOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(MANAGEDRELATIONS_200701_PORT_NAME, "GetTraceReport", getTraceReportInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityReportOutput wire = (Teamcenter.Schemas.Core._2007_01.Managedrelations.TraceabilityReportOutput)obj;
			Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.TraceabilityReportOutput result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse ModifyRelation(Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ModifyManagedRelationInput[] NewInput)
	{
		try
		{
			restSender.PushRequestId();
			ModifyRelationInput modifyRelationInput = new ModifyRelationInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < NewInput.Length; i++)
			{
				arrayList.Add(toWire(NewInput[i]));
			}
			modifyRelationInput.setNewInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(MANAGEDRELATIONS_200701_PORT_NAME, "ModifyRelation", modifyRelationInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse wire = (Teamcenter.Schemas.Core._2007_01.Managedrelations.ManagedRelationResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.ManagedRelations.ManagedRelationResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationInput toWire(Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationInput local)
	{
		Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationInput getManagedRelationInput = new Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationInput();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PrimaryTags.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PrimaryTags[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.PrimaryTags[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		getManagedRelationInput.setPrimaryTags(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.SecondaryTags.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.SecondaryTags[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.SecondaryTags[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		getManagedRelationInput.setSecondaryTags(arrayList2);
		getManagedRelationInput.setPrimaryType(local.PrimaryType);
		getManagedRelationInput.setSubtype(local.Subtype);
		return getManagedRelationInput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationInput toLocal(Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationInput getManagedRelationInput = new Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationInput();
		IList primaryTags = wire.getPrimaryTags();
		getManagedRelationInput.PrimaryTags = new Teamcenter.Soa.Client.Model.ModelObject[primaryTags.Count];
		for (int i = 0; i < primaryTags.Count; i++)
		{
			getManagedRelationInput.PrimaryTags[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)primaryTags[i]);
		}
		IList secondaryTags = wire.getSecondaryTags();
		getManagedRelationInput.SecondaryTags = new Teamcenter.Soa.Client.Model.ModelObject[secondaryTags.Count];
		for (int i = 0; i < secondaryTags.Count; i++)
		{
			getManagedRelationInput.SecondaryTags[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)secondaryTags[i]);
		}
		getManagedRelationInput.PrimaryType = wire.getPrimaryType();
		getManagedRelationInput.Subtype = wire.getSubtype();
		return getManagedRelationInput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationResponse toLocal(Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationResponse getManagedRelationResponse = new Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationResponse();
		getManagedRelationResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList managedRelations = wire.getManagedRelations();
		getManagedRelationResponse.ManagedRelations = new WorkspaceObject[managedRelations.Count];
		for (int i = 0; i < managedRelations.Count; i++)
		{
			getManagedRelationResponse.ManagedRelations[i] = (WorkspaceObject)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)managedRelations[i]);
		}
		return getManagedRelationResponse;
	}

	public override Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationResponse GetManagedRelations(Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationInput Inputdata)
	{
		try
		{
			restSender.PushRequestId();
			GetManagedRelationsInput getManagedRelationsInput = new GetManagedRelationsInput();
			getManagedRelationsInput.setInputdata(toWire(Inputdata));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(MANAGEDRELATIONS_200806_PORT_NAME, "GetManagedRelations", getManagedRelationsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationResponse wire = (Teamcenter.Schemas.Core._2008_06.Managedrelations.GetManagedRelationResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.ManagedRelations.GetManagedRelationResponse result = toLocal(wire, modelManager);
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
