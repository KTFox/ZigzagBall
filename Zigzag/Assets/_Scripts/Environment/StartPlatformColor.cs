using UnityEngine;

public class StartPlatformColor : MonoBehaviour
{
    [SerializeField] GameObject platform;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = platform.GetComponent<LerpColorPlatform>().myColors[0];
    }
}
