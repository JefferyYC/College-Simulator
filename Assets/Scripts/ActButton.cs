using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActButton : MonoBehaviour
{
    public void updateStats()
    {
        GameObject schedulePanel = GameObject.Find("SchedulePanel");
        ScheduleLayout schedulelayout = schedulePanel.GetComponent<ScheduleLayout>();
        GameObject gm = GameObject.Find("GameManager");
        GameManager gmScript = gm.GetComponent<GameManager>();

        for (int i=0; i<schedulelayout.scheduledTasks.Count; i++)
        {
            Task task = schedulelayout.scheduledTasks[i].GetComponent<Task>();
            gmScript.industry += task.industry;
            gmScript.academic += task.academic;
            gmScript.social += task.social;
            gmScript.health += task.health;
            gmScript.stress += task.stress;
        }
    }
}
