using Etteplan_XML_test;
using System.Xml;

// Initialize the XMLReader
XMLReader xmlReader = new();

// Initialize available id's
string idOne = "42006";
string idTwo = "42007";
string idThree = "42008";
string idFour = "42009";

// Initialize displaying/user variables
bool IsValidChoice;
string choiceOfId;
string displayString = "Please choose a number between 1 and 4: ";
string targetValue;

// Display welcome message and ask for user input
GetWelcomeMsg();
GetUserInput();

// Displays the welcome message
void GetWelcomeMsg()
{
    Console.Clear();
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("  WELCOME TO THE BRILLIANT FILE SAVER APP    ");
    Console.WriteLine("_____________________________________________\n");
    Console.WriteLine("There are currently available info on the following id's:\n");
    Console.WriteLine($"1. {idOne}");
    Console.WriteLine($"2. {idTwo}");
    Console.WriteLine($"3. {idThree}");
    Console.WriteLine($"4. {idFour}\n");
}

// Ask user for input (and pass choice to GetTargetValue if valid)
void GetUserInput()
{
    Console.Write(displayString);
    IsValidChoice = int.TryParse(Console.ReadLine().Trim(), out int userNum);

    if (IsValidChoice)
    {
        switch (userNum)
        {
            case 1: 
                GetTargetValue(idOne);
                break;
            case 2:
                GetTargetValue(idTwo);
                break;
            case 3:
                GetTargetValue(idThree);
                break;
            case 4:
                GetTargetValue(idFour);
                break;
            default: displayString = "A number between 1 and 4 please: ";
                GetWelcomeMsg();
                GetUserInput();
                break;
        }
    }

    else
    {
        displayString = "Only numbers allowed: ";
        GetWelcomeMsg();
        GetUserInput();
    }
}

// Get the target value based on id
void GetTargetValue(string id)
{
    choiceOfId = id;
    targetValue = xmlReader.GetTargetValueById(choiceOfId);

    if (choiceOfId == idTwo)
    {
        SaveToFileAsync(targetValue);
    }

    else
    {
        DisplayTargetValue(targetValue);
    }
}

// Display the target value
void DisplayTargetValue(string value)
{
    GetWelcomeMsg();
    Console.WriteLine($"The target value is: {value}\n");
    ContinueOrExitApp();
}

// Save the target value to a file
async Task SaveToFileAsync(string value)
{
    GetWelcomeMsg();
    Console.WriteLine($"Saving the target value to a .txt file...");
    await File.WriteAllTextAsync("Targetvalue.txt", value);
    Console.WriteLine("\nDone! The file was saved to \"...bin\\debug\\net7.0\".\n");
}

// Ask user to continue or exit app
void ContinueOrExitApp()
{
    Console.Write("Press \"y\" for another value or \"x\" to exit the app: ");
    string? userChoice = Console.ReadLine().Trim();

    if (userChoice.ToLower() == "y")
    {
        GetWelcomeMsg();
        displayString = "Please choose a number between 1 and 4: ";
        GetUserInput();
    }

    else if (userChoice.ToLower() != "x")
    {
        GetWelcomeMsg();
        Console.WriteLine("Enter a valid option!\n");
        ContinueOrExitApp();
    }
}