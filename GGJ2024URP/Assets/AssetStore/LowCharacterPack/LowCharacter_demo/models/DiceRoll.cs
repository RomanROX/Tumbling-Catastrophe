using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        Debug.DrawRay(transform.position, transform.right, Color.red, RayLenght);
        if (Physics.Raycast(transform.position, transform.right, out hit, RayLenght) && hit.collider.gameObject.CompareTag("Ground") && Rigidbody.velocity.magnitude <= 0.1)        {
                RolledSix();            
        }
    }

    void RolledSix()
    {
        Debug.Log("Rolled Six 1");
        Invoke("CheckOneMoreTime", 5);

    }
    void CheckOneMoreTime()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, RayLenght) && hit.collider.gameObject.CompareTag("Ground") && Rigidbody.velocity.magnitude <= 0.1)
        {
            Debug.Log("Rolled Six 2");

            Invoke("AddForce", 2);
        }
    }

    private void AddForce()
    {
        GameObject ojb = GameObject.Find("PHips").gameObject;
        ojb.GetComponent<Rigidbody>().AddForce(Vector3.up * 50, ForceMode.Impulse);
        Invoke("GoToNextScene", 4);
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(2);
    }
}
