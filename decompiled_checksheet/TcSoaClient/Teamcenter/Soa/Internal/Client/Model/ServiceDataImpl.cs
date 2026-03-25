using System.Collections;
using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ServiceDataImpl : Teamcenter.Soa.Client.Model.ServiceData
{
	private IList<Teamcenter.Soa.Client.Model.ModelObject> mCreatedObjects = new List<Teamcenter.Soa.Client.Model.ModelObject>();

	private ArrayList mDeletedUids = new ArrayList();

	private IList<Teamcenter.Soa.Client.Model.ModelObject> mUpdatedObjects = new List<Teamcenter.Soa.Client.Model.ModelObject>();

	private IList<Teamcenter.Soa.Client.Model.ModelObject> mPlainObjects = new List<Teamcenter.Soa.Client.Model.ModelObject>();

	private Teamcenter.Soa.Client.Model.ErrorStack[] mErrorStacks = new Teamcenter.Soa.Client.Model.ErrorStack[0];

	public ServiceDataImpl(ClientDataModel manager, ArrayList createdUids, ArrayList deletedUids, ArrayList updatedUids, ArrayList childUids, ArrayList plainUids, Teamcenter.Soa.Client.Model.ErrorStack[] errorStacks)
	{
		mDeletedUids = deletedUids;
		mErrorStacks = errorStacks;
		foreach (RefId createdUid in createdUids)
		{
			mCreatedObjects.Add(manager.GetObject(createdUid.Uid));
		}
		foreach (RefId updatedUid in updatedUids)
		{
			mUpdatedObjects.Add(manager.GetObject(updatedUid.Uid));
		}
		foreach (RefId plainUid in plainUids)
		{
			mPlainObjects.Add(manager.GetObject(plainUid.Uid));
		}
	}

	public int sizeOfCreatedObjects()
	{
		return mCreatedObjects.Count;
	}

	public int sizeOfDeletedObjects()
	{
		return mDeletedUids.Count;
	}

	public int sizeOfUpdatedObjects()
	{
		return mUpdatedObjects.Count;
	}

	public int sizeOfPlainObjects()
	{
		return mPlainObjects.Count;
	}

	public int sizeOfPartialErrors()
	{
		return mErrorStacks.Length;
	}

	public Teamcenter.Soa.Client.Model.ModelObject GetCreatedObject(int index)
	{
		return mCreatedObjects[index];
	}

	public string GetDeletedObject(int index)
	{
		return ((RefId)mDeletedUids[index]).Uid;
	}

	public Teamcenter.Soa.Client.Model.ModelObject GetUpdatedObject(int index)
	{
		return mUpdatedObjects[index];
	}

	public Teamcenter.Soa.Client.Model.ModelObject GetPlainObject(int index)
	{
		return mPlainObjects[index];
	}

	public Teamcenter.Soa.Client.Model.ErrorStack GetPartialError(int index)
	{
		return mErrorStacks[index];
	}
}
