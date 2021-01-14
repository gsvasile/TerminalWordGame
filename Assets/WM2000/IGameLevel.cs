public interface IGameLevel
{
    string GamePassword
    {
        get;
    }

    string GamePasswordHint
    {
        get;
    }

    void Start();
    string GetWin();
}