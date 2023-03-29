using UnityEngine;

public class StartPlatformColor : MonoBehaviour
{
    [SerializeField] GameObject platform;

    void Start()
    {
        

    }

    void Update()
    {
        GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, platform.GetComponent<LerpColorPlatform>().myColors[PlayerPrefs.GetInt("indexColor")], 0.7f);
    }
}
