using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

    [SerializeField] float playerSpeed;
    [SerializeField] float strafeSpeed;
    [SerializeField] float jumpForce;

    private Rigidbody HipsRigidbody;
    public bool isGrounded;
    void Start()
    {
        HipsRigidbody = GetComponent<Rigidbody>();
    }

    //hips je rotiran za 180
    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                HipsRigidbody.AddForce(-HipsRigidbody.transform.forward * playerSpeed * 1.5f);
            }
            else
            {
                HipsRigidbody.AddForce(-HipsRigidbody.transform.forward * playerSpeed);
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            HipsRigidbody.AddForce(HipsRigidbody.transform.right * strafeSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            HipsRigidbody.AddForce(-HipsRigidbody.transform.right * strafeSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            HipsRigidbody.AddForce(HipsRigidbody.transform.forward * playerSpeed);
        }


        if(Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                HipsRigidbody.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
