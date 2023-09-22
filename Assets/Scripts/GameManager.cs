using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Figure[,] figuresTable = new Figure[8, 8];
    public Figure[] avaibleFigures;
    public static Figure[] staticFigures;
    public GameObject plansza;
    public static GameObject staticPlansza;
    public GameObject background;
    public static int numberFigureToCreate;
    public static bool colorFigureToCreate;
    public static bool posibleFigureCreate;
    public Image kafelekB;
    public Image kafelekC;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                if (i % 2 == 1)
                {
                    Instantiate(kafelekB, background.transform);
                    Instantiate(kafelekC, background.transform);
                }
                else
                {
                    Instantiate(kafelekC, background.transform);
                    Instantiate(kafelekB, background.transform);
                }
            }
        }
        //przypisanie niestatycznych elementów do statycznych zmiennych
        staticFigures = avaibleFigures;
        staticPlansza = plansza;
        //*************
    }
    public static void addFigure(int x, int y)
    {
        if (!posibleFigureCreate)
        {
            return;
        }
        Figure temp = Instantiate(staticFigures[numberFigureToCreate], staticPlansza.transform);
        temp.setColor(colorFigureToCreate);
        temp.setPostion(x, y);
        temp.transform.localPosition = new Vector2(temp.positionOnBoard.Litera * 125, temp.positionOnBoard.Liczba * -125);
        temp.setImage();
        figuresTable[x, y] = temp;
        posibleFigureCreate = false;
        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                if (figuresTable[i, j] != null)
                {
                    figuresTable[i, j].generateAvaibleMoves();
                }
            }
        }
    }
    public static void choiceFigureToCreate(int x, bool color)
    {
        numberFigureToCreate = x;
        colorFigureToCreate = color;
        posibleFigureCreate = true;
    }
    // Update is called once per frame
    private void Update()
    {

    }
}
