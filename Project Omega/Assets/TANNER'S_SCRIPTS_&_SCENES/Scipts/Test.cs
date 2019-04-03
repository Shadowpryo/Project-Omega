using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject pauseScreen;
    float timeSpeed = 0; //  Hold the old timescale for unpausing
    bool paused = false;

    private void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Debug.Log("Pausing");
            IsPaused();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Debug.Log("Unpausing");
            isUnpaused();
        }
    }

    void IsPaused()
    {
        paused = !paused;
        Debug.Log("Pause: " + paused);
        timeSpeed = Time.timeScale;

        Time.timeScale = 0f;

        pauseScreen.SetActive(true);
    }

    void isUnpaused()
    {
        paused = !paused;
        Debug.Log("Unpause: " + paused);
        Time.timeScale = timeSpeed;

        pauseScreen.SetActive(false);
    }
}