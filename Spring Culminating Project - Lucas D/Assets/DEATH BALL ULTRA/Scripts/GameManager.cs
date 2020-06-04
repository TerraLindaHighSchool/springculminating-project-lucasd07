using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI dunkedText;

    private int lives = 3;
    private int enemiesDunked;
    
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        dunkedText.text = "Enemies Dunked: " + enemiesDunked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives(int numLives)
    {
        lives += numLives;
        livesText.text = "Lives: " + lives;
    }

    public void updateDunked()
    {
        enemiesDunked += 1;
        dunkedText.text = "Enemies Dunked: " + enemiesDunked;
    }
}
