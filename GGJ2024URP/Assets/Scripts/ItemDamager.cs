using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamager : MonoBehaviour
{
    //Rigidbody rb;

    [SerializeField] HealthSystem healthSystem;
    [SerializeField] float TimeBetweenPunches = 1f;
    float timer = 0;

    // Start is called before the first frame update
    void Start()

    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item") && Time.time >= timer + TimeBetweenPunches)
        {
            float damage = (float) Convert.ToInt32(other.GetComponent<Rigidbody>().velocity.magnitude);
            Debug.Log("item velocity: " + damage);
            healthSystem.DealDamage(damage);
            timer = Time.time;

            //if (other.TryGetComponent<PlayerHealthGrabber>(out PlayerHealthGrabber playerHealthGrabber))
            //{
            //    playerHealthGrabber.SendDamage(damage);
            //}
        }
    }
}
