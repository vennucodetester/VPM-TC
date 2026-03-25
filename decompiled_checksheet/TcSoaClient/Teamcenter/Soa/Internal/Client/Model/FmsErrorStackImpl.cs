using System;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class FmsErrorStackImpl : ErrorStack
{
	internal class FmsErrorValue : ErrorValue
	{
		protected int code;

		protected int level;

		protected string message;

		public int Code => code;

		public int Level => level;

		public string Message => message;

		public FmsErrorValue(int level, int code, string message)
		{
			this.level = level;
			this.code = code;
			this.message = message;
		}
	}

	private ErrorValue error;

	private string clientId;

	public string ClientId => clientId;

	public int ClientIndex => 0;

	public ModelObject AssociatedObject => null;

	public string[] Messages => new string[1] { error.Message };

	public int[] Codes => new int[1] { error.Code };

	public int[] Levels => new int[1] { error.Level };

	public ErrorValue[] ErrorValues => new ErrorValue[1] { error };

	public FmsErrorStackImpl(string message, string clientId)
	{
		error = new FmsErrorValue(1, 0, message);
		this.clientId = clientId;
	}

	public bool HasClientId()
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public bool HasClientIndex()
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public bool HasAssociatedObject()
	{
		throw new Exception("The method or operation is not implemented.");
	}
}
