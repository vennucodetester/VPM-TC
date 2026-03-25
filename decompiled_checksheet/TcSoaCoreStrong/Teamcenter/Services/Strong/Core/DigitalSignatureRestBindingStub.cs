using System;
using System.Collections;
using Teamcenter.Schemas.Core._2014_06.Digitalsignature;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Strong.Core._2014_06.DigitalSignature;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class DigitalSignatureRestBindingStub : DigitalSignatureService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Connection localConnection;

	private static readonly string DIGITALSIGNATURE_201406_PORT_NAME = "Core-2014-06-DigitalSignature";

	public DigitalSignatureRestBindingStub(Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2014_06.Digitalsignature.ApplySignaturesInputData toWire(Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.ApplySignaturesInputData local)
	{
		Teamcenter.Schemas.Core._2014_06.Digitalsignature.ApplySignaturesInputData applySignaturesInputData = new Teamcenter.Schemas.Core._2014_06.Digitalsignature.ApplySignaturesInputData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		applySignaturesInputData.setObject(modelObject);
		applySignaturesInputData.setEncryptedString(local.EncryptedString);
		return applySignaturesInputData;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.ApplySignaturesInputData toLocal(Teamcenter.Schemas.Core._2014_06.Digitalsignature.ApplySignaturesInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.ApplySignaturesInputData applySignaturesInputData = new Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.ApplySignaturesInputData();
		applySignaturesInputData.Object = modelManager.LoadObjectData(wire.getObject());
		applySignaturesInputData.EncryptedString = wire.getEncryptedString();
		return applySignaturesInputData;
	}

	public static Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesOutput toWire(Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesOutput local)
	{
		Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesOutput getSignatureMessagesOutput = new Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesOutput();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		getSignatureMessagesOutput.setTargetObject(modelObject);
		getSignatureMessagesOutput.setMessage(local.Message);
		return getSignatureMessagesOutput;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesOutput toLocal(Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesOutput getSignatureMessagesOutput = new Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesOutput();
		getSignatureMessagesOutput.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		getSignatureMessagesOutput.Message = wire.getMessage();
		return getSignatureMessagesOutput;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesResponse toLocal(Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesResponse getSignatureMessagesResponse = new Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesResponse();
		getSignatureMessagesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getSignatureMessagesResponse.Output = new Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getSignatureMessagesResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesOutput)output[i], modelManager);
		}
		return getSignatureMessagesResponse;
	}

	public static Teamcenter.Schemas.Core._2014_06.Digitalsignature.VoidSignaturesInputData toWire(Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.VoidSignaturesInputData local)
	{
		Teamcenter.Schemas.Core._2014_06.Digitalsignature.VoidSignaturesInputData voidSignaturesInputData = new Teamcenter.Schemas.Core._2014_06.Digitalsignature.VoidSignaturesInputData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TargetObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TargetObject.Uid);
		}
		voidSignaturesInputData.setTargetObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Signatureobject.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.Signatureobject[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.Signatureobject[i].Uid);
			}
			arrayList.Add(modelObject2);
		}
		voidSignaturesInputData.setSignatureobject(arrayList);
		voidSignaturesInputData.setComment(local.Comment);
		return voidSignaturesInputData;
	}

	public static Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.VoidSignaturesInputData toLocal(Teamcenter.Schemas.Core._2014_06.Digitalsignature.VoidSignaturesInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.VoidSignaturesInputData voidSignaturesInputData = new Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.VoidSignaturesInputData();
		voidSignaturesInputData.TargetObject = modelManager.LoadObjectData(wire.getTargetObject());
		IList signatureobject = wire.getSignatureobject();
		voidSignaturesInputData.Signatureobject = new Teamcenter.Soa.Client.Model.ModelObject[signatureobject.Count];
		for (int i = 0; i < signatureobject.Count; i++)
		{
			voidSignaturesInputData.Signatureobject[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)signatureobject[i]);
		}
		voidSignaturesInputData.Comment = wire.getComment();
		return voidSignaturesInputData;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData ApplySignatures(Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.ApplySignaturesInputData[] Input)
	{
		try
		{
			restSender.PushRequestId();
			ApplySignaturesInput applySignaturesInput = new ApplySignaturesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			applySignaturesInput.setInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DIGITALSIGNATURE_201406_PORT_NAME, "ApplySignatures", applySignaturesInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesResponse GetSignatureMessages(Teamcenter.Soa.Client.Model.ModelObject[] TargetObject)
	{
		try
		{
			restSender.PushRequestId();
			GetSignatureMessagesInput getSignatureMessagesInput = new GetSignatureMessagesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TargetObject.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (TargetObject[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(TargetObject[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getSignatureMessagesInput.setTargetObject(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DIGITALSIGNATURE_201406_PORT_NAME, "GetSignatureMessages", getSignatureMessagesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesResponse wire = (Teamcenter.Schemas.Core._2014_06.Digitalsignature.GetSignatureMessagesResponse)obj;
			Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.GetSignatureMessagesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData VoidSignatures(Teamcenter.Services.Strong.Core._2014_06.DigitalSignature.VoidSignaturesInputData[] Input, string ElectronicSignature)
	{
		try
		{
			restSender.PushRequestId();
			VoidSignaturesInput voidSignaturesInput = new VoidSignaturesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Input.Length; i++)
			{
				arrayList.Add(toWire(Input[i]));
			}
			voidSignaturesInput.setInput(arrayList);
			voidSignaturesInput.setElectronicSignature(ElectronicSignature);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(DIGITALSIGNATURE_201406_PORT_NAME, "VoidSignatures", voidSignaturesInput, typeFromHandle, extraTypes);
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
}
