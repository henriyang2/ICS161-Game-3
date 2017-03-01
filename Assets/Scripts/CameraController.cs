using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    private Game gameScriptRef;

    void Start ()
    {
        //Get a reference to the game script in order to see whether the game has ended
        gameScriptRef = GetComponent<Game>();
    }

    void LateUpdate ()
    {
        //If the game ends, stop camera movement
        if (!gameScriptRef.gameEnded)
        {
            //Camera constantly moves upwards at a designated speed, can tune this if needed
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
        }
    }
}
