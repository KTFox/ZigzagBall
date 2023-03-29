using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject startPanel;
    public GameObject gameOverHolderPanel;
    public GameObject buttons;
    public GameObject runningScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highScore1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        highScore.text = "High score: " + ScoreManager.instance.highScore.ToString();
    }

    void Update()
    {
        runningScore.GetComponent<TextMeshProUGUI>().text = "Score: " + ScoreManager.instance.score.ToString();
    }
    
    public void GameStart()
    {
        buttons.SetActive(false);
        runningScore.SetActive(true);
        startPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        gameOverHolderPanel.SetActive(true);
        runningScore.SetActive(false);
        score.text = ScoreManager.instance.score.ToString();
        highScore1.text = ScoreManager.instance.highScore.ToString();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
