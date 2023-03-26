using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
    //Variables
    [SerializeField] float defaultSpeed = 4f;
    [SerializeField] float currentSpeed;

    bool gameOver;
    Rigidbody rb;

    //Event functions
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FallOutOfPlatform();
        SwitchDirection();
        SpeedUp();
    }

    //Methods
    public void SwitchDirection()
    {
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(0, 0, currentSpeed);
            }
            else if (rb.velocity.z > 0)
            {
                rb.velocity = new Vector3(currentSpeed, 0, 0);
            }
        }     
    }

    public void StartRun()
    {       
        rb.velocity = new Vector3(defaultSpeed, 0, 0);
        GameManager.instance.StartGame();
    }

    public void FallOutOfPlatform()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.velocity = new Vector3(0, -25f, 0);

            gameOver = true;

            GameManager.instance.GameOver();
        }
    }

    public void SpeedUp()
    {
        int currentScore = ScoreManager.instance.score;

        if (currentScore <= 1000)
        {
            currentSpeed = defaultSpeed;
        }
        else if (currentScore > 1000)
        {
            currentSpeed = defaultSpeed + (currentScore/1000);
        }
    }
}
