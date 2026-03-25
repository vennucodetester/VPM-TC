using System;
using Teamcenter.Services.Strong.Core._2007_06.LOV;
using Teamcenter.Services.Strong.Core._2011_06.LOV;
using Teamcenter.Services.Strong.Core._2013_05.LOV;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Core;

public abstract class LOVService : Teamcenter.Services.Strong.Core._2007_06.LOV.LOV, Teamcenter.Services.Strong.Core._2011_06.LOV.LOV, Teamcenter.Services.Strong.Core._2013_05.LOV.LOV
{
	public static LOVService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new LOVRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	[Obsolete("As of tc2007.1, use the getAttachedPropDescs operation.", false)]
	public virtual AttachedLOVsResponse GetAttachedLOVs(LOVInfo[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual LOVAttachmentsResponse GetLOVAttachments(LOVAttachmentsInput[] ObjectStructArray)
	{
		throw new NotImplementedException();
	}

	public virtual LOVSearchResults GetInitialLOVValues(InitialLovData InitialData)
	{
		throw new NotImplementedException();
	}

	public virtual LOVSearchResults GetNextLOVValues(LOVData LovData)
	{
		throw new NotImplementedException();
	}

	public virtual ValidateLOVValueSelectionsResponse ValidateLOVValueSelections(LOVInput LovInput, string PropName, string[] UidOfSelectedRows)
	{
		throw new NotImplementedException();
	}
}
