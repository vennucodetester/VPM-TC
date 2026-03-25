using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ReferenceImpl : Reference
{
	private readonly string mName;

	private readonly IList<string> mTemplates;

	private readonly IList<string> mFormats;

	public string Name => mName;

	public IList<string> Templates => mTemplates;

	public IList<string> Formats => mFormats;

	public ReferenceImpl(string name, IList<string> templates, IList<string> formats)
	{
		mName = name;
		mTemplates = templates;
		mFormats = formats;
	}
}
