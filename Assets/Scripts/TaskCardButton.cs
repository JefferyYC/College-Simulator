using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script defines behaviours for clicking a task card in the task panel
public class TaskCardButton : MonoBehaviour
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

      GameObject oldtask = schedulelayout.scheduledTasks[schedulelayout.taskcount - 1];
      GameObject newtask = GameObject.Instantiate(Taskcard) as GameObject;
      schedulelayout.scheduledTasks[schedulelayout.taskcount - 1] = newtask;

      newtask.transform.parent = oldtask.transform.parent;
      newtask.transform.rotation = oldtask.transform.rotation;
      newtask.transform.position = oldtask.transform.position;
      newtask.transform.localScale = oldtask.transform.localScale;
      newtask.transform.name = "NewTask" + schedulelayout.taskcount;
      schedulelayout.taskcount ++;
      Destroy(oldtask);
    }
  }
}
