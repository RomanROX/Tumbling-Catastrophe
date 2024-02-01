using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public GameObject Target;
    //public AudioMixer audMix;

    //public void SetVolume (float volume)
    //{
    //    audMix.SetFloat("volume", volume);
    //}

    public void setQuality ()
    {
        setGraphics();
        Debug.Log("calling");
    }

    void setGraphics()
    {
        int value = Target.GetComponent<TMP_Dropdown>().value;
        QualitySettings.SetQualityLevel(value);
        Debug.Log(value);
    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape) && Target.activeSelf == false)
    //    {
    //        Target.SetActive(true);
    //        Time.timeScale = 0.0f;
    //    }

    //    else if(Input.GetKeyDown(KeyCode.Escape) && Target.activeSelf == true)
    //    {
    //        Target.SetActive(false);
    //    }
    //    if (Target.gameObject.activeSelf == false)
    //    {
    //        Time.timeScale = 1.0f;
    //    }
    //}
}
