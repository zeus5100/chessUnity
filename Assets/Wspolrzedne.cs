using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wspolrzedne
{
    public char Litera { get; set; }
    public char Type { get; set; }
    public int Liczba { get; set; }

    public Wspolrzedne(char litera, int liczba, char type)
    {
        Litera = litera;
        Liczba = liczba;
        Type = type;
    }
}
