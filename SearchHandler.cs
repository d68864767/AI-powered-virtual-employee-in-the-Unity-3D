using System;
using UnityEngine;
using UnityEngine.Networking;

public class SearchHandler
{
    public string PerformSearch(string query)
    {
        string url = "https://www.google.com/search?q=" + UnityWebRequest.EscapeURL(query);

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();

        while (!www.isDone)
        {
            System.Threading.Thread.Sleep(100);
        }

        if (www.isNetworkError || www.isHttpError)
        {
            throw new Exception("Failed to perform search. Error: " + www.error);
        }
        else
        {
            return "Search results for '" + query + "': " + www.downloadHandler.text;
        }
    }
}
