using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class Figure : MonoBehaviour
{
    public string name;
    public Sprite imageB;
    public Sprite imageC;
    public int value;
    public bool color;
    public Button button;
    public Image myImage;
    public Image greenImage;
    public bool visibleMoves;
    public GameObject toShowAvaibleMoves;
    public Wspolrzedne positionOnBoard;
    List<Wspolrzedne> posibleMoves = new List<Wspolrzedne>();
    private void Start()
    {
        button.onClick.AddListener(showAvaibleMoves);
        visibleMoves = true;
        showAvaibleMoves();
    }
    

    public void generateAvaibleMoves()
    {
        posibleMoves.Clear();
        switch(name)
        {
            case "Wie�a" :
                Debug.Log(positionOnBoard.toSting());
                Debug.Log("Lista: ");
                //ruch w prawo do sciany
                for(int i = positionOnBoard.Litera + 1; i<=7; i++)
                {
                    if (GameManager.figuresTable[i, positionOnBoard.Liczba] == null )
                    {
                        posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                    } else
                    {
                        if(GameManager.figuresTable[i, positionOnBoard.Liczba].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                        }
                        i = 8;
                    }
                }
                //ruch w lewo do sciany
                for (int i = positionOnBoard.Litera - 1; i >= 0; i--)
                {
                    if ( GameManager.figuresTable[i, positionOnBoard.Liczba] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                    }
                    else
                    {
                        if(GameManager.figuresTable[i, positionOnBoard.Liczba].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(i, positionOnBoard.Liczba));
                        }
                        i = -1;
                    }
                }
                // ruch w gore do krawedzi
                for (int i = positionOnBoard.Liczba + 1; i <= 7; i++)
                {
                    if ( GameManager.figuresTable[positionOnBoard.Litera, i] == null )
                    {
                        posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera, i));
                    }
                    else
                    {
                        if ( GameManager.figuresTable[positionOnBoard.Litera, i].color != GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba].color)
                        {
                            posibleMoves.Add(new Wspolrzedne(positionOnBoard.Litera, i));
                        }
                        i = 8;
                    }
                }
                // ruch w dol do krawedzi
                for (int i = positionOnBoard.Liczba - 1; i >= 0; i--)
                {
                    if ( GameManager.figuresTable[positionOnBoard.Litera, i] == null)
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
                break;

            case "Goniec":

                // ruch dol-prawo do krawedzi
                for(int i=positionOnBoard.Litera + 1, j = positionOnBoard.Liczba + 1; i <= 7 && j <= 7; i++, j++)
                {
                    if (
                        GameManager.figuresTable[i, j] == null ||
                        GameManager.figuresTable[i, j].color !=
                        GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(i, j));
                    }
                    else
                    {
                        i = 8;
                    }
                }

                // ruch dol-lewo do krawedzi
                for (int i = positionOnBoard.Litera - 1, j = positionOnBoard.Liczba + 1; i >= 0 && j <= 7; i--, j++)
                {
                    if (
                        GameManager.figuresTable[i, j] == null ||
                        GameManager.figuresTable[i, j].color !=
                        GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(i, j));
                    }
                    else
                    {
                        i = -1;
                    }
                }

                // ruch gora-lewo do krawedzi


                for (int i = positionOnBoard.Litera - 1, j = positionOnBoard.Liczba -1; i >= 0 && j >=0; i--,j--)
                {
                    if (GameManager.figuresTable[i, j] == null ||
                        GameManager.figuresTable[i, j].color !=
                        GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(i, j));
                    }
                    else
                    {
                        i = -1;
                    }
                }

                // ruch gora-prawo do krawedzi
                for (int i = positionOnBoard.Litera + 1, j = positionOnBoard.Liczba - 1; i <= 7 && j >=0; i++,j--)
                {
                    if (
                        GameManager.figuresTable[i, j] == null ||
                        GameManager.figuresTable[i, j].color !=
                        GameManager.figuresTable[positionOnBoard.Litera, positionOnBoard.Liczba]
                        )
                    {
                        posibleMoves.Add(new Wspolrzedne(i, j));
                    }
                    else
                    {
                        i = 8;
                    }
                }
                break;

            case "Ko�":
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
        }
        
        for(int i=0; i<posibleMoves.Count; i++)
        {
            var temp = Instantiate(greenImage, toShowAvaibleMoves.transform);
            temp.transform.localPosition = new Vector2(posibleMoves[i].Litera * 125 - positionOnBoard.Litera * 125, posibleMoves[i].Liczba * -125 + positionOnBoard.Liczba * 125);
            Debug.Log(posibleMoves[i].toSting());
        }
    }
    public void showAvaibleMoves()
    {
        if(visibleMoves)
        {
            toShowAvaibleMoves.SetActive(false);
            visibleMoves = false;
        } else
        {
            toShowAvaibleMoves.SetActive(true);
            visibleMoves = true;
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
        if(color)
        {
            myImage.sprite = imageB;
        } else
        {
            myImage.sprite = imageC;
        }
    }
    Vector2 convertPosition(int x, int y)
    {
        return new Vector2((x - 1) * 125, (y - 1) * 125);
    }
}
