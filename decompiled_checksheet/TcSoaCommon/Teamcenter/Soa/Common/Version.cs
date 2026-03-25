namespace Teamcenter.Soa.Common;

public class Version
{
	public static readonly string TEAMCENTER_VERSION_LABLEL = "V10000.1.0.30_20141202.00";

	public static readonly string TEAMCENTER_VERSION = "10000.1.0";

	public readonly int major;

	public readonly int minor;

	public readonly int maintenance;

	public Version(int major, int minor, int maintenance)
	{
		this.major = major;
		this.minor = minor;
		this.maintenance = maintenance;
	}

	public Version(string version)
	{
		char[] separator = new char[3] { 'P', 'V', '.' };
		string[] array = version.Split(separator);
		int num = ((array[0].Length <= 0) ? 1 : 0);
		major = int.Parse(array[num]);
		minor = int.Parse(array[num + 1]);
		maintenance = int.Parse(array[num + 2]);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Version))
		{
			return false;
		}
		Version version = (Version)obj;
		return this == version;
	}

	public override int GetHashCode()
	{
		return major + minor + maintenance;
	}

	public static bool operator ==(Version left, Version right)
	{
		if (left.major != right.major)
		{
			return false;
		}
		if (left.minor != right.minor)
		{
			return false;
		}
		if (left.maintenance != right.maintenance)
		{
			return false;
		}
		return true;
	}

	public static bool operator !=(Version left, Version right)
	{
		return !(left == right);
	}

	public static bool operator >(Version left, Version right)
	{
		if (left.major > right.major)
		{
			return true;
		}
		if (left.major == right.major)
		{
			if (left.minor > right.minor)
			{
				return true;
			}
			if (left.minor == right.minor && left.maintenance > right.maintenance)
			{
				return true;
			}
		}
		return false;
	}

	public static bool operator >=(Version left, Version right)
	{
		if (left.major > right.major)
		{
			return true;
		}
		if (left.major == right.major)
		{
			if (left.minor > right.minor)
			{
				return true;
			}
			if (left.minor == right.minor && left.maintenance >= right.maintenance)
			{
				return true;
			}
		}
		return false;
	}

	public static bool operator <(Version left, Version right)
	{
		if (left.major < right.major)
		{
			return true;
		}
		if (left.major == right.major)
		{
			if (left.minor < right.minor)
			{
				return true;
			}
			if (left.minor == right.minor && left.maintenance < right.maintenance)
			{
				return true;
			}
		}
		return false;
	}

	public static bool operator <=(Version left, Version right)
	{
		if (left.major < right.major)
		{
			return true;
		}
		if (left.major == right.major)
		{
			if (left.minor < right.minor)
			{
				return true;
			}
			if (left.minor == right.minor && left.maintenance <= right.maintenance)
			{
				return true;
			}
		}
		return false;
	}
}
