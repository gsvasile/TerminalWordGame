using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel3 : GameLevel
{
    public GameLevel3() 
        : base("hi-ya!", "'ello!", "superdooper", "alrighty")
    {

    }

    public override void Start()
    {
        base.Start();

        Terminal.ClearScreen();
        Terminal.WriteLine(@"
           x
.-. _______|
|=|/     /  \
| |_____|_""_|
|_|_[X]_|____|");
    }

    public override string GetWin()
    {
        return @" Call the Batman!!
          _,     _   _     ,_
      .-'` /     \'-'/     \ `'-.
     /    |      |   |      |    \
    ;      \_  _/     \_  _/      ;
   |         ``         ``         |
   |                               |
    ;    .-.   .-.   .-.   .-.    ;
     \  (   '.'   \ /   '.'   )  /
      '-.;         V         ;.-'
          `                 `";
    }
}
