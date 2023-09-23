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
    public GameObject avaibleMoves;
    public static int numberFigureToCreate;
    public static bool colorFigureToCreate;
    public static bool posibleFigureCreate;
    public static bool whichMove;
    
    //Szachowanie krola
    public static bool isChecked;
    public static List<Figure> figuresChecking = new List<Figure>();
    public static List<Wspolrzedne> attackingFields = new List<Wspolrzedne> ();
    public static int whichMethod;

    public static int currentX;
    public static int currentY;

    public Image kafelekB;
    public Image kafelekC;

    //generate default position

    public Button resetGame;

    // Start is called before the first frame update
    void Start()
    {
        whichMove = true;
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

        resetGame.onClick.AddListener(generateStartPosition);
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
        generateAvaibleMoves();
    }
    public static void choiceFigureToCreate(int x, bool color)
    {
        numberFigureToCreate = x;
        colorFigureToCreate = color;
        posibleFigureCreate = true;
    }

    public static void moveFigure(int targetX, int targetY)
    {
        if (figuresTable[currentX, currentY] != null)
        {
            if (figuresTable[targetX, targetY] != null)
            {
                Destroy(figuresTable[targetX, targetY].gameObject);
            }

            figuresTable[targetX, targetY] = figuresTable[currentX, currentY];
            figuresTable[currentX, currentY] = null;
            figuresTable[targetX, targetY].setPostion(targetX, targetY);
            figuresTable[targetX, targetY].transform.localPosition = new Vector2(figuresTable[targetX, targetY].positionOnBoard.Litera * 125, figuresTable[targetX, targetY].positionOnBoard.Liczba * -125);
            figuresTable[targetX, targetY].hideAvaibleMoves();
            generateAvaibleMoves();
            Debug.Log(isChecked);

            if (whichMove)
            {
                whichMove = false;
            }
            else
            {
                whichMove = true;
            }

            if(isChecked)
            {
                if(figuresChecking.Count < 2)
                {
                    //Sprawdzanie czy da sie zaslonic i ruchy krolem
                    switch (figuresChecking[0].nameFigure)
                    {
                        case "Goniec":
                            figuresChecking[0].bishopMoves(whichMethod);
                            break;
                    }
                    foreach(Wspolrzedne w in attackingFields)
                    {
                        Debug.Log(w.toSting());
                    }
                }
                else
                {
                    //Generowanie ruchow tylko krolem
                }
            }
        }
    }
   
    static void generateAvaibleMoves()
    {
        isChecked = false;
        figuresChecking.Clear();
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

    public static void generateStartPosition()
    {
        Debug.Log("Debug");
        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                if (figuresTable[i, j] != null)
                {
                    Destroy(figuresTable[i, j].gameObject);
                    figuresTable[i, j] = null;
                }
            }
        }
        //white
        //white
        whichMove = true;
        posibleFigureCreate = true;
        colorFigureToCreate = true;
        //wieze
        numberFigureToCreate = 0;
        addFigure(0, 0);
        addFigure(7, 0);
        //skoczki
        numberFigureToCreate = 2;
        addFigure(1, 0);
        addFigure(6, 0);
        //gonce
        numberFigureToCreate = 1;
        addFigure(2, 0);
        addFigure(5, 0);
        //krol
        numberFigureToCreate = 4;
        addFigure(3, 0);
        //hetman
        numberFigureToCreate = 3;
        addFigure(4, 0);
        //pionki
        numberFigureToCreate = 5;
        for (int i = 0; i <= 7; i++)
        {
            addFigure(i, 1);
        }

        colorFigureToCreate = false;
        //wieze
        numberFigureToCreate = 0;
        addFigure(0, 7);
        addFigure(7, 7);
        //skoczki
        numberFigureToCreate = 2;
        addFigure(1, 7);
        addFigure(6, 7);
        //gonce
        numberFigureToCreate = 1;
        addFigure(2, 7);
        addFigure(5, 7);
        //krol
        numberFigureToCreate = 4;
        addFigure(3, 7);
        //hetman
        numberFigureToCreate = 3;
        addFigure(4, 7);
        //pionki
        numberFigureToCreate = 5;
        for (int i = 0; i <= 7; i++)
        {
            addFigure(i, 6);
        }
        posibleFigureCreate = true;
    }

    // Update is called once per frame

    private void Update()
    {

    }
}
