namespace Teamcenter.Soa.Client;

public delegate int FMS_Progress_Callback(string uid, object args, int bytesDownloaded, int bytesFileSize, ref bool continueDownload);
