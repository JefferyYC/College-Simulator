using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 1f;

    GameManager gmScript;
    
    public void LoadGraduation()
    {
        StartCoroutine(GraduationTransition());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        this.transform.Find("TransitionImage").gameObject.SetActive(true);
        GameObject gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();
        //Wait
        yield return new WaitForSeconds(transitionTime);
        this.transform.Find("TransitionImage").gameObject.SetActive(false);
        //Load Scene
        gmScript.semesterNum += 1;
        //Debug.Log("1111111111");
    }

    IEnumerator GraduationTransition()
    {
        this.transform.Find("TransitionImage").gameObject.SetActive(true);
        GameObject gm = GameObject.Find("GameManager");
        gmScript = gm.GetComponent<GameManager>();
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //this.transform.Find("TransitionImage").gameObject.SetActive(false);
        SceneManager.LoadScene("Scene5");
        //Load Scene
        gmScript.semesterNum += 1;
        //Debug.Log("1111111111");
    }
}
