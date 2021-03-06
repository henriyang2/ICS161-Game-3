﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 300f;
    public bool jump = false;
    public float jumpForce = 1000f;

    public GameObject groundCheck1;
    public GameObject groundCheck2;
    public GameObject groundCheck3;

    public string PLAYER_INPUT_HORIZONTAL_AXIS_STRING;
    public string PLAYER_INPUT_JUMP_STRING;

    public int MaxJumps = 1;
    public int CurrentJumps = 1;

    public AudioClip jumpAudioClip;
    public AudioClip hitAudioClip;

    private string GROUND_LAYER_NAME = "Ground";
    private string PLATFORM_TAG_NAME = "Platform";

    private Rigidbody2D rb2d;
    private Animator animation;

    private bool grounded1;
    private bool grounded2;
    private bool grounded3;

    //For adjusting layer collisions only once each time in FixedUpdate
    private bool ignoreGroundCollision = false;

    private AudioSource playerAudioSource;

    public bool has_power = false;

    private bool faceRight;

    void Awake()
    {
        //Get references
        rb2d = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
        animation = GetComponent<Animator>();

        //To prevent the bug that makes player fall through from happening
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer(GROUND_LAYER_NAME), false);
    }

    void Start()
    {
        faceRight = true;
    }

    void Update()
    {
        //Check if the player's stats are normal, if they are but their color isn't white, change it back to white
            //This is a workaround for when a player is affected by both Slow and another PowerUp, but when both are over they're
            //still not the default color
        if (moveSpeed == 300f && MaxJumps == 1)
        {
            GetComponent<Renderer>().material.color = Color.white;
            has_power = false;
        }
        //Linecast to check if player is on ground
        //3 linecasts for more accurate ground checks
        //grounded1 = Physics2D.Linecast(transform.position, groundCheck1.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        //grounded2 = Physics2D.Linecast(transform.position, groundCheck2.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        //grounded3 = Physics2D.Linecast(transform.position, groundCheck3.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        //If Player pressed W and is grounded, jump
        if (Input.GetButtonDown(PLAYER_INPUT_JUMP_STRING) && (CurrentJumps >= 1))
        {
            
            jump = true;
            playerAudioSource.PlayOneShot(jumpAudioClip);
        }

        if (grounded1)
        {
            animation.SetBool("onGround", true);
            CurrentJumps = MaxJumps;
        }
        else
        {
            animation.SetBool("onGround", false);
        }

    }

    void FixedUpdate()
    {
        //Variable to hold horizontal GetAxis value
        float horizontalInputValue;

        //If Player  is holding down A or D buttons to move
        horizontalInputValue = Input.GetAxis(PLAYER_INPUT_HORIZONTAL_AXIS_STRING);

        if (horizontalInputValue < 0)
        {
            animation.SetBool("isMoving", true);
            faceRight = false;
            transform.localScale = new Vector3(-0.75f, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInputValue > 0)
        {
            animation.SetBool("isMoving", true);
            faceRight = true;
            transform.localScale = new Vector3(0.75f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            animation.SetBool("isMoving", false);
        }

        rb2d.velocity = new Vector2(horizontalInputValue * moveSpeed * Time.deltaTime, rb2d.velocity.y);


        //Set y velocity directly to perform the jump
        if (jump)
        {
            CurrentJumps -= 1;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce * Time.deltaTime);

            jump = false;
        }

        if (rb2d.velocity.y > 0)
        {
            if (!ignoreGroundCollision)
            {
                Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer(GROUND_LAYER_NAME), true);
                ignoreGroundCollision = true;
            }
        }
        else
        {
            if (ignoreGroundCollision)
            {
                Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer(GROUND_LAYER_NAME), false);
                ignoreGroundCollision = false;
            }
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == PLATFORM_TAG_NAME)
        {
            grounded1 = true;
        }
        if (collision.gameObject.tag == "bullet")
        {
            playerAudioSource.PlayOneShot(hitAudioClip);
        }
    }

    void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.tag == PLATFORM_TAG_NAME)
        {
            grounded1 = false;
        }
    }

    public bool GetDirection()
    {
        return faceRight;
    }
}
