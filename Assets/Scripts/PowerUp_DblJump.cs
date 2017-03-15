using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_DblJump : PowerUp {
    //Floats holding default values for how much the Speed Power Up boosts the player
    PlayerController PController;

    int newMaxJumps = 2;
    public float duration = 10f;
    public bool poweredUp = false;
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
        //Makes two jumps available to the player
        //Also currently changes the player's material to indicate that they're powered up

        //Changes Material back to the previous one
        if(poweredUp == false)
        { 
            powerupAudioSource.PlayOneShot(collectAudioClip);

            PController = player.GetComponent<PlayerController>();
            oldMaterial = PController.gameObject.GetComponent<Renderer>().material;

            PController.GetComponent<Renderer>().material = newMaterial;
            PController.MaxJumps = newMaxJumps;
            PController.CurrentJumps = 1;


            poweredUp = true;

            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    void RevertStats()
    {
        //Reverts all changes the power-up made to the player
        PController.GetComponent<Renderer>().material = oldMaterial;
        PController.MaxJumps = 1;
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
            duration = 10f;
            destroyPowerUp();
        }
    }
}