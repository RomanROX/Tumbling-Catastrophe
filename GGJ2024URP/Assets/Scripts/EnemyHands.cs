using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHands : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] EnemyController enemyController;

    [SerializeField] float TimeBetweenPunches = 5f;
    float timer = 0;

    //public AudioSource audioSource;
    //public AudioClip[] Grabclips;
    //public AudioClip[] Throwclips;

    // Start is called before the first frame update
    void Start()

    {
        rb = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Time.time >= timer + TimeBetweenPunches)
        {
            //Debug.Log(rb.velocity.magnitude);
            float damage = enemyController.DamageCalculator(rb.velocity.magnitude);
            if (other.TryGetComponent<PlayerHealthGrabber>(out PlayerHealthGrabber playerHealthGrabber))
            {
                timer = Time.time;
                playerHealthGrabber.SendDamage(damage);
                //PlaySound(Grabclips);
            }
        }
    }

    //public void PlaySound(AudioClip[] audioclips)
    //{
    //    int rand = Random.Range(0, audioclips.Length-1);
    //    Debug.Log(rand);
    //    audioSource.PlayOneShot(audioclips[rand]);
    //}
}
