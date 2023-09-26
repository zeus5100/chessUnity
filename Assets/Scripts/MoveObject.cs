using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject
{
    public char figureSymbol;
    public Wspolrzedne currentPos;
    public Wspolrzedne lastPos;
    public bool capture;



    public string toString()
    {
        string s = "";
        s += figureSymbol;
        if (capture)
        {
            s += "x";
        }

        s += convertToSymbol(currentPos.Litera);
        s += currentPos.Liczba + 1;


        return s;
    }


    public char convertToSymbol(int x)
    {
        switch (x)
        {
            case 0:
                return 'h';
            case 1:
                return 'g';
            case 2:
                return 'f';
            case 3:
                return 'e';
            case 4:
                return 'd';
            case 5:
                return 'c';
            case 6:
                return 'b';
            case 7:
                return 'a';

        }
        return 'x';
    }

}
