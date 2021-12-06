using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class life : MonoBehaviour
{
    #region Data Varaibles
    private int academic;
    private int social;
    private int health;
    private int stress;
    private int cs;
    private int music;
    private int gaming;
    #endregion

    private int highest;
    private int highest_index;

    public GameObject nameFilter;
    public Text name;

    private List<int> LevelList = new List<int> {};

    public GameObject[] milestones;
    company myCompany;
    Text description;
    Image myImage;
    int pointer;
    int level;

    #region Get Data
    private void Awake()
    {
        #region Get data stored in the PlayerPref
        if (PlayerPrefs.HasKey("academic"))
        {
            academic = PlayerPrefs.GetInt("academic");
        }

        if (PlayerPrefs.HasKey("social"))
        {
            social = PlayerPrefs.GetInt("social");
        }

        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetInt("health");
        }

        if (PlayerPrefs.HasKey("stress"))
        {
            stress = PlayerPrefs.GetInt("stress");
        }

        if (PlayerPrefs.HasKey("cs"))
        {
            cs = PlayerPrefs.GetInt("cs");
        }

        if (PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetInt("music");
        }

        if (PlayerPrefs.HasKey("gaming"))
        {
            gaming = PlayerPrefs.GetInt("gaming");
        }

        if (PlayerPrefs.HasKey("name"))
        {
            name.text = PlayerPrefs.GetString("name");
            Debug.Log("I have a name");
        }

        #endregion
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        description = GetComponentInChildren<Text>();

        myImage = transform.GetChild(0).GetComponent<Image>();
        //get the correct result

        //pointer points to different results [academic, social, health ......]
        Debug.Log("----");
        Debug.Log(academic);
        Debug.Log("----");
        pointer = 0;
        SetLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nameFilter.SetActive(false);
            //SetLevel Function to set level
            level = LevelList[pointer];
            if (pointer < 5)
            {
                if (pointer == 4)
                {
                    pointer = highest_index;
                    Debug.Log(pointer);
                    Debug.Log(music);
                }
                
                description.text = milestones[pointer].GetComponent<company>().description[level];
                myImage.sprite = milestones[pointer].GetComponent<company>().image[level];
                pointer = pointer + 1;
            }
        }
    }
    void SetLevel()
    {
        //
        
        if (academic < 100)
        {
            // Index respective "possible_______" array, and put the indexed component into the YourFuture array.
            // Pesudo-code
            LevelList.Add(0);
            

        }
        else if (academic >= 100 && academic < 200)
        {
            LevelList.Add(1);
            Debug.Log("HERE");
        }
        else
        {
            LevelList.Add(2);
        }

        

        if (social < 100)
        {
            LevelList.Add(0);
        }
        else if (social >= 100 && social < 200)
        {
            LevelList.Add(1);
        }
        else
        {
            LevelList.Add(2);
        }

        if (health < 100)
        {
            LevelList.Add(0);
        }
        else if (health >= 100 && health < 200)
        {
            LevelList.Add(1);
        }
        else
        {
            LevelList.Add(2);
        }

        if (stress > -100)
        {
            LevelList.Add(0);

        }
        else if (stress < -100 && stress > -200)
        {
            LevelList.Add(1);
        }
        else if (stress <= -200)
        {
            LevelList.Add(2);
        }

        if (cs > music)
        {
            highest = cs;
            highest_index = 4;

        } else
        {
            highest = music;
            highest_index = 5;
            
        }

        if (highest < gaming)
        {
            highest = gaming;
            highest_index = 6;
            
        }

        if (highest < 100)
        {
            LevelList.Add(0);
        }
        else if (highest >= 100 && highest < 200)
        {
            LevelList.Add(1);
        } else
        {
            LevelList.Add(2);
        }
        
    }
}

