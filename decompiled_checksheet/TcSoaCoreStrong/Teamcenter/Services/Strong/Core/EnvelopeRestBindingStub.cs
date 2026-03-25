using System;
using System.Collections;
using Teamcenter.Schemas.Core._2011_06.Envelope;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class EnvelopeRestBindingStub : EnvelopeService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string ENVELOPE_201106_PORT_NAME = "Core-2011-06-Envelope";

	public EnvelopeRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public override Teamcenter.Soa.Client.Model.ServiceData SendAndDeleteEnvelopes(Envelope[] Envelopes)
	{
		try
		{
			restSender.PushRequestId();
			SendAndDeleteEnvelopesInput sendAndDeleteEnvelopesInput = new SendAndDeleteEnvelopesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Envelopes.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Envelopes[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Envelopes[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			sendAndDeleteEnvelopesInput.setEnvelopes(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(ENVELOPE_201106_PORT_NAME, "SendAndDeleteEnvelopes", sendAndDeleteEnvelopesInput, typeFromHandle, extraTypes);
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
