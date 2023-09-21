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
        Figure temp = Instantiate(avaibleFigures[4], plansza.transform);
        Figure temp1 = Instantiate(avaibleFigures[1], plansza.transform);
        Figure temp2 = Instantiate(avaibleFigures[2], plansza.transform);
        Figure temp3 = Instantiate(avaibleFigures[3], plansza.transform);
        Figure temp4 = Instantiate(avaibleFigures[5], plansza.transform);

        figuresTable[2, 5] = temp3;
        temp3.setPostion(2, 5);
        temp3.transform.localPosition = new Vector2(temp3.positionOnBoard.Litera * 125, temp3.positionOnBoard.Liczba * -125);
        temp3.setImage();
        figuresTable[6, 5] = temp4;
        temp4.setPostion(5, 5);
        temp4.setColor(false);
        temp4.transform.localPosition = new Vector2(temp4.positionOnBoard.Litera * 125, temp4.positionOnBoard.Liczba * -125);
        temp4.setImage();


        figuresTable[6, 6] = temp2;
        temp2.setPostion(6, 6);
        temp2.transform.localPosition = new Vector2(temp2.positionOnBoard.Litera * 125, temp2.positionOnBoard.Liczba * -125);
        temp2.setColor(false);
        temp2.setImage();
        
        int x1 = 5;
        int y1 = 2;
        temp1.setPostion(x1, y1);
        temp1.setColor(false);
        figuresTable[x1, y1] = temp1;
        int x = 2;
        int y = 2;
        temp.setPostion(x, y);
        temp.transform.localPosition = new Vector2(temp.positionOnBoard.Litera * 125, temp.positionOnBoard.Liczba * -125);
        temp.setImage();
        figuresTable[x, y] = temp;
        figuresTable[x, y].generateAvaibleMoves();
        
        temp1.transform.localPosition = new Vector2(temp1.positionOnBoard.Litera * 125, temp1.positionOnBoard.Liczba * -125);
        temp1.setImage();
        figuresTable[6, 6].generateAvaibleMoves();
        figuresTable[x1, y1].generateAvaibleMoves();
        figuresTable[2, 5].generateAvaibleMoves();

        figuresTable[6, 5].generateAvaibleMoves();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
