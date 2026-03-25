namespace Teamcenter.Soa.Client.Model.Strong;

public class Dataset : WorkspaceObject
{
	public ModelObject[] Ref_list => GetProperty("ref_list").ModelObjectArrayValue;

	public string[] Ref_names => GetProperty("ref_names").StringArrayValue;

	public int[] Ref_types => GetProperty("ref_types").IntArrayValue;

	public string Format_used => GetProperty("format_used").StringValue;

	public string User_class => GetProperty("user_class").StringValue;

	public bool System_managed => GetProperty("system_managed").BoolValue;

	public string Local_path => GetProperty("local_path").StringValue;

	public string Markup_acl => GetProperty("markup_acl").StringValue;

	public bool Markup_official => GetProperty("markup_official").BoolValue;

	public string Markup_status => GetProperty("markup_status").StringValue;

	public string[] Fnd0InstanceAttrExMappings => GetProperty("fnd0InstanceAttrExMappings").StringArrayValue;

	public bool Fnd0IsSignable => GetProperty("fnd0IsSignable").BoolValue;

	public DatasetType Dataset_type => (DatasetType)GetProperty("dataset_type").ModelObjectValue;

	public RevisionAnchor Rev_chain_anchor => (RevisionAnchor)GetProperty("rev_chain_anchor").ModelObjectValue;

	public Tool Tool_used => (Tool)GetProperty("tool_used").ModelObjectValue;

	public Tool Markup_create_tool => (Tool)GetProperty("markup_create_tool").ModelObjectValue;

	public ModelObject[] IMAN_external_object_link => GetProperty("IMAN_external_object_link").ModelObjectArrayValue;

	public ModelObject[] IMAN_Rendering => GetProperty("IMAN_Rendering").ModelObjectArrayValue;

	public string Pubr_object_id => GetProperty("pubr_object_id").StringValue;

	public string Rev => GetProperty("rev").StringValue;

	public int Keep_limit_prop => GetProperty("keep_limit_prop").IntValue;

	public int Highest_rev_prop => GetProperty("highest_rev_prop").IntValue;

	public ModelObject[] Revisions_prop => GetProperty("revisions_prop").ModelObjectArrayValue;

	public string Rev_prop => GetProperty("rev_prop").StringValue;

	public string Id_prop => GetProperty("id_prop").StringValue;

	public ModelObject[] Fnd0FileAccessAuditLogs => GetProperty("fnd0FileAccessAuditLogs").ModelObjectArrayValue;

	public ModelObject[] DgtSignatureByUserRelation => GetProperty("DgtSignatureByUserRelation").ModelObjectArrayValue;

	public bool Fnd0IsCheckOutForSign => GetProperty("fnd0IsCheckOutForSign").BoolValue;

	public Dataset(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
