
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    /*TO DO:
        -napraviti raycast skakanje
        -da bude skakanje uvjek isto
        -? dodati još neke kosti da prate kretnju
     */
    [SerializeField] private string tagName;

    [SerializeField] private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
        playerController.isGrounded = true;
        Debug.Log("Sent IsGrounded");
        }
    }
}
