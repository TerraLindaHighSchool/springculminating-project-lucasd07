using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI dunkedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelWinText;

    private int lives;
    private int enemiesDunked;
    private int score;
    private int yDeathZone = -20;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        enemiesDunked = 0;
        score = 0;
        livesText.text = "Lives: " + lives;
        dunkedText.text = "Enemies Dunked: " + enemiesDunked;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeathCheck();
    }

    public void UpdateLives(int numLives)
    {
        if(!isGameOver)
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
        if(!isGameOver)
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
                isGameOver = true;
                StartCoroutine(LoadMainMenu());
            }
        }
    }
}
