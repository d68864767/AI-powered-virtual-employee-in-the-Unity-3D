using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    private AI_Employee aiEmployee;

    // Start is called before the first frame update
    void Start()
    {
        aiEmployee = new AI_Employee();

        // Example commands
        string[] commands = new string[]
        {
            "Navigate to https://www.google.com",
            "Fill out form with {firstName: 'John', lastName: 'Doe', email: 'johndoe@example.com'}",
            "Search for 'Unity tutorials'",
            "Download image at https://example.com/image.png and save to C:/Users/Username/Downloads"
        };

        foreach (string command in commands)
        {
            try
            {
                string result = aiEmployee.ExecuteCommand(command);
                Debug.Log(result);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Here you can add more commands to be executed in real-time if needed
    }
}
