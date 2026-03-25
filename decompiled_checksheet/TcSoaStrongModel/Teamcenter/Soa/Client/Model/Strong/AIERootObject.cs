using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIERootObject : POM_application_object
{
	public ModelObject Target_object => GetProperty("target_object").ModelObjectValue;

	public ModelObject[] Child_datasets => GetProperty("child_datasets").ModelObjectArrayValue;

	public ModelObject Item_revision => GetProperty("item_revision").ModelObjectValue;

	public bool Root_configured => GetProperty("root_configured").BoolValue;

	public bool Export_as_assembly => GetProperty("export_as_assembly").BoolValue;

	public ModelObject Naming_rule => GetProperty("naming_rule").ModelObjectValue;

	public DateTime Effectivity_date => GetProperty("effectivity_date").DateValue;

	public VariantRule Variant_rule => (VariantRule)GetProperty("variant_rule").ModelObjectValue;

	public RevisionRule Revision_rule => (RevisionRule)GetProperty("revision_rule").ModelObjectValue;

	public Folder Override_folder => (Folder)GetProperty("override_folder").ModelObjectValue;

	public AIERootObject(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
