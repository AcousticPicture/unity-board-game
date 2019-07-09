using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round 
{
    // true stands for Jack
    bool[] turns;
    // is Jack currently visible 
    bool visibile;
    // lamp that will be switched off, 0 is none
    int lamp;

    public Round(bool[] turns, bool visibile, int lamp)
    {
        this.turns = turns;
        this.visibile = visibile;
        this.lamp = lamp;
    }
}
