using System;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class TcServerDate
{
	private static readonly string wireFormat = "M/d/yyyy h:mm tt";

	private static readonly string xsdFormat = "yyyy-MM-dd'T'HH:mm:sszzzz";

	private static readonly string serverNullDateString = "0001-01-01T00:00:00+00:00";

	private static readonly string localNullString = DateTime.Parse(serverNullDateString).ToString(wireFormat);

	public static DateTime ToWire(DateTime local)
	{
		return local;
	}

	public static DateTime ToLocal(DateTime wire)
	{
		if (wire.ToString(wireFormat) == localNullString)
		{
			return Property.NullDate;
		}
		return wire;
	}

	public static DateTime Parse(string wireString)
	{
		if (wireString == null || wireString.Length == 0 || wireString == serverNullDateString)
		{
			return Property.NullDate;
		}
		try
		{
			return DateTime.Parse(wireString);
		}
		catch (FormatException)
		{
			string text = "Unable to parse the input string as a Date. Expecting a string with the syntax of 'yyyy-MM-dd'T'HH:mm:ssZ'. ";
			text = text + "Received the string '" + wireString + "'.";
			throw new ArgumentException(text);
		}
	}

	public static string ToString(DateTime local)
	{
		return local.ToString(xsdFormat);
	}
}
