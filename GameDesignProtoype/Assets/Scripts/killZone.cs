using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killZone : MonoBehaviour //This script handles the kill zone and everything relating to it. Goes on the object set as the deathzone trigger. Dependencies; changeColor, Player_Movement, checkPoint.
{
    public GameObject minionDead1; //
    public GameObject minionDead2; //
    public GameObject minionDead3; //These three store the minions in the event that they die. They need to be stored like this because of a change in the tag that was used to indentify them.
    private bool tempactive = true; //Whether or not the death zone is active.
    public bool permanent = false; //Whether or not the death zone is permanent. Set in editor.

    void Start()
    {
        minionDead1 = GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject; //
        minionDead2 = GameObject.Find("Minion (2)").gameObject.transform.GetChild(0).gameObject; //Find and keep track of each of the minions. No other script does this because it's intended that the minions stop
        minionDead3 = GameObject.Find("Minion (3)").gameObject.transform.GetChild(0).gameObject; //Functioning completely after dying.
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
                GameObject.FindWithTag("Minion1").GetComponent<AudioSource>().volume = 0.0f; //Turn off their related music component.
                GameObject.FindWithTag("Minion1").SendMessage("DeactivateMinion"); //Deactivate the minion entirely.
                minionDead1.SendMessage("changeColorDead"); //Set their color to "dead"
                tempactive = false; //This and other duplicate lines deactivate the death plane, but only when the minions touch it.
                if (!permanent) //If the deathplane is not permanent...
                {
                    gameObject.SetActive(false); //Remove it.
                }

                other.gameObject.tag = "Dead"; //Set the minion's tag to "Dead". This will cause all other scripts to lose track of it, which is intentional.
            }

            if (other.gameObject.CompareTag("Minion2")) //This is the same as the above, but for minion 2.
            {
                GameObject.FindWithTag("Minion2").GetComponent<AudioSource>().volume = 0.0f;
                GameObject.FindWithTag("Minion2").SendMessage("DeactivateMinion");
                minionDead2.SendMessage("changeColorDead");
                tempactive = false;
                if (!permanent)
                {
                    gameObject.SetActive(false);
                }
                other.gameObject.tag = "Dead";
            }

            if (other.gameObject.CompareTag("Minion3")) //Again, same as above but for minion 3.
            {
                GameObject.FindWithTag("Minion3").GetComponent<AudioSource>().volume = 0.0f;
                GameObject.FindWithTag("Minion3").SendMessage("DeactivateMinion");
                minionDead3.SendMessage("changeColorDead");
                tempactive = false;
                if (!permanent)
                {
                    gameObject.SetActive(false);
                }
                other.gameObject.tag = "Dead";

            }

            
        }
    }
}