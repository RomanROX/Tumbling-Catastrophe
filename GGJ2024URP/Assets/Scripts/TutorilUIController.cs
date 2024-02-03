using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorilUIController : MonoBehaviour
{
    [SerializeField] GameObject UIObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIObject.SetActive(false);
        }
    }
}
