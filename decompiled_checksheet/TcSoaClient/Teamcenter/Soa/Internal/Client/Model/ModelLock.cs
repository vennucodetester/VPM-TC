using System.Runtime.CompilerServices;
using System.Threading;
using Teamcenter.Soa.Client;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ModelLock
{
	private bool mIsLocked = false;

	private Thread mLockedBy = null;

	private int mLockedCount = 0;

	private Connection mConnection = null;

	public ModelLock(Connection connection)
	{
		mConnection = connection;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void Lock()
	{
		if (mConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
		{
			mIsLocked = false;
			mLockedBy = null;
			mLockedCount = 0;
			return;
		}
		Thread currentThread = Thread.CurrentThread;
		while (mIsLocked && mLockedBy != currentThread)
		{
			try
			{
				Monitor.Wait(this);
			}
			catch (ThreadInterruptedException)
			{
			}
			catch (SynchronizationLockException)
			{
			}
		}
		mIsLocked = true;
		mLockedCount++;
		mLockedBy = currentThread;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void Unlock()
	{
		Thread currentThread = Thread.CurrentThread;
		if (mIsLocked && currentThread == mLockedBy)
		{
			mLockedCount--;
			if (mLockedCount <= 0)
			{
				mIsLocked = false;
				mLockedBy = null;
				mLockedCount = 0;
				Monitor.Pulse(this);
			}
		}
	}
}
