using System;

public class ErrorHandler
{
    public string HandleError(Exception e)
    {
        // Log the error message for debugging purposes
        UnityEngine.Debug.LogError("Error: " + e.Message);

        // Return a user-friendly error message
        return "An error occurred while executing your command. Please check the command and try again. Error: " + e.Message;
    }
}
