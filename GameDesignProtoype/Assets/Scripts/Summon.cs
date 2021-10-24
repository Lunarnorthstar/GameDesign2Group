using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Summon : MonoBehaviour //This script handles the teleportation of the minions to the main player. Goes on the minions. Dependencies; None.
{
    private float Xpos; //
    private float Ypos; //Stores a position, in this case the position of the main player.

    private bool active = false; //Whether the minion is active or not.


    void Update()
    {
        Xpos = GameObject.Find("Player").transform.position.x; //
        Ypos = GameObject.Find("Player").transform.position.y; //Sets the stored position to the player's position.
    }



    public void Activate() //This activates the host.
    {
        active = true; //Which it does right here.
    }
    
    public void Deactivate() //And same thing but deactivating.
    {
        active = false;
    }
    
    public void Call(InputAction.CallbackContext context) //When the player presses the relevant key...
    {
        if (active) //If the host is active/collected and thus can be summoned...
        {
            transform.position = new Vector3(Xpos, Ypos); //Set the host's position to the main player's position. Clipping and/or shoving may ensue.
        }
    }

    public void OutOfBounds() //When the player presses the relevant key...
    {
        if (active) //If the host is active/collected and thus can be summoned...
        {
            transform.position = new Vector3(Xpos, Ypos); //Set the host's position to the main player's position. Clipping and/or shoving may ensue.
        }
    }
}
