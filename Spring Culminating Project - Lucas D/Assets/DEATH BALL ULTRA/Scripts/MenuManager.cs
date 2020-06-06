using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject titleText;
    public GameObject tutorialButton;
    public GameObject creditsButton;
    public GameObject creditsText;
    public GameObject backButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }

    /*
    public void LoadEasyLevel()
    {
        SceneManager.LoadScene(2);
    }
    */ //Future levels canceled due to time restrictions.

    public void LoadCreditsScreen()
    {
        titleText.SetActive(false);
        tutorialButton.SetActive(false);
        creditsButton.SetActive(false);
        
        creditsText.SetActive(true);
        backButton.SetActive(true);
    }

    public void BackButton()
    {
        titleText.SetActive(true);
        tutorialButton.SetActive(true);
        creditsButton.SetActive(true);

        creditsText.SetActive(false);
        backButton.SetActive(false);
    }
}
