using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    public Button moveButton;
    void Start()
    {
        moveButton = GetComponent<Button>();
        moveButton.onClick.AddListener(moveFigure);
    }

    void moveFigure()
    {
        Vector2 position = gameObject.transform.localPosition;
        int positionX = (int)(position.x) / 125;
        int positionY = (int)(position.y) / -125;
        GameManager.moveFigure(positionX, positionY);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
