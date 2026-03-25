namespace Teamcenter.Soa.Client.Model;

public interface PartialErrorListener
{
	void HandlePartialError(ErrorStack[] partialErrors);
}
