using System;
using System.Collections;
using Teamcenter.Schemas.Core._2006_03.Reservation;
using Teamcenter.Schemas.Core._2008_06.Reservation;
using Teamcenter.Schemas.Core._2011_06.Reservation;
using Teamcenter.Schemas.Core._2014_06.Reservation;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Strong.Core._2006_03.Reservation;
using Teamcenter.Services.Strong.Core._2011_06.Reservation;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class ReservationRestBindingStub : ReservationService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string RESERVATION_200603_PORT_NAME = "Core-2006-03-Reservation";

	private static readonly string RESERVATION_200806_PORT_NAME = "Core-2008-06-Reservation";

	private static readonly string RESERVATION_201106_PORT_NAME = "Core-2011-06-Reservation";

	private static readonly string RESERVATION_201406_PORT_NAME = "Core-2014-06-Reservation";

	public ReservationRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Reservation.GetReservationHistoryResponse toLocal(Teamcenter.Schemas.Core._2006_03.Reservation.GetReservationHistoryResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Reservation.GetReservationHistoryResponse getReservationHistoryResponse = new Teamcenter.Services.Strong.Core._2006_03.Reservation.GetReservationHistoryResponse();
		getReservationHistoryResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList histories = wire.getHistories();
		getReservationHistoryResponse.Histories = new Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistory[histories.Count];
		for (int i = 0; i < histories.Count; i++)
		{
			getReservationHistoryResponse.Histories[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistory)histories[i], modelManager);
		}
		return getReservationHistoryResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistory toWire(Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistory local)
	{
		Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistory reservationHistory = new Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistory();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Object == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Object.Uid);
		}
		reservationHistory.setObject(modelObject);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Events.Length; i++)
		{
			arrayList.Add(toWire(local.Events[i]));
		}
		reservationHistory.setEvents(arrayList);
		return reservationHistory;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistory toLocal(Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistory wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistory reservationHistory = new Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistory();
		reservationHistory.Object = modelManager.LoadObjectData(wire.getObject());
		IList events = wire.getEvents();
		reservationHistory.Events = new Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistoryEvent[events.Count];
		for (int i = 0; i < events.Count; i++)
		{
			reservationHistory.Events[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistoryEvent)events[i], modelManager);
		}
		return reservationHistory;
	}

	public static Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistoryEvent toWire(Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistoryEvent local)
	{
		Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistoryEvent reservationHistoryEvent = new Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistoryEvent();
		reservationHistoryEvent.setDateTime(local.DateTime);
		reservationHistoryEvent.setUser(local.User);
		reservationHistoryEvent.setActivity(local.Activity);
		reservationHistoryEvent.setChangeId(local.ChangeId);
		reservationHistoryEvent.setComment(local.Comment);
		return reservationHistoryEvent;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistoryEvent toLocal(Teamcenter.Schemas.Core._2006_03.Reservation.ReservationHistoryEvent wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistoryEvent reservationHistoryEvent = new Teamcenter.Services.Strong.Core._2006_03.Reservation.ReservationHistoryEvent();
		reservationHistoryEvent.DateTime = wire.getDateTime();
		reservationHistoryEvent.User = wire.getUser();
		reservationHistoryEvent.Activity = wire.getActivity();
		reservationHistoryEvent.ChangeId = wire.getChangeId();
		reservationHistoryEvent.Comment = wire.getComment();
		return reservationHistoryEvent;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData CancelCheckout(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			CancelCheckoutInput cancelCheckoutInput = new CancelCheckoutInput();
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
			cancelCheckoutInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_200603_PORT_NAME, "CancelCheckout", cancelCheckoutInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Soa.Client.Model.ServiceData Checkin(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			CheckinInput checkinInput = new CheckinInput();
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
			checkinInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_200603_PORT_NAME, "Checkin", checkinInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Soa.Client.Model.ServiceData Checkout(Teamcenter.Soa.Client.Model.ModelObject[] Objects, string Comment, string ChangeId)
	{
		try
		{
			restSender.PushRequestId();
			CheckoutInput checkoutInput = new CheckoutInput();
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
			checkoutInput.setObjects(arrayList);
			checkoutInput.setComment(Comment);
			checkoutInput.setChangeId(ChangeId);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_200603_PORT_NAME, "Checkout", checkoutInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Services.Strong.Core._2006_03.Reservation.GetReservationHistoryResponse GetReservationHistory(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			GetReservationHistoryInput getReservationHistoryInput = new GetReservationHistoryInput();
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
			getReservationHistoryInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Reservation.GetReservationHistoryResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_200603_PORT_NAME, "GetReservationHistory", getReservationHistoryInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Reservation.GetReservationHistoryResponse wire = (Teamcenter.Schemas.Core._2006_03.Reservation.GetReservationHistoryResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Reservation.GetReservationHistoryResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData TransferCheckout(Teamcenter.Soa.Client.Model.ModelObject[] Objects, User UserId)
	{
		try
		{
			restSender.PushRequestId();
			TransferCheckoutInput transferCheckoutInput = new TransferCheckoutInput();
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
			transferCheckoutInput.setObjects(arrayList);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (UserId == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(UserId.Uid);
			}
			transferCheckoutInput.setUserId(modelObject2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_200806_PORT_NAME, "TransferCheckout", transferCheckoutInput, typeFromHandle, extraTypes);
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

	public static Teamcenter.Services.Strong.Core._2011_06.Reservation.OkToCheckoutResponse toLocal(Teamcenter.Schemas.Core._2011_06.Reservation.OkToCheckoutResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.Reservation.OkToCheckoutResponse okToCheckoutResponse = new Teamcenter.Services.Strong.Core._2011_06.Reservation.OkToCheckoutResponse();
		okToCheckoutResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList verdict = wire.getVerdict();
		okToCheckoutResponse.Verdict = new bool[verdict.Count];
		for (int i = 0; i < verdict.Count; i++)
		{
			okToCheckoutResponse.Verdict[i] = Convert.ToBoolean(verdict[i]);
		}
		return okToCheckoutResponse;
	}

	public override Teamcenter.Services.Strong.Core._2011_06.Reservation.OkToCheckoutResponse OkToCheckout(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			OkToCheckoutInput okToCheckoutInput = new OkToCheckoutInput();
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
			okToCheckoutInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Reservation.OkToCheckoutResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_201106_PORT_NAME, "OkToCheckout", okToCheckoutInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2011_06.Reservation.OkToCheckoutResponse wire = (Teamcenter.Schemas.Core._2011_06.Reservation.OkToCheckoutResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.Reservation.OkToCheckoutResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Soa.Client.Model.ServiceData BulkCancelCheckout(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			BulkCancelCheckoutInput bulkCancelCheckoutInput = new BulkCancelCheckoutInput();
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
			bulkCancelCheckoutInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_201406_PORT_NAME, "BulkCancelCheckout", bulkCancelCheckoutInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Soa.Client.Model.ServiceData BulkCheckin(Teamcenter.Soa.Client.Model.ModelObject[] Objects)
	{
		try
		{
			restSender.PushRequestId();
			BulkCheckinInput bulkCheckinInput = new BulkCheckinInput();
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
			bulkCheckinInput.setObjects(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_201406_PORT_NAME, "BulkCheckin", bulkCheckinInput, typeFromHandle, extraTypes);
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

	public override Teamcenter.Soa.Client.Model.ServiceData BulkCheckout(Teamcenter.Soa.Client.Model.ModelObject[] Objects, string Comment, string ChangeId, int ReservationType)
	{
		try
		{
			restSender.PushRequestId();
			BulkCheckoutInput bulkCheckoutInput = new BulkCheckoutInput();
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
			bulkCheckoutInput.setObjects(arrayList);
			bulkCheckoutInput.setComment(Comment);
			bulkCheckoutInput.setChangeId(ChangeId);
			bulkCheckoutInput.setReservationType(ReservationType);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(RESERVATION_201406_PORT_NAME, "BulkCheckout", bulkCheckoutInput, typeFromHandle, extraTypes);
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
