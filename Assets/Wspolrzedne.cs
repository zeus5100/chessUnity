using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wspolrzedne
{
    public int Litera { get; set; }
    public int Liczba { get; set; }

    public Wspolrzedne(int litera, int liczba)
    {
        Litera = litera;
        Liczba = liczba;
    }
    public string toSting()
    {
        return "" + Litera + " " + Liczba;
    }
}
