namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccData : POM_object
{
	public AbsOccurrence Abs_occ => (AbsOccurrence)GetProperty("abs_occ").ModelObjectValue;

	public AbsOccurrence Parent_absocc => (AbsOccurrence)GetProperty("parent_absocc").ModelObjectValue;

	public AbsOccDataQualifier Data_qualifier => (AbsOccDataQualifier)GetProperty("data_qualifier").ModelObjectValue;

	public double Xt_transform_rot00 => GetProperty("xt_transform_rot00").DoubleValue;

	public double Xt_transform_rot10 => GetProperty("xt_transform_rot10").DoubleValue;

	public double Xt_transform_rot20 => GetProperty("xt_transform_rot20").DoubleValue;

	public double Xt_transform_per0 => GetProperty("xt_transform_per0").DoubleValue;

	public double Xt_transform_rot01 => GetProperty("xt_transform_rot01").DoubleValue;

	public double Xt_transform_rot11 => GetProperty("xt_transform_rot11").DoubleValue;

	public double Xt_transform_rot21 => GetProperty("xt_transform_rot21").DoubleValue;

	public double Xt_transform_per1 => GetProperty("xt_transform_per1").DoubleValue;

	public double Xt_transform_rot02 => GetProperty("xt_transform_rot02").DoubleValue;

	public double Xt_transform_rot12 => GetProperty("xt_transform_rot12").DoubleValue;

	public double Xt_transform_rot22 => GetProperty("xt_transform_rot22").DoubleValue;

	public double Xt_transform_per2 => GetProperty("xt_transform_per2").DoubleValue;

	public double Xt_transform_tra0 => GetProperty("xt_transform_tra0").DoubleValue;

	public double Xt_transform_tra1 => GetProperty("xt_transform_tra1").DoubleValue;

	public double Xt_transform_tra2 => GetProperty("xt_transform_tra2").DoubleValue;

	public double Xt_transform_invscale => GetProperty("xt_transform_invscale").DoubleValue;

	public string Notetext => GetProperty("notetext").StringValue;

	public int Occflags => GetProperty("occflags").IntValue;

	public double Qtyvalue => GetProperty("qtyvalue").DoubleValue;

	public string Seqno => GetProperty("seqno").StringValue;

	public ModelObject Childitem => GetProperty("childitem").ModelObjectValue;

	public string Occname => GetProperty("occname").StringValue;

	public int Instancenumber => GetProperty("instancenumber").IntValue;

	public int Flagvalue => GetProperty("flagvalue").IntValue;

	public int Flagmask => GetProperty("flagmask").IntValue;

	public string Archtype => GetProperty("archtype").StringValue;

	public string Archelemid => GetProperty("archelemid").StringValue;

	public string Logicalpos => GetProperty("logicalpos").StringValue;

	public string[] Usgpartidlist => GetProperty("usgpartidlist").StringArrayValue;

	public string[] Usgprodlist => GetProperty("usgprodlist").StringArrayValue;

	public int Datamask => GetProperty("datamask").IntValue;

	public string Ref_designator => GetProperty("ref_designator").StringValue;

	public int Source => GetProperty("source").IntValue;

	public NoteType Notetype => (NoteType)GetProperty("notetype").ModelObjectValue;

	public PSBOMView Childbv => (PSBOMView)GetProperty("childbv").ModelObjectValue;

	public PSOccurrenceType Occtype => (PSOccurrenceType)GetProperty("occtype").ModelObjectValue;

	public UnitOfMeasure Uom_tag => (UnitOfMeasure)GetProperty("uom_tag").ModelObjectValue;

	public VariantExpressionBlock Variantcondition => (VariantExpressionBlock)GetProperty("variantcondition").ModelObjectValue;

	public VariantExpressionBlock Ucc_vc => (VariantExpressionBlock)GetProperty("ucc_vc").ModelObjectValue;

	public GeneralDesignElement Gdeobject => (GeneralDesignElement)GetProperty("gdeobject").ModelObjectValue;

	public string Absocc_rootline_str => GetProperty("absocc_rootline_str").StringValue;

	public string Absocc_attr_name => GetProperty("absocc_attr_name").StringValue;

	public string Absocc_attr_value => GetProperty("absocc_attr_value").StringValue;

	public string Object_type => GetProperty("object_type").StringValue;

	public AbsOccData(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
