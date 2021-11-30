using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskOptionControl : MonoBehaviour
{
    [SerializeField]
    private GameObject taskTemplate;
    [SerializeField]
    private GameObject boostedTaskTemplate;
    [SerializeField]
    private GameObject uniqueTaskTemplate;

    // Display name (the text shown on the task panel)
    private List<string> initialTaskDisplay = new List<string> { "Make Friend", "Nap", "Study", "Workout", "Coding", "Study Music Sheets", "Gaming" };
    // Tag (to access the task card objects)
    private List<string> initialTaskTag = new List<string> { "MakeFriendLv1", "NapLv1", "StudyLv1", "WorkoutLv1", "CodingLv1", "MusicLv1", "GamingLv1" };

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
        // If performed base action over 5 times, add boost action in the next turn and reset count
        if (gmScript.studyCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Intensive Study"));
            if (!initialTaskDisplay.Contains("Intensive Study"))
            {
                AddBoostedTask("Intensive Study", "StudyLv2", "Intensive Study Card");
                gmScript.studyCount = 0;
            }
        }
        else  // remove boost action after the turn it is added
        {
            if (initialTaskDisplay.Contains("Intensive Study"))
            {
                RemoveTask("Intensive Study", "StudyLv2", "Intensive Study Card");
            }
        }


        if (gmScript.socialCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Party"));
            if (!initialTaskDisplay.Contains("Party"))
            {
                AddBoostedTask("Party", "PartyLv2", "Party Card");
                gmScript.socialCount = 0;
            }
        }
        else
        {
            if (initialTaskDisplay.Contains("Party"))
            {
                RemoveTask("Party", "PartyLv2", "Party Card");
            }
        }

        if (gmScript.workoutCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Breaking PRs"));
            if (!initialTaskDisplay.Contains("Breaking PRs"))
            {
                AddBoostedTask("Breaking PRs", "WorkoutLv2", "Breaking PRs Card");
                gmScript.workoutCount = 0;
            }
        }
        else
        {
            if (initialTaskDisplay.Contains("Breaking PRs"))
            {
                RemoveTask("Breaking PRs", "WorkoutLv2", "Breaking PRs Card");
            }
        }

        if (gmScript.napCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Rest Day"));
            if (!initialTaskDisplay.Contains("Rest Day"))
            {
                AddBoostedTask("Rest Day", "RestLv2", "Rest Day Card");
                gmScript.napCount = 0;
            }
        }
        else
        {
            if (initialTaskDisplay.Contains("Rest Day"))
            {
                RemoveTask("Rest Day", "RestLv2", "Rest Day Card");
            }
        }

        if (gmScript.csCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Leetcode Grind"));
            if (!initialTaskDisplay.Contains("Leetcode Grind"))
            {
                AddBoostedTask("Leetcode Grind", "CodingLv2", "Leetcode Grind Card");
                gmScript.csCount = 0;
            }
        }
        else
        {
            if (initialTaskDisplay.Contains("Leetcode Grind"))
            {
                RemoveTask("Leetcode Grind", "CodingLv2", "Leetcode Grind Card");
            }
        }

        if (gmScript.gamingCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Rank Up In LOL"));
            if (!initialTaskDisplay.Contains("Rank Up In LOL"))
            {
                AddBoostedTask("Rank Up In LOL", "GamingLv2", "Rank Up In LOL Card");
                gmScript.gamingCount = 0;
            }
        }
        else
        {
            if (initialTaskDisplay.Contains("Rank Up In LOL"))
            {
                RemoveTask("Rank Up In LOL", "GamingLv2", "Rank Up In LOL Card");
            }
        }

        if (gmScript.musicCount >= 5)
        {
            StartCoroutine(NotifyUnlockBoost("Play Like Mozart"));
            if (!initialTaskDisplay.Contains("Play Like Mozart"))
            {
                AddBoostedTask("Play Like Mozart", "MusicLv2", "Play Like Mozart Card");
                gmScript.musicCount = 0;
            }
        }
        else
        {
            if (initialTaskDisplay.Contains("Play Like Mozart"))
            {
                RemoveTask("Play Like Mozart", "MusicLv2", "Play Like Mozart Card");
            }
        }
    }

    // Add a task card to task panel
    void AddBoostedTask(string display, string taskTag, string cardTag)
    {
            GameObject newTask = Instantiate(boostedTaskTemplate) as GameObject;
            newTask.gameObject.tag = cardTag;
            newTask.SetActive(true);
            newTask.transform.SetParent(this.transform, false);
            newTask.GetComponent<TaskCardButton>().setTaskCard(GameObject.FindGameObjectWithTag(taskTag));
            newTask.GetComponent<TaskCardButton>().setText(display);
            initialTaskDisplay.Add(display);
            initialTaskTag.Add(taskTag);
    }

    void RemoveTask(string display, string taskTag, string cardTag)
    {
        Destroy(GameObject.FindWithTag(cardTag));
        initialTaskDisplay.Remove(display);
        initialTaskTag.Remove(taskTag);
    }

    // A pop up text that notifies players updates in available tasks, disappear after 1f
    IEnumerator NotifyUnlockBoost(string s)
    {
        notifyText.text = "Unlock Boost: " + s;
        yield return new WaitForSeconds(1f);
        notifyText.text = "";
    }
}
