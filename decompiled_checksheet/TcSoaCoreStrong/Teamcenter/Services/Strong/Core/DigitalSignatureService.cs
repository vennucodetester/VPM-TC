using System;
using Teamcenter.Services.Strong.Core._2014_06.DigitalSignature;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public abstract class DigitalSignatureService : DigitalSignature
{
	public static DigitalSignatureService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new DigitalSignatureRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual ServiceData ApplySignatures(ApplySignaturesInputData[] Input)
	{
		throw new NotImplementedException();
	}

	public virtual GetSignatureMessagesResponse GetSignatureMessages(ModelObject[] TargetObject)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData VoidSignatures(VoidSignaturesInputData[] Input, string ElectronicSignature)
	{
		throw new NotImplementedException();
	}
}
