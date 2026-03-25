using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Rapid_Check.My;

namespace Rapid_Check;

[StandardModule]
public sealed class Declarations
{
	public enum Input_type
	{
		ECN,
		ItemID,
		MultipleItemID,
		ECN_CheckSheet,
		MultipleItemIDFolder,
		Unknown
	}

	public enum Excel_Colour
	{
		White = 0,
		Green = 4,
		Red = 3,
		Yellow = 6
	}

	public static string gToolVersion = string.Empty;

	public static string gToolName = string.Empty;

	public static string SiteLoc = string.Empty;

	public const string OOTB_CHG_NOTICE_REV_CLASS = "ChangeNoticeRevision";

	public const string OOTB_OWNING_GRP = "owning_group";

	public const string OOTB_PROJECT_IDS = "project_ids";

	public const string HSM_CAP_CHG_NOTICE_REV_CLASS = "H4_ECN_CAPRevision";

	public const string HSM_COD_CHG_NOTICE_REV_CLASS = "H4_ECN_CODRevision";

	public const string HSM_NPD_CHG_NOTICE_REV_CLASS = "H4_ECN_NPDRevision";

	public const string HSM_VAVE_CHG_NOTICE_REV_CLASS = "H4_ECN_VAVERevision";

	public const string OOTB_ITEM_REV_QRY = "Item Revision...";

	public const string OOTB_ITEM_QRY = "Item...";

	public const string HSM_DEFAULT_VIEW_NAME = "PLM View";

	public const string OOTB_VIEW_TYPE_ATTR = "view_type";

	public const string HSM_DEFAULT_REV_RULE = "HSM_WIP_Latest_Production_Released";

	public const string HSM_ITEM_REV_CLASS = "H4_Hussmann_ItemRevision";

	public const string HSM_ITEM_CLASS = "H4_Hussmann_Item";

	public const string OOTB_BOMLINE_CLASS = "BOMLine";

	public const string OOTB_CM_HAS_SOLUTION_ITEM_REL = "CMHasSolutionItem";

	public const string OOTB_REV_RULE_CLASS = "RevisionRule";

	public const string OOTB_ITEM_ID_ATTR = "item_id";

	public const string OOTB_ANALYST_USER_ID = "analyst_user_id";

	public const string OOTB_OWNING_USER = "owning_user";

	public const string OOTB_UOM = "uom_tag";

	public const string OOTB_ITEM_TYPE = "h4_Hussmann_Item_Type";

	public const string OOTB_ITEMS_TAG_ATTR = "items_tag";

	public const string OOTB_ITEM_REV_ID_ATTR = "item_revision_id";

	public const string OOTB_OBJECT_NAME_ATTR = "object_name";

	public const string OOTB_Description = "object_desc";

	public const string Custom_Nomenclature = "h4_Nomenclature";

	public const string Custom_BGN_Source = "h4_BGN_Source";

	public const string Custom_BBK_Source = "h4_BBK_Source";

	public const string Custom_CNO_Source = "h4_CNO_Source";

	public const string Custom_HAB_Source = "h4_HAB_Source";

	public const string Custom_MTY_Source = "h4_MTY_Source";

	public const string Custom_SWN_Source = "h4_SWN_Source";

	public const string Custom_BOM_Option_Code = "h4_BOM_Option_Code";

	public const string Custom_ECN_Number = "h4_ECN_Number";

	public const string Custom_Finish_Code = "h4_Finish_Code";

	public const string Custom_Finish_Color = "h4_Finish_Color";

	public const string Custom_Risk_Level = "h4_Risk_Level";

	public const string Custom_High_Level_Category = "h4_High_Level_Category";

	public const string Custom_Sub_Category = "h4_Sub_Category";

	public const string Custom_Hussmann_Item_Type = "h4_Hussmann_Item_Type";

	public const string Custom_Master_Template = "h4_Template_Name";

	public const string Custom_Plant = "h4_Plant";

	public const string OOTB_Type = "object_type";

	public const string OOTB_Release_Status = "release_status_list";

	public const string OOTB_Effectivity = "effectivity_text";

	public const string Custom_PLM_Revision = "h4_PLM_Revision";

	public const string OOTB_Process_Stage = "process_stage";

	public const string Custom_Product_Family = "h4_Product_Family";

	public const string Custom_Model_Group = "h4_Model_Group";

	public const string Custom_Product_Line = "h4_Product_Line";

	public const string Custom_EAU = "h4_EAU";

	public const string Custom_CrossRef_Number = "h4_Cross_Ref_Part_No";

	public const string OOTB_Property_Name = "";

	public const string Custom_Frm_Plant_Template = "h4_Plant_Template";

	public const string Custom_Frm_Template_Name = "h4_Template_Name";

	public const string Custom_Frm_MAPICS_Item_Type = "h4_MAPICS_Item_Type";

	public const string Custom_Frm_US_BAAN_Item_Type = "h4_US_Baan_Item_Type";

	public const string Custom_Frm_Plant = "h4_Plant";

	public const string Custom_Frm_Plant_Coded = "h4_Plant_Coded";

	public static string[] HSM_Check_Sheet_POLICY_PROPETIES = new string[36]
	{
		"item_id", "object_name", "item_revision_id", "items_tag", "object_desc", "h4_Nomenclature", "h4_BGN_Source", "h4_BBK_Source", "h4_CNO_Source", "h4_HAB_Source",
		"h4_MTY_Source", "h4_SWN_Source", "h4_BOM_Option_Code", "h4_ECN_Number", "h4_Finish_Code", "h4_Finish_Color", "h4_Risk_Level", "h4_High_Level_Category", "h4_Sub_Category", "h4_Hussmann_Item_Type",
		"h4_Template_Name", "h4_Plant", "object_type", "release_status_list", "effectivity_text", "h4_PLM_Revision", "process_stage", "", "h4_Plant_Template", "h4_Template_Name",
		"h4_Plant", "h4_Plant_Coded", "h4_Product_Family", "h4_Model_Group", "h4_Product_Line", "h4_EAU"
	};

	public static string[] HSM_Check_Sheet_Form_PROPETIES = new string[7] { "h4_Plant_Template", "h4_Template_Name", "h4_Plant", "h4_Plant_Coded", "h4_MAPICS_Item_Type", "h4_US_Baan_Item_Type", "h4_Cross_Ref_Part_No" };

	public const string Custom_BGN_FormName = "H4_BGN_View_Form";

	public const string Custom_MTY_FormName = "H4_MTY_View_Form";

	public const string Custom_CNO_FormName = "H4_CNO_View_Form";

	public const string Custom_SWN_FormName = "H4_SWN_View_Form";

	public const string Custom_HAB_FormName = "H4_HAB_View_Form";

	public const string Custom_BBK_FormName = "H4_BBK_View_Form";

	public const string Custom_BGN_FormRelation = "H4_bgn_plant_rel";

	public const string Custom_MTY_FormRelation = "H4_mty_plant_rel";

	public const string Custom_CNO_FormRelation = "H4_cno_plant_rel";

	public const string Custom_SWN_FormRelation = "H4_swn_plant_rel";

	public const string Custom_HAB_FormRelation = "H4_hab_plant_rel";

	public const string Custom_BBK_FormRelation = "H4_bbk_plant_rel";

	public const string OOTB_BOM_VIEW_TAGS_ATTR = "bom_view_tags";

	public const string OOTB_BL_ITEM_ID_ATTR = "bl_item_item_id";

	public const string OOTB_BL_ITEM_REV_ID_ATTR = "bl_rev_item_revision_id";

	public static string[] HSM_ECN_POLICY_PROPETIES = new string[9] { "item_id", "object_name", "object_desc", "item_revision_id", "items_tag", "analyst_user_id", "owning_user", "owning_group", "project_ids" };

	public static string[] HSM_ITEM_REV_POLICY_PROPETIES = new string[7] { "item_id", "object_name", "object_desc", "item_revision_id", "items_tag", "owning_group", "h4_Hussmann_Item_Type" };

	public static string[] HSM_ITEM_POLICY_PROPETIES = new string[8] { "item_id", "h4_Product_Family", "h4_Model_Group", "h4_Product_Line", "analyst_user_id", "owning_user", "uom_tag", "h4_Hussmann_Item_Type" };

	public static string[] BOM_LINE_POLICY_PROPETIES = new string[2] { "bl_item_item_id", "bl_rev_item_revision_id" };

	public static string[] REV_RULE_POLICY_PROPETIES = new string[1] { "object_name" };

	[STAThread]
	public static void main()
	{
		try
		{
			Application.EnableVisualStyles();
			gToolName = "CHECKSHEET-TC10";
			gToolVersion = MyProject.Application.Info.Version.ToString();
			Application.Run(new frmMain());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}
}
