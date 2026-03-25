using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class LooseObjectFactory : ModelObjectFactory
{
	public ModelObject ConstructObject(SoaType type, string uid)
	{
		return new ModelObjectImpl(type, uid);
	}
}
