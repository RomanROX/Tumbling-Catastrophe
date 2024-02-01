using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TExtHandler : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI tm;

    public void Piši(string a)
    {
        animator.SetBool("Reset", true);
        tm.text = a;
        StartCoroutine(fade());
    }


    public IEnumerator fade()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("Reset", false);
    }
}
