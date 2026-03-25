using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class DataTypeRef : POM_object
{
	public DataType DataType => (DataType)GetProperty("dataType").ModelObjectValue;

	public string Qualifier => GetProperty("qualifier").StringValue;

	public DataTypeRef[] Params
	{
		get
		{
			IList modelObjectListValue = GetProperty("params").ModelObjectListValue;
			DataTypeRef[] array = new DataTypeRef[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public DataTypeRef(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
