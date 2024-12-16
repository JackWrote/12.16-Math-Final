using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= -GetComponent<SpriteRenderer>().bounds.size.x)
        {
            transform.position = new Vector3(transform.position.x + ((GetComponent<SpriteRenderer>().bounds.size.x)*2), transform.position.y, transform.position.z);
        }
    }
}
