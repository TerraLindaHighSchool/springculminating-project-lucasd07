using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public GameObject player;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI dunkedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelWinText;

    private float spawnPosX;
    private float spawnPosY = 8;
    private float spawnPosZ;
    private float spawnRangeX = 6.75f;
    private float spawnLimitZ = 80;

    private Vector3 randomPos;

    private int lives;
    private int enemiesDunked;
    private int score;
    private int yDeathZone = -20;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        lives = 3;
        enemiesDunked = 0;
        score = 0;
        livesText.text = "Lives: " + lives;
        dunkedText.text = "Enemies Dunked: " + enemiesDunked;
        scoreText.text = "Score: " + score;

        StartCoroutine(SpawnEnemy(1));
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeathCheck();
    }

    public void UpdateLives(int numLives)
    {
        if(isGameActive)
        {
            lives += numLives;
            livesText.text = "Lives: " + lives;
        }
    }

    public void UpdateDunked()
    {
        enemiesDunked += 1;
        dunkedText.text = "Enemies Dunked: " + enemiesDunked;
    }

    public void UpdateScore(int addedScore)
    {
        if(isGameActive)
        {
            score += addedScore;
            scoreText.text = "Score: " + score;
        }
    }

    public IEnumerator LoadMainMenu()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(0); //Loads main menu        
    }

    private void PlayerDeathCheck()
    {
        if (player.transform.position.y < yDeathZone)
        {
            UpdateLives(-1);
            UpdateScore(-20);
            if (lives > 0)
            {                
                player.transform.position = new Vector3(0, 2, 0);
            }
            else
            {
                gameOverText.gameObject.SetActive(true);
                isGameActive = false;
                StartCoroutine(LoadMainMenu());
            }
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        spawnPosZ = Random.Range(0, spawnLimitZ); //Spawn "limit" because the first value should be 0 as there is no ground below z:0
        randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randomPos;
    }
    
    private IEnumerator SpawnEnemy(int numToSpawn)
    {
        while (isGameActive)
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
            }
            yield return new WaitForSeconds(5);
        }
    }
}
