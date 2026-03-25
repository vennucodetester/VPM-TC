namespace Teamcenter.Soa.Client.Model;

public interface ErrorValue
{
	int Code { get; }

	int Level { get; }

	string Message { get; }
}
