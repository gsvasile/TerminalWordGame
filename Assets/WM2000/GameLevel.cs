using System;

public class GameLevel : IGameLevel
{
    protected readonly Random random = new Random();
    protected string[] passwords;
    protected string gamePassword;

    public string GamePassword
    {
        get
        {
            return gamePassword;
        }
    }

    public string GamePasswordHint
    {
        get
        {
            return GamePassword.Shuffle();
        }
    }

    public GameLevel(params string[] passwords)
    {
        this.passwords = passwords;
    }

    public virtual void Start()
    {
        gamePassword = passwords[random.Next(0, passwords.Length)];
    }

    public virtual string GetWin()
    {
        return "Congratulations!";
    }
}
