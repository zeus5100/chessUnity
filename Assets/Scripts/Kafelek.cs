using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kafelek : MonoBehaviour
{
    public Button pole;
    // Start is called before the first frame update
    void Start()
    {
        pole.onClick.AddListener(myPosition);
    }

    public void myPosition()
    {
        Vector2 poz = gameObject.transform.localPosition;
        int pozX = (int)(poz.x + 500) / 125;
        int pozY = (int)(-1 * poz.y + 500) / 125;
        GameManager.addFigure(pozX, pozY);
        //Debug.Log("Moja pozycja to: " + pozX + ", " + pozY);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
