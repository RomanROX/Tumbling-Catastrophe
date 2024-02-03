using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Grabing : MonoBehaviour
{

    //donekle radi grab

    [SerializeField] Animator animator;
    [SerializeField] GameObject grabbedObj = null;

    FixedJoint fixedJoint;

    public Rigidbody rb;
    public int isLeftOrRight;
    public bool alredyGrabbing = false;

    public AudioSource audioSource;
    public AudioClip[] Grabclips;
    public AudioClip[] Throwclips;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (grabbedObj != null) Debug.Log("grabbed obj: " + grabbedObj.name);

        if (Input.GetMouseButtonDown(isLeftOrRight))
        {
            if (isLeftOrRight == 0) {
                animator.SetLayerWeight(1, 1);
                //PlaySound(Grabclips);
            }
            else if(isLeftOrRight == 1) {
                animator.SetLayerWeight(2, 1);
                //PlaySound(Grabclips);
            }
            
        }   
        else if (Input.GetMouseButtonUp(isLeftOrRight))
        {

            if (isLeftOrRight == 0)
            {
                animator.SetLayerWeight(1, 0);
                PlaySound(Throwclips);
            }
            else if (isLeftOrRight == 1)
            {
                animator.SetLayerWeight(2, 0);
                PlaySound(Throwclips);
            }

            removeSetJoint();
            //if (grabbedObj != null)
            //{
            //    Destroy(grabbedObj.GetComponent<FixedJoint>());
            //}

            //grabbedObj = null;
        }

        if (Input.GetMouseButton(isLeftOrRight)) setJoint();
        else removeSetJoint();
    }

    //grabbanje objekta
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
                //PlaySound(Grabclips);
            //Debug.Log("Enter: " + other.name);
            grabbedObj = other.gameObject;
            if (grabbedObj.GetComponent<FixedJoint>() == null)
            {
                FixedJoint fixedJoint = grabbedObj.AddComponent<FixedJoint>();
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Item") && Input.GetMouseButtonUp(isLeftOrRight))
    //    {
    //        grabbedObj = other.gameObject;
    //    }
    //}

    //ungrabanje objekta
    private void OnTriggerExit(Collider other)    {
        if (other.gameObject.CompareTag("Item") && other.gameObject.name != "Enemy (raggdoll)(Clone)")
        {
            PlaySound(Throwclips);
            // Debug.Log("EXIT: " + other.name);
            if(other.transform.GetChild(0).TryGetComponent<GranadaExplode>(out GranadaExplode granadaExplode))
            {
                
                granadaExplode.Boom = true;

            }

            grabbedObj = null;
        }
    }

   void setJoint()
    {
        //Debug.Log("SetJOint");
        if (grabbedObj != null && grabbedObj.GetComponent<FixedJoint>() != null)
        {
            grabbedObj.GetComponent<FixedJoint>().connectedBody = this.rb;
            grabbedObj.GetComponent<FixedJoint>().breakForce = 1050;
        }
    }

    void removeSetJoint()
    {
        //Debug.Log("removeSetJOint");

        if (grabbedObj != null)
        {
            Destroy(grabbedObj.gameObject.GetComponent<FixedJoint>());
        }
    }

    public void PlaySound(AudioClip[] audioclips)
    {
        int rand = Random.Range(0, audioclips.Length);
        Debug.Log(rand);
        audioSource.PlayOneShot(audioclips[rand]);
    }
}
