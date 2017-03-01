using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour 
{
    void OnTriggerEnter2D (Collider2D other)
    {
        //If Player 1 touched the trigger, Player 2 won
        //If Player 2 touched the trigger, Player 1 won
        if (other.CompareTag("Player 1"))
        {
            Camera.main.GetComponent<Game>().EndGame("Player 2");
        }
        else if (other.CompareTag("Player 2"))
        {
            Camera.main.GetComponent<Game>().EndGame("Player 1");
        }
    }
}
