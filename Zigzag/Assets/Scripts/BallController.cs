using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
    //Variables
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] GameObject particle;
    bool hasMoved;
    bool gameOver;
    Rigidbody rb;

    //Event functions
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!hasMoved)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
                hasMoved = true;

                GameManager.instance.StartGame();
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameObject.Find("PlaftformSpawner").GetComponent<PlaftformSpawner>().gameOver = true;

            gameOver = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    //Methods
    public void SwitchDirection()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, moveSpeed);
        }
        else if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(moveSpeed, 0, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            GameObject par = Instantiate(particle, other.transform.position, Quaternion.identity) as GameObject;

            Destroy(par, 1f);
            Destroy(other.gameObject);
        }
    }

}
