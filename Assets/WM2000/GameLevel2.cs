
public class GameLevel2 : GameLevel
{
    public GameLevel2() 
        : base("howdy", "howdyDo")
    {

    }

    public override void Start()
    {
        base.Start();

        Terminal.ClearScreen();
        Terminal.WriteLine(@"
           ()
           /\
      ()--'  '--()
        `.    .'
         / .. \
        ()'  '()");
    }

    public override string GetWin()
    {
        return @"
| _|  .  |) |) \./
| | /-\ |  |   |
' ''   ''  '   '
 . .  _ |  |
 |\| |- |  |
 ' '  ~ \/\/
\./  _  .  |)
 |  |- /-\ |\
 '   ~'   '' '";
    }
}
