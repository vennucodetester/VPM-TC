using System.Collections;

namespace Teamcenter.Soa.Internal.Client.Model;

public class JavaStyleStringCompare : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		string text = (string)x;
		string text2 = (string)y;
		for (int i = 0; i < text.Length && i < text2.Length; i++)
		{
			int num = text[i];
			int num2 = text2[i];
			if (num != num2)
			{
				return num - num2;
			}
		}
		return text.Length - text2.Length;
	}
}
