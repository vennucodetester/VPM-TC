namespace Teamcenter.Soa.Client.Model.Strong;

public class DCt_Language : WorkspaceObject
{
	public string LanguageName => GetProperty("languageName").StringValue;

	public string IsoLanguageCode => GetProperty("isoLanguageCode").StringValue;

	public string IsoCountryCode => GetProperty("isoCountryCode").StringValue;

	public string LangFileInitials => GetProperty("langFileInitials").StringValue;

	public string LangDescription => GetProperty("langDescription").StringValue;

	public string DefaultPubFont => GetProperty("defaultPubFont").StringValue;

	public string AdminComment => GetProperty("adminComment").StringValue;

	public bool LoginEnabled => GetProperty("loginEnabled").BoolValue;

	public bool MetadataEnabled => GetProperty("metadataEnabled").BoolValue;

	public bool ContentEnabled => GetProperty("contentEnabled").BoolValue;

	public string Fnd0isoLanguageCountryCode => GetProperty("fnd0isoLanguageCountryCode").StringValue;

	public DCt_Language(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
