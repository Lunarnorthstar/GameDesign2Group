using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMinion : MonoBehaviour //This script handles the collection and activation of each minion when the player touches it. Goes on the minion. Dependencies; Player_Movement, Change_Character.
{
    private bool Collided; //Keeps track of whether the host minion has been collected already.

    private void OnTriggerEnter2D(Collider2D other) //When something touches it...
    {
        if (other.gameObject.tag == "Player") //If it's the player...
        {
            if (Collided == true) //If it has been collected...
            {
                //Do nothing.
            }
            else //If it hasn't been collected...
            {
                GameObject.Find("Minion (1)").SendMessage("TurnChangeOff", 2);//
                GameObject.Find("Minion (2)").SendMessage("TurnChangeOff", 3);//
                GameObject.Find("Minion (3)").SendMessage("TurnChangeOff", 4);// Temporarily prevent the player from changing characters (Change_Character)...
                gameObject.SendMessage("ActivateMinion");
                
                GameObject.Find("Player").SendMessage("DeactivateMovement"); //Temporarily deactivate all movement (Player_Movement)...
                
                Collided = true; //Set this minion to be collected so this doesn't happen again
                gameObject.GetComponent<AudioSource>().volume = 1.0f; //Activate the minion's relevant audio track.
            }
        }

    }
}
