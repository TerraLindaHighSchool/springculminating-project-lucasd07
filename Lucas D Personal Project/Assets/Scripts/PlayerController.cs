using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private float speed = 10.0f;
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.AddForce(Vector3.right * horizontalInput * speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.AddForce(Vector3.left * -horizontalInput * speed);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector3.up * verticalInput * speed);
        }
    }
}
