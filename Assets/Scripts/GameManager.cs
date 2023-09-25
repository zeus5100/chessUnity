using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
    //pozycja krola

    public static Wspolrzedne posKing;

    //Szachowanie krola
    public static bool isChecked;
    public static List<Figure> figuresChecking = new List<Figure>();
    public static List<Wspolrzedne> attackingFields = new List<Wspolrzedne>();
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
        whichMethod = 99;
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
            attackingFields.Clear();
            if (whichMove)
            {
                whichMove = false;
            }
            else
            {
                whichMove = true;
            }
            generateAvaibleMoves();
            int indexX = posKing.Litera;
            int indexY = posKing.Liczba;
            if (isChecked)
            {
                if (figuresChecking.Count < 2)
                {
                    //figury które mog¹ zas³oniæ szacha
                    List<Wspolrzedne> tempAvaibleMoves = new List<Wspolrzedne>();
                    figuresChecking[0].figuresMoves(whichMethod);
                    foreach (Figure f in figuresTable)
                    {
                        tempAvaibleMoves.Clear();
                        if (f != null && f.color == whichMove)
                        {
                            foreach (Wspolrzedne wDefence in f.posibleMoves)
                            {
                                foreach (Wspolrzedne wAttack in attackingFields)
                                {
                                    if ((wDefence.Litera == wAttack.Litera && wDefence.Liczba == wAttack.Liczba))
                                    {
                                        tempAvaibleMoves.Add(wAttack);
                                    }
                                    if (wDefence.Liczba == figuresChecking[0].positionOnBoard.Liczba && wDefence.Litera == figuresChecking[0].positionOnBoard.Litera)
                                    {
                                        tempAvaibleMoves.Add(figuresChecking[0].positionOnBoard);
                                    }
                                }
                            }
                            f.posibleMoves.Clear();
                            f.posibleMoves.AddRange(tempAvaibleMoves);
                        }
                    }
                    figuresTable[indexX, indexY].generateAvaibleMoves();
                    Wspolrzedne toDelete = null;
                    switch (whichMethod)
                    {
                        case 0:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX - 1) && x.Liczba == (indexY + 1));

                            break;
                        case 1:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX - 1) && x.Liczba == (indexY - 1));

                            break;
                        case 2:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX + 1) && x.Liczba == (indexY - 1));

                            break;
                        case 3:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX + 1) && x.Liczba == (indexY + 1));

                            break;
                        case 4:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX) && x.Liczba == (indexY + 1));

                            break;
                        case 5:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX - 1) && x.Liczba == (indexY));

                            break;
                        case 6:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX) && x.Liczba == (indexY - 1));

                            break;
                        case 7:
                            toDelete = figuresTable[indexX, indexY].posibleMoves.Find(x => x.Litera == (indexX + 1) && x.Liczba == (indexY));

                            break;
                    }
                    if (toDelete != null)
                    {
                        figuresTable[indexX, indexY].posibleMoves.Remove(toDelete);
                    }
                    figuresChecking[0].generateAvaibleMoves();
                    //na nowo ruchy króla
                }
                else
                {
                    //Generowanie ruchow tylko krolem
                }
            }
            List<Wspolrzedne> tempKingMoves = figuresTable[indexX, indexY].posibleMoves;
            foreach (Figure f in figuresTable)
            {
                if (f != null && f.color != whichMove)
                {
                    foreach (Wspolrzedne wAttack in f.posibleMoves)
                    {
                        for (int i = 0; i < tempKingMoves.Count; i++)
                        {
                            if ((wAttack.Litera == tempKingMoves[i].Litera && wAttack.Liczba == tempKingMoves[i].Liczba))
                            {
                                figuresTable[indexX, indexY].posibleMoves.Remove(tempKingMoves[i]);
                            }
                        }
                        /*foreach (Wspolrzedne wAttack in attackingFields)
                        {
                            if ((wDefence.Litera == wAttack.Litera && wDefence.Liczba == wAttack.Liczba))
                            {
                                tempAvaibleMoves.Add(wAttack);
                            }
                            if (wDefence.Liczba == figuresChecking[0].positionOnBoard.Liczba && wDefence.Litera == figuresChecking[0].positionOnBoard.Litera)
                            {
                                tempAvaibleMoves.Add(figuresChecking[0].positionOnBoard);
                            }
                        }*/
                    }/*
                            f.posibleMoves.Clear();
                            f.posibleMoves.AddRange(tempAvaibleMoves);*/
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
                    figuresTable[i, j].isProtected = false;
                    if (figuresTable[i, j].nameFigure == "Krol" && figuresTable[i, j].color == whichMove)
                    {
                        posKing = figuresTable[i, j].positionOnBoard;
                    }
                }
            }
        }
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
