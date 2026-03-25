using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Soa.Client.Model;

public class NullModelObject
{
	public static readonly string NULL_ID = "AAAAAAAAAAAAAA";

	public static readonly ModelObject NullObject = new ModelObjectImpl(null, "AAAAAAAAAAAAAA");

	public static readonly string UNKNOWN_TYPE = "unknownType";

	public static ModelObject Get()
	{
		return NullObject;
	}
}
