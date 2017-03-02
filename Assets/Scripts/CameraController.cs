using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    private Game gameScriptRef;
    public float cameraSpeed = 0.01f;
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
            //Camera constantly moves upwards at the speed designated by cameraSpeed
            transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        }
    }
}
