namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccNote : AbsOccData
{
	public string Note_text => GetProperty("note_text").StringValue;

	public NoteType Note_type => (NoteType)GetProperty("note_type").ModelObjectValue;

	public AbsOccNote(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
