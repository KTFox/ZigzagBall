using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject particle;

    //Methods
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.instance.score += 50;

            GameObject par = Instantiate(particle, gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(par, 1f);
            Destroy(gameObject);
        }
    }
}
