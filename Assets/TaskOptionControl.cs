using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskOptionControl : MonoBehaviour
{
    [SerializeField]
    private GameObject taskTemplate;

    // Display name (the text shown on the task panel)
    private List<string> initialTaskDisplay = new List<string> { "Make Friend", "Nap", "Study" };
    // Tag (to access the task card objects)
    private List<string> initialTaskTag = new List<string> { "MakeFriendsTask", "NapTask", "StudyTask" };
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialTaskTag.Count; i++)
        {
            GameObject newTask = Instantiate(taskTemplate) as GameObject;
            newTask.SetActive(true);
            newTask.transform.SetParent(this.transform, false);
            newTask.GetComponent<TaskCardButton>().setTaskCard(GameObject.FindGameObjectWithTag(initialTaskTag[i]));
            newTask.GetComponent<TaskCardButton>().setText(initialTaskDisplay[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
