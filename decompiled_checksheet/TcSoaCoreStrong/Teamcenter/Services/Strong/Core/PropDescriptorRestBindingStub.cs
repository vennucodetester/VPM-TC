using System;
using System.Collections;
using Teamcenter.Schemas.Core._2007_06.Propdescriptor;
using Teamcenter.Schemas.Core._2008_06.Propdescriptor;
using Teamcenter.Schemas.Core._2011_06.Propdescriptor;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Core._2007_06.PropDescriptor;
using Teamcenter.Services.Strong.Core._2008_06.PropDescriptor;
using Teamcenter.Services.Strong.Core._2011_06.PropDescriptor;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class PropDescriptorRestBindingStub : PropDescriptorService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string PROPDESCRIPTOR_200706_PORT_NAME = "Core-2007-06-PropDescriptor";

	private static readonly string PROPDESCRIPTOR_200806_PORT_NAME = "Core-2008-06-PropDescriptor";

	private static readonly string PROPDESCRIPTOR_201106_PORT_NAME = "Core-2011-06-PropDescriptor";

	public PropDescriptorRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.AttachedPropDescsResponse toLocal(Teamcenter.Schemas.Core._2007_06.Propdescriptor.AttachedPropDescsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.AttachedPropDescsResponse attachedPropDescsResponse = new Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.AttachedPropDescsResponse();
		attachedPropDescsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		attachedPropDescsResponse.InputTypeNameToPropDescOutput = toLocalInputTypeNameToPropDescOutputMap(wire.getInputTypeNameToPropDescOutput(), modelManager);
		return attachedPropDescsResponse;
	}

	public static Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDesc toWire(Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDesc local)
	{
		Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDesc propDesc = new Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDesc();
		propDesc.setPropName(local.PropName);
		propDesc.setDisplayName(local.DisplayName);
		propDesc.setDefaultValue(local.DefaultValue);
		propDesc.setPropValueType(local.PropValueType);
		propDesc.setPropType(local.PropType);
		propDesc.setIsDisplayable(local.IsDisplayable);
		propDesc.setIsArray(local.IsArray);
		propDesc.setMaxNumElems(local.MaxNumElems);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		propDesc.setLov(modelObject);
		propDesc.setIsRequired(local.IsRequired);
		propDesc.setIsEnabled(local.IsEnabled);
		propDesc.setIsModifiable(local.IsModifiable);
		propDesc.setAttachedSpecifier(local.AttachedSpecifier);
		propDesc.setMaxLength(local.MaxLength);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.InterdependentProps.Length; i++)
		{
			arrayList.Add(local.InterdependentProps[i]);
		}
		propDesc.setInterdependentProps(arrayList);
		return propDesc;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDesc toLocal(Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDesc wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDesc propDesc = new Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDesc();
		propDesc.PropName = wire.getPropName();
		propDesc.DisplayName = wire.getDisplayName();
		propDesc.DefaultValue = wire.getDefaultValue();
		propDesc.PropValueType = wire.getPropValueType();
		propDesc.PropType = wire.getPropType();
		propDesc.IsDisplayable = wire.IsDisplayable;
		propDesc.IsArray = wire.IsArray;
		propDesc.MaxNumElems = wire.getMaxNumElems();
		propDesc.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		propDesc.IsRequired = wire.IsRequired;
		propDesc.IsEnabled = wire.IsEnabled;
		propDesc.IsModifiable = wire.IsModifiable;
		propDesc.AttachedSpecifier = wire.getAttachedSpecifier();
		propDesc.MaxLength = wire.getMaxLength();
		IList interdependentProps = wire.getInterdependentProps();
		propDesc.InterdependentProps = new string[interdependentProps.Count];
		for (int i = 0; i < interdependentProps.Count; i++)
		{
			propDesc.InterdependentProps[i] = Convert.ToString(interdependentProps[i]);
		}
		return propDesc;
	}

	public static Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescInfo toWire(Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescInfo local)
	{
		Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescInfo propDescInfo = new Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescInfo();
		propDescInfo.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropNames.Length; i++)
		{
			arrayList.Add(local.PropNames[i]);
		}
		propDescInfo.setPropNames(arrayList);
		return propDescInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescInfo toLocal(Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescInfo propDescInfo = new Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescInfo();
		propDescInfo.TypeName = wire.getTypeName();
		IList propNames = wire.getPropNames();
		propDescInfo.PropNames = new string[propNames.Count];
		for (int i = 0; i < propNames.Count; i++)
		{
			propDescInfo.PropNames[i] = Convert.ToString(propNames[i]);
		}
		return propDescInfo;
	}

	public static Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescOutput toWire(Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput local)
	{
		Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescOutput propDescOutput = new Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescOutput();
		propDescOutput.setPropName(local.PropName);
		propDescOutput.setPropertyDesc(toWire(local.PropertyDesc));
		return propDescOutput;
	}

	public static Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput toLocal(Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput propDescOutput = new Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput();
		propDescOutput.PropName = wire.getPropName();
		propDescOutput.PropertyDesc = toLocal(wire.getPropertyDesc(), modelManager);
		return propDescOutput;
	}

	public static ArrayList toWireInputTypeNameToPropDescOutputMap(IDictionary InputTypeNameToPropDescOutputMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in InputTypeNameToPropDescOutputMap)
		{
			object key = item.Key;
			object value = item.Value;
			InputTypeNameToPropDescOutputMap inputTypeNameToPropDescOutputMap = new InputTypeNameToPropDescOutputMap();
			inputTypeNameToPropDescOutputMap.setKey(Convert.ToString(key));
			IList value2 = inputTypeNameToPropDescOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput[] array = (Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			inputTypeNameToPropDescOutputMap.setValue((ArrayList)value2);
			arrayList.Add(inputTypeNameToPropDescOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalInputTypeNameToPropDescOutputMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			InputTypeNameToPropDescOutputMap inputTypeNameToPropDescOutputMap = (InputTypeNameToPropDescOutputMap)wire[i];
			string key = inputTypeNameToPropDescOutputMap.getKey();
			IList value = inputTypeNameToPropDescOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput[] array = new Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescOutput[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2007_06.Propdescriptor.PropDescOutput)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	[Obsolete("As of Teamcenter 9, use the getAttachedPropDescs2 operation.", false)]
	public override Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.AttachedPropDescsResponse GetAttachedPropDescs(Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetAttachedPropDescsInput getAttachedPropDescsInput = new GetAttachedPropDescsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getAttachedPropDescsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_06.Propdescriptor.AttachedPropDescsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(PROPDESCRIPTOR_200706_PORT_NAME, "GetAttachedPropDescs", getAttachedPropDescsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2007_06.Propdescriptor.AttachedPropDescsResponse wire = (Teamcenter.Schemas.Core._2007_06.Propdescriptor.AttachedPropDescsResponse)obj;
			Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.AttachedPropDescsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDesc toWire(Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDesc local)
	{
		Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDesc createDesc = new Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDesc();
		createDesc.setBusinessObjectTypeName(local.BusinessObjectTypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropDescs.Length; i++)
		{
			arrayList.Add(toWire(local.PropDescs[i]));
		}
		createDesc.setPropDescs(arrayList);
		createDesc.setSecondaryCreateDescs(toWireSecCreateDescMap(local.SecondaryCreateDescs));
		return createDesc;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDesc toLocal(Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDesc wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDesc createDesc = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDesc();
		createDesc.BusinessObjectTypeName = wire.getBusinessObjectTypeName();
		IList propDescs = wire.getPropDescs();
		createDesc.PropDescs = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDesc[propDescs.Count];
		for (int i = 0; i < propDescs.Count; i++)
		{
			createDesc.PropDescs[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Propdescriptor.PropDesc)propDescs[i], modelManager);
		}
		createDesc.SecondaryCreateDescs = toLocalSecCreateDescMap(wire.getSecondaryCreateDescs(), modelManager);
		return createDesc;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDescResponse toLocal(Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDescResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDescResponse createDescResponse = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDescResponse();
		createDescResponse.SrvData = modelManager.LoadServiceData(wire.getServiceData());
		IList createDescs = wire.getCreateDescs();
		createDescResponse.CreateDescs = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDesc[createDescs.Count];
		for (int i = 0; i < createDescs.Count; i++)
		{
			createDescResponse.CreateDescs[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDesc)createDescs[i], modelManager);
		}
		return createDescResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Propdescriptor.PropDesc toWire(Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDesc local)
	{
		Teamcenter.Schemas.Core._2008_06.Propdescriptor.PropDesc propDesc = new Teamcenter.Schemas.Core._2008_06.Propdescriptor.PropDesc();
		propDesc.setPropName(local.PropName);
		propDesc.setDisplayName(local.DisplayName);
		propDesc.setDefaultValue(local.DefaultValue);
		propDesc.setPropValueType(local.PropValueType);
		propDesc.setPropType(local.PropType);
		propDesc.setIsDisplayable(local.IsDisplayable);
		propDesc.setIsArray(local.IsArray);
		propDesc.setMaxNumElems(local.MaxNumElems);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		propDesc.setLov(modelObject);
		propDesc.setIsRequired(local.IsRequired);
		propDesc.setIsEnabled(local.IsEnabled);
		propDesc.setIsModifiable(local.IsModifiable);
		propDesc.setAttachedSpecifier(local.AttachedSpecifier);
		propDesc.setMaxLength(local.MaxLength);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.InterdependentProps.Length; i++)
		{
			arrayList.Add(local.InterdependentProps[i]);
		}
		propDesc.setInterdependentProps(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.NamingPatterns.Length; i++)
		{
			arrayList2.Add(local.NamingPatterns[i]);
		}
		propDesc.setNamingPatterns(arrayList2);
		return propDesc;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDesc toLocal(Teamcenter.Schemas.Core._2008_06.Propdescriptor.PropDesc wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDesc propDesc = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDesc();
		propDesc.PropName = wire.getPropName();
		propDesc.DisplayName = wire.getDisplayName();
		propDesc.DefaultValue = wire.getDefaultValue();
		propDesc.PropValueType = wire.getPropValueType();
		propDesc.PropType = wire.getPropType();
		propDesc.IsDisplayable = wire.IsDisplayable;
		propDesc.IsArray = wire.IsArray;
		propDesc.MaxNumElems = wire.getMaxNumElems();
		propDesc.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		propDesc.IsRequired = wire.IsRequired;
		propDesc.IsEnabled = wire.IsEnabled;
		propDesc.IsModifiable = wire.IsModifiable;
		propDesc.AttachedSpecifier = wire.getAttachedSpecifier();
		propDesc.MaxLength = wire.getMaxLength();
		IList interdependentProps = wire.getInterdependentProps();
		propDesc.InterdependentProps = new string[interdependentProps.Count];
		for (int i = 0; i < interdependentProps.Count; i++)
		{
			propDesc.InterdependentProps[i] = Convert.ToString(interdependentProps[i]);
		}
		IList namingPatterns = wire.getNamingPatterns();
		propDesc.NamingPatterns = new string[namingPatterns.Count];
		for (int i = 0; i < namingPatterns.Count; i++)
		{
			propDesc.NamingPatterns[i] = Convert.ToString(namingPatterns[i]);
		}
		return propDesc;
	}

	public static Teamcenter.Schemas.Core._2008_06.Propdescriptor.SecCreateDesc toWire(Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc local)
	{
		Teamcenter.Schemas.Core._2008_06.Propdescriptor.SecCreateDesc secCreateDesc = new Teamcenter.Schemas.Core._2008_06.Propdescriptor.SecCreateDesc();
		secCreateDesc.setBusinessObjectTypeName(local.BusinessObjectTypeName);
		secCreateDesc.setIsRequired(local.IsRequired);
		secCreateDesc.setIsArray(local.IsArray);
		secCreateDesc.setCompoundingCtxt(local.CompoundingCtxt);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropDescs.Length; i++)
		{
			arrayList.Add(toWire(local.PropDescs[i]));
		}
		secCreateDesc.setPropDescs(arrayList);
		secCreateDesc.setSecondaryCreateDescs(toWireSecCreateDescMap(local.SecondaryCreateDescs));
		return secCreateDesc;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc toLocal(Teamcenter.Schemas.Core._2008_06.Propdescriptor.SecCreateDesc wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc secCreateDesc = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc();
		secCreateDesc.BusinessObjectTypeName = wire.getBusinessObjectTypeName();
		secCreateDesc.IsRequired = wire.IsRequired;
		secCreateDesc.IsArray = wire.IsArray;
		secCreateDesc.CompoundingCtxt = wire.getCompoundingCtxt();
		IList propDescs = wire.getPropDescs();
		secCreateDesc.PropDescs = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.PropDesc[propDescs.Count];
		for (int i = 0; i < propDescs.Count; i++)
		{
			secCreateDesc.PropDescs[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Propdescriptor.PropDesc)propDescs[i], modelManager);
		}
		secCreateDesc.SecondaryCreateDescs = toLocalSecCreateDescMap(wire.getSecondaryCreateDescs(), modelManager);
		return secCreateDesc;
	}

	public static ArrayList toWireSecCreateDescMap(IDictionary SecCreateDescMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in SecCreateDescMap)
		{
			object key = item.Key;
			object value = item.Value;
			SecCreateDescMap secCreateDescMap = new SecCreateDescMap();
			secCreateDescMap.setKey(Convert.ToString(key));
			IList value2 = secCreateDescMap.getValue();
			Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc[] array = (Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			secCreateDescMap.setValue((ArrayList)value2);
			arrayList.Add(secCreateDescMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalSecCreateDescMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			SecCreateDescMap secCreateDescMap = (SecCreateDescMap)wire[i];
			string key = secCreateDescMap.getKey();
			IList value = secCreateDescMap.getValue();
			Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc[] array = new Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.SecCreateDesc[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2008_06.Propdescriptor.SecCreateDesc)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDescResponse GetCreateDesc(string[] BusinessObjectTypeNames)
	{
		try
		{
			restSender.PushRequestId();
			GetCreateDescInput getCreateDescInput = new GetCreateDescInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < BusinessObjectTypeNames.Length; i++)
			{
				arrayList.Add(BusinessObjectTypeNames[i]);
			}
			getCreateDescInput.setBusinessObjectTypeNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDescResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(PROPDESCRIPTOR_200806_PORT_NAME, "GetCreateDesc", getCreateDescInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDescResponse wire = (Teamcenter.Schemas.Core._2008_06.Propdescriptor.CreateDescResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.PropDescriptor.CreateDescResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.AttachedPropDescsResponse toLocal(Teamcenter.Schemas.Core._2011_06.Propdescriptor.AttachedPropDescsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.AttachedPropDescsResponse attachedPropDescsResponse = new Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.AttachedPropDescsResponse();
		attachedPropDescsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		attachedPropDescsResponse.InputTypeNameToPropDescOutput = toLocalInputTypeNameToPropDescOutputMap2(wire.getInputTypeNameToPropDescOutput(), modelManager);
		return attachedPropDescsResponse;
	}

	public static Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDesc toWire(Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDesc local)
	{
		Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDesc propDesc = new Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDesc();
		propDesc.setPropName(local.PropName);
		propDesc.setDisplayName(local.DisplayName);
		propDesc.setDefaultValue(local.DefaultValue);
		propDesc.setPropValueType(local.PropValueType);
		propDesc.setPropType(local.PropType);
		propDesc.setIsDisplayable(local.IsDisplayable);
		propDesc.setIsArray(local.IsArray);
		propDesc.setMaxNumElems(local.MaxNumElems);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		propDesc.setLov(modelObject);
		propDesc.setIsRequired(local.IsRequired);
		propDesc.setIsEnabled(local.IsEnabled);
		propDesc.setIsModifiable(local.IsModifiable);
		propDesc.setAttachedSpecifier(local.AttachedSpecifier);
		propDesc.setMaxLength(local.MaxLength);
		propDesc.setLovAttachmentsCategory(local.LovAttachmentsCategory);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.InterdependentProps.Length; i++)
		{
			arrayList.Add(local.InterdependentProps[i]);
		}
		propDesc.setInterdependentProps(arrayList);
		return propDesc;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDesc toLocal(Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDesc wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDesc propDesc = new Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDesc();
		propDesc.PropName = wire.getPropName();
		propDesc.DisplayName = wire.getDisplayName();
		propDesc.DefaultValue = wire.getDefaultValue();
		propDesc.PropValueType = wire.getPropValueType();
		propDesc.PropType = wire.getPropType();
		propDesc.IsDisplayable = wire.IsDisplayable;
		propDesc.IsArray = wire.IsArray;
		propDesc.MaxNumElems = wire.getMaxNumElems();
		propDesc.Lov = (ListOfValues)modelManager.LoadObjectData(wire.getLov());
		propDesc.IsRequired = wire.IsRequired;
		propDesc.IsEnabled = wire.IsEnabled;
		propDesc.IsModifiable = wire.IsModifiable;
		propDesc.AttachedSpecifier = wire.getAttachedSpecifier();
		propDesc.MaxLength = wire.getMaxLength();
		propDesc.LovAttachmentsCategory = wire.getLovAttachmentsCategory();
		IList interdependentProps = wire.getInterdependentProps();
		propDesc.InterdependentProps = new string[interdependentProps.Count];
		for (int i = 0; i < interdependentProps.Count; i++)
		{
			propDesc.InterdependentProps[i] = Convert.ToString(interdependentProps[i]);
		}
		return propDesc;
	}

	public static Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDescOutput2 toWire(Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2 local)
	{
		Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDescOutput2 propDescOutput = new Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDescOutput2();
		propDescOutput.setPropName(local.PropName);
		propDescOutput.setPropertyDesc(toWire(local.PropertyDesc));
		return propDescOutput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2 toLocal(Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDescOutput2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2 propDescOutput = new Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2();
		propDescOutput.PropName = wire.getPropName();
		propDescOutput.PropertyDesc = toLocal(wire.getPropertyDesc(), modelManager);
		return propDescOutput;
	}

	public static ArrayList toWireInputTypeNameToPropDescOutputMap2(IDictionary InputTypeNameToPropDescOutputMap2)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in InputTypeNameToPropDescOutputMap2)
		{
			object key = item.Key;
			object value = item.Value;
			InputTypeNameToPropDescOutputMap2 inputTypeNameToPropDescOutputMap = new InputTypeNameToPropDescOutputMap2();
			inputTypeNameToPropDescOutputMap.setKey(Convert.ToString(key));
			IList value2 = inputTypeNameToPropDescOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2[] array = (Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			inputTypeNameToPropDescOutputMap.setValue((ArrayList)value2);
			arrayList.Add(inputTypeNameToPropDescOutputMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalInputTypeNameToPropDescOutputMap2(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			InputTypeNameToPropDescOutputMap2 inputTypeNameToPropDescOutputMap = (InputTypeNameToPropDescOutputMap2)wire[i];
			string key = inputTypeNameToPropDescOutputMap.getKey();
			IList value = inputTypeNameToPropDescOutputMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2[] array = new Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.PropDescOutput2[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2011_06.Propdescriptor.PropDescOutput2)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.AttachedPropDescsResponse GetAttachedPropDescs2(Teamcenter.Services.Strong.Core._2007_06.PropDescriptor.PropDescInfo[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetAttachedPropDescs2Input getAttachedPropDescs2Input = new GetAttachedPropDescs2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getAttachedPropDescs2Input.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Propdescriptor.AttachedPropDescsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(PROPDESCRIPTOR_201106_PORT_NAME, "GetAttachedPropDescs2", getAttachedPropDescs2Input, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2011_06.Propdescriptor.AttachedPropDescsResponse wire = (Teamcenter.Schemas.Core._2011_06.Propdescriptor.AttachedPropDescsResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.PropDescriptor.AttachedPropDescsResponse result = toLocal(wire, modelManager);
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
