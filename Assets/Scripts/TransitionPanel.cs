using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPanel : MonoBehaviour
{
    public GameObject Panel;
    List<GameObject> scheduledTasks;
    GameManager gmScript;
    Text description;
    int taskPointer;
    Task curTask;
    // Start is called before the first frame update
    void Start()
    {
        GameObject schedulePanel = GameObject.Find("SchedulePanel");
        scheduledTasks = schedulePanel.GetComponent<ScheduleLayout>().scheduledTasks;
        GameObject gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();

        description = GetComponentInChildren<Text>();

        taskPointer = 0;

        curTask = scheduledTasks[taskPointer].GetComponent<Task>();


        description.text = curTask.description;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            taskPointer += 1;
            if (taskPointer >= scheduledTasks.Count)
            {
                Panel.SetActive(false);
                gmScript.turn += 1;
                taskPointer = 0;
            }
            else
            {
                curTask = scheduledTasks[taskPointer].GetComponent<Task>();
                description.text = curTask.description;
                gmScript.industry += curTask.industry;
                gmScript.academic += curTask.academic;
                gmScript.social += curTask.social;
                gmScript.health += curTask.health;
                gmScript.stress += curTask.stress;
            }
        }
    }
}
