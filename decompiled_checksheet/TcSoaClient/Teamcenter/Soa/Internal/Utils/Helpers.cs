using System;
using System.Collections;
using System.Globalization;

namespace Teamcenter.Soa.Internal.Utils;

internal class Helpers
{
	public static readonly int MIN_RADIX = 2;

	public static readonly int MAX_RADIX = 36;

	public static char ForDigit(int digit, int radix)
	{
		if (digit >= radix || digit < 0)
		{
			return '\0';
		}
		if (radix < MIN_RADIX || radix > MAX_RADIX)
		{
			return '\0';
		}
		if (digit < 10)
		{
			return (char)(48 + digit);
		}
		return (char)(87 + digit);
	}

	public static bool String2Bool(string s)
	{
		bool result = false;
		if (s == null)
		{
			return false;
		}
		s.Trim();
		if (s.Equals("true") || s.Equals("TRUE"))
		{
			result = true;
		}
		return result;
	}

	public static ArrayList Array2ArrayList(object[] inp)
	{
		ArrayList arrayList = new ArrayList();
		if (inp == null)
		{
			return arrayList;
		}
		for (int i = 0; i < inp.Length; i++)
		{
			arrayList.Add(inp[i]);
		}
		return arrayList;
	}

	public static GregorianCalendar SetTimeInMillis(int timetoAdd)
	{
		DateTime time = new DateTime(1970, 1, 1, 0, 0, 0);
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		gregorianCalendar.AddMilliseconds(time, timetoAdd);
		return gregorianCalendar;
	}
}
