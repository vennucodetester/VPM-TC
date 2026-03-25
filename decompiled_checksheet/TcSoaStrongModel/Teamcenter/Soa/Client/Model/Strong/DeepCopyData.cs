namespace Teamcenter.Soa.Client.Model.Strong;

public class DeepCopyData : OperationInput
{
	public ModelObject AttachedObject => GetProperty("attachedObject").ModelObjectValue;

	public ModelObject[] ChildDeepCopyData => GetProperty("childDeepCopyData").ModelObjectArrayValue;

	public bool IsRequired => GetProperty("isRequired").BoolValue;

	public bool IsTargetPrimary => GetProperty("isTargetPrimary").BoolValue;

	public ModelObject OperationInputTypeDesc => GetProperty("operationInputTypeDesc").ModelObjectValue;

	public string PropertyName => GetProperty("propertyName").StringValue;

	public int PropertyType => GetProperty("propertyType").IntValue;

	public ModelObject AttachedObjectCopy => GetProperty("attachedObjectCopy").ModelObjectValue;

	public ModelObject OperationInput => GetProperty("operationInput").ModelObjectValue;

	public int CopyAction => GetProperty("copyAction").IntValue;

	public ModelObject SourceObject => GetProperty("sourceObject").ModelObjectValue;

	public ModelObject TargetObject => GetProperty("targetObject").ModelObjectValue;

	public ModelObject[] ParentDeepCopyData => GetProperty("parentDeepCopyData").ModelObjectArrayValue;

	public bool Copy_relations => GetProperty("copy_relations").BoolValue;

	public DeepCopyData(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
