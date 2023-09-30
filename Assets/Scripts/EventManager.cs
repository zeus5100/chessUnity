using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public Button copyPositionButton;

    public Button openLoadPositionButton;
    public Button closeLoadPositionButton;
    public Button loadPositionButton;
    public TMP_InputField postionInput;

    //od wczytywania pozycji 

    public GameObject menuLoadPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition.onClick.AddListener(GameManager.generateStartPosition);
        clearButton.onClick.AddListener(GameManager.clearBoard);
        reversBoardButton.onClick.AddListener(GameManager.flipBoard);
        copyPositionButton.onClick.AddListener(GameManager.copyPositon);
        openLoadPositionButton.onClick.AddListener(showLoadPositionMenu);
        closeLoadPositionButton.onClick.AddListener(closeLoadPositionMenu);
        loadPositionButton.onClick.AddListener(readPositionFromInput);
    }

    public void readPositionFromInput()
    {
        string s = postionInput.text;
        closeLoadPositionMenu();
        GameManager.loadPosition(s);
    }

    public void showLoadPositionMenu()
    {
        menuLoadPosition.gameObject.SetActive(true);
    }

    public void closeLoadPositionMenu()
    {
        menuLoadPosition.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
