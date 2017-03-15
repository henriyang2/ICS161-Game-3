using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 450f;
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

    private Rigidbody2D rb2d;

    private bool grounded1;
    private bool grounded2;
    private bool grounded3;

    private AudioSource playerAudioSource;

    void Awake()
    {
        //Get references
        rb2d = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    void Update()
    {
        //Linecast to check if player is on ground
        //3 linecasts for more accurate ground checks
        grounded1 = Physics2D.Linecast(transform.position, groundCheck1.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded2 = Physics2D.Linecast(transform.position, groundCheck2.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded3 = Physics2D.Linecast(transform.position, groundCheck3.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        //If Player pressed W and is grounded, jump
        if (Input.GetButtonDown(PLAYER_INPUT_JUMP_STRING) && (CurrentJumps >= 1))
        {
            jump = true;
            playerAudioSource.PlayOneShot(jumpAudioClip);
        }
        
        if (grounded1 || grounded2 || grounded3)
            CurrentJumps = MaxJumps;

    }

    void FixedUpdate()
    {
        //Variable to hold horizontal GetAxis value
        float horizontalInputValue;

        //If Player  is holding down A or D buttons to move
        horizontalInputValue = Input.GetAxis(PLAYER_INPUT_HORIZONTAL_AXIS_STRING);


        rb2d.velocity = new Vector2(horizontalInputValue * moveSpeed * Time.deltaTime, rb2d.velocity.y);


        //Set y velocity directly to perform the jump
        if (jump)
        {
            CurrentJumps -= 1;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce * Time.deltaTime);

            jump = false;
        }
    }
}
