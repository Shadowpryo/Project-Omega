using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //Public Vars
    public Vector3 PSH01;
    public GameObject playerD;
    public GameObject playerE;
    public Camera camera;
    public bool enlisted;
    // Called after everything in the scene is loaded, only gets called once in it's life time
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        enlisted = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Here is where we'll handle all menu items
    private void OnGUI()
    {
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 3)
        {
            PSH01 = GameObject.Find("playerSpawn").transform.position;
            if (enlisted)
            {
                GameObject ply = (GameObject)Instantiate(playerE, PSH01, Quaternion.identity);
                Camera cam = (Camera)Instantiate(camera, PSH01, Quaternion.identity);
                cam.name = "Main Camera";
                ply.name = "Player";
                cam.transform.parent = ply.transform;
            }
            else
            {
                GameObject ply = (GameObject)Instantiate(playerD, PSH01, Quaternion.identity);
                Camera cam = (Camera)Instantiate(camera, PSH01, Quaternion.identity);
                cam.name = "Main Camera";
                ply.name = "Player";
                cam.transform.parent = ply.transform;
            }
        }
    }
}
