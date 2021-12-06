using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;
    //ScoreManager is only used in the ending scene.

    //region for all the scores to track
    #region Private Variables
    private int academic;
    private int social;
    private int health;
    private int stress;
    private int cs;
    private int music;
    private int gaming;
    #endregion

    /*
    #region Initialziation
    private void Awake()
    {
        #region Get data stored in the PlayerPref
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.HasKey("academic"))
        {
            academic = PlayerPrefs.GetInt("academic");
            Debug.Log(academic);
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
            academic = PlayerPrefs.GetInt("music");
        }

        if (PlayerPrefs.HasKey("gaming"))
        {
            academic = PlayerPrefs.GetInt("gaming");
        }
        #endregion
    }
    #endregion

    */

    public void Restart()
    {
        SceneManager.LoadScene("Start");

        //when restart, also reset the scores stored in playerprefs
        PlayerPrefs.SetInt("academic", 0);
        PlayerPrefs.SetInt("social", 0);
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.SetInt("stress", 0);
        PlayerPrefs.SetInt("cs", 0);
        PlayerPrefs.SetInt("music", 0);
        PlayerPrefs.SetInt("gaming", 0);
    }
}
