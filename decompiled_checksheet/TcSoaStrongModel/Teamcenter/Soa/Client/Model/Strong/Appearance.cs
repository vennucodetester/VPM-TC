using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class Appearance : POM_object
{
	public Appearance Parent => (Appearance)GetProperty("parent").ModelObjectValue;

	public AppearanceRoot Appearance_root => (AppearanceRoot)GetProperty("appearance_root").ModelObjectValue;

	public DateTime Creation_date => GetProperty("creation_date").DateValue;

	public double Ext_transform_rot00 => GetProperty("ext_transform_rot00").DoubleValue;

	public double Ext_transform_rot10 => GetProperty("ext_transform_rot10").DoubleValue;

	public double Ext_transform_rot20 => GetProperty("ext_transform_rot20").DoubleValue;

	public double Ext_transform_per0 => GetProperty("ext_transform_per0").DoubleValue;

	public double Ext_transform_rot01 => GetProperty("ext_transform_rot01").DoubleValue;

	public double Ext_transform_rot11 => GetProperty("ext_transform_rot11").DoubleValue;

	public double Ext_transform_rot21 => GetProperty("ext_transform_rot21").DoubleValue;

	public double Ext_transform_per1 => GetProperty("ext_transform_per1").DoubleValue;

	public double Ext_transform_rot02 => GetProperty("ext_transform_rot02").DoubleValue;

	public double Ext_transform_rot12 => GetProperty("ext_transform_rot12").DoubleValue;

	public double Ext_transform_rot22 => GetProperty("ext_transform_rot22").DoubleValue;

	public double Ext_transform_per2 => GetProperty("ext_transform_per2").DoubleValue;

	public double Ext_transform_tra0 => GetProperty("ext_transform_tra0").DoubleValue;

	public double Ext_transform_tra1 => GetProperty("ext_transform_tra1").DoubleValue;

	public double Ext_transform_tra2 => GetProperty("ext_transform_tra2").DoubleValue;

	public double Ext_transform_invscale => GetProperty("ext_transform_invscale").DoubleValue;

	public DateTime Validity_date_in => GetProperty("validity_date_in").DateValue;

	public DateTime Validity_date_out => GetProperty("validity_date_out").DateValue;

	public int Validity_unit_in => GetProperty("validity_unit_in").IntValue;

	public int Validity_unit_out => GetProperty("validity_unit_out").IntValue;

	public bool Is_precise => GetProperty("is_precise").BoolValue;

	public ItemRevision Component_item_rev => (ItemRevision)GetProperty("component_item_rev").ModelObjectValue;

	public Item Component_item => (Item)GetProperty("component_item").ModelObjectValue;

	public PSBOMView Component_bom_view => (PSBOMView)GetProperty("component_bom_view").ModelObjectValue;

	public PSOccurrenceThread Occ_thread => (PSOccurrenceThread)GetProperty("occ_thread").ModelObjectValue;

	public string[] Mapped_attrs => GetProperty("mapped_attrs").StringArrayValue;

	public Appearance(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
