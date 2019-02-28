using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //Public Vars
    public Vector3 PSH01;
    public GameObject playerD;
    public GameObject playerE;
    public int money;
    public PlayerControl PC;
    public bool enlisted;
    public bool inGame = false;


    // Called after everything in the scene is loaded, only gets called once in it's life time
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        enlisted = false;
	}

    //Here is where we'll handle all menu items
    private void OnGUI()
    {
        if (inGame)
        {
            GUI.Box(new Rect(10, 10, 120, 25),
                string.Format("HP/MaxHP: " + PC.hp + "/" + PC.MaxHP));
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 3)
        {
            PSH01 = GameObject.Find("playerSpawn").transform.position;
            GameObject player = GameObject.Find("Player");
            player.transform.position = PSH01;
            PlayerControl pc = player.GetComponent<PlayerControl>();
            pc.cam.gameObject.SetActive(true);
            pc.canMove = true;
            inGame = true;
        }
    }
}
