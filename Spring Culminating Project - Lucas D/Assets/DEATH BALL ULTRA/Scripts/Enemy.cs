using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody enemyRb;
    private GameManager gameManager;

    private int yDeath = -20;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        deathCheck();
    }

    private void movement()
    {
        enemyRb.AddForce(enemyRb.transform.forward * Time.deltaTime * speed);
    }

    private void deathCheck()
    {
        if(transform.position.y < yDeath)
        {
            gameManager.UpdateDunked();
            gameManager.UpdateScore(25);
            Destroy(gameObject);
        }
    }
}
