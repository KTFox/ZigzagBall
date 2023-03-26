using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAppearManager : MonoBehaviour
{
    //Variables
    [SerializeField] Material[] ballColors;
    int selectedColor;

    //Event functions
    void Start()
    {
        selectedColor = PlayerPrefs.GetInt("SelectedColor");
        gameObject.GetComponent<Renderer>().material = ballColors[selectedColor];
    }

    //Methods
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
