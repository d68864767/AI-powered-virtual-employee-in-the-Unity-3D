using System;
using UnityEngine;
using UnityEngine.Networking;

public class WebBrowser
{
    public string NavigateTo(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();

        while (!www.isDone)
        {
            System.Threading.Thread.Sleep(100);
        }

        if (www.isNetworkError || www.isHttpError)
        {
            throw new Exception("Failed to navigate to " + url + ". Error: " + www.error);
        }
        else
        {
            return "Successfully navigated to " + url + ". Source code: " + www.downloadHandler.text;
        }
    }
}
