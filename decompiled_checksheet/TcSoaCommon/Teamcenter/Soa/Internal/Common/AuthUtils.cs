using Teamcenter.Schemas.Core._2006_03.Session;
using Teamcenter.Schemas.Core._2008_06.Session;
using Teamcenter.Schemas.Core._2011_06.Session;
using Teamcenter.Soa.Common.Utils;

namespace Teamcenter.Soa.Internal.Common;

public class AuthUtils
{
	private static readonly string SESSION_0603_SERVICE = "Core-2006-03-Session";

	private static readonly string SESSION_0806_SERVICE = "Core-2008-06-Session";

	private static readonly string SESSION_1106_SERVICE = "Core-2011-06-Session";

	private static readonly string LOGIN_METHOD_NAME = "login";

	private static readonly string SSOLOGIN_METHOD_NAME = "loginsso";

	public static bool IsLoginOperation(string service, string operation)
	{
		string text = operation.ToLower();
		if ((service.Equals(SESSION_0603_SERVICE) || service.Equals(SESSION_0806_SERVICE) || service.Equals(SESSION_1106_SERVICE)) && (text.Equals(LOGIN_METHOD_NAME) || text.Equals(SSOLOGIN_METHOD_NAME)))
		{
			return true;
		}
		return false;
	}

	public static Credentials GetUserCredentials(string service, string operation, string xmlDocument)
	{
		XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();
		object requestObject = null;
		string text = operation.ToLower();
		if (service.Equals(SESSION_0603_SERVICE) && text.Equals(LOGIN_METHOD_NAME))
		{
			requestObject = xmlBindingUtils.Deserialize(xmlDocument, typeof(Teamcenter.Schemas.Core._2006_03.Session.LoginInput), null);
		}
		if (service.Equals(SESSION_0806_SERVICE) && text.Equals(LOGIN_METHOD_NAME))
		{
			requestObject = xmlBindingUtils.Deserialize(xmlDocument, typeof(Teamcenter.Schemas.Core._2008_06.Session.LoginInput), null);
		}
		if (service.Equals(SESSION_1106_SERVICE) && text.Equals(LOGIN_METHOD_NAME))
		{
			requestObject = xmlBindingUtils.Deserialize(xmlDocument, typeof(Teamcenter.Schemas.Core._2011_06.Session.LoginInput), null);
		}
		if (service.Equals(SESSION_0603_SERVICE) && text.Equals(SSOLOGIN_METHOD_NAME))
		{
			requestObject = xmlBindingUtils.Deserialize(xmlDocument, typeof(Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput), null);
		}
		if (service.Equals(SESSION_0806_SERVICE) && text.Equals(SSOLOGIN_METHOD_NAME))
		{
			requestObject = xmlBindingUtils.Deserialize(xmlDocument, typeof(Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput), null);
		}
		if (service.Equals(SESSION_1106_SERVICE) && text.Equals(SSOLOGIN_METHOD_NAME))
		{
			requestObject = xmlBindingUtils.Deserialize(xmlDocument, typeof(Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput), null);
		}
		return GetUserCredentials(requestObject);
	}

	public static Credentials GetUserCredentials(object requestObject)
	{
		Credentials credentials = new Credentials();
		if (requestObject is Teamcenter.Schemas.Core._2006_03.Session.LoginInput)
		{
			Teamcenter.Schemas.Core._2006_03.Session.LoginInput loginInput = (Teamcenter.Schemas.Core._2006_03.Session.LoginInput)requestObject;
			credentials.User = loginInput.Username;
			credentials.Password = loginInput.Password;
			credentials.Group = loginInput.Group;
			credentials.Role = loginInput.Role;
			credentials.Locale = "";
			credentials.Descrimator = loginInput.SessionDiscriminator;
		}
		if (requestObject is Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput)
		{
			Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput loginSSOInput = (Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput)requestObject;
			credentials.User = loginSSOInput.Username;
			credentials.Password = loginSSOInput.SsoCredentials;
			credentials.Group = loginSSOInput.Group;
			credentials.Role = loginSSOInput.Role;
			credentials.Locale = "";
			credentials.Descrimator = loginSSOInput.SessionDiscriminator;
		}
		if (requestObject is Teamcenter.Schemas.Core._2008_06.Session.LoginInput)
		{
			Teamcenter.Schemas.Core._2008_06.Session.LoginInput loginInput2 = (Teamcenter.Schemas.Core._2008_06.Session.LoginInput)requestObject;
			credentials.User = loginInput2.Username;
			credentials.Password = loginInput2.Password;
			credentials.Group = loginInput2.Group;
			credentials.Role = loginInput2.Role;
			credentials.Locale = loginInput2.Locale;
			credentials.Descrimator = loginInput2.SessionDiscriminator;
		}
		if (requestObject is Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput)
		{
			Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput loginSSOInput2 = (Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput)requestObject;
			credentials.User = loginSSOInput2.Username;
			credentials.Password = loginSSOInput2.SsoCredentials;
			credentials.Group = loginSSOInput2.Group;
			credentials.Role = loginSSOInput2.Role;
			credentials.Locale = loginSSOInput2.Locale;
			credentials.Descrimator = loginSSOInput2.SessionDiscriminator;
		}
		if (requestObject is Teamcenter.Schemas.Core._2011_06.Session.LoginInput || requestObject is Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput)
		{
			credentials = ((!(requestObject is Teamcenter.Schemas.Core._2011_06.Session.LoginInput)) ? ((Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput)requestObject).getCredentials() : ((Teamcenter.Schemas.Core._2011_06.Session.LoginInput)requestObject).getCredentials());
		}
		return credentials;
	}
}
