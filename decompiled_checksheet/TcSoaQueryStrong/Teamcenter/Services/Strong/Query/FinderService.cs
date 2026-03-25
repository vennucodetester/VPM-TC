using System;
using Teamcenter.Services.Strong.Query._2007_06.Finder;
using Teamcenter.Services.Strong.Query._2012_10.Finder;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Query;

public abstract class FinderService : Teamcenter.Services.Strong.Query._2007_06.Finder.Finder, Teamcenter.Services.Strong.Query._2012_10.Finder.Finder
{
	public static FinderService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new FinderRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual FindWorkspaceObjectsResponse FindWorkspaceObjects(WSOFindSet[] FindList)
	{
		throw new NotImplementedException();
	}

	public virtual SearchResponse PerformSearch(SearchInput SearchInput)
	{
		throw new NotImplementedException();
	}
}
