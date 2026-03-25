using System;
using System.Collections;
using Teamcenter.Schemas.Query._2006_03.Savedquery;
using Teamcenter.Schemas.Query._2007_01.Savedquery;
using Teamcenter.Schemas.Query._2007_06.Savedquery;
using Teamcenter.Schemas.Query._2007_09.Savedquery;
using Teamcenter.Schemas.Query._2008_06.Savedquery;
using Teamcenter.Schemas.Query._2010_04.Savedquery;
using Teamcenter.Schemas.Query._2010_09.Savedquery;
using Teamcenter.Schemas.Query._2013_05.Savedquery;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Query._2006_03.SavedQuery;
using Teamcenter.Services.Strong.Query._2007_01.SavedQuery;
using Teamcenter.Services.Strong.Query._2007_06.SavedQuery;
using Teamcenter.Services.Strong.Query._2007_09.SavedQuery;
using Teamcenter.Services.Strong.Query._2008_06.SavedQuery;
using Teamcenter.Services.Strong.Query._2010_04.SavedQuery;
using Teamcenter.Services.Strong.Query._2010_09.SavedQuery;
using Teamcenter.Services.Strong.Query._2013_05.SavedQuery;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Query;

public class SavedQueryRestBindingStub : SavedQueryService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string SAVEDQUERY_200603_PORT_NAME = "Query-2006-03-SavedQuery";

	private static readonly string SAVEDQUERY_200701_PORT_NAME = "Query-2007-01-SavedQuery";

	private static readonly string SAVEDQUERY_200706_PORT_NAME = "Query-2007-06-SavedQuery";

	private static readonly string SAVEDQUERY_200709_PORT_NAME = "Query-2007-09-SavedQuery";

	private static readonly string SAVEDQUERY_200806_PORT_NAME = "Query-2008-06-SavedQuery";

	private static readonly string SAVEDQUERY_201004_PORT_NAME = "Query-2010-04-SavedQuery";

	private static readonly string SAVEDQUERY_201009_PORT_NAME = "Query-2010-09-SavedQuery";

	private static readonly string SAVEDQUERY_201305_PORT_NAME = "Query-2013-05-SavedQuery";

	public SavedQueryRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Services.Strong.Query._2006_03.SavedQuery.DescribeSavedQueriesResponse toLocal(Teamcenter.Schemas.Query._2006_03.Savedquery.DescribeSavedQueriesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2006_03.SavedQuery.DescribeSavedQueriesResponse describeSavedQueriesResponse = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.DescribeSavedQueriesResponse();
		describeSavedQueriesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList fieldLists = wire.getFieldLists();
		describeSavedQueriesResponse.FieldLists = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldListObject[fieldLists.Count];
		for (int i = 0; i < fieldLists.Count; i++)
		{
			describeSavedQueriesResponse.FieldLists[i] = toLocal((Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldListObject)fieldLists[i], modelManager);
		}
		return describeSavedQueriesResponse;
	}

	public static Teamcenter.Services.Strong.Query._2006_03.SavedQuery.ExecuteSavedQueryResponse toLocal(Teamcenter.Schemas.Query._2006_03.Savedquery.ExecuteSavedQueryResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2006_03.SavedQuery.ExecuteSavedQueryResponse executeSavedQueryResponse = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.ExecuteSavedQueryResponse();
		executeSavedQueryResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		executeSavedQueryResponse.NFound = wire.getNFound();
		IList objects = wire.getObjects();
		executeSavedQueryResponse.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			executeSavedQueryResponse.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		return executeSavedQueryResponse;
	}

	public static Teamcenter.Services.Strong.Query._2006_03.SavedQuery.GetSavedQueriesResponse toLocal(Teamcenter.Schemas.Query._2006_03.Savedquery.GetSavedQueriesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2006_03.SavedQuery.GetSavedQueriesResponse getSavedQueriesResponse = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.GetSavedQueriesResponse();
		getSavedQueriesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList queries = wire.getQueries();
		getSavedQueriesResponse.Queries = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryObject[queries.Count];
		for (int i = 0; i < queries.Count; i++)
		{
			getSavedQueriesResponse.Queries[i] = toLocal((Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryObject)queries[i], modelManager);
		}
		return getSavedQueriesResponse;
	}

	public static Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldListObject toWire(Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldListObject local)
	{
		Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldListObject savedQueryFieldListObject = new Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldListObject();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Fields.Length; i++)
		{
			arrayList.Add(toWire(local.Fields[i]));
		}
		savedQueryFieldListObject.setFields(arrayList);
		return savedQueryFieldListObject;
	}

	public static Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldListObject toLocal(Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldListObject wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldListObject savedQueryFieldListObject = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldListObject();
		IList fields = wire.getFields();
		savedQueryFieldListObject.Fields = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldObject[fields.Count];
		for (int i = 0; i < fields.Count; i++)
		{
			savedQueryFieldListObject.Fields[i] = toLocal((Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldObject)fields[i], modelManager);
		}
		return savedQueryFieldListObject;
	}

	public static Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldObject toWire(Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldObject local)
	{
		Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldObject savedQueryFieldObject = new Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldObject();
		savedQueryFieldObject.setAttributeName(local.AttributeName);
		savedQueryFieldObject.setEntryName(local.EntryName);
		savedQueryFieldObject.setLogicalOperation(local.LogicalOperation);
		savedQueryFieldObject.setMathOperation(local.MathOperation);
		savedQueryFieldObject.setValue(local.Value);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Lov == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Lov.Uid);
		}
		savedQueryFieldObject.setLov(modelObject);
		savedQueryFieldObject.setAttributeType(local.AttributeType);
		return savedQueryFieldObject;
	}

	public static Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldObject toLocal(Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryFieldObject wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldObject savedQueryFieldObject = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryFieldObject();
		savedQueryFieldObject.AttributeName = wire.getAttributeName();
		savedQueryFieldObject.EntryName = wire.getEntryName();
		savedQueryFieldObject.LogicalOperation = wire.getLogicalOperation();
		savedQueryFieldObject.MathOperation = wire.getMathOperation();
		savedQueryFieldObject.Value = wire.getValue();
		savedQueryFieldObject.Lov = modelManager.LoadObjectData(wire.getLov());
		savedQueryFieldObject.AttributeType = wire.getAttributeType();
		return savedQueryFieldObject;
	}

	public static Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryObject toWire(Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryObject local)
	{
		Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryObject savedQueryObject = new Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryObject();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Query == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Query.Uid);
		}
		savedQueryObject.setQuery(modelObject);
		savedQueryObject.setName(local.Name);
		savedQueryObject.setDescription(local.Description);
		return savedQueryObject;
	}

	public static Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryObject toLocal(Teamcenter.Schemas.Query._2006_03.Savedquery.SavedQueryObject wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryObject savedQueryObject = new Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQueryObject();
		savedQueryObject.Query = (ImanQuery)modelManager.LoadObjectData(wire.getQuery());
		savedQueryObject.Name = wire.getName();
		savedQueryObject.Description = wire.getDescription();
		return savedQueryObject;
	}

	public override Teamcenter.Services.Strong.Query._2006_03.SavedQuery.DescribeSavedQueriesResponse DescribeSavedQueries(ImanQuery[] Queries)
	{
		try
		{
			restSender.PushRequestId();
			DescribeSavedQueriesInput describeSavedQueriesInput = new DescribeSavedQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Queries.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Queries[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Queries[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			describeSavedQueriesInput.setQueries(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2006_03.Savedquery.DescribeSavedQueriesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_200603_PORT_NAME, "DescribeSavedQueries", describeSavedQueriesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2006_03.Savedquery.DescribeSavedQueriesResponse wire = (Teamcenter.Schemas.Query._2006_03.Savedquery.DescribeSavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2006_03.SavedQuery.DescribeSavedQueriesResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of tc2007, use the executeSavedQueries operation from the _2007_06 namespace.", false)]
	public override Teamcenter.Services.Strong.Query._2006_03.SavedQuery.ExecuteSavedQueryResponse ExecuteSavedQuery(ImanQuery Query, string[] Entries, string[] Values, int Limit)
	{
		try
		{
			restSender.PushRequestId();
			ExecuteSavedQueryInput executeSavedQueryInput = new ExecuteSavedQueryInput();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Query == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(Query.Uid);
			}
			executeSavedQueryInput.setQuery(modelObject);
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Entries.Length; i++)
			{
				arrayList.Add(Entries[i]);
			}
			executeSavedQueryInput.setEntries(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < Values.Length; i++)
			{
				arrayList2.Add(Values[i]);
			}
			executeSavedQueryInput.setValues(arrayList2);
			executeSavedQueryInput.setLimit(Limit);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2006_03.Savedquery.ExecuteSavedQueryResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_200603_PORT_NAME, "ExecuteSavedQuery", executeSavedQueryInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Query._2006_03.Savedquery.ExecuteSavedQueryResponse wire = (Teamcenter.Schemas.Query._2006_03.Savedquery.ExecuteSavedQueryResponse)obj;
			Teamcenter.Services.Strong.Query._2006_03.SavedQuery.ExecuteSavedQueryResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Query._2006_03.SavedQuery.GetSavedQueriesResponse GetSavedQueries()
	{
		try
		{
			restSender.PushRequestId();
			GetSavedQueriesInput requestObject = new GetSavedQueriesInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2006_03.Savedquery.GetSavedQueriesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_200603_PORT_NAME, "GetSavedQueries", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Query._2006_03.Savedquery.GetSavedQueriesResponse wire = (Teamcenter.Schemas.Query._2006_03.Savedquery.GetSavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2006_03.SavedQuery.GetSavedQueriesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Services.Strong.Query._2007_01.SavedQuery.RetrieveQueryCriteriaResponse toLocal(Teamcenter.Schemas.Query._2007_01.Savedquery.RetrieveQueryCriteriaResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_01.SavedQuery.RetrieveQueryCriteriaResponse retrieveQueryCriteriaResponse = new Teamcenter.Services.Strong.Query._2007_01.SavedQuery.RetrieveQueryCriteriaResponse();
		retrieveQueryCriteriaResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		retrieveQueryCriteriaResponse.Output = new Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SaveQueryCriteriaInfo[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			retrieveQueryCriteriaResponse.Output[i] = toLocal((Teamcenter.Schemas.Query._2007_01.Savedquery.SaveQueryCriteriaInfo)output[i], modelManager);
		}
		return retrieveQueryCriteriaResponse;
	}

	public static Teamcenter.Schemas.Query._2007_01.Savedquery.SaveQueryCriteriaInfo toWire(Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SaveQueryCriteriaInfo local)
	{
		Teamcenter.Schemas.Query._2007_01.Savedquery.SaveQueryCriteriaInfo saveQueryCriteriaInfo = new Teamcenter.Schemas.Query._2007_01.Savedquery.SaveQueryCriteriaInfo();
		saveQueryCriteriaInfo.setSearchName(local.SearchName);
		saveQueryCriteriaInfo.setQueryName(local.QueryName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Keys.Length; i++)
		{
			arrayList.Add(local.Keys[i]);
		}
		saveQueryCriteriaInfo.setKeys(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList2.Add(local.Values[i]);
		}
		saveQueryCriteriaInfo.setValues(arrayList2);
		return saveQueryCriteriaInfo;
	}

	public static Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SaveQueryCriteriaInfo toLocal(Teamcenter.Schemas.Query._2007_01.Savedquery.SaveQueryCriteriaInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SaveQueryCriteriaInfo saveQueryCriteriaInfo = new Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SaveQueryCriteriaInfo();
		saveQueryCriteriaInfo.SearchName = wire.getSearchName();
		saveQueryCriteriaInfo.QueryName = wire.getQueryName();
		IList keys = wire.getKeys();
		saveQueryCriteriaInfo.Keys = new string[keys.Count];
		for (int i = 0; i < keys.Count; i++)
		{
			saveQueryCriteriaInfo.Keys[i] = Convert.ToString(keys[i]);
		}
		IList values = wire.getValues();
		saveQueryCriteriaInfo.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			saveQueryCriteriaInfo.Values[i] = Convert.ToString(values[i]);
		}
		return saveQueryCriteriaInfo;
	}

	[Obsolete("As of Teamcenter 8.1, use the deleteObjects operation.", false)]
	public override Teamcenter.Soa.Client.Model.ServiceData DeleteQueryCriterias(string[] QueryCriteriaNames)
	{
		try
		{
			restSender.PushRequestId();
			DeleteQueryCriteriasInput deleteQueryCriteriasInput = new DeleteQueryCriteriasInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < QueryCriteriaNames.Length; i++)
			{
				arrayList.Add(QueryCriteriaNames[i]);
			}
			deleteQueryCriteriasInput.setQueryCriteriaNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_200701_PORT_NAME, "DeleteQueryCriterias", deleteQueryCriteriasInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
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

	[Obsolete("As of Teamcenter 8.1, there is no replacement.", false)]
	public override Teamcenter.Soa.Client.Model.ServiceData ReorderSavedQueryCriterias(string[] QueryCriteriaNames)
	{
		try
		{
			restSender.PushRequestId();
			ReorderSavedQueryCriteriasInput reorderSavedQueryCriteriasInput = new ReorderSavedQueryCriteriasInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < QueryCriteriaNames.Length; i++)
			{
				arrayList.Add(QueryCriteriaNames[i]);
			}
			reorderSavedQueryCriteriasInput.setQueryCriteriaNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_200701_PORT_NAME, "ReorderSavedQueryCriterias", reorderSavedQueryCriteriasInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
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

	[Obsolete("As of tc2007.1, use the retrieveSearchCriteria operation from  the _2007_06 namespace.", false)]
	public override Teamcenter.Services.Strong.Query._2007_01.SavedQuery.RetrieveQueryCriteriaResponse RetrieveQueryCriterias(string[] QueryCriteriaNames)
	{
		try
		{
			restSender.PushRequestId();
			RetrieveQueryCriteriasInput retrieveQueryCriteriasInput = new RetrieveQueryCriteriasInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < QueryCriteriaNames.Length; i++)
			{
				arrayList.Add(QueryCriteriaNames[i]);
			}
			retrieveQueryCriteriasInput.setQueryCriteriaNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_01.Savedquery.RetrieveQueryCriteriaResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_200701_PORT_NAME, "RetrieveQueryCriterias", retrieveQueryCriteriasInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Query._2007_01.Savedquery.RetrieveQueryCriteriaResponse wire = (Teamcenter.Schemas.Query._2007_01.Savedquery.RetrieveQueryCriteriaResponse)obj;
			Teamcenter.Services.Strong.Query._2007_01.SavedQuery.RetrieveQueryCriteriaResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of tc2007.1, use the saveSearchCriteria operation from the _2007_06 namespace.", false)]
	public override Teamcenter.Soa.Client.Model.ServiceData SaveQueryCriterias(Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SaveQueryCriteriaInfo[] QueryCriterias)
	{
		try
		{
			restSender.PushRequestId();
			SaveQueryCriteriasInput saveQueryCriteriasInput = new SaveQueryCriteriasInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < QueryCriterias.Length; i++)
			{
				arrayList.Add(toWire(QueryCriterias[i]));
			}
			saveQueryCriteriasInput.setQueryCriterias(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_200701_PORT_NAME, "SaveQueryCriterias", saveQueryCriteriasInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
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

	public static Teamcenter.Services.Strong.Query._2007_06.SavedQuery.ExecuteSavedQueriesResponse toLocal(Teamcenter.Schemas.Query._2007_06.Savedquery.ExecuteSavedQueriesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.SavedQuery.ExecuteSavedQueriesResponse executeSavedQueriesResponse = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.ExecuteSavedQueriesResponse();
		executeSavedQueriesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList arrayOfResults = wire.getArrayOfResults();
		executeSavedQueriesResponse.ArrayOfResults = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryResults[arrayOfResults.Count];
		for (int i = 0; i < arrayOfResults.Count; i++)
		{
			executeSavedQueriesResponse.ArrayOfResults[i] = toLocal((Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryResults)arrayOfResults[i], modelManager);
		}
		return executeSavedQueriesResponse;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.SavedQuery.RetrieveSearchCriteriaResponse toLocal(Teamcenter.Schemas.Query._2007_06.Savedquery.RetrieveSearchCriteriaResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.SavedQuery.RetrieveSearchCriteriaResponse retrieveSearchCriteriaResponse = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.RetrieveSearchCriteriaResponse();
		retrieveSearchCriteriaResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		retrieveSearchCriteriaResponse.Output = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SaveSearchCriteriaInfo[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			retrieveSearchCriteriaResponse.Output[i] = toLocal((Teamcenter.Schemas.Query._2007_06.Savedquery.SaveSearchCriteriaInfo)output[i], modelManager);
		}
		return retrieveSearchCriteriaResponse;
	}

	public static Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryInput toWire(Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryInput local)
	{
		Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryInput savedQueryInput = new Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Query == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Query.Uid);
		}
		savedQueryInput.setQuery(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Entries.Length; i++)
		{
			arrayList.Add(local.Entries[i]);
		}
		savedQueryInput.setEntries(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList2.Add(local.Values[i]);
		}
		savedQueryInput.setValues(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.LimitList.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.LimitList[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.LimitList[i].Uid);
			}
			arrayList3.Add(modelObject2);
		}
		savedQueryInput.setLimitList(arrayList3);
		savedQueryInput.setLimitListCount(local.LimitListCount);
		savedQueryInput.setMaxNumToReturn(local.MaxNumToReturn);
		savedQueryInput.setResultsType(local.ResultsType);
		savedQueryInput.setMaxNumToInflate(local.MaxNumToInflate);
		return savedQueryInput;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryInput toLocal(Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryInput savedQueryInput = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryInput();
		savedQueryInput.Query = (ImanQuery)modelManager.LoadObjectData(wire.getQuery());
		IList entries = wire.getEntries();
		savedQueryInput.Entries = new string[entries.Count];
		for (int i = 0; i < entries.Count; i++)
		{
			savedQueryInput.Entries[i] = Convert.ToString(entries[i]);
		}
		IList values = wire.getValues();
		savedQueryInput.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			savedQueryInput.Values[i] = Convert.ToString(values[i]);
		}
		IList limitList = wire.getLimitList();
		savedQueryInput.LimitList = new Teamcenter.Soa.Client.Model.ModelObject[limitList.Count];
		for (int i = 0; i < limitList.Count; i++)
		{
			savedQueryInput.LimitList[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)limitList[i]);
		}
		savedQueryInput.LimitListCount = wire.getLimitListCount();
		savedQueryInput.MaxNumToReturn = wire.getMaxNumToReturn();
		savedQueryInput.ResultsType = wire.getResultsType();
		savedQueryInput.MaxNumToInflate = wire.getMaxNumToInflate();
		return savedQueryInput;
	}

	public static Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryResults toWire(Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryResults local)
	{
		Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryResults savedQueryResults = new Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryResults();
		savedQueryResults.setNumOfObjects(local.NumOfObjects);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectsRelMap.Length; i++)
		{
			arrayList.Add(local.ObjectsRelMap[i]);
		}
		savedQueryResults.setObjectsRelMap(arrayList);
		ArrayList arrayList2 = new ArrayList();
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
			arrayList2.Add(modelObject);
		}
		savedQueryResults.setObjects(arrayList2);
		return savedQueryResults;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryResults toLocal(Teamcenter.Schemas.Query._2007_06.Savedquery.SavedQueryResults wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryResults savedQueryResults = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryResults();
		savedQueryResults.NumOfObjects = wire.getNumOfObjects();
		IList objectsRelMap = wire.getObjectsRelMap();
		savedQueryResults.ObjectsRelMap = new int[objectsRelMap.Count];
		for (int i = 0; i < objectsRelMap.Count; i++)
		{
			savedQueryResults.ObjectsRelMap[i] = Convert.ToInt32(objectsRelMap[i]);
		}
		IList objects = wire.getObjects();
		savedQueryResults.Objects = new Teamcenter.Soa.Client.Model.ModelObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			savedQueryResults.Objects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i]);
		}
		return savedQueryResults;
	}

	public static Teamcenter.Schemas.Query._2007_06.Savedquery.SaveSearchCriteriaInfo toWire(Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SaveSearchCriteriaInfo local)
	{
		Teamcenter.Schemas.Query._2007_06.Savedquery.SaveSearchCriteriaInfo saveSearchCriteriaInfo = new Teamcenter.Schemas.Query._2007_06.Savedquery.SaveSearchCriteriaInfo();
		saveSearchCriteriaInfo.setSearchName(local.SearchName);
		saveSearchCriteriaInfo.setQueryName(local.QueryName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Keys.Length; i++)
		{
			arrayList.Add(local.Keys[i]);
		}
		saveSearchCriteriaInfo.setKeys(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList2.Add(local.Values[i]);
		}
		saveSearchCriteriaInfo.setValues(arrayList2);
		saveSearchCriteriaInfo.setResultsType(local.ResultsType);
		saveSearchCriteriaInfo.setVirtualFolderPath(local.VirtualFolderPath);
		return saveSearchCriteriaInfo;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SaveSearchCriteriaInfo toLocal(Teamcenter.Schemas.Query._2007_06.Savedquery.SaveSearchCriteriaInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SaveSearchCriteriaInfo saveSearchCriteriaInfo = new Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SaveSearchCriteriaInfo();
		saveSearchCriteriaInfo.SearchName = wire.getSearchName();
		saveSearchCriteriaInfo.QueryName = wire.getQueryName();
		IList keys = wire.getKeys();
		saveSearchCriteriaInfo.Keys = new string[keys.Count];
		for (int i = 0; i < keys.Count; i++)
		{
			saveSearchCriteriaInfo.Keys[i] = Convert.ToString(keys[i]);
		}
		IList values = wire.getValues();
		saveSearchCriteriaInfo.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			saveSearchCriteriaInfo.Values[i] = Convert.ToString(values[i]);
		}
		saveSearchCriteriaInfo.ResultsType = wire.getResultsType();
		saveSearchCriteriaInfo.VirtualFolderPath = wire.getVirtualFolderPath();
		return saveSearchCriteriaInfo;
	}

	public override Teamcenter.Services.Strong.Query._2007_06.SavedQuery.ExecuteSavedQueriesResponse ExecuteSavedQueries(Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQueryInput[] Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Query._2007_06.Savedquery.ExecuteSavedQueriesInput executeSavedQueriesInput = new Teamcenter.Schemas.Query._2007_06.Savedquery.ExecuteSavedQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			executeSavedQueriesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_06.Savedquery.ExecuteSavedQueriesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_200706_PORT_NAME, "ExecuteSavedQueries", executeSavedQueriesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2007_06.Savedquery.ExecuteSavedQueriesResponse wire = (Teamcenter.Schemas.Query._2007_06.Savedquery.ExecuteSavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2007_06.SavedQuery.ExecuteSavedQueriesResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Teamcenter 8.1, refer to Release notes on how to retrieve My Saved Searches information.", false)]
	public override Teamcenter.Services.Strong.Query._2007_06.SavedQuery.RetrieveSearchCriteriaResponse RetrieveSearchCriteria(string[] SearchNames)
	{
		try
		{
			restSender.PushRequestId();
			RetrieveSearchCriteriaInput retrieveSearchCriteriaInput = new RetrieveSearchCriteriaInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < SearchNames.Length; i++)
			{
				arrayList.Add(SearchNames[i]);
			}
			retrieveSearchCriteriaInput.setSearchNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_06.Savedquery.RetrieveSearchCriteriaResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_200706_PORT_NAME, "RetrieveSearchCriteria", retrieveSearchCriteriaInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2007_06.Savedquery.RetrieveSearchCriteriaResponse wire = (Teamcenter.Schemas.Query._2007_06.Savedquery.RetrieveSearchCriteriaResponse)obj;
			Teamcenter.Services.Strong.Query._2007_06.SavedQuery.RetrieveSearchCriteriaResponse result = toLocal(wire, modelManager);
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

	[Obsolete("As of Teamcenter 8.1, use createObjects on a SavedSearch business object.", false)]
	public override Teamcenter.Soa.Client.Model.ServiceData SaveSearchCriteria(Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SaveSearchCriteriaInfo[] SearchCriteria)
	{
		try
		{
			restSender.PushRequestId();
			SaveSearchCriteriaInput saveSearchCriteriaInput = new SaveSearchCriteriaInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < SearchCriteria.Length; i++)
			{
				arrayList.Add(toWire(SearchCriteria[i]));
			}
			saveSearchCriteriaInput.setSearchCriteria(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_200706_PORT_NAME, "SaveSearchCriteria", saveSearchCriteriaInput, typeFromHandle, extraTypes);
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

	public static Teamcenter.Schemas.Query._2007_09.Savedquery.QueryInput toWire(Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryInput local)
	{
		Teamcenter.Schemas.Query._2007_09.Savedquery.QueryInput queryInput = new Teamcenter.Schemas.Query._2007_09.Savedquery.QueryInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Query == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Query.Uid);
		}
		queryInput.setQuery(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Entries.Length; i++)
		{
			arrayList.Add(local.Entries[i]);
		}
		queryInput.setEntries(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList2.Add(local.Values[i]);
		}
		queryInput.setValues(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.LimitList.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.LimitList[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.LimitList[i].Uid);
			}
			arrayList3.Add(modelObject2);
		}
		queryInput.setLimitList(arrayList3);
		queryInput.setMaxNumToReturn(local.MaxNumToReturn);
		queryInput.setResultsType(local.ResultsType);
		return queryInput;
	}

	public static Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryInput toLocal(Teamcenter.Schemas.Query._2007_09.Savedquery.QueryInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryInput queryInput = new Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryInput();
		queryInput.Query = (ImanQuery)modelManager.LoadObjectData(wire.getQuery());
		IList entries = wire.getEntries();
		queryInput.Entries = new string[entries.Count];
		for (int i = 0; i < entries.Count; i++)
		{
			queryInput.Entries[i] = Convert.ToString(entries[i]);
		}
		IList values = wire.getValues();
		queryInput.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			queryInput.Values[i] = Convert.ToString(values[i]);
		}
		IList limitList = wire.getLimitList();
		queryInput.LimitList = new Teamcenter.Soa.Client.Model.ModelObject[limitList.Count];
		for (int i = 0; i < limitList.Count; i++)
		{
			queryInput.LimitList[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)limitList[i]);
		}
		queryInput.MaxNumToReturn = wire.getMaxNumToReturn();
		queryInput.ResultsType = wire.getResultsType();
		return queryInput;
	}

	public static Teamcenter.Schemas.Query._2007_09.Savedquery.QueryResults toWire(Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryResults local)
	{
		Teamcenter.Schemas.Query._2007_09.Savedquery.QueryResults queryResults = new Teamcenter.Schemas.Query._2007_09.Savedquery.QueryResults();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ObjectsRelMap.Length; i++)
		{
			arrayList.Add(local.ObjectsRelMap[i]);
		}
		queryResults.setObjectsRelMap(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ObjectUIDS.Length; i++)
		{
			arrayList2.Add(local.ObjectUIDS[i]);
		}
		queryResults.setObjectUIDS(arrayList2);
		return queryResults;
	}

	public static Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryResults toLocal(Teamcenter.Schemas.Query._2007_09.Savedquery.QueryResults wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryResults queryResults = new Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryResults();
		IList objectsRelMap = wire.getObjectsRelMap();
		queryResults.ObjectsRelMap = new int[objectsRelMap.Count];
		for (int i = 0; i < objectsRelMap.Count; i++)
		{
			queryResults.ObjectsRelMap[i] = Convert.ToInt32(objectsRelMap[i]);
		}
		IList objectUIDS = wire.getObjectUIDS();
		queryResults.ObjectUIDS = new string[objectUIDS.Count];
		for (int i = 0; i < objectUIDS.Count; i++)
		{
			queryResults.ObjectUIDS[i] = Convert.ToString(objectUIDS[i]);
		}
		return queryResults;
	}

	public static Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse toLocal(Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse savedQueriesResponse = new Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse();
		savedQueriesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList arrayOfResults = wire.getArrayOfResults();
		savedQueriesResponse.ArrayOfResults = new Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryResults[arrayOfResults.Count];
		for (int i = 0; i < arrayOfResults.Count; i++)
		{
			savedQueriesResponse.ArrayOfResults[i] = toLocal((Teamcenter.Schemas.Query._2007_09.Savedquery.QueryResults)arrayOfResults[i], modelManager);
		}
		return savedQueriesResponse;
	}

	[Obsolete("As of Tc 8, use the executeSavedQueries operation from the _2008_06 namespace.", false)]
	public override Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse ExecuteSavedQueries(Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryInput[] Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Query._2007_09.Savedquery.ExecuteSavedQueriesInput executeSavedQueriesInput = new Teamcenter.Schemas.Query._2007_09.Savedquery.ExecuteSavedQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			executeSavedQueriesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_200709_PORT_NAME, "ExecuteSavedQueries", executeSavedQueriesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse wire = (Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Query._2008_06.Savedquery.QueryInput toWire(Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput local)
	{
		Teamcenter.Schemas.Query._2008_06.Savedquery.QueryInput queryInput = new Teamcenter.Schemas.Query._2008_06.Savedquery.QueryInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Query == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Query.Uid);
		}
		queryInput.setQuery(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Entries.Length; i++)
		{
			arrayList.Add(local.Entries[i]);
		}
		queryInput.setEntries(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList2.Add(local.Values[i]);
		}
		queryInput.setValues(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.LimitList.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.LimitList[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.LimitList[i].Uid);
			}
			arrayList3.Add(modelObject2);
		}
		queryInput.setLimitList(arrayList3);
		queryInput.setMaxNumToReturn(local.MaxNumToReturn);
		queryInput.setResultsType(local.ResultsType);
		queryInput.setRequestId(local.RequestId);
		queryInput.setClientId(local.ClientId);
		return queryInput;
	}

	public static Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput toLocal(Teamcenter.Schemas.Query._2008_06.Savedquery.QueryInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput queryInput = new Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput();
		queryInput.Query = (ImanQuery)modelManager.LoadObjectData(wire.getQuery());
		IList entries = wire.getEntries();
		queryInput.Entries = new string[entries.Count];
		for (int i = 0; i < entries.Count; i++)
		{
			queryInput.Entries[i] = Convert.ToString(entries[i]);
		}
		IList values = wire.getValues();
		queryInput.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			queryInput.Values[i] = Convert.ToString(values[i]);
		}
		IList limitList = wire.getLimitList();
		queryInput.LimitList = new Teamcenter.Soa.Client.Model.ModelObject[limitList.Count];
		for (int i = 0; i < limitList.Count; i++)
		{
			queryInput.LimitList[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)limitList[i]);
		}
		queryInput.MaxNumToReturn = wire.getMaxNumToReturn();
		queryInput.ResultsType = wire.getResultsType();
		queryInput.RequestId = wire.getRequestId();
		queryInput.ClientId = wire.getClientId();
		return queryInput;
	}

	public override Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse ExecuteSavedQueries(Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput[] Input)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Query._2008_06.Savedquery.ExecuteSavedQueriesInput executeSavedQueriesInput = new Teamcenter.Schemas.Query._2008_06.Savedquery.ExecuteSavedQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			executeSavedQueriesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_200806_PORT_NAME, "ExecuteSavedQueries", executeSavedQueriesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse wire = (Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesCriteriaInput toWire(Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesCriteriaInput local)
	{
		Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesCriteriaInput findSavedQueriesCriteriaInput = new Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesCriteriaInput();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.QueryNames.Length; i++)
		{
			arrayList.Add(local.QueryNames[i]);
		}
		findSavedQueriesCriteriaInput.setQueryNames(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.QueryDescs.Length; i++)
		{
			arrayList2.Add(local.QueryDescs[i]);
		}
		findSavedQueriesCriteriaInput.setQueryDescs(arrayList2);
		findSavedQueriesCriteriaInput.setQueryType(local.QueryType);
		return findSavedQueriesCriteriaInput;
	}

	public static Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesCriteriaInput toLocal(Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesCriteriaInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesCriteriaInput findSavedQueriesCriteriaInput = new Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesCriteriaInput();
		IList queryNames = wire.getQueryNames();
		findSavedQueriesCriteriaInput.QueryNames = new string[queryNames.Count];
		for (int i = 0; i < queryNames.Count; i++)
		{
			findSavedQueriesCriteriaInput.QueryNames[i] = Convert.ToString(queryNames[i]);
		}
		IList queryDescs = wire.getQueryDescs();
		findSavedQueriesCriteriaInput.QueryDescs = new string[queryDescs.Count];
		for (int i = 0; i < queryDescs.Count; i++)
		{
			findSavedQueriesCriteriaInput.QueryDescs[i] = Convert.ToString(queryDescs[i]);
		}
		findSavedQueriesCriteriaInput.QueryType = wire.getQueryType();
		return findSavedQueriesCriteriaInput;
	}

	public static Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesResponse toLocal(Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesResponse findSavedQueriesResponse = new Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesResponse();
		findSavedQueriesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList savedQueries = wire.getSavedQueries();
		findSavedQueriesResponse.SavedQueries = new ImanQuery[savedQueries.Count];
		for (int i = 0; i < savedQueries.Count; i++)
		{
			findSavedQueriesResponse.SavedQueries[i] = (ImanQuery)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)savedQueries[i]);
		}
		return findSavedQueriesResponse;
	}

	public override Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesResponse FindSavedQueries(Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesCriteriaInput[] InputCriteria)
	{
		try
		{
			restSender.PushRequestId();
			FindSavedQueriesInput findSavedQueriesInput = new FindSavedQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < InputCriteria.Length; i++)
			{
				arrayList.Add(toWire(InputCriteria[i]));
			}
			findSavedQueriesInput.setInputCriteria(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SAVEDQUERY_201004_PORT_NAME, "FindSavedQueries", findSavedQueriesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesResponse wire = (Teamcenter.Schemas.Query._2010_04.Savedquery.FindSavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2010_04.SavedQuery.FindSavedQueriesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryClause toWire(Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryClause local)
	{
		Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryClause businessObjectQueryClause = new Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryClause();
		businessObjectQueryClause.setPropName(local.PropName);
		businessObjectQueryClause.setPropValue(local.PropValue);
		businessObjectQueryClause.setMathOperator(local.MathOperator);
		businessObjectQueryClause.setLogicOperator(local.LogicOperator);
		return businessObjectQueryClause;
	}

	public static Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryClause toLocal(Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryClause wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryClause businessObjectQueryClause = new Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryClause();
		businessObjectQueryClause.PropName = wire.getPropName();
		businessObjectQueryClause.PropValue = wire.getPropValue();
		businessObjectQueryClause.MathOperator = wire.getMathOperator();
		businessObjectQueryClause.LogicOperator = wire.getLogicOperator();
		return businessObjectQueryClause;
	}

	public static Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryInput toWire(Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryInput local)
	{
		Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryInput businessObjectQueryInput = new Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryInput();
		businessObjectQueryInput.setTypeName(local.TypeName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Clauses.Length; i++)
		{
			arrayList.Add(toWire(local.Clauses[i]));
		}
		businessObjectQueryInput.setClauses(arrayList);
		businessObjectQueryInput.setMaxNumToReturn(local.MaxNumToReturn);
		businessObjectQueryInput.setRequestId(local.RequestId);
		businessObjectQueryInput.setClientId(local.ClientId);
		return businessObjectQueryInput;
	}

	public static Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryInput toLocal(Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryInput businessObjectQueryInput = new Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryInput();
		businessObjectQueryInput.TypeName = wire.getTypeName();
		IList clauses = wire.getClauses();
		businessObjectQueryInput.Clauses = new Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryClause[clauses.Count];
		for (int i = 0; i < clauses.Count; i++)
		{
			businessObjectQueryInput.Clauses[i] = toLocal((Teamcenter.Schemas.Query._2010_09.Savedquery.BusinessObjectQueryClause)clauses[i], modelManager);
		}
		businessObjectQueryInput.MaxNumToReturn = wire.getMaxNumToReturn();
		businessObjectQueryInput.RequestId = wire.getRequestId();
		businessObjectQueryInput.ClientId = wire.getClientId();
		return businessObjectQueryInput;
	}

	public override Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse ExecuteBusinessObjectQueries(Teamcenter.Services.Strong.Query._2010_09.SavedQuery.BusinessObjectQueryInput[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			ExecuteBusinessObjectQueriesInput executeBusinessObjectQueriesInput = new ExecuteBusinessObjectQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			executeBusinessObjectQueriesInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_201009_PORT_NAME, "ExecuteBusinessObjectQueries", executeBusinessObjectQueriesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse wire = (Teamcenter.Schemas.Query._2007_09.Savedquery.SavedQueriesResponse)obj;
			Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQueriesResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Query._2013_05.Savedquery.SavedQueryProperties toWire(Teamcenter.Services.Strong.Query._2013_05.SavedQuery.SavedQueryProperties local)
	{
		Teamcenter.Schemas.Query._2013_05.Savedquery.SavedQueryProperties savedQueryProperties = new Teamcenter.Schemas.Query._2013_05.Savedquery.SavedQueryProperties();
		savedQueryProperties.setClientId(local.ClientId);
		savedQueryProperties.setQueryName(local.QueryName);
		savedQueryProperties.setQueryDesc(local.QueryDesc);
		savedQueryProperties.setQueryClass(local.QueryClass);
		savedQueryProperties.setQueryClauses(local.QueryClauses);
		return savedQueryProperties;
	}

	public static Teamcenter.Services.Strong.Query._2013_05.SavedQuery.SavedQueryProperties toLocal(Teamcenter.Schemas.Query._2013_05.Savedquery.SavedQueryProperties wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2013_05.SavedQuery.SavedQueryProperties savedQueryProperties = new Teamcenter.Services.Strong.Query._2013_05.SavedQuery.SavedQueryProperties();
		savedQueryProperties.ClientId = wire.getClientId();
		savedQueryProperties.QueryName = wire.getQueryName();
		savedQueryProperties.QueryDesc = wire.getQueryDesc();
		savedQueryProperties.QueryClass = wire.getQueryClass();
		savedQueryProperties.QueryClauses = wire.getQueryClauses();
		return savedQueryProperties;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData CreateSavedQueries(Teamcenter.Services.Strong.Query._2013_05.SavedQuery.SavedQueryProperties[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			CreateSavedQueriesInput createSavedQueriesInput = new CreateSavedQueriesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createSavedQueriesInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SAVEDQUERY_201305_PORT_NAME, "CreateSavedQueries", createSavedQueriesInput, typeFromHandle, extraTypes);
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
