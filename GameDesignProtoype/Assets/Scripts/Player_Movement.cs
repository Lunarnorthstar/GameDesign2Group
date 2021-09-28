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

    private float moveDir;
    private Rigidbody2D myRB;
    private bool canJump;
    private SpriteRenderer mySprite;
    private bool canMove;
    private string objectName;
    private bool isActive;

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
        }

        if (moveDir < 0)
        {
            mySprite.flipX = true;
        }
        var moveAxis = Vector2.right * moveDir;

        if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        }

        if (groundCheck.IsTouchingLayers(groundLayers) && canMove == true)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        //I have no idea, naomi made this part
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
    }


}