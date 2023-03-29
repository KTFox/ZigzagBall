using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartGame()
    {
        AudioSystem.instance.PlaySound("SoundTrack");
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        PlaftformSpawner.instance.StartSpawn();

        Camera.main.GetComponent<CameraFollow>().gameOver = false;
    }

    public void GameOver()
    {
        AudioSystem.instance.StopSound("SoundTrack");
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();

        Camera.main.GetComponent<CameraFollow>().gameOver = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
