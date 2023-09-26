using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovePrefab : MonoBehaviour
{
    public TextMeshProUGUI moveCount;
    public TextMeshProUGUI whiteMove;
    public TextMeshProUGUI blackMove;
    // Start is called before the first frame update
    void Start()
    {
        blackMove.text = "";
    }

    public void setMoveCount(int x)
    {
        moveCount.text = x.ToString();

    }
    public void setWhiteMove(string x)
    {
        whiteMove.text = x.ToString();
    }
    public void setBlackMove(string x)
    {
        blackMove.text = x.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
