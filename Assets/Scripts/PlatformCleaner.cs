using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCleaner : MonoBehaviour 
{
    void OnTriggerEnter2D (Collider2D other)
    {
        //For putting platform objects back into the pool
        //When the platform cleaner hits the colliders on
        //the bottom of the screen, it will disable it and
        //put it back into the pool for future use
        if (other.CompareTag("Platform"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
