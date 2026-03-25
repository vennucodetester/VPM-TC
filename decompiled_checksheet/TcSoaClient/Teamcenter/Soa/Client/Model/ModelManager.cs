using System;
using System.Collections.Generic;

namespace Teamcenter.Soa.Client.Model;

public interface ModelManager
{
	ModelObject GetObject(string uid);

	IList<ModelObject> GetAllObjectsFromStore();

	List<SoaType> GetTypes(string[] typeNames);

	ModelObject ConstructObject(string typeStr, string uid);

	ModelObject ConstructObject(string uid);

	void RemoveObjectsFromStore(ModelObject[] objects);

	void RemoveAllObjectsFromStore();

	void RemoveObjectsFromStore(string[] uids);

	[Obsolete("Deprecated Tc9.0. Use setModelEventListener")]
	void AddChangeListener(ChangeListener listener);

	[Obsolete("Deprecated Tc9.0. Use setModelEventListener")]
	void RemoveChangeListener(ChangeListener listener);

	[Obsolete("Deprecated Tc9.0. Use setModelEventListener")]
	void AddCreateListener(CreateListener listener);

	[Obsolete("Deprecated in Tc9.0. Use setModelEventListener")]
	void RemoveCreateListener(CreateListener listener);

	[Obsolete("Deprecated in Tc9.0. Use setModelEventListener")]
	void AddDeleteListener(DeleteListener listener);

	[Obsolete("Deprecated in Tc9.0. Use setModelEventListener")]
	void RemoveDeleteListener(DeleteListener listener);

	void AddPartialErrorListener(PartialErrorListener listener);

	void RemovePartialErrorListener(PartialErrorListener listener);

	SoaType GetSoaType(string typeName);

	IList<SoaType> GetSoaTypes(IList<string> typeNames);

	void RemoveObjectsRecursivelyFromStore(IList<ModelObject> objects);

	ModelObject GetUserSessionObject();

	void AddModelEventListener(ModelEventListener listener);

	void RemoveModelEventListener(ModelEventListener listener);

	void AddSharedSessionHandler(SessionHandler handler);

	void RemoveSharedSessionHandler(SessionHandler handler);
}
