using System;
using System.Collections;
using Teamcenter.Schemas.Core._2010_04.Languageinformation;
using Teamcenter.Services.Strong.Core._2010_04.LanguageInformation;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class LanguageInformationRestBindingStub : LanguageInformationService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Connection localConnection;

	private static readonly string LANGUAGEINFORMATION_201004_PORT_NAME = "Core-2010-04-LanguageInformation";

	public LanguageInformationRestBindingStub(Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2010_04.Languageinformation.FullTranslationStatus toWire(Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.FullTranslationStatus local)
	{
		Teamcenter.Schemas.Core._2010_04.Languageinformation.FullTranslationStatus fullTranslationStatus = new Teamcenter.Schemas.Core._2010_04.Languageinformation.FullTranslationStatus();
		fullTranslationStatus.setStatus(local.Status);
		fullTranslationStatus.setStatusName(local.StatusName);
		fullTranslationStatus.setStatusDescription(local.StatusDescription);
		return fullTranslationStatus;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.FullTranslationStatus toLocal(Teamcenter.Schemas.Core._2010_04.Languageinformation.FullTranslationStatus wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.FullTranslationStatus fullTranslationStatus = new Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.FullTranslationStatus();
		fullTranslationStatus.Status = wire.getStatus();
		fullTranslationStatus.StatusName = wire.getStatusName();
		fullTranslationStatus.StatusDescription = wire.getStatusDescription();
		return fullTranslationStatus;
	}

	public static Teamcenter.Schemas.Core._2010_04.Languageinformation.Language toWire(Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.Language local)
	{
		Teamcenter.Schemas.Core._2010_04.Languageinformation.Language language = new Teamcenter.Schemas.Core._2010_04.Languageinformation.Language();
		language.setLanguageCode(local.LanguageCode);
		language.setLanguageName(local.LanguageName);
		return language;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.Language toLocal(Teamcenter.Schemas.Core._2010_04.Languageinformation.Language wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.Language language = new Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.Language();
		language.LanguageCode = wire.getLanguageCode();
		language.LanguageName = wire.getLanguageName();
		return language;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.LanguageResponse toLocal(Teamcenter.Schemas.Core._2010_04.Languageinformation.LanguageResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.LanguageResponse languageResponse = new Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.LanguageResponse();
		languageResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList languageList = wire.getLanguageList();
		languageResponse.LanguageList = new Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.Language[languageList.Count];
		for (int i = 0; i < languageList.Count; i++)
		{
			languageResponse.LanguageList[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Languageinformation.Language)languageList[i], modelManager);
		}
		return languageResponse;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.TranslationStatusResponse toLocal(Teamcenter.Schemas.Core._2010_04.Languageinformation.TranslationStatusResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.TranslationStatusResponse translationStatusResponse = new Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.TranslationStatusResponse();
		translationStatusResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList fullTranslationStatuses = wire.getFullTranslationStatuses();
		translationStatusResponse.FullTranslationStatuses = new Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.FullTranslationStatus[fullTranslationStatuses.Count];
		for (int i = 0; i < fullTranslationStatuses.Count; i++)
		{
			translationStatusResponse.FullTranslationStatuses[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Languageinformation.FullTranslationStatus)fullTranslationStatuses[i], modelManager);
		}
		return translationStatusResponse;
	}

	public override Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.TranslationStatusResponse GetAllTranslationStatuses()
	{
		try
		{
			restSender.PushRequestId();
			GetAllTranslationStatusesInput requestObject = new GetAllTranslationStatusesInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Languageinformation.TranslationStatusResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(LANGUAGEINFORMATION_201004_PORT_NAME, "GetAllTranslationStatuses", requestObject, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Languageinformation.TranslationStatusResponse wire = (Teamcenter.Schemas.Core._2010_04.Languageinformation.TranslationStatusResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.TranslationStatusResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.LanguageResponse GetLanguagesList(string Scenario)
	{
		try
		{
			restSender.PushRequestId();
			GetLanguagesListInput getLanguagesListInput = new GetLanguagesListInput();
			getLanguagesListInput.setScenario(Scenario);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Languageinformation.LanguageResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(LANGUAGEINFORMATION_201004_PORT_NAME, "GetLanguagesList", getLanguagesListInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Languageinformation.LanguageResponse wire = (Teamcenter.Schemas.Core._2010_04.Languageinformation.LanguageResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.LanguageInformation.LanguageResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}
}
