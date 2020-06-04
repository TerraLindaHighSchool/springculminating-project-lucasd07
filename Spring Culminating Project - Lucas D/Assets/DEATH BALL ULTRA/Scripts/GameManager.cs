using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI dunkedText;
    public TextMeshProUGUI scoreText;

    private int lives;
    private int enemiesDunked;
    private int score;
    
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
        
    }

    public void UpdateLives(int numLives)
    {
        lives += numLives;
        livesText.text = "Lives: " + lives;
    }

    public void UpdateDunked()
    {
        enemiesDunked += 1;
        dunkedText.text = "Enemies Dunked: " + enemiesDunked;
    }

    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); //Loads main menu
    }
}
