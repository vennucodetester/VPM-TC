using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ErrorStackImpl : Teamcenter.Soa.Client.Model.ErrorStack
{
	private Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack wireError;

	private ClientDataModel clientDataModel;

	public string ClientId => wireError.ClientId;

	public int ClientIndex => wireError.ClientIndex;

	public Teamcenter.Soa.Client.Model.ModelObject AssociatedObject
	{
		get
		{
			if (HasAssociatedObject())
			{
				return clientDataModel.GetObject(wireError.Uid);
			}
			return null;
		}
	}

	public string[] Messages
	{
		get
		{
			Teamcenter.Soa.Client.Model.ErrorValue[] errorValues = ErrorValues;
			string[] array = new string[errorValues.Length];
			for (int i = 0; i < errorValues.Length; i++)
			{
				array[i] = errorValues[i].Message;
			}
			return array;
		}
	}

	public int[] Codes
	{
		get
		{
			Teamcenter.Soa.Client.Model.ErrorValue[] errorValues = ErrorValues;
			int length = errorValues.GetLength(0);
			int[] array = new int[errorValues.Length];
			for (int i = 0; i < errorValues.Length; i++)
			{
				array[i] = errorValues[i].Code;
			}
			return array;
		}
	}

	public int[] Levels
	{
		get
		{
			Teamcenter.Soa.Client.Model.ErrorValue[] errorValues = ErrorValues;
			int[] array = new int[errorValues.Length];
			for (int i = 0; i < errorValues.Length; i++)
			{
				array[i] = errorValues[i].Code;
			}
			return array;
		}
	}

	public Teamcenter.Soa.Client.Model.ErrorValue[] ErrorValues
	{
		get
		{
			IList errorValues = wireError.ErrorValues;
			Teamcenter.Soa.Client.Model.ErrorValue[] array = new Teamcenter.Soa.Client.Model.ErrorValue[errorValues.Count];
			for (int i = 0; i < errorValues.Count; i++)
			{
				array[i] = new ErrorValueImpl((Teamcenter.Schemas.Soa._2006_03.Base.ErrorValue)errorValues[i]);
			}
			return array;
		}
	}

	public ErrorStackImpl(Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack wireError, ClientDataModel clientDataModel)
	{
		this.wireError = wireError;
		this.clientDataModel = clientDataModel;
	}

	public bool HasClientId()
	{
		return wireError.ClientId != null && wireError.ClientId.Length > 0;
	}

	public bool HasClientIndex()
	{
		if (HasClientId() || HasAssociatedObject())
		{
			return false;
		}
		return true;
	}

	public bool HasAssociatedObject()
	{
		return wireError.Uid != null && wireError.Uid.Length > 0;
	}
}
