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

        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {        
        DeathCheck();
    }

    private IEnumerator Movement()
    {
        while (gameManager.isGameActive)
        {
            enemyRb.AddForce(enemyRb.transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
            yield return new WaitForSeconds(4);
            enemyRb.AddForce(-enemyRb.transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
            yield return new WaitForSeconds(4);
        } 
    }

    private void DeathCheck()
    {
        if(transform.position.y < yDeath)
        {
            gameManager.UpdateDunked();
            gameManager.UpdateScore(25);
            Destroy(gameObject);
        }
    }
}
