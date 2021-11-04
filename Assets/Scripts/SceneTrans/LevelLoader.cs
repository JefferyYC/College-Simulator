using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    GameManager gmScript;
    

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation

        transition.SetTrigger("Start");
        GameObject gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        gmScript.semesterNum += 1;
        SceneManager.LoadScene(levelIndex);
        //Debug.Log("1111111111");
    }
}
