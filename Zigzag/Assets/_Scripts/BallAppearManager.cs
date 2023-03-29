using UnityEngine;

public class BallAppearManager : MonoBehaviour
{
    [SerializeField] Material[] ballColors;
    
    private int selectedColor;

    void Start()
    {
        selectedColor = PlayerPrefs.GetInt("SelectedColor");
        gameObject.GetComponent<Renderer>().material = ballColors[selectedColor];
    }

    public void NextColor()
    {
        selectedColor = (selectedColor + 1) % ballColors.Length;
        gameObject.GetComponent<Renderer>().material = ballColors[selectedColor];

        PlayerPrefs.SetInt("SelectedColor", selectedColor);
    }

    public void BeforeColor()
    {
        selectedColor--;

        if (selectedColor < 0)
        {
            selectedColor += ballColors.Length;
        }

        gameObject.GetComponent<Renderer>().material = ballColors[selectedColor];

        PlayerPrefs.SetInt("SelectedColor", selectedColor);
    }
}
