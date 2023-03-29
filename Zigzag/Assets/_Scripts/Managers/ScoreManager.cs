using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;

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
