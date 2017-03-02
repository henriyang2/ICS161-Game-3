using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    bool pickedUp = false;
    //Abstract class for powerups

    //When another object intersects with the powerUp's collider, call the Power-Up function
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;

        if (collider.gameObject.CompareTag("Player 1") || collider.gameObject.CompareTag("Player 2"))
        {
            pickedUp = true;
            ActivatePowerUp(collider.gameObject);
        }
        //If the power-up gets to the deathTrigger and no one picked it up, delete it for performance
        else if (collider.gameObject.name == "deathTrigger" && pickedUp == false)
        {
            destroyPowerUp();
        }
    }

    //Override this virtual function with an added effect in a derived class
    public virtual void ActivatePowerUp(GameObject player) { }

    //destroys the power-up
    public void destroyPowerUp()
    {
        Destroy(this.gameObject);
    }

}
