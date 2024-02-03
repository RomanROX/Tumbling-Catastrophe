using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;

    public float transTime = 1f;

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        OnLevelWasLoaded();
    //    }   
    //}

    //start Corutine
    public void LoadNextLevelScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            StartCoroutine(LoadLevel(0));
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void CustomLoader(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    public void ReloadLevelScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelindex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(levelindex);
    }
}
