using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerEmpty;
    public GameObject player;

    [SerializeField] private float speed;
    private float forwardInput;
    private float horizontalInput;

    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(playerEmpty.transform.forward * speed * forwardInput);
        playerRb.AddForce(playerEmpty.transform.right * speed * horizontalInput);
        WinCheck();
    }

    private void WinCheck()
    {
        //This will eventually move the player to the next level
        if (player.transform.position.z > 90)
        {
            Debug.Log("You Win!");
            Application.Quit();
        }            
    }
}
