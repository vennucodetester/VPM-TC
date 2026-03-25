using System;
using System.Collections;
using Teamcenter.Schemas.Internal.Core._2006_03.Types;
using Teamcenter.Schemas.Internal.Core._2007_05.Session;
using Teamcenter.Schemas.Internal.Core._2007_12.Session;
using Teamcenter.Schemas.Internal.Core._2008_03.Session;
using Teamcenter.Schemas.Internal.Core._2008_06.Session;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Internal.Loose.Core;

public class SessionRestBindingStub : SessionService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Connection localConnection;

	private static readonly string TYPES_200603_PORT_NAME = "Internal-Core-2006-03-Types";

	private static readonly string SESSION_200705_PORT_NAME = "Internal-Core-2007-05-Session";

	private static readonly string SESSION_200712_PORT_NAME = "Internal-Core-2007-12-Session";

	private static readonly string SESSION_200803_PORT_NAME = "Internal-Core-2008-03-Session";

	private static readonly string SESSION_200806_PORT_NAME = "Internal-Core-2008-06-Session";

	public SessionRestBindingStub(Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
	}

	public override ModelSchema InitTypeByNames(string[] TypeNames)
	{
		try
		{
			restSender.PushRequestId();
			InitTypeByNamesInput initTypeByNamesInput = new InitTypeByNamesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TypeNames.Length; i++)
			{
				arrayList.Add(TypeNames[i]);
			}
			initTypeByNamesInput.setTypeNames(arrayList);
			Type typeFromHandle = typeof(ModelSchema);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(TYPES_200603_PORT_NAME, "InitTypeByNames", initTypeByNamesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			ModelSchema modelSchema = (ModelSchema)obj;
			ModelSchema result = modelSchema;
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

	public override ModelSchema InitTypeByUids(string[] Uids)
	{
		try
		{
			restSender.PushRequestId();
			InitTypeByUidsInput initTypeByUidsInput = new InitTypeByUidsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Uids.Length; i++)
			{
				arrayList.Add(Uids[i]);
			}
			initTypeByUidsInput.setUids(arrayList);
			Type typeFromHandle = typeof(ModelSchema);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(TYPES_200603_PORT_NAME, "InitTypeByUids", initTypeByUidsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			ModelSchema modelSchema = (ModelSchema)obj;
			ModelSchema result = modelSchema;
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

	[Obsolete("As of tc2007.1, use the published refreshPOMCachePerRequest operation.", false)]
	public override bool RefreshPOMCachePerRequest(bool Refresh)
	{
		try
		{
			restSender.PushRequestId();
			RefreshPOMCachePerRequestInput refreshPOMCachePerRequestInput = new RefreshPOMCachePerRequestInput();
			refreshPOMCachePerRequestInput.setRefresh(Refresh);
			Type typeFromHandle = typeof(RefreshPOMCachePerRequestOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200705_PORT_NAME, "RefreshPOMCachePerRequest", refreshPOMCachePerRequestInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			RefreshPOMCachePerRequestOutput refreshPOMCachePerRequestOutput = (RefreshPOMCachePerRequestOutput)obj;
			bool result = refreshPOMCachePerRequestOutput.Out;
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

	public override Teamcenter.Soa.Client.Model.ServiceData GetProperties(Teamcenter.Soa.Client.Model.ModelObject[] Objects, string[] Attributes)
	{
		try
		{
			restSender.PushRequestId();
			GetPropertiesInput getPropertiesInput = new GetPropertiesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Objects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Objects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Objects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getPropertiesInput.setObjects(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < Attributes.Length; i++)
			{
				arrayList2.Add(Attributes[i]);
			}
			getPropertiesInput.setAttributes(arrayList2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200712_PORT_NAME, "GetProperties", getPropertiesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	[Obsolete("As of Teamcenter 9, session states is shared across the clients connecting to same instance of tcserver.", false)]
	public override Teamcenter.Soa.Client.Model.ServiceData DisableUserSessionState(string[] Names)
	{
		try
		{
			restSender.PushRequestId();
			DisableUserSessionStateInput disableUserSessionStateInput = new DisableUserSessionStateInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Names.Length; i++)
			{
				arrayList.Add(Names[i]);
			}
			disableUserSessionStateInput.setNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200803_PORT_NAME, "DisableUserSessionState", disableUserSessionStateInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
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

	public override bool CancelOperation(string Id)
	{
		try
		{
			restSender.PushRequestId();
			CancelOperationInput cancelOperationInput = new CancelOperationInput();
			cancelOperationInput.setId(Id);
			Type typeFromHandle = typeof(CancelOperationOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200806_PORT_NAME, "CancelOperation", cancelOperationInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			CancelOperationOutput cancelOperationOutput = (CancelOperationOutput)obj;
			bool result = cancelOperationOutput.Out;
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
