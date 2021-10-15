using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pickup : MonoBehaviour //This script handles the collection of powerup/colelctible items. Goes on the item. Dependencies; None. Currently Unused.
{
    [SerializeField] private Collider2D playerCheck;
    [SerializeField] private LayerMask playerLayers;
    [SerializeField] private GameManager manager;
    [SerializeField] private int scoreToGive = 100;


    private void Update()
    {
        if (playerCheck.IsTouchingLayers(playerLayers))
        {
            
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.RespawnPlayer();
        }
    }
} //Commenting this would be a waste of time since I doubt we'll use anything in its current state.