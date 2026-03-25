using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class DecisionTable : AppExtensionRuleType
{
	public RBFRow[] Rows
	{
		get
		{
			IList modelObjectListValue = GetProperty("rows").ModelObjectListValue;
			RBFRow[] array = new RBFRow[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public RBFTableColumn[] Table_columns
	{
		get
		{
			IList modelObjectListValue = GetProperty("table_columns").ModelObjectListValue;
			RBFTableColumn[] array = new RBFTableColumn[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public DecisionTable(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
