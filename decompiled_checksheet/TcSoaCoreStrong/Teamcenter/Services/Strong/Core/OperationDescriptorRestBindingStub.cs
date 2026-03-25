using System;
using System.Collections;
using Teamcenter.Schemas.Core._2011_06.Operationdescriptor;
using Teamcenter.Schemas.Core._2012_02.Operationdescriptor;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor;
using Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class OperationDescriptorRestBindingStub : OperationDescriptorService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Connection localConnection;

	private static readonly string OPERATIONDESCRIPTOR_201106_PORT_NAME = "Core-2011-06-OperationDescriptor";

	private static readonly string OPERATIONDESCRIPTOR_201202_PORT_NAME = "Core-2012-02-OperationDescriptor";

	public OperationDescriptorRestBindingStub(Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsInput toWire(Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsInput local)
	{
		Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsInput saveAsInput = new Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsInput();
		saveAsInput.setBoName(local.BoName);
		saveAsInput.setStringProps(toWireStringMap(local.StringProps));
		saveAsInput.setStringArrayProps(toWireStringVectorMap(local.StringArrayProps));
		saveAsInput.setDoubleProps(toWireDoubleMap(local.DoubleProps));
		saveAsInput.setDoubleArrayProps(toWireDoubleVectorMap(local.DoubleArrayProps));
		saveAsInput.setFloatProps(toWireFloatMap(local.FloatProps));
		saveAsInput.setFloatArrayProps(toWireFloatVectorMap(local.FloatArrayProps));
		saveAsInput.setIntProps(toWireIntMap(local.IntProps));
		saveAsInput.setIntArrayProps(toWireIntVectorMap(local.IntArrayProps));
		saveAsInput.setBoolProps(toWireBoolMap(local.BoolProps));
		saveAsInput.setBoolArrayProps(toWireBoolVectorMap(local.BoolArrayProps));
		saveAsInput.setDateProps(toWireDateMap(local.DateProps));
		saveAsInput.setDateArrayProps(toWireDateVectorMap(local.DateArrayProps));
		saveAsInput.setTagProps(toWireTagMap(local.TagProps));
		saveAsInput.setTagArrayProps(toWireTagVectorMap(local.TagArrayProps));
		return saveAsInput;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsInput toLocal(Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsInput saveAsInput = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsInput();
		saveAsInput.BoName = wire.getBoName();
		saveAsInput.StringProps = toLocalStringMap(wire.getStringProps(), modelManager);
		saveAsInput.StringArrayProps = toLocalStringVectorMap(wire.getStringArrayProps(), modelManager);
		saveAsInput.DoubleProps = toLocalDoubleMap(wire.getDoubleProps(), modelManager);
		saveAsInput.DoubleArrayProps = toLocalDoubleVectorMap(wire.getDoubleArrayProps(), modelManager);
		saveAsInput.FloatProps = toLocalFloatMap(wire.getFloatProps(), modelManager);
		saveAsInput.FloatArrayProps = toLocalFloatVectorMap(wire.getFloatArrayProps(), modelManager);
		saveAsInput.IntProps = toLocalIntMap(wire.getIntProps(), modelManager);
		saveAsInput.IntArrayProps = toLocalIntVectorMap(wire.getIntArrayProps(), modelManager);
		saveAsInput.BoolProps = toLocalBoolMap(wire.getBoolProps(), modelManager);
		saveAsInput.BoolArrayProps = toLocalBoolVectorMap(wire.getBoolArrayProps(), modelManager);
		saveAsInput.DateProps = toLocalDateMap(wire.getDateProps(), modelManager);
		saveAsInput.DateArrayProps = toLocalDateVectorMap(wire.getDateArrayProps(), modelManager);
		saveAsInput.TagProps = toLocalTagMap(wire.getTagProps(), modelManager);
		saveAsInput.TagArrayProps = toLocalTagVectorMap(wire.getTagArrayProps(), modelManager);
		return saveAsInput;
	}

	public static Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData toWire(Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData local)
	{
		Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData deepCopyData = new Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData();
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

	public static Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData toLocal(Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData deepCopyData = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData();
		deepCopyData.AttachedObject = modelManager.LoadObjectData(wire.getAttachedObject());
		deepCopyData.PropertyName = wire.getPropertyName();
		deepCopyData.PropertyType = wire.getPropertyType();
		deepCopyData.CopyAction = wire.getCopyAction();
		deepCopyData.IsTargetPrimary = wire.IsTargetPrimary;
		deepCopyData.IsRequired = wire.IsRequired;
		deepCopyData.CopyRelations = wire.CopyRelations;
		deepCopyData.SaveAsInputTypeName = wire.getSaveAsInputTypeName();
		IList childDeepCopyData = wire.getChildDeepCopyData();
		deepCopyData.ChildDeepCopyData = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[childDeepCopyData.Count];
		for (int i = 0; i < childDeepCopyData.Count; i++)
		{
			deepCopyData.ChildDeepCopyData[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData)childDeepCopyData[i], modelManager);
		}
		deepCopyData.SaveAsInput = toLocal(wire.getSaveAsInput(), modelManager);
		return deepCopyData;
	}

	public static Teamcenter.Schemas.Core._2011_06.Operationdescriptor.PropDescSaveAs toWire(Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.PropDescSaveAs local)
	{
		Teamcenter.Schemas.Core._2011_06.Operationdescriptor.PropDescSaveAs propDescSaveAs = new Teamcenter.Schemas.Core._2011_06.Operationdescriptor.PropDescSaveAs();
		propDescSaveAs.setParent(PropDescriptorRestBindingStub.toWire(local.Parent));
		propDescSaveAs.setCopyFromOriginal(local.CopyFromOriginal);
		return propDescSaveAs;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.PropDescSaveAs toLocal(Teamcenter.Schemas.Core._2011_06.Operationdescriptor.PropDescSaveAs wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.PropDescSaveAs propDescSaveAs = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.PropDescSaveAs();
		propDescSaveAs.Parent = PropDescriptorRestBindingStub.toLocal(wire.getParent(), modelManager);
		propDescSaveAs.CopyFromOriginal = wire.CopyFromOriginal;
		return propDescSaveAs;
	}

	public static Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDesc toWire(Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDesc local)
	{
		Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDesc saveAsDesc = new Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDesc();
		saveAsDesc.setBusinessObjectName(local.BusinessObjectName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PropDescs.Length; i++)
		{
			arrayList.Add(toWire(local.PropDescs[i]));
		}
		saveAsDesc.setPropDescs(arrayList);
		return saveAsDesc;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDesc toLocal(Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDesc wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDesc saveAsDesc = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDesc();
		saveAsDesc.BusinessObjectName = wire.getBusinessObjectName();
		IList propDescs = wire.getPropDescs();
		saveAsDesc.PropDescs = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.PropDescSaveAs[propDescs.Count];
		for (int i = 0; i < propDescs.Count; i++)
		{
			saveAsDesc.PropDescs[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Operationdescriptor.PropDescSaveAs)propDescs[i], modelManager);
		}
		return saveAsDesc;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDescResponse toLocal(Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDescResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDescResponse saveAsDescResponse = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDescResponse();
		saveAsDescResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		saveAsDescResponse.SaveAsDescMap = toLocalSaveAsDescMap(wire.getSaveAsDescMap(), modelManager);
		saveAsDescResponse.DeepCopyInfoMap = toLocalDeepCopyInfoMap(wire.getDeepCopyInfoMap(), modelManager);
		return saveAsDescResponse;
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

	public static ArrayList toWireDeepCopyInfoMap(IDictionary DeepCopyInfoMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DeepCopyInfoMap)
		{
			object key = item.Key;
			object value = item.Value;
			DeepCopyInfoMap deepCopyInfoMap = new DeepCopyInfoMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			deepCopyInfoMap.setKey(modelObject);
			IList value2 = deepCopyInfoMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[] array = (Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			deepCopyInfoMap.setValue((ArrayList)value2);
			arrayList.Add(deepCopyInfoMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDeepCopyInfoMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DeepCopyInfoMap deepCopyInfoMap = (DeepCopyInfoMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(deepCopyInfoMap.getKey());
			IList value = deepCopyInfoMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[] array = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData)value[j], modelManager);
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

	public static ArrayList toWireSaveAsDescMap(IDictionary SaveAsDescMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in SaveAsDescMap)
		{
			object key = item.Key;
			object value = item.Value;
			SaveAsDescMap saveAsDescMap = new SaveAsDescMap();
			saveAsDescMap.setKey(Convert.ToString(key));
			saveAsDescMap.setValue(toWire((Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDesc)value));
			arrayList.Add(saveAsDescMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalSaveAsDescMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			SaveAsDescMap saveAsDescMap = (SaveAsDescMap)wire[i];
			string key = saveAsDescMap.getKey();
			Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDesc value = toLocal(saveAsDescMap.getValue(), modelManager);
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

	public override Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDescResponse GetSaveAsDesc(Teamcenter.Soa.Client.Model.ModelObject[] TargetObjects)
	{
		try
		{
			restSender.PushRequestId();
			GetSaveAsDescInput getSaveAsDescInput = new GetSaveAsDescInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TargetObjects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (TargetObjects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(TargetObjects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getSaveAsDescInput.setTargetObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDescResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(OPERATIONDESCRIPTOR_201106_PORT_NAME, "GetSaveAsDesc", getSaveAsDescInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDescResponse wire = (Teamcenter.Schemas.Core._2011_06.Operationdescriptor.SaveAsDescResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.SaveAsDescResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
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

	public static Teamcenter.Schemas.Core._2012_02.Operationdescriptor.DeepCopyDataInput toWire(Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.DeepCopyDataInput local)
	{
		Teamcenter.Schemas.Core._2012_02.Operationdescriptor.DeepCopyDataInput deepCopyDataInput = new Teamcenter.Schemas.Core._2012_02.Operationdescriptor.DeepCopyDataInput();
		deepCopyDataInput.setOperation(local.Operation);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		deepCopyDataInput.setObject(modelObject);
		return deepCopyDataInput;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.DeepCopyDataInput toLocal(Teamcenter.Schemas.Core._2012_02.Operationdescriptor.DeepCopyDataInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.DeepCopyDataInput deepCopyDataInput = new Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.DeepCopyDataInput();
		deepCopyDataInput.Operation = wire.getOperation();
		deepCopyDataInput.Object = modelManager.LoadObjectData(wire.getObject());
		return deepCopyDataInput;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.GetDeepCopyDataResponse toLocal(Teamcenter.Schemas.Core._2012_02.Operationdescriptor.GetDeepCopyDataResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.GetDeepCopyDataResponse getDeepCopyDataResponse = new Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.GetDeepCopyDataResponse();
		getDeepCopyDataResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getDeepCopyDataResponse.DeepCopyInfoMap = toLocalDeepCopyInfoMap2(wire.getDeepCopyInfoMap(), modelManager);
		return getDeepCopyDataResponse;
	}

	public static ArrayList toWireDeepCopyInfoMap2(IDictionary DeepCopyInfoMap2)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DeepCopyInfoMap2)
		{
			object key = item.Key;
			object value = item.Value;
			DeepCopyInfoMap2 deepCopyInfoMap = new DeepCopyInfoMap2();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			deepCopyInfoMap.setKey(modelObject);
			IList value2 = deepCopyInfoMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[] array = (Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			deepCopyInfoMap.setValue((ArrayList)value2);
			arrayList.Add(deepCopyInfoMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDeepCopyInfoMap2(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DeepCopyInfoMap2 deepCopyInfoMap = (DeepCopyInfoMap2)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(deepCopyInfoMap.getKey());
			IList value = deepCopyInfoMap.getValue();
			Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[] array = new Teamcenter.Services.Strong.Core._2011_06.OperationDescriptor.DeepCopyData[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Core._2011_06.Operationdescriptor.DeepCopyData)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.GetDeepCopyDataResponse GetDeepCopyData(Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.DeepCopyDataInput[] DeepCopyDataInput)
	{
		try
		{
			restSender.PushRequestId();
			GetDeepCopyDataInput getDeepCopyDataInput = new GetDeepCopyDataInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < DeepCopyDataInput.Length; i++)
			{
				arrayList.Add(toWire(DeepCopyDataInput[i]));
			}
			getDeepCopyDataInput.setDeepCopyDataInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_02.Operationdescriptor.GetDeepCopyDataResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(OPERATIONDESCRIPTOR_201202_PORT_NAME, "GetDeepCopyData", getDeepCopyDataInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_02.Operationdescriptor.GetDeepCopyDataResponse wire = (Teamcenter.Schemas.Core._2012_02.Operationdescriptor.GetDeepCopyDataResponse)obj;
			Teamcenter.Services.Strong.Core._2012_02.OperationDescriptor.GetDeepCopyDataResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
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
