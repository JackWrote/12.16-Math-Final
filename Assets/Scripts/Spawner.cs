using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cactus1;
    public float spawnDelay = 3f;
    public float spawnTime = 2f;
    public GameObject cactus2;
    public GameObject cactus3;
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(20, -1f, 0);

    }

    void InstantiateObjects()
    {
        int r = Random.Range(1, 4);
        if(r == 1)
        {
            Instantiate(cactus1, transform.position, transform.rotation);
        }
        else if (r == 2)
        {
            Instantiate(cactus2, transform.position, transform.rotation);
        }
        else if (r == 3)
        {
            transform.position = new Vector3(20, 0.35f, 0);
            Instantiate(cactus3, transform.position, transform.rotation);
        }

    }
}
