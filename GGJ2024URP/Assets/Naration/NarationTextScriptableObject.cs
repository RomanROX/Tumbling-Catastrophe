using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NarationTextSO", menuName = "ScriptableObjects/Naration", order = 0)]
public class NarationTextScriptableObject : ScriptableObject
{
    [Header("Data")]
    public AudioClip AudioSample;
    [TextArea(10, 90)]
    public string TextSample;
}
