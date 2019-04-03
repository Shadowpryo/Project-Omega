using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This script will control the object of the main menu and the loading screen
 * This does not control the pause and settings menus, only links to them
 */

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas, loadingCanvis;

    public float loading = 0;

    public Slider progressing;

    private void Start()
    {
        menuCanvas.SetActive(true);
        loadingCanvis.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnClick();
        }
	}

    public void OnClick()
    {
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        menuCanvas.SetActive(false);
        loadingCanvis.SetActive(true);

        AsyncOperation preload = SceneManager.LoadSceneAsync("Testing");

        Debug.Log(preload.progress);

        while (!preload.isDone)
        {
            loading = Mathf.Clamp01(preload.progress / .9f);

            progressing.value = loading;

            Debug.Log(preload.progress);

            yield return null;
        }
        if(preload.isDone)
        {
            Debug.Log(preload.progress);

            loading = Mathf.Clamp01(preload.progress / .9f);

            progressing.value = loading;

            Debug.Log(preload.progress);

            yield return new WaitForSeconds(5);
        }
        Debug.Log(preload.progress);
    }
}