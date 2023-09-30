using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventManager : MonoBehaviour
{
    //generate default position
    public Button startPosition;
    //wyczysc plansze
    public Button clearButton;
    // odwroc pozycje
    public Button reversBoardButton;
    // Start is called before the first frame update
    void Start()
    {
        startPosition.onClick.AddListener(GameManager.generateStartPosition);
        clearButton.onClick.AddListener(GameManager.clearBoard);
        reversBoardButton.onClick.AddListener(GameManager.flipBoard);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
