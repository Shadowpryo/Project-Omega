using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    //public vars
    public GameManager GM;
    public Vector3 spawn;
    public Texture2D MenuImg;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Funct to start new game
    public void newGame()
    {
        //Actually loads the next scene
        SceneManager.LoadScene("CharacterSelect");
    }
    //Funct to load a game
    public void loadGame()
    {
        //Debug to make sure it's clicking
        Debug.Log("Load a game");
    }
    //Funct to get to options
    public void Options()
    {
        //Debug to make sure it's clicking
        Debug.Log("Load options menu");
    }
    //Funct to quit game
    public void Quit()
    {
        //Quits the application
        Application.Quit();
    }
    //Fucn to slect drafted
    public void Drafte()
    {
        //Debug log to make sure it's clicking
        Debug.Log("You were drafted! show cut scene");
        GM.enlisted = false;
        //No cutscene so for now load level
        SceneManager.LoadScene("CustomChar");
    }
    //func to select enliseted
    public void Enslit()
    {
        //Debug to show it's clicking
        Debug.Log("You enlisted! show cut scene");
        GM.enlisted = true;
        //No cutscene so for now load level
        SceneManager.LoadScene("CustomChar");
    }

    public void Body()
    {
        GameObject player = GameObject.Find("Player");
        Color32 ncolor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        player.GetComponent<Renderer>().material.color = ncolor;
    }
    public void Eyes()
    {
        GameObject reye = GameObject.Find("rEye");
        GameObject leye = GameObject.Find("lEye");
        Color32 ncolor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        reye.GetComponent<Renderer>().material.color = ncolor;
        leye.GetComponent<Renderer>().material.color = ncolor;
    }

    public void Begin()
    {
        SceneManager.LoadScene("Hub01");
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            Debug.Log("Game manager is " + GM);
            spawn = GameObject.Find("Spawn").transform.position;
            if (GM.enlisted)
            {
                GameObject ply = (GameObject)Instantiate(GM.playerE, spawn, Quaternion.Euler(new Vector3(0,180,0)));
                ply.name = "Player";
                ply.GetComponentInChildren<Camera>().gameObject.SetActive(false);
                GM.PC = GameObject.Find("Player").GetComponent<PlayerControl>();
            }
            else
            {
                GameObject ply = (GameObject)Instantiate(GM.playerD, spawn, Quaternion.Euler(new Vector3(0, 180, 0)));
                ply.name = "Player";
                ply.GetComponentInChildren<Camera>().gameObject.SetActive(false);
                GM.PC = GameObject.Find("Player").GetComponent<PlayerControl>();
            }
        }
    }

    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), MenuImg, ScaleMode.ScaleToFit, true);
    }
}
