using System;
using Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement;
using Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Services.Internal.Loose.Core;

public abstract class FileManagementService : Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileManagement, Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement.FileManagement
{
	public static FileManagementService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new FileManagementRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual CommitUploadedRegularFilesResponse CommitRegularFiles(CommitUploadedRegularFilesInput[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual GetFileTransferTicketsResponse GetFileTransferTickets(ModelObject[] ImanFiles)
	{
		throw new NotImplementedException();
	}

	public virtual GetRegularFileWriteTicketsResponse GetRegularFileTicketsForUpload(GetRegularFileWriteTicketsInput[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual FileTicketsResponse GetWriteTickets(WriteTicketsInput[] Inputs)
	{
		throw new NotImplementedException();
	}

	public virtual UpdateImanFileCommitsResponse UpdateImanFileCommits(string[] CleanupInfo)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData CommitReplacedFiles(CommitReplacedFileInfo[] CommitInfos, bool[] Flags)
	{
		throw new NotImplementedException();
	}
}
