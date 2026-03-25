using System;
using Teamcenter.Services.Strong.Core._2010_04.LanguageInformation;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;

namespace Teamcenter.Services.Strong.Core;

public abstract class LanguageInformationService : LanguageInformation
{
	public static LanguageInformationService getService(Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new LanguageInformationRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	public virtual TranslationStatusResponse GetAllTranslationStatuses()
	{
		throw new NotImplementedException();
	}

	public virtual LanguageResponse GetLanguagesList(string Scenario)
	{
		throw new NotImplementedException();
	}
}
