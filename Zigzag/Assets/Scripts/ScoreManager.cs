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

        PlayerPrefs.SetInt("score", score);
    }

    //Methods
    void IncreaseScore()
    {
        score += 10;
    }

    public void StartScore()
    {
        InvokeRepeating("IncreaseScore", 1f, 0.2f);
    }

    public void StopScore()
    {
        CancelInvoke("IncreaseScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
