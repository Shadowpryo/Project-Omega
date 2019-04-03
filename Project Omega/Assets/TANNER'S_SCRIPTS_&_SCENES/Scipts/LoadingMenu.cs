using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingMenu : MonoBehaviour
{
    public GameObject loadingScreen; // Hold the loading screen Canvis
    public Slider loadingSlider;     // The loading bar, disable interaction on the bar
    public Text percentage;          // The printed percentage of the loading bar

    float progress = 0f;

    public void Loading(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            percentage.text = progress * 100f + "%";

            yield return null;
        }
    }
}