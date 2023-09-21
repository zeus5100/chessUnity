using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GenerateFigures : MonoBehaviour
{
    public GameObject plansza;
    public GameObject background;
    public Image kafelekB;
    public Image kafelekC;
    public Figure[] figures;
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
    List<Wspolrzedne> listaWsporzedneB = new List<Wspolrzedne>();

    List<Wspolrzedne> listaWsporzedneC = new List<Wspolrzedne>();

    // Start is called before the first frame update
    void Start()
    {
        listaWsporzedneB.Add(new Wspolrzedne('a', 1, 'R'));
        listaWsporzedneB.Add(new Wspolrzedne('b', 1, 'N'));
        listaWsporzedneB.Add(new Wspolrzedne('c', 1, 'B'));
        listaWsporzedneB.Add(new Wspolrzedne('d', 1, 'Q'));
        listaWsporzedneB.Add(new Wspolrzedne('e', 1, 'K'));
        listaWsporzedneB.Add(new Wspolrzedne('f', 1, 'B'));
        listaWsporzedneB.Add(new Wspolrzedne('g', 1, 'N'));
        listaWsporzedneB.Add(new Wspolrzedne('h', 1, 'R'));

        listaWsporzedneB.Add(new Wspolrzedne('a', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('b', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('c', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('d', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('e', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('f', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('g', 2, 'P'));
        listaWsporzedneB.Add(new Wspolrzedne('h', 2, 'P'));

        listaWsporzedneC.Add(new Wspolrzedne('a', 8, 'R'));
        listaWsporzedneC.Add(new Wspolrzedne('b', 8, 'N'));
        listaWsporzedneC.Add(new Wspolrzedne('c', 8, 'B'));
        listaWsporzedneC.Add(new Wspolrzedne('d', 8, 'Q'));
        listaWsporzedneC.Add(new Wspolrzedne('e', 8, 'K'));
        listaWsporzedneC.Add(new Wspolrzedne('f', 8, 'B'));
        listaWsporzedneC.Add(new Wspolrzedne('g', 8, 'N'));
        listaWsporzedneC.Add(new Wspolrzedne('h', 8, 'R'));

        listaWsporzedneC.Add(new Wspolrzedne('a', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('b', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('c', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('d', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('e', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('f', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('g', 7, 'P'));
        listaWsporzedneC.Add(new Wspolrzedne('h', 7, 'P'));
        Debug.Log(2);
        for(int i = 1; i<= 8; i++)
        {
            for( int j = 1; j<= 4; j++)
            {
                if(i % 2 == 1)
                {
                    Instantiate(kafelekB, background.transform);
                    Instantiate(kafelekC, background.transform);
                } else
                {
                    Instantiate(kafelekC, background.transform);
                    Instantiate(kafelekB, background.transform);
                }
            }
        }
        for(int i=0; i<listaWsporzedneB.Count; i++)
        {
            var temp = Instantiate(figures[letterToFigure(listaWsporzedneB[i].Type)], plansza.transform);
            temp.transform.localPosition = convertPosition(listaWsporzedneB[i].Litera, listaWsporzedneB[i].Liczba);
            temp.setImage();
            temp.setPostion(listaWsporzedneB[i].Litera, listaWsporzedneB[i].Liczba);
            temp.generateAvaibleMoves();
        }
        for (int i = 0; i < listaWsporzedneC.Count; i++)
        {
            var temp = Instantiate(figures[letterToFigure(listaWsporzedneC[i].Type)], plansza.transform);
            temp.transform.localPosition = convertPosition(listaWsporzedneC[i].Litera, listaWsporzedneC[i].Liczba);
            temp.setColor(false);
            temp.setImage();
            temp.setPostion(listaWsporzedneC[i].Litera, listaWsporzedneC[i].Liczba);
        }
    }
    Vector2 convertPosition(char x, int y)
    {
        return new Vector2((letterToPostion(x) - 1) * 125, (y - 1) * 125);
    }
    int letterToFigure(char x)
    {
        switch(x)
        {
            case 'K' : return 5; 
            case 'Q': return 4;
            case 'B': return 1;
            case 'N': return 2;
            case 'R': return 3;
            case 'P': return 0;
        }
        return 0;
    }
    int letterToPostion(char s)
    {
        int value = 0;
        switch(s)
        {
            case 'a': value = 1; break;
            case 'b': value = 2; break;
            case 'c': value = 3; break;
            case 'd': value = 4; break;
            case 'e': value = 5; break;
            case 'f': value = 6; break;
            case 'g': value = 7; break;
            case 'h': value = 8; break;
        }
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
