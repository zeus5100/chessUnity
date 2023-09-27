using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

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
    public static bool canGuard = false;
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

    //wyczysc plansze

    public Button clearButton;


    //historia ruchów
    public MovePrefab movePrefab;
    public static MovePrefab staticMovePrefab;
    public static List<MoveObject> movesHistory = new List<MoveObject>();

    public GameObject historyPlace;
    public static GameObject staticHistoryPlace;

    //Promocja pionka

    public GameObject promotePlace;
    public static GameObject staticPromotePlace;

    //historia pozycji
    public static Dictionary<string, int> samePositionCount = new Dictionary<string, int>();

    //powtorzenie 50 razy

    public static int countWithoutCapture;

    void Start()
    {

        whichMove = true;
        whichMethod = 99;
        countWithoutCapture = 0;
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
        staticMovePrefab = movePrefab;
        staticHistoryPlace = historyPlace;
        staticPromotePlace = promotePlace;



        resetGame.onClick.AddListener(generateStartPosition);
        clearButton.onClick.AddListener(clearBoard);
        //*************
    }

    public static void promoteReady()
    {
        staticPromotePlace.SetActive(false);
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
    public static char nameToSymbol(string x)
    {
        switch (x)
        {
            case "Wieza": return 'R';
            case "Pionek": return ' ';
            case "Kon": return 'N';
            case "Krol": return 'K';
            case "Hetman": return 'Q';
            case "Goniec": return 'B';
        }
        return ' ';
    }

    public static string PositionToString()
    {
        string s = "";
        foreach (Figure f in figuresTable)
        {
            if (f != null)
            {
                s += f.toString();
            }
        }
        return s;
    }
    public static void moveFigure(int targetX, int targetY)
    {
        if (figuresTable[currentX, currentY] != null)
        {
            if (pawnPromote(targetX, targetY))
            {
                return;
            }
            var obj = new MoveObject();
            obj.currentPos = new Wspolrzedne(targetX, targetY);
            obj.lastPos = figuresTable[currentX, currentY].positionOnBoard;
            obj.capture = false;
            obj.figureSymbol = nameToSymbol(figuresTable[currentX, currentY].nameFigure);
            countWithoutCapture++;
            if (figuresTable[targetX, targetY] != null)
            {
                obj.capture = true;
                countWithoutCapture = 0;
                Destroy(figuresTable[targetX, targetY].gameObject);
            }
            if (countWithoutCapture == 50)
            {
                Debug.Log("Draw");
                return;
            }
            movesHistory.Add(obj);
            kingCastle(targetX);
            enPassant(targetX, targetY);
            figuresTable[targetX, targetY] = figuresTable[currentX, currentY];
            figuresTable[currentX, currentY] = null;
            figuresTable[targetX, targetY].setPostion(targetX, targetY);
            figuresTable[targetX, targetY].hasMoved = true;
            figuresTable[targetX, targetY].transform.localPosition = new Vector2(figuresTable[targetX, targetY].positionOnBoard.Litera * 125, figuresTable[targetX, targetY].positionOnBoard.Liczba * -125);
            figuresTable[targetX, targetY].hideAvaibleMoves();
            attackingFields.Clear();
            var position = PositionToString();
            int value;
            if (!samePositionCount.TryGetValue(position, out value))
            {
                samePositionCount[position] = 1;
            }
            else
            {
                samePositionCount[position] += 1;
                if (samePositionCount[position] == 3)
                {
                    Debug.Log("Draw");
                    return;
                }
            }



            if (whichMove)
            {
                var moveHistory = Instantiate(staticMovePrefab, staticHistoryPlace.transform);
                moveHistory.setMoveCount((movesHistory.Count + 1) / 2);
                moveHistory.setWhiteMove(obj.toString());
                whichMove = false;
            }
            else
            {
                int lastChildIndex = staticHistoryPlace.transform.childCount - 1;
                Transform lastChildTransform = staticHistoryPlace.transform.GetChild(lastChildIndex);
                MovePrefab lastChildMoveObject = lastChildTransform.GetComponent<MovePrefab>();
                lastChildMoveObject.setBlackMove(obj.toString());
                whichMove = true;
            }
            isChecked = false;
            generateAvaibleMoves();
            int indexX = posKing.Litera;
            int indexY = posKing.Liczba;
            if (isChecked)
            {
                if (figuresChecking.Count < 2)
                {
                    //figury które mog¹ zas³oniæ szacha
                    figuresTable[indexX, indexY].posibleMoves.Clear();
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

                            if (tempAvaibleMoves.Count > 0)
                            {
                                canGuard = true;
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
                    foreach (Figure f in figuresTable)
                    {
                        if (f != null && f.color == whichMove && f.nameFigure != "Krol")
                        {
                            f.posibleMoves.Clear();
                        }
                    }
                }
            }
            if (!isChecked)
            {
                foreach (Figure f in figuresTable)
                {
                    if (f != null && f.nameFigure == "Pionek")
                    {
                        f.posibleMoves.Clear();
                        if (f.color)
                        {
                            f.posibleMoves.Add(new Wspolrzedne(f.positionOnBoard.Litera - 1, f.positionOnBoard.Liczba + 1));
                            f.posibleMoves.Add(new Wspolrzedne(f.positionOnBoard.Litera + 1, f.positionOnBoard.Liczba + 1));
                        }
                        else
                        {
                            f.posibleMoves.Add(new Wspolrzedne(f.positionOnBoard.Litera - 1, f.positionOnBoard.Liczba - 1));
                            f.posibleMoves.Add(new Wspolrzedne(f.positionOnBoard.Litera + 1, f.positionOnBoard.Liczba - 1));
                        }
                    }
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
            if (!isChecked)
            {
                foreach (Figure f in figuresTable)
                {
                    if (f != null && f.nameFigure == "Pionek")
                    {
                        f.posibleMoves.Clear();
                        f.generateAvaibleMoves();
                    }
                }
            }
            bool isDraw = true;
            foreach (Figure f in figuresTable)
            {
                if (f != null && f.color == whichMove)
                {
                    if (f.posibleMoves.Count > 0)
                    {
                        isDraw = false;
                        break;
                    }
                }
            }

            if (!canGuard && figuresTable[indexX, indexY].posibleMoves.Count == 0 && isChecked)
            {
                Debug.Log("Checkmate");
            }
            else if (isDraw)
            {
                Debug.Log("DRAW");
                return;
            }
        }
    }


    public static void enPassant(int targetX, int targetY)
    {
        if (figuresTable[currentX, currentY].nameFigure == "Pionek")
        {
            if (currentX != targetX && figuresTable[targetX, targetY] == null)
            {
                Destroy(figuresTable[targetX, currentY].gameObject);
            }
        }
    }
    public static void kingCastle(int x)
    {

        if (figuresTable[currentX, currentY].nameFigure == "Krol" && !figuresTable[currentX, currentY].hasMoved)
        {
            if (x == 5)
            {
                Debug.Log("test");
                figuresTable[4, currentY] = figuresTable[7, currentY];
                figuresTable[7, currentY] = null;
                figuresTable[4, currentY].setPostion(4, currentY);
                figuresTable[4, currentY].hasMoved = true;
                figuresTable[4, currentY].transform.localPosition = new Vector2(figuresTable[4, currentY].positionOnBoard.Litera * 125, figuresTable[4, currentY].positionOnBoard.Liczba * -125);
            }
            if (x == 1)
            {
                Debug.Log("test2");
                figuresTable[2, currentY] = figuresTable[0, currentY];
                figuresTable[0, currentY] = null;
                figuresTable[2, currentY].setPostion(2, currentY);
                figuresTable[2, currentY].hasMoved = true;
                figuresTable[2, currentY].transform.localPosition = new Vector2(figuresTable[2, currentY].positionOnBoard.Litera * 125, figuresTable[2, currentY].positionOnBoard.Liczba * -125);
            }
        }
    }

    public static bool pawnPromote(int x, int y)
    {
        if (figuresTable[currentX, currentY].nameFigure == "Pionek")
        {
            if (y == 7)
            {
                staticPromotePlace.SetActive(true);
                PromotionController.choosedWhite();
                PromotionController.x = x;
                PromotionController.y = y;
                return true;
            }

            if (y == 0)
            {
                staticPromotePlace.SetActive(true);
                PromotionController.choosedBlack();
                PromotionController.x = x;
                PromotionController.y = y;
                return true;
            }
        }
        return false;
    }

    public static void replaceFigure(bool color, int figureIndex)
    {
        colorFigureToCreate = color;
        numberFigureToCreate = figureIndex;
        posibleFigureCreate = true;
        Destroy(figuresTable[currentX, currentY].gameObject);
        addFigure(currentX, currentY);
        moveFigure(PromotionController.x, PromotionController.y);
        posibleFigureCreate = false;
        staticPromotePlace.SetActive(false);
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

    public static void clearBoard()
    {
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
        foreach (Transform child in PosibleMoves.place.transform)
        {
            Destroy(child.gameObject);
        }
        samePositionCount.Clear();
        countWithoutCapture = 0;
    }

    public static void generateStartPosition()
    {
        clearBoard();
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
        var position = PositionToString();
        samePositionCount[position] = 1;
    }

    // Update is called once per frame

    private void Update()
    {

    }
}
