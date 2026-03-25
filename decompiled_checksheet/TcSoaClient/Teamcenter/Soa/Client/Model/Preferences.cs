using System.Collections;

namespace Teamcenter.Soa.Client.Model;

public interface Preferences
{
	bool DoesExist(string preference);

	ArrayList GetPreference(string preference);
}
