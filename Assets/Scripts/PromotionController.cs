using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromotionController : MonoBehaviour
{
    public GameObject blackFigures;
    public GameObject whiteFigures;
    public static GameObject staticBlackFigures;
    public static GameObject staticWhiteFigures;
    public static int x;
    public static int y;

    
    public static void choosedWhite()
    {
        staticWhiteFigures.SetActive(true);
        staticBlackFigures.SetActive(false);
    }

    public static void choosedBlack()
    {
        staticBlackFigures.SetActive(true);
        staticWhiteFigures.SetActive(false);    
    }

    // Start is called before the first frame update
    void Start()
    {
        staticBlackFigures = blackFigures;
        staticWhiteFigures = whiteFigures;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
