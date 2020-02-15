using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private bool isOnGround;

    private float speed = 10.0f;
    private float horizontalInput;

    private int leftBound = -7;
    private int rightBound = 18;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ConstrainPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Right Arrow movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.AddForce(Vector3.right * horizontalInput * speed);
        }
        //Left Arrow movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.AddForce(Vector3.left * -horizontalInput * speed);
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up, ForceMode.Impulse);            
        }
    }

    private void ConstrainPlayer()
    {
        //Prohibits player from leaving left/right bounds
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }
}
