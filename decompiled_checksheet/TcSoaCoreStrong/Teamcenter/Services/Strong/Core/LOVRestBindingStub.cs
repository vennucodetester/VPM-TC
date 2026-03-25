using System;
using System.Collections;
using Teamcenter.Schemas.Core._2007_06.Lov;
using Teamcenter.Schemas.Core._2011_06.Lov;
using Teamcenter.Schemas.Core._2013_05.Lov;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Core._2007_06.LOV;
using Teamcenter.Services.Strong.Core._2011_06.LOV;
using Teamcenter.Services.Strong.Core._2013_05.LOV;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class LOVRestBindingStub : LOVService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string LOV_200706_PORT_NAME = "Core-2007-06-LOV";

	private static readonly string LOV_201106_PORT_NAME = "Core-2011-06-LOV";

	private static readonly string LOV_201305_PORT_NAME = "Core-2013-05-LOV";

	public LOVRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Services.Strong.Core._2007_06.LOV.AttachedLOVsResponse toLocal(Teamcenter.Schemas.Core._2007_06.Lov.AttachedLOVsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.LOV.AttachedLOVsResponse attachedLOVsResponse = new Teamcenter.Services.Strong.Core._2007_06.LOV.AttachedLOVsResponse();
		attachedLOVsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		attachedLOVsResponse.InputTypeNameToLOVOutput = toLocalInputTypeNameToLOVOutputMap(wire.getInputTypeNameToLOVOutput(), modelManager);
		return attachedLOVsResponse;
	}

	public static Teamcenter.Schemas.Core._2007_06.Lov.LOVInfo toWire(Teamcenter.Services.Strong.Core._2007_06.LOV.LOVInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Lov.LOVInfo lOVInfo = new Teamcenter.Schemas.Core._2007_06.Lov.LOVInfo();
		lOVInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropNames.Length; i++)
		{
			arrayList.Add(local.PropNames[i]);
		}
		lOVInfo.setPropNames(arrayList);
		return lOVInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.LOV.LOVInfo toLocal(Teamcenter.Schemas.Core._2007_06.Lov.LOVInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.LOV.LOVInfo lOVInfo = new Teamcenter.Services.Strong.Core._2007_06.LOV.LOVInfo();
		lOVInfo.TypeName = wire.getTypeName();
		IList propNames = wire.getPropNames();
		lOVInfo.PropNames = new string[propNames.Count];
		for (int i = 0; i < propNames.Count; i++)
		{
			lOVInfo.PropNames[i] = Convert.ToString(propNames[i]);
		}
		return lOVInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Lov.LOVOutput toWire(Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput local)
	{
		Teamcenter.Schemas.Core._2007_06.Lov.LOVOutput lOVOutput = new Teamcenter.Schemas.Core._2007_06.Lov.LOVOutput();
		lOVOutput.setPropName(local.PropName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		lOVOutput.setLov(modelObject);
		return lOVOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput toLocal(Teamcenter.Schemas.Core._2007_06.Lov.LOVOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput lOVOutput = new Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput();
		lOVOutput.PropName = wire.getPropName();
		lOVOutput.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		return lOVOutput;
	}

	public static ArrayList toWireInputTypeNameToLOVOutputMap(IDictionary InputTypeNameToLOVOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in InputTypeNameToLOVOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			InputTypeNameToLOVOutputMap inputTypeNameToLOVOutputMap = new InputTypeNameToLOVOutputMap();
			inputTypeNameToLOVOutputMap.setKey(Convert.ToString(key));
			IList value2 = inputTypeNameToLOVOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput[] array = (Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			inputTypeNameToLOVOutputMap.setValue((ArrayList)value2);
			arrayList.Add(inputTypeNameToLOVOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalInputTypeNameToLOVOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			InputTypeNameToLOVOutputMap inputTypeNameToLOVOutputMap = (InputTypeNameToLOVOutputMap)wire[i];
			string key = inputTypeNameToLOVOutputMap.getKey();
			IList value = inputTypeNameToLOVOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput[] array = new Teamcenter.Services.Strong.Core._2007_06.LOV.LOVOutput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2007_06.Lov.LOVOutput)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	[Obsolete("As of tc2007.1, use the getAttachedPropDescs operation.", false)]
	public override Teamcenter.Services.Strong.Core._2007_06.LOV.AttachedLOVsResponse GetAttachedLOVs(Teamcenter.Services.Strong.Core._2007_06.LOV.LOVInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetAttachedLOVsInput getAttachedLOVsInput = new GetAttachedLOVsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getAttachedLOVsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Lov.AttachedLOVsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(LOV_200706_PORT_NAME, "GetAttachedLOVs", getAttachedLOVsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2007_06.Lov.AttachedLOVsResponse wire = (Teamcenter.Schemas.Core._2007_06.Lov.AttachedLOVsResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.LOV.AttachedLOVsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachment toWire(Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment local)
	{
		Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachment lOVAttachment = new Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachment();
		lOVAttachment.setPropName(local.PropName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		lOVAttachment.setLov(modelObject);
		return lOVAttachment;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment toLocal(Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachment wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment lOVAttachment = new Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment();
		lOVAttachment.PropName = wire.getPropName();
		lOVAttachment.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		return lOVAttachment;
	}

	public static Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsInput toWire(Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsInput local)
	{
		Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsInput lOVAttachmentsInput = new Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsInput();
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
		lOVAttachmentsInput.setObjects(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Properties.Length; i++)
		{
			arrayList2.Add(local.Properties[i]);
		}
		lOVAttachmentsInput.setProperties(arrayList2);
		return lOVAttachmentsInput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsInput toLocal(Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsInput lOVAttachmentsInput = new Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsInput();
		IList objects = wire.getObjects();
		lOVAttachmentsInput.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			lOVAttachmentsInput.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		IList properties = wire.getProperties();
		lOVAttachmentsInput.Properties = new string[properties.Count];
		for (int i = 0; i < properties.Count; i++)
		{
			lOVAttachmentsInput.Properties[i] = Convert.ToString(properties[i]);
		}
		return lOVAttachmentsInput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsResponse toLocal(Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsResponse lOVAttachmentsResponse = new Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsResponse();
		lOVAttachmentsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		lOVAttachmentsResponse.LovAttachments = toLocalInpoutObjectToLOVAttachmentsMap(wire.getLovAttachments(), modelManager);
		return lOVAttachmentsResponse;
	}

	public static ArrayList toWireInpoutObjectToLOVAttachmentsMap(IDictionary InpoutObjectToLOVAttachmentsMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in InpoutObjectToLOVAttachmentsMap)
		{
			object key = item.Key;
			object value = item.Value;
			InpoutObjectToLOVAttachmentsMap inpoutObjectToLOVAttachmentsMap = new InpoutObjectToLOVAttachmentsMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			inpoutObjectToLOVAttachmentsMap.setKey(modelObject);
			IList value2 = inpoutObjectToLOVAttachmentsMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment[] array = (Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			inpoutObjectToLOVAttachmentsMap.setValue((ArrayList)value2);
			arrayList.Add(inpoutObjectToLOVAttachmentsMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalInpoutObjectToLOVAttachmentsMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			InpoutObjectToLOVAttachmentsMap inpoutObjectToLOVAttachmentsMap = (InpoutObjectToLOVAttachmentsMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(inpoutObjectToLOVAttachmentsMap.getKey());
			IList value = inpoutObjectToLOVAttachmentsMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment[] array = new Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachment[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachment)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsResponse GetLOVAttachments(Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsInput[] ObjectStructArray)
	{
		try
		{
			restSender.PushRequestId();
			GetLOVAttachmentsInput getLOVAttachmentsInput = new GetLOVAttachmentsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ObjectStructArray.Length; i++)
			{
				arrayList.Add(toWire(ObjectStructArray[i]));
			}
			getLOVAttachmentsInput.setObjectStructArray(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(LOV_201106_PORT_NAME, "GetLOVAttachments", getLOVAttachmentsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsResponse wire = (Teamcenter.Schemas.Core._2011_06.Lov.LOVAttachmentsResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.LOV.LOVAttachmentsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2013_05.Lov.LOVInput toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVInput local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.LOVInput lOVInput = new Teamcenter.Schemas.Core._2013_05.Lov.LOVInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.OwningObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.OwningObject.Uid);
		}
		lOVInput.setOwningObject(modelObject);
		lOVInput.setBoName(local.BoName);
		lOVInput.setOperationName(local.OperationName);
		lOVInput.setPropertyValues(toWirePropertyValues(local.PropertyValues));
		return lOVInput;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LOVInput toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LOVInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LOVInput lOVInput = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVInput();
		lOVInput.OwningObject = modelManager.LoadObjectData(wire.getOwningObject());
		lOVInput.BoName = wire.getBoName();
		lOVInput.OperationName = wire.getOperationName();
		lOVInput.PropertyValues = toLocalPropertyValues(wire.getPropertyValues(), modelManager);
		return lOVInput;
	}

	public static Teamcenter.Schemas.Core._2013_05.Lov.LovFilterData toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.LovFilterData local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.LovFilterData lovFilterData = new Teamcenter.Schemas.Core._2013_05.Lov.LovFilterData();
		lovFilterData.setFilterString(local.FilterString);
		lovFilterData.setMaxResults(local.MaxResults);
		lovFilterData.setNumberToReturn(local.NumberToReturn);
		lovFilterData.setSortPropertyName(local.SortPropertyName);
		lovFilterData.setOrder(local.Order);
		return lovFilterData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LovFilterData toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LovFilterData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LovFilterData lovFilterData = new Teamcenter.Services.Strong.Core._2013_05.LOV.LovFilterData();
		lovFilterData.FilterString = wire.getFilterString();
		lovFilterData.MaxResults = wire.getMaxResults();
		lovFilterData.NumberToReturn = wire.getNumberToReturn();
		lovFilterData.SortPropertyName = wire.getSortPropertyName();
		lovFilterData.Order = wire.getOrder();
		return lovFilterData;
	}

	public static Teamcenter.Schemas.Core._2013_05.Lov.InitialLovData toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.InitialLovData local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.InitialLovData initialLovData = new Teamcenter.Schemas.Core._2013_05.Lov.InitialLovData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		initialLovData.setLov(modelObject);
		initialLovData.setLovInput(toWire(local.LovInput));
		initialLovData.setPropertyName(local.PropertyName);
		initialLovData.setFilterData(toWire(local.FilterData));
		return initialLovData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.InitialLovData toLocal(Teamcenter.Schemas.Core._2013_05.Lov.InitialLovData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.InitialLovData initialLovData = new Teamcenter.Services.Strong.Core._2013_05.LOV.InitialLovData();
		initialLovData.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		initialLovData.LovInput = toLocal(wire.getLovInput(), modelManager);
		initialLovData.PropertyName = wire.getPropertyName();
		initialLovData.FilterData = toLocal(wire.getFilterData(), modelManager);
		return initialLovData;
	}

	public static Teamcenter.Schemas.Core._2013_05.Lov.LOVColumnNames toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVColumnNames local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.LOVColumnNames lOVColumnNames = new Teamcenter.Schemas.Core._2013_05.Lov.LOVColumnNames();
		lOVColumnNames.setLovValueProp(local.LovValueProp);
		lOVColumnNames.setLovDescrProp(local.LovDescrProp);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.FilterProperties.Length; i++)
		{
			arrayList.Add(local.FilterProperties[i]);
		}
		lOVColumnNames.setFilterProperties(arrayList);
		lOVColumnNames.setDisplayNames(toWireStringMap(local.DisplayNames));
		lOVColumnNames.setColumnManagementFlags(toWireStringIntMap(local.ColumnManagementFlags));
		return lOVColumnNames;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LOVColumnNames toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LOVColumnNames wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LOVColumnNames lOVColumnNames = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVColumnNames();
		lOVColumnNames.LovValueProp = wire.getLovValueProp();
		lOVColumnNames.LovDescrProp = wire.getLovDescrProp();
		IList filterProperties = wire.getFilterProperties();
		lOVColumnNames.FilterProperties = new string[filterProperties.Count];
		for (int i = 0; i < filterProperties.Count; i++)
		{
			lOVColumnNames.FilterProperties[i] = Convert.ToString(filterProperties[i]);
		}
		lOVColumnNames.DisplayNames = toLocalStringMap(wire.getDisplayNames(), modelManager);
		lOVColumnNames.ColumnManagementFlags = toLocalStringIntMap(wire.getColumnManagementFlags(), modelManager);
		return lOVColumnNames;
	}

	public static Teamcenter.Schemas.Core._2013_05.Lov.LOVBehaviorData toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVBehaviorData local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.LOVBehaviorData lOVBehaviorData = new Teamcenter.Schemas.Core._2013_05.Lov.LOVBehaviorData();
		lOVBehaviorData.setLovUsage(local.LovUsage);
		lOVBehaviorData.setStyle(local.Style);
		lOVBehaviorData.setColumnNames(toWire(local.ColumnNames));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DescriptionsAttached.Length; i++)
		{
			arrayList.Add(local.DescriptionsAttached[i]);
		}
		lOVBehaviorData.setDescriptionsAttached(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.DependendProps.Length; i++)
		{
			arrayList2.Add(local.DependendProps[i]);
		}
		lOVBehaviorData.setDependendProps(arrayList2);
		lOVBehaviorData.setRangeUpperLimit(local.RangeUpperLimit);
		lOVBehaviorData.setRangeLowerLimit(local.RangeLowerLimit);
		return lOVBehaviorData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LOVBehaviorData toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LOVBehaviorData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LOVBehaviorData lOVBehaviorData = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVBehaviorData();
		lOVBehaviorData.LovUsage = wire.getLovUsage();
		lOVBehaviorData.Style = wire.getStyle();
		lOVBehaviorData.ColumnNames = toLocal(wire.getColumnNames(), modelManager);
		IList descriptionsAttached = wire.getDescriptionsAttached();
		lOVBehaviorData.DescriptionsAttached = new bool[descriptionsAttached.Count];
		for (int i = 0; i < descriptionsAttached.Count; i++)
		{
			lOVBehaviorData.DescriptionsAttached[i] = Convert.ToBoolean(descriptionsAttached[i]);
		}
		IList dependendProps = wire.getDependendProps();
		lOVBehaviorData.DependendProps = new string[dependendProps.Count];
		for (int i = 0; i < dependendProps.Count; i++)
		{
			lOVBehaviorData.DependendProps[i] = Convert.ToString(dependendProps[i]);
		}
		lOVBehaviorData.RangeUpperLimit = wire.getRangeUpperLimit();
		lOVBehaviorData.RangeLowerLimit = wire.getRangeLowerLimit();
		return lOVBehaviorData;
	}

	public static Teamcenter.Schemas.Core._2013_05.Lov.LOVData toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVData local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.LOVData lOVData = new Teamcenter.Schemas.Core._2013_05.Lov.LOVData();
		lOVData.setStyle(local.Style);
		lOVData.setFilterData(toWire(local.FilterData));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.UnProcessedObjects.Length; i++)
		{
			arrayList.Add(local.UnProcessedObjects[i]);
		}
		lOVData.setUnProcessedObjects(arrayList);
		lOVData.setAdditionalValuesSkipped(local.AdditionalValuesSkipped);
		lOVData.setCurrentIndex(local.CurrentIndex);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Lovs.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Lovs[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.Lovs[i].Uid);
			}
			arrayList2.Add(modelObject);
		}
		lOVData.setLovs(arrayList2);
		return lOVData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LOVData toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LOVData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LOVData lOVData = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVData();
		lOVData.Style = wire.getStyle();
		lOVData.FilterData = toLocal(wire.getFilterData(), modelManager);
		IList unProcessedObjects = wire.getUnProcessedObjects();
		lOVData.UnProcessedObjects = new string[unProcessedObjects.Count];
		for (int i = 0; i < unProcessedObjects.Count; i++)
		{
			lOVData.UnProcessedObjects[i] = Convert.ToString(unProcessedObjects[i]);
		}
		lOVData.AdditionalValuesSkipped = wire.AdditionalValuesSkipped;
		lOVData.CurrentIndex = wire.getCurrentIndex();
		IList lovs = wire.getLovs();
		lOVData.Lovs = new ListOfValues[lovs.Count];
		for (int i = 0; i < lovs.Count; i++)
		{
			lOVData.Lovs[i] = (ListOfValues)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)lovs[i]);
		}
		return lOVData;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults lOVSearchResults = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults();
		lOVSearchResults.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList lovValues = wire.getLovValues();
		lOVSearchResults.LovValues = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVValueRow[lovValues.Count];
		for (int i = 0; i < lovValues.Count; i++)
		{
			lOVSearchResults.LovValues[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Lov.LOVValueRow)lovValues[i], modelManager);
		}
		lOVSearchResults.MoreValuesExist = wire.MoreValuesExist;
		lOVSearchResults.BehaviorData = toLocal(wire.getBehaviorData(), modelManager);
		lOVSearchResults.LovData = toLocal(wire.getLovData(), modelManager);
		return lOVSearchResults;
	}

	public static Teamcenter.Schemas.Core._2013_05.Lov.LOVValueRow toWire(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVValueRow local)
	{
		Teamcenter.Schemas.Core._2013_05.Lov.LOVValueRow lOVValueRow = new Teamcenter.Schemas.Core._2013_05.Lov.LOVValueRow();
		lOVValueRow.setUid(local.Uid);
		lOVValueRow.setPropInternalValues(toWirePropertyValues(local.PropInternalValues));
		lOVValueRow.setPropInternalValueTypes(toWireStringIntMap(local.PropInternalValueTypes));
		lOVValueRow.setPropDisplayValues(toWirePropertyValues(local.PropDisplayValues));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ChildRows.Length; i++)
		{
			arrayList.Add(toWire(local.ChildRows[i]));
		}
		lOVValueRow.setChildRows(arrayList);
		return lOVValueRow;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.LOVValueRow toLocal(Teamcenter.Schemas.Core._2013_05.Lov.LOVValueRow wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.LOVValueRow lOVValueRow = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVValueRow();
		lOVValueRow.Uid = wire.getUid();
		lOVValueRow.PropInternalValues = toLocalPropertyValues(wire.getPropInternalValues(), modelManager);
		lOVValueRow.PropInternalValueTypes = toLocalStringIntMap(wire.getPropInternalValueTypes(), modelManager);
		lOVValueRow.PropDisplayValues = toLocalPropertyValues(wire.getPropDisplayValues(), modelManager);
		IList childRows = wire.getChildRows();
		lOVValueRow.ChildRows = new Teamcenter.Services.Strong.Core._2013_05.LOV.LOVValueRow[childRows.Count];
		for (int i = 0; i < childRows.Count; i++)
		{
			lOVValueRow.ChildRows[i] = toLocal((Teamcenter.Schemas.Core._2013_05.Lov.LOVValueRow)childRows[i], modelManager);
		}
		return lOVValueRow;
	}

	public static Teamcenter.Services.Strong.Core._2013_05.LOV.ValidateLOVValueSelectionsResponse toLocal(Teamcenter.Schemas.Core._2013_05.Lov.ValidateLOVValueSelectionsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2013_05.LOV.ValidateLOVValueSelectionsResponse validateLOVValueSelectionsResponse = new Teamcenter.Services.Strong.Core._2013_05.LOV.ValidateLOVValueSelectionsResponse();
		validateLOVValueSelectionsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		validateLOVValueSelectionsResponse.PropHasValidValues = wire.PropHasValidValues;
		IList dependentPropNames = wire.getDependentPropNames();
		validateLOVValueSelectionsResponse.DependentPropNames = new string[dependentPropNames.Count];
		for (int i = 0; i < dependentPropNames.Count; i++)
		{
			validateLOVValueSelectionsResponse.DependentPropNames[i] = Convert.ToString(dependentPropNames[i]);
		}
		validateLOVValueSelectionsResponse.UpdatedPropValues = toLocal(wire.getUpdatedPropValues(), modelManager);
		return validateLOVValueSelectionsResponse;
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

	public static ArrayList toWireStringIntMap(IDictionary StringIntMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in StringIntMap)
		{
			object key = item.Key;
			object value = item.Value;
			StringIntMap stringIntMap = new StringIntMap();
			stringIntMap.setKey(Convert.ToString(key));
			stringIntMap.setValue((int)value);
			arrayList.Add(stringIntMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalStringIntMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			StringIntMap stringIntMap = (StringIntMap)wire[i];
			string key = stringIntMap.getKey();
			int value = stringIntMap.getValue();
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

	public override Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults GetInitialLOVValues(Teamcenter.Services.Strong.Core._2013_05.LOV.InitialLovData InitialData)
	{
		try
		{
			restSender.PushRequestId();
			GetInitialLOVValuesInput getInitialLOVValuesInput = new GetInitialLOVValuesInput();
			getInitialLOVValuesInput.setInitialData(toWire(InitialData));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(LOV_201305_PORT_NAME, "GetInitialLOVValues", getInitialLOVValuesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults wire = (Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults)obj;
			Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults GetNextLOVValues(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVData LovData)
	{
		try
		{
			restSender.PushRequestId();
			GetNextLOVValuesInput getNextLOVValuesInput = new GetNextLOVValuesInput();
			getNextLOVValuesInput.setLovData(toWire(LovData));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(LOV_201305_PORT_NAME, "GetNextLOVValues", getNextLOVValuesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults wire = (Teamcenter.Schemas.Core._2013_05.Lov.LOVSearchResults)obj;
			Teamcenter.Services.Strong.Core._2013_05.LOV.LOVSearchResults result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2013_05.LOV.ValidateLOVValueSelectionsResponse ValidateLOVValueSelections(Teamcenter.Services.Strong.Core._2013_05.LOV.LOVInput LovInput, string PropName, string[] UidOfSelectedRows)
	{
		try
		{
			restSender.PushRequestId();
			ValidateLOVValueSelectionsInput validateLOVValueSelectionsInput = new ValidateLOVValueSelectionsInput();
			validateLOVValueSelectionsInput.setLovInput(toWire(LovInput));
			validateLOVValueSelectionsInput.setPropName(PropName);
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < UidOfSelectedRows.Length; i++)
			{
				arrayList.Add(UidOfSelectedRows[i]);
			}
			validateLOVValueSelectionsInput.setUidOfSelectedRows(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2013_05.Lov.ValidateLOVValueSelectionsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(LOV_201305_PORT_NAME, "ValidateLOVValueSelections", validateLOVValueSelectionsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2013_05.Lov.ValidateLOVValueSelectionsResponse wire = (Teamcenter.Schemas.Core._2013_05.Lov.ValidateLOVValueSelectionsResponse)obj;
			Teamcenter.Services.Strong.Core._2013_05.LOV.ValidateLOVValueSelectionsResponse result = toLocal(wire, modelManager);
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
