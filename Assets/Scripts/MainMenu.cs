using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    //Funct to start new game
    public void newGame()
    {
        //Debug to make sure it's clicking
        Debug.Log("Start a new game");
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
        //Debug to make sure it's clicking
        Debug.Log("Quit game");
        //Quits the application
        Application.Quit();
    }
    //Fucn to slect drafted
    public void Drafte()
    {
        //Debug log to make sure it's clicking
        Debug.Log("You were drafted! show cut scene");
        //No cutscene so for now load level
        SceneManager.LoadScene("Hub01");
    }
    //func to select enliseted
    public void Enslit()
    {
        //Debug to show it's clicking
        Debug.Log("You enlisted! show cut scene");
        //No cutscene so for now load level
        SceneManager.LoadScene("Hub01");
    }
}
