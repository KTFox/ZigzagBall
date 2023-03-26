using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{   
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            FallDown();
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Invoke(nameof(SpawnNewPlatform), 1f);     
    }

    void SpawnNewPlatform()
    {
        PlaftformSpawner.instance.SpawnPlatform();
    }
}
