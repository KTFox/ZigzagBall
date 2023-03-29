using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] GameObject particle;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            AudioSystem.instance.PlaySound("DiamondCollection");

            ScoreManager.instance.score += 50;

            GameObject par = Instantiate(particle, gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(par, 1f);
            Destroy(gameObject);
        }
    }
}
