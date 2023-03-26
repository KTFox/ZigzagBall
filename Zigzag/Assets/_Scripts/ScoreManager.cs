using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Variables
    public static ScoreManager instance;

    public int score;
    public int highScore;

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
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    //Methods
    void IncreaseScore()
    {
        score += 10;

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void StartScore()
    {
        InvokeRepeating(nameof(IncreaseScore), 1f, 0.2f);
    }

    public void StopScore()
    {
        CancelInvoke("IncreaseScore");
    }
}
