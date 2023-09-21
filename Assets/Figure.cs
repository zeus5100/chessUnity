using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Figure : MonoBehaviour
{
    public string name;
    public char x;
    public int y;
    public Sprite imageB;
    public Sprite imageC;
    public int value;
    public bool color;
    public Image myImage;
    public Button button;
    public Image greenImage;
    public bool visibleMoves;
    public GameObject toShowAvaibleMoves;
    private void Start()
    {
        button.onClick.AddListener(showAvaibleMoves);
        visibleMoves = true;
        showAvaibleMoves();
    }

    public void generateAvaibleMoves()
    {
        var temp = Instantiate(greenImage, toShowAvaibleMoves.transform);
        temp.transform.localPosition = new Vector2(0, 0);
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
    public void setPostion(char a, int b)
    {
        x = a; y = b;
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
    Vector2 convertPosition(char x, int y)
    {
        return new Vector2((letterToPostion(x) - 1) * 125, (y - 1) * 125);
    }
    int letterToPostion(char s)
    {
        int value = 0;
        switch (s)
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
}
