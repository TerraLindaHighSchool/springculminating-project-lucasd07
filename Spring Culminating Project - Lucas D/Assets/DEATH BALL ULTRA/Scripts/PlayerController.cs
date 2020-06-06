using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerEmpty;
    public GameObject player;

    public ParticleSystem collisionEnemy;
    public ParticleSystem collisionWorld;

    [SerializeField] private float speed;
    private float forwardInput;
    private float horizontalInput;

    private Rigidbody playerRb;
    private GameManager gameManager;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
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
        //Checks if the player's z coordinate is past the goal
        if (player.transform.position.z > 90)
        {
            //Makes the Win Text appear
            gameManager.levelWinText.gameObject.SetActive(true);
            //Makes sure the player doesn't lose any lives after already winning
            if (transform.position.y < -19)
                transform.position = new Vector3(transform.position.x, -19, transform.position.z);
            //Loads main menu
            StartCoroutine(gameManager.LoadMainMenu());
        }            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collisionEnemy.Play();
        }
        if(collision.gameObject.CompareTag("World"))
        {
            collisionWorld.Play();
        }
    }
}
