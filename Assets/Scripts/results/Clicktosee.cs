using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicktosee : MonoBehaviour
{
    private Text myText;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }


    public void OnMouseEnter()
    {
        myText.text = ">>> JUST CLICK <<<";
        Debug.Log("It entered");
    }

    public void OnMouseExit()
    {
        myText.text = ">>> CLICK TO SEE MORE <<<";
        Debug.Log("It exited");
    }
}
