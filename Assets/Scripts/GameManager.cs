using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public float industry;
	public float academic;
	public float social;
	public float health;
	public float stress;

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
		UpdateUI();
	}

	// Update is called once per frame
	void UpdateUI()
	{
		industryText.text = "Industry: " + industry.ToString();
		academicText.text = "Academic: " + academic.ToString();
		socialText.text = "Social: " + social.ToString();
		healthText.text = "Health: " + health.ToString();
		stressText.text = "Stress: " + stress.ToString();
	}
}
