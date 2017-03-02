using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp {
    //Floats holding default values for how much the Speed Power Up boosts the player
    public float SpeedCapIncrease = 1.5f;
    public float JumpForceIncrease = 1f;

    public override void ActivatePowerUp(GameObject player)
    {
        //Increases the player's speed, then destroys the power up object

        PlayerController PController = player.GetComponent<PlayerController>();
        float oldSpeed = PController.maxSpeed;
        float oldJumpForce = PController.jumpForce;

        PController.maxSpeed = oldSpeed + SpeedCapIncrease;
        PController.jumpForce = oldJumpForce + JumpForceIncrease;

        destroyPowerUp();
    }
}