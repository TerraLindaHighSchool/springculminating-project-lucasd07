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
        horizontalInput = Input.GetAxis("Horizontal");
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.AddForce(Vector3.right * horizontalInput * speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.AddForce(Vector3.left * -horizontalInput * speed);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up, ForceMode.Impulse);
            isOnGround = false;
        }
        if(transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        if(transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
