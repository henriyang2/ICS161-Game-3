using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float moveForce = 80f;
    public float maxSpeed = 5f;
    public bool jump = false;
    public float jumpForce = 18f;

    public GameObject groundCheck1;
    public GameObject groundCheck2;
    public GameObject groundCheck3;

    public string PLAYER_INPUT_HORIZONTAL_AXIS_STRING;
    public string PLAYER_INPUT_JUMP_STRING;

    private Rigidbody2D rb2d;

    private bool grounded1;
    private bool grounded2;
    private bool grounded3;

    void Awake ()
    {
        //Get references
        rb2d = GetComponent<Rigidbody2D>();
    }

	void Start () 
    {
		
	}
	
	void Update () 
    {
        //Linecast to check if player is on ground
        //3 linecasts for more accurate ground checks
        grounded1 = Physics2D.Linecast(transform.position, groundCheck1.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded2 = Physics2D.Linecast(transform.position, groundCheck2.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded3 = Physics2D.Linecast(transform.position, groundCheck3.transform.position, 1 << LayerMask.NameToLayer("Ground"));

            //If Player pressed W and is grounded, jump
            if (Input.GetButtonDown(PLAYER_INPUT_JUMP_STRING) && (grounded1 || (grounded2 || grounded3)))
            {
                jump = true;
            }
        
	}

    void FixedUpdate ()
    {
        //Variable to hold horizontal GetAxis value
            float horizontalInputValue;

            //If Player 1 is holding down A or D buttons to move
            horizontalInputValue = Input.GetAxis(PLAYER_INPUT_HORIZONTAL_AXIS_STRING);

            //If Player is no longer holding down A or D buttons, stop
            if (horizontalInputValue == 0f)
            {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
                rb2d.angularVelocity = 0f;
            }

            //If Player x velocity is lesser than max speed, keep adding speed
            if (horizontalInputValue * rb2d.velocity.x < maxSpeed)
            {
                rb2d.AddForce(Vector2.right * horizontalInputValue * moveForce);
            }

            //If Player x velocity is greater than max speed, set player velocity directly to max speed 
            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
            }

            //Set y velocity directly to perform the jump
            if (jump)
            {
                jump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
    }
}
