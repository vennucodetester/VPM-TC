namespace Teamcenter.Soa.Client.Model;

public abstract class ModelEventListener
{
	public virtual void LocalObjectCreate(ModelObject[] createdObjs)
	{
	}

	public virtual void LocalObjectChange(ModelObject[] changedObjs)
	{
	}

	public virtual void LocalObjectDelete(string[] deletedUids)
	{
	}

	public virtual void SharedObjectCreate(ModelObject[] createdObjs)
	{
	}

	public virtual void SharedObjectChange(ModelObject[] changedObjs)
	{
	}

	public virtual void SharedObjectDelete(string[] deletedUids)
	{
	}
}
