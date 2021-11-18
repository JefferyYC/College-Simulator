using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject emptyTask;
    public LevelLoader levelManager;
    List<GameObject> scheduledTasks;
    ScheduleLayout scheduleLayout;
    GameManager gmScript;
    Text description;
    Image taskImage;
    int taskPointer;
    Task curTask;

    // Start is called before the first frame update
    void Start()
    {
        GameObject schedulePanel = GameObject.Find("SchedulePanel");
        scheduleLayout = schedulePanel.GetComponent<ScheduleLayout>();
        scheduledTasks = scheduleLayout.scheduledTasks;
        GameObject gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();


        if (levelManager != null)
        {
            Debug.Log("It is not null");
        }

        description = GetComponentInChildren<Text>();

        taskImage = transform.GetChild(0).GetComponent<Image>();

        taskPointer = 0;

        curTask = scheduledTasks[taskPointer].GetComponent<Task>();

        description.text = curTask.description;

        taskImage.sprite = curTask.taskImage;

    }


    void OnEnable()
    {
        // Initialize the transition scene with the first task on each new turn
        curTask = scheduledTasks[taskPointer].GetComponent<Task>();
        description.text = curTask.description;
        taskImage.sprite = curTask.taskImage;
    }

    // Update is called once per frame
    void Update()
    {
        //if 2 turns, goes to next scene

        // On a click, the attributes updates based on the current task listed on the transition scene
        // And then the transition scene's text transits the the next task
        // If there is no more next task, transition scence closes
        if (Input.GetMouseButtonDown(0))
        {
            GameObject oldtask = scheduledTasks[taskPointer];
            GameObject newtask = GameObject.Instantiate(emptyTask) as GameObject;
            scheduledTasks[taskPointer] = newtask;
            taskPointer += 1;

            curTask = oldtask.GetComponent<Task>();
            description.text = curTask.description;
            taskImage.sprite = curTask.taskImage;
            gmScript.industry += curTask.industry;
            gmScript.academic += curTask.academic;
            gmScript.social += curTask.social;
            gmScript.health += curTask.health;
            gmScript.stress += curTask.stress;


            if (taskPointer >= scheduledTasks.Count)
            {
                Panel.SetActive(false);
                scheduleLayout.taskcount = 1;
                //gmScript.turn += 1;
                taskPointer = 0;
                if (gmScript.turn == 8)
                {
                    levelManager.LoadGraduation();
                }
                else if (gmScript.turn > 0 && gmScript.turn % 2 == 0)
                {
                    levelManager.LoadNextLevel();
                }
                gmScript.turn += 1;
            }
            else
            {
                Task nextTask = scheduledTasks[taskPointer].GetComponent<Task>();
                description.text = nextTask.description;
                taskImage.sprite = nextTask.taskImage;
            }

            newtask.transform.parent = oldtask.transform.parent;
            newtask.transform.rotation = oldtask.transform.rotation;
            newtask.transform.position = oldtask.transform.position;
            newtask.transform.localScale = oldtask.transform.localScale;
            newtask.transform.name = "EmptyTask" + taskPointer;
            Destroy(oldtask);
        }
    }
}
