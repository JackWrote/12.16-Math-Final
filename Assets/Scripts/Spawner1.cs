using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpawner: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flying;
    public float spawnDelay = 3f;
    public float spawnTime = 2f;
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(20, 0, 0);

    }

    void InstantiateObjects()
    {
        int r = Random.Range(1, 4);
        if(r == 1)
        {
            int h = Random.Range(0, 4);
            transform.position = new Vector3(transform.position.x, transform.position.y + h, transform.position.z);
            Instantiate(flying, transform.position, transform.rotation);
        }
    }
}
