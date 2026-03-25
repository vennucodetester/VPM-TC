using System;
using System.IO;
using System.Text;
using System.Xml;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;

namespace Teamcenter.Soa.Exceptions;

public class ExceptionMapper
{
	protected static string invalidUserExceptionNamespace = GetTargetNameSpace(new InvalidUserException(""));

	protected static string invalidCredentialsExceptionNamespace = GetTargetNameSpace(new InvalidCredentialsException(""));

	protected static string internalServerExceptionNamespace = GetTargetNameSpace(new InternalServerException(""));

	protected static string connectionExceptionNamespace = GetTargetNameSpace(new ConnectionException(""));

	protected static string protocolExceptionNamespace = GetTargetNameSpace(new ProtocolException(""));

	protected static string serviceExceptionNamespace = GetTargetNameSpace(new ServiceException(""));

	private static string EXCEPTION_NAMESPACE = new InternalServerException("").NamespaceURI;

	private static string GetTargetNameSpace(SoaException e)
	{
		return e.NamespaceURI + "/" + e.Localpart;
	}

	public void ThrowSoaException(Exception ex)
	{
		if (ex == null)
		{
			return;
		}
		if (ex is InvalidCredentialsException)
		{
			throw (InvalidCredentialsException)ex;
		}
		if (ex is InvalidUserException)
		{
			throw (InvalidUserException)ex;
		}
		if (ex is InternalServerException)
		{
			throw (InternalServerException)ex;
		}
		if (ex is ServiceException)
		{
			throw (ServiceException)ex;
		}
		throw new InternalServerException(ex.Message, ex);
	}

	public void WriteSoaException(Exception ex, Stream outStream)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			ThrowSoaException(ex);
			return;
		}
		catch (InvalidCredentialsException ex2)
		{
			string localpart = ex2.Localpart;
			string targetNameSpace = GetTargetNameSpace(ex2);
			stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
			stringBuilder.Append("<" + localpart + " xmlns=\"" + targetNameSpace + "\"");
			stringBuilder.Append(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
			stringBuilder.Append("<message xsi:type=\"xsd:string\"");
			stringBuilder.Append(" code=\"" + ex2.Error.Code + "\"");
			stringBuilder.Append(" level=\"" + ex2.Error.Level + "\"");
			stringBuilder.Append(">");
			stringBuilder.Append(Encode(ex2.Error.Message));
			stringBuilder.Append("</message>\n");
			stringBuilder.Append("</" + localpart + ">");
		}
		catch (InvalidUserException ex3)
		{
			string localpart = ex3.Localpart;
			string targetNameSpace = GetTargetNameSpace(ex3);
			stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
			stringBuilder.Append("<" + localpart + " xmlns=\"" + targetNameSpace + "\"");
			stringBuilder.Append(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n");
			stringBuilder.Append("<code xsi:type=\"xsd:int\">" + ex3.Code + "</code>\n");
			stringBuilder.Append("<level xsi:type=\"xsd:int\">" + ex3.Level + "</level>\n");
			stringBuilder.Append("<tcresponse xsi:type=\"xsd:string\">" + ex3.TcResponse + "</tcresponse>\n");
			stringBuilder.Append("<message xsi:type=\"xsd:string\">");
			stringBuilder.Append(Encode(ex3.Message));
			stringBuilder.Append("</message>\n");
			stringBuilder.Append("</" + localpart + ">");
		}
		catch (InternalServerException ex4)
		{
			string localpart = ex4.Localpart;
			string targetNameSpace = GetTargetNameSpace(ex4);
			stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
			stringBuilder.Append("<" + localpart + " xmlns=\"" + targetNameSpace + "\"");
			stringBuilder.Append(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n");
			Error[] errors = ex4.Errors;
			for (int i = 0; i < errors.Length; i++)
			{
				string value = Encode(errors[i].Message);
				stringBuilder.Append("<message xsi:type=\"xsd:string\"");
				stringBuilder.Append(" code=\"" + errors[i].Code + "\"");
				stringBuilder.Append(" level=\"" + errors[i].Level + "\"");
				stringBuilder.Append(">");
				stringBuilder.Append(value);
				stringBuilder.Append("</message>\n");
			}
			stringBuilder.Append("</" + localpart + ">");
		}
		catch (ServiceException ex5)
		{
			string localpart = ex5.Localpart;
			string targetNameSpace = GetTargetNameSpace(ex5);
			stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
			stringBuilder.Append("<" + localpart + " xmlns=\"" + targetNameSpace + "\"");
			stringBuilder.Append(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
			if (ex5.IsUidSet())
			{
				stringBuilder.Append(" uid=\"" + ex5.Uid + "\"");
			}
			if (ex5.isClientIdSet())
			{
				stringBuilder.Append(" clientId=\"" + ex5.ClientId + "\"");
			}
			stringBuilder.Append(">");
			Error[] errors = ex5.Errors;
			for (int i = 0; i < errors.Length; i++)
			{
				string value = Encode(errors[i].Message);
				stringBuilder.Append("<messages xsi:type=\"xsd:string\"");
				stringBuilder.Append(" code=\"" + errors[i].Code + "\"");
				stringBuilder.Append(" level=\"" + errors[i].Level + "\"");
				stringBuilder.Append(">");
				stringBuilder.Append(value);
				stringBuilder.Append("</messages>\n");
			}
			stringBuilder.Append("</" + localpart + ">");
		}
		try
		{
			byte[] bytes = uTF8Encoding.GetBytes(stringBuilder.ToString());
			outStream.Write(bytes, 0, bytes.Length);
		}
		catch (IOException)
		{
		}
	}

	public void ParseExceptionString(string xmlString)
	{
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			int startIndex = xmlString.IndexOf("<");
			xmlDocument.LoadXml(xmlString.Substring(startIndex));
		}
		catch (Exception ex)
		{
			throw new InternalServerException(ex.Message, ex);
		}
		XmlElement firstChildElement = GetFirstChildElement(xmlDocument);
		XmlAttributeCollection attributes = firstChildElement.Attributes;
		string text = "";
		for (int i = 0; i < attributes.Count; i++)
		{
			XmlNode xmlNode = attributes.Item(i);
			if (xmlNode.Name.Equals("xmlns") || xmlNode.LocalName.Equals("xmlns"))
			{
				text = GetElementValue(xmlNode);
				break;
			}
		}
		XmlElement xmlElement = null;
		if (text.Equals(invalidUserExceptionNamespace))
		{
			XmlElement firstChildElement2 = GetFirstChildElement(firstChildElement);
			XmlElement nextSiblingElement = GetNextSiblingElement(firstChildElement2);
			XmlElement nextSiblingElement2 = GetNextSiblingElement(nextSiblingElement);
			xmlElement = GetNextSiblingElement(nextSiblingElement2);
			throw new InvalidUserException(int.Parse(GetElementValue(firstChildElement2)), int.Parse(GetElementValue(nextSiblingElement)), GetElementValue(xmlElement), GetElementValue(nextSiblingElement2));
		}
		if (text.Equals(invalidCredentialsExceptionNamespace))
		{
			xmlElement = GetFirstChildElement(firstChildElement);
			int code = (xmlElement.HasAttribute("code") ? int.Parse(xmlElement.GetAttribute("code")) : 0);
			int level = (xmlElement.HasAttribute("level") ? int.Parse(xmlElement.GetAttribute("level")) : 3);
			throw new InvalidCredentialsException(GetElementValue(xmlElement), code, level);
		}
		if (text.Equals(internalServerExceptionNamespace))
		{
			xmlElement = GetFirstChildElement(firstChildElement);
			InternalServerException ex2 = null;
			while (xmlElement != null)
			{
				string elementValue = GetElementValue(xmlElement);
				int code = (xmlElement.HasAttribute("code") ? int.Parse(xmlElement.GetAttribute("code")) : 0);
				int level = (xmlElement.HasAttribute("level") ? int.Parse(xmlElement.GetAttribute("level")) : 3);
				if (ex2 == null)
				{
					ex2 = new InternalServerException(elementValue, code, level);
				}
				else
				{
					ex2.AddMessage(elementValue, code, level);
				}
				xmlElement = GetNextSiblingElement(xmlElement);
			}
			throw ex2;
		}
		if (text.Equals(connectionExceptionNamespace))
		{
			xmlElement = GetFirstChildElement(firstChildElement);
			int code = (xmlElement.HasAttribute("code") ? int.Parse(xmlElement.GetAttribute("code")) : 0);
			int level = (xmlElement.HasAttribute("level") ? int.Parse(xmlElement.GetAttribute("level")) : 3);
			throw new ConnectionException(GetElementValue(xmlElement), code, level);
		}
		if (text.Equals(protocolExceptionNamespace))
		{
			xmlElement = GetFirstChildElement(firstChildElement);
			int code = (xmlElement.HasAttribute("code") ? int.Parse(xmlElement.GetAttribute("code")) : 0);
			int level = (xmlElement.HasAttribute("level") ? int.Parse(xmlElement.GetAttribute("level")) : 3);
			throw new ProtocolException(GetElementValue(xmlElement), code, level);
		}
		if (text.Equals(serviceExceptionNamespace))
		{
			xmlElement = GetFirstChildElement(firstChildElement);
			ServiceException ex3 = null;
			while (xmlElement != null)
			{
				string elementValue = GetElementValue(xmlElement);
				int code = (xmlElement.HasAttribute("code") ? int.Parse(xmlElement.GetAttribute("code")) : 0);
				int level = (xmlElement.HasAttribute("level") ? int.Parse(xmlElement.GetAttribute("level")) : 3);
				if (ex3 == null)
				{
					ex3 = new ServiceException(elementValue, code, level);
				}
				else
				{
					ex3.AddMessage(elementValue, code, level);
				}
				xmlElement = GetNextSiblingElement(xmlElement);
			}
			attributes = firstChildElement.Attributes;
			for (int i = 0; i < attributes.Count; i++)
			{
				XmlNode xmlNode = attributes.Item(i);
				if (xmlNode.Name.Equals("uid") || xmlNode.LocalName.Equals("uid"))
				{
					ex3.Uid = GetElementValue(xmlNode);
				}
				if (xmlNode.Name.Equals("clientId") || xmlNode.LocalName.Equals("clientId"))
				{
					ex3.ClientId = GetElementValue(xmlNode);
				}
			}
			throw ex3;
		}
		if (firstChildElement.Name.Equals("TcResponse") || firstChildElement.LocalName.Equals("TcResponse"))
		{
			XmlElement firstChildElement3 = GetFirstChildElement(firstChildElement);
			if (firstChildElement3.Name.Equals("TcError") || firstChildElement3.LocalName.Equals("TcError"))
			{
				XmlElement xmlElement2 = GetFirstChildElement(firstChildElement3);
				InternalServerException ex2 = new InternalServerException();
				while (xmlElement2 != null)
				{
					attributes = xmlElement2.Attributes;
					string msg = null;
					int level = 3;
					int code = 0;
					for (int i = 0; i < attributes.Count; i++)
					{
						XmlNode xmlNode = attributes.Item(i);
						if (xmlNode.Name.Equals("code") || xmlNode.LocalName.Equals("code"))
						{
							code = Convert.ToInt32(GetElementValue(xmlNode));
						}
						if (xmlNode.Name.Equals("level") || xmlNode.LocalName.Equals("level"))
						{
							level = Convert.ToInt32(GetElementValue(xmlNode));
						}
						if (xmlNode.Name.Equals("message") || xmlNode.LocalName.Equals("message"))
						{
							msg = GetElementValue(xmlNode);
						}
					}
					ex2.AddMessage(msg, code, level);
					xmlElement2 = GetNextSiblingElement(xmlElement2);
				}
				throw ex2;
			}
			throw new InternalServerException("Unexected xml document.\n" + xmlString);
		}
		throw new InternalServerException("Unknown exception: " + text + "\n" + xmlString);
	}

	public static bool IsException(string xml)
	{
		int num = xml.IndexOf("<") + 1;
		if (xml.Substring(num, 4).Equals("?xml"))
		{
			num = xml.IndexOf('<', num) + 1;
		}
		int num2 = xml.IndexOf(' ', num);
		if (num2 < 0)
		{
			return false;
		}
		string text = xml.Substring(num, num2 - num);
		if (text.StartsWith("TcResponse/>"))
		{
			return false;
		}
		if (text.StartsWith("TcResponse><TcError>"))
		{
			return true;
		}
		num2 = text.IndexOf(':');
		string text2 = ((num2 != -1) ? ("xmlns:" + text.Substring(0, num2) + "=\"") : "xmlns=\"");
		num = xml.IndexOf(text2, num) + text2.Length;
		num2 = xml.IndexOf('"', num);
		string text3 = xml.Substring(num, num2 - num);
		return text3.StartsWith(EXCEPTION_NAMESPACE);
	}

	private XmlElement GetFirstChildElement(XmlNode node)
	{
		XmlNode xmlNode = node.FirstChild;
		while (xmlNode != null && xmlNode.NodeType != XmlNodeType.Element)
		{
			xmlNode = xmlNode.NextSibling;
		}
		return (XmlElement)xmlNode;
	}

	private XmlElement GetNextSiblingElement(XmlNode element)
	{
		XmlNode nextSibling = element.NextSibling;
		while (nextSibling != null && element.NodeType != XmlNodeType.Element)
		{
			nextSibling = element.NextSibling;
		}
		return (XmlElement)nextSibling;
	}

	private string GetElementValue(XmlNode element)
	{
		string text = null;
		text = element.Value;
		if (text == null)
		{
			XmlNode firstChild = element.FirstChild;
			if (firstChild != null)
			{
				text = firstChild.Value;
			}
		}
		return text;
	}

	protected static string Encode(string message)
	{
		message = message.Replace("<", "&lt;");
		message = message.Replace(">", "&gt;");
		message = message.Replace("&", "&amp;");
		message = message.Replace("%", "&#x25;");
		message = message.Replace("\"", "&quot;");
		message = message.Replace("'", "&apos;");
		message = message.Replace("\n", "&#10;");
		message = message.Replace("\t", "&#9;");
		return message;
	}
}
