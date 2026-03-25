using Teamcenter.Soa.Client.Model;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class DefaultClientDataModel : ClientDataModel
{
	private ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();

	private static ILog logger = LogManager.GetLogger(typeof(DefaultClientDataModel));

	protected override ModelObject LoadObject(SoaType type, string uid)
	{
		ModelManagerImpl.LogDebug(ClassNames.DefaultClientDataModel, logger, "ObjectFactory.constructModelObject", type.Name + "," + uid);
		return objectFactory.ConstructModelObject(type, uid);
	}

	protected override void RefineType(ModelObject obj, SoaType type)
	{
		ModelManagerImpl.LogDebug(ClassNames.DefaultClientDataModel, logger, "ObjectFactory.refineType", obj.Uid);
		if (!objectFactory.RefineType(obj, type))
		{
			logger.Warn("Couldn't refine type to " + type.Name + " for obj " + obj.Uid);
		}
	}
}
