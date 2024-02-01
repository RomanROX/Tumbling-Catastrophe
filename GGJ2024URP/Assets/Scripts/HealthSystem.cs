using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthSystem : MonoBehaviour
{

    public float health;
    [SerializeField] private float maxHealth;
    //neam audio source-a na likovima
    public List<AudioClip> clip = new List<AudioClip>();
    public List<string> titles = new List<string>();
    public GameObject TitlesOBJ;

    public float soundWait;
    public float RestartWair;
    public string sceneName;

    private bool isplaying;


    [Header("Ako je player")]
    public bool IsPlayer;
    public GameObject head;
    public GameObject enemyRagdoll;
    public AudioSource ass;

    //public LevelLoaderScript levelLoaderScript;

    public GameObject objectToDestory;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        maxHealth = health;
        ass = GetComponent<AudioSource>();

    }


    public void DealDamage(float damage)
    {
        health -= damage;

        //Debug.Log(gameObject.transform.parent.name + " Recived damage: -" + damage);

        if (health <= 0)
        {
            Debug.Log(gameObject.transform.parent.name + "<color=#00FF00> DIED </color>");

            if (IsPlayer)
            {
                Debug.Log("Spawning Force"); 
                this.gameObject.AddComponent<ConstantForce>();
                GetComponent<ConstantForce>().enabled = true;
                GetComponent<ConstantForce>().force = new Vector3(0, 300, 0);

                head.gameObject.AddComponent<ConstantForce>();
                head.GetComponent<ConstantForce>().enabled = true;
                head.GetComponent<ConstantForce>().force = new Vector3(0, -50, 0);

                if (!isplaying)
                {
                    isplaying = true;
                    int _i = Random.Range(0, clip.Count);
                    ass.PlayOneShot(clip[_i]);
                    soundWait = clip[_i].length;
                    RestartWair = soundWait + 2;



                    TitlesOBJ.GetComponent<TExtHandler>().Piši(titles[_i]);




                    Invoke("RestartScene", RestartWair);
                    //Invoke("PlayDeathSound", soundWait);

                }
            }
            else
            {
                Vector3 position = transform.parent.transform.position;
                Instantiate(enemyRagdoll, position, Quaternion.identity);
                Destroy(objectToDestory);
            }

        }
    }

    /*public void PlayDeathSound()
    {
        int _i = Random.Range(0, clip.Count);
        ass.PlayOneShot(clip[_i]);
        soundWait = clip[_i].length;
        RestartWair = soundWait + 2;
        Invoke("RestartScene", RestartWair);
        Debug.Log("playing");

    }*/

    public void RestartScene()
    {
        Debug.Log("loadingNextScene3");
        //LevelLoaderScript levelLoaderScript = transform.Find("LevelLoader").GetComponent<LevelLoaderScript>();

        //levelLoaderScript.ReloadLevelScene();
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     

        isplaying = false;
    }
}
