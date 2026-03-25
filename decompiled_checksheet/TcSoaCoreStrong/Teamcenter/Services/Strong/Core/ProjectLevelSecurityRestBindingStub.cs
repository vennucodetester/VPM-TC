using System;
using System.Collections;
using Teamcenter.Schemas.Core._2007_09.Projectlevelsecurity;
using Teamcenter.Schemas.Core._2009_04.Projectlevelsecurity;
using Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity;
using Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity;
using Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity;
using Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity;
using Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class ProjectLevelSecurityRestBindingStub : ProjectLevelSecurityService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string PROJECTLEVELSECURITY_200709_PORT_NAME = "Core-2007-09-ProjectLevelSecurity";

	private static readonly string PROJECTLEVELSECURITY_200904_PORT_NAME = "Core-2009-04-ProjectLevelSecurity";

	private static readonly string PROJECTLEVELSECURITY_200910_PORT_NAME = "Core-2009-10-ProjectLevelSecurity";

	private static readonly string PROJECTLEVELSECURITY_201209_PORT_NAME = "Core-2012-09-ProjectLevelSecurity";

	public ProjectLevelSecurityRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2007_09.Projectlevelsecurity.AssignedOrRemovedObjects toWire(Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity.AssignedOrRemovedObjects local)
	{
		Teamcenter.Schemas.Core._2007_09.Projectlevelsecurity.AssignedOrRemovedObjects assignedOrRemovedObjects = new Teamcenter.Schemas.Core._2007_09.Projectlevelsecurity.AssignedOrRemovedObjects();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Projects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Projects[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.Projects[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		assignedOrRemovedObjects.setProjects(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ObjectToAssign.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ObjectToAssign[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.ObjectToAssign[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		assignedOrRemovedObjects.setObjectToAssign(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.ObjectToRemove.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ObjectToRemove[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.ObjectToRemove[i].Uid);
			}
			arrayList3.Add(modelObject3);
		}
		assignedOrRemovedObjects.setObjectToRemove(arrayList3);
		return assignedOrRemovedObjects;
	}

	public static Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity.AssignedOrRemovedObjects toLocal(Teamcenter.Schemas.Core._2007_09.Projectlevelsecurity.AssignedOrRemovedObjects wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity.AssignedOrRemovedObjects assignedOrRemovedObjects = new Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity.AssignedOrRemovedObjects();
		IList projects = wire.getProjects();
		assignedOrRemovedObjects.Projects = new TC_Project[projects.Count];
		for (int i = 0; i < projects.Count; i++)
		{
			assignedOrRemovedObjects.Projects[i] = (TC_Project)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)projects[i]);
		}
		IList objectToAssign = wire.getObjectToAssign();
		assignedOrRemovedObjects.ObjectToAssign = new Teamcenter.Soa.Client.Model.ModelObject[objectToAssign.Count];
		for (int i = 0; i < objectToAssign.Count; i++)
		{
			assignedOrRemovedObjects.ObjectToAssign[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objectToAssign[i]);
		}
		IList objectToRemove = wire.getObjectToRemove();
		assignedOrRemovedObjects.ObjectToRemove = new Teamcenter.Soa.Client.Model.ModelObject[objectToRemove.Count];
		for (int i = 0; i < objectToRemove.Count; i++)
		{
			assignedOrRemovedObjects.ObjectToRemove[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objectToRemove[i]);
		}
		return assignedOrRemovedObjects;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData AssignOrRemoveObjects(Teamcenter.Services.Strong.Core._2007_09.ProjectLevelSecurity.AssignedOrRemovedObjects[] AssignedOrRemovedobjects)
	{
		try
		{
			restSender.PushRequestId();
			AssignOrRemoveObjectsInput assignOrRemoveObjectsInput = new AssignOrRemoveObjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < AssignedOrRemovedobjects.Length; i++)
			{
				arrayList.Add(toWire(AssignedOrRemovedobjects[i]));
			}
			assignOrRemoveObjectsInput.setAssignedOrRemovedobjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_200709_PORT_NAME, "AssignOrRemoveObjects", assignOrRemoveObjectsInput, typeFromHandle, extraTypes);
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

	public static Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity.LoadProjectDataForUserResponse toLocal(Teamcenter.Schemas.Core._2009_04.Projectlevelsecurity.LoadProjectDataForUserResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity.LoadProjectDataForUserResponse loadProjectDataForUserResponse = new Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity.LoadProjectDataForUserResponse();
		loadProjectDataForUserResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList applicableProjects = wire.getApplicableProjects();
		loadProjectDataForUserResponse.ApplicableProjects = new TC_Project[applicableProjects.Count];
		for (int i = 0; i < applicableProjects.Count; i++)
		{
			loadProjectDataForUserResponse.ApplicableProjects[i] = (TC_Project)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)applicableProjects[i]);
		}
		return loadProjectDataForUserResponse;
	}

	public override Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity.LoadProjectDataForUserResponse LoadProjectDataForUser(User User, Group Group, Role Role)
	{
		try
		{
			restSender.PushRequestId();
			LoadProjectDataForUserInput loadProjectDataForUserInput = new LoadProjectDataForUserInput();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (User == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(User.Uid);
			}
			loadProjectDataForUserInput.setUser(modelObject);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Group == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(Group.Uid);
			}
			loadProjectDataForUserInput.setGroup(modelObject2);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (Role == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(Role.Uid);
			}
			loadProjectDataForUserInput.setRole(modelObject3);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2009_04.Projectlevelsecurity.LoadProjectDataForUserResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_200904_PORT_NAME, "LoadProjectDataForUser", loadProjectDataForUserInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2009_04.Projectlevelsecurity.LoadProjectDataForUserResponse wire = (Teamcenter.Schemas.Core._2009_04.Projectlevelsecurity.LoadProjectDataForUserResponse)obj;
			Teamcenter.Services.Strong.Core._2009_04.ProjectLevelSecurity.LoadProjectDataForUserResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.ProjectInfo toWire(Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.ProjectInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.ProjectInfo projectInfo = new Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.ProjectInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Project == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Project.Uid);
		}
		projectInfo.setProject(modelObject);
		projectInfo.setIsUserPrivileged(local.IsUserPrivileged);
		return projectInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.ProjectInfo toLocal(Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.ProjectInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.ProjectInfo projectInfo = new Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.ProjectInfo();
		projectInfo.Project = (TC_Project)modelManager.LoadObjectData(wire.getProject());
		projectInfo.IsUserPrivileged = wire.IsUserPrivileged;
		return projectInfo;
	}

	public static Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfo toWire(Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfo local)
	{
		Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfo userProjectsInfo = new Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.User == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.User.Uid);
		}
		userProjectsInfo.setUser(modelObject);
		userProjectsInfo.setActiveProjectsOnly(local.ActiveProjectsOnly);
		userProjectsInfo.setPrivilegedProjectsOnly(local.PrivilegedProjectsOnly);
		userProjectsInfo.setProgramsOnly(local.ProgramsOnly);
		userProjectsInfo.setClientId(local.ClientId);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ProjectsInfo.Length; i++)
		{
			arrayList.Add(toWire(local.ProjectsInfo[i]));
		}
		userProjectsInfo.setProjectsInfo(arrayList);
		return userProjectsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfo toLocal(Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfo userProjectsInfo = new Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfo();
		userProjectsInfo.User = (User)modelManager.LoadObjectData(wire.getUser());
		userProjectsInfo.ActiveProjectsOnly = wire.ActiveProjectsOnly;
		userProjectsInfo.PrivilegedProjectsOnly = wire.PrivilegedProjectsOnly;
		userProjectsInfo.ProgramsOnly = wire.ProgramsOnly;
		userProjectsInfo.ClientId = wire.getClientId();
		IList projectsInfo = wire.getProjectsInfo();
		userProjectsInfo.ProjectsInfo = new Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.ProjectInfo[projectsInfo.Count];
		for (int i = 0; i < projectsInfo.Count; i++)
		{
			userProjectsInfo.ProjectsInfo[i] = toLocal((Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.ProjectInfo)projectsInfo[i], modelManager);
		}
		return userProjectsInfo;
	}

	public static Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoInput toWire(Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoInput local)
	{
		Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoInput userProjectsInfoInput = new Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoInput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.User == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.User.Uid);
		}
		userProjectsInfoInput.setUser(modelObject);
		userProjectsInfoInput.setActiveProjectsOnly(local.ActiveProjectsOnly);
		userProjectsInfoInput.setPrivilegedProjectsOnly(local.PrivilegedProjectsOnly);
		userProjectsInfoInput.setProgramsOnly(local.ProgramsOnly);
		userProjectsInfoInput.setClientId(local.ClientId);
		return userProjectsInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoInput toLocal(Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoInput userProjectsInfoInput = new Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoInput();
		userProjectsInfoInput.User = (User)modelManager.LoadObjectData(wire.getUser());
		userProjectsInfoInput.ActiveProjectsOnly = wire.ActiveProjectsOnly;
		userProjectsInfoInput.PrivilegedProjectsOnly = wire.PrivilegedProjectsOnly;
		userProjectsInfoInput.ProgramsOnly = wire.ProgramsOnly;
		userProjectsInfoInput.ClientId = wire.getClientId();
		return userProjectsInfoInput;
	}

	public static Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoResponse toLocal(Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoResponse userProjectsInfoResponse = new Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoResponse();
		userProjectsInfoResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList userProjectInfos = wire.getUserProjectInfos();
		userProjectsInfoResponse.UserProjectInfos = new Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfo[userProjectInfos.Count];
		for (int i = 0; i < userProjectInfos.Count; i++)
		{
			userProjectsInfoResponse.UserProjectInfos[i] = toLocal((Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfo)userProjectInfos[i], modelManager);
		}
		return userProjectsInfoResponse;
	}

	public override Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoResponse GetUserProjects(Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoInput[] UserProjectsInfoInputs)
	{
		try
		{
			restSender.PushRequestId();
			GetUserProjectsInput getUserProjectsInput = new GetUserProjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < UserProjectsInfoInputs.Length; i++)
			{
				arrayList.Add(toWire(UserProjectsInfoInputs[i]));
			}
			getUserProjectsInput.setUserProjectsInfoInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_200910_PORT_NAME, "GetUserProjects", getUserProjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoResponse wire = (Teamcenter.Schemas.Core._2009_10.Projectlevelsecurity.UserProjectsInfoResponse)obj;
			Teamcenter.Services.Strong.Core._2009_10.ProjectLevelSecurity.UserProjectsInfoResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectInformation toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectInformation local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectInformation projectInformation = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectInformation();
		projectInformation.setProjectId(local.ProjectId);
		projectInformation.setProjectName(local.ProjectName);
		projectInformation.setProjectDescription(local.ProjectDescription);
		projectInformation.setUseProgramContext(local.UseProgramContext);
		projectInformation.setActive(local.Active);
		projectInformation.setVisible(local.Visible);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.TeamMembers.Length; i++)
		{
			arrayList.Add(toWire(local.TeamMembers[i]));
		}
		projectInformation.setTeamMembers(arrayList);
		projectInformation.setClientId(local.ClientId);
		return projectInformation;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectInformation toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectInformation wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectInformation projectInformation = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectInformation();
		projectInformation.ProjectId = wire.getProjectId();
		projectInformation.ProjectName = wire.getProjectName();
		projectInformation.ProjectDescription = wire.getProjectDescription();
		projectInformation.UseProgramContext = wire.UseProgramContext;
		projectInformation.Active = wire.Active;
		projectInformation.Visible = wire.Visible;
		IList teamMembers = wire.getTeamMembers();
		projectInformation.TeamMembers = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.TeamMemberInfo[teamMembers.Count];
		for (int i = 0; i < teamMembers.Count; i++)
		{
			projectInformation.TeamMembers[i] = toLocal((Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.TeamMemberInfo)teamMembers[i], modelManager);
		}
		projectInformation.ClientId = wire.getClientId();
		return projectInformation;
	}

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.CopyProjectsInfo toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.CopyProjectsInfo local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.CopyProjectsInfo copyProjectsInfo = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.CopyProjectsInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SourceProject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.SourceProject.Uid);
		}
		copyProjectsInfo.setSourceProject(modelObject);
		copyProjectsInfo.setProjectInfo(toWire(local.ProjectInfo));
		copyProjectsInfo.setClientId(local.ClientId);
		return copyProjectsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.CopyProjectsInfo toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.CopyProjectsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.CopyProjectsInfo copyProjectsInfo = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.CopyProjectsInfo();
		copyProjectsInfo.SourceProject = (TC_Project)modelManager.LoadObjectData(wire.getSourceProject());
		copyProjectsInfo.ProjectInfo = toLocal(wire.getProjectInfo(), modelManager);
		copyProjectsInfo.ClientId = wire.getClientId();
		return copyProjectsInfo;
	}

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ModifyProjectsInfo toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ModifyProjectsInfo local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ModifyProjectsInfo modifyProjectsInfo = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ModifyProjectsInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.SourceProject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.SourceProject.Uid);
		}
		modifyProjectsInfo.setSourceProject(modelObject);
		modifyProjectsInfo.setProjectInfo(toWire(local.ProjectInfo));
		modifyProjectsInfo.setClientId(local.ClientId);
		return modifyProjectsInfo;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ModifyProjectsInfo toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ModifyProjectsInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ModifyProjectsInfo modifyProjectsInfo = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ModifyProjectsInfo();
		modifyProjectsInfo.SourceProject = (TC_Project)modelManager.LoadObjectData(wire.getSourceProject());
		modifyProjectsInfo.ProjectInfo = toLocal(wire.getProjectInfo(), modelManager);
		modifyProjectsInfo.ClientId = wire.getClientId();
		return modifyProjectsInfo;
	}

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectClientId toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectClientId local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectClientId projectClientId = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectClientId();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TcProject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TcProject.Uid);
		}
		projectClientId.setTcProject(modelObject);
		projectClientId.setClientId(local.ClientId);
		return projectClientId;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectClientId toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectClientId wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectClientId projectClientId = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectClientId();
		projectClientId.TcProject = (TC_Project)modelManager.LoadObjectData(wire.getTcProject());
		projectClientId.ClientId = wire.getClientId();
		return projectClientId;
	}

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsOutput toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsOutput local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsOutput projectOpsOutput = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Project == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Project.Uid);
		}
		projectOpsOutput.setProject(modelObject);
		projectOpsOutput.setClientId(local.ClientId);
		return projectOpsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsOutput toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsOutput projectOpsOutput = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsOutput();
		projectOpsOutput.Project = (TC_Project)modelManager.LoadObjectData(wire.getProject());
		projectOpsOutput.ClientId = wire.getClientId();
		return projectOpsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse projectOpsResponse = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse();
		projectOpsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList projectOpsOutputs = wire.getProjectOpsOutputs();
		projectOpsResponse.ProjectOpsOutputs = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsOutput[projectOpsOutputs.Count];
		for (int i = 0; i < projectOpsOutputs.Count; i++)
		{
			projectOpsResponse.ProjectOpsOutputs[i] = toLocal((Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsOutput)projectOpsOutputs[i], modelManager);
		}
		return projectOpsResponse;
	}

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamData toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamData local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamData projectTeamData = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Project == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Project.Uid);
		}
		projectTeamData.setProject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RegularMembers.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.RegularMembers[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.RegularMembers[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		projectTeamData.setRegularMembers(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.ProjectTeamAdmins.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject3 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.ProjectTeamAdmins[i] == null)
			{
				modelObject3.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject3.setUid(local.ProjectTeamAdmins[i].Uid);
			}
			arrayList2.Add(modelObject3);
		}
		projectTeamData.setProjectTeamAdmins(arrayList2);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.PrivMembers.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject4 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PrivMembers[i] == null)
			{
				modelObject4.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject4.setUid(local.PrivMembers[i].Uid);
			}
			arrayList3.Add(modelObject4);
		}
		projectTeamData.setPrivMembers(arrayList3);
		return projectTeamData;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamData toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamData projectTeamData = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamData();
		projectTeamData.Project = (TC_Project)modelManager.LoadObjectData(wire.getProject());
		IList regularMembers = wire.getRegularMembers();
		projectTeamData.RegularMembers = new Teamcenter.Soa.Client.Model.ModelObject[regularMembers.Count];
		for (int i = 0; i < regularMembers.Count; i++)
		{
			projectTeamData.RegularMembers[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)regularMembers[i]);
		}
		IList projectTeamAdmins = wire.getProjectTeamAdmins();
		projectTeamData.ProjectTeamAdmins = new Teamcenter.Soa.Client.Model.ModelObject[projectTeamAdmins.Count];
		for (int i = 0; i < projectTeamAdmins.Count; i++)
		{
			projectTeamData.ProjectTeamAdmins[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)projectTeamAdmins[i]);
		}
		IList privMembers = wire.getPrivMembers();
		projectTeamData.PrivMembers = new Teamcenter.Soa.Client.Model.ModelObject[privMembers.Count];
		for (int i = 0; i < privMembers.Count; i++)
		{
			projectTeamData.PrivMembers[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)privMembers[i]);
		}
		return projectTeamData;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamsResponse toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamsResponse projectTeamsResponse = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamsResponse();
		projectTeamsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList projectTeams = wire.getProjectTeams();
		projectTeamsResponse.ProjectTeams = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamData[projectTeams.Count];
		for (int i = 0; i < projectTeams.Count; i++)
		{
			projectTeamsResponse.ProjectTeams[i] = toLocal((Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamData)projectTeams[i], modelManager);
		}
		return projectTeamsResponse;
	}

	public static Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.TeamMemberInfo toWire(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.TeamMemberInfo local)
	{
		Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.TeamMemberInfo teamMemberInfo = new Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.TeamMemberInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TeamMember == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TeamMember.Uid);
		}
		teamMemberInfo.setTeamMember(modelObject);
		teamMemberInfo.setTeamMemberType(local.TeamMemberType);
		return teamMemberInfo;
	}

	public static Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.TeamMemberInfo toLocal(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.TeamMemberInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.TeamMemberInfo teamMemberInfo = new Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.TeamMemberInfo();
		teamMemberInfo.TeamMember = modelManager.LoadObjectData(wire.getTeamMember());
		teamMemberInfo.TeamMemberType = wire.getTeamMemberType();
		return teamMemberInfo;
	}

	public override Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse CopyProjects(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.CopyProjectsInfo[] CopyProjectsInfos)
	{
		try
		{
			restSender.PushRequestId();
			CopyProjectsInput copyProjectsInput = new CopyProjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < CopyProjectsInfos.Length; i++)
			{
				arrayList.Add(toWire(CopyProjectsInfos[i]));
			}
			copyProjectsInput.setCopyProjectsInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_201209_PORT_NAME, "CopyProjects", copyProjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse wire = (Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse)obj;
			Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse CreateProjects(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectInformation[] ProjectInfos)
	{
		try
		{
			restSender.PushRequestId();
			CreateProjectsInput createProjectsInput = new CreateProjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ProjectInfos.Length; i++)
			{
				arrayList.Add(toWire(ProjectInfos[i]));
			}
			createProjectsInput.setProjectInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_201209_PORT_NAME, "CreateProjects", createProjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse wire = (Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse)obj;
			Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamsResponse GetProjectTeams(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectClientId[] ProjectObjs)
	{
		try
		{
			restSender.PushRequestId();
			GetProjectTeamsInput getProjectTeamsInput = new GetProjectTeamsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ProjectObjs.Length; i++)
			{
				arrayList.Add(toWire(ProjectObjs[i]));
			}
			getProjectTeamsInput.setProjectObjs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_201209_PORT_NAME, "GetProjectTeams", getProjectTeamsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamsResponse wire = (Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectTeamsResponse)obj;
			Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectTeamsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse ModifyProjects(Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ModifyProjectsInfo[] ModifyProjectsInfos)
	{
		try
		{
			restSender.PushRequestId();
			ModifyProjectsInput modifyProjectsInput = new ModifyProjectsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ModifyProjectsInfos.Length; i++)
			{
				arrayList.Add(toWire(ModifyProjectsInfos[i]));
			}
			modifyProjectsInput.setModifyProjectsInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(PROJECTLEVELSECURITY_201209_PORT_NAME, "ModifyProjects", modifyProjectsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse wire = (Teamcenter.Schemas.Core._2012_09.Projectlevelsecurity.ProjectOpsResponse)obj;
			Teamcenter.Services.Strong.Core._2012_09.ProjectLevelSecurity.ProjectOpsResponse result = toLocal(wire, modelManager);
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
