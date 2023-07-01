using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game Configuration Data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    //Game State
    int level;
    string password;

    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

    // Use this for initialization
    void Start ()
    {
        showMainMenu();
	}

    void showMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Select what you want to hack into:");
        Terminal.WriteLine("You can return to this screen at any");
        Terminal.WriteLine("time by typing \"Menu\"");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local Library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
    }


    void OnUserInput(string input)
    {
        if (input == "menu" || input == "Menu") //we can always go to the main menu
        {
            showMainMenu();
        }
        else if(input == "quit" || input == "close" || input == "exit")
        {
            Terminal.ClearScreen();
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            runMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            runPassword(input);
        }
    }

    void runMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            askForPassword();
        }
        else if (input == "007")// Easter egg
        {
            Terminal.WriteLine("Welcome Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void runPassword(string input)
    {
        if (input == password)
        {
            displayWinScreen();
        }
        else
        {
            askForPassword();

        }
    }

    void askForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        setRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

    }

    void setRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.Log("Invalid level number");
                break;
        }
    }

    void displayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        showLevelReward();
        Terminal.WriteLine("Type \"menu\" to return to the menu");
    }

    void showLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Here, have a book...");
                Terminal.WriteLine(@"
    ____
   /   //
  /   //
 /___//
(___(/
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '
"               );
                break;
            case 3:
                Terminal.WriteLine("Welcome to the world's leader in space exploration!");
                Terminal.WriteLine(@"NASA
 ___  ___    ___      ___    ___
| _ \_| |   / _ \    /  /   / _ \
| | \   |  / /_\ \  _\  \  / /_\ \
|_|  \__| /_/   \_\ \___/ /_/   \_\
"               );
                break;
            default:
                Debug.LogError("Invalid level recieved");
                break;
        }
    }
}
