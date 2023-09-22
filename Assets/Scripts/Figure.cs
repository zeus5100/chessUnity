using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class Figure : MonoBehaviour
{
    [SerializeField] string nameFigure;
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
                    if (GameManager.figuresTable[x, y + 1] == null)
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
                    }
                    //przod prawo
                    if (x + 1 <= 7 && y + 1 <= 7 &&
                        GameManager.figuresTable[x + 1, y + 1] != null &&
                        GameManager.figuresTable[x + 1, y + 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y + 1));
                    }

                }
                else
                {
                    //przod o jeden
                    if (GameManager.figuresTable[x, y - 1] == null)
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
                    }
                    //przod prawo
                    if (x + 1 <= 7 && y - 1 >= 0 &&
                        GameManager.figuresTable[x + 1, y - 1] != null &&
                        GameManager.figuresTable[x + 1, y - 1].color != GameManager.figuresTable[x, y].color)
                    {
                        posibleMoves.Add(new Wspolrzedne(x + 1, y - 1));
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
        // ruch dol-prawo do krawedzi
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
                }
                i = 8;
            }
        }

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
                }
                i = -1;
            }
        }

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
                }
                i = -1;
            }
        }

        // ruch gora-prawo do krawedzi
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
                }
                i = 8;
            }
        }
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
                }
                i = -1;
            }
        }
    }

}
