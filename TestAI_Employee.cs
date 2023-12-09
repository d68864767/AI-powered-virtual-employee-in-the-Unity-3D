using NUnit.Framework;
using System;

public class TestAI_Employee
{
    private AI_Employee aiEmployee;

    [SetUp]
    public void SetUp()
    {
        aiEmployee = new AI_Employee();
    }

    [Test]
    public void TestNavigateCommand()
    {
        string command = "Navigate to https://www.google.com";
        string result = aiEmployee.ExecuteCommand(command);
        Assert.IsTrue(result.StartsWith("Successfully navigated to https://www.google.com. Source code:"));
    }

    [Test]
    public void TestFillOutFormCommand()
    {
        string command = "Fill out form with {\"firstName\": \"John\", \"lastName\": \"Doe\", \"email\": \"johndoe@example.com\"}";
        string result = aiEmployee.ExecuteCommand(command);
        Assert.IsTrue(result.StartsWith("Successfully filled out form. Response:"));
    }

    [Test]
    public void TestSearchCommand()
    {
        string command = "Search for 'Unity tutorials'";
        string result = aiEmployee.ExecuteCommand(command);
        Assert.IsTrue(result.StartsWith("Search results for 'Unity tutorials':"));
    }

    [Test]
    public void TestDownloadCommand()
    {
        string command = "Download image at https://example.com/image.png and save to C:/Users/Username/Downloads";
        string result = aiEmployee.ExecuteCommand(command);
        Assert.IsTrue(result.StartsWith("Successfully downloaded file from https://example.com/image.png and saved to C:/Users/Username/Downloads"));
    }

    [Test]
    public void TestInvalidCommand()
    {
        string command = "Invalid command";
        string result = aiEmployee.ExecuteCommand(command);
        Assert.IsTrue(result.StartsWith("An error occurred while executing your command. Please check the command and try again. Error:"));
    }
}
