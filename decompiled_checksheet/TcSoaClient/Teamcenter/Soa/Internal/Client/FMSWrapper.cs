using System.IO;
using Teamcenter.Soa.Client;

namespace Teamcenter.Soa.Internal.Client;

public interface FMSWrapper
{
	void Init();

	void Term();

	string RegisterTicket(string ticket);

	string[] RegisterTickets(string[] tickets);

	string DownLoadFileFromPLM(string policy, FMS_Progress_Callback cb, object clientObject, string UID);

	string[] DownLoadFilesFromPLM(string policy, FMS_Progress_Callback cb, object clientObject, string[] Uids);

	string UploadFileToPlm(string fileUid, FMS_Progress_Callback cb, object clientObject, string filePath);

	string[] UploadFilesToPlm(string[] fileUids, FMS_Progress_Callback cb, object clientObject, string[] filePaths);

	void RollBackFileUploadedToPLM(string Uid, string volumeID);

	void RollBackFilesUploadedToPLM(string[] Uids, string[] volumeIDs);

	FileInfo DownLoadTransientFile(string policy, FMS_Progress_Callback cb, object clientObject, string UID, string filePathName);

	FileInfo DownLoadTransientFile(string policy, FMS_Progress_Callback cb, object clientObject, string UID, string directory, string fileName);

	void UnRegisterTickets(string[] tickets);

	void UnRegisterTicket(string ticket);

	string StreamUpload(string UID, Stream uploadStream, long streamLength);

	void StreamDownload(string UID, Stream downloadStream);
}
