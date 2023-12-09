using System;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class FormHandler
{
    public string FillOutForm(string formData)
    {
        // Parse the JSON object
        Dictionary<string, string> formFields = JsonConvert.DeserializeObject<Dictionary<string, string>>(formData);

        // Create a new form
        WWWForm form = new WWWForm();

        // Add fields to the form
        foreach (KeyValuePair<string, string> field in formFields)
        {
            form.AddField(field.Key, field.Value);
        }

        // Send the form
        UnityWebRequest www = UnityWebRequest.Post("http://example.com/form", form);
        www.SendWebRequest();

        // Wait for the form to be submitted
        while (!www.isDone)
        {
            System.Threading.Thread.Sleep(100);
        }

        // Check for errors
        if (www.isNetworkError || www.isHttpError)
        {
            throw new Exception("Failed to fill out form. Error: " + www.error);
        }
        else
        {
            return "Successfully filled out form. Response: " + www.downloadHandler.text;
        }
    }
}
