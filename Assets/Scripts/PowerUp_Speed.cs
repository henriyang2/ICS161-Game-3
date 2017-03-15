using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp {
    //Floats holding default values for how much the Speed Power Up boosts the player
    PlayerController PController;

    public float SpeedCapIncrease = 1.5f;
    public float JumpForceIncrease = 1f;
    public float duration = 4f;
    public bool poweredUp = false;
    float oldSpeed;
    float oldJumpForce;
    Material oldMaterial;
    public Material newMaterial;
    public AudioClip collectAudioClip;

    private AudioSource powerupAudioSource;

    void Awake ()
    { 
        powerupAudioSource = GetComponent<AudioSource>();
    }

    public override void ActivatePowerUp(GameObject player)
    {
        //Increases the player's speed, then destroys the power up object
        //Also currently changes the player's material to indicate that they're powered up
        if(poweredUp == false)
        { 
            powerupAudioSource.PlayOneShot(collectAudioClip);

            PController = player.GetComponent<PlayerController>();
            oldMaterial = PController.gameObject.GetComponent<Renderer>().material;
        

        oldSpeed = PController.moveSpeed;
        oldJumpForce = PController.jumpForce;

        PController.moveSpeed = oldSpeed + SpeedCapIncrease;
        PController.jumpForce = oldJumpForce + JumpForceIncrease;
        PController.gameObject.GetComponent<Renderer>().material = newMaterial;


            poweredUp = true;

            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    void RevertStats()
    {
        //Reverts all changes the power-up made to the player
        PController.moveSpeed = oldSpeed;
        PController.jumpForce = oldJumpForce;
        PController.gameObject.GetComponent<Renderer>().material = oldMaterial;
        poweredUp = false;
    }

    void Update()
    {
        if (poweredUp)
        {
            duration -= Time.deltaTime;
        }
        if (duration <= 0)
        {
            RevertStats();
            duration = 4f;
            destroyPowerUp();
        }
    }
}