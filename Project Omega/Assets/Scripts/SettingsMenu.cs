using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public Slider mouseXSlider, mouseYSlider;
    float mouseX, mouseY;

    private void Start()
    {
        settingsMenu.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("X: " + mouseX);
        Debug.Log("Y: " + mouseY);

        //Mouse Sensitivity Sliders
        mouseX += Input.GetAxisRaw("Mouse X") * mouseXSlider.value;
        mouseY += Input.GetAxisRaw("Mouse Y") * mouseYSlider.value;
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