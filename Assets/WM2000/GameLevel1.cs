
public class GameLevel1 : GameLevel
{
    public GameLevel1()
        : base("thebat", "batman", "bat")
    {

    }

    public override void Start()
    {
        base.Start();

        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the kiddie pool.");
        Terminal.WriteLine("This might be a quick round!");
    }

    public override string GetWin()
    {
        return @" Here's a baby!
   ,=""""=,
  c , _,{
  /\  @ )                 __
 /  ^~~^\          <=.,__/ '}=
(_/ ,, ,,)          \_ _>_/~
 ~\_(/-\)'-,_,_,_,-'(_)-(_)";
    }
}
