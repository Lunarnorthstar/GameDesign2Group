using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lightKillzone : MonoBehaviour //This script handles the kill zone and everything relating to it. Goes on the object set as the deathzone trigger. Dependencies; changeColor, Player_Movement, checkPoint.
{

    private bool tempactive = true; //Whether or not the death zone is active.
    public bool permanent = true; //Whether or not the death zone is permanent. Set in editor.

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //When something bumps you...
    {
        if (tempactive || permanent) //If the deathplane hasn't been deactivated or is always active
        {
            if (other.gameObject.CompareTag("Player")) //If you were bumped by the main player...
            {
                GameObject.Find("Player").SendMessage("gotoCP"); //Tell the main player to go to their checkpoint.
            }

            if (other.gameObject.CompareTag("Minion1")) //If it was minion 1...
            {
                other.gameObject.SendMessage("OutOfBounds");
            }

            if (other.gameObject.CompareTag("Minion2")) //This is the same as the above, but for minion 2.
            {
                other.gameObject.SendMessage("OutOfBounds");
            }

            if (other.gameObject.CompareTag("Minion3")) //Again, same as above but for minion 3.
            {
                other.gameObject.SendMessage("OutOfBounds");

            }


        }
    }
}