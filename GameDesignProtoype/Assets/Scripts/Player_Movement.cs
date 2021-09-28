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

    }

    public void Move(InputAction.CallbackContext context)
    {
        if (canMove == true)
        {
            moveDir = context.ReadValue<float>();
        }
        else { }

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
        if (isActive == true)
        {
            canMove = true;
        }
    }
    public void DeactivateMovement()
    {
        canMove = false;

    }

    public void ActivateMinion()
    {
        isActive = true;
    }


}
