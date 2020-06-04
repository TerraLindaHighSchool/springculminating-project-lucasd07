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
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        WinCheck();
    }

    private void MovePlayer()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(playerEmpty.transform.forward * speed * forwardInput);
        playerRb.AddForce(playerEmpty.transform.right * speed * horizontalInput);

        if(transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void WinCheck()
    {
        //Loads main menu as scene
        if (player.transform.position.z > 90)
        {
            Debug.Log("You Win!");
            gameManager.LoadMainMenu();
        }            
    }
}
