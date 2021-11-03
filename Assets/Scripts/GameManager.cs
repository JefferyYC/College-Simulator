using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager;
	public int industry;
	public int academic;
	public int social;
	public int health;
	public int stress;

	public int turn = 1;
	public GameObject turnTextObject;
	private Text turnText;

	public int semesterNum = 0;
	public string[] semesters = { "Freshmen", "Sophmore", "Junior", "Senior", "Graduated" };
	public GameObject semesterTextObject;
	private Text semesterText;

	public GameObject industryObject;
    private TextMeshProUGUI industryText;

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
		gameManager = this;
		industryText = industryObject.GetComponent<TextMeshProUGUI>();
		academicText = academicObject.GetComponent<TextMeshProUGUI>();
		socialText = socialObject.GetComponent<TextMeshProUGUI>();
		healthText = healthObject.GetComponent<TextMeshProUGUI>();
		stressText = stressObject.GetComponent<TextMeshProUGUI>();
		turnText = turnTextObject.GetComponent<Text>();
		semesterText = semesterTextObject.GetComponent<Text>();
		UpdateUI();
	}

	void UpdateUI()
	{
		Debug.Log(turn);
		Debug.Log(turnText.text);
		industryText.text = "Industry: " + industry.ToString();
		academicText.text = "Academic: " + academic.ToString();
		socialText.text = "Social: " + social.ToString();
		healthText.text = "Health: " + health.ToString();
		stressText.text = "Stress: " + stress.ToString();
		turnText.text = "Turn: " + turn.ToString();
		semesterText.text = "Year: " + semesters[semesterNum];
	}

	// Update is called once per frame
	void Update()
    {
		UpdateUI();
    }
}
