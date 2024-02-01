using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScena : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKey(KeyCode.Tab))  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
