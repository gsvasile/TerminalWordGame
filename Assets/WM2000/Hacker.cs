using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private const string mainMenuText = "What would you like to crack into?!?\n\r" +
                                        "Press 1 for the kiddie pool.\n\r" +
                                        "Press 2 for the Sheriff's Department.\n\r" +
                                        "Press 3 for Homeland Securty.\n\r" +
                                        "Enter your selection:";

    private const short NumberOfDifficulties = 3;

    private enum Screen
    {
        MainMenu,
        Password,
        Win,
        Error
    }

    private int gameLevel;
    private Screen currentScreen;
    private readonly IGameLevel[] games = new GameLevel[NumberOfDifficulties];
    private GameLevel currentGame;


    // Start is called before the first frame update
    private void Start()
    {
        DisplayMainMenu(mainMenuText);
    }

    private void DisplayMainMenu(string mainMenuText)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(mainMenuText);
    }

    private void OnUserInput(string input)
    {
        var lowerInput = input.ToLower();
        if(lowerInput == "menu")
        {
            DisplayMainMenu(mainMenuText);
        }
        else if(lowerInput == "quit" || lowerInput == "close" || lowerInput == "exit")
        {
            Terminal.WriteLine("If using this on the web, close the tab.");
            Application.Quit();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            ProcessMainMenuInput(input);
        }
        else if(currentScreen == Screen.Password)
        {
            ProcessPassword(input);
        }
    }

    private void ProcessMainMenuInput(string input)
    {
        switch(input)
        {
            case "1":
            case "2":
            case "3":
                gameLevel = int.Parse(input);
                StartGame();
                break;
            default:
                Terminal.WriteLine("Please make a valid selection!!!!!");
                break;
        }
    }

    private void ProcessPassword(string input)
    {
        if(input == currentGame.GamePassword)
        {
            ProcessWin();
        }
        else
        {
            Terminal.WriteLine("Wrong Password! Try Again.");
            ShowPasswordHint();
            PromptToRestart();
        }
    }

    private void ProcessWin()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine(currentGame.GetWin());
        PromptToRestart();
    }

    private void PromptToRestart()
    {
        Terminal.WriteLine("(Type \"menu\" to restart.)");
    }

    private void ShowPasswordHint()
    {
        Terminal.WriteLine(string.Format("  hint: {0}", currentGame.GamePasswordHint));
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;

        SetCurrentGame();

        if(currentGame == null)
        {
            DisplayMainMenu(mainMenuText);
            return;
        }

        currentGame.Start();
        print(currentGame.GamePassword);
        Terminal.WriteLine("Enter your password:");
        ShowPasswordHint();
        PromptToRestart();
    }

    private void SetCurrentGame()
    {
        ValidateGameLevel();
        InitializeGame();

        currentGame = games[gameLevel - 1] as GameLevel;

        if(currentGame == null)
        {
            currentScreen = Screen.Error;
            Terminal.ClearScreen();
            Terminal.WriteLine("ERROR: Game Cannot be started! Please type \"menu\" to restart.");
        }
    }

    private void ValidateGameLevel()
    {
        if(gameLevel == 0 || gameLevel > NumberOfDifficulties)
        {
            currentScreen = Screen.Error;
            Terminal.ClearScreen();
            Terminal.WriteLine("ERROR: Game Level Incorrect. Please type \"menu\" to restart.");
        }
    }

    private void InitializeGame()
    {
        if(games[gameLevel - 1] != null)
        {
            return;
        }

        switch(gameLevel)
        {
            case 1:
                games[gameLevel - 1] = new GameLevel1();
                break;
            case 2:
                games[gameLevel - 1] = new GameLevel2();
                break;
            case 3:
                games[gameLevel - 1] = new GameLevel3();
                break;
        }
    }
}
