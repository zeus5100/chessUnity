using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonsLogic : MonoBehaviour
{
    public Button przycisk;
    public TextMeshProUGUI text1;
    public GameObject kwadracik;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        przycisk.onClick.AddListener(ClickButton);
    }
    public void ClickButton()
    {
        score++;
        text1.text = score.ToString();
        kwadracik.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
