using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenButton : MonoBehaviour
{
    private Text myText;
    private Color myColor;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }


    public void OnMouseEnter()
    {
        myColor = new Color(236f / 255f, 92f / 255f, 92f / 255f);
        myText.text = "RESTART !!!";
        myText.color = myColor;
        Debug.Log("It entered");
    }

    public void OnMouseExit()
    {
        myText.color = Color.grey;
        myText.text = "RESTART >>>";
        Debug.Log("It exited");
    }

}
