using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class Authorization : Folder
{
	public string Release_number => GetProperty("release_number").StringValue;

	public int Current_status => GetProperty("current_status").IntValue;

	public int Previous_status => GetProperty("previous_status").IntValue;

	public DateTime Date_of_current_status => GetProperty("date_of_current_status").DateValue;

	public TaskType Task_type => (TaskType)GetProperty("task_type").ModelObjectValue;

	public Form Task_form => (Form)GetProperty("task_form").ModelObjectValue;

	public DistributionList Notification_list => (DistributionList)GetProperty("notification_list").ModelObjectValue;

	public Folder Target_folder => (Folder)GetProperty("target_folder").ModelObjectValue;

	public Folder Reference_folder => (Folder)GetProperty("reference_folder").ModelObjectValue;

	public ReleaseStatus Release_status => (ReleaseStatus)GetProperty("release_status").ModelObjectValue;

	public DateTime Date_submitted => GetProperty("date_submitted").DateValue;

	public User Submitted_by => (User)GetProperty("submitted_by").ModelObjectValue;

	public Authorization(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
