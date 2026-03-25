namespace Teamcenter.Soa.Client.Model.Strong;

public class CondValResult : ValidationResult
{
	public StructureContext Context => (StructureContext)GetProperty("context").ModelObjectValue;

	public Condition Condition => (Condition)GetProperty("condition").ModelObjectValue;

	public ValidationAgentRevision Valagent_revision => (ValidationAgentRevision)GetProperty("valagent_revision").ModelObjectValue;

	public string Condition_desc => GetProperty("condition_desc").StringValue;

	public string Condition_name => GetProperty("condition_name").StringValue;

	public ModelObject Client_target => GetProperty("client_target").ModelObjectValue;

	public CondValResult(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
