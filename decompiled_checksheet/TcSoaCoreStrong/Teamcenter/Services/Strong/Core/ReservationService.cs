using System;
using Teamcenter.Services.Strong.Core._2006_03.Reservation;
using Teamcenter.Services.Strong.Core._2008_06.Reservation;
using Teamcenter.Services.Strong.Core._2011_06.Reservation;
using Teamcenter.Services.Strong.Core._2014_06.Reservation;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Core;

public abstract class ReservationService : Teamcenter.Services.Strong.Core._2006_03.Reservation.Reservation, Teamcenter.Services.Strong.Core._2008_06.Reservation.Reservation, Teamcenter.Services.Strong.Core._2011_06.Reservation.Reservation, Teamcenter.Services.Strong.Core._2014_06.Reservation.Reservation
{
	public static ReservationService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new ReservationRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ServiceData CancelCheckout(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData Checkin(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData Checkout(ModelObject[] Objects, string Comment, string ChangeId)
	{
		throw new NotImplementedException();
	}

	public virtual GetReservationHistoryResponse GetReservationHistory(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData TransferCheckout(ModelObject[] Objects, User UserId)
	{
		throw new NotImplementedException();
	}

	public virtual OkToCheckoutResponse OkToCheckout(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData BulkCancelCheckout(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData BulkCheckin(ModelObject[] Objects)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData BulkCheckout(ModelObject[] Objects, string Comment, string ChangeId, int ReservationType)
	{
		throw new NotImplementedException();
	}
}
