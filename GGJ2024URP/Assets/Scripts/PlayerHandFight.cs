using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandFight : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float TimeBetweenPunches = 1f;
    float timer = 0;

    public AudioSource audioSource;
    public AudioClip[] Grabclips;
    public AudioClip[] Throwclips;

    // Start is called before the first frame update
    void Start()

    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && Time.time >= timer + TimeBetweenPunches)
        {
            //Debug.Log("Player Hand velocity: " + rb.velocity.magnitude);
            float damage = rb.velocity.magnitude;
            if (other.TryGetComponent<PlayerHealthGrabber>(out PlayerHealthGrabber playerHealthGrabber))
            {
                timer = Time.time;
                
                playerHealthGrabber.SendDamage(damage);
                 PlaySound(Grabclips);
            }
        }
    }

    public void PlaySound(AudioClip[] audioclips)
    {
       int rand = Random.Range(0, audioclips.Length);
        Debug.Log(rand);
        audioSource.PlayOneShot(audioclips[rand]);
    }
}
