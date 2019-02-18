using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //Public Vars

    // Called after everything in the scene is loaded, only gets called once in it's life time
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    //Here is where we'll handle all menu items
    private void OnGUI()
    {
    }
}
