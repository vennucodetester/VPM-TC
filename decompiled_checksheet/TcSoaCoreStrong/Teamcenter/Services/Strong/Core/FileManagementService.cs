using System;
using Teamcenter.Services.Strong.Core._2006_03.FileManagement;
using Teamcenter.Services.Strong.Core._2007_01.FileManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Core;

public abstract class FileManagementService : Teamcenter.Services.Strong.Core._2006_03.FileManagement.FileManagement, Teamcenter.Services.Strong.Core._2007_01.FileManagement.FileManagement
{
	public static FileManagementService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new FileManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ServiceData CommitDatasetFiles(CommitDatasetFileInfo[] CommitInput)
	{
		throw new NotImplementedException();
	}

	public virtual GetDatasetWriteTicketsResponse GetDatasetWriteTickets(GetDatasetWriteTicketsInputData[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual FileTicketsResponse GetFileReadTickets(ImanFile[] Files)
	{
		throw new NotImplementedException();
	}

	public virtual GetTransientFileTicketsResponse GetTransientFileTicketsForUpload(TransientFileInfo[] TransientFileInfos)
	{
		throw new NotImplementedException();
	}
}
