using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private Text myText;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }


    public void OnMouseEnter()
    {
        myText.color = Color.white;
        Debug.Log("It entered");
    }

    public void OnMouseExit()
    {
        myText.color = Color.black;
        Debug.Log("It exited");
    }


    public void Restart()
    {
        SceneManager.LoadScene("MasterScene");
    }
}
