using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class life : MonoBehaviour
{
    public GameObject[] milestones;
    company myCompany;
    Text description;
    Image myImage;
    int pointer;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        description = GetComponentInChildren<Text>();

        myImage = transform.GetChild(0).GetComponent<Image>();
        //get the correct result
        
        pointer = 0;
        level = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log(milestones[pointer].GetComponent<company>().description[pointer]);
            description.text = milestones[pointer].GetComponent<company>().description[level];
            myImage.sprite = milestones[pointer].GetComponent<company>().image[level];

            pointer = pointer + 1;

        }
    }
}
