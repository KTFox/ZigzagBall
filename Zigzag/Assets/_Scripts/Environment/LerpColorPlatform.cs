using UnityEngine;

public class LerpColorPlatform : MonoBehaviour
{
    [SerializeField] BallController ball;
    [SerializeField] float speed;
    [SerializeField] int indexColor;
    [SerializeField] [Range(0f, 1f)] float timeLerp = 0.7f;

    private MeshRenderer platformMesh;

    public Color[] myColors;

    void Awake()
    {
        platformMesh = GetComponent<MeshRenderer>();
        ball = GameObject.Find("Ball").GetComponent<BallController>();
    }

    void Start()
    {
        speed = ball.defaultSpeed;
        platformMesh.material.color = myColors[0];
    }

    void Update()
    {
        LerpColor();
    }

    void LerpColor()
    {
        if (ball.currentSpeed > speed)
        {
            indexColor = Random.Range(0, myColors.Length);
            PlayerPrefs.SetInt("indexColor", indexColor);
            speed = ball.currentSpeed;
        }

        platformMesh.material.color = Color.Lerp(platformMesh.material.color, myColors[PlayerPrefs.GetInt("indexColor")], timeLerp * Time.deltaTime);
    }
}
