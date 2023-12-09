using System;
using System.Collections.Generic;
using UnityEngine;

public class AI_Employee
{
    private WebBrowser webBrowser;
    private FormHandler formHandler;
    private SearchHandler searchHandler;
    private DownloadHandler downloadHandler;
    private ErrorHandler errorHandler;

    public AI_Employee()
    {
        webBrowser = new WebBrowser();
        formHandler = new FormHandler();
        searchHandler = new SearchHandler();
        downloadHandler = new DownloadHandler();
        errorHandler = new ErrorHandler();
    }

    public string ExecuteCommand(string command)
    {
        string[] commandParts = command.Split(' ');

        switch (commandParts[0])
        {
            case "Navigate":
                try
                {
                    string url = commandParts[2];
                    return webBrowser.NavigateTo(url);
                }
                catch (Exception e)
                {
                    return errorHandler.HandleError(e);
                }

            case "Fill":
                try
                {
                    string formData = commandParts[4];
                    return formHandler.FillOutForm(formData);
                }
                catch (Exception e)
                {
                    return errorHandler.HandleError(e);
                }

            case "Search":
                try
                {
                    string query = commandParts[2];
                    return searchHandler.PerformSearch(query);
                }
                catch (Exception e)
                {
                    return errorHandler.HandleError(e);
                }

            case "Download":
                try
                {
                    string downloadUrl = commandParts[3];
                    string saveLocation = commandParts[7];
                    return downloadHandler.DownloadFile(downloadUrl, saveLocation);
                }
                catch (Exception e)
                {
                    return errorHandler.HandleError(e);
                }

            default:
                return "Invalid command";
        }
    }
}
