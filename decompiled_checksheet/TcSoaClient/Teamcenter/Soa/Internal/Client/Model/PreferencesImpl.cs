using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PreferencesImpl : Teamcenter.Soa.Client.Model.Preferences
{
	private Hashtable preferences = new Hashtable();

	public PreferencesImpl(Teamcenter.Schemas.Soa._2006_03.Base.Preferences wirePreferences)
	{
		Preference[] prefs = wirePreferences.Prefs;
		foreach (Preference preference in prefs)
		{
			PreferenceValue[] values = preference.Values;
			int num = ((values != null) ? values.Length : 0);
			ArrayList arrayList = new ArrayList(num);
			for (int j = 0; j < num; j++)
			{
				arrayList.Add(values[j].Value);
			}
			preferences.Add(preference.Name, arrayList);
		}
	}

	public bool DoesExist(string preference)
	{
		return preferences.ContainsKey(preference);
	}

	public ArrayList GetPreference(string preference)
	{
		return (ArrayList)preferences[preference];
	}
}
