using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private float timeRate;

    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 0f, timeRate);
    }

    public void SpawnObjects()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
