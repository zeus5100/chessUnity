using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Wspolrzedne postionOnBoard;
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
            case "Wie¿a" :
                Debug.Log(postionOnBoard.toSting());
                Debug.Log("Lista: ");
                //ruch w prawo do sciany
                for(int i = postionOnBoard.Litera + 1; i<=7; i++)
                {
                    if (GameManager.figuresTable[i, postionOnBoard.Liczba] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(i, postionOnBoard.Liczba));
                    } else
                    {
                        i = 8;
                    }
                }
                //ruch w lewo do sciany
                for (int i = postionOnBoard.Litera - 1; i >= 0; i--)
                {
                    if (GameManager.figuresTable[i, postionOnBoard.Liczba] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(i, postionOnBoard.Liczba));
                    }
                    else
                    {
                        i = -1;
                    }
                }
                // ruch w gore do krawedzi
                for (int i = postionOnBoard.Liczba + 1; i <= 7; i++)
                {
                    if (GameManager.figuresTable[postionOnBoard.Litera, i] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(postionOnBoard.Litera, i));
                    }
                    else
                    {
                        i = 8;
                    }
                }
                // ruch w dol do krawedzi
                for (int i = postionOnBoard.Liczba - 1; i >= 0; i--)
                {
                    if (GameManager.figuresTable[postionOnBoard.Litera, i] == null)
                    {
                        posibleMoves.Add(new Wspolrzedne(postionOnBoard.Litera, i));
                    }
                    else
                    {
                        i = -1;
                    }
                }
                break;
        }
        //var temp = Instantiate(greenImage, toShowAvaibleMoves.transform);
        //temp.transform.localPosition = new Vector2(0, 0);
        for(int i=0; i<posibleMoves.Count; i++)
        {
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
        postionOnBoard = new Wspolrzedne(a, b);
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
