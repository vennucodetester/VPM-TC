namespace Teamcenter.Soa.Client.Model;

public interface PartialErrors
{
	int sizeOfPartialErrors();

	ErrorStack GetPartialError(int index);
}
