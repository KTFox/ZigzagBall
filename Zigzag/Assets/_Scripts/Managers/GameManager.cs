using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private GameObject followCam;

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        followCam = GameObject.Find("Follow Camera");
    }

    public void StartGame()
    {
        AudioSystem.instance.PlaySound("SoundTrack");
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        PlaftformSpawner.instance.StartSpawn();
    }

    public void GameOver()
    {
        AudioSystem.instance.StopSound("SoundTrack");
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();

        followCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = null;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
