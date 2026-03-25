using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;

namespace Teamcenter.Soa.Common.Utils;

public class XmlBindingUtils
{
	public byte[] Serialize(object requestObject)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(requestObject.GetType());
			Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
			MemoryStream memoryStream = new MemoryStream();
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Encoding = encoding;
			xmlWriterSettings.NewLineHandling = NewLineHandling.Entitize;
			XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
			xmlSerializer.Serialize(xmlWriter, requestObject);
			byte[] result = memoryStream.ToArray();
			memoryStream.Flush();
			memoryStream.Close();
			return result;
		}
		catch (InvalidOperationException ex)
		{
			string msg = ex.Message + "\n" + ex.InnerException.Message;
			throw new InternalServerException(msg, 101, 3);
		}
	}

	public object Deserialize3(string inpXml, Type type, Type[] extraTypes, Encoding encoding)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			MemoryStream memoryStream = new MemoryStream(StringToEncodedByteArray(inpXml, encoding));
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
			object result = xmlSerializer.Deserialize(memoryStream);
			memoryStream.Close();
			return result;
		}
		catch (InvalidOperationException ex)
		{
			string msg = ex.Message + "\n" + ex.InnerException.Message;
			throw new InternalServerException(msg, 101, 3);
		}
	}

	public object Deserialize2(string inpXml, Type type, Type[] extraTypes)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(type, extraTypes);
			StringReader textReader = new StringReader(inpXml);
			return xmlSerializer.Deserialize(textReader);
		}
		catch (InvalidOperationException ex)
		{
			string msg = ex.Message + "\n" + ex.InnerException.Message;
			throw new InternalServerException(msg, 101, 3);
		}
	}

	public object Deserialize(string inpXml, Type type, Type[] extraTypes)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(inpXml));
			object result = xmlSerializer.Deserialize(memoryStream);
			memoryStream.Close();
			return result;
		}
		catch (InvalidOperationException ex)
		{
			string msg = ex.Message + "\n" + ex.InnerException.Message;
			throw new InternalServerException(msg, 101, 3);
		}
	}

	private static void UnknownAttribute(object sender, XmlAttributeEventArgs e)
	{
		Console.WriteLine("Unknown Attribute: " + e.Attr.OuterXml);
	}

	private static void UnknownElement(object sender, XmlElementEventArgs e)
	{
		Console.WriteLine("Unknown Element: " + e.Element.Name);
	}

	private static void UnknownNode(object sender, XmlNodeEventArgs e)
	{
		Console.WriteLine("Unknown Node:" + e.Name);
	}

	public static string UTF8ByteArrayToString(byte[] chars)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		return uTF8Encoding.GetString(chars);
	}

	public static byte[] StringToUTF8ByteArray(string xmlString)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		return uTF8Encoding.GetBytes(xmlString);
	}

	public static byte[] StringToEncodedByteArray(string xmlString, Encoding encoding)
	{
		return encoding.GetBytes(xmlString);
	}
}
