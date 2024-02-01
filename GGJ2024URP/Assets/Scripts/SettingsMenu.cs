using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public GameObject Target;
    public AudioMixer audMix;

    public void SetVolume (float volume)
    {
        audMix.SetFloat("volume", volume);
    }

    public void setQuality (int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Target.activeSelf == false)
        {
            Target.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && Target.activeSelf == true)
        {
            Target.SetActive(false);
        }
        if (Target.gameObject.activeSelf == false)
        {
            Time.timeScale = 1.0f;
        }
    }
}
