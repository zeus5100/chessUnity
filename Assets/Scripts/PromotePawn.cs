using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromotePawn : MonoBehaviour
{
    public enum Figury
    {
        Wie¿a,
        Goniec,
        Konik,
        Hetman,
        Król,
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
        GameManager.replaceFigure(color, (int)typ);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
