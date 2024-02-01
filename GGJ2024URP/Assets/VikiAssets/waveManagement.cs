using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class waveManagement : MonoBehaviour
{
    public List<GameObject> Enemy = new List<GameObject>();
    public List<int> Waves = new List<int>();

    public float VrijemeIzmedjuValova;
    private float PreostaloDoSljedeceg;

    public int trenutni;

    //public LevelLoaderScript LevelLoader;

    public List<GameObject> mjesta= new List<GameObject>();

    private void Awake()
    {
        
    }

    private void Start()
    {
        trenutni= 0;    
    }
    // Update is called once per frame
    void Update()
    {
        Places();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().Find("PHips").GetComponent<Rigidbody>().AddForce(transform.up * 50, ForceMode.Impulse);

        }
    }


    public void Places()
    {
        if (PreostaloDoSljedeceg <= 0f)
        {
            PreostaloDoSljedeceg = VrijemeIzmedjuValova;
            for (int i = 0; i < Waves[trenutni]; i++)
            {
                int range = Random.Range(0, mjesta.Count);
                int type = Random.Range(0, Enemy.Count);

                Instantiate(Enemy[type], mjesta[range].transform.position, Quaternion.identity, transform.GetChild(0));
            }
            trenutni++;
        }
        if (transform.GetChild(0).childCount == 0) StartCoroutine(Don());
    }
    public IEnumerator Don()
    {
        yield return new WaitForSeconds(3);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().Find("Hips").GetComponent<Rigidbody>().AddForce(transform.up * 50, ForceMode.Impulse);
        //GameObject ojb = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().GetChild(1).gameObject;
        GameObject ojb = GameObject.Find("PHips").gameObject;
        ojb.GetComponent<Rigidbody>().AddForce(transform.up * 50, ForceMode.Impulse);
        yield return new WaitForSeconds(3);
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //LevelLoaderScript LevelLoader = transform.Find("LevelLoader").GetComponent<LevelLoaderScript>();
        //LevelLoader.LoadNextLevelScene();
    }
}
