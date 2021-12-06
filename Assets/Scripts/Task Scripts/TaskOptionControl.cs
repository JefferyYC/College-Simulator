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
    private List<string> initialTaskDisplay = new List<string> { "Make Friend", "Nap", "Study", "Workout", "Coding", "Practice Music", "Gaming" };
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
        if (gmScript.studyCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Intensive Study"));
            AddBoostedTask("Intensive Study", "StudyLv2");
            gmScript.studyCount = 0;
        }

        if (gmScript.socialCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Party"));
            AddBoostedTask("Party", "PartyLv2");
            gmScript.socialCount = 0;
        }

        if (gmScript.workoutCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Breaking PRs"));
            AddBoostedTask("Breaking PRs", "WorkoutLv2");
            gmScript.workoutCount = 0;
        }

        if (gmScript.napCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Rest Day"));
            AddBoostedTask("Rest Day", "RestLv2");
            gmScript.napCount = 0;
        }

        if (gmScript.csCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Leetcode Grind"));
            AddBoostedTask("Leetcode Grind", "CodingLv2");
            gmScript.csCount = 0;
        }

        if (gmScript.gamingCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Rank Up In LOL"));
            AddBoostedTask("Rank Up In LOL", "GamingLv2");
            gmScript.gamingCount -= 5;
        }

        if (gmScript.musicCount >= 3)
        {
            StartCoroutine(NotifyUnlockBoost("Play Like Mozart"));
            AddBoostedTask("Play Like Mozart", "MusicLv2");
            gmScript.musicCount = 0;
        }

        if (gmScript.academic >= 100)
        {
            if (!initialTaskDisplay.Contains("Join Research"))
            {
                StartCoroutine(NotifyUnlockUnique("Join Research"));
                AddUniqueTask("Join Research", "StudyLv3");
            }
        }

        if (gmScript.academic >= 175)
        {
            if (!initialTaskDisplay.Contains("Publish a Paper"))
            {
                StartCoroutine(NotifyUnlockUnique("Publish a Paper"));
                AddUniqueTask("Publish a Paper", "StudyLv4");
            }
        }

        if (gmScript.social >= 100)
        {
            if (!initialTaskDisplay.Contains("Become Club Leader"))
            {
                StartCoroutine(NotifyUnlockUnique("Become Club Leader"));
                AddUniqueTask("Become Club Leader", "SocialLv3");
            }
        }

        if (gmScript.social >= 175)
        {
            if (!initialTaskDisplay.Contains("Dating"))
            {
                StartCoroutine(NotifyUnlockUnique("Dating"));
                AddUniqueTask("Dating", "SocialLv4");
            }
        }

        if (gmScript.health >= 100)
        {
            if (!initialTaskDisplay.Contains("Join Football Team"))
            {
                StartCoroutine(NotifyUnlockUnique("Join Football Team"));
                AddUniqueTask("Join Football Team", "WorkoutLv3");
            }
        }

        if (gmScript.health >= 175)
        {
            if (!initialTaskDisplay.Contains("Win Big Game"))
            {
                StartCoroutine(NotifyUnlockUnique("Win Big Game"));
                AddUniqueTask("Win Big Game", "WorkoutLv4");
            }
        }

        if (gmScript.stress <= -100)
        {
            if (!initialTaskDisplay.Contains("Travel to Japan"))
            {
                StartCoroutine(NotifyUnlockUnique("Travel to Japan"));
                AddUniqueTask("Travel to Japan", "RestLv3");
            }
        }

        if (gmScript.stress <= -175)
        {
            if (!initialTaskDisplay.Contains("Naked Run"))
            {
                StartCoroutine(NotifyUnlockUnique("Naked Run"));
                AddUniqueTask("Naked Run", "RestLv4");
            }
        }

        if (gmScript.cs >= 100)
        {
            if (!initialTaskDisplay.Contains("Hackathon"))
            {
                StartCoroutine(NotifyUnlockUnique("Hackathon"));
                AddUniqueTask("Hackathon", "CodingLv3");
            }
        }

        if (gmScript.cs >= 200)
        {
            if (!initialTaskDisplay.Contains("SWE Internship"))
            {
                StartCoroutine(NotifyUnlockUnique("SWE Internship"));
                AddUniqueTask("SWE Internship", "CodingLv4");
            }
        }

        if (gmScript.music >= 100)
        {
            if (!initialTaskDisplay.Contains("Perform at Concert"))
            {
                StartCoroutine(NotifyUnlockUnique("Perform at Concert"));
                AddUniqueTask("Perform at Concert", "MusicLv3");
            }
        }

        if (gmScript.music >= 200)
        {
            if (!initialTaskDisplay.Contains("Release an Album"))
            {
                StartCoroutine(NotifyUnlockUnique("Release an Album"));
                AddUniqueTask("Release an Album", "MusicLv4");
            }
        }

        if (gmScript.gaming >= 100)
        {
            if (!initialTaskDisplay.Contains("Top 100 Player"))  // never removed this from list, so only shows once
            {
                StartCoroutine(NotifyUnlockUnique("Top 100 Player"));
                AddUniqueTask("Top 100 Player", "GamingLv3");
            }
        }

        if (gmScript.gaming >= 200)
        {
            if (!initialTaskDisplay.Contains("Collegiate Champion"))
            {
                StartCoroutine(NotifyUnlockUnique("Collegiate Champion"));
                AddUniqueTask("Collegiate Champion", "GamingLv4");
            }
        }
    }

    // Add a boosted task card to task panel
    void AddBoostedTask(string display, string taskTag)
    {
        GameObject newTask = Instantiate(boostedTaskTemplate) as GameObject;
        newTask.SetActive(true);
        newTask.transform.SetParent(this.transform, false);
        newTask.GetComponent<TaskCardButton>().setTaskCard(GameObject.FindGameObjectWithTag(taskTag));
        newTask.GetComponent<TaskCardButton>().setText(display);
        initialTaskDisplay.Add(display);
        initialTaskTag.Add(taskTag);
    }

    // Add a unique task card to task panel
    void AddUniqueTask(string display, string taskTag)
    {
        GameObject newTask = Instantiate(uniqueTaskTemplate) as GameObject;
        newTask.SetActive(true);
        newTask.transform.SetParent(this.transform, false);
        newTask.GetComponent<TaskCardButton>().setTaskCard(GameObject.FindGameObjectWithTag(taskTag));
        newTask.GetComponent<TaskCardButton>().setText(display);
        initialTaskDisplay.Add(display);
        initialTaskTag.Add(taskTag);
    }

    // A pop up text that notifies players unlock boosted tasks, disappear after 1f
    IEnumerator NotifyUnlockBoost(string s)
    {
        notifyText.text = "Unlock Boost: " + s;
        yield return new WaitForSeconds(1f);
        notifyText.text = "";
    }

    // A pop up text that notifies players unlock unique tasks, disappear after 1f
    IEnumerator NotifyUnlockUnique(string s)
    {
        notifyText.text = "Unlock Unique Action: " + s;
        yield return new WaitForSeconds(1f);
        notifyText.text = "";
    }
}
