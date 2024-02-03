using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public void PTutorial()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void STutorial()
    {
        SceneManager.LoadScene(2);

    }
}
