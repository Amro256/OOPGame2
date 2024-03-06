using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float horzDirection;
    float vertdirection;
    private BoxCollider2D coll; //Reffernece to box collider on player
    [SerializeField] float speed = 5;
    Rigidbody2D playerRigidBody;
    private SpriteRenderer sr;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] LayerMask Groundlayer;
    [SerializeField] TrailRenderer tril; //Refernece to the TrailRenderer component
    private bool facingRight = true; //When the game intially starts the player is facing right  
    private bool DoubleJump;
    private bool dash = true;
    private bool isDashing;
    private float dashPower = 10f;
    private float dashTime = 0.2f;
    private float dashCoolDown = 1;
    private Animator ani; //Refenrece to the Animator
    [SerializeField] AudioManger am; //Refernece to the AudioManger script

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        tril = GetComponent<TrailRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing) //Checks if dashing is true
        {
            return; //Prevents the player movement and jump from impacting the dash.
        }
        //Input
        horzDirection = Input.GetAxisRaw("Horizontal");
        vertdirection = Input.GetAxisRaw("Vertical");

        playerRigidBody.velocity = new Vector2(horzDirection * speed, playerRigidBody.velocity.y);

        if(horzDirection > 0 && !facingRight) //If moving to the right and player is not facing right then flip player & Plays animations
        {
            FlipPlayer(); //Calling the function
            ani.Play("PlayerWalk");
            
        }
        else if(horzDirection < 0 && facingRight) //if moving to the left and facing right then flip the player &plays animation
        {
            FlipPlayer();
            ani.Play("PlayerWalk");
           
        }

        if(Input.GetButtonDown ("Jump"))
        {
            
            if(IsGounded()) //if player is grounded allow them to jump & double jump
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
                DoubleJump = true; //Sets double jump to true
                ani.Play("PlayerJump"); //Plays jump animation
                am.PlayerJumpSound(); //Plays jump sounds
            }
            else if(DoubleJump) //Checks if the player is already double jumping
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
                DoubleJump = false; //Then set it to false 
            } 
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && dash) //Checks for input and if dash is true
        {
            am.PlayerDashSound();
            StartCoroutine(dashMovement());
        }
    }

    void FlipPlayer() //Deal with the character flipping
    {
        facingRight = !facingRight; // Setting face right to the oppsoite of what it is currently.
        transform.Rotate(0f,180f,0f); //Rotates the player 180 on the y-axis
        
    }
    bool IsGounded() //Returns a bool to check if the player is grounded or not
    {
        ani.Play("PlayerIdle");
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Groundlayer); //Creates a small box under the original box collider to detect is the player is on the ground
    
    }

     IEnumerator dashMovement()
    {
        dash = false;
        isDashing = true;
        float oggravity = playerRigidBody.gravityScale; //Stores the original gravity
        playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * dashPower; //Allows the player to dash in all directions. Even Diagonally
        tril.emitting = true; //Enables the trail effect
        yield return new WaitForSeconds(dashTime);
        tril.emitting = false; //Disables the trail effect
        playerRigidBody.gravityScale = oggravity; //Revers back to the original gravity scale
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown); //Wait for the cooldown before allowing the player to dash again
        dash = true;
    }

    void FixedUpdate()
    {
        if(isDashing) //Checks if isDashing is true
        {
            return;
        }
    }
}
 
