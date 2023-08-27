using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextsCanvas : MonoBehaviour
{
    public Text myText;
    public Button myButton;
    public Text myButtonText;

    private void Start()
    {
        NextText();
    }
    public void CompleteText()
    {
        myButton.GetComponent<Image>().color = Color.blue;
        myButtonText.text = "완료";
    }
    public void NextText()
    {
        myButton.GetComponent<Image>().color = Color.green;
        myButtonText.text = "다음";
    }
}
