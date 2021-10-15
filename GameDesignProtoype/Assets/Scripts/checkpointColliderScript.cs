using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointColliderScript : MonoBehaviour //This script handles setting the player's checkpoint position. Goes on the trigger object. Dependencies; checkPoint.
{
    public float X; //
    public float Y; // These temporarily store a position, in this case the position of the player.

    private void OnTriggerEnter2D(Collider2D other) //When something touches you...
    {
        if (other.gameObject.CompareTag("Player")) //If it's the player...
        {
            X = GameObject.Find("Player").transform.position.x; //
            Y = GameObject.Find("Player").transform.position.y; //Get that object's position and remember it.
            
            GameObject.Find("Player").SendMessage("CPsetX", X); //
            GameObject.Find("Player").SendMessage("CPsetY", Y); //Set that object's CheckPoint position to its current position.
            //Couldn't we just make 1 function with 2 input variables?
        }
    }
}
