using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFigure : MonoBehaviour
{
    public enum Figury
    {
        Wieza,
        Goniec,
        Konik,
        Hetman,
        Krol,
        Pionek,
    }
    public Figury typ;
    public bool color = false;
    private Button choiceButton;
    // Start is called before the first frame update
    void Start()
    {
        choiceButton = GetComponent<Button>();
        choiceButton.onClick.AddListener(choiceFigure);
    }

    void choiceFigure()
    {
        GameManager.choiceFigureToCreate((int)typ, color);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
