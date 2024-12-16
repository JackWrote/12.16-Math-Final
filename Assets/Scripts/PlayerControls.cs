using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    private float posX = 0.0f;
    private Rigidbody2D rb;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public bool isJumping = false;
    private float gravityForce = 0.02f;
    private float delay = 0.0f;
    public bool canDoubleJump = false;
    private bool shrunk = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && !isJumping)
        {
            transform.position = new Vector3(transform.position.x, -2.1f, transform.position.z);
            rb.AddForce(Vector3.up * jumpPower * rb.mass * rb.gravityScale * 20.0f);
            isJumping = true;
            canDoubleJump = true;
        }
        if (canDoubleJump && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && delay >= 120){
            canDoubleJump = false;
            gravityForce = 0.02f;
            rb.AddForce(Vector3.up * jumpPower * rb.mass * rb.gravityScale * 20.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (shrunk == false)
            {
                transform.localScale += new Vector3(0, -(transform.localScale.y / 2), 0);
                shrunk = true;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            }
        }
        else if(shrunk)
        {
            transform.localScale += new Vector3(0, transform.localScale.y, 0);
            shrunk = false;
        }

    }

    void Update()
    {
        float time = Time.time * frequency; // Scale time for frequency

        float yOffset = Mathf.Sin(time) * amplitude; // Calculate sine wave
        if (shrunk)
        {
            yOffset -= 0.5f;
        }
        if (!isJumping)
        {
            transform.position = new Vector3(transform.position.x, yOffset - 2.1f, transform.position.z);
        }
        if (isJumping)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + gravityForce, transform.position.z);
            gravityForce -= 0.00008f;
            delay += 1f;
            if (transform.position.y <= yOffset - 2.1f && delay >= 120)
            {
                isJumping = false;
                delay = 0.0f;
                gravityForce = 0.02f;
                canDoubleJump = false;
            }
        }

        if(transform.position.x <= -9)
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    } 

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
