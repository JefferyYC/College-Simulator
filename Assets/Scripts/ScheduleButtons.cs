using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleButtons : MonoBehaviour
{
  public GameObject TasksPanel;

  public GameObject Taskcard;

  public void SelectTask()
  {
    GameObject schedulePanel = GameObject.Find("SchedulePanel");
    ScheduleLayout schedulelayout = schedulePanel.GetComponent<ScheduleLayout>();
    if (schedulelayout.taskcount <= 7)
    {
      if (schedulelayout.taskcount == 7)
      {
        schedulelayout.taskcount = 1;
      }
      GameObject oldtask = schedulelayout.findEmpty(schedulelayout.taskcount);
      GameObject newtask = GameObject.Instantiate(Taskcard) as GameObject;

      newtask.transform.parent = oldtask.transform.parent;
      newtask.transform.rotation = oldtask.transform.rotation;
      newtask.transform.position = oldtask.transform.position;
      newtask.transform.localScale = oldtask.transform.localScale;
      newtask.transform.name = "NewTask" + schedulelayout.taskcount;
      schedulelayout.taskcount ++;
    }
  }
}
