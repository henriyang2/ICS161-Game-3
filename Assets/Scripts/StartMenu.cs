using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    private string GAME_SCENE_NAME_STRING = "Game";

	void Start () 
    {
		
	}
	
	void Update () 
    {
		
	}

    public void Play ()
    {
        SceneManager.LoadScene(GAME_SCENE_NAME_STRING);
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
