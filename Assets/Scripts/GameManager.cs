using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager;

    #region Private Score Variables
    public int academic;
	public int social;
	public int health;
	public int stress;
	public int cs;
	public int music;
	public int gaming;
    #endregion

    public int studyCount;
	public int socialCount;
	public int workoutCount;
	public int napCount;
	public int csCount;
	public int musicCount;
	public int gamingCount;

	public int turn = 1;
	public GameObject turnTextObject;
	private Text turnText;

	public int semesterNum = 0;
	public string[] semesters = { "Freshmen", "Sophmore", "Junior", "Senior", "Graduated" };
	public GameObject semesterTextObject;
	private Text semesterText;

	public GameObject academicObject;
	private TextMeshProUGUI academicText;

	public GameObject socialObject;
	private TextMeshProUGUI socialText;

	public GameObject healthObject;
	private TextMeshProUGUI healthText;

	public GameObject stressObject;
	private TextMeshProUGUI stressText;

	// Use this for initialization
	void Start()
	{
		//Debug.Log("hello");
		gameManager = this;
		academicText = academicObject.GetComponent<TextMeshProUGUI>();
		socialText = socialObject.GetComponent<TextMeshProUGUI>();
		healthText = healthObject.GetComponent<TextMeshProUGUI>();
		stressText = stressObject.GetComponent<TextMeshProUGUI>();
		turnText = turnTextObject.GetComponent<Text>();
		semesterText = semesterTextObject.GetComponent<Text>();
		UpdateUI();
	}

	private double academicNorm;
	private double socialNorm;
	private double healthNorm;
	private double stressNorm;

	void UpdateUI()
	{
		//Debug.Log(turn);
		//Debug.Log(turnText.text);
		academicNorm = (double) academic / 250.0 * 100;
		academicText.text = "Academic: " + academicNorm.ToString() + "%";
		socialNorm = (double) social / 250 * 100;

		socialText.text = "Social: " + socialNorm.ToString() + "%";
		healthNorm = (double) health / 250 * 100;
		healthText.text = "Health: " + healthNorm.ToString() + "%";
		stressNorm = (double) stress / 250 * 100;
		stressText.text = "Stress: " + stressNorm.ToString() + "%";
		turnText.text = "Turn: " + turn.ToString();
		semesterText.text = semesters[semesterNum];

		//use PlayerPrefs for data persistency to store data across game sessions
		PlayerPrefs.SetInt("academic", academic);
		PlayerPrefs.SetInt("social", social);
		PlayerPrefs.SetInt("health", health);
		PlayerPrefs.SetInt("stress", stress);
		PlayerPrefs.SetInt("cs", cs);
		PlayerPrefs.SetInt("music", music);
		PlayerPrefs.SetInt("gaming", gaming);
	}

	// Update is called once per frame
	void Update()
    {
		UpdateUI();
    }
}
