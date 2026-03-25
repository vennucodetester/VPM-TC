namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccXform : AbsOccData
{
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

	public AbsOccXform(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
