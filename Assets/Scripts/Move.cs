using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    private Button moveButton; 
    void Start()
    {
        moveButton = GetComponent<Button>();
        moveButton.onClick.AddListener(moveFigure);
    }

    void moveFigure()
    {
        Vector2 position = gameObject.transform.localPosition;
        Vector2 figurePosition = gameObject.transform.parent.parent.localPosition;
        int positionX = (int)(position.x + figurePosition.x) / 125;
        int positionY = (int)(position.y + figurePosition.y) / -125;
        int figureX = (int)figurePosition.x / 125;
        int figureY = (int)figurePosition.y / -125;

        GameManager.moveFigure(figureX,figureY, positionX, positionY);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
