using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public Vector3 RayShot;
    public float RayLenght;

    Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {        
        //Debug.Log(Rigidbody.velocity.magnitude);


        RaycastHit hit;
        
        Debug.DrawRay(transform.position, transform.right, Color.red);
        if (Physics.Raycast(transform.position, transform.right, out hit) && hit.collider.gameObject.CompareTag("Ground") && Rigidbody.velocity.magnitude <= 0.1)        {
                RolledSix();            
        }
    }

    void RolledSix()
    {
        Debug.Log("Rolled Six");
    }
}
