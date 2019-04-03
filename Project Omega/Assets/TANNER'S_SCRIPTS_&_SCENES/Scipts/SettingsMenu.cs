using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public Slider mouseXYSlider, mouseXSlider, mouseYSlider;
    public Text mouseXYText, mouseXText, mouseYText;
    float mouseXY, mouseX, mouseY;

    private void Start()
    {
        settingsMenu.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("X: " + mouseX);
        Debug.Log("Y: " + mouseY);

        //Mouse Sensitivity Sliders
        mouseX += Input.GetAxisRaw("Mouse X") * (mouseXSlider.value + mouseXYSlider.value);
        mouseY += Input.GetAxisRaw("Mouse Y") * (mouseYSlider.value + mouseXYSlider.value);

        mouseXYText.text = mouseXYSlider.value.ToString("#.00");
        mouseXText.text = mouseXSlider.value.ToString("#.00");
        mouseYText.text = mouseYSlider.value.ToString("#.00");
    }

    public void Menu()
    {
        settingsMenu.SetActive(true);
    }

    public void Exit()
    {
        settingsMenu.SetActive(false);
    }

    public void Settings()
    {
        bool i = Input.anyKeyDown;
    }
}