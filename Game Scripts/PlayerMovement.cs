using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animate;

    [SerializeField] private LayerMask jumpableGround;
    private float X_Direction = 0;
    [SerializeField]private float movespeed = 7f;
    [SerializeField] private float jumpforce = 14f;//SerializeField, allows me to change these variables in unity runtime, so I dont have to keep going to the script
                                                        //Making Development easier.

    private enum MovementState {Idle,Running,Jumping,Falling}
    [SerializeField] private AudioSource jumpSound;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        X_Direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(X_Direction * movespeed,rb.velocity.y);
        //Console.WriteLine(X_Direction);
        

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce); //Assiging the jump action to take place if the Jump key has been pressed
        }                                                  // Jump key is asigned in the Unity IDE , Not in the script

        AnimationUpdate();



    }
    private void AnimationUpdate()
    {

        MovementState state;
        //Controlling when the Running animation is applied to the player.
        if (X_Direction > 0f) 
        {
            state = MovementState.Running;  //If the player has some velocity, then I am applying the Run animation.
            sprite.flipX = false;                // If the player velocity is positive meaning moving right, then flip the characters direction.
        }   
        else if (X_Direction < 0f)
        {
            state = MovementState.Running; // Same again here, if the player is in motion, then apply the run animation.
            sprite.flipX = true;                // If the player velocity is negative meaning moving left, then flip the characters direction.
        }
        else
        {
            state = MovementState.Idle; //if the player has no velocity, then dont run the Run animaiton.
        }
        if (rb.velocity.y > .1f) //Checking if the player is jumping by cheching the Y velocity
        { 
            state = MovementState.Jumping; // If player is jumping change animation state to Jumping
        }
        else if (rb.velocity.y < -.1f) // Checking if player is falling by checking for negative Y Velocity
        {
            state = MovementState.Falling;// if player is falling, update animation to Falling animation.
        }


        

        animate.SetInteger("state", (int)state);
    }

    private bool Grounded() {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    } 
        
}
