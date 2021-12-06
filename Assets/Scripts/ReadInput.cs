using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{

    private string input;
    

    public void ReadInputField(string s)
    {
        input = s;
        PlayerPrefs.SetString("name", input);
        Debug.Log(input);
    }
}
