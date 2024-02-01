using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GranadaExplode : MonoBehaviour
{
    public List<GameObject> Tijela = new List<GameObject>();
	public float JacinaBombe;
    public bool Boom;
    private bool Boomed = false;
    public ParticleSystem ps;
    public float delay;

    public AudioClip clip;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(Boomed == false && Boom == true)
        {
            StartCoroutine(BimBimBumBum());
            Boomed= true;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(BimBimBumBum());
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>() != null)
        {
            bool MozeProc = true;
            for (int i = 0; i < Tijela.Count; i++)
            {
                if (Tijela[i] == other.gameObject) MozeProc= false;
            }
            if(MozeProc == true)Tijela.Add(other.gameObject);
        }
    }


    public IEnumerator BimBimBumBum()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Bam");
        ps.Play();

        for (int i = 0; i < Tijela.Count; i++)
        {
          
            Tijela[i].GetComponent<Rigidbody>().AddForce((Tijela[i].transform.position-transform.position).normalized * (1 / Vector3.Distance(Tijela[i].transform.position, transform.position) )*JacinaBombe,ForceMode.Impulse);
            if(Tijela[i].TryGetComponent<PlayerHealthGrabber>(out PlayerHealthGrabber playerHealthGrabber))
            {
                playerHealthGrabber.SendDamage(25 * (1/ Vector3.Distance(Tijela[i].transform.position,transform.position)));
            }

        }
        audioSource.PlayOneShot(clip);
        gameObject.transform.parent.GetComponent<MeshRenderer>().enabled= false;
        GetComponent<GranadaExplode>().enabled = false;
    }


}
