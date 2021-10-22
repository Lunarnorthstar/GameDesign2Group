using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour //This script handles the movement of the active character. Goes on all characters. Dependencies; CollectMinion.
{
    [SerializeField] private float moveSpeed, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private bool cancelJumpEnabled;

   
    private float moveDir; //The direction you are moving in
    private Rigidbody2D myRB; //Your rigidbody
    private bool canJump; //Whether or not you can jump
    private SpriteRenderer mySprite;//Your sprite component
    private bool canMove; //Whether or not you can move
    private string objectName; //Your name
    private bool isActive = true; //Whether or not You are "active"; Whether you can be controlled and move.
    private bool isActivatable = true; //This gets set to false if You are a minion and You touch the deathplane.
    Animator anim; //sets a variable called anim of type Animator
    float currentSpeed; //this will be used to check for the horizontal velocity of the Rigidbody2D
    float upSpeed;//this will be used to check for the vertical velocity of the Rigidbody2D
    public Transform animatorTransform;

    private void Start()
    {
        
        myRB = GetComponent<Rigidbody2D>();
        mySprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>(); //getcomponent Animator and assigns it to anim

        if (!gameObject.CompareTag("Player"))
        {
            canMove = false;
            isActive = false;
        }

        //this code checks the tag of the game object, if the object is the player it can move right away and it's active, if it's not the player canMove is set to false
    }


    private void FixedUpdate()
    {
        /*
        if (moveDir > 0)
        {
            mySprite.flipX = false;
        }//Unflip your sprite if moving right

        if (moveDir < 0)
        {
            mySprite.flipX = true;
        }//Flip your sprite if moving left
        */
        var moveAxis = Vector2.right * moveDir;

        if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        } //Moves you.

        if (groundCheck.IsTouchingLayers(groundLayers) && canMove == true)
        {
            canJump = true;
            anim.SetBool("grounded", true);
        } //If you're touching the ground you can jump, otherwise you can't.
        else
        {
            canJump = false;
            anim.SetBool("grounded", false);
        }

        //Anim Stuff
        currentSpeed = myRB.velocity.x; //sets currentSpeed variable to the current horizontal velocity of the rigidbody

        //float moveH = Input.GetAxis("Horizontal"); //checks input axis on the horizontal, so A, D or arrow left right buttons. will also work with a controller

        //this following if/else statement checks to see if the user pressed the right/left buttons, and tells the Animator if the right button has been pressed or the left
        if (moveDir > 0)
        {
            mySprite.flipX = false; //flips the gameobject to -1 scale. Depending on which direction your gameobject started off, the -1 may need to be 1 instead
        }
        else if (moveDir < 0)
        {
            mySprite.flipX = true;

        }

        anim.SetFloat("speed", (Mathf.Abs(currentSpeed))); //checks the currentspeed and outputs the value as speed of the animator. move is added so if trying to move against a wall, it will still play animation, as it will detect the keypres

        //Jump Anim
        float moveup = Input.GetAxis("Vertical"); //checks input axis on the vertical
        upSpeed = myRB.velocity.y; //checks what the current vertical speed of the player is, and sets the float upSpeed to that value
        anim.SetFloat("vSpeed", (upSpeed + moveup)); //tells the animator what the current vertical speed of the player is, in the form of a float called verticalSpeed. if positive, is moving up, negative, is falling

    }

        public void Move(InputAction.CallbackContext context)
    {
        if (canMove == true)
        {
            moveDir = context.ReadValue<float>();
        }
        else {
            moveDir = 0;
        }
        //if the gameObject canMove is true, the object is able to move

    }

    public void Move(float moveAmt)
    {
        if (canMove == true)
        {
            moveDir = moveAmt;
        }
        else { }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (canJump && canMove)
        {
            if (context.started)
            {
                myRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                
                canJump = false;
                anim.SetBool("grounded", false);
            }
        }

        if (context.canceled && cancelJumpEnabled)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
        }
    }



    public void ActivateMovement()
    {
        //this get called from the Change_Character script, it sets the gameObject canMove state to true if the object isActive is true
        if (isActive == true)
        {
            canMove = true;
        }
    }
    public void DeactivateMovement()
    {
        //this get called from the Change_Character script, it sets the gameObject canMove state to false
        canMove = false;
    }

    public void ActivateMinion()
    {
        //this get called from the CollectMinion script, when the player enters the trigger zone, the minion is set to active
        if (isActivatable)
        {
            isActive = true;
            gameObject.SendMessage("Activate", null, SendMessageOptions.DontRequireReceiver);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
    
    public void DeactivateMinion()
    {
        //this get called from the Killzone script, when the minion enters the death zone, the minion is set to inactive
        isActive = false;
        isActivatable = false; //Also makes them unable to be reactivated.
        gameObject.SendMessage("Deactivate");
        DeactivateMovement(); //Deactivates their movement.

        gameObject.transform.GetChild(3).gameObject.SetActive(false); //kills all their momentum.
    }

   


}