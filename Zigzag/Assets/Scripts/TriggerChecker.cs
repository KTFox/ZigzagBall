using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Invoke(nameof(FallDown), 0.05f);
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 1f);
    }
}
