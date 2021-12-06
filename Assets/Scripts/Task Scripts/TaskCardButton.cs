using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script defines behaviours for clicking a task card in the task panel
public class TaskCardButton : MonoBehaviour
{
    [SerializeField]
    private GameObject TasksPanel;

    [SerializeField]
    private GameObject Taskcard;

    public GameObject ActButton;

    public void setTaskCard(GameObject taskcard)
    {
        Taskcard = taskcard;
    }

    public void setText(string s)
    {
        this.GetComponentInChildren<Text>().text = s;
    }

    public void SelectTask()
    {
        GameObject schedulePanel = GameObject.Find("SchedulePanel");
        GameObject actButton = FindInActiveObjectByName("ActionButton");
        ScheduleLayout schedulelayout = schedulePanel.GetComponent<ScheduleLayout>();
        Debug.Log(actButton);
        if (schedulelayout.taskcount <= 7)
        {
            if (schedulelayout.taskcount == 6)
            {
                actButton.SetActive(true);
            }

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

    public void SelectTaskThenDestroy()
    {
        SelectTask();
        Destroy(gameObject);
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
