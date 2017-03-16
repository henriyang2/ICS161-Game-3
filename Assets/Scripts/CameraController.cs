using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    private Game gameScriptRef;
    public float cameraSpeed = 0.01f;
    public float cameraExtraSpeed;

    public Transform player1;
    public Transform player2;
    public Transform threshold;
    public Transform threshold2;

    void Start()
    {
        //Get a reference to the game script in order to see whether the game has ended
        gameScriptRef = GetComponent<Game>();
    }

    void LateUpdate()
    {
        //If the game ends, stop camera movement
        if (!gameScriptRef.gameEnded)
        {
            //check if players are above first threshold
            if (player1.position.y > threshold.position.y || player2.position.y > threshold.position.y)
            {
                //Camera constantly moves upwards at the speed designated by cameraSpeed if either player is above threshold
                transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
            }

            //check if players are above second threshold
            if (player1.position.y > threshold2.position.y || player2.position.y > threshold2.position.y)
            {
                //Camera constantly moves upwards at the speed designated by cameraSpeed if either player is above threshold
                transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed + cameraExtraSpeed, transform.position.z);
            }

            //Camera constantly moves upwards at the speed designated by cameraSpeed if either player is above threshold
            //transform.position = new Vector3(transform.position.x, transform.position.y + cameraSpeed, transform.position.z);
        }
    }
}
