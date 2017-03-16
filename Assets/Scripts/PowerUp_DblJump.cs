using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_DblJump : PowerUp {
    //Floats holding default values for how much the Speed Power Up boosts the player
    PlayerController PController;

    int newMaxJumps = 2;
    public float duration = 10f;
    float timer;
    public bool poweredUp = false;
    Material oldMaterial;
    public Color oldColor;
    public AudioClip collectAudioClip;

    private AudioSource powerupAudioSource;
    private ParticleSystem PSystem;

    void Awake ()
    {
        powerupAudioSource = GetComponent<AudioSource>();
        PSystem = GetComponentInChildren<ParticleSystem>();
        PSystem.Stop();
        timer = duration;
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
            oldColor = PController.gameObject.GetComponent<Renderer>().material.color;

            

            PController.GetComponent<Renderer>().material.color = Color.yellow;
            PController.MaxJumps = newMaxJumps;
            PController.CurrentJumps = 1;


            poweredUp = true;
            PSystem.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    void RevertStats()
    {
        //Reverts all changes the power-up made to the player
        PController.GetComponent<Renderer>().material.color = oldColor;
        PController.MaxJumps = 1;
        poweredUp = false;
    }

    void Update()
    {
        if (poweredUp)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            RevertStats();
            timer = duration;
            destroyPowerUp();
        }
    }
}