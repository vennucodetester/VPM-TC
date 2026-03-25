using System;
using Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity;
using Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity;
using Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity;
using Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Core;

public abstract class ProjectLevelSecurityService : Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity.ProjectLevelSecurity, Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity.ProjectLevelSecurity, Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.ProjectLevelSecurity, Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectLevelSecurity
{
	public static ProjectLevelSecurityService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new ProjectLevelSecurityRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ServiceData AssignOrRemoveObjects(AssignedOrRemovedObjects[] AssignedOrRemovedobjects)
	{
		throw new NotImplementedException();
	}

	public virtual LoadProjectDataForUserResponse LoadProjectDataForUser(User User, Group Group, Role Role)
	{
		throw new NotImplementedException();
	}

	public virtual UserProjectsInfoResponse GetUserProjects(UserProjectsInfoInput[] UserProjectsInfoInputs)
	{
		throw new NotImplementedException();
	}

	public virtual ProjectOpsResponse CopyProjects(CopyProjectsInfo[] CopyProjectsInfos)
	{
		throw new NotImplementedException();
	}

	public virtual ProjectOpsResponse CreateProjects(ProjectInformation[] ProjectInfos)
	{
		throw new NotImplementedException();
	}

	public virtual ProjectTeamsResponse GetProjectTeams(ProjectClientId[] ProjectObjs)
	{
		throw new NotImplementedException();
	}

	public virtual ProjectOpsResponse ModifyProjects(ModifyProjectsInfo[] ModifyProjectsInfos)
	{
		throw new NotImplementedException();
	}
}
