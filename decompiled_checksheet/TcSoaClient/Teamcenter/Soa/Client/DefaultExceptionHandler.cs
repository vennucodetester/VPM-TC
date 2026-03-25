using System;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Client;

public class DefaultExceptionHandler : ExceptionHandler
{
	public void HandleException(InternalServerException ise)
	{
		Console.Error.WriteLine("The server returned and internal server error.\n" + ise.Message + "\nThe application will terminate.");
		Environment.Exit(1);
	}

	public void HandleException(CanceledOperationException coe)
	{
		Console.Error.WriteLine("It appears that the client cancelled authentication.\n" + coe.Message + "\nUnclear how to proceed.");
		throw new Exception("Error corresponding to CanceledOperationException", coe);
	}
}
