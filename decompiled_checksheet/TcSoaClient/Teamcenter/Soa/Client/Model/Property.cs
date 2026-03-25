using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Soa.Client.Model;

public abstract class Property
{
	public static readonly DateTime NullDate = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private static readonly CultureInfo serializeLocale = new CultureInfo("en-US", useUserOverride: false);

	[Obsolete("Deprecated as of 8.2 Use DisplayableValue  or DisplayableValues. This method does not distinguish between a property that has one or multiple values. Display value for multiple valued properties are returned as a comma (,) separated list.", false)]
	public abstract string DisplayValue { get; }

	public abstract string DisplayableValue { get; }

	public abstract string[] DisplayableValues { get; }

	public abstract PropertyDescription PropertyDescription { get; }

	public abstract bool Modifiable { get; }

	public abstract bool IsNull { get; }

	public abstract char CharValue { get; }

	public abstract DateTime DateValue { get; }

	public abstract double DoubleValue { get; }

	[Obsolete("Deprecated As of 11.1. Use the FloatValueAsDouble property.", false)]
	public abstract float FloatValue { get; }

	public abstract double FloatValueAsDouble { get; }

	public abstract int IntValue { get; }

	public abstract bool BoolValue { get; }

	public abstract short ShortValue { get; }

	public abstract string StringValue { get; }

	public abstract ModelObject ModelObjectValue { get; }

	public abstract char[] CharArrayValue { get; }

	public abstract DateTime[] DateArrayValue { get; }

	public abstract double[] DoubleArrayValue { get; }

	[Obsolete("Deprecated As of 11.1. Use the FloatArrayValueAsDoubles property.", false)]
	public abstract float[] FloatArrayValue { get; }

	public abstract double[] FloatArrayValueAsDoubles { get; }

	public abstract int[] IntArrayValue { get; }

	public abstract bool[] BoolArrayValue { get; }

	public abstract short[] ShortArrayValue { get; }

	public abstract string[] StringArrayValue { get; }

	public abstract ModelObject[] ModelObjectArrayValue { get; }

	public abstract IList ModelObjectListValue { get; }

	public static bool ParseBoolean(string s)
	{
		if (s != null && (s.Equals("1") || s.Equals("true")))
		{
			return true;
		}
		return false;
	}

	public static string ToBooleanString(bool b)
	{
		return b ? "1" : "0";
	}

	public static char ParseChar(string s)
	{
		if (s == null || s.Length == 0)
		{
			return '\0';
		}
		try
		{
			int num = int.Parse(s);
			if (num < 0 || num > 255)
			{
				string text = "Unable to parse the input string as a Char. Expecting a string value of '0' - '255'. ";
				text = text + "Received the string '" + s + "'.";
				throw new ArgumentException(text);
			}
			return (char)num;
		}
		catch (FormatException)
		{
			string text = "Unable to parse the input string as a Char. Expecting a string value of '0' - '255'. ";
			text = text + "Received the string '" + s + "'.";
			throw new ArgumentException(text);
		}
	}

	public static string ToCharString(char c)
	{
		return Convert.ToString((int)c);
	}

	public static DateTime ParseDate(string s)
	{
		return TcServerDate.Parse(s);
	}

	public static string ToDateString(DateTime c)
	{
		return TcServerDate.ToString(c);
	}

	public static double ParseDouble(string s)
	{
		if (s == null || s.Length == 0)
		{
			return 0.0;
		}
		return double.Parse(s, serializeLocale);
	}

	public static string ToDoubleString(double d)
	{
		return d.ToString(serializeLocale);
	}

	public static float ParseFloat(string s)
	{
		if (s == null || s.Length == 0)
		{
			return 0f;
		}
		return float.Parse(s, serializeLocale);
	}

	public static string ToFloatString(float f)
	{
		return f.ToString(serializeLocale);
	}

	public static int ParseInt(string s)
	{
		if (s == null || s.Length == 0)
		{
			return 0;
		}
		return int.Parse(s);
	}

	public static string ToIntString(int i)
	{
		return i.ToString();
	}

	public static short ParseShort(string s)
	{
		if (s == null || s.Length == 0)
		{
			return 0;
		}
		return short.Parse(s);
	}

	public static string ToShortString(short s)
	{
		return s.ToString();
	}

	public static string ToModelObjectString(ModelObject m)
	{
		return m.Uid;
	}

	public string ToNeutralString()
	{
		if (PropertyDescription.Array)
		{
			return ToNeutralStrings()[0];
		}
		return PropertyDescription.Type switch
		{
			0 => ToCharString(CharValue), 
			1 => ToDateString(DateValue), 
			2 => ToDoubleString(DoubleValue), 
			3 => ToDoubleString(FloatValueAsDouble), 
			4 => ToIntString(IntValue), 
			5 => ToBooleanString(BoolValue), 
			6 => ToShortString(ShortValue), 
			7 => StringValue, 
			8 => ToModelObjectString(ModelObjectValue), 
			_ => "", 
		};
	}

	public IList<string> ToNeutralStrings()
	{
		List<string> list = new List<string>();
		if (!PropertyDescription.Array)
		{
			list.Add(ToNeutralString());
			return list;
		}
		switch (PropertyDescription.Type)
		{
		case 0:
		{
			char[] charArrayValue = CharArrayValue;
			for (int i = 0; i < charArrayValue.Length; i++)
			{
				list.Add(ToCharString(charArrayValue[i]));
			}
			break;
		}
		case 1:
		{
			DateTime[] dateArrayValue = DateArrayValue;
			for (int i = 0; i < dateArrayValue.Length; i++)
			{
				list.Add(ToDateString(dateArrayValue[i]));
			}
			break;
		}
		case 2:
		{
			double[] floatArrayValueAsDoubles = DoubleArrayValue;
			for (int i = 0; i < floatArrayValueAsDoubles.Length; i++)
			{
				list.Add(ToDoubleString(floatArrayValueAsDoubles[i]));
			}
			break;
		}
		case 3:
		{
			double[] floatArrayValueAsDoubles = FloatArrayValueAsDoubles;
			for (int i = 0; i < floatArrayValueAsDoubles.Length; i++)
			{
				list.Add(ToDoubleString(floatArrayValueAsDoubles[i]));
			}
			break;
		}
		case 4:
		{
			int[] intArrayValue = IntArrayValue;
			for (int i = 0; i < intArrayValue.Length; i++)
			{
				list.Add(ToIntString(intArrayValue[i]));
			}
			break;
		}
		case 5:
		{
			bool[] boolArrayValue = BoolArrayValue;
			for (int i = 0; i < boolArrayValue.Length; i++)
			{
				list.Add(ToBooleanString(boolArrayValue[i]));
			}
			break;
		}
		case 6:
		{
			short[] shortArrayValue = ShortArrayValue;
			for (int i = 0; i < shortArrayValue.Length; i++)
			{
				list.Add(ToShortString(shortArrayValue[i]));
			}
			break;
		}
		case 7:
		{
			string[] stringArrayValue = StringArrayValue;
			for (int i = 0; i < stringArrayValue.Length; i++)
			{
				list.Add(stringArrayValue[i]);
			}
			break;
		}
		case 8:
		{
			ModelObject[] modelObjectArrayValue = ModelObjectArrayValue;
			for (int i = 0; i < modelObjectArrayValue.Length; i++)
			{
				list.Add(ToModelObjectString(modelObjectArrayValue[i]));
			}
			break;
		}
		}
		return list;
	}
}
