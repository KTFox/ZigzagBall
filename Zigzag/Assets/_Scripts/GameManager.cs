using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager will controll: UI, score, camera, platformspawner
public class GameManager : MonoBehaviour
{
    //Variables
    public static GameManager instance;

    public bool gameOver;

    //Event functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Methods
    public void StartGame()
    {
        AudioManager.instance.PlaySound("SoundTrack");
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        PlaftformSpawner.instance.StartSpawn();

        Camera.main.GetComponent<CameraFollow>().gameOver = false;
    }

    public void GameOver()
    {
        AudioManager.instance.StopSound("SoundTrack");
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();

        Camera.main.GetComponent<CameraFollow>().gameOver = true;
    }
}
