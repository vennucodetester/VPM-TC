using System;
using System.Runtime.Serialization;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class FMSException : Exception, ISerializable
{
	protected int errCode = 0;

	public int ErrorCode
	{
		get
		{
			return errCode;
		}
		set
		{
			errCode = value;
		}
	}

	public FMSException()
	{
	}

	public FMSException(string s)
		: base(s)
	{
	}

	public FMSException(string s, Exception inner)
		: base(s, inner)
	{
	}

	protected FMSException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		errCode = info.GetInt32("FMSErrorCode");
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("FMSErrorCode", errCode);
	}

	public FMSException(int code, string s, Exception inner)
		: base(s, inner)
	{
		errCode = code;
	}

	public FMSException(int code, string s)
		: base(s)
	{
		errCode = code;
	}
}
