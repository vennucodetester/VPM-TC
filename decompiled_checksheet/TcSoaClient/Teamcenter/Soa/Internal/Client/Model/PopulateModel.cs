using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public interface PopulateModel
{
	void LoadModelSchema(ModelSchema wireModelSchema);

	Teamcenter.Soa.Client.Model.ServiceData LoadServiceData(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData);

	Teamcenter.Soa.Client.Model.PartialErrors LoadPartialErrors(Teamcenter.Schemas.Soa._2006_03.Base.PartialErrors wirePartial);

	Teamcenter.Soa.Client.Model.ModelObject LoadObjectData(Teamcenter.Schemas.Soa._2006_03.Base.ModelObject wireObj);

	Teamcenter.Soa.Client.Model.ModelObject[] LoadObjectData(ArrayList wireObjs);

	Teamcenter.Soa.Client.Model.Preferences LoadPreferences(Teamcenter.Schemas.Soa._2006_03.Base.Preferences wireObj);

	void LockModel();

	void UnlockModel();
}
