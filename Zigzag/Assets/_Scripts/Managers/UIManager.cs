using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [Header("Start State")]
    public GameObject startPanel;
    public GameObject buttons;
    public TextMeshProUGUI highScore;

    [Header("Run State")]
    public GameObject runningScore;

    [Header("GameOver State")]
    public GameObject gameOverHolderPanel;    
    public TextMeshProUGUI score; 
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
        runningScore.GetComponent<TextMeshProUGUI>().text = ScoreManager.instance.score.ToString();
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
