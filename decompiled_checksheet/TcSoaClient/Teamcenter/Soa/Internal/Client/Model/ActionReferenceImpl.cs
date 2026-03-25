using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ActionReferenceImpl : ActionReference
{
	private readonly string mName;

	private readonly bool mExport;

	private readonly Reference mReference;

	public string Name => mName;

	public Reference Reference => mReference;

	public bool IsExport => mExport;

	public ActionReferenceImpl(string name, bool export, Reference reference)
	{
		mName = name;
		mExport = export;
		mReference = reference;
	}
}
