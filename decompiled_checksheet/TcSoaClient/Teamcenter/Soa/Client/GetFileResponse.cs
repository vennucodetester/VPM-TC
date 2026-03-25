using System.Collections;
using System.IO;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Client;

public class GetFileResponse
{
	private FileInfo[] files = new FileInfo[0];

	private ArrayList partialErrors = new ArrayList();

	public void SetFiles(FileInfo[] files)
	{
		this.files = files;
	}

	public void AddPartialError(ErrorStack partialError)
	{
		partialErrors.Add(partialError);
	}

	public int SizeOfPartialErrors()
	{
		return partialErrors.Count;
	}

	public ErrorStack GetPartialError(int index)
	{
		return (ErrorStack)partialErrors[index];
	}

	public int SizeOfFiles()
	{
		return files.Length;
	}

	public FileInfo[] GetFiles()
	{
		return files;
	}

	public FileInfo GetFile(int index)
	{
		return files[index];
	}
}
