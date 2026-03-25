using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface Tool
{
	string Name { get; }

	IList<ToolAction> Actions { get; }

	string Description { get; }

	string[] InputFormats { get; }

	string[] OutputFormats { get; }

	string LaunchCommandMac { get; }

	string MimeType { get; }

	string PackageName { get; }

	string ReleaseDate { get; }

	string Symbol { get; }

	string VendorName { get; }

	string Version { get; }

	bool IsCallbackEnabled { get; }

	bool IsDigitalSignatureCapable { get; }

	bool IsDownloadRequired { get; }

	bool IsEmbedApplication { get; }

	bool IsMarkupCapable { get; }

	bool IsViewCapable { get; }

	bool IsVviRequired { get; }

	ToolAction GetAction(string name);
}
