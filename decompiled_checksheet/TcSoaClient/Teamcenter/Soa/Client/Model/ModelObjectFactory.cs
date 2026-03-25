namespace Teamcenter.Soa.Client.Model;

public interface ModelObjectFactory
{
	ModelObject ConstructObject(SoaType type, string uid);
}
