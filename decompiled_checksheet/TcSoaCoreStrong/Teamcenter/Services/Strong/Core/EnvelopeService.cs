using System;
using Teamcenter.Services.Strong.Core._2011_06.Envelope;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;

namespace Teamcenter.Services.Strong.Core;

public abstract class EnvelopeService : Teamcenter.Services.Strong.Core._2011_06.Envelope.Envelope
{
	public static EnvelopeService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new EnvelopeRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ServiceData SendAndDeleteEnvelopes(Teamcenter.Soa.Client.Model.Strong.Envelope[] Envelopes)
	{
		throw new NotImplementedException();
	}
}
