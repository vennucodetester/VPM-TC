using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceAttrMapping : POM_object
{
	public bool External => GetProperty("external").BoolValue;

	public AppearanceAttrDefinition[] Mapped_attrs
	{
		get
		{
			IList modelObjectListValue = GetProperty("mapped_attrs").ModelObjectListValue;
			AppearanceAttrDefinition[] array = new AppearanceAttrDefinition[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public NoteType[] Occ_note_types
	{
		get
		{
			IList modelObjectListValue = GetProperty("occ_note_types").ModelObjectListValue;
			NoteType[] array = new NoteType[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AppearanceAttrMapping(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
