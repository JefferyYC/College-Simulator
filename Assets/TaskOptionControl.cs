using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskOptionControl : MonoBehaviour
{
    [SerializeField]
    private GameObject taskTemplate;

    // Display name (the text shown on the task panel)
    private List<string> initialTaskDisplay = new List<string> { "Make Friend", "Nap", "Study" };
    // Tag (to access the task card objects)
    private List<string> initialTaskTag = new List<string> { "MakeFriendLv1", "NapLv1", "StudyLv1" };

    private GameManager gmScript;

    private Text notifyText;

    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        notifyText = GameObject.Find("NewTaskNotification").GetComponent<Text>();
        for (int i = 0; i < initialTaskTag.Count; i++)
        {
            GameObject newTask = Instantiate(taskTemplate) as GameObject;
            newTask.SetActive(true);
            newTask.transform.SetParent(this.transform, false);
            newTask.GetComponent<TaskCardButton>().setTaskCard(GameObject.FindGameObjectWithTag(initialTaskTag[i]));
            newTask.GetComponent<TaskCardButton>().setText(initialTaskDisplay[i]);
        }
    }

    void OnEnable()
    {
        //On enable, instantiate new tasks based on threshold.
        //Note that we should avoid instantiating a task multiple times.
        UpdateTask();
    }

    void UpdateTask()
    {
        if (gmScript.social >= 20)
        {
            if (!initialTaskDisplay.Contains("Party"))
            {
                GameObject newTask = Instantiate(taskTemplate) as GameObject;
                newTask.SetActive(true);
                newTask.transform.SetParent(this.transform, false);
                newTask.GetComponent<TaskCardButton>().setTaskCard(GameObject.FindGameObjectWithTag("PartyLv2"));
                newTask.GetComponent<TaskCardButton>().setText("Party");
                initialTaskDisplay.Add("Party");
                initialTaskTag.Add("PartyLv2");
                StartCoroutine(Notify("Party"));
            }
        }
    }

    // A pop up text that notifies players updates in available tasks, disappear after 1f
    IEnumerator Notify(string s)
    {
        notifyText.text = "You have learned a new skill: " + s;
        yield return new WaitForSeconds(1f);
        notifyText.text = "";
    }
}
