using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class requierdItemOnTop : MonoBehaviour
{
    
    public string Tag;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag)
        {
            
            StartCoroutine(next());
        }
    }
    public IEnumerator next()
    {
        yield return new WaitForSeconds(3);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce(GameObject.FindGameObjectWithTag("Player").transform.up * 100, ForceMode.Impulse);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
