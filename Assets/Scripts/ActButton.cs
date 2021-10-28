using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActButton : MonoBehaviour
{
    public GameObject TransitionPanel;

    public void OpenPanel()
    {
        if (TransitionPanel != null)
        {
            TransitionPanel.SetActive(true);
        }
    }
}
