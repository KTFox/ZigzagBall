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
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        PlaftformSpawner.instance.StartSpawn();

        Camera.main.GetComponent<CameraFollow>().gameOver = false;
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        PlaftformSpawner.instance.StopSpawn();

        Camera.main.GetComponent<CameraFollow>().gameOver = true;
    }
}
