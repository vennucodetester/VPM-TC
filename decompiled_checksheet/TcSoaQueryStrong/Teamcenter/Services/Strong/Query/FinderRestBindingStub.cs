using System;
using System.Collections;
using Teamcenter.Schemas.Query._2007_06.Finder;
using Teamcenter.Schemas.Query._2012_10.Finder;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Query._2007_06.Finder;
using Teamcenter.Services.Strong.Query._2012_10.Finder;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Query;

public class FinderRestBindingStub : FinderService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string FINDER_200706_PORT_NAME = "Query-2007-06-Finder";

	private static readonly string FINDER_201210_PORT_NAME = "Query-2012-10-Finder";

	public FinderRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsOutput toWire(Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsOutput local)
	{
		Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsOutput findWorkspaceObjectsOutput = new Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsOutput();
		findWorkspaceObjectsOutput.setFindSetIndex(local.FindSetIndex);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.FoundObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.FoundObjects[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.FoundObjects[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		findWorkspaceObjectsOutput.setFoundObjects(arrayList);
		return findWorkspaceObjectsOutput;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsOutput toLocal(Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsOutput findWorkspaceObjectsOutput = new Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsOutput();
		findWorkspaceObjectsOutput.FindSetIndex = wire.getFindSetIndex();
		IList foundObjects = wire.getFoundObjects();
		findWorkspaceObjectsOutput.FoundObjects = new WorkspaceObject[foundObjects.Count];
		for (int i = 0; i < foundObjects.Count; i++)
		{
			findWorkspaceObjectsOutput.FoundObjects[i] = (WorkspaceObject)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)foundObjects[i]);
		}
		return findWorkspaceObjectsOutput;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsResponse toLocal(Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsResponse findWorkspaceObjectsResponse = new Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsResponse();
		findWorkspaceObjectsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList outputList = wire.getOutputList();
		findWorkspaceObjectsResponse.OutputList = new Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsOutput[outputList.Count];
		for (int i = 0; i < outputList.Count; i++)
		{
			findWorkspaceObjectsResponse.OutputList[i] = toLocal((Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsOutput)outputList[i], modelManager);
		}
		return findWorkspaceObjectsResponse;
	}

	public static Teamcenter.Schemas.Query._2007_06.Finder.WSOFindCriteria toWire(Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindCriteria local)
	{
		Teamcenter.Schemas.Query._2007_06.Finder.WSOFindCriteria wSOFindCriteria = new Teamcenter.Schemas.Query._2007_06.Finder.WSOFindCriteria();
		wSOFindCriteria.setObjectType(local.ObjectType);
		wSOFindCriteria.setObjectName(local.ObjectName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Owner == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Owner.Uid);
		}
		wSOFindCriteria.setOwner(modelObject);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Group == null)
		{
			modelObject2.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject2.setUid(local.Group.Uid);
		}
		wSOFindCriteria.setGroup(modelObject2);
		wSOFindCriteria.setCreatedBefore(TcServerDate.ToWire(local.CreatedBefore));
		wSOFindCriteria.setModifiedBefore(TcServerDate.ToWire(local.ModifiedBefore));
		wSOFindCriteria.setReleasedBefore(TcServerDate.ToWire(local.ReleasedBefore));
		wSOFindCriteria.setCreatedAfter(TcServerDate.ToWire(local.CreatedAfter));
		wSOFindCriteria.setModifiedAfter(TcServerDate.ToWire(local.ModifiedAfter));
		wSOFindCriteria.setReleasedAfter(TcServerDate.ToWire(local.ReleasedAfter));
		wSOFindCriteria.setScope(local.Scope);
		return wSOFindCriteria;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindCriteria toLocal(Teamcenter.Schemas.Query._2007_06.Finder.WSOFindCriteria wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindCriteria wSOFindCriteria = new Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindCriteria();
		wSOFindCriteria.ObjectType = wire.getObjectType();
		wSOFindCriteria.ObjectName = wire.getObjectName();
		wSOFindCriteria.Owner = modelManager.LoadObjectData(wire.getOwner());
		wSOFindCriteria.Group = modelManager.LoadObjectData(wire.getGroup());
		wSOFindCriteria.CreatedBefore = TcServerDate.ToLocal(wire.getCreatedBefore());
		wSOFindCriteria.ModifiedBefore = TcServerDate.ToLocal(wire.getModifiedBefore());
		wSOFindCriteria.ReleasedBefore = TcServerDate.ToLocal(wire.getReleasedBefore());
		wSOFindCriteria.CreatedAfter = TcServerDate.ToLocal(wire.getCreatedAfter());
		wSOFindCriteria.ModifiedAfter = TcServerDate.ToLocal(wire.getModifiedAfter());
		wSOFindCriteria.ReleasedAfter = TcServerDate.ToLocal(wire.getReleasedAfter());
		wSOFindCriteria.Scope = wire.getScope();
		return wSOFindCriteria;
	}

	public static Teamcenter.Schemas.Query._2007_06.Finder.WSOFindSet toWire(Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindSet local)
	{
		Teamcenter.Schemas.Query._2007_06.Finder.WSOFindSet wSOFindSet = new Teamcenter.Schemas.Query._2007_06.Finder.WSOFindSet();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Criterias.Length; i++)
		{
			arrayList.Add(toWire(local.Criterias[i]));
		}
		wSOFindSet.setCriterias(arrayList);
		return wSOFindSet;
	}

	public static Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindSet toLocal(Teamcenter.Schemas.Query._2007_06.Finder.WSOFindSet wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindSet wSOFindSet = new Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindSet();
		IList criterias = wire.getCriterias();
		wSOFindSet.Criterias = new Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindCriteria[criterias.Count];
		for (int i = 0; i < criterias.Count; i++)
		{
			wSOFindSet.Criterias[i] = toLocal((Teamcenter.Schemas.Query._2007_06.Finder.WSOFindCriteria)criterias[i], modelManager);
		}
		return wSOFindSet;
	}

	public override Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsResponse FindWorkspaceObjects(Teamcenter.Services.Strong.Query._2007_06.Finder.WSOFindSet[] FindList)
	{
		try
		{
			restSender.PushRequestId();
			FindWorkspaceObjectsInput findWorkspaceObjectsInput = new FindWorkspaceObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < FindList.Length; i++)
			{
				arrayList.Add(toWire(FindList[i]));
			}
			findWorkspaceObjectsInput.setFindList(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(FINDER_200706_PORT_NAME, "FindWorkspaceObjects", findWorkspaceObjectsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsResponse wire = (Teamcenter.Schemas.Query._2007_06.Finder.FindWorkspaceObjectsResponse)obj;
			Teamcenter.Services.Strong.Query._2007_06.Finder.FindWorkspaceObjectsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Query._2012_10.Finder.SearchFilter toWire(Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter local)
	{
		Teamcenter.Schemas.Query._2012_10.Finder.SearchFilter searchFilter = new Teamcenter.Schemas.Query._2012_10.Finder.SearchFilter();
		searchFilter.setSearchFilterType(local.SearchFilterType);
		searchFilter.setStringValue(local.StringValue);
		searchFilter.setStartDateValue(TcServerDate.ToWire(local.StartDateValue));
		searchFilter.setEndDateValue(TcServerDate.ToWire(local.EndDateValue));
		searchFilter.setStartNumericValue(local.StartNumericValue);
		searchFilter.setEndNumericValue(local.EndNumericValue);
		searchFilter.setCount(local.Count);
		searchFilter.setSelected(local.Selected);
		searchFilter.setStartEndRange(local.StartEndRange);
		return searchFilter;
	}

	public static Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter toLocal(Teamcenter.Schemas.Query._2012_10.Finder.SearchFilter wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter searchFilter = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter();
		searchFilter.SearchFilterType = wire.getSearchFilterType();
		searchFilter.StringValue = wire.getStringValue();
		searchFilter.StartDateValue = TcServerDate.ToLocal(wire.getStartDateValue());
		searchFilter.EndDateValue = TcServerDate.ToLocal(wire.getEndDateValue());
		searchFilter.StartNumericValue = Convert.ToDouble(wire.getStartNumericValue());
		searchFilter.EndNumericValue = Convert.ToDouble(wire.getEndNumericValue());
		searchFilter.Count = wire.getCount();
		searchFilter.Selected = wire.Selected;
		searchFilter.StartEndRange = wire.getStartEndRange();
		return searchFilter;
	}

	public static Teamcenter.Schemas.Query._2012_10.Finder.SearchFilterField toWire(Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilterField local)
	{
		Teamcenter.Schemas.Query._2012_10.Finder.SearchFilterField searchFilterField = new Teamcenter.Schemas.Query._2012_10.Finder.SearchFilterField();
		searchFilterField.setInternalName(local.InternalName);
		searchFilterField.setDisplayName(local.DisplayName);
		searchFilterField.setDefaultFilterValueDisplayCount(local.DefaultFilterValueDisplayCount);
		return searchFilterField;
	}

	public static Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilterField toLocal(Teamcenter.Schemas.Query._2012_10.Finder.SearchFilterField wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilterField searchFilterField = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilterField();
		searchFilterField.InternalName = wire.getInternalName();
		searchFilterField.DisplayName = wire.getDisplayName();
		searchFilterField.DefaultFilterValueDisplayCount = wire.getDefaultFilterValueDisplayCount();
		return searchFilterField;
	}

	public static Teamcenter.Schemas.Query._2012_10.Finder.SearchInput toWire(Teamcenter.Services.Strong.Query._2012_10.Finder.SearchInput local)
	{
		Teamcenter.Schemas.Query._2012_10.Finder.SearchInput searchInput = new Teamcenter.Schemas.Query._2012_10.Finder.SearchInput();
		searchInput.setProviderName(local.ProviderName);
		searchInput.setSearchCriteria(toWireStringMap(local.SearchCriteria));
		searchInput.setStartIndex(local.StartIndex);
		searchInput.setMaxToReturn(local.MaxToReturn);
		searchInput.setMaxToLoad(local.MaxToLoad);
		searchInput.setSearchFilterMap(toWireSearchFilterMap(local.SearchFilterMap));
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.SearchSortCriteria.Length; i++)
		{
			arrayList.Add(toWire(local.SearchSortCriteria[i]));
		}
		searchInput.setSearchSortCriteria(arrayList);
		searchInput.setSearchFilterFieldSortType(local.SearchFilterFieldSortType);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.AttributesToInflate.Length; i++)
		{
			arrayList2.Add(local.AttributesToInflate[i]);
		}
		searchInput.setAttributesToInflate(arrayList2);
		return searchInput;
	}

	public static Teamcenter.Services.Strong.Query._2012_10.Finder.SearchInput toLocal(Teamcenter.Schemas.Query._2012_10.Finder.SearchInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2012_10.Finder.SearchInput searchInput = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchInput();
		searchInput.ProviderName = wire.getProviderName();
		searchInput.SearchCriteria = toLocalStringMap(wire.getSearchCriteria(), modelManager);
		searchInput.StartIndex = wire.getStartIndex();
		searchInput.MaxToReturn = wire.getMaxToReturn();
		searchInput.MaxToLoad = wire.getMaxToLoad();
		searchInput.SearchFilterMap = toLocalSearchFilterMap(wire.getSearchFilterMap(), modelManager);
		IList searchSortCriteria = wire.getSearchSortCriteria();
		searchInput.SearchSortCriteria = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchSortCriteria[searchSortCriteria.Count];
		for (int i = 0; i < searchSortCriteria.Count; i++)
		{
			searchInput.SearchSortCriteria[i] = toLocal((Teamcenter.Schemas.Query._2012_10.Finder.SearchSortCriteria)searchSortCriteria[i], modelManager);
		}
		searchInput.SearchFilterFieldSortType = wire.getSearchFilterFieldSortType();
		IList attributesToInflate = wire.getAttributesToInflate();
		searchInput.AttributesToInflate = new string[attributesToInflate.Count];
		for (int i = 0; i < attributesToInflate.Count; i++)
		{
			searchInput.AttributesToInflate[i] = Convert.ToString(attributesToInflate[i]);
		}
		return searchInput;
	}

	public static Teamcenter.Services.Strong.Query._2012_10.Finder.SearchResponse toLocal(Teamcenter.Schemas.Query._2012_10.Finder.SearchResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2012_10.Finder.SearchResponse searchResponse = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchResponse();
		searchResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList searchResults = wire.getSearchResults();
		searchResponse.SearchResults = new Teamcenter.Soa.Client.Model.ModelObject[searchResults.Count];
		for (int i = 0; i < searchResults.Count; i++)
		{
			searchResponse.SearchResults[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)searchResults[i]);
		}
		searchResponse.TotalFound = wire.getTotalFound();
		searchResponse.TotalLoaded = wire.getTotalLoaded();
		searchResponse.SearchFilterMap = toLocalSearchFilterMap(wire.getSearchFilterMap(), modelManager);
		IList searchFilterCategories = wire.getSearchFilterCategories();
		searchResponse.SearchFilterCategories = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilterField[searchFilterCategories.Count];
		for (int i = 0; i < searchFilterCategories.Count; i++)
		{
			searchResponse.SearchFilterCategories[i] = toLocal((Teamcenter.Schemas.Query._2012_10.Finder.SearchFilterField)searchFilterCategories[i], modelManager);
		}
		searchResponse.DefaultFilterFieldDisplayCount = wire.getDefaultFilterFieldDisplayCount();
		return searchResponse;
	}

	public static Teamcenter.Schemas.Query._2012_10.Finder.SearchSortCriteria toWire(Teamcenter.Services.Strong.Query._2012_10.Finder.SearchSortCriteria local)
	{
		Teamcenter.Schemas.Query._2012_10.Finder.SearchSortCriteria searchSortCriteria = new Teamcenter.Schemas.Query._2012_10.Finder.SearchSortCriteria();
		searchSortCriteria.setFieldName(local.FieldName);
		searchSortCriteria.setSortDirection(local.SortDirection);
		return searchSortCriteria;
	}

	public static Teamcenter.Services.Strong.Query._2012_10.Finder.SearchSortCriteria toLocal(Teamcenter.Schemas.Query._2012_10.Finder.SearchSortCriteria wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Query._2012_10.Finder.SearchSortCriteria searchSortCriteria = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchSortCriteria();
		searchSortCriteria.FieldName = wire.getFieldName();
		searchSortCriteria.SortDirection = wire.getSortDirection();
		return searchSortCriteria;
	}

	public static ArrayList toWireSearchFilterMap(IDictionary SearchFilterMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in SearchFilterMap)
		{
			object key = item.Key;
			object value = item.Value;
			SearchFilterMap searchFilterMap = new SearchFilterMap();
			searchFilterMap.setKey(Convert.ToString(key));
			IList value2 = searchFilterMap.getValue();
			Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter[] array = (Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			searchFilterMap.setValue((ArrayList)value2);
			arrayList.Add(searchFilterMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalSearchFilterMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			SearchFilterMap searchFilterMap = (SearchFilterMap)wire[i];
			string key = searchFilterMap.getKey();
			IList value = searchFilterMap.getValue();
			Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter[] array = new Teamcenter.Services.Strong.Query._2012_10.Finder.SearchFilter[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Query._2012_10.Finder.SearchFilter)value[j], modelManager);
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

	public override Teamcenter.Services.Strong.Query._2012_10.Finder.SearchResponse PerformSearch(Teamcenter.Services.Strong.Query._2012_10.Finder.SearchInput SearchInput)
	{
		try
		{
			restSender.PushRequestId();
			PerformSearchInput performSearchInput = new PerformSearchInput();
			performSearchInput.setSearchInput(toWire(SearchInput));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Query._2012_10.Finder.SearchResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FINDER_201210_PORT_NAME, "PerformSearch", performSearchInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Query._2012_10.Finder.SearchResponse wire = (Teamcenter.Schemas.Query._2012_10.Finder.SearchResponse)obj;
			Teamcenter.Services.Strong.Query._2012_10.Finder.SearchResponse result = toLocal(wire, modelManager);
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
