using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Variables
    public static UIManager instance;

    public GameObject startPanel;
    public GameObject gameOverHolderPanel;
    public GameObject clickText;
    public GameObject currentScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highScore1;

    //Event functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        highScore.text = "High score: " + PlayerPrefs.GetInt("highScore").ToString();
    }
    
    void Update()
    {

    }
    
    //Methods
    public void GameStart()
    {
        clickText.SetActive(false);

        startPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        gameOverHolderPanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
