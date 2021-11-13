using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    public GameObject LifePanel;


    public void OpenPanel()
    {
        if (LifePanel != null)
        {
            LifePanel.SetActive(true);
        }
    }
}
