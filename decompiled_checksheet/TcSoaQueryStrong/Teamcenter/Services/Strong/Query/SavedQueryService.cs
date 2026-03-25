using System;
using Teamcenter.Services.Strong.Query._2006_03.SavedQuery;
using Teamcenter.Services.Strong.Query._2007_01.SavedQuery;
using Teamcenter.Services.Strong.Query._2007_06.SavedQuery;
using Teamcenter.Services.Strong.Query._2007_09.SavedQuery;
using Teamcenter.Services.Strong.Query._2008_06.SavedQuery;
using Teamcenter.Services.Strong.Query._2010_04.SavedQuery;
using Teamcenter.Services.Strong.Query._2010_09.SavedQuery;
using Teamcenter.Services.Strong.Query._2013_05.SavedQuery;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Query;

public abstract class SavedQueryService : Teamcenter.Services.Strong.Query._2006_03.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2007_01.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2007_06.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2007_09.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2008_06.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2010_04.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2010_09.SavedQuery.SavedQuery, Teamcenter.Services.Strong.Query._2013_05.SavedQuery.SavedQuery
{
	public static SavedQueryService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new SavedQueryRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual DescribeSavedQueriesResponse DescribeSavedQueries(ImanQuery[] Queries)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007, use the executeSavedQueries operation from the _2007_06 namespace.", false)]
	public virtual ExecuteSavedQueryResponse ExecuteSavedQuery(ImanQuery Query, string[] Entries, string[] Values, int Limit)
	{
		throw new NotImplementedException();
	}

	public virtual GetSavedQueriesResponse GetSavedQueries()
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 8.1, use the deleteObjects operation.", false)]
	public virtual ServiceData DeleteQueryCriterias(string[] QueryCriteriaNames)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 8.1, there is no replacement.", false)]
	public virtual ServiceData ReorderSavedQueryCriterias(string[] QueryCriteriaNames)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007.1, use the retrieveSearchCriteria operation from  the _2007_06 namespace.", false)]
	public virtual RetrieveQueryCriteriaResponse RetrieveQueryCriterias(string[] QueryCriteriaNames)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of tc2007.1, use the saveSearchCriteria operation from the _2007_06 namespace.", false)]
	public virtual ServiceData SaveQueryCriterias(SaveQueryCriteriaInfo[] QueryCriterias)
	{
		throw new NotImplementedException();
	}

	public virtual ExecuteSavedQueriesResponse ExecuteSavedQueries(SavedQueryInput[] Input)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 8.1, refer to Release notes on how to retrieve My Saved Searches information.", false)]
	public virtual RetrieveSearchCriteriaResponse RetrieveSearchCriteria(string[] SearchNames)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 8.1, use createObjects on a SavedSearch business object.", false)]
	public virtual ServiceData SaveSearchCriteria(SaveSearchCriteriaInfo[] SearchCriteria)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Tc 8, use the executeSavedQueries operation from the _2008_06 namespace.", false)]
	public virtual SavedQueriesResponse ExecuteSavedQueries(Teamcenter.Services.Strong.Query._2007_09.SavedQuery.QueryInput[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual SavedQueriesResponse ExecuteSavedQueries(Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual FindSavedQueriesResponse FindSavedQueries(FindSavedQueriesCriteriaInput[] InputCriteria)
	{
		throw new NotImplementedException();
	}

	public virtual SavedQueriesResponse ExecuteBusinessObjectQueries(BusinessObjectQueryInput[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData CreateSavedQueries(SavedQueryProperties[] Inputs)
	{
		throw new NotImplementedException();
	}
}
