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
    public bool visibleMoves;
    public Wspolrzedne positionOnBoard;
    List<Wspolrzedne> posibleMoves = new List<Wspolrzedne>();
    private void Start()
    {
        button.onClick.AddListener(showAvaibleMoves);
        visibleMoves = true;
        showAvaibleMoves();
    }

    private void Update()
    {

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
                        GameManager.figuresTable[x + 1, y - 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y - 1));
                    }
                }
                //2prawa-strona
                if (x + 1 <= 7)
                {
                    if (GameManager.figuresTable[x + 1, y] == null ||
                        GameManager.figuresTable[x + 1, y].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y));
                    }
                }
                //3prawy-dolny
                if (x + 1 <= 7 && y + 1 <= 7)
                {
                    if (GameManager.figuresTable[x + 1, y + 1] == null ||
                        GameManager.figuresTable[x + 1, y + 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y + 1));
                    }
                }
                //4dolna-strona
                if (y + 1 <= 7)
                {
                    if (GameManager.figuresTable[x, y + 1] == null ||
                        GameManager.figuresTable[x, y + 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x, y + 1));
                    }
                }
                //5lewy-dolny
                if (x - 1 >= 0 && y + 1 <= 7)
                {
                    if (GameManager.figuresTable[x - 1, y + 1] == null ||
                        GameManager.figuresTable[x - 1, y + 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y + 1));
                    }
                }
                //6lewa-strona
                if (x - 1 >= 0)
                {
                    if (GameManager.figuresTable[x - 1, y] == null ||
                        GameManager.figuresTable[x - 1, y].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y));
                    }
                }
                //7lewy-gorny
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (GameManager.figuresTable[x - 1, y - 1] == null ||
                        GameManager.figuresTable[x - 1, y - 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y - 1));
                    }
                }
                //8gorna-strona
                if (y - 1 >= 0)
                {
                    if (GameManager.figuresTable[x, y - 1] == null ||
                        GameManager.figuresTable[x, y - 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x, y - 1));
                    }
                }
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
                    //przod lewo
                    if (x - 1 >= 0 && y + 1 <= 7 &&
                        GameManager.figuresTable[x - 1, y + 1] != null &&
                        GameManager.figuresTable[x - 1, y + 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y + 1));

                        if (GameManager.figuresTable[x - 1, y + 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    //przod prawo
                    if (x + 1 <= 7 && y + 1 <= 7 &&
                        GameManager.figuresTable[x + 1, y + 1] != null &&
                        GameManager.figuresTable[x + 1, y + 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y + 1));

                        if (GameManager.figuresTable[x + 1, y + 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }

                }
                else
                {
                    //przod o jeden
                    if ( y - 1 >= 0 && GameManager.figuresTable[x, y - 1] == null)
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
                    if (x - 1 >= 0 && y - 1 >= 0 &&
                        GameManager.figuresTable[x - 1, y - 1] != null &&
                        GameManager.figuresTable[x - 1, y - 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x - 1, y - 1));

                        if (GameManager.figuresTable[x - 1, y - 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
                        }
                    }
                    //przod prawo
                    if (x + 1 <= 7 && y - 1 >= 0 &&
                        GameManager.figuresTable[x + 1, y - 1] != null &&
                        GameManager.figuresTable[x + 1, y - 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y - 1));

                        if (GameManager.figuresTable[x + 1, y - 1].nameFigure == "Krol")
                        {
                            GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                            GameManager.isChecked = true;
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
    public void showAvaibleMoves()
    {

        if (visibleMoves)
        {
            visibleMoves = false;
        }
        else
        {
            if (GameManager.whichMove == color)
            {
                togetherGenerate();
                GameManager.currentX = positionOnBoard.Litera;
                GameManager.currentY = positionOnBoard.Liczba;
                GameManager.posibleFigureCreate = false;
                visibleMoves = true;
                Debug.Log("K00tas");
            }
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
        visibleMoves = false;
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

    public void bishopMoves(int whichMoves)
    {
        posibleMoves.Clear();
        switch(whichMoves)
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
        }

        GameManager.attackingFields.AddRange(posibleMoves);
    }

    void rookMoves()
    {
        //ruch w prawo do sciany
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, positionOnBoard.Liczba].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                        Debug.Log(GameManager.isChecked);
                    }
                }
                i = 8;
            }
        }
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, positionOnBoard.Liczba].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                    }
                }
                i = -1;
            }
        }
        // ruch w gore do krawedzi
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[positionOnBoard.Litera, i].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                    }
                }
                i = 8;
            }
        }
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[positionOnBoard.Litera, i].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.isChecked = true;
                    }
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 0;
                        GameManager.isChecked = true;
                    }
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 1;
                        GameManager.isChecked = true;
                    }
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 2;
                        GameManager.isChecked = true;
                    }
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
                    //Sprawdzanie czy szach
                    if (GameManager.figuresTable[i, j].nameFigure == "Krol")
                    {
                        GameManager.figuresChecking.Add(GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]);
                        GameManager.whichMethod = 3;
                        GameManager.isChecked = true;
                    }
                }
                i = 8;
            }
        }
    }

    
}
