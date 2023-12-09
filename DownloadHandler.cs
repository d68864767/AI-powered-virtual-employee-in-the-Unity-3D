using System;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadHandler
{
    public string DownloadFile(string downloadUrl, string saveLocation)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(downloadUrl);
        www.SendWebRequest();

        while (!www.isDone)
        {
            System.Threading.Thread.Sleep(100);
        }

        if (www.isNetworkError || www.isHttpError)
        {
            throw new Exception("Failed to download file from " + downloadUrl + ". Error: " + www.error);
        }
        else
        {
            try
            {
                byte[] results = www.downloadHandler.data;
                System.IO.File.WriteAllBytes(saveLocation, results);
                return "Successfully downloaded file from " + downloadUrl + " and saved to " + saveLocation;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to save file to " + saveLocation + ". Error: " + e.Message);
            }
        }
    }
}
