using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Figure[,] figuresTable = new Figure[8, 8];
    public Figure[] avaibleFigures;
    public GameObject plansza;
    public GameObject background;
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
        Figure temp = Instantiate(avaibleFigures[0], plansza.transform);
        Figure temp1 = Instantiate(avaibleFigures[1], plansza.transform);
 
        int x1 = 4;
        int y1 = 2;
        temp1.setPostion(x1, y1);

        figuresTable[x1, y1] = temp1;
        int x = 2;
        int y = 2;
        temp.setPostion(x, y);
        temp.transform.localPosition = new Vector2(temp.postionOnBoard.Litera * 125, temp.postionOnBoard.Liczba * -125);
        temp.setImage();
        figuresTable[x, y] = temp;
        figuresTable[x, y].generateAvaibleMoves();

        Debug.Log("____________TUTAJ GONIEC____________");
        
        temp1.transform.localPosition = new Vector2(temp1.postionOnBoard.Litera * 125, temp1.postionOnBoard.Liczba * -125);
        temp1.setImage();
        figuresTable[x1, y1].generateAvaibleMoves();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
