using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActButton : MonoBehaviour
{
    public GameObject TransitionPanel;

    public GameObject TaskPanel;

    public GameObject emptyTask;

    public void OpenPanel()
    {
        TaskPanel.SetActive(false);
        if (TransitionPanel != null)
        {
            TransitionPanel.SetActive(true);
        }
    }

    // public void ResetSchedule()
    // {
    //   int count = 6;
    //   GameObject schedulePanel = GameObject.Find("SchedulePanel");
    //   ScheduleLayout schedulelayout = schedulePanel.GetComponent<ScheduleLayout>();
    //   while (count > 0)
    //   {
    //     GameObject oldtask = schedulelayout.scheduledTasks[count - 1];
    //     GameObject newtask = GameObject.Instantiate(emptyTask) as GameObject;
    //     schedulelayout.scheduledTasks[count - 1] = newtask;
    //
    //     newtask.transform.parent = oldtask.transform.parent;
    //     newtask.transform.rotation = oldtask.transform.rotation;
    //     newtask.transform.position = oldtask.transform.position;
    //     newtask.transform.localScale = oldtask.transform.localScale;
    //     newtask.transform.name = "EmptyTask" + schedulelayout.taskcount;
    //     schedulelayout.taskcount ++;
    //     Destroy(oldtask);
    //     count--;
    //   }
    // }
}
