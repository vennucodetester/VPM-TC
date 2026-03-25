using System;
using System.Runtime.Serialization;

namespace Teamcenter.Soa.Exceptions;

[Serializable]
public class CanceledOperationException : Exception, ISerializable
{
	public CanceledOperationException(string message)
		: base(message)
	{
	}

	public CanceledOperationException()
	{
	}

	public CanceledOperationException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected CanceledOperationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
