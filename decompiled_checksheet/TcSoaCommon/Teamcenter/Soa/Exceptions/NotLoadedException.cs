using System;
using System.Runtime.Serialization;

namespace Teamcenter.Soa.Exceptions;

[Serializable]
public class NotLoadedException : Exception, ISerializable
{
	public NotLoadedException(string message)
		: base(message)
	{
	}

	public NotLoadedException()
	{
	}

	public NotLoadedException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected NotLoadedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
