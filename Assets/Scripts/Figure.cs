using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class Figure : MonoBehaviour
{
    [SerializeField] public string nameFigure;
    public Sprite imageB;
    public Sprite imageC;
    public int value;
    public bool color;
    public Button button;
    public Image myImage;
    public Image greenImage;
    public Image redImage;
    public Wspolrzedne positionOnBoard;
    public List<Wspolrzedne> posibleMoves = new List<Wspolrzedne>();
    public bool isProtected;
    public bool hasMoved;
    private void Start()
    {
        hasMoved = false;
        button.onClick.AddListener(showAvaibleMoves);
    }

    private void Update()
    {

    }
    public string toString()
    {
        return nameFigure + positionOnBoard.Litera.ToString() + positionOnBoard.Liczba.ToString();
    }
    public void generateAvaibleMoves()
    {
        posibleMoves.Clear();
        switch (nameFigure)
        {
            case "Wieza":
                rookMoves();
                break;

            case "Goniec":
                bishopMoves();
                break;

            case "Kon":
                // Gora-Prawo
                int x = positionOnBoard.Litera;
                int y = positionOnBoard.Liczba;
                if (x + 1 <= 7 && y - 2 >= 0)
                {
                    if (
                        GameManager.figuresTable[x + 1, y - 2] == null ||
                        GameManager.figuresTable[x + 1, y - 2].color !=
                        GameManager.figuresTable[x, y].color

                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y - 2));

                        if (GameManager.figuresTable[x + 1, y - 2] != null && GameManager.figuresTable[x + 1, y - 2].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }

                    }
                    else
                    {
                        GameManager.figuresTable[x + 1, y - 2].isProtected = true;
                    }
                }
                // Dol-Prawo
                if (x + 1 <= 7 && y + 2 <= 7)
                {
                    if (
                        GameManager.figuresTable[x + 1, y + 2] == null ||
                        GameManager.figuresTable[x + 1, y + 2].color !=
                        GameManager.figuresTable[x, y].color
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y + 2));

                        if (GameManager.figuresTable[x + 1, y + 2] != null && GameManager.figuresTable[x + 1, y + 2].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x + 1, y + 2].isProtected = true;
                    }
                }
                // Prawo-Gora
                if (x + 2 <= 7 && y - 1 >= 0)
                {
                    if (
                        GameManager.figuresTable[x + 2, y - 1] == null ||
                        GameManager.figuresTable[x + 2, y - 1].color !=
                        GameManager.figuresTable[x, y].color
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 2, y - 1));

                        if (GameManager.figuresTable[x + 2, y - 1] != null && GameManager.figuresTable[x + 2, y - 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x + 2, y - 1].isProtected = true;
                    }
                }
                // Prawo-Dol
                if (x + 2 <= 7 && y + 1 <= 7)
                {
                    if (
                        GameManager.figuresTable[x + 2, y + 1] == null ||
                        GameManager.figuresTable[x + 2, y + 1].color !=
                        GameManager.figuresTable[x, y].color
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 2, y + 1));

                        if (GameManager.figuresTable[x + 2, y + 1] != null && GameManager.figuresTable[x + 2, y + 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x + 2, y + 1].isProtected = true;
                    }
                }

                //______________________________________________________

                // Gora-Lewo
                if (x - 1 >= 0 && y - 2 >= 0)
                {
                    if (
                        GameManager.figuresTable[x - 1, y - 2] == null ||
                        GameManager.figuresTable[x - 1, y - 2].color !=
                        GameManager.figuresTable[x, y].color
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y - 2));

                        if (GameManager.figuresTable[x - 1, y - 2] != null && GameManager.figuresTable[x - 1, y - 2].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x - 1, y - 2].isProtected = true;
                    }
                }
                // Dol-Lewo
                if (x - 1 >= 0 && y + 2 <= 7)
                {
                    if (
                        GameManager.figuresTable[x - 1, y + 2] == null ||
                        GameManager.figuresTable[x - 1, y + 2].color !=
                        GameManager.figuresTable[x, y].color
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y + 2));

                        if (GameManager.figuresTable[x - 1, y + 2] != null && GameManager.figuresTable[x - 1, y + 2].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x - 1, y + 2].isProtected = true;
                    }
                }
                // Lewo-Gora
                if (x - 2 >= 0 && y - 1 >= 0)
                {
                    if (
                        GameManager.figuresTable[x - 2, y - 1] == null ||
                        GameManager.figuresTable[x - 2, y - 1].color !=
                        GameManager.figuresTable[x, y].color
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 2, y - 1));

                        if (GameManager.figuresTable[x - 2, y - 1] != null && GameManager.figuresTable[x - 2, y - 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x - 2, y - 1].isProtected = true;
                    }
                }
                // Lewo-Dol
                if (x - 2 >= 0 && y + 1 <= 7)
                {
                    if (
                        GameManager.figuresTable[x - 2, y + 1] == null ||
                    GameManager.figuresTable[x - 2, y + 1].color !=
                    GameManager.figuresTable[x, y].color
                    )
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 2, y + 1));

                        if (GameManager.figuresTable[x - 2, y + 1] != null && GameManager.figuresTable[x - 2, y + 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    else
                    {
                        GameManager.figuresTable[x - 2, y + 1].isProtected = true;
                    }
                }

                break;

            case "Hetman":
                //Ruchy gonca + ruchy wiezy
                bishopMoves();
                rookMoves();
                break;
            case "Krol":
                x = positionOnBoard.Litera;
                y = positionOnBoard.Liczba;
                //1prawy-g�rny
                if (x + 1 <= 7 && y - 1 >= 0)
                {
                    if (GameManager.figuresTable[x + 1, y - 1] == null ||
                        (GameManager.figuresTable[x + 1, y - 1].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x + 1, y - 1].isProtected))
                    {

                        posibleMoves.Add(new Wspolrzedne(x + 1, y - 1));
                    }
                    else
                    {
                        GameManager.figuresTable[x + 1, y - 1].isProtected = true;
                    }
                }
                //2prawa-strona
                if (x + 1 <= 7)
                {
                    if (GameManager.figuresTable[x + 1, y] == null ||
                        (GameManager.figuresTable[x + 1, y].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x + 1, y].isProtected)
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y));
                    }
                    else
                    {
                        GameManager.figuresTable[x + 1, y].isProtected = true;
                    }
                }
                //3prawy-dolny
                if (x + 1 <= 7 && y + 1 <= 7)
                {
                    if (GameManager.figuresTable[x + 1, y + 1] == null ||
                        (GameManager.figuresTable[x + 1, y + 1].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x + 1, y + 1].isProtected))
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y + 1));
                    }
                    else
                    {
                        GameManager.figuresTable[x + 1, y + 1].isProtected = true;
                    }
                }
                //4dolna-strona
                if (y + 1 <= 7)
                {
                    if (GameManager.figuresTable[x, y + 1] == null ||
                        (GameManager.figuresTable[x, y + 1].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x, y + 1].isProtected))
                    {
                        posibleMoves.Add(new Wspolrzedne(x, y + 1));
                    }
                    else
                    {
                        GameManager.figuresTable[x, y + 1].isProtected = true;
                    }
                }
                //5lewy-dolny
                if (x - 1 >= 0 && y + 1 <= 7)
                {
                    if (GameManager.figuresTable[x - 1, y + 1] == null ||
                        (GameManager.figuresTable[x - 1, y + 1].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x - 1, y + 1].isProtected))
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y + 1));
                    }
                    else
                    {
                        GameManager.figuresTable[x - 1, y + 1].isProtected = true;
                    }
                }
                //6lewa-strona
                if (x - 1 >= 0)
                {
                    if (GameManager.figuresTable[x - 1, y] == null ||
                        (GameManager.figuresTable[x - 1, y].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x - 1, y].isProtected))
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y));
                    }
                    else
                    {
                        GameManager.figuresTable[x - 1, y].isProtected = true;
                    }
                }
                //7lewy-gorny
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (GameManager.figuresTable[x - 1, y - 1] == null ||
                        (GameManager.figuresTable[x - 1, y - 1].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x - 1, y - 1].isProtected))
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y - 1));
                    }
                    else
                    {
                        GameManager.figuresTable[x - 1, y - 1].isProtected = true;
                    }
                }
                //8gorna-strona
                if (y - 1 >= 0)
                {
                    if (GameManager.figuresTable[x, y - 1] == null ||
                        (GameManager.figuresTable[x, y - 1].color != GameManager.figuresTable[x, y].color &&
                        !GameManager.figuresTable[x, y - 1].isProtected))
                    {
                        posibleMoves.Add(new Wspolrzedne(x, y - 1));
                    }
                    else
                    {
                        GameManager.figuresTable[x, y - 1].isProtected = true;
                    }
                }
                checkPosibleCast();
                break;
            case "Pionek":
                x = positionOnBoard.Litera;
                y = positionOnBoard.Liczba;
                if (color)
                {
                    //przod o jeden
                    if (y + 1 <= 7 && GameManager.figuresTable[x, y + 1] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(x, y + 1));
                        //przod o dwa
                        if (y == 1)
                        {
                            if (GameManager.figuresTable[x, y + 2] == null)
                            {
                                posibleMoves.Add(new Wspolrzedne(x, y + 2));
                            }
                        }
                    }
                    //przod prawo
                    if (x - 1 >= 0 && y + 1 <= 7)
                    {
                        if (GameManager.figuresTable[x - 1, y + 1] != null &&
                        GameManager.figuresTable[x - 1, y + 1].color != GameManager.figuresTable[x, y].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(x - 1, y + 1));
                            if (GameManager.figuresTable[x - 1, y + 1].nameFigure == "Krol")
                            {
                                GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                                GameManager.isChecked = true;
                            }
                            else
                            {
                                GameManager.figuresTable[x - 1, y + 1].isProtected = true;
                            }
                        }
                        else if (y == 4 &&
                            GameManager.figuresTable[x - 1, y] != null &&
                            GameManager.figuresTable[x - 1, y].nameFigure == "Pionek" &&
                            GameManager.figuresTable[x - 1, y].color == false &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Litera == (x - 1) &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].lastPos.Liczba - GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Liczba == 2
                            )
                        {
                            posibleMoves.Add(new Wspolrzedne(x - 1, y + 1));
                        }
                    }
                    //przod lewo
                    if (x + 1 <= 7 && y + 1 <= 7)
                    {
                        if (GameManager.figuresTable[x + 1, y + 1] != null &&
                        GameManager.figuresTable[x + 1, y + 1].color != GameManager.figuresTable[x, y].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(x + 1, y + 1));

                            if (GameManager.figuresTable[x + 1, y + 1].nameFigure == "Krol")
                            {
                                GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                                GameManager.isChecked = true;
                            }
                            else
                            {
                                GameManager.figuresTable[x + 1, y + 1].isProtected = true;
                            }
                        }
                        else if (y == 4 &&
                            GameManager.figuresTable[x + 1, y] != null &&
                            GameManager.figuresTable[x + 1, y].nameFigure == "Pionek" &&
                            GameManager.figuresTable[x + 1, y].color == false &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Litera == (x + 1) &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].lastPos.Liczba - GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Liczba == 2
                            )
                        {
                            posibleMoves.Add(new Wspolrzedne(x + 1, y + 1));
                        }
                    }

                }
                else
                {
                    //przod o jeden
                    if (y - 1 >= 0 && GameManager.figuresTable[x, y - 1] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(x, y - 1));
                        //przod o dwa
                        if (y == 6)
                        {
                            if (GameManager.figuresTable[x, y - 2] == null)
                            {
                                posibleMoves.Add(new Wspolrzedne(x, y - 2));
                            }
                        }
                    }
                    //przod lewo
                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        if (GameManager.figuresTable[x - 1, y - 1] != null &&
                        GameManager.figuresTable[x - 1, y - 1].color != GameManager.figuresTable[x, y].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(x - 1, y - 1));

                            if (GameManager.figuresTable[x - 1, y - 1].nameFigure == "Krol")
                            {
                                GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                                GameManager.isChecked = true;
                            }
                            else
                            {
                                GameManager.figuresTable[x - 1, y - 1].isProtected = true;
                            }
                        }
                        else if (y == 3 &&
                            GameManager.figuresTable[x - 1, y] != null &&
                            GameManager.figuresTable[x - 1, y].nameFigure == "Pionek" &&
                            GameManager.figuresTable[x - 1, y].color == true &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Litera == (x - 1) &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Liczba - GameManager.movesHistory[GameManager.movesHistory.Count - 1].lastPos.Liczba == 2
                            )
                        {
                            posibleMoves.Add(new Wspolrzedne(x - 1, y - 1));
                        }

                    }
                    //przod prawo
                    if (x + 1 <= 7 && y - 1 >= 0)
                    {
                        if (GameManager.figuresTable[x + 1, y - 1] != null &&
                        GameManager.figuresTable[x + 1, y - 1].color != GameManager.figuresTable[x, y].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(x + 1, y - 1));

                            if (GameManager.figuresTable[x + 1, y - 1].nameFigure == "Krol")
                            {
                                GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                                GameManager.isChecked = true;
                            }
                            else
                            {
                                GameManager.figuresTable[x + 1, y - 1].isProtected = true;
                            }
                        }
                        else if (y == 3 &&
                            GameManager.figuresTable[x + 1, y] != null &&
                            GameManager.figuresTable[x + 1, y].nameFigure == "Pionek" &&
                            GameManager.figuresTable[x + 1, y].color == true &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Litera == (x + 1) &&
                            GameManager.movesHistory[GameManager.movesHistory.Count - 1].currentPos.Liczba - GameManager.movesHistory[GameManager.movesHistory.Count - 1].lastPos.Liczba == 2
                            )
                        {
                            posibleMoves.Add(new Wspolrzedne(x + 1, y - 1));
                        }

                    }
                }
                break;
        }

        /*for (int i = 0; i < posibleMoves.Count; i++)
        {
            var temp = Instantiate(greenImage, toShowAvaibleMoves.transform);
            temp.transform.localPosition = new Vector2(posibleMoves[i].Litera * 125 - positionOnBoard.Litera * 125, posibleMoves[i].Liczba * -125 + positionOnBoard.Liczba * 125);
            // Debug.Log(posibleMoves[i].toSting());
        }*/
    }


    public void checkPosibleCast()
    {
        if (!GameManager.isChecked)
        {
            bool canCastle = true;
            if (!hasMoved &&
                GameManager.figuresTable[positionOnBoard.Litera + 1, positionOnBoard.Liczba] == null &&
                GameManager.figuresTable[positionOnBoard.Litera + 2, positionOnBoard.Liczba] == null &&
                GameManager.figuresTable[positionOnBoard.Litera + 3, positionOnBoard.Liczba] == null &&
                GameManager.figuresTable[positionOnBoard.Litera + 4, positionOnBoard.Liczba] != null &&
                !GameManager.figuresTable[positionOnBoard.Litera + 4, positionOnBoard.Liczba].hasMoved)
            {

                foreach (Figure figure in GameManager.figuresTable)
                {
                    if (figure != null && figure.color != GameManager.whichMove)
                    {
                        foreach (Wspolrzedne wAttack in figure.posibleMoves)
                        {
                            if ((wAttack.Litera == positionOnBoard.Litera + 1 && wAttack.Liczba == positionOnBoard.Liczba) ||
                                (wAttack.Litera == positionOnBoard.Litera + 2 && wAttack.Liczba == positionOnBoard.Liczba) ||
                                (wAttack.Litera == positionOnBoard.Litera + 3 && wAttack.Liczba == positionOnBoard.Liczba))
                            {
                                canCastle = false;
                                break;
                            }
                        }
                    }
                }
                if (canCastle)
                {
                    posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera + 2, positionOnBoard.Liczba));
                }
            }
            if (!hasMoved &&
                GameManager.figuresTable[positionOnBoard.Litera - 1, positionOnBoard.Liczba] == null &&
                GameManager.figuresTable[positionOnBoard.Litera - 2, positionOnBoard.Liczba] == null &&
                GameManager.figuresTable[positionOnBoard.Litera - 3, positionOnBoard.Liczba] != null &&
                !GameManager.figuresTable[positionOnBoard.Litera - 3, positionOnBoard.Liczba].hasMoved)
            {
                canCastle = true;
                foreach (Figure figure in GameManager.figuresTable)
                {
                    if (figure != null && figure.color != GameManager.whichMove)
                    {
                        foreach (Wspolrzedne wAttack in figure.posibleMoves)
                        {
                            if ((wAttack.Litera == positionOnBoard.Litera - 1 && wAttack.Liczba == positionOnBoard.Liczba) ||
                                (wAttack.Litera == positionOnBoard.Litera - 2 && wAttack.Liczba == positionOnBoard.Liczba))
                            {
                                canCastle = false;
                                break;
                            }
                        }
                    }
                }
                if (canCastle)
                {
                    posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera - 2, positionOnBoard.Liczba));
                }
            }
        }
    }
    public void showAvaibleMoves()
    {
        if (GameManager.whichMove == color)
        {
            togetherGenerate();
            GameManager.currentX = positionOnBoard.Litera;
            GameManager.currentY = positionOnBoard.Liczba;
            GameManager.posibleFigureCreate = false;
        }
    }
    public void togetherGenerate()
    {
        foreach (Transform child in PosibleMoves.place.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < posibleMoves.Count; i++)
        {
            var temp = Instantiate(greenImage, PosibleMoves.place.transform);
            temp.transform.localPosition = new Vector2(posibleMoves[i].Litera * 125, posibleMoves[i].Liczba * -125);
            // Debug.Log(posibleMoves[i].toSting());
        }
    }

    public void hideAvaibleMoves()
    {
        foreach (Transform child in PosibleMoves.place.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void setPostion(int a, int b)
    {
        positionOnBoard = new Wspolrzedne(a, b);
    }
    public void setColor(bool x)
    {
        color = x;
    }
    public void setImage()
    {
        if (color)
        {
            myImage.sprite = imageB;
        }
        else
        {
            myImage.sprite = imageC;
        }
    }
    Vector2 convertPosition(int x, int y)
    {
        return new Vector2((x - 1) * 125, (y - 1) * 125);
    }

    void bishopMoves()
    {
        bishopUpRight();
        bishopDownRight();
        bishopDownLeft();
        bishopUpLeft();
    }
    void rookMoves()
    {
        rookUp();
        rookRight();
        rookDown();
        rookLeft();
    }

    public void figuresMoves(int whichMoves)
    {
        switch (whichMoves)
        {
            case 0:
                bishopUpRight();
                break;

            case 1:
                bishopDownRight();
                break;

            case 2:
                bishopDownLeft();
                break;
            case 3:
                bishopUpLeft();
                break;
            case 4:
                rookUp();
                break;
            case 5:
                rookRight();
                break;
            case 6:
                rookDown();
                break;
            case 7:
                rookLeft();
                break;
            default:
                generateAvaibleMoves();
                break;
        }
        GameManager.attackingFields.AddRange(posibleMoves);
        for (int i = 0; i < posibleMoves.Count; i++)
        {
            var temp = Instantiate(redImage, PosibleMoves.place.transform);
            temp.transform.localPosition = new Vector2(posibleMoves[i].Litera * 125, posibleMoves[i].Liczba * -125);
            // Debug.Log(posibleMoves[i].toSting());
        }
    }

    public void rookLeft()
    {
        //ruch w left do sciany
        for (int i = positionOnBoard.Litera + 1; i <= 7; i++)
        {
            if (GameManager.figuresTable[i, positionOnBoard.Liczba] == null)
            {
                posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
            }
            else
            {
                if (GameManager.figuresTable[i, positionOnBoard.Liczba].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                    for (int j = i + 1; j <= 7; j++)
                    {
                        if (GameManager.figuresTable[j, positionOnBoard.Liczba] != null)
                        {
                            if (GameManager.figuresTable[j, positionOnBoard.Liczba].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                                GameManager.pinedMethod.Add(7);
                                GameManager.reversePinedMethod.Add(5);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, positionOnBoard.Liczba].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                        GameManager.whichMethod = 7;
                    }
                }
                else
                {
                    GameManager.figuresTable[i, positionOnBoard.Liczba].isProtected = true;
                }
                i = 8;
            }
        }
    }
    public void rookDown()
    {
        // ruch w down do krawedzi
        for (int i = positionOnBoard.Liczba + 1; i <= 7; i++)
        {
            if (GameManager.figuresTable[positionOnBoard.Litera, i] == null)
            {
                posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera, i));
            }
            else
            {
                if (GameManager.figuresTable[positionOnBoard.Litera, i].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera, i));
                    for (int j = i + 1; j <= 7; j++)
                    {
                        if (GameManager.figuresTable[positionOnBoard.Litera, j] != null)
                        {
                            if (GameManager.figuresTable[positionOnBoard.Litera, j].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(positionOnBoard.Litera, i));
                                GameManager.pinedMethod.Add(6);
                                GameManager.reversePinedMethod.Add(4);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[positionOnBoard.Litera, i].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                        GameManager.whichMethod = 6;
                    }
                }
                else
                {
                    GameManager.figuresTable[positionOnBoard.Litera, i].isProtected = true;
                }
                i = 8;
            }
        }
    }
    public void rookRight()
    {
        //ruch w lewo do sciany
        for (int i = positionOnBoard.Litera - 1; i >= 0; i--)
        {
            if (GameManager.figuresTable[i, positionOnBoard.Liczba] == null)
            {
                posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
            }
            else
            {
                if (GameManager.figuresTable[i, positionOnBoard.Liczba].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (GameManager.figuresTable[j, positionOnBoard.Liczba] != null)
                        {
                            if (GameManager.figuresTable[j, positionOnBoard.Liczba].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                                GameManager.pinedMethod.Add(5);
                                GameManager.reversePinedMethod.Add(7);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, positionOnBoard.Liczba].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                        GameManager.whichMethod = 5;
                    }
                }
                else
                {
                    GameManager.figuresTable[i, positionOnBoard.Liczba].isProtected = true;
                }
                i = -1;
            }
        }
    }
    public void rookUp()
    {
        // ruch w dol do krawedzi
        for (int i = positionOnBoard.Liczba - 1; i >= 0; i--)
        {
            if (GameManager.figuresTable[positionOnBoard.Litera, i] == null)
            {
                posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera, i));
            }
            else
            {
                if (GameManager.figuresTable[positionOnBoard.Litera, i].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera, i));
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (GameManager.figuresTable[positionOnBoard.Litera, j] != null)
                        {
                            if (GameManager.figuresTable[positionOnBoard.Litera, j].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(positionOnBoard.Litera, i));
                                GameManager.pinedMethod.Add(4);
                                GameManager.reversePinedMethod.Add(6);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[positionOnBoard.Litera, i].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                        GameManager.whichMethod = 4;
                    }
                }
                else
                {
                    GameManager.figuresTable[positionOnBoard.Litera, i].isProtected = true;
                }
                i = -1;
            }
        }
    }

    void bishopUpRight()
    {
        // ruch dol-lewo do krawedzi
        for (int i = positionOnBoard.Litera - 1, j = positionOnBoard.Liczba + 1; i >= 0 && j <= 7; i--, j++)
        {
            if (GameManager.figuresTable[i, j] == null)
            {
                posibleMoves.Add(new Wspolrzedne(i, j));
            }
            else
            {
                if (GameManager.figuresTable[i, j].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(i, j));
                    for (int k = i - 1, l = j + 1; k >= 0 && l <= 7; k--, l++)
                    {
                        if (GameManager.figuresTable[k, l] != null)
                        {
                            if (GameManager.figuresTable[k, l].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(i, j));
                                GameManager.pinedMethod.Add(0);
                                GameManager.reversePinedMethod.Add(2);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 0;
                        GameManager.isChecked = true;
                    }
                }
                else
                {
                    GameManager.figuresTable[i, j].isProtected = true;
                }
                i = -1;
            }
        }
    }

    void bishopDownRight()
    {
        // ruch gora-lewo do krawedzi


        for (int i = positionOnBoard.Litera - 1, j = positionOnBoard.Liczba - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (GameManager.figuresTable[i, j] == null)
            {
                posibleMoves.Add(new Wspolrzedne(i, j));
            }
            else
            {
                if (GameManager.figuresTable[i, j].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(i, j));
                    for (int k = i - 1, l = j - 1; k >= 0 && l >= 0; k--, l--)
                    {
                        if (GameManager.figuresTable[k, l] != null)
                        {
                            if (GameManager.figuresTable[k, l].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(i, j));
                                GameManager.pinedMethod.Add(1);
                                GameManager.reversePinedMethod.Add(3);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 1;
                        GameManager.isChecked = true;
                    }
                }
                else
                {
                    GameManager.figuresTable[i, j].isProtected = true;
                }
                i = -1;
            }
        }
    }


    void bishopDownLeft()
    {
        // 2
        for (int i = positionOnBoard.Litera + 1, j = positionOnBoard.Liczba - 1; i <= 7 && j >= 0; i++, j--)
        {
            if (GameManager.figuresTable[i, j] == null)
            {
                posibleMoves.Add(new Wspolrzedne(i, j));
            }
            else
            {
                if (GameManager.figuresTable[i, j].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(i, j));
                    for (int k = i + 1, l = j - 1; k <= 7 && l >= 0; k++, l--)
                    {
                        if (GameManager.figuresTable[k, l] != null)
                        {
                            if (GameManager.figuresTable[k, l].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(i, j));
                                GameManager.pinedMethod.Add(2);
                                GameManager.reversePinedMethod.Add(0);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 2;
                        GameManager.isChecked = true;
                    }
                }
                else
                {
                    GameManager.figuresTable[i, j].isProtected = true;
                }
                i = 8;
            }
        }
    }

    void bishopUpLeft()
    {

        //3
        for (int i = positionOnBoard.Litera + 1, j = positionOnBoard.Liczba + 1; i <= 7 && j <= 7; i++, j++)
        {
            if (GameManager.figuresTable[i, j] == null)
            {
                posibleMoves.Add(new Wspolrzedne(i, j));
            }
            else
            {
                if (GameManager.figuresTable[i, j].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                {
                    posibleMoves.Add(new Wspolrzedne(i, j));
                    for (int k = i + 1, l = j + 1; k <= 7 && l <= 7; k++, l++)
                    {
                        if (GameManager.figuresTable[k, l] != null)
                        {
                            if (GameManager.figuresTable[k, l].nameFigure == "Krol")
                            {
                                GameManager.figuresPined.Add(new Wspolrzedne(i, j));
                                GameManager.pinedMethod.Add(3);
                                GameManager.reversePinedMethod.Add(1);
                            }
                            else
                            {
                                break;
                            }
                            //dodac do listy figur zwiazanych 
                        }
                    }
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 3;
                        GameManager.isChecked = true;
                    }
                }
                else
                {
                    GameManager.figuresTable[i, j].isProtected = true;
                }
                i = 8;
            }
        }
    }


}
