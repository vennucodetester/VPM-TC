namespace Teamcenter.Soa.Client.Model;

public interface ChangeListener
{
	void ModelObjectChange(ModelObject[] changedObjs);
}
