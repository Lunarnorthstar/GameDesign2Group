using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
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
    private bool isActive; //Whether or not You are "active"; Whether you can be controlled and move.

    private void Start()
    {
        
        myRB = GetComponent<Rigidbody2D>();
        mySprite = GetComponentInChildren<SpriteRenderer>();
        objectName = gameObject.name;
        if (objectName == "Player")
        {
            
            canMove = true;
            isActive = true;
        }
        else
        {
            canMove = false;
            isActive = false;
        }
        //this code checks the tag of the game object, if the object is the player it can move right away and it's active, if it's not the player canMove is set to false
    }


    private void FixedUpdate()
    {
        if (moveDir > 0)
        {
            mySprite.flipX = false;
        }//Unflip your sprite if moving right

        if (moveDir < 0)
        {
            mySprite.flipX = true;
        }//Flip your sprite if moving left
        var moveAxis = Vector2.right * moveDir;

        if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        } //Moves you.

        if (groundCheck.IsTouchingLayers(groundLayers) && canMove == true)
        {
            canJump = true;
        } //If you're touching the ground you can jump, otherwise you can't.
        else
        {
            canJump = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (canMove == true)
        {
            moveDir = context.ReadValue<float>();
        }
        else { }
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
        if (canJump)
        {
            if (context.started)
            {
                myRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
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
        isActive = true;

        gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

   


}