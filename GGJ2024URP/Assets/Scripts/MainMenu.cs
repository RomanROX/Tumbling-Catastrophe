using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public LevelLoaderScript LevelLoaderScript;
    public void GoToNextScene()
    {
        LevelLoaderScript.LoadNextLevelScene();
    }

    public void Setting()
    {
        Debug.Log("Setting!!!");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    
    
}
