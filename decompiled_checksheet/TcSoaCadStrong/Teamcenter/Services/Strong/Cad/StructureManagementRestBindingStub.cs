using System;
using System.Collections;
using Teamcenter.Schemas.Cad._2007_01.Structuremanagement;
using Teamcenter.Schemas.Cad._2007_06.Structuremanagement;
using Teamcenter.Schemas.Cad._2007_09.Structuremanagement;
using Teamcenter.Schemas.Cad._2007_12.Structuremanagement;
using Teamcenter.Schemas.Cad._2008_03.Structuremanagement;
using Teamcenter.Schemas.Cad._2008_06.Structuremanagement;
using Teamcenter.Schemas.Cad._2009_04.Structuremanagement;
using Teamcenter.Schemas.Cad._2013_05.Structuremanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Cad._2007_01.StructureManagement;
using Teamcenter.Services.Strong.Cad._2007_06.StructureManagement;
using Teamcenter.Services.Strong.Cad._2007_09.StructureManagement;
using Teamcenter.Services.Strong.Cad._2007_12.StructureManagement;
using Teamcenter.Services.Strong.Cad._2008_03.StructureManagement;
using Teamcenter.Services.Strong.Cad._2008_06.StructureManagement;
using Teamcenter.Services.Strong.Cad._2009_04.StructureManagement;
using Teamcenter.Services.Strong.Cad._2013_05.StructureManagement;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Cad;

public class StructureManagementRestBindingStub : StructureManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string STRUCTUREMANAGEMENT_200701_PORT_NAME = "Cad-2007-01-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_200706_PORT_NAME = "Cad-2007-06-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_200709_PORT_NAME = "Cad-2007-09-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_200712_PORT_NAME = "Cad-2007-12-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_200803_PORT_NAME = "Cad-2008-03-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_200806_PORT_NAME = "Cad-2008-06-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_200904_PORT_NAME = "Cad-2009-04-StructureManagement";

	private static readonly string STRUCTUREMANAGEMENT_201305_PORT_NAME = "Cad-2013-05-StructureManagement";

	public StructureManagementRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccAttachment toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccAttachment local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccAttachment absOccAttachment = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccAttachment();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		absOccAttachment.setDataset(modelObject);
		absOccAttachment.setRelationTypeName(local.RelationTypeName);
		return absOccAttachment;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccAttachment toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccAttachment wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccAttachment absOccAttachment = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccAttachment();
		absOccAttachment.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		absOccAttachment.RelationTypeName = wire.getRelationTypeName();
		return absOccAttachment;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccDataInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccDataInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccDataInfo absOccDataInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccDataInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OverridesToSet.Length; i++)
		{
			arrayList.Add(toWire(local.OverridesToSet[i]));
		}
		absOccDataInfo.setOverridesToSet(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.OverridesToRemove.Length; i++)
		{
			arrayList2.Add(local.OverridesToRemove[i]);
		}
		absOccDataInfo.setOverridesToRemove(arrayList2);
		absOccDataInfo.setAsRequired(local.AsRequired);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.OccTransform.Length; i++)
		{
			arrayList3.Add(local.OccTransform[i]);
		}
		absOccDataInfo.setOccTransform(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.OccNotes.Length; i++)
		{
			arrayList4.Add(toWire(local.OccNotes[i]));
		}
		absOccDataInfo.setOccNotes(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.Attachments.Length; i++)
		{
			arrayList5.Add(toWire(local.Attachments[i]));
		}
		absOccDataInfo.setAttachments(arrayList5);
		ArrayList arrayList6 = new ArrayList();
		for (int i = 0; i < local.AttachmentsToUnattach.Length; i++)
		{
			arrayList6.Add(toWire(local.AttachmentsToUnattach[i]));
		}
		absOccDataInfo.setAttachmentsToUnattach(arrayList6);
		absOccDataInfo.setClientIdOfUsedArrangement(local.ClientIdOfUsedArrangement);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.UsedArr == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.UsedArr.Uid);
		}
		absOccDataInfo.setUsedArr(modelObject);
		return absOccDataInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccDataInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccDataInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccDataInfo absOccDataInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccDataInfo();
		IList overridesToSet = wire.getOverridesToSet();
		absOccDataInfo.OverridesToSet = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo[overridesToSet.Count];
		for (int i = 0; i < overridesToSet.Count; i++)
		{
			absOccDataInfo.OverridesToSet[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo)overridesToSet[i], modelManager);
		}
		IList overridesToRemove = wire.getOverridesToRemove();
		absOccDataInfo.OverridesToRemove = new string[overridesToRemove.Count];
		for (int i = 0; i < overridesToRemove.Count; i++)
		{
			absOccDataInfo.OverridesToRemove[i] = Convert.ToString(overridesToRemove[i]);
		}
		absOccDataInfo.AsRequired = wire.AsRequired;
		IList occTransform = wire.getOccTransform();
		absOccDataInfo.OccTransform = new double[occTransform.Count];
		for (int i = 0; i < occTransform.Count; i++)
		{
			absOccDataInfo.OccTransform[i] = Convert.ToDouble(occTransform[i]);
		}
		IList occNotes = wire.getOccNotes();
		absOccDataInfo.OccNotes = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote[occNotes.Count];
		for (int i = 0; i < occNotes.Count; i++)
		{
			absOccDataInfo.OccNotes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote)occNotes[i], modelManager);
		}
		IList attachments = wire.getAttachments();
		absOccDataInfo.Attachments = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccAttachment[attachments.Count];
		for (int i = 0; i < attachments.Count; i++)
		{
			absOccDataInfo.Attachments[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccAttachment)attachments[i], modelManager);
		}
		IList attachmentsToUnattach = wire.getAttachmentsToUnattach();
		absOccDataInfo.AttachmentsToUnattach = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccAttachment[attachmentsToUnattach.Count];
		for (int i = 0; i < attachmentsToUnattach.Count; i++)
		{
			absOccDataInfo.AttachmentsToUnattach[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccAttachment)attachmentsToUnattach[i], modelManager);
		}
		absOccDataInfo.ClientIdOfUsedArrangement = wire.getClientIdOfUsedArrangement();
		absOccDataInfo.UsedArr = (AssemblyArrangement)modelManager.LoadObjectData(wire.getUsedArr());
		return absOccDataInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo absOccInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo();
		absOccInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.AbsOcc == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.AbsOcc.Uid);
		}
		absOccInfo.setAbsOcc(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.CadOccIdPath.Length; i++)
		{
			arrayList.Add(local.CadOccIdPath[i]);
		}
		absOccInfo.setCadOccIdPath(arrayList);
		absOccInfo.setAbsOccData(toWire(local.AbsOccData));
		return absOccInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo absOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo();
		absOccInfo.ClientId = wire.getClientId();
		absOccInfo.AbsOcc = (AbsOccurrence)modelManager.LoadObjectData(wire.getAbsOcc());
		IList cadOccIdPath = wire.getCadOccIdPath();
		absOccInfo.CadOccIdPath = new string[cadOccIdPath.Count];
		for (int i = 0; i < cadOccIdPath.Count; i++)
		{
			absOccInfo.CadOccIdPath[i] = Convert.ToString(cadOccIdPath[i]);
		}
		absOccInfo.AbsOccData = toLocal(wire.getAbsOccData(), modelManager);
		return absOccInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo assemblyArrangementInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo();
		assemblyArrangementInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Arrangement == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Arrangement.Uid);
		}
		assemblyArrangementInfo.setArrangement(modelObject);
		assemblyArrangementInfo.setName(local.Name);
		assemblyArrangementInfo.setIsDefault(local.IsDefault);
		assemblyArrangementInfo.setDescription(local.Description);
		assemblyArrangementInfo.setExternalUid(local.ExternalUid);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AbsOccInfo.Length; i++)
		{
			arrayList.Add(toWire(local.AbsOccInfo[i]));
		}
		assemblyArrangementInfo.setAbsOccInfo(arrayList);
		return assemblyArrangementInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo assemblyArrangementInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo();
		assemblyArrangementInfo.ClientId = wire.getClientId();
		assemblyArrangementInfo.Arrangement = (AssemblyArrangement)modelManager.LoadObjectData(wire.getArrangement());
		assemblyArrangementInfo.Name = wire.getName();
		assemblyArrangementInfo.IsDefault = wire.IsDefault;
		assemblyArrangementInfo.Description = wire.getDescription();
		assemblyArrangementInfo.ExternalUid = wire.getExternalUid();
		IList absOccInfo = wire.getAbsOccInfo();
		assemblyArrangementInfo.AbsOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo[absOccInfo.Count];
		for (int i = 0; i < absOccInfo.Count; i++)
		{
			assemblyArrangementInfo.AbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo)absOccInfo[i], modelManager);
		}
		return assemblyArrangementInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo attributesInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo();
		attributesInfo.setName(local.Name);
		attributesInfo.setValue(local.Value);
		return attributesInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo attributesInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo();
		attributesInfo.Name = wire.getName();
		attributesInfo.Value = wire.getValue();
		return attributesInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CloseBOMWindowsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CloseBOMWindowsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CloseBOMWindowsResponse closeBOMWindowsResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CloseBOMWindowsResponse();
		closeBOMWindowsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return closeBOMWindowsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleEntryProps toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleEntryProps local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleEntryProps revisionRuleEntryProps = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleEntryProps();
		revisionRuleEntryProps.setUnitNo(local.UnitNo);
		revisionRuleEntryProps.setDate(TcServerDate.ToWire(local.Date));
		revisionRuleEntryProps.setToday(local.Today);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.EndItem == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.EndItem.Uid);
		}
		revisionRuleEntryProps.setEndItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.EndItemRevision == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.EndItemRevision.Uid);
		}
		revisionRuleEntryProps.setEndItemRevision(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OverrideFolders.Length; i++)
		{
			arrayList.Add(toWire(local.OverrideFolders[i]));
		}
		revisionRuleEntryProps.setOverrideFolders(arrayList);
		return revisionRuleEntryProps;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleEntryProps toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleEntryProps wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleEntryProps revisionRuleEntryProps = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleEntryProps();
		revisionRuleEntryProps.UnitNo = wire.getUnitNo();
		revisionRuleEntryProps.Date = TcServerDate.ToLocal(wire.getDate());
		revisionRuleEntryProps.Today = wire.Today;
		revisionRuleEntryProps.EndItem = (Item)modelManager.LoadObjectData(wire.getEndItem());
		revisionRuleEntryProps.EndItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getEndItemRevision());
		IList overrideFolders = wire.getOverrideFolders();
		revisionRuleEntryProps.OverrideFolders = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OverrideInfo[overrideFolders.Count];
		for (int i = 0; i < overrideFolders.Count; i++)
		{
			revisionRuleEntryProps.OverrideFolders[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OverrideInfo)overrideFolders[i], modelManager);
		}
		return revisionRuleEntryProps;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleConfigInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleConfigInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleConfigInfo revisionRuleConfigInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleConfigInfo();
		revisionRuleConfigInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RevRule == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RevRule.Uid);
		}
		revisionRuleConfigInfo.setRevRule(modelObject);
		revisionRuleConfigInfo.setProps(toWire(local.Props));
		return revisionRuleConfigInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleConfigInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleConfigInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleConfigInfo revisionRuleConfigInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleConfigInfo();
		revisionRuleConfigInfo.ClientId = wire.getClientId();
		revisionRuleConfigInfo.RevRule = (RevisionRule)modelManager.LoadObjectData(wire.getRevRule());
		revisionRuleConfigInfo.Props = toLocal(wire.getProps(), modelManager);
		return revisionRuleConfigInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsInfo createBOMWindowsInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsInfo();
		createBOMWindowsInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		createBOMWindowsInfo.setItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		createBOMWindowsInfo.setItemRev(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomView == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.BomView.Uid);
		}
		createBOMWindowsInfo.setBomView(modelObject3);
		createBOMWindowsInfo.setRevRuleConfigInfo(toWire(local.RevRuleConfigInfo));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject4 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectForConfigure == null)
		{
			modelObject4.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject4.setUid(local.ObjectForConfigure.Uid);
		}
		createBOMWindowsInfo.setObjectForConfigure(modelObject4);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject5 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ActiveAssemblyArrangement == null)
		{
			modelObject5.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject5.setUid(local.ActiveAssemblyArrangement.Uid);
		}
		createBOMWindowsInfo.setActiveAssemblyArrangement(modelObject5);
		return createBOMWindowsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsInfo createBOMWindowsInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsInfo();
		createBOMWindowsInfo.ClientId = wire.getClientId();
		createBOMWindowsInfo.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		createBOMWindowsInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		createBOMWindowsInfo.BomView = (PSBOMView)modelManager.LoadObjectData(wire.getBomView());
		createBOMWindowsInfo.RevRuleConfigInfo = toLocal(wire.getRevRuleConfigInfo(), modelManager);
		createBOMWindowsInfo.ObjectForConfigure = modelManager.LoadObjectData(wire.getObjectForConfigure());
		createBOMWindowsInfo.ActiveAssemblyArrangement = (AssemblyArrangement)modelManager.LoadObjectData(wire.getActiveAssemblyArrangement());
		return createBOMWindowsInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsOutput createBOMWindowsOutput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsOutput();
		createBOMWindowsOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomWindow == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomWindow.Uid);
		}
		createBOMWindowsOutput.setBomWindow(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.BomLine.Uid);
		}
		createBOMWindowsOutput.setBomLine(modelObject2);
		return createBOMWindowsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsOutput createBOMWindowsOutput = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsOutput();
		createBOMWindowsOutput.ClientId = wire.getClientId();
		createBOMWindowsOutput.BomWindow = (BOMWindow)modelManager.LoadObjectData(wire.getBomWindow());
		createBOMWindowsOutput.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		return createBOMWindowsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse createBOMWindowsResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse();
		createBOMWindowsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createBOMWindowsResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createBOMWindowsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsOutput)output[i], modelManager);
		}
		return createBOMWindowsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo createOrUpdateAbsoluteStructureInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ContextItemRev.Uid);
		}
		createOrUpdateAbsoluteStructureInfo.setContextItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BvrAbsOccInfo.Length; i++)
		{
			arrayList.Add(toWire(local.BvrAbsOccInfo[i]));
		}
		createOrUpdateAbsoluteStructureInfo.setBvrAbsOccInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ArrAbsOccInfo.Length; i++)
		{
			arrayList2.Add(toWire(local.ArrAbsOccInfo[i]));
		}
		createOrUpdateAbsoluteStructureInfo.setArrAbsOccInfo(arrayList2);
		return createOrUpdateAbsoluteStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureInfo createOrUpdateAbsoluteStructureInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureInfo();
		createOrUpdateAbsoluteStructureInfo.ContextItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getContextItemRev());
		IList bvrAbsOccInfo = wire.getBvrAbsOccInfo();
		createOrUpdateAbsoluteStructureInfo.BvrAbsOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo[bvrAbsOccInfo.Count];
		for (int i = 0; i < bvrAbsOccInfo.Count; i++)
		{
			createOrUpdateAbsoluteStructureInfo.BvrAbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo)bvrAbsOccInfo[i], modelManager);
		}
		IList arrAbsOccInfo = wire.getArrAbsOccInfo();
		createOrUpdateAbsoluteStructureInfo.ArrAbsOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo[arrAbsOccInfo.Count];
		for (int i = 0; i < arrAbsOccInfo.Count; i++)
		{
			createOrUpdateAbsoluteStructureInfo.ArrAbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo)arrAbsOccInfo[i], modelManager);
		}
		return createOrUpdateAbsoluteStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructurePref toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructurePref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructurePref createOrUpdateAbsoluteStructurePref = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructurePref();
		createOrUpdateAbsoluteStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		return createOrUpdateAbsoluteStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructurePref toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructurePref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructurePref createOrUpdateAbsoluteStructurePref = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructurePref();
		createOrUpdateAbsoluteStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		return createOrUpdateAbsoluteStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse createOrUpdateAbsoluteStructureResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse();
		createOrUpdateAbsoluteStructureResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		createOrUpdateAbsoluteStructureResponse.AbsOccOutput = toLocalClientIdToAbsOccMap(wire.getAbsOccOutput(), modelManager);
		createOrUpdateAbsoluteStructureResponse.AsmArrOutput = toLocalClientIdToAsmArrMap(wire.getAsmArrOutput(), modelManager);
		return createOrUpdateAbsoluteStructureResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureInfo createOrUpdateRelativeStructureInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		createOrUpdateRelativeStructureInfo.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ChildInfo[i]));
		}
		createOrUpdateRelativeStructureInfo.setChildInfo(arrayList);
		createOrUpdateRelativeStructureInfo.setPrecise(local.Precise);
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureInfo createOrUpdateRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureInfo();
		createOrUpdateRelativeStructureInfo.Parent = (ItemRevision)modelManager.LoadObjectData(wire.getParent());
		IList childInfo = wire.getChildInfo();
		createOrUpdateRelativeStructureInfo.ChildInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelativeStructureChildInfo[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			createOrUpdateRelativeStructureInfo.ChildInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelativeStructureChildInfo)childInfo[i], modelManager);
		}
		createOrUpdateRelativeStructureInfo.Precise = wire.Precise;
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructurePref toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructurePref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructurePref createOrUpdateRelativeStructurePref = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructurePref();
		createOrUpdateRelativeStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemTypes.Length; i++)
		{
			arrayList.Add(local.ItemTypes[i]);
		}
		createOrUpdateRelativeStructurePref.setItemTypes(arrayList);
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructurePref toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructurePref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructurePref createOrUpdateRelativeStructurePref = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructurePref();
		createOrUpdateRelativeStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		IList itemTypes = wire.getItemTypes();
		createOrUpdateRelativeStructurePref.ItemTypes = new string[itemTypes.Count];
		for (int i = 0; i < itemTypes.Count; i++)
		{
			createOrUpdateRelativeStructurePref.ItemTypes[i] = Convert.ToString(itemTypes[i]);
		}
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse createOrUpdateRelativeStructureResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse();
		createOrUpdateRelativeStructureResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		createOrUpdateRelativeStructureResponse.Output = toLocalClientIdToPSOccurrenceThreadMap(wire.getOutput(), modelManager);
		return createOrUpdateRelativeStructureResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsInfo deleteAssemblyArrangementsInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRev.Uid);
		}
		deleteAssemblyArrangementsInfo.setItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Arrangements.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Arrangements[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Arrangements[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		deleteAssemblyArrangementsInfo.setArrangements(arrayList);
		return deleteAssemblyArrangementsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsInfo deleteAssemblyArrangementsInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsInfo();
		deleteAssemblyArrangementsInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList arrangements = wire.getArrangements();
		deleteAssemblyArrangementsInfo.Arrangements = new AssemblyArrangement[arrangements.Count];
		for (int i = 0; i < arrangements.Count; i++)
		{
			deleteAssemblyArrangementsInfo.Arrangements[i] = (AssemblyArrangement)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)arrangements[i]);
		}
		return deleteAssemblyArrangementsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse deleteAssemblyArrangementsResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse();
		deleteAssemblyArrangementsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return deleteAssemblyArrangementsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureInfo deleteRelativeStructureInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		deleteRelativeStructureInfo.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(local.ChildInfo[i]);
		}
		deleteRelativeStructureInfo.setChildInfo(arrayList);
		return deleteRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureInfo deleteRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureInfo();
		deleteRelativeStructureInfo.Parent = (ItemRevision)modelManager.LoadObjectData(wire.getParent());
		IList childInfo = wire.getChildInfo();
		deleteRelativeStructureInfo.ChildInfo = new string[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			deleteRelativeStructureInfo.ChildInfo[i] = Convert.ToString(childInfo[i]);
		}
		return deleteRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructurePref toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructurePref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructurePref deleteRelativeStructurePref = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructurePref();
		deleteRelativeStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		return deleteRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructurePref toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructurePref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructurePref deleteRelativeStructurePref = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructurePref();
		deleteRelativeStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		return deleteRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse deleteRelativeStructureResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse();
		deleteRelativeStructureResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return deleteRelativeStructureResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsInfo expandPSAllLevelsInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParentBomLines.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ParentBomLines[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.ParentBomLines[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		expandPSAllLevelsInfo.setParentBomLines(arrayList);
		expandPSAllLevelsInfo.setExcludeFilter(local.ExcludeFilter);
		return expandPSAllLevelsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsInfo expandPSAllLevelsInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsInfo();
		IList parentBomLines = wire.getParentBomLines();
		expandPSAllLevelsInfo.ParentBomLines = new BOMLine[parentBomLines.Count];
		for (int i = 0; i < parentBomLines.Count; i++)
		{
			expandPSAllLevelsInfo.ParentBomLines[i] = (BOMLine)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)parentBomLines[i]);
		}
		expandPSAllLevelsInfo.ExcludeFilter = wire.getExcludeFilter();
		return expandPSAllLevelsInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSParentData toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSParentData local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSParentData expandPSParentData = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSParentData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		expandPSParentData.setBomLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevOfBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRevOfBOMLine.Uid);
		}
		expandPSParentData.setItemRevOfBOMLine(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParentDatasets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ParentDatasets[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.ParentDatasets[i].Uid);
			}
			arrayList.Add(modelObject3);
		}
		expandPSParentData.setParentDatasets(arrayList);
		return expandPSParentData;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSParentData toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSParentData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSParentData expandPSParentData = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSParentData();
		expandPSParentData.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		expandPSParentData.ItemRevOfBOMLine = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevOfBOMLine());
		IList parentDatasets = wire.getParentDatasets();
		expandPSParentData.ParentDatasets = new Dataset[parentDatasets.Count];
		for (int i = 0; i < parentDatasets.Count; i++)
		{
			expandPSParentData.ParentDatasets[i] = (Dataset)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)parentDatasets[i]);
		}
		return expandPSParentData;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsOutput expandPSAllLevelsOutput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsOutput();
		expandPSAllLevelsOutput.setParent(toWire(local.Parent));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			arrayList.Add(toWire(local.Children[i]));
		}
		expandPSAllLevelsOutput.setChildren(arrayList);
		return expandPSAllLevelsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsOutput expandPSAllLevelsOutput = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsOutput();
		expandPSAllLevelsOutput.Parent = toLocal(wire.getParent(), modelManager);
		IList children = wire.getChildren();
		expandPSAllLevelsOutput.Children = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSData[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			expandPSAllLevelsOutput.Children[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSData)children[i], modelManager);
		}
		return expandPSAllLevelsOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsPref toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsPref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsPref expandPSAllLevelsPref = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsPref();
		expandPSAllLevelsPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandPSAllLevelsPref.setInfo(arrayList);
		return expandPSAllLevelsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsPref toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsPref expandPSAllLevelsPref = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsPref();
		expandPSAllLevelsPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandPSAllLevelsPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandPSAllLevelsPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter)info[i], modelManager);
		}
		return expandPSAllLevelsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsResponse expandPSAllLevelsResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsResponse();
		expandPSAllLevelsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandPSAllLevelsResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandPSAllLevelsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsOutput)output[i], modelManager);
		}
		return expandPSAllLevelsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSData toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSData local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSData expandPSData = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		expandPSData.setBomLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevOfBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRevOfBOMLine.Uid);
		}
		expandPSData.setItemRevOfBOMLine(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Datasets.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Datasets[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.Datasets[i].Uid);
			}
			arrayList.Add(modelObject3);
		}
		expandPSData.setDatasets(arrayList);
		return expandPSData;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSData toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSData expandPSData = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSData();
		expandPSData.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		expandPSData.ItemRevOfBOMLine = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevOfBOMLine());
		IList datasets = wire.getDatasets();
		expandPSData.Datasets = new Dataset[datasets.Count];
		for (int i = 0; i < datasets.Count; i++)
		{
			expandPSData.Datasets[i] = (Dataset)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)datasets[i]);
		}
		return expandPSData;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelInfo expandPSOneLevelInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParentBomLines.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ParentBomLines[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.ParentBomLines[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		expandPSOneLevelInfo.setParentBomLines(arrayList);
		expandPSOneLevelInfo.setExcludeFilter(local.ExcludeFilter);
		return expandPSOneLevelInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelInfo expandPSOneLevelInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelInfo();
		IList parentBomLines = wire.getParentBomLines();
		expandPSOneLevelInfo.ParentBomLines = new BOMLine[parentBomLines.Count];
		for (int i = 0; i < parentBomLines.Count; i++)
		{
			expandPSOneLevelInfo.ParentBomLines[i] = (BOMLine)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)parentBomLines[i]);
		}
		expandPSOneLevelInfo.ExcludeFilter = wire.getExcludeFilter();
		return expandPSOneLevelInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelOutput toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelOutput local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelOutput expandPSOneLevelOutput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelOutput();
		expandPSOneLevelOutput.setParent(toWire(local.Parent));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			arrayList.Add(toWire(local.Children[i]));
		}
		expandPSOneLevelOutput.setChildren(arrayList);
		return expandPSOneLevelOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelOutput toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelOutput expandPSOneLevelOutput = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelOutput();
		expandPSOneLevelOutput.Parent = toLocal(wire.getParent(), modelManager);
		IList children = wire.getChildren();
		expandPSOneLevelOutput.Children = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSData[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			expandPSOneLevelOutput.Children[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSData)children[i], modelManager);
		}
		return expandPSOneLevelOutput;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelPref toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelPref local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelPref expandPSOneLevelPref = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelPref();
		expandPSOneLevelPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandPSOneLevelPref.setInfo(arrayList);
		return expandPSOneLevelPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelPref toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelPref expandPSOneLevelPref = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelPref();
		expandPSOneLevelPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandPSOneLevelPref.Info = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandPSOneLevelPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter)info[i], modelManager);
		}
		return expandPSOneLevelPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelResponse expandPSOneLevelResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelResponse();
		expandPSOneLevelResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandPSOneLevelResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandPSOneLevelResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelOutput)output[i], modelManager);
		}
		return expandPSOneLevelResponse;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetRevisionRulesResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetRevisionRulesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetRevisionRulesResponse getRevisionRulesResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetRevisionRulesResponse();
		getRevisionRulesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getRevisionRulesResponse.Output = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleInfo[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getRevisionRulesResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleInfo)output[i], modelManager);
		}
		return getRevisionRulesResponse;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetVariantRulesResponse toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetVariantRulesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetVariantRulesResponse getVariantRulesResponse = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetVariantRulesResponse();
		getVariantRulesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getVariantRulesResponse.InputItemRevToVarRules = toLocalItemRevisionToVariantRulesMap(wire.getInputItemRevToVarRules(), modelManager);
		return getVariantRulesResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote occNote = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote();
		occNote.setNoteType(local.NoteType);
		occNote.setNoteText(local.NoteText);
		return occNote;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote occNote = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote();
		occNote.NoteType = wire.getNoteType();
		occNote.NoteText = wire.getNoteText();
		return occNote;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OverrideInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OverrideInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OverrideInfo overrideInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OverrideInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RuleEntry == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RuleEntry.Uid);
		}
		overrideInfo.setRuleEntry(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Folder == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Folder.Uid);
		}
		overrideInfo.setFolder(modelObject2);
		return overrideInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OverrideInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OverrideInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OverrideInfo overrideInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OverrideInfo();
		overrideInfo.RuleEntry = (CFMOverrideEntry)modelManager.LoadObjectData(wire.getRuleEntry());
		overrideInfo.Folder = (Folder)modelManager.LoadObjectData(wire.getFolder());
		return overrideInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter();
		relationAndTypesFilter.setRelationName(local.RelationName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelationTypeNames.Length; i++)
		{
			arrayList.Add(local.RelationTypeNames[i]);
		}
		relationAndTypesFilter.setRelationTypeNames(arrayList);
		return relationAndTypesFilter;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter();
		relationAndTypesFilter.RelationName = wire.getRelationName();
		IList relationTypeNames = wire.getRelationTypeNames();
		relationAndTypesFilter.RelationTypeNames = new string[relationTypeNames.Count];
		for (int i = 0; i < relationTypeNames.Count; i++)
		{
			relationAndTypesFilter.RelationTypeNames[i] = Convert.ToString(relationTypeNames[i]);
		}
		return relationAndTypesFilter;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelOccInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelOccInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelOccInfo relOccInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelOccInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrsToSet.Length; i++)
		{
			arrayList.Add(toWire(local.AttrsToSet[i]));
		}
		relOccInfo.setAttrsToSet(arrayList);
		relOccInfo.setAsRequired(local.AsRequired);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.OccTransform.Length; i++)
		{
			arrayList2.Add(local.OccTransform[i]);
		}
		relOccInfo.setOccTransform(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.OccNotes.Length; i++)
		{
			arrayList3.Add(toWire(local.OccNotes[i]));
		}
		relOccInfo.setOccNotes(arrayList3);
		return relOccInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelOccInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelOccInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelOccInfo relOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelOccInfo();
		IList attrsToSet = wire.getAttrsToSet();
		relOccInfo.AttrsToSet = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo[attrsToSet.Count];
		for (int i = 0; i < attrsToSet.Count; i++)
		{
			relOccInfo.AttrsToSet[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo)attrsToSet[i], modelManager);
		}
		relOccInfo.AsRequired = wire.AsRequired;
		IList occTransform = wire.getOccTransform();
		relOccInfo.OccTransform = new double[occTransform.Count];
		for (int i = 0; i < occTransform.Count; i++)
		{
			relOccInfo.OccTransform[i] = Convert.ToDouble(occTransform[i]);
		}
		IList occNotes = wire.getOccNotes();
		relOccInfo.OccNotes = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote[occNotes.Count];
		for (int i = 0; i < occNotes.Count; i++)
		{
			relOccInfo.OccNotes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote)occNotes[i], modelManager);
		}
		return relOccInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelativeStructureChildInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelativeStructureChildInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelativeStructureChildInfo relativeStructureChildInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelativeStructureChildInfo();
		relativeStructureChildInfo.setClientId(local.ClientId);
		relativeStructureChildInfo.setCadOccId(local.CadOccId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Child == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Child.Uid);
		}
		relativeStructureChildInfo.setChild(modelObject);
		relativeStructureChildInfo.setOccInfo(toWire(local.OccInfo));
		return relativeStructureChildInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelativeStructureChildInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelativeStructureChildInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelativeStructureChildInfo relativeStructureChildInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelativeStructureChildInfo();
		relativeStructureChildInfo.ClientId = wire.getClientId();
		relativeStructureChildInfo.CadOccId = wire.getCadOccId();
		relativeStructureChildInfo.Child = (ItemRevision)modelManager.LoadObjectData(wire.getChild());
		relativeStructureChildInfo.OccInfo = toLocal(wire.getOccInfo(), modelManager);
		return relativeStructureChildInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleInfo toWire(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleInfo local)
	{
		Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleInfo revisionRuleInfo = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RevRule == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RevRule.Uid);
		}
		revisionRuleInfo.setRevRule(modelObject);
		revisionRuleInfo.setHasValueStatus(toWireConfigureAttrStatusMap(local.HasValueStatus));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OverrideFolders.Length; i++)
		{
			arrayList.Add(toWire(local.OverrideFolders[i]));
		}
		revisionRuleInfo.setOverrideFolders(arrayList);
		return revisionRuleInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleInfo toLocal(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RevisionRuleInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleInfo revisionRuleInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RevisionRuleInfo();
		revisionRuleInfo.RevRule = (RevisionRule)modelManager.LoadObjectData(wire.getRevRule());
		revisionRuleInfo.HasValueStatus = toLocalConfigureAttrStatusMap(wire.getHasValueStatus(), modelManager);
		IList overrideFolders = wire.getOverrideFolders();
		revisionRuleInfo.OverrideFolders = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OverrideInfo[overrideFolders.Count];
		for (int i = 0; i < overrideFolders.Count; i++)
		{
			revisionRuleInfo.OverrideFolders[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OverrideInfo)overrideFolders[i], modelManager);
		}
		return revisionRuleInfo;
	}

	public static ArrayList toWireClientIdToAbsOccMap(IDictionary ClientIdToAbsOccMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToAbsOccMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToAbsOccMap clientIdToAbsOccMap = new ClientIdToAbsOccMap();
			clientIdToAbsOccMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			clientIdToAbsOccMap.setValue(modelObject);
			arrayList.Add(clientIdToAbsOccMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToAbsOccMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToAbsOccMap clientIdToAbsOccMap = (ClientIdToAbsOccMap)wire[i];
			string key = clientIdToAbsOccMap.getKey();
			AbsOccurrence value = (AbsOccurrence)modelManager.LoadObjectData(clientIdToAbsOccMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireClientIdToAsmArrMap(IDictionary ClientIdToAsmArrMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToAsmArrMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToAsmArrMap clientIdToAsmArrMap = new ClientIdToAsmArrMap();
			clientIdToAsmArrMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			clientIdToAsmArrMap.setValue(modelObject);
			arrayList.Add(clientIdToAsmArrMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToAsmArrMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToAsmArrMap clientIdToAsmArrMap = (ClientIdToAsmArrMap)wire[i];
			string key = clientIdToAsmArrMap.getKey();
			AssemblyArrangement value = (AssemblyArrangement)modelManager.LoadObjectData(clientIdToAsmArrMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireClientIdToPSOccurrenceThreadMap(IDictionary ClientIdToPSOccurrenceThreadMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToPSOccurrenceThreadMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToPSOccurrenceThreadMap clientIdToPSOccurrenceThreadMap = new ClientIdToPSOccurrenceThreadMap();
			clientIdToPSOccurrenceThreadMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			clientIdToPSOccurrenceThreadMap.setValue(modelObject);
			arrayList.Add(clientIdToPSOccurrenceThreadMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToPSOccurrenceThreadMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToPSOccurrenceThreadMap clientIdToPSOccurrenceThreadMap = (ClientIdToPSOccurrenceThreadMap)wire[i];
			string key = clientIdToPSOccurrenceThreadMap.getKey();
			PSOccurrenceThread value = (PSOccurrenceThread)modelManager.LoadObjectData(clientIdToPSOccurrenceThreadMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireConfigureAttrStatusMap(IDictionary ConfigureAttrStatusMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ConfigureAttrStatusMap)
		{
			object key = item.Key;
			object value = item.Value;
			ConfigureAttrStatusMap configureAttrStatusMap = new ConfigureAttrStatusMap();
			configureAttrStatusMap.setKey(Convert.ToString(key));
			configureAttrStatusMap.setValue(Convert.ToBoolean(value));
			arrayList.Add(configureAttrStatusMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalConfigureAttrStatusMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ConfigureAttrStatusMap configureAttrStatusMap = (ConfigureAttrStatusMap)wire[i];
			string key = configureAttrStatusMap.getKey();
			bool value = configureAttrStatusMap.Value;
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireItemRevisionToVariantRulesMap(IDictionary ItemRevisionToVariantRulesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ItemRevisionToVariantRulesMap)
		{
			object key = item.Key;
			object value = item.Value;
			ItemRevisionToVariantRulesMap itemRevisionToVariantRulesMap = new ItemRevisionToVariantRulesMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			itemRevisionToVariantRulesMap.setKey(modelObject);
			IList value2 = itemRevisionToVariantRulesMap.getValue();
			VariantRule[] array = (VariantRule[])value;
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
			itemRevisionToVariantRulesMap.setValue((ArrayList)value2);
			arrayList.Add(itemRevisionToVariantRulesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalItemRevisionToVariantRulesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ItemRevisionToVariantRulesMap itemRevisionToVariantRulesMap = (ItemRevisionToVariantRulesMap)wire[i];
			ItemRevision key = (ItemRevision)modelManager.LoadObjectData(itemRevisionToVariantRulesMap.getKey());
			IList value = itemRevisionToVariantRulesMap.getValue();
			VariantRule[] array = new VariantRule[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (VariantRule)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)value[j]);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CloseBOMWindowsResponse CloseBOMWindows(BOMWindow[] BomWindows)
	{
		try
		{
			restSender.PushRequestId();
			CloseBOMWindowsInput closeBOMWindowsInput = new CloseBOMWindowsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < BomWindows.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (BomWindows[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(BomWindows[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			closeBOMWindowsInput.setBomWindows(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CloseBOMWindowsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "CloseBOMWindows", closeBOMWindowsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CloseBOMWindowsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CloseBOMWindowsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CloseBOMWindowsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse CreateBOMWindows(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			CreateBOMWindowsInput createBOMWindowsInput = new CreateBOMWindowsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createBOMWindowsInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "CreateBOMWindows", createBOMWindowsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of tc2007, use the createOrUpdateAbsoluteStructure operation from the  207_12 namespace.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse CreateOrUpdateAbsoluteStructure(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureInfo[] Info, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructurePref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureInput createOrUpdateAbsoluteStructureInput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdateAbsoluteStructureInput.setInfo(arrayList);
			createOrUpdateAbsoluteStructureInput.setBomViewTypeName(BomViewTypeName);
			createOrUpdateAbsoluteStructureInput.setComplete(Complete);
			createOrUpdateAbsoluteStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "CreateOrUpdateAbsoluteStructure", createOrUpdateAbsoluteStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of tc2007, use the createOrUpdateRelativeStructure operation from the 2007_12 namespace.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureInfo[] Inputs, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructurePref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureInput createOrUpdateRelativeStructureInput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createOrUpdateRelativeStructureInput.setInputs(arrayList);
			createOrUpdateRelativeStructureInput.setBomViewTypeName(BomViewTypeName);
			createOrUpdateRelativeStructureInput.setComplete(Complete);
			createOrUpdateRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "CreateOrUpdateRelativeStructure", createOrUpdateRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of tc2007, use the deleteAssemblyArrangements operation from the 2007_12 namespace.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse DeleteAssemblyArrangements(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsInfo[] Info, string BomViewTypeName)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsInput deleteAssemblyArrangementsInput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			deleteAssemblyArrangementsInput.setInfo(arrayList);
			deleteAssemblyArrangementsInput.setBomViewTypeName(BomViewTypeName);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "DeleteAssemblyArrangements", deleteAssemblyArrangementsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of tc2007, use the deleteRelativeStructure operation from the 2007_12 namespace.", false)]
	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse DeleteRelativeStructure(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureInfo[] Inputs, string BomViewTypeName, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructurePref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureInput deleteRelativeStructureInput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			deleteRelativeStructureInput.setInputs(arrayList);
			deleteRelativeStructureInput.setBomViewTypeName(BomViewTypeName);
			deleteRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "DeleteRelativeStructure", deleteRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsResponse ExpandPSAllLevels(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsInfo Input, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsInput expandPSAllLevelsInput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsInput();
			expandPSAllLevelsInput.setInput(toWire(Input));
			expandPSAllLevelsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "ExpandPSAllLevels", expandPSAllLevelsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSAllLevelsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSAllLevelsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelResponse ExpandPSOneLevel(Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelInfo Input, Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelInput expandPSOneLevelInput = new Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelInput();
			expandPSOneLevelInput.setInput(toWire(Input));
			expandPSOneLevelInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "ExpandPSOneLevel", expandPSOneLevelInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.ExpandPSOneLevelResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.ExpandPSOneLevelResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetRevisionRulesResponse GetRevisionRules()
	{
		try
		{
			restSender.PushRequestId();
			GetRevisionRulesInput requestObject = new GetRevisionRulesInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetRevisionRulesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "GetRevisionRules", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetRevisionRulesResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetRevisionRulesResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetRevisionRulesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetVariantRulesResponse GetVariantRules(ItemRevision[] ItemRevs)
	{
		try
		{
			restSender.PushRequestId();
			GetVariantRulesInput getVariantRulesInput = new GetVariantRulesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ItemRevs.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (ItemRevs[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(ItemRevs[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getVariantRulesInput.setItemRevs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetVariantRulesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200701_PORT_NAME, "GetVariantRules", getVariantRulesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetVariantRulesResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.GetVariantRulesResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.GetVariantRulesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.ClassicOptionInfo toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.ClassicOptionInfo local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.ClassicOptionInfo classicOptionInfo = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.ClassicOptionInfo();
		classicOptionInfo.setOptionName(local.OptionName);
		classicOptionInfo.setOptionDesc(local.OptionDesc);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		classicOptionInfo.setValues(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ExistingValues.Length; i++)
		{
			arrayList2.Add(local.ExistingValues[i]);
		}
		classicOptionInfo.setExistingValues(arrayList2);
		return classicOptionInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.ClassicOptionInfo toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.ClassicOptionInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.ClassicOptionInfo classicOptionInfo = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.ClassicOptionInfo();
		classicOptionInfo.OptionName = wire.getOptionName();
		classicOptionInfo.OptionDesc = wire.getOptionDesc();
		IList values = wire.getValues();
		classicOptionInfo.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			classicOptionInfo.Values[i] = Convert.ToString(values[i]);
		}
		IList existingValues = wire.getExistingValues();
		classicOptionInfo.ExistingValues = new string[existingValues.Count];
		for (int i = 0; i < existingValues.Count; i++)
		{
			classicOptionInfo.ExistingValues[i] = Convert.ToString(existingValues[i]);
		}
		return classicOptionInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateOrUpdateVariantCondInput toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateOrUpdateVariantCondInput local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateOrUpdateVariantCondInput createOrUpdateVariantCondInput = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateOrUpdateVariantCondInput();
		createOrUpdateVariantCondInput.setClientId(local.ClientId);
		createOrUpdateVariantCondInput.setOperation(local.Operation);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		createOrUpdateVariantCondInput.setBomLine(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.VariantCondInfo.Length; i++)
		{
			arrayList.Add(toWire(local.VariantCondInfo[i]));
		}
		createOrUpdateVariantCondInput.setVariantCondInfo(arrayList);
		return createOrUpdateVariantCondInput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateOrUpdateVariantCondInput toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateOrUpdateVariantCondInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateOrUpdateVariantCondInput createOrUpdateVariantCondInput = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateOrUpdateVariantCondInput();
		createOrUpdateVariantCondInput.ClientId = wire.getClientId();
		createOrUpdateVariantCondInput.Operation = wire.getOperation();
		createOrUpdateVariantCondInput.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		IList variantCondInfo = wire.getVariantCondInfo();
		createOrUpdateVariantCondInput.VariantCondInfo = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.VariantCondInfo[variantCondInfo.Count];
		for (int i = 0; i < variantCondInfo.Count; i++)
		{
			createOrUpdateVariantCondInput.VariantCondInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_06.Structuremanagement.VariantCondInfo)variantCondInfo[i], modelManager);
		}
		return createOrUpdateVariantCondInput;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateUpdateClassicOptionsInput toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateUpdateClassicOptionsInput local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateUpdateClassicOptionsInput createUpdateClassicOptionsInput = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateUpdateClassicOptionsInput();
		createUpdateClassicOptionsInput.setClientId(local.ClientId);
		createUpdateClassicOptionsInput.setOperation(local.Operation);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		createUpdateClassicOptionsInput.setBomLine(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Options.Length; i++)
		{
			arrayList.Add(toWire(local.Options[i]));
		}
		createUpdateClassicOptionsInput.setOptions(arrayList);
		return createUpdateClassicOptionsInput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateUpdateClassicOptionsInput toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.CreateUpdateClassicOptionsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateUpdateClassicOptionsInput createUpdateClassicOptionsInput = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateUpdateClassicOptionsInput();
		createUpdateClassicOptionsInput.ClientId = wire.getClientId();
		createUpdateClassicOptionsInput.Operation = wire.getOperation();
		createUpdateClassicOptionsInput.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		IList options = wire.getOptions();
		createUpdateClassicOptionsInput.Options = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.ClassicOptionInfo[options.Count];
		for (int i = 0; i < options.Count; i++)
		{
			createUpdateClassicOptionsInput.Options[i] = toLocal((Teamcenter.Schemas.Cad._2007_06.Structuremanagement.ClassicOptionInfo)options[i], modelManager);
		}
		return createUpdateClassicOptionsInput;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DelClassicOptionsInput toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DelClassicOptionsInput local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DelClassicOptionsInput delClassicOptionsInput = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DelClassicOptionsInput();
		delClassicOptionsInput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		delClassicOptionsInput.setBomLine(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OptionNames.Length; i++)
		{
			arrayList.Add(local.OptionNames[i]);
		}
		delClassicOptionsInput.setOptionNames(arrayList);
		return delClassicOptionsInput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DelClassicOptionsInput toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DelClassicOptionsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DelClassicOptionsInput delClassicOptionsInput = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DelClassicOptionsInput();
		delClassicOptionsInput.ClientId = wire.getClientId();
		delClassicOptionsInput.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		IList optionNames = wire.getOptionNames();
		delClassicOptionsInput.OptionNames = new string[optionNames.Count];
		for (int i = 0; i < optionNames.Count; i++)
		{
			delClassicOptionsInput.OptionNames[i] = Convert.ToString(optionNames[i]);
		}
		return delClassicOptionsInput;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DeleteVariantCondInput toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DeleteVariantCondInput local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DeleteVariantCondInput deleteVariantCondInput = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DeleteVariantCondInput();
		deleteVariantCondInput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		deleteVariantCondInput.setBomLine(modelObject);
		return deleteVariantCondInput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DeleteVariantCondInput toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.DeleteVariantCondInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DeleteVariantCondInput deleteVariantCondInput = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DeleteVariantCondInput();
		deleteVariantCondInput.ClientId = wire.getClientId();
		deleteVariantCondInput.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		return deleteVariantCondInput;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionInfo toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionInfo local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionInfo getConfiguredItemRevisionInfo = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		getConfiguredItemRevisionInfo.setObject(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RevRule == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.RevRule.Uid);
		}
		getConfiguredItemRevisionInfo.setRevRule(modelObject2);
		return getConfiguredItemRevisionInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionInfo toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionInfo getConfiguredItemRevisionInfo = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionInfo();
		getConfiguredItemRevisionInfo.Object = modelManager.LoadObjectData(wire.getObject());
		getConfiguredItemRevisionInfo.RevRule = (RevisionRule)modelManager.LoadObjectData(wire.getRevRule());
		return getConfiguredItemRevisionInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionOutput toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionOutput local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionOutput getConfiguredItemRevisionOutput = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionOutput();
		getConfiguredItemRevisionOutput.setInputInfo(toWire(local.InputInfo));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ConfiguredItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ConfiguredItemRev.Uid);
		}
		getConfiguredItemRevisionOutput.setConfiguredItemRev(modelObject);
		return getConfiguredItemRevisionOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionOutput toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionOutput getConfiguredItemRevisionOutput = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionOutput();
		getConfiguredItemRevisionOutput.InputInfo = toLocal(wire.getInputInfo(), modelManager);
		getConfiguredItemRevisionOutput.ConfiguredItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getConfiguredItemRev());
		return getConfiguredItemRevisionOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionResponse toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionResponse getConfiguredItemRevisionResponse = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionResponse();
		getConfiguredItemRevisionResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getConfiguredItemRevisionResponse.Output = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getConfiguredItemRevisionResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionOutput)output[i], modelManager);
		}
		return getConfiguredItemRevisionResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_06.Structuremanagement.VariantCondInfo toWire(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.VariantCondInfo local)
	{
		Teamcenter.Schemas.Cad._2007_06.Structuremanagement.VariantCondInfo variantCondInfo = new Teamcenter.Schemas.Cad._2007_06.Structuremanagement.VariantCondInfo();
		variantCondInfo.setOptionName(local.OptionName);
		variantCondInfo.setJoinOperator(local.JoinOperator);
		variantCondInfo.setCompOperator(local.CompOperator);
		variantCondInfo.setValue(local.Value);
		return variantCondInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.VariantCondInfo toLocal(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.VariantCondInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.VariantCondInfo variantCondInfo = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.VariantCondInfo();
		variantCondInfo.OptionName = wire.getOptionName();
		variantCondInfo.JoinOperator = wire.getJoinOperator();
		variantCondInfo.CompOperator = wire.getCompOperator();
		variantCondInfo.Value = wire.getValue();
		return variantCondInfo;
	}

	public override Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionResponse GetConfiguredItemRevision(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetConfiguredItemRevisionInput getConfiguredItemRevisionInput = new GetConfiguredItemRevisionInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getConfiguredItemRevisionInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200706_PORT_NAME, "GetConfiguredItemRevision", getConfiguredItemRevisionInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionResponse wire = (Teamcenter.Schemas.Cad._2007_06.Structuremanagement.GetConfiguredItemRevisionResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.GetConfiguredItemRevisionResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData CreateOrUpdateClassicOptions(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateUpdateClassicOptionsInput[] InputObjects)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateClassicOptionsInput createOrUpdateClassicOptionsInput = new CreateOrUpdateClassicOptionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputObjects.Length; i++)
			{
				arrayList.Add(toWire(InputObjects[i]));
			}
			createOrUpdateClassicOptionsInput.setInputObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200706_PORT_NAME, "CreateOrUpdateClassicOptions", createOrUpdateClassicOptionsInput, typeFromHandle, extraTypes);
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

	[Obsolete("As of tc2007.1, use  the createOrUpdateVariantConditions2 operation.", false)]
	public override Teamcenter.Soa.Client.Model.ServiceData CreateOrUpdateVariantConditions(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.CreateOrUpdateVariantCondInput[] InputObjects)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateVariantConditionsInput createOrUpdateVariantConditionsInput = new CreateOrUpdateVariantConditionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputObjects.Length; i++)
			{
				arrayList.Add(toWire(InputObjects[i]));
			}
			createOrUpdateVariantConditionsInput.setInputObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200706_PORT_NAME, "CreateOrUpdateVariantConditions", createOrUpdateVariantConditionsInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Soa.Client.Model.ServiceData DeleteClassicOptions(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DelClassicOptionsInput[] InputObjects)
	{
		try
		{
			restSender.PushRequestId();
			DeleteClassicOptionsInput deleteClassicOptionsInput = new DeleteClassicOptionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputObjects.Length; i++)
			{
				arrayList.Add(toWire(InputObjects[i]));
			}
			deleteClassicOptionsInput.setInputObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200706_PORT_NAME, "DeleteClassicOptions", deleteClassicOptionsInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Soa.Client.Model.ServiceData DeleteVariantConditions(Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.DeleteVariantCondInput[] InputObjects)
	{
		try
		{
			restSender.PushRequestId();
			DeleteVariantConditionsInput deleteVariantConditionsInput = new DeleteVariantConditionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputObjects.Length; i++)
			{
				arrayList.Add(toWire(InputObjects[i]));
			}
			deleteVariantConditionsInput.setInputObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200706_PORT_NAME, "DeleteVariantConditions", deleteVariantConditionsInput, typeFromHandle, extraTypes);
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

	public static Teamcenter.Schemas.Cad._2007_09.Structuremanagement.CreateOrUpdateVariantCondInput toWire(Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.CreateOrUpdateVariantCondInput local)
	{
		Teamcenter.Schemas.Cad._2007_09.Structuremanagement.CreateOrUpdateVariantCondInput createOrUpdateVariantCondInput = new Teamcenter.Schemas.Cad._2007_09.Structuremanagement.CreateOrUpdateVariantCondInput();
		createOrUpdateVariantCondInput.setClientId(local.ClientId);
		createOrUpdateVariantCondInput.setOperation(local.Operation);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		createOrUpdateVariantCondInput.setBomLine(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.VariantCondInfo.Length; i++)
		{
			arrayList.Add(toWire(local.VariantCondInfo[i]));
		}
		createOrUpdateVariantCondInput.setVariantCondInfo(arrayList);
		return createOrUpdateVariantCondInput;
	}

	public static Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.CreateOrUpdateVariantCondInput toLocal(Teamcenter.Schemas.Cad._2007_09.Structuremanagement.CreateOrUpdateVariantCondInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.CreateOrUpdateVariantCondInput createOrUpdateVariantCondInput = new Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.CreateOrUpdateVariantCondInput();
		createOrUpdateVariantCondInput.ClientId = wire.getClientId();
		createOrUpdateVariantCondInput.Operation = wire.getOperation();
		createOrUpdateVariantCondInput.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		IList variantCondInfo = wire.getVariantCondInfo();
		createOrUpdateVariantCondInput.VariantCondInfo = new Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.VariantCondInfo[variantCondInfo.Count];
		for (int i = 0; i < variantCondInfo.Count; i++)
		{
			createOrUpdateVariantCondInput.VariantCondInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_09.Structuremanagement.VariantCondInfo)variantCondInfo[i], modelManager);
		}
		return createOrUpdateVariantCondInput;
	}

	public static Teamcenter.Schemas.Cad._2007_09.Structuremanagement.VariantCondInfo toWire(Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.VariantCondInfo local)
	{
		Teamcenter.Schemas.Cad._2007_09.Structuremanagement.VariantCondInfo variantCondInfo = new Teamcenter.Schemas.Cad._2007_09.Structuremanagement.VariantCondInfo();
		variantCondInfo.setOptionName(local.OptionName);
		variantCondInfo.setItemId(local.ItemId);
		variantCondInfo.setJoinOperator(local.JoinOperator);
		variantCondInfo.setCompOperator(local.CompOperator);
		variantCondInfo.setValue(local.Value);
		return variantCondInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.VariantCondInfo toLocal(Teamcenter.Schemas.Cad._2007_09.Structuremanagement.VariantCondInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.VariantCondInfo variantCondInfo = new Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.VariantCondInfo();
		variantCondInfo.OptionName = wire.getOptionName();
		variantCondInfo.ItemId = wire.getItemId();
		variantCondInfo.JoinOperator = wire.getJoinOperator();
		variantCondInfo.CompOperator = wire.getCompOperator();
		variantCondInfo.Value = wire.getValue();
		return variantCondInfo;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData CreateOrUpdateVariantConditions2(Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.CreateOrUpdateVariantCondInput[] InputObjects)
	{
		try
		{
			restSender.PushRequestId();
			CreateOrUpdateVariantConditions2Input createOrUpdateVariantConditions2Input = new CreateOrUpdateVariantConditions2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputObjects.Length; i++)
			{
				arrayList.Add(toWire(InputObjects[i]));
			}
			createOrUpdateVariantConditions2Input.setInputObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200709_PORT_NAME, "CreateOrUpdateVariantConditions2", createOrUpdateVariantConditions2Input, typeFromHandle, extraTypes);
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

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.BomLineVariantCondition toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.BomLineVariantCondition local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.BomLineVariantCondition bomLineVariantCondition = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.BomLineVariantCondition();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		bomLineVariantCondition.setBomLine(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ConditionClauses.Length; i++)
		{
			arrayList.Add(toWire(local.ConditionClauses[i]));
		}
		bomLineVariantCondition.setConditionClauses(arrayList);
		return bomLineVariantCondition;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.BomLineVariantCondition toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.BomLineVariantCondition wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.BomLineVariantCondition bomLineVariantCondition = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.BomLineVariantCondition();
		bomLineVariantCondition.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		IList conditionClauses = wire.getConditionClauses();
		bomLineVariantCondition.ConditionClauses = new Teamcenter.Services.Strong.Cad._2007_09.StructureManagement.VariantCondInfo[conditionClauses.Count];
		for (int i = 0; i < conditionClauses.Count; i++)
		{
			bomLineVariantCondition.ConditionClauses[i] = toLocal((Teamcenter.Schemas.Cad._2007_09.Structuremanagement.VariantCondInfo)conditionClauses[i], modelManager);
		}
		return bomLineVariantCondition;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionData toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionData local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionData classicOptionData = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRevision == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRevision.Uid);
		}
		classicOptionData.setItemRevision(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OptionData.Length; i++)
		{
			arrayList.Add(toWire(local.OptionData[i]));
		}
		classicOptionData.setOptionData(arrayList);
		return classicOptionData;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionData toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionData classicOptionData = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionData();
		classicOptionData.ItemRevision = (ItemRevision)modelManager.LoadObjectData(wire.getItemRevision());
		IList optionData = wire.getOptionData();
		classicOptionData.OptionData = new Teamcenter.Services.Strong.Cad._2007_06.StructureManagement.ClassicOptionInfo[optionData.Count];
		for (int i = 0; i < optionData.Count; i++)
		{
			classicOptionData.OptionData[i] = toLocal((Teamcenter.Schemas.Cad._2007_06.Structuremanagement.ClassicOptionInfo)optionData[i], modelManager);
		}
		return classicOptionData;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionsResponse toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionsResponse classicOptionsResponse = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionsResponse();
		classicOptionsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList itemRevisionOptionData = wire.getItemRevisionOptionData();
		classicOptionsResponse.ItemRevisionOptionData = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionData[itemRevisionOptionData.Count];
		for (int i = 0; i < itemRevisionOptionData.Count; i++)
		{
			classicOptionsResponse.ItemRevisionOptionData[i] = toLocal((Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionData)itemRevisionOptionData[i], modelManager);
		}
		return classicOptionsResponse;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructureInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo2 createOrUpdateAbsoluteStructureInfo = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo2();
		createOrUpdateAbsoluteStructureInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ContextItemRev.Uid);
		}
		createOrUpdateAbsoluteStructureInfo.setContextItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BvrAbsOccInfo.Length; i++)
		{
			arrayList.Add(toWire(local.BvrAbsOccInfo[i]));
		}
		createOrUpdateAbsoluteStructureInfo.setBvrAbsOccInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ArrAbsOccInfo.Length; i++)
		{
			arrayList2.Add(toWire(local.ArrAbsOccInfo[i]));
		}
		createOrUpdateAbsoluteStructureInfo.setArrAbsOccInfo(arrayList2);
		return createOrUpdateAbsoluteStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructureInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructureInfo2 createOrUpdateAbsoluteStructureInfo = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructureInfo2();
		createOrUpdateAbsoluteStructureInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		createOrUpdateAbsoluteStructureInfo.ContextItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getContextItemRev());
		IList bvrAbsOccInfo = wire.getBvrAbsOccInfo();
		createOrUpdateAbsoluteStructureInfo.BvrAbsOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AbsOccInfo[bvrAbsOccInfo.Count];
		for (int i = 0; i < bvrAbsOccInfo.Count; i++)
		{
			createOrUpdateAbsoluteStructureInfo.BvrAbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AbsOccInfo)bvrAbsOccInfo[i], modelManager);
		}
		IList arrAbsOccInfo = wire.getArrAbsOccInfo();
		createOrUpdateAbsoluteStructureInfo.ArrAbsOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo[arrAbsOccInfo.Count];
		for (int i = 0; i < arrAbsOccInfo.Count; i++)
		{
			createOrUpdateAbsoluteStructureInfo.ArrAbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo)arrAbsOccInfo[i], modelManager);
		}
		return createOrUpdateAbsoluteStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructurePref2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructurePref2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructurePref2 createOrUpdateAbsoluteStructurePref = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructurePref2();
		createOrUpdateAbsoluteStructurePref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		createOrUpdateAbsoluteStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		return createOrUpdateAbsoluteStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructurePref2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructurePref2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructurePref2 createOrUpdateAbsoluteStructurePref = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructurePref2();
		createOrUpdateAbsoluteStructurePref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		createOrUpdateAbsoluteStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		return createOrUpdateAbsoluteStructurePref;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructureInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructureInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructureInfo2 createOrUpdateRelativeStructureInfo = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructureInfo2();
		createOrUpdateRelativeStructureInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		createOrUpdateRelativeStructureInfo.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ChildInfo[i]));
		}
		createOrUpdateRelativeStructureInfo.setChildInfo(arrayList);
		createOrUpdateRelativeStructureInfo.setPrecise(local.Precise);
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructureInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructureInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructureInfo2 createOrUpdateRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructureInfo2();
		createOrUpdateRelativeStructureInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		createOrUpdateRelativeStructureInfo.Parent = (ItemRevision)modelManager.LoadObjectData(wire.getParent());
		IList childInfo = wire.getChildInfo();
		createOrUpdateRelativeStructureInfo.ChildInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelativeStructureChildInfo[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			createOrUpdateRelativeStructureInfo.ChildInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelativeStructureChildInfo)childInfo[i], modelManager);
		}
		createOrUpdateRelativeStructureInfo.Precise = wire.Precise;
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructurePref2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructurePref2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructurePref2 createOrUpdateRelativeStructurePref = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructurePref2();
		createOrUpdateRelativeStructurePref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		createOrUpdateRelativeStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ItemTypes.Length; i++)
		{
			arrayList.Add(local.ItemTypes[i]);
		}
		createOrUpdateRelativeStructurePref.setItemTypes(arrayList);
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructurePref2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructurePref2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructurePref2 createOrUpdateRelativeStructurePref = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructurePref2();
		createOrUpdateRelativeStructurePref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		createOrUpdateRelativeStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		IList itemTypes = wire.getItemTypes();
		createOrUpdateRelativeStructurePref.ItemTypes = new string[itemTypes.Count];
		for (int i = 0; i < itemTypes.Count; i++)
		{
			createOrUpdateRelativeStructurePref.ItemTypes[i] = Convert.ToString(itemTypes[i]);
		}
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsInfo2 deleteAssemblyArrangementsInfo = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsInfo2();
		deleteAssemblyArrangementsInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ItemRev.Uid);
		}
		deleteAssemblyArrangementsInfo.setItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Arrangements.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Arrangements[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Arrangements[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		deleteAssemblyArrangementsInfo.setArrangements(arrayList);
		return deleteAssemblyArrangementsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsInfo2 deleteAssemblyArrangementsInfo = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsInfo2();
		deleteAssemblyArrangementsInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		deleteAssemblyArrangementsInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		IList arrangements = wire.getArrangements();
		deleteAssemblyArrangementsInfo.Arrangements = new AssemblyArrangement[arrangements.Count];
		for (int i = 0; i < arrangements.Count; i++)
		{
			deleteAssemblyArrangementsInfo.Arrangements[i] = (AssemblyArrangement)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)arrangements[i]);
		}
		return deleteAssemblyArrangementsInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsPref toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsPref local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsPref deleteAssemblyArrangementsPref = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsPref();
		deleteAssemblyArrangementsPref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		return deleteAssemblyArrangementsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsPref toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsPref deleteAssemblyArrangementsPref = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsPref();
		deleteAssemblyArrangementsPref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		return deleteAssemblyArrangementsPref;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructureInfo2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructureInfo2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructureInfo2 deleteRelativeStructureInfo = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructureInfo2();
		deleteRelativeStructureInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		deleteRelativeStructureInfo.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(local.ChildInfo[i]);
		}
		deleteRelativeStructureInfo.setChildInfo(arrayList);
		return deleteRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructureInfo2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructureInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructureInfo2 deleteRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructureInfo2();
		deleteRelativeStructureInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		deleteRelativeStructureInfo.Parent = (ItemRevision)modelManager.LoadObjectData(wire.getParent());
		IList childInfo = wire.getChildInfo();
		deleteRelativeStructureInfo.ChildInfo = new string[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			deleteRelativeStructureInfo.ChildInfo[i] = Convert.ToString(childInfo[i]);
		}
		return deleteRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructurePref2 toWire(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructurePref2 local)
	{
		Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructurePref2 deleteRelativeStructurePref = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructurePref2();
		deleteRelativeStructurePref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		deleteRelativeStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		return deleteRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructurePref2 toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructurePref2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructurePref2 deleteRelativeStructurePref = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructurePref2();
		deleteRelativeStructurePref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		deleteRelativeStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		return deleteRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.VariantConditionResponse toLocal(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.VariantConditionResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.VariantConditionResponse variantConditionResponse = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.VariantConditionResponse();
		variantConditionResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList variantConditions = wire.getVariantConditions();
		variantConditionResponse.VariantConditions = new Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.BomLineVariantCondition[variantConditions.Count];
		for (int i = 0; i < variantConditions.Count; i++)
		{
			variantConditionResponse.VariantConditions[i] = toLocal((Teamcenter.Schemas.Cad._2007_12.Structuremanagement.BomLineVariantCondition)variantConditions[i], modelManager);
		}
		return variantConditionResponse;
	}

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse CreateOrUpdateAbsoluteStructure(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructureInfo2[] Info, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateAbsoluteStructurePref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructureInput createOrUpdateAbsoluteStructureInput = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateAbsoluteStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createOrUpdateAbsoluteStructureInput.setInfo(arrayList);
			createOrUpdateAbsoluteStructureInput.setBomViewTypeName(BomViewTypeName);
			createOrUpdateAbsoluteStructureInput.setComplete(Complete);
			createOrUpdateAbsoluteStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200712_PORT_NAME, "CreateOrUpdateAbsoluteStructure", createOrUpdateAbsoluteStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateAbsoluteStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructureInfo2[] Inputs, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.CreateOrUpdateRelativeStructurePref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructureInput createOrUpdateRelativeStructureInput = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.CreateOrUpdateRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createOrUpdateRelativeStructureInput.setInputs(arrayList);
			createOrUpdateRelativeStructureInput.setBomViewTypeName(BomViewTypeName);
			createOrUpdateRelativeStructureInput.setComplete(Complete);
			createOrUpdateRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200712_PORT_NAME, "CreateOrUpdateRelativeStructure", createOrUpdateRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse DeleteAssemblyArrangements(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsInfo2[] Info, string BomViewTypeName, Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteAssemblyArrangementsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsInput deleteAssemblyArrangementsInput = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteAssemblyArrangementsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			deleteAssemblyArrangementsInput.setInfo(arrayList);
			deleteAssemblyArrangementsInput.setBomViewTypeName(BomViewTypeName);
			deleteAssemblyArrangementsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200712_PORT_NAME, "DeleteAssemblyArrangements", deleteAssemblyArrangementsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteAssemblyArrangementsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteAssemblyArrangementsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse DeleteRelativeStructure(Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructureInfo2[] Inputs, string BomViewTypeName, Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructurePref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructureInput deleteRelativeStructureInput = new Teamcenter.Schemas.Cad._2007_12.Structuremanagement.DeleteRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			deleteRelativeStructureInput.setInputs(arrayList);
			deleteRelativeStructureInput.setBomViewTypeName(BomViewTypeName);
			deleteRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200712_PORT_NAME, "DeleteRelativeStructure", deleteRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionsResponse QueryClassicOptions(ItemRevision[] InputRevisions)
	{
		try
		{
			restSender.PushRequestId();
			QueryClassicOptionsInput queryClassicOptionsInput = new QueryClassicOptionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputRevisions.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (InputRevisions[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(InputRevisions[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			queryClassicOptionsInput.setInputRevisions(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200712_PORT_NAME, "QueryClassicOptions", queryClassicOptionsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionsResponse wire = (Teamcenter.Schemas.Cad._2007_12.Structuremanagement.ClassicOptionsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.ClassicOptionsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.VariantConditionResponse QueryVariantConditions(BOMLine[] InputBomLines)
	{
		try
		{
			restSender.PushRequestId();
			QueryVariantConditionsInput queryVariantConditionsInput = new QueryVariantConditionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputBomLines.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (InputBomLines[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(InputBomLines[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			queryVariantConditionsInput.setInputBomLines(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_12.Structuremanagement.VariantConditionResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200712_PORT_NAME, "QueryVariantConditions", queryVariantConditionsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_12.Structuremanagement.VariantConditionResponse wire = (Teamcenter.Schemas.Cad._2007_12.Structuremanagement.VariantConditionResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.VariantConditionResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesInfo toWire(Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesInfo local)
	{
		Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesInfo askChildPathBOMLinesInfo = new Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesInfo();
		askChildPathBOMLinesInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ParentBomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ParentBomLine.Uid);
		}
		askChildPathBOMLinesInfo.setParentBomLine(modelObject);
		askChildPathBOMLinesInfo.setUseAsStable(local.UseAsStable);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildPaths.Length; i++)
		{
			arrayList.Add(toWire(local.ChildPaths[i]));
		}
		askChildPathBOMLinesInfo.setChildPaths(arrayList);
		return askChildPathBOMLinesInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesInfo toLocal(Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesInfo askChildPathBOMLinesInfo = new Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesInfo();
		askChildPathBOMLinesInfo.ClientId = wire.getClientId();
		askChildPathBOMLinesInfo.ParentBomLine = (BOMLine)modelManager.LoadObjectData(wire.getParentBomLine());
		askChildPathBOMLinesInfo.UseAsStable = wire.UseAsStable;
		IList childPaths = wire.getChildPaths();
		askChildPathBOMLinesInfo.ChildPaths = new Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesPath[childPaths.Count];
		for (int i = 0; i < childPaths.Count; i++)
		{
			askChildPathBOMLinesInfo.ChildPaths[i] = toLocal((Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesPath)childPaths[i], modelManager);
		}
		return askChildPathBOMLinesInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesPath toWire(Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesPath local)
	{
		Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesPath askChildPathBOMLinesPath = new Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesPath();
		askChildPathBOMLinesPath.setClientId(local.ClientId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildPath.Length; i++)
		{
			arrayList.Add(local.ChildPath[i]);
		}
		askChildPathBOMLinesPath.setChildPath(arrayList);
		return askChildPathBOMLinesPath;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesPath toLocal(Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesPath wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesPath askChildPathBOMLinesPath = new Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesPath();
		askChildPathBOMLinesPath.ClientId = wire.getClientId();
		IList childPath = wire.getChildPath();
		askChildPathBOMLinesPath.ChildPath = new string[childPath.Count];
		for (int i = 0; i < childPath.Count; i++)
		{
			askChildPathBOMLinesPath.ChildPath[i] = Convert.ToString(childPath[i]);
		}
		return askChildPathBOMLinesPath;
	}

	public static Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesResponse toLocal(Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesResponse askChildPathBOMLinesResponse = new Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesResponse();
		askChildPathBOMLinesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		askChildPathBOMLinesResponse.Output = toLocalAskChildPathBOMLineMap(wire.getOutput(), modelManager);
		return askChildPathBOMLinesResponse;
	}

	public static ArrayList toWireAskChildPathBOMLineMap(IDictionary AskChildPathBOMLineMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in AskChildPathBOMLineMap)
		{
			object key = item.Key;
			object value = item.Value;
			AskChildPathBOMLineMap askChildPathBOMLineMap = new AskChildPathBOMLineMap();
			askChildPathBOMLineMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			askChildPathBOMLineMap.setValue(modelObject);
			arrayList.Add(askChildPathBOMLineMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalAskChildPathBOMLineMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			AskChildPathBOMLineMap askChildPathBOMLineMap = (AskChildPathBOMLineMap)wire[i];
			string key = askChildPathBOMLineMap.getKey();
			BOMLine value = (BOMLine)modelManager.LoadObjectData(askChildPathBOMLineMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	[Obsolete("As of Teamcenter 10.1, the _2013_05 version of askChildPathBOMLine replaces this version.", false)]
	public override Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesResponse AskChildPathBOMLines(Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesInfo[] Input)
	{
		try
		{
			restSender.PushRequestId();
			AskChildPathBOMLinesInput askChildPathBOMLinesInput = new AskChildPathBOMLinesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			askChildPathBOMLinesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200803_PORT_NAME, "AskChildPathBOMLines", askChildPathBOMLinesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesResponse wire = (Teamcenter.Schemas.Cad._2008_03.Structuremanagement.AskChildPathBOMLinesResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccAttachment2 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccAttachment2 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccAttachment2 absOccAttachment = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccAttachment2();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OverrideObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OverrideObject.Uid);
		}
		absOccAttachment.setOverrideObject(modelObject);
		absOccAttachment.setRelationTypeName(local.RelationTypeName);
		return absOccAttachment;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccAttachment2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccAttachment2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccAttachment2 absOccAttachment = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccAttachment2();
		absOccAttachment.OverrideObject = modelManager.LoadObjectData(wire.getOverrideObject());
		absOccAttachment.RelationTypeName = wire.getRelationTypeName();
		return absOccAttachment;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetInfo datasetInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetInfo();
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
		datasetInfo.setCreateNewVersion(local.CreateNewVersion);
		datasetInfo.setNamedReferencePreference(local.NamedReferencePreference);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DataList.Length; i++)
		{
			arrayList.Add(toWire(local.DataList[i]));
		}
		datasetInfo.setDataList(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList2.Add(toWire(local.DatasetFileInfos[i]));
		}
		datasetInfo.setDatasetFileInfos(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.NamedReferenceObjectInfos.Length; i++)
		{
			arrayList3.Add(toWire(local.NamedReferenceObjectInfos[i]));
		}
		datasetInfo.setNamedReferenceObjectInfos(arrayList3);
		return datasetInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetInfo datasetInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetInfo();
		datasetInfo.ClientId = wire.getClientId();
		datasetInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		datasetInfo.Name = wire.getName();
		datasetInfo.BasisName = wire.getBasisName();
		datasetInfo.Description = wire.getDescription();
		datasetInfo.Type = wire.getType();
		datasetInfo.LastModifiedOfDataset = TcServerDate.ToLocal(wire.getLastModifiedOfDataset());
		datasetInfo.Id = wire.getId();
		datasetInfo.DatasetRev = wire.getDatasetRev();
		datasetInfo.CreateNewVersion = wire.CreateNewVersion;
		datasetInfo.NamedReferencePreference = wire.getNamedReferencePreference();
		IList dataList = wire.getDataList();
		datasetInfo.DataList = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct[dataList.Count];
		for (int i = 0; i < dataList.Count; i++)
		{
			datasetInfo.DataList[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct)dataList[i], modelManager);
		}
		IList datasetFileInfos = wire.getDatasetFileInfos();
		datasetInfo.DatasetFileInfos = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			datasetInfo.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		IList namedReferenceObjectInfos = wire.getNamedReferenceObjectInfos();
		datasetInfo.NamedReferenceObjectInfos = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NamedReferenceObjectInfo[namedReferenceObjectInfos.Count];
		for (int i = 0; i < namedReferenceObjectInfos.Count; i++)
		{
			datasetInfo.NamedReferenceObjectInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NamedReferenceObjectInfo)namedReferenceObjectInfos[i], modelManager);
		}
		return datasetInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateDatasetAttachmentInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateDatasetAttachmentInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateDatasetAttachmentInfo absOccCreateDatasetAttachmentInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateDatasetAttachmentInfo();
		absOccCreateDatasetAttachmentInfo.setClientId(local.ClientId);
		absOccCreateDatasetAttachmentInfo.setDatasetInfo(toWire(local.DatasetInfo));
		absOccCreateDatasetAttachmentInfo.setRelationTypeName(local.RelationTypeName);
		absOccCreateDatasetAttachmentInfo.setCreateIfFound(local.CreateIfFound);
		return absOccCreateDatasetAttachmentInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateDatasetAttachmentInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateDatasetAttachmentInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateDatasetAttachmentInfo absOccCreateDatasetAttachmentInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateDatasetAttachmentInfo();
		absOccCreateDatasetAttachmentInfo.ClientId = wire.getClientId();
		absOccCreateDatasetAttachmentInfo.DatasetInfo = toLocal(wire.getDatasetInfo(), modelManager);
		absOccCreateDatasetAttachmentInfo.RelationTypeName = wire.getRelationTypeName();
		absOccCreateDatasetAttachmentInfo.CreateIfFound = wire.CreateIfFound;
		return absOccCreateDatasetAttachmentInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.FormInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.FormInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.FormInfo formInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.FormInfo();
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
		formInfo.setName(local.Name);
		formInfo.setDescription(local.Description);
		formInfo.setFormType(local.FormType);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Attributes.Length; i++)
		{
			arrayList.Add(toWire(local.Attributes[i]));
		}
		formInfo.setAttributes(arrayList);
		return formInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.FormInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.FormInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.FormInfo formInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.FormInfo();
		formInfo.FormObject = (Form)modelManager.LoadObjectData(wire.getFormObject());
		formInfo.Name = wire.getName();
		formInfo.Description = wire.getDescription();
		formInfo.FormType = wire.getFormType();
		IList attributes = wire.getAttributes();
		formInfo.Attributes = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct[attributes.Count];
		for (int i = 0; i < attributes.Count; i++)
		{
			formInfo.Attributes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct)attributes[i], modelManager);
		}
		return formInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateFormAttachmentInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateFormAttachmentInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateFormAttachmentInfo absOccCreateFormAttachmentInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateFormAttachmentInfo();
		absOccCreateFormAttachmentInfo.setClientId(local.ClientId);
		absOccCreateFormAttachmentInfo.setFormInfo(toWire(local.FormInfo));
		absOccCreateFormAttachmentInfo.setRelationTypeName(local.RelationTypeName);
		absOccCreateFormAttachmentInfo.setCreateIfFound(local.CreateIfFound);
		return absOccCreateFormAttachmentInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateFormAttachmentInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateFormAttachmentInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateFormAttachmentInfo absOccCreateFormAttachmentInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateFormAttachmentInfo();
		absOccCreateFormAttachmentInfo.ClientId = wire.getClientId();
		absOccCreateFormAttachmentInfo.FormInfo = toLocal(wire.getFormInfo(), modelManager);
		absOccCreateFormAttachmentInfo.RelationTypeName = wire.getRelationTypeName();
		absOccCreateFormAttachmentInfo.CreateIfFound = wire.CreateIfFound;
		return absOccCreateFormAttachmentInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataGRMExpansionInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataGRMExpansionInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataGRMExpansionInfo absOccDataGRMExpansionInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataGRMExpansionInfo();
		absOccDataGRMExpansionInfo.setRelationName(local.RelationName);
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
		absOccDataGRMExpansionInfo.setObjects(arrayList);
		return absOccDataGRMExpansionInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataGRMExpansionInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataGRMExpansionInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataGRMExpansionInfo absOccDataGRMExpansionInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataGRMExpansionInfo();
		absOccDataGRMExpansionInfo.RelationName = wire.getRelationName();
		IList objects = wire.getObjects();
		absOccDataGRMExpansionInfo.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			absOccDataGRMExpansionInfo.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		return absOccDataGRMExpansionInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataInfo2 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataInfo2 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataInfo2 absOccDataInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataInfo2();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OverridesToSet.Length; i++)
		{
			arrayList.Add(toWire(local.OverridesToSet[i]));
		}
		absOccDataInfo.setOverridesToSet(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.OverridesToRemove.Length; i++)
		{
			arrayList2.Add(local.OverridesToRemove[i]);
		}
		absOccDataInfo.setOverridesToRemove(arrayList2);
		absOccDataInfo.setAsRequired(local.AsRequired);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.OccTransform.Length; i++)
		{
			arrayList3.Add(local.OccTransform[i]);
		}
		absOccDataInfo.setOccTransform(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.OccNotes.Length; i++)
		{
			arrayList4.Add(toWire(local.OccNotes[i]));
		}
		absOccDataInfo.setOccNotes(arrayList4);
		ArrayList arrayList5 = new ArrayList();
		for (int i = 0; i < local.Attachments.Length; i++)
		{
			arrayList5.Add(toWire(local.Attachments[i]));
		}
		absOccDataInfo.setAttachments(arrayList5);
		ArrayList arrayList6 = new ArrayList();
		for (int i = 0; i < local.AttachmentsToUnattach.Length; i++)
		{
			arrayList6.Add(toWire(local.AttachmentsToUnattach[i]));
		}
		absOccDataInfo.setAttachmentsToUnattach(arrayList6);
		ArrayList arrayList7 = new ArrayList();
		for (int i = 0; i < local.DatasetAttachments.Length; i++)
		{
			arrayList7.Add(toWire(local.DatasetAttachments[i]));
		}
		absOccDataInfo.setDatasetAttachments(arrayList7);
		ArrayList arrayList8 = new ArrayList();
		for (int i = 0; i < local.FormAttachments.Length; i++)
		{
			arrayList8.Add(toWire(local.FormAttachments[i]));
		}
		absOccDataInfo.setFormAttachments(arrayList8);
		absOccDataInfo.setClientIdOfUsedArrangement(local.ClientIdOfUsedArrangement);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.UsedArr == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.UsedArr.Uid);
		}
		absOccDataInfo.setUsedArr(modelObject);
		ArrayList arrayList9 = new ArrayList();
		for (int i = 0; i < local.BoundingBoxInfo.Length; i++)
		{
			arrayList9.Add(toWire(local.BoundingBoxInfo[i]));
		}
		absOccDataInfo.setBoundingBoxInfo(arrayList9);
		return absOccDataInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataInfo2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataInfo2 absOccDataInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataInfo2();
		IList overridesToSet = wire.getOverridesToSet();
		absOccDataInfo.OverridesToSet = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo[overridesToSet.Count];
		for (int i = 0; i < overridesToSet.Count; i++)
		{
			absOccDataInfo.OverridesToSet[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo)overridesToSet[i], modelManager);
		}
		IList overridesToRemove = wire.getOverridesToRemove();
		absOccDataInfo.OverridesToRemove = new string[overridesToRemove.Count];
		for (int i = 0; i < overridesToRemove.Count; i++)
		{
			absOccDataInfo.OverridesToRemove[i] = Convert.ToString(overridesToRemove[i]);
		}
		absOccDataInfo.AsRequired = wire.AsRequired;
		IList occTransform = wire.getOccTransform();
		absOccDataInfo.OccTransform = new double[occTransform.Count];
		for (int i = 0; i < occTransform.Count; i++)
		{
			absOccDataInfo.OccTransform[i] = Convert.ToDouble(occTransform[i]);
		}
		IList occNotes = wire.getOccNotes();
		absOccDataInfo.OccNotes = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote[occNotes.Count];
		for (int i = 0; i < occNotes.Count; i++)
		{
			absOccDataInfo.OccNotes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote)occNotes[i], modelManager);
		}
		IList attachments = wire.getAttachments();
		absOccDataInfo.Attachments = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccAttachment2[attachments.Count];
		for (int i = 0; i < attachments.Count; i++)
		{
			absOccDataInfo.Attachments[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccAttachment2)attachments[i], modelManager);
		}
		IList attachmentsToUnattach = wire.getAttachmentsToUnattach();
		absOccDataInfo.AttachmentsToUnattach = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccAttachment2[attachmentsToUnattach.Count];
		for (int i = 0; i < attachmentsToUnattach.Count; i++)
		{
			absOccDataInfo.AttachmentsToUnattach[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccAttachment2)attachmentsToUnattach[i], modelManager);
		}
		IList datasetAttachments = wire.getDatasetAttachments();
		absOccDataInfo.DatasetAttachments = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateDatasetAttachmentInfo[datasetAttachments.Count];
		for (int i = 0; i < datasetAttachments.Count; i++)
		{
			absOccDataInfo.DatasetAttachments[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateDatasetAttachmentInfo)datasetAttachments[i], modelManager);
		}
		IList formAttachments = wire.getFormAttachments();
		absOccDataInfo.FormAttachments = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccCreateFormAttachmentInfo[formAttachments.Count];
		for (int i = 0; i < formAttachments.Count; i++)
		{
			absOccDataInfo.FormAttachments[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccCreateFormAttachmentInfo)formAttachments[i], modelManager);
		}
		absOccDataInfo.ClientIdOfUsedArrangement = wire.getClientIdOfUsedArrangement();
		absOccDataInfo.UsedArr = (AssemblyArrangement)modelManager.LoadObjectData(wire.getUsedArr());
		IList boundingBoxInfo = wire.getBoundingBoxInfo();
		absOccDataInfo.BoundingBoxInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBoxInfo[boundingBoxInfo.Count];
		for (int i = 0; i < boundingBoxInfo.Count; i++)
		{
			absOccDataInfo.BoundingBoxInfo[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBoxInfo)boundingBoxInfo[i], modelManager);
		}
		return absOccDataInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataPref toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataPref local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataPref absOccDataPref = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataPref();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelationFilterInfos.Length; i++)
		{
			arrayList.Add(toWire(local.RelationFilterInfos[i]));
		}
		absOccDataPref.setRelationFilterInfos(arrayList);
		absOccDataPref.setQualifierFilter(local.QualifierFilter);
		return absOccDataPref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataPref toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataPref absOccDataPref = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataPref();
		IList relationFilterInfos = wire.getRelationFilterInfos();
		absOccDataPref.RelationFilterInfos = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter[relationFilterInfos.Count];
		for (int i = 0; i < relationFilterInfos.Count; i++)
		{
			absOccDataPref.RelationFilterInfos[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter)relationFilterInfos[i], modelManager);
		}
		absOccDataPref.QualifierFilter = wire.getQualifierFilter();
		return absOccDataPref;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccInfo2 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccInfo2 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccInfo2 absOccInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccInfo2();
		absOccInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.AbsOcc == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.AbsOcc.Uid);
		}
		absOccInfo.setAbsOcc(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.CadOccIdPath.Length; i++)
		{
			arrayList.Add(local.CadOccIdPath[i]);
		}
		absOccInfo.setCadOccIdPath(arrayList);
		absOccInfo.setAbsOccData(toWire(local.AbsOccData));
		return absOccInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccInfo2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccInfo2 absOccInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccInfo2();
		absOccInfo.ClientId = wire.getClientId();
		absOccInfo.AbsOcc = (AbsOccurrence)modelManager.LoadObjectData(wire.getAbsOcc());
		IList cadOccIdPath = wire.getCadOccIdPath();
		absOccInfo.CadOccIdPath = new string[cadOccIdPath.Count];
		for (int i = 0; i < cadOccIdPath.Count; i++)
		{
			absOccInfo.CadOccIdPath[i] = Convert.ToString(cadOccIdPath[i]);
		}
		absOccInfo.AbsOccData = toLocal(wire.getAbsOccData(), modelManager);
		return absOccInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccQualifierInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccQualifierInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccQualifierInfo absOccQualifierInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccQualifierInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.QualifyingBVR == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.QualifyingBVR.Uid);
		}
		absOccQualifierInfo.setQualifyingBVR(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.UpperQualifier == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.UpperQualifier.Uid);
		}
		absOccQualifierInfo.setUpperQualifier(modelObject2);
		return absOccQualifierInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccQualifierInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccQualifierInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccQualifierInfo absOccQualifierInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccQualifierInfo();
		absOccQualifierInfo.QualifyingBVR = (PSBOMViewRevision)modelManager.LoadObjectData(wire.getQualifyingBVR());
		absOccQualifierInfo.UpperQualifier = modelManager.LoadObjectData(wire.getUpperQualifier());
		return absOccQualifierInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DataOverrideInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DataOverrideInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DataOverrideInfo dataOverrideInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DataOverrideInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OverrideData == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OverrideData.Uid);
		}
		dataOverrideInfo.setOverrideData(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ExpandedOverrides.Length; i++)
		{
			arrayList.Add(toWire(local.ExpandedOverrides[i]));
		}
		dataOverrideInfo.setExpandedOverrides(arrayList);
		return dataOverrideInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DataOverrideInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DataOverrideInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DataOverrideInfo dataOverrideInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DataOverrideInfo();
		dataOverrideInfo.OverrideData = (AbsOccData)modelManager.LoadObjectData(wire.getOverrideData());
		IList expandedOverrides = wire.getExpandedOverrides();
		dataOverrideInfo.ExpandedOverrides = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataGRMExpansionInfo[expandedOverrides.Count];
		for (int i = 0; i < expandedOverrides.Count; i++)
		{
			dataOverrideInfo.ExpandedOverrides[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccDataGRMExpansionInfo)expandedOverrides[i], modelManager);
		}
		return dataOverrideInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccStructureDataInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccStructureDataInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccStructureDataInfo absOccStructureDataInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccStructureDataInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OccThreadPaths.Length; i++)
		{
			arrayList.Add(toWire(local.OccThreadPaths[i]));
		}
		absOccStructureDataInfo.setOccThreadPaths(arrayList);
		absOccStructureDataInfo.setDataOverrideInfo(toWire(local.DataOverrideInfo));
		return absOccStructureDataInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccStructureDataInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccStructureDataInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccStructureDataInfo absOccStructureDataInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccStructureDataInfo();
		IList occThreadPaths = wire.getOccThreadPaths();
		absOccStructureDataInfo.OccThreadPaths = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ApnToThreadPathStruct[occThreadPaths.Count];
		for (int i = 0; i < occThreadPaths.Count; i++)
		{
			absOccStructureDataInfo.OccThreadPaths[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ApnToThreadPathStruct)occThreadPaths[i], modelManager);
		}
		absOccStructureDataInfo.DataOverrideInfo = toLocal(wire.getDataOverrideInfo(), modelManager);
		return absOccStructureDataInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ApnToThreadPathStruct toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ApnToThreadPathStruct local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ApnToThreadPathStruct apnToThreadPathStruct = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ApnToThreadPathStruct();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Apn == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Apn.Uid);
		}
		apnToThreadPathStruct.setApn(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OccThreadPath.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.OccThreadPath[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.OccThreadPath[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		apnToThreadPathStruct.setOccThreadPath(arrayList);
		return apnToThreadPathStruct;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ApnToThreadPathStruct toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ApnToThreadPathStruct wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ApnToThreadPathStruct apnToThreadPathStruct = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ApnToThreadPathStruct();
		apnToThreadPathStruct.Apn = (MEAppearancePathNode)modelManager.LoadObjectData(wire.getApn());
		IList occThreadPath = wire.getOccThreadPath();
		apnToThreadPathStruct.OccThreadPath = new PSOccurrenceThread[occThreadPath.Count];
		for (int i = 0; i < occThreadPath.Count; i++)
		{
			apnToThreadPathStruct.OccThreadPath[i] = (PSOccurrenceThread)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)occThreadPath[i]);
		}
		return apnToThreadPathStruct;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBox toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBox local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBox boundingBox = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBox();
		boundingBox.setXmin(local.Xmin);
		boundingBox.setYmin(local.Ymin);
		boundingBox.setZmin(local.Zmin);
		boundingBox.setXmax(local.Xmax);
		boundingBox.setYmax(local.Ymax);
		boundingBox.setZmax(local.Zmax);
		return boundingBox;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBox toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBox wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBox boundingBox = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBox();
		boundingBox.Xmin = Convert.ToDouble(wire.getXmin());
		boundingBox.Ymin = Convert.ToDouble(wire.getYmin());
		boundingBox.Zmin = Convert.ToDouble(wire.getZmin());
		boundingBox.Xmax = Convert.ToDouble(wire.getXmax());
		boundingBox.Ymax = Convert.ToDouble(wire.getYmax());
		boundingBox.Zmax = Convert.ToDouble(wire.getZmax());
		return boundingBox;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBoxInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBoxInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBoxInfo boundingBoxInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBoxInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		boundingBoxInfo.setDataset(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BoundingBoxVector.Length; i++)
		{
			arrayList.Add(toWire(local.BoundingBoxVector[i]));
		}
		boundingBoxInfo.setBoundingBoxVector(arrayList);
		return boundingBoxInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBoxInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBoxInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBoxInfo boundingBoxInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBoxInfo();
		boundingBoxInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList boundingBoxVector = wire.getBoundingBoxVector();
		boundingBoxInfo.BoundingBoxVector = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBox[boundingBoxVector.Count];
		for (int i = 0; i < boundingBoxVector.Count; i++)
		{
			boundingBoxInfo.BoundingBoxVector[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBox)boundingBoxVector[i], modelManager);
		}
		return boundingBoxInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CommitDatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CommitDatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CommitDatasetFileInfo();
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

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CommitDatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CommitDatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CommitDatasetFileInfo();
		commitDatasetFileInfo.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		commitDatasetFileInfo.CreateNewVersion = wire.CreateNewVersion;
		IList datasetFileTicketInfos = wire.getDatasetFileTicketInfos();
		commitDatasetFileInfo.DatasetFileTicketInfos = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileTicketInfo[datasetFileTicketInfos.Count];
		for (int i = 0; i < datasetFileTicketInfos.Count; i++)
		{
			commitDatasetFileInfo.DatasetFileTicketInfos[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileTicketInfo)datasetFileTicketInfos[i], modelManager);
		}
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo3 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureInfo3 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo3 createOrUpdateAbsoluteStructureInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo3();
		createOrUpdateAbsoluteStructureInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ContextItemRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ContextItemRev.Uid);
		}
		createOrUpdateAbsoluteStructureInfo.setContextItemRev(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.BvrAbsOccInfo.Length; i++)
		{
			arrayList.Add(toWire(local.BvrAbsOccInfo[i]));
		}
		createOrUpdateAbsoluteStructureInfo.setBvrAbsOccInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ArrAbsOccInfo.Length; i++)
		{
			arrayList2.Add(toWire(local.ArrAbsOccInfo[i]));
		}
		createOrUpdateAbsoluteStructureInfo.setArrAbsOccInfo(arrayList2);
		return createOrUpdateAbsoluteStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureInfo3 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureInfo3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureInfo3 createOrUpdateAbsoluteStructureInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureInfo3();
		createOrUpdateAbsoluteStructureInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		createOrUpdateAbsoluteStructureInfo.ContextItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getContextItemRev());
		IList bvrAbsOccInfo = wire.getBvrAbsOccInfo();
		createOrUpdateAbsoluteStructureInfo.BvrAbsOccInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccInfo2[bvrAbsOccInfo.Count];
		for (int i = 0; i < bvrAbsOccInfo.Count; i++)
		{
			createOrUpdateAbsoluteStructureInfo.BvrAbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccInfo2)bvrAbsOccInfo[i], modelManager);
		}
		IList arrAbsOccInfo = wire.getArrAbsOccInfo();
		createOrUpdateAbsoluteStructureInfo.ArrAbsOccInfo = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AssemblyArrangementInfo[arrAbsOccInfo.Count];
		for (int i = 0; i < arrAbsOccInfo.Count; i++)
		{
			createOrUpdateAbsoluteStructureInfo.ArrAbsOccInfo[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AssemblyArrangementInfo)arrAbsOccInfo[i], modelManager);
		}
		return createOrUpdateAbsoluteStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructurePref3 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructurePref3 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructurePref3 createOrUpdateAbsoluteStructurePref = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructurePref3();
		createOrUpdateAbsoluteStructurePref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OverridesToSynchronize.Length; i++)
		{
			arrayList.Add(local.OverridesToSynchronize[i]);
		}
		createOrUpdateAbsoluteStructurePref.setOverridesToSynchronize(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.RelationFilters.Length; i++)
		{
			arrayList2.Add(toWire(local.RelationFilters[i]));
		}
		createOrUpdateAbsoluteStructurePref.setRelationFilters(arrayList2);
		createOrUpdateAbsoluteStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		return createOrUpdateAbsoluteStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructurePref3 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructurePref3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructurePref3 createOrUpdateAbsoluteStructurePref = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructurePref3();
		createOrUpdateAbsoluteStructurePref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		IList overridesToSynchronize = wire.getOverridesToSynchronize();
		createOrUpdateAbsoluteStructurePref.OverridesToSynchronize = new string[overridesToSynchronize.Count];
		for (int i = 0; i < overridesToSynchronize.Count; i++)
		{
			createOrUpdateAbsoluteStructurePref.OverridesToSynchronize[i] = Convert.ToString(overridesToSynchronize[i]);
		}
		IList relationFilters = wire.getRelationFilters();
		createOrUpdateAbsoluteStructurePref.RelationFilters = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.RelationAndTypesFilter[relationFilters.Count];
		for (int i = 0; i < relationFilters.Count; i++)
		{
			createOrUpdateAbsoluteStructurePref.RelationFilters[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.RelationAndTypesFilter)relationFilters[i], modelManager);
		}
		createOrUpdateAbsoluteStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		return createOrUpdateAbsoluteStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureResponse2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureResponse2 createOrUpdateAbsoluteStructureResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureResponse2();
		createOrUpdateAbsoluteStructureResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		createOrUpdateAbsoluteStructureResponse.AbsOccOutput = toLocalClientIdToAbsOccMap2(wire.getAbsOccOutput(), modelManager);
		createOrUpdateAbsoluteStructureResponse.AsmArrangementOutput = toLocalClientIdToAsmArrangementMap(wire.getAsmArrangementOutput(), modelManager);
		createOrUpdateAbsoluteStructureResponse.FormOutput = toLocalClientIdToFormMap(wire.getFormOutput(), modelManager);
		IList datasetOutput = wire.getDatasetOutput();
		createOrUpdateAbsoluteStructureResponse.DatasetOutput = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetOutput[datasetOutput.Count];
		for (int i = 0; i < datasetOutput.Count; i++)
		{
			createOrUpdateAbsoluteStructureResponse.DatasetOutput[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetOutput)datasetOutput[i], modelManager);
		}
		return createOrUpdateAbsoluteStructureResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructureInfo3 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructureInfo3 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructureInfo3 createOrUpdateRelativeStructureInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructureInfo3();
		createOrUpdateRelativeStructureInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		createOrUpdateRelativeStructureInfo.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ChildInfo[i]));
		}
		createOrUpdateRelativeStructureInfo.setChildInfo(arrayList);
		createOrUpdateRelativeStructureInfo.setPrecise(local.Precise);
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructureInfo3 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructureInfo3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructureInfo3 createOrUpdateRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructureInfo3();
		createOrUpdateRelativeStructureInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		createOrUpdateRelativeStructureInfo.Parent = modelManager.LoadObjectData(wire.getParent());
		IList childInfo = wire.getChildInfo();
		createOrUpdateRelativeStructureInfo.ChildInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelativeStructureChildInfo2[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			createOrUpdateRelativeStructureInfo.ChildInfo[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelativeStructureChildInfo2)childInfo[i], modelManager);
		}
		createOrUpdateRelativeStructureInfo.Precise = wire.Precise;
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructurePref3 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructurePref3 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructurePref3 createOrUpdateRelativeStructurePref = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructurePref3();
		createOrUpdateRelativeStructurePref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		createOrUpdateRelativeStructurePref.setContinueOnError(local.ContinueOnError);
		createOrUpdateRelativeStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectTypes.Length; i++)
		{
			arrayList.Add(local.ObjectTypes[i]);
		}
		createOrUpdateRelativeStructurePref.setObjectTypes(arrayList);
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructurePref3 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructurePref3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructurePref3 createOrUpdateRelativeStructurePref = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructurePref3();
		createOrUpdateRelativeStructurePref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		createOrUpdateRelativeStructurePref.ContinueOnError = wire.ContinueOnError;
		createOrUpdateRelativeStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		IList objectTypes = wire.getObjectTypes();
		createOrUpdateRelativeStructurePref.ObjectTypes = new string[objectTypes.Count];
		for (int i = 0; i < objectTypes.Count; i++)
		{
			createOrUpdateRelativeStructurePref.ObjectTypes[i] = Convert.ToString(objectTypes[i]);
		}
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesInfo createVariantRulesInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesInfo();
		createVariantRulesInfo.setClientID(local.ClientID);
		createVariantRulesInfo.setVruleName(local.VruleName);
		createVariantRulesInfo.setVruleDescription(local.VruleDescription);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Rev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Rev.Uid);
		}
		createVariantRulesInfo.setRev(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Parent.Uid);
		}
		createVariantRulesInfo.setParent(modelObject2);
		createVariantRulesInfo.setRelation(local.Relation);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Options.Length; i++)
		{
			arrayList.Add(toWire(local.Options[i]));
		}
		createVariantRulesInfo.setOptions(arrayList);
		return createVariantRulesInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesInfo createVariantRulesInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesInfo();
		createVariantRulesInfo.ClientID = wire.getClientID();
		createVariantRulesInfo.VruleName = wire.getVruleName();
		createVariantRulesInfo.VruleDescription = wire.getVruleDescription();
		createVariantRulesInfo.Rev = (ItemRevision)modelManager.LoadObjectData(wire.getRev());
		createVariantRulesInfo.Parent = modelManager.LoadObjectData(wire.getParent());
		createVariantRulesInfo.Relation = wire.getRelation();
		IList options = wire.getOptions();
		createVariantRulesInfo.Options = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.OptionsInfo[options.Count];
		for (int i = 0; i < options.Count; i++)
		{
			createVariantRulesInfo.Options[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.OptionsInfo)options[i], modelManager);
		}
		return createVariantRulesInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesResponse toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesResponse createVariantRulesResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesResponse();
		createVariantRulesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		createVariantRulesResponse.Output = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.VariantRulesOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			createVariantRulesResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.VariantRulesOutput)output[i], modelManager);
		}
		return createVariantRulesResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileInfo();
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

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileInfo();
		datasetFileInfo.ClientId = wire.getClientId();
		datasetFileInfo.FileName = wire.getFileName();
		datasetFileInfo.NamedReferencedName = wire.getNamedReferencedName();
		datasetFileInfo.IsText = wire.IsText;
		datasetFileInfo.AllowReplace = wire.AllowReplace;
		datasetFileInfo.BoundingBoxesAvailable = wire.BoundingBoxesAvailable;
		IList boundingBoxes = wire.getBoundingBoxes();
		datasetFileInfo.BoundingBoxes = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.BoundingBox[boundingBoxes.Count];
		for (int i = 0; i < boundingBoxes.Count; i++)
		{
			datasetFileInfo.BoundingBoxes[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.BoundingBox)boundingBoxes[i], modelManager);
		}
		return datasetFileInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileTicketInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileTicketInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.setDatasetFileInfo(toWire(local.DatasetFileInfo));
		datasetFileTicketInfo.setTicket(local.Ticket);
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileTicketInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetFileTicketInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.DatasetFileInfo = toLocal(wire.getDatasetFileInfo(), modelManager);
		datasetFileTicketInfo.Ticket = wire.getTicket();
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetOutput datasetOutput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetOutput();
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

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DatasetOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetOutput datasetOutput = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DatasetOutput();
		datasetOutput.ClientId = wire.getClientId();
		datasetOutput.Dataset = (Dataset)modelManager.LoadObjectData(wire.getDataset());
		IList commitInfo = wire.getCommitInfo();
		datasetOutput.CommitInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CommitDatasetFileInfo[commitInfo.Count];
		for (int i = 0; i < commitInfo.Count; i++)
		{
			datasetOutput.CommitInfo[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CommitDatasetFileInfo)commitInfo[i], modelManager);
		}
		return datasetOutput;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DeleteRelativeStructureInfo3 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DeleteRelativeStructureInfo3 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DeleteRelativeStructureInfo3 deleteRelativeStructureInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DeleteRelativeStructureInfo3();
		deleteRelativeStructureInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		deleteRelativeStructureInfo.setParent(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(local.ChildInfo[i]);
		}
		deleteRelativeStructureInfo.setChildInfo(arrayList);
		return deleteRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DeleteRelativeStructureInfo3 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DeleteRelativeStructureInfo3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DeleteRelativeStructureInfo3 deleteRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DeleteRelativeStructureInfo3();
		deleteRelativeStructureInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		deleteRelativeStructureInfo.Parent = modelManager.LoadObjectData(wire.getParent());
		IList childInfo = wire.getChildInfo();
		deleteRelativeStructureInfo.ChildInfo = new string[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			deleteRelativeStructureInfo.ChildInfo[i] = Convert.ToString(childInfo[i]);
		}
		return deleteRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsInfo expandPSAllLevelsInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParentBomLines.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ParentBomLines[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.ParentBomLines[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		expandPSAllLevelsInfo.setParentBomLines(arrayList);
		expandPSAllLevelsInfo.setExcludeFilter(local.ExcludeFilter);
		return expandPSAllLevelsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsInfo expandPSAllLevelsInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsInfo();
		IList parentBomLines = wire.getParentBomLines();
		expandPSAllLevelsInfo.ParentBomLines = new BOMLine[parentBomLines.Count];
		for (int i = 0; i < parentBomLines.Count; i++)
		{
			expandPSAllLevelsInfo.ParentBomLines[i] = (BOMLine)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)parentBomLines[i]);
		}
		expandPSAllLevelsInfo.ExcludeFilter = wire.getExcludeFilter();
		return expandPSAllLevelsInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSParentData toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSParentData local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSParentData expandPSParentData = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSParentData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		expandPSParentData.setBomLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectOfBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ObjectOfBOMLine.Uid);
		}
		expandPSParentData.setObjectOfBOMLine(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParentRelatedObjects.Length; i++)
		{
			arrayList.Add(toWire(local.ParentRelatedObjects[i]));
		}
		expandPSParentData.setParentRelatedObjects(arrayList);
		return expandPSParentData;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSParentData toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSParentData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSParentData expandPSParentData = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSParentData();
		expandPSParentData.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		expandPSParentData.ObjectOfBOMLine = modelManager.LoadObjectData(wire.getObjectOfBOMLine());
		IList parentRelatedObjects = wire.getParentRelatedObjects();
		expandPSParentData.ParentRelatedObjects = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSRelatedObjectInfo[parentRelatedObjects.Count];
		for (int i = 0; i < parentRelatedObjects.Count; i++)
		{
			expandPSParentData.ParentRelatedObjects[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSRelatedObjectInfo)parentRelatedObjects[i], modelManager);
		}
		return expandPSParentData;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsOutput expandPSAllLevelsOutput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsOutput();
		expandPSAllLevelsOutput.setParent(toWire(local.Parent));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			arrayList.Add(toWire(local.Children[i]));
		}
		expandPSAllLevelsOutput.setChildren(arrayList);
		return expandPSAllLevelsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsOutput expandPSAllLevelsOutput = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsOutput();
		expandPSAllLevelsOutput.Parent = toLocal(wire.getParent(), modelManager);
		IList children = wire.getChildren();
		expandPSAllLevelsOutput.Children = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSData[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			expandPSAllLevelsOutput.Children[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSData)children[i], modelManager);
		}
		return expandPSAllLevelsOutput;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsPref toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsPref local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsPref expandPSAllLevelsPref = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsPref();
		expandPSAllLevelsPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandPSAllLevelsPref.setInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.IncludeOccurrenceTypes.Length; i++)
		{
			arrayList2.Add(local.IncludeOccurrenceTypes[i]);
		}
		expandPSAllLevelsPref.setIncludeOccurrenceTypes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExcludeOccurrenceTypes.Length; i++)
		{
			arrayList3.Add(local.ExcludeOccurrenceTypes[i]);
		}
		expandPSAllLevelsPref.setExcludeOccurrenceTypes(arrayList3);
		return expandPSAllLevelsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsPref toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsPref expandPSAllLevelsPref = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsPref();
		expandPSAllLevelsPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandPSAllLevelsPref.Info = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelationAndTypesFilter[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandPSAllLevelsPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelationAndTypesFilter)info[i], modelManager);
		}
		IList includeOccurrenceTypes = wire.getIncludeOccurrenceTypes();
		expandPSAllLevelsPref.IncludeOccurrenceTypes = new string[includeOccurrenceTypes.Count];
		for (int i = 0; i < includeOccurrenceTypes.Count; i++)
		{
			expandPSAllLevelsPref.IncludeOccurrenceTypes[i] = Convert.ToString(includeOccurrenceTypes[i]);
		}
		IList excludeOccurrenceTypes = wire.getExcludeOccurrenceTypes();
		expandPSAllLevelsPref.ExcludeOccurrenceTypes = new string[excludeOccurrenceTypes.Count];
		for (int i = 0; i < excludeOccurrenceTypes.Count; i++)
		{
			expandPSAllLevelsPref.ExcludeOccurrenceTypes[i] = Convert.ToString(excludeOccurrenceTypes[i]);
		}
		return expandPSAllLevelsPref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsResponse2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsResponse2 expandPSAllLevelsResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsResponse2();
		expandPSAllLevelsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandPSAllLevelsResponse.Output = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandPSAllLevelsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsOutput)output[i], modelManager);
		}
		return expandPSAllLevelsResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSData toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSData local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSData expandPSData = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomLine == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomLine.Uid);
		}
		expandPSData.setBomLine(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectOfBOMLine == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ObjectOfBOMLine.Uid);
		}
		expandPSData.setObjectOfBOMLine(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelatedObjects.Length; i++)
		{
			arrayList.Add(toWire(local.RelatedObjects[i]));
		}
		expandPSData.setRelatedObjects(arrayList);
		return expandPSData;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSData toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSData expandPSData = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSData();
		expandPSData.BomLine = (BOMLine)modelManager.LoadObjectData(wire.getBomLine());
		expandPSData.ObjectOfBOMLine = modelManager.LoadObjectData(wire.getObjectOfBOMLine());
		IList relatedObjects = wire.getRelatedObjects();
		expandPSData.RelatedObjects = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSRelatedObjectInfo[relatedObjects.Count];
		for (int i = 0; i < relatedObjects.Count; i++)
		{
			expandPSData.RelatedObjects[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSRelatedObjectInfo)relatedObjects[i], modelManager);
		}
		return expandPSData;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSNamedReferenceInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSNamedReferenceInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSNamedReferenceInfo expandPSNamedReferenceInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSNamedReferenceInfo();
		expandPSNamedReferenceInfo.setNamedReferenceType(local.NamedReferenceType);
		expandPSNamedReferenceInfo.setNamedReferenceName(local.NamedReferenceName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ReferenceObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ReferenceObject.Uid);
		}
		expandPSNamedReferenceInfo.setReferenceObject(modelObject);
		expandPSNamedReferenceInfo.setFileTicket(local.FileTicket);
		return expandPSNamedReferenceInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSNamedReferenceInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSNamedReferenceInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSNamedReferenceInfo expandPSNamedReferenceInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSNamedReferenceInfo();
		expandPSNamedReferenceInfo.NamedReferenceType = wire.getNamedReferenceType();
		expandPSNamedReferenceInfo.NamedReferenceName = wire.getNamedReferenceName();
		expandPSNamedReferenceInfo.ReferenceObject = modelManager.LoadObjectData(wire.getReferenceObject());
		expandPSNamedReferenceInfo.FileTicket = wire.getFileTicket();
		return expandPSNamedReferenceInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelInfo expandPSOneLevelInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ParentBomLines.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ParentBomLines[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.ParentBomLines[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		expandPSOneLevelInfo.setParentBomLines(arrayList);
		expandPSOneLevelInfo.setExcludeFilter(local.ExcludeFilter);
		return expandPSOneLevelInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelInfo expandPSOneLevelInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelInfo();
		IList parentBomLines = wire.getParentBomLines();
		expandPSOneLevelInfo.ParentBomLines = new BOMLine[parentBomLines.Count];
		for (int i = 0; i < parentBomLines.Count; i++)
		{
			expandPSOneLevelInfo.ParentBomLines[i] = (BOMLine)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)parentBomLines[i]);
		}
		expandPSOneLevelInfo.ExcludeFilter = wire.getExcludeFilter();
		return expandPSOneLevelInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelOutput expandPSOneLevelOutput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelOutput();
		expandPSOneLevelOutput.setParent(toWire(local.Parent));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Children.Length; i++)
		{
			arrayList.Add(toWire(local.Children[i]));
		}
		expandPSOneLevelOutput.setChildren(arrayList);
		return expandPSOneLevelOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelOutput expandPSOneLevelOutput = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelOutput();
		expandPSOneLevelOutput.Parent = toLocal(wire.getParent(), modelManager);
		IList children = wire.getChildren();
		expandPSOneLevelOutput.Children = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSData[children.Count];
		for (int i = 0; i < children.Count; i++)
		{
			expandPSOneLevelOutput.Children[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSData)children[i], modelManager);
		}
		return expandPSOneLevelOutput;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelPref toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelPref local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelPref expandPSOneLevelPref = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelPref();
		expandPSOneLevelPref.setExpItemRev(local.ExpItemRev);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Info.Length; i++)
		{
			arrayList.Add(toWire(local.Info[i]));
		}
		expandPSOneLevelPref.setInfo(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.IncludeOccurrenceTypes.Length; i++)
		{
			arrayList2.Add(local.IncludeOccurrenceTypes[i]);
		}
		expandPSOneLevelPref.setIncludeOccurrenceTypes(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ExcludeOccurrenceTypes.Length; i++)
		{
			arrayList3.Add(local.ExcludeOccurrenceTypes[i]);
		}
		expandPSOneLevelPref.setExcludeOccurrenceTypes(arrayList3);
		return expandPSOneLevelPref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelPref toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelPref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelPref expandPSOneLevelPref = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelPref();
		expandPSOneLevelPref.ExpItemRev = wire.ExpItemRev;
		IList info = wire.getInfo();
		expandPSOneLevelPref.Info = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelationAndTypesFilter[info.Count];
		for (int i = 0; i < info.Count; i++)
		{
			expandPSOneLevelPref.Info[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelationAndTypesFilter)info[i], modelManager);
		}
		IList includeOccurrenceTypes = wire.getIncludeOccurrenceTypes();
		expandPSOneLevelPref.IncludeOccurrenceTypes = new string[includeOccurrenceTypes.Count];
		for (int i = 0; i < includeOccurrenceTypes.Count; i++)
		{
			expandPSOneLevelPref.IncludeOccurrenceTypes[i] = Convert.ToString(includeOccurrenceTypes[i]);
		}
		IList excludeOccurrenceTypes = wire.getExcludeOccurrenceTypes();
		expandPSOneLevelPref.ExcludeOccurrenceTypes = new string[excludeOccurrenceTypes.Count];
		for (int i = 0; i < excludeOccurrenceTypes.Count; i++)
		{
			expandPSOneLevelPref.ExcludeOccurrenceTypes[i] = Convert.ToString(excludeOccurrenceTypes[i]);
		}
		return expandPSOneLevelPref;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelResponse2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelResponse2 expandPSOneLevelResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelResponse2();
		expandPSOneLevelResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		expandPSOneLevelResponse.Output = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			expandPSOneLevelResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelOutput)output[i], modelManager);
		}
		return expandPSOneLevelResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSRelatedObjectInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSRelatedObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSRelatedObjectInfo expandPSRelatedObjectInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSRelatedObjectInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.RelatedObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.RelatedObject.Uid);
		}
		expandPSRelatedObjectInfo.setRelatedObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.NamedRefList.Length; i++)
		{
			arrayList.Add(toWire(local.NamedRefList[i]));
		}
		expandPSRelatedObjectInfo.setNamedRefList(arrayList);
		return expandPSRelatedObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSRelatedObjectInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSRelatedObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSRelatedObjectInfo expandPSRelatedObjectInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSRelatedObjectInfo();
		expandPSRelatedObjectInfo.RelatedObject = modelManager.LoadObjectData(wire.getRelatedObject());
		IList namedRefList = wire.getNamedRefList();
		expandPSRelatedObjectInfo.NamedRefList = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSNamedReferenceInfo[namedRefList.Count];
		for (int i = 0; i < namedRefList.Count; i++)
		{
			expandPSRelatedObjectInfo.NamedRefList[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSNamedReferenceInfo)namedRefList[i], modelManager);
		}
		return expandPSRelatedObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.GetAbsoluteStructureDataResponse toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.GetAbsoluteStructureDataResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.GetAbsoluteStructureDataResponse getAbsoluteStructureDataResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.GetAbsoluteStructureDataResponse();
		getAbsoluteStructureDataResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList overrides = wire.getOverrides();
		getAbsoluteStructureDataResponse.Overrides = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccStructureDataInfo[overrides.Count];
		for (int i = 0; i < overrides.Count; i++)
		{
			getAbsoluteStructureDataResponse.Overrides[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.AbsOccStructureDataInfo)overrides[i], modelManager);
		}
		return getAbsoluteStructureDataResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NamedReferenceObjectInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NamedReferenceObjectInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NamedReferenceObjectInfo();
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
		for (int i = 0; i < local.DataNameValuePairs.Length; i++)
		{
			arrayList.Add(toWire(local.DataNameValuePairs[i]));
		}
		namedReferenceObjectInfo.setDataNameValuePairs(arrayList);
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NamedReferenceObjectInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NamedReferenceObjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NamedReferenceObjectInfo namedReferenceObjectInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NamedReferenceObjectInfo();
		namedReferenceObjectInfo.ClientId = wire.getClientId();
		namedReferenceObjectInfo.Object = modelManager.LoadObjectData(wire.getObject());
		namedReferenceObjectInfo.NamedReferenceName = wire.getNamedReferenceName();
		namedReferenceObjectInfo.TypeName = wire.getTypeName();
		IList dataNameValuePairs = wire.getDataNameValuePairs();
		namedReferenceObjectInfo.DataNameValuePairs = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct[dataNameValuePairs.Count];
		for (int i = 0; i < dataNameValuePairs.Count; i++)
		{
			namedReferenceObjectInfo.DataNameValuePairs[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct)dataNameValuePairs[i], modelManager);
		}
		return namedReferenceObjectInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct nameValueStruct = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct();
		nameValueStruct.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		nameValueStruct.setValues(arrayList);
		return nameValueStruct;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.NameValueStruct wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct nameValueStruct = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.NameValueStruct();
		nameValueStruct.Name = wire.getName();
		IList values = wire.getValues();
		nameValueStruct.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			nameValueStruct.Values[i] = Convert.ToString(values[i]);
		}
		return nameValueStruct;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.OptionsInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.OptionsInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.OptionsInfo optionsInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.OptionsInfo();
		optionsInfo.setOptionName(local.OptionName);
		optionsInfo.setOptionValue(local.OptionValue);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.AssocRev == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.AssocRev.Uid);
		}
		optionsInfo.setAssocRev(modelObject);
		return optionsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.OptionsInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.OptionsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.OptionsInfo optionsInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.OptionsInfo();
		optionsInfo.OptionName = wire.getOptionName();
		optionsInfo.OptionValue = wire.getOptionValue();
		optionsInfo.AssocRev = (ItemRevision)modelManager.LoadObjectData(wire.getAssocRev());
		return optionsInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsInfo toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsInfo local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsInfo reconfigureBOMWindowsInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsInfo();
		reconfigureBOMWindowsInfo.setClientID(local.ClientID);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomWindow == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomWindow.Uid);
		}
		reconfigureBOMWindowsInfo.setBomWindow(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectForConfigure == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ObjectForConfigure.Uid);
		}
		reconfigureBOMWindowsInfo.setObjectForConfigure(modelObject2);
		reconfigureBOMWindowsInfo.setRevRuleConfigInfo(toWire(local.RevRuleConfigInfo));
		return reconfigureBOMWindowsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsInfo toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsInfo reconfigureBOMWindowsInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsInfo();
		reconfigureBOMWindowsInfo.ClientID = wire.getClientID();
		reconfigureBOMWindowsInfo.BomWindow = (BOMWindow)modelManager.LoadObjectData(wire.getBomWindow());
		reconfigureBOMWindowsInfo.ObjectForConfigure = modelManager.LoadObjectData(wire.getObjectForConfigure());
		reconfigureBOMWindowsInfo.RevRuleConfigInfo = toLocal(wire.getRevRuleConfigInfo(), modelManager);
		return reconfigureBOMWindowsInfo;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsOutput reconfigureBOMWindowsOutput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsOutput();
		reconfigureBOMWindowsOutput.setClientID(local.ClientID);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomWindow == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.BomWindow.Uid);
		}
		reconfigureBOMWindowsOutput.setBomWindow(modelObject);
		return reconfigureBOMWindowsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsOutput reconfigureBOMWindowsOutput = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsOutput();
		reconfigureBOMWindowsOutput.ClientID = wire.getClientID();
		reconfigureBOMWindowsOutput.BomWindow = (BOMWindow)modelManager.LoadObjectData(wire.getBomWindow());
		return reconfigureBOMWindowsOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsResponse toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsResponse reconfigureBOMWindowsResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsResponse();
		reconfigureBOMWindowsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		reconfigureBOMWindowsResponse.Output = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			reconfigureBOMWindowsResponse.Output[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsOutput)output[i], modelManager);
		}
		return reconfigureBOMWindowsResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelatedObjectTypeAndNamedRefs toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelatedObjectTypeAndNamedRefs local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelatedObjectTypeAndNamedRefs relatedObjectTypeAndNamedRefs = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelatedObjectTypeAndNamedRefs();
		relatedObjectTypeAndNamedRefs.setObjectTypeName(local.ObjectTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.NamedReferenceNames.Length; i++)
		{
			arrayList.Add(local.NamedReferenceNames[i]);
		}
		relatedObjectTypeAndNamedRefs.setNamedReferenceNames(arrayList);
		return relatedObjectTypeAndNamedRefs;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelatedObjectTypeAndNamedRefs toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelatedObjectTypeAndNamedRefs wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelatedObjectTypeAndNamedRefs relatedObjectTypeAndNamedRefs = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelatedObjectTypeAndNamedRefs();
		relatedObjectTypeAndNamedRefs.ObjectTypeName = wire.getObjectTypeName();
		IList namedReferenceNames = wire.getNamedReferenceNames();
		relatedObjectTypeAndNamedRefs.NamedReferenceNames = new string[namedReferenceNames.Count];
		for (int i = 0; i < namedReferenceNames.Count; i++)
		{
			relatedObjectTypeAndNamedRefs.NamedReferenceNames[i] = Convert.ToString(namedReferenceNames[i]);
		}
		return relatedObjectTypeAndNamedRefs;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelationAndTypesFilter toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelationAndTypesFilter local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelationAndTypesFilter();
		relationAndTypesFilter.setRelationName(local.RelationName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RelatedObjAndNamedRefs.Length; i++)
		{
			arrayList.Add(toWire(local.RelatedObjAndNamedRefs[i]));
		}
		relationAndTypesFilter.setRelatedObjAndNamedRefs(arrayList);
		relationAndTypesFilter.setNamedRefHandler(local.NamedRefHandler);
		return relationAndTypesFilter;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelationAndTypesFilter toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelationAndTypesFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelationAndTypesFilter();
		relationAndTypesFilter.RelationName = wire.getRelationName();
		IList relatedObjAndNamedRefs = wire.getRelatedObjAndNamedRefs();
		relationAndTypesFilter.RelatedObjAndNamedRefs = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelatedObjectTypeAndNamedRefs[relatedObjAndNamedRefs.Count];
		for (int i = 0; i < relatedObjAndNamedRefs.Count; i++)
		{
			relationAndTypesFilter.RelatedObjAndNamedRefs[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelatedObjectTypeAndNamedRefs)relatedObjAndNamedRefs[i], modelManager);
		}
		relationAndTypesFilter.NamedRefHandler = wire.getNamedRefHandler();
		return relationAndTypesFilter;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelativeStructureChildInfo2 toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelativeStructureChildInfo2 local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelativeStructureChildInfo2 relativeStructureChildInfo = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelativeStructureChildInfo2();
		relativeStructureChildInfo.setClientId(local.ClientId);
		relativeStructureChildInfo.setCadOccId(local.CadOccId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Child == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Child.Uid);
		}
		relativeStructureChildInfo.setChild(modelObject);
		relativeStructureChildInfo.setOccInfo(toWire(local.OccInfo));
		return relativeStructureChildInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelativeStructureChildInfo2 toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelativeStructureChildInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelativeStructureChildInfo2 relativeStructureChildInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelativeStructureChildInfo2();
		relativeStructureChildInfo.ClientId = wire.getClientId();
		relativeStructureChildInfo.CadOccId = wire.getCadOccId();
		relativeStructureChildInfo.Child = modelManager.LoadObjectData(wire.getChild());
		relativeStructureChildInfo.OccInfo = toLocal(wire.getOccInfo(), modelManager);
		return relativeStructureChildInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.SaveBOMWindowsResponse toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.SaveBOMWindowsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.SaveBOMWindowsResponse saveBOMWindowsResponse = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.SaveBOMWindowsResponse();
		saveBOMWindowsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		return saveBOMWindowsResponse;
	}

	public static Teamcenter.Schemas.Cad._2008_06.Structuremanagement.VariantRulesOutput toWire(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.VariantRulesOutput local)
	{
		Teamcenter.Schemas.Cad._2008_06.Structuremanagement.VariantRulesOutput variantRulesOutput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.VariantRulesOutput();
		variantRulesOutput.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Vrule == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Vrule.Uid);
		}
		variantRulesOutput.setVrule(modelObject);
		return variantRulesOutput;
	}

	public static Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.VariantRulesOutput toLocal(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.VariantRulesOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.VariantRulesOutput variantRulesOutput = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.VariantRulesOutput();
		variantRulesOutput.ClientId = wire.getClientId();
		variantRulesOutput.Vrule = (VariantRule)modelManager.LoadObjectData(wire.getVrule());
		return variantRulesOutput;
	}

	public static ArrayList toWireClientIdToAbsOccMap2(IDictionary ClientIdToAbsOccMap2)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToAbsOccMap2)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToAbsOccMap2 clientIdToAbsOccMap = new ClientIdToAbsOccMap2();
			clientIdToAbsOccMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			clientIdToAbsOccMap.setValue(modelObject);
			arrayList.Add(clientIdToAbsOccMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToAbsOccMap2(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToAbsOccMap2 clientIdToAbsOccMap = (ClientIdToAbsOccMap2)wire[i];
			string key = clientIdToAbsOccMap.getKey();
			AbsOccurrence value = (AbsOccurrence)modelManager.LoadObjectData(clientIdToAbsOccMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireClientIdToAsmArrangementMap(IDictionary ClientIdToAsmArrangementMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToAsmArrangementMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToAsmArrangementMap clientIdToAsmArrangementMap = new ClientIdToAsmArrangementMap();
			clientIdToAsmArrangementMap.setKey(Convert.ToString(key));
			IList value2 = clientIdToAsmArrangementMap.getValue();
			AssemblyArrangement[] array = (AssemblyArrangement[])value;
			for (int i = 0; i < array.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (array[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)array[i]).Uid);
				}
				value2.Add(modelObject);
			}
			clientIdToAsmArrangementMap.setValue((ArrayList)value2);
			arrayList.Add(clientIdToAsmArrangementMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToAsmArrangementMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToAsmArrangementMap clientIdToAsmArrangementMap = (ClientIdToAsmArrangementMap)wire[i];
			string key = clientIdToAsmArrangementMap.getKey();
			IList value = clientIdToAsmArrangementMap.getValue();
			AssemblyArrangement[] array = new AssemblyArrangement[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = (AssemblyArrangement)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)value[j]);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireClientIdToFormMap(IDictionary ClientIdToFormMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToFormMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToFormMap clientIdToFormMap = new ClientIdToFormMap();
			clientIdToFormMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			clientIdToFormMap.setValue(modelObject);
			arrayList.Add(clientIdToFormMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToFormMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToFormMap clientIdToFormMap = (ClientIdToFormMap)wire[i];
			string key = clientIdToFormMap.getKey();
			Form value = (Form)modelManager.LoadObjectData(clientIdToFormMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureResponse2 CreateOrUpdateAbsoluteStructure(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureInfo3[] AbsOccInfos, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructurePref3 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureInput createOrUpdateAbsoluteStructureInput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < AbsOccInfos.Length; i++)
			{
				arrayList.Add(toWire(AbsOccInfos[i]));
			}
			createOrUpdateAbsoluteStructureInput.setAbsOccInfos(arrayList);
			createOrUpdateAbsoluteStructureInput.setBomViewTypeName(BomViewTypeName);
			createOrUpdateAbsoluteStructureInput.setComplete(Complete);
			createOrUpdateAbsoluteStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse2);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "CreateOrUpdateAbsoluteStructure", createOrUpdateAbsoluteStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse2 wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateAbsoluteStructureResponse2)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateAbsoluteStructureResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructureInfo3[] Inputs, string BomViewTypeName, bool Complete, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateOrUpdateRelativeStructurePref3 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructureInput createOrUpdateRelativeStructureInput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateOrUpdateRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createOrUpdateRelativeStructureInput.setInputs(arrayList);
			createOrUpdateRelativeStructureInput.setBomViewTypeName(BomViewTypeName);
			createOrUpdateRelativeStructureInput.setComplete(Complete);
			createOrUpdateRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "CreateOrUpdateRelativeStructure", createOrUpdateRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateOrUpdateRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateOrUpdateRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse DeleteRelativeStructure(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.DeleteRelativeStructureInfo3[] Inputs, string BomViewTypeName, Teamcenter.Services.Strong.Cad._2007_12.StructureManagement.DeleteRelativeStructurePref2 Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DeleteRelativeStructureInput deleteRelativeStructureInput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.DeleteRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			deleteRelativeStructureInput.setInputs(arrayList);
			deleteRelativeStructureInput.setBomViewTypeName(BomViewTypeName);
			deleteRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "DeleteRelativeStructure", deleteRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.DeleteRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.DeleteRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsResponse2 ExpandPSAllLevels(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsInfo Info, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsInput expandPSAllLevelsInput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsInput();
			expandPSAllLevelsInput.setInfo(toWire(Info));
			expandPSAllLevelsInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "ExpandPSAllLevels", expandPSAllLevelsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsResponse2 wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSAllLevelsResponse2)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSAllLevelsResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelResponse2 ExpandPSOneLevel(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelInfo Info, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelPref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelInput expandPSOneLevelInput = new Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelInput();
			expandPSOneLevelInput.setInfo(toWire(Info));
			expandPSOneLevelInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "ExpandPSOneLevel", expandPSOneLevelInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelResponse2 wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ExpandPSOneLevelResponse2)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ExpandPSOneLevelResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.GetAbsoluteStructureDataResponse GetAbsoluteStructureData(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccQualifierInfo[] AbsOccDataQualInfos, Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.AbsOccDataPref AbsOccDataPref)
	{
		try
		{
			restSender.PushRequestId();
			GetAbsoluteStructureDataInput getAbsoluteStructureDataInput = new GetAbsoluteStructureDataInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < AbsOccDataQualInfos.Length; i++)
			{
				arrayList.Add(toWire(AbsOccDataQualInfos[i]));
			}
			getAbsoluteStructureDataInput.setAbsOccDataQualInfos(arrayList);
			getAbsoluteStructureDataInput.setAbsOccDataPref(toWire(AbsOccDataPref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.GetAbsoluteStructureDataResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "GetAbsoluteStructureData", getAbsoluteStructureDataInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.GetAbsoluteStructureDataResponse wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.GetAbsoluteStructureDataResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.GetAbsoluteStructureDataResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesResponse CreateVariantRules(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesInfo[] Input)
	{
		try
		{
			restSender.PushRequestId();
			CreateVariantRulesInput createVariantRulesInput = new CreateVariantRulesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			createVariantRulesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "CreateVariantRules", createVariantRulesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesResponse wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.CreateVariantRulesResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.CreateVariantRulesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsResponse ReconfigureBOMWindows(Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsInfo[] Info)
	{
		try
		{
			restSender.PushRequestId();
			ReconfigureBOMWindowsInput reconfigureBOMWindowsInput = new ReconfigureBOMWindowsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			reconfigureBOMWindowsInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "ReconfigureBOMWindows", reconfigureBOMWindowsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsResponse wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.ReconfigureBOMWindowsResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.ReconfigureBOMWindowsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.SaveBOMWindowsResponse SaveBOMWindows(BOMWindow[] BomWindows)
	{
		try
		{
			restSender.PushRequestId();
			SaveBOMWindowsInput saveBOMWindowsInput = new SaveBOMWindowsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < BomWindows.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (BomWindows[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(BomWindows[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			saveBOMWindowsInput.setBomWindows(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2008_06.Structuremanagement.SaveBOMWindowsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200806_PORT_NAME, "SaveBOMWindows", saveBOMWindowsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2008_06.Structuremanagement.SaveBOMWindowsResponse wire = (Teamcenter.Schemas.Cad._2008_06.Structuremanagement.SaveBOMWindowsResponse)obj;
			Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.SaveBOMWindowsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfoForObject toWire(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfoForObject local)
	{
		Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfoForObject attributesInfoForObject = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfoForObject();
		attributesInfoForObject.setTopLineAttrThatRefersToObject(local.TopLineAttrThatRefersToObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrsToSet.Length; i++)
		{
			arrayList.Add(toWire(local.AttrsToSet[i]));
		}
		attributesInfoForObject.setAttrsToSet(arrayList);
		return attributesInfoForObject;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfoForObject toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfoForObject wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfoForObject attributesInfoForObject = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfoForObject();
		attributesInfoForObject.TopLineAttrThatRefersToObject = wire.getTopLineAttrThatRefersToObject();
		IList attrsToSet = wire.getAttrsToSet();
		attributesInfoForObject.AttrsToSet = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfos[attrsToSet.Count];
		for (int i = 0; i < attrsToSet.Count; i++)
		{
			attributesInfoForObject.AttrsToSet[i] = toLocal((Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfos)attrsToSet[i], modelManager);
		}
		return attributesInfoForObject;
	}

	public static Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfos toWire(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfos local)
	{
		Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfos attributesInfos = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfos();
		attributesInfos.setName(local.Name);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		attributesInfos.setValues(arrayList);
		return attributesInfos;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfos toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfos wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfos attributesInfos = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfos();
		attributesInfos.Name = wire.getName();
		IList values = wire.getValues();
		attributesInfos.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			attributesInfos.Values[i] = Convert.ToString(values[i]);
		}
		return attributesInfos;
	}

	public static Teamcenter.Schemas.Cad._2009_04.Structuremanagement.RelativeStructureParentInfo toWire(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.RelativeStructureParentInfo local)
	{
		Teamcenter.Schemas.Cad._2009_04.Structuremanagement.RelativeStructureParentInfo relativeStructureParentInfo = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.RelativeStructureParentInfo();
		relativeStructureParentInfo.setClientId(local.ClientId);
		relativeStructureParentInfo.setComplete(local.Complete);
		relativeStructureParentInfo.setBomViewTypeName(local.BomViewTypeName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		relativeStructureParentInfo.setParent(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ChangeContext == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ChangeContext.Uid);
		}
		relativeStructureParentInfo.setChangeContext(modelObject2);
		relativeStructureParentInfo.setLastModifiedOfBVR(TcServerDate.ToWire(local.LastModifiedOfBVR));
		relativeStructureParentInfo.setPrecise(local.Precise);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.SupportingClassAttrs.Length; i++)
		{
			arrayList.Add(toWire(local.SupportingClassAttrs[i]));
		}
		relativeStructureParentInfo.setSupportingClassAttrs(arrayList);
		return relativeStructureParentInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.RelativeStructureParentInfo toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.RelativeStructureParentInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.RelativeStructureParentInfo relativeStructureParentInfo = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.RelativeStructureParentInfo();
		relativeStructureParentInfo.ClientId = wire.getClientId();
		relativeStructureParentInfo.Complete = wire.Complete;
		relativeStructureParentInfo.BomViewTypeName = wire.getBomViewTypeName();
		relativeStructureParentInfo.Parent = modelManager.LoadObjectData(wire.getParent());
		relativeStructureParentInfo.ChangeContext = modelManager.LoadObjectData(wire.getChangeContext());
		relativeStructureParentInfo.LastModifiedOfBVR = TcServerDate.ToLocal(wire.getLastModifiedOfBVR());
		relativeStructureParentInfo.Precise = wire.Precise;
		IList supportingClassAttrs = wire.getSupportingClassAttrs();
		relativeStructureParentInfo.SupportingClassAttrs = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.AttributesInfoForObject[supportingClassAttrs.Count];
		for (int i = 0; i < supportingClassAttrs.Count; i++)
		{
			relativeStructureParentInfo.SupportingClassAttrs[i] = toLocal((Teamcenter.Schemas.Cad._2009_04.Structuremanagement.AttributesInfoForObject)supportingClassAttrs[i], modelManager);
		}
		return relativeStructureParentInfo;
	}

	public static Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureInfo toWire(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureInfo local)
	{
		Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureInfo createOrUpdateRelativeStructureInfo = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureInfo();
		createOrUpdateRelativeStructureInfo.setParentInfo(toWire(local.ParentInfo));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ChildInfo[i]));
		}
		createOrUpdateRelativeStructureInfo.setChildInfo(arrayList);
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureInfo toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureInfo createOrUpdateRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureInfo();
		createOrUpdateRelativeStructureInfo.ParentInfo = toLocal(wire.getParentInfo(), modelManager);
		IList childInfo = wire.getChildInfo();
		createOrUpdateRelativeStructureInfo.ChildInfo = new Teamcenter.Services.Strong.Cad._2008_06.StructureManagement.RelativeStructureChildInfo2[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			createOrUpdateRelativeStructureInfo.ChildInfo[i] = toLocal((Teamcenter.Schemas.Cad._2008_06.Structuremanagement.RelativeStructureChildInfo2)childInfo[i], modelManager);
		}
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructurePref toWire(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref local)
	{
		Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructurePref createOrUpdateRelativeStructurePref = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructurePref();
		createOrUpdateRelativeStructurePref.setOverwriteForLastModDate(local.OverwriteForLastModDate);
		createOrUpdateRelativeStructurePref.setContinueOnError(local.ContinueOnError);
		createOrUpdateRelativeStructurePref.setBomViewTypeName(local.BomViewTypeName);
		createOrUpdateRelativeStructurePref.setCadOccIdAttrName(local.CadOccIdAttrName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectTypes.Length; i++)
		{
			arrayList.Add(local.ObjectTypes[i]);
		}
		createOrUpdateRelativeStructurePref.setObjectTypes(arrayList);
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructurePref wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref createOrUpdateRelativeStructurePref = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref();
		createOrUpdateRelativeStructurePref.OverwriteForLastModDate = wire.OverwriteForLastModDate;
		createOrUpdateRelativeStructurePref.ContinueOnError = wire.ContinueOnError;
		createOrUpdateRelativeStructurePref.BomViewTypeName = wire.getBomViewTypeName();
		createOrUpdateRelativeStructurePref.CadOccIdAttrName = wire.getCadOccIdAttrName();
		IList objectTypes = wire.getObjectTypes();
		createOrUpdateRelativeStructurePref.ObjectTypes = new string[objectTypes.Count];
		for (int i = 0; i < objectTypes.Count; i++)
		{
			createOrUpdateRelativeStructurePref.ObjectTypes[i] = Convert.ToString(objectTypes[i]);
		}
		return createOrUpdateRelativeStructurePref;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse createOrUpdateRelativeStructureResponse = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse();
		createOrUpdateRelativeStructureResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		createOrUpdateRelativeStructureResponse.Output = toLocalClientIdToOccurrenceMap(wire.getOutput(), modelManager);
		return createOrUpdateRelativeStructureResponse;
	}

	public static Teamcenter.Schemas.Cad._2009_04.Structuremanagement.MappedReturnData toWire(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.MappedReturnData local)
	{
		Teamcenter.Schemas.Cad._2009_04.Structuremanagement.MappedReturnData mappedReturnData = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.MappedReturnData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OccThread == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OccThread.Uid);
		}
		mappedReturnData.setOccThread(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Occurrence == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Occurrence.Uid);
		}
		mappedReturnData.setOccurrence(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Bvr == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.Bvr.Uid);
		}
		mappedReturnData.setBvr(modelObject3);
		return mappedReturnData;
	}

	public static Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.MappedReturnData toLocal(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.MappedReturnData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.MappedReturnData mappedReturnData = new Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.MappedReturnData();
		mappedReturnData.OccThread = modelManager.LoadObjectData(wire.getOccThread());
		mappedReturnData.Occurrence = modelManager.LoadObjectData(wire.getOccurrence());
		mappedReturnData.Bvr = modelManager.LoadObjectData(wire.getBvr());
		return mappedReturnData;
	}

	public static ArrayList toWireClientIdToOccurrenceMap(IDictionary ClientIdToOccurrenceMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ClientIdToOccurrenceMap)
		{
			object key = item.Key;
			object value = item.Value;
			ClientIdToOccurrenceMap clientIdToOccurrenceMap = new ClientIdToOccurrenceMap();
			clientIdToOccurrenceMap.setKey(Convert.ToString(key));
			clientIdToOccurrenceMap.setValue(toWire((Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.MappedReturnData)value));
			arrayList.Add(clientIdToOccurrenceMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalClientIdToOccurrenceMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ClientIdToOccurrenceMap clientIdToOccurrenceMap = (ClientIdToOccurrenceMap)wire[i];
			string key = clientIdToOccurrenceMap.getKey();
			Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.MappedReturnData value = toLocal(clientIdToOccurrenceMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	[Obsolete("As of Teamcenter 10.1, this version of createOrUpdateRelativeStructure is replaced by the _2013_05 version.", false)]
	public override Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureInfo[] Inputs, Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureInput createOrUpdateRelativeStructureInput = new Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createOrUpdateRelativeStructureInput.setInputs(arrayList);
			createOrUpdateRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_200904_PORT_NAME, "CreateOrUpdateRelativeStructure", createOrUpdateRelativeStructureInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public static AskChildPathBOMLineOutputNode toWire(AskChildPathBOMLineOutputNode local)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		AskChildPathBOMLineOutputNode val = new AskChildPathBOMLineOutputNode();
		val.setChildPath(local.ChildPath);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Bomline == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Bomline.Uid);
		}
		val.setBomline(modelObject);
		return val;
	}

	public static AskChildPathBOMLineOutputNode toLocal(AskChildPathBOMLineOutputNode wire, PopulateModel modelManager)
	{
		AskChildPathBOMLineOutputNode askChildPathBOMLineOutputNode = new AskChildPathBOMLineOutputNode();
		askChildPathBOMLineOutputNode.ChildPath = wire.getChildPath();
		askChildPathBOMLineOutputNode.Bomline = (BOMLine)modelManager.LoadObjectData(wire.getBomline());
		return askChildPathBOMLineOutputNode;
	}

	public static AskChildPathBOMLinesResponse2 toLocal(AskChildPathBOMLinesResponse2 wire, PopulateModel modelManager)
	{
		AskChildPathBOMLinesResponse2 askChildPathBOMLinesResponse = new AskChildPathBOMLinesResponse2();
		askChildPathBOMLinesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		askChildPathBOMLinesResponse.Output = toLocalAskChildPathClientIdToBOMLineMap(wire.getOutput(), modelManager);
		return askChildPathBOMLinesResponse;
	}

	public static Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateOrUpdateRelativeStructureInfo4 toWire(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateOrUpdateRelativeStructureInfo4 local)
	{
		Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateOrUpdateRelativeStructureInfo4 createOrUpdateRelativeStructureInfo = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateOrUpdateRelativeStructureInfo4();
		createOrUpdateRelativeStructureInfo.setParentInfo(toWire(local.ParentInfo));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ChildInfo[i]));
		}
		createOrUpdateRelativeStructureInfo.setChildInfo(arrayList);
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateOrUpdateRelativeStructureInfo4 toLocal(Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateOrUpdateRelativeStructureInfo4 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateOrUpdateRelativeStructureInfo4 createOrUpdateRelativeStructureInfo = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateOrUpdateRelativeStructureInfo4();
		createOrUpdateRelativeStructureInfo.ParentInfo = toLocal(wire.getParentInfo(), modelManager);
		IList childInfo = wire.getChildInfo();
		createOrUpdateRelativeStructureInfo.ChildInfo = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelativeStructureChildInfo3[childInfo.Count];
		for (int i = 0; i < childInfo.Count; i++)
		{
			createOrUpdateRelativeStructureInfo.ChildInfo[i] = toLocal((Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelativeStructureChildInfo3)childInfo[i], modelManager);
		}
		return createOrUpdateRelativeStructureInfo;
	}

	public static Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateWindowsInfo2 toWire(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateWindowsInfo2 local)
	{
		Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateWindowsInfo2 createWindowsInfo = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateWindowsInfo2();
		createWindowsInfo.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Item == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Item.Uid);
		}
		createWindowsInfo.setItem(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ItemRev == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.ItemRev.Uid);
		}
		createWindowsInfo.setItemRev(modelObject2);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.BomView == null)
		{
			modelObject3.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject3.setUid(local.BomView.Uid);
		}
		createWindowsInfo.setBomView(modelObject3);
		createWindowsInfo.setRevRuleConfigInfo(toWire(local.RevRuleConfigInfo));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectsForConfigure.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject4 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ObjectsForConfigure[i] == null)
			{
				modelObject4.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject4.setUid(local.ObjectsForConfigure[i].Uid);
			}
			arrayList.Add(modelObject4);
		}
		createWindowsInfo.setObjectsForConfigure(arrayList);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject5 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ActiveAssemblyArrangement == null)
		{
			modelObject5.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject5.setUid(local.ActiveAssemblyArrangement.Uid);
		}
		createWindowsInfo.setActiveAssemblyArrangement(modelObject5);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject6 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ConfigContext == null)
		{
			modelObject6.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject6.setUid(local.ConfigContext.Uid);
		}
		createWindowsInfo.setConfigContext(modelObject6);
		createWindowsInfo.setBomWinPropFlagMap(toWireStringMap(local.BomWinPropFlagMap));
		return createWindowsInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateWindowsInfo2 toLocal(Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateWindowsInfo2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateWindowsInfo2 createWindowsInfo = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateWindowsInfo2();
		createWindowsInfo.ClientId = wire.getClientId();
		createWindowsInfo.Item = (Item)modelManager.LoadObjectData(wire.getItem());
		createWindowsInfo.ItemRev = (ItemRevision)modelManager.LoadObjectData(wire.getItemRev());
		createWindowsInfo.BomView = (PSBOMView)modelManager.LoadObjectData(wire.getBomView());
		createWindowsInfo.RevRuleConfigInfo = toLocal(wire.getRevRuleConfigInfo(), modelManager);
		IList objectsForConfigure = wire.getObjectsForConfigure();
		createWindowsInfo.ObjectsForConfigure = new Teamcenter.Soa.Client.Model.ModelObject[objectsForConfigure.Count];
		for (int i = 0; i < objectsForConfigure.Count; i++)
		{
			createWindowsInfo.ObjectsForConfigure[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objectsForConfigure[i]);
		}
		createWindowsInfo.ActiveAssemblyArrangement = (AssemblyArrangement)modelManager.LoadObjectData(wire.getActiveAssemblyArrangement());
		createWindowsInfo.ConfigContext = (ConfigurationContext)modelManager.LoadObjectData(wire.getConfigContext());
		createWindowsInfo.BomWinPropFlagMap = toLocalStringMap(wire.getBomWinPropFlagMap(), modelManager);
		return createWindowsInfo;
	}

	public static Teamcenter.Schemas.Cad._2013_05.Structuremanagement.MoveInfo toWire(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.MoveInfo local)
	{
		Teamcenter.Schemas.Cad._2013_05.Structuremanagement.MoveInfo moveInfo = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.MoveInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.CommonParent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.CommonParent.Uid);
		}
		moveInfo.setCommonParent(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SourceAssembly == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.SourceAssembly.Uid);
		}
		moveInfo.setSourceAssembly(modelObject2);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.OccThreadPathToBeMoved.Length; i++)
		{
			arrayList.Add(local.OccThreadPathToBeMoved[i]);
		}
		moveInfo.setOccThreadPathToBeMoved(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.OccThreadPathTargetParent.Length; i++)
		{
			arrayList2.Add(toWire(local.OccThreadPathTargetParent[i]));
		}
		moveInfo.setOccThreadPathTargetParent(arrayList2);
		return moveInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.MoveInfo toLocal(Teamcenter.Schemas.Cad._2013_05.Structuremanagement.MoveInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.MoveInfo moveInfo = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.MoveInfo();
		moveInfo.CommonParent = modelManager.LoadObjectData(wire.getCommonParent());
		moveInfo.SourceAssembly = modelManager.LoadObjectData(wire.getSourceAssembly());
		IList occThreadPathToBeMoved = wire.getOccThreadPathToBeMoved();
		moveInfo.OccThreadPathToBeMoved = new string[occThreadPathToBeMoved.Count];
		for (int i = 0; i < occThreadPathToBeMoved.Count; i++)
		{
			moveInfo.OccThreadPathToBeMoved[i] = Convert.ToString(occThreadPathToBeMoved[i]);
		}
		IList occThreadPathTargetParent = wire.getOccThreadPathTargetParent();
		moveInfo.OccThreadPathTargetParent = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.OccThreadEquivalent[occThreadPathTargetParent.Count];
		for (int i = 0; i < occThreadPathTargetParent.Count; i++)
		{
			moveInfo.OccThreadPathTargetParent[i] = toLocal((Teamcenter.Schemas.Cad._2013_05.Structuremanagement.OccThreadEquivalent)occThreadPathTargetParent[i], modelManager);
		}
		return moveInfo;
	}

	public static Teamcenter.Schemas.Cad._2013_05.Structuremanagement.OccThreadEquivalent toWire(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.OccThreadEquivalent local)
	{
		Teamcenter.Schemas.Cad._2013_05.Structuremanagement.OccThreadEquivalent occThreadEquivalent = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.OccThreadEquivalent();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Parent == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Parent.Uid);
		}
		occThreadEquivalent.setParent(modelObject);
		occThreadEquivalent.setIdType(local.IdType);
		occThreadEquivalent.setId(local.Id);
		occThreadEquivalent.setIsNew(local.IsNew);
		return occThreadEquivalent;
	}

	public static Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.OccThreadEquivalent toLocal(Teamcenter.Schemas.Cad._2013_05.Structuremanagement.OccThreadEquivalent wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.OccThreadEquivalent occThreadEquivalent = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.OccThreadEquivalent();
		occThreadEquivalent.Parent = modelManager.LoadObjectData(wire.getParent());
		occThreadEquivalent.IdType = wire.getIdType();
		occThreadEquivalent.Id = wire.getId();
		occThreadEquivalent.IsNew = wire.IsNew;
		return occThreadEquivalent;
	}

	public static Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelOccInfo toWire(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelOccInfo local)
	{
		Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelOccInfo relOccInfo = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelOccInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.AttrsToSet.Length; i++)
		{
			arrayList.Add(toWire(local.AttrsToSet[i]));
		}
		relOccInfo.setAttrsToSet(arrayList);
		relOccInfo.setAsRequired(local.AsRequired);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.OccTransform.Length; i++)
		{
			arrayList2.Add(local.OccTransform[i]);
		}
		relOccInfo.setOccTransform(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.OccNotes.Length; i++)
		{
			arrayList3.Add(toWire(local.OccNotes[i]));
		}
		relOccInfo.setOccNotes(arrayList3);
		relOccInfo.setMoveInfo(toWire(local.MoveInfo));
		return relOccInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelOccInfo toLocal(Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelOccInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelOccInfo relOccInfo = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelOccInfo();
		IList attrsToSet = wire.getAttrsToSet();
		relOccInfo.AttrsToSet = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.AttributesInfo[attrsToSet.Count];
		for (int i = 0; i < attrsToSet.Count; i++)
		{
			relOccInfo.AttrsToSet[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.AttributesInfo)attrsToSet[i], modelManager);
		}
		relOccInfo.AsRequired = wire.AsRequired;
		IList occTransform = wire.getOccTransform();
		relOccInfo.OccTransform = new double[occTransform.Count];
		for (int i = 0; i < occTransform.Count; i++)
		{
			relOccInfo.OccTransform[i] = Convert.ToDouble(occTransform[i]);
		}
		IList occNotes = wire.getOccNotes();
		relOccInfo.OccNotes = new Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.OccNote[occNotes.Count];
		for (int i = 0; i < occNotes.Count; i++)
		{
			relOccInfo.OccNotes[i] = toLocal((Teamcenter.Schemas.Cad._2007_01.Structuremanagement.OccNote)occNotes[i], modelManager);
		}
		relOccInfo.MoveInfo = toLocal(wire.getMoveInfo(), modelManager);
		return relOccInfo;
	}

	public static Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelativeStructureChildInfo3 toWire(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelativeStructureChildInfo3 local)
	{
		Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelativeStructureChildInfo3 relativeStructureChildInfo = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelativeStructureChildInfo3();
		relativeStructureChildInfo.setClientId(local.ClientId);
		relativeStructureChildInfo.setChildBomViewTypeName(local.ChildBomViewTypeName);
		relativeStructureChildInfo.setCadOccId(local.CadOccId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Child == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Child.Uid);
		}
		relativeStructureChildInfo.setChild(modelObject);
		relativeStructureChildInfo.setOccInfo(toWire(local.OccInfo));
		return relativeStructureChildInfo;
	}

	public static Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelativeStructureChildInfo3 toLocal(Teamcenter.Schemas.Cad._2013_05.Structuremanagement.RelativeStructureChildInfo3 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelativeStructureChildInfo3 relativeStructureChildInfo = new Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.RelativeStructureChildInfo3();
		relativeStructureChildInfo.ClientId = wire.getClientId();
		relativeStructureChildInfo.ChildBomViewTypeName = wire.getChildBomViewTypeName();
		relativeStructureChildInfo.CadOccId = wire.getCadOccId();
		relativeStructureChildInfo.Child = modelManager.LoadObjectData(wire.getChild());
		relativeStructureChildInfo.OccInfo = toLocal(wire.getOccInfo(), modelManager);
		return relativeStructureChildInfo;
	}

	public static ArrayList toWireAskChildPathClientIdToBOMLineMap(IDictionary AskChildPathClientIdToBOMLineMap)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in AskChildPathClientIdToBOMLineMap)
		{
			object key = item.Key;
			object value = item.Value;
			AskChildPathClientIdToBOMLineMap val = new AskChildPathClientIdToBOMLineMap();
			val.setKey(Convert.ToString(key));
			IList value2 = val.getValue();
			AskChildPathBOMLineOutputNode[] array = (AskChildPathBOMLineOutputNode[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			val.setValue((ArrayList)value2);
			arrayList.Add(val);
		}
		return arrayList;
	}

	public static Hashtable toLocalAskChildPathClientIdToBOMLineMap(ArrayList wire, PopulateModel modelManager)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			AskChildPathClientIdToBOMLineMap val = (AskChildPathClientIdToBOMLineMap)wire[i];
			string key = val.getKey();
			IList value = val.getValue();
			AskChildPathBOMLineOutputNode[] array = new AskChildPathBOMLineOutputNode[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = StructureManagementRestBindingStub.toLocal((AskChildPathBOMLineOutputNode)value[j], modelManager);
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

	public override AskChildPathBOMLinesResponse2 AskChildPathBOMLines2(Teamcenter.Services.Strong.Cad._2008_03.StructureManagement.AskChildPathBOMLinesInfo[] Input)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		try
		{
			restSender.PushRequestId();
			AskChildPathBOMLines2Input val = new AskChildPathBOMLines2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			val.setInput(arrayList);
			Type typeFromHandle = typeof(AskChildPathBOMLinesResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_201305_PORT_NAME, "AskChildPathBOMLines2", val, typeFromHandle, extraTypes);
			modelManager.LockModel();
			AskChildPathBOMLinesResponse2 wire = (AskChildPathBOMLinesResponse2)obj;
			AskChildPathBOMLinesResponse2 result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse CreateOrUpdateRelativeStructure(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateOrUpdateRelativeStructureInfo4[] Inputs, Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructurePref Pref)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateOrUpdateRelativeStructureInput createOrUpdateRelativeStructureInput = new Teamcenter.Schemas.Cad._2013_05.Structuremanagement.CreateOrUpdateRelativeStructureInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createOrUpdateRelativeStructureInput.setInputs(arrayList);
			createOrUpdateRelativeStructureInput.setPref(toWire(Pref));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_201305_PORT_NAME, "CreateOrUpdateRelativeStructure", createOrUpdateRelativeStructureInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse wire = (Teamcenter.Schemas.Cad._2009_04.Structuremanagement.CreateOrUpdateRelativeStructureResponse)obj;
			Teamcenter.Services.Strong.Cad._2009_04.StructureManagement.CreateOrUpdateRelativeStructureResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse CreateBOMWindows2(Teamcenter.Services.Strong.Cad._2013_05.StructureManagement.CreateWindowsInfo2[] Info)
	{
		try
		{
			restSender.PushRequestId();
			CreateBOMWindows2Input createBOMWindows2Input = new CreateBOMWindows2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(toWire(Info[i]));
			}
			createBOMWindows2Input.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(STRUCTUREMANAGEMENT_201305_PORT_NAME, "CreateBOMWindows2", createBOMWindows2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse wire = (Teamcenter.Schemas.Cad._2007_01.Structuremanagement.CreateBOMWindowsResponse)obj;
			Teamcenter.Services.Strong.Cad._2007_01.StructureManagement.CreateBOMWindowsResponse result = toLocal(wire, modelManager);
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
