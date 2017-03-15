using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    private string GAME_SCENE_NAME = "Game";

	void Start () 
    {
		
	}

    public void Play ()
    {
        SceneManager.LoadScene(GAME_SCENE_NAME);
    }
	
    public void Quit ()
    {
        Application.Quit();
    }
}
