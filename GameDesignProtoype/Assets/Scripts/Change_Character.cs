using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Character : MonoBehaviour //This script handles the changing and changeability of characters. Goes on all characters. Dependencies; Player_Movement
{
    public GameObject playerCam; //
    public GameObject minionCam1; //
    public GameObject minionCam2; //
    public GameObject minionCam3; //These first four are assigned to the cameras that track each character. This keeps track of them so they can be switched between.
    public GameObject minionCall1; //
    public GameObject minionCall2; //
    public GameObject minionCall3; //These three are the assigned to the minions. This keeps track of them so that they can be switched between.
    public bool canChangeTo1 = true; //
    public bool canChangeTo2 = false; //
    public bool canChangeTo3 = false; //
    public bool canChangeTo4 = false; //These four keep track of whether the player can switch to a given character.
    public GameObject playerTag; //
    public GameObject minionTag1; //
    public GameObject minionTag2; //
    public GameObject minionTag3; //These four are assigned the name tags for the characters. This is so they can be disabled to reduce screen clutter.

    void Start() //At start of game...
    {
        minionCall1 = GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject;//
        minionCall2 = GameObject.Find("Minion (2)").gameObject.transform.GetChild(0).gameObject;//
        minionCall3 = GameObject.Find("Minion (3)").gameObject.transform.GetChild(0).gameObject;//Find the objects tagged as minions and automatically assign them.
    }

    public void TurnChangeOn(int number) //This function enables switching between characters.
    {
        switch(number) //Given the number number...
        {
            case 1: //If it's 1...
                canChangeTo1 = true; //Activate the changeability of minion 1 (player character).
                break; //And stop.
            case 2: //If it's 2...
                canChangeTo2 = true; //Activate the changeability of minion 2.
                break; //And stop.
            case 3: //If it's 3...
                canChangeTo3 = true; //Activate the changeability of minion 3.
                break; //And stop.
            case 4: //If it's 4...
                canChangeTo4 = true; //Activate the changeability of minion 4.
                break;
            default:
                break;


        }

    }
    public void TurnChangeOff(int number) //This function disables switching between characters.
    {
        switch (number) //Given the number number...
        {
            case 1: //This is all basically the opposite of the above function.
                canChangeTo1 = false;
                break;
            case 2: //Do I really have to write it all out again?
                canChangeTo2 = false;
                break;
            case 3: //I mean I did volunteer for this...
                canChangeTo3 = false;
                break;
            case 4: //Whatever. Just look at the above function and imagine that but in reverse.
                canChangeTo4 = false;
                break;
            default:
                break;


        }

    }
    public void ChangeCharacter1() //This function handles changing back to the player.
    {
        if (canChangeTo1 == true) //If changing is enabled...
        {
            gameObject.SendMessage("DeactivateMovement"); //Deactivate the host's movement.
            GameObject.Find("Player").SendMessage("ActivateMovement"); //Find the player and tell it to enable movement.
            playerCam.SetActive(true); //Set the player's camera to active.
            minionCam1.SetActive(false); //
            minionCam2.SetActive(false); //
            minionCam3.SetActive(false); //Set all other cameras to inactive.
            minionCall1.SendMessage("changeColorOff"); //
            minionCall2.SendMessage("changeColorOff"); //
            minionCall3.SendMessage("changeColorOff"); //Set the color of all minions to their inactive color.
            playerTag.SetActive(true); //Set the host's name tag to be active.
            minionTag1.SetActive(false); //
            minionTag2.SetActive(false); //
            minionTag3.SetActive(false); //Set all the other minion's name tags to be inactive.
        }
    }
    public void ChangeCharacter2() //This function handles swapping to the second character, A.K.A. the first minion.
    {
        if (transform.CompareTag("Minion1")) //If this object is minion 1...
        {
            if (canChangeTo2 == true) //If it has been "collected", meaning it can be changed to...
            {
                gameObject.SendMessage("DeactivateMovement"); //Deactivate the host's movement.
                GameObject.Find("Player").SendMessage("DeactivateMovement"); //Deactivate the player's movement.
                Debug.Log(minionCall1.name); //Quick debug message
                GameObject.Find("Minion (1)").SendMessage("ActivateMovement"); //Find minion 1 and activate it's movement
                minionCall1.SendMessage("changeColorOn"); //Tell minion 1 to change to its active color.
                minionCall2.SendMessage("changeColorOff"); //
                minionCall3.SendMessage("changeColorOff"); //Tell the other minions to change to their inactive colors.
                playerCam.SetActive(false); //
                minionCam1.SetActive(true); //
                minionCam2.SetActive(false); //
                minionCam3.SetActive(false); //Set minion 1's camera to active, and all others to inactive.
                playerTag.SetActive(false); //
                minionTag1.SetActive(true); //
                minionTag2.SetActive(false); //
                minionTag3.SetActive(false); //Set minion 1's name tag to be active and all others to be inactive.
            }
        } //Note that as far as I'm aware (And I didn't write this part) this if statement is redundant functionally. It does seem to help performance by preventing the same code from pointlessly running multiple times.
    }
    public void ChangeCharacter3() //This function handles swapping to the third character, minion 2.
    {

        if (transform.CompareTag("Minion2")) //All of this function is effectively a copy-paste of the above ChangeCharacter2 function.
        {
            if (canChangeTo3 == true) //The only real difference is that minion 2 is what's being activated instead of minion 1.
            {
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                gameObject.SendMessage("DeactivateMovement");
                GameObject.Find("Minion (2)").SendMessage("ActivateMovement");
                playerCam.SetActive(false);
                minionCam1.SetActive(false);
                minionCam2.SetActive(true);
                minionCam3.SetActive(false);
                GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject.SendMessage("changeColorOff", gameObject.name);
                minionCall1.SendMessage("changeColorOff");
                minionCall2.SendMessage("changeColorOn");
                minionCall3.SendMessage("changeColorOff");
                playerTag.SetActive(false);
                minionTag1.SetActive(false);
                minionTag2.SetActive(true);
                minionTag3.SetActive(false);
            }
        }
    }
    public void ChangeCharacter4() //This function handles swapping to the fourth character, minion 3.
    {

        if (transform.CompareTag("Minion3")) //This function is effectively identical to ChangeCharacter2 and 3.
        {
            if (canChangeTo4 == true) //See above for explanations, with the exception is that this time minion 3 is the activated character.
            {
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                gameObject.SendMessage("DeactivateMovement");
                GameObject.Find("Minion (3)").SendMessage("ActivateMovement");
                playerCam.SetActive(false);
                minionCam1.SetActive(false);
                minionCam2.SetActive(false);
                minionCam3.SetActive(true);
                GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject.SendMessage("changeColorOff", gameObject.name);
                minionCall1.SendMessage("changeColorOff");
                minionCall2.SendMessage("changeColorOff");
                minionCall3.SendMessage("changeColorOn");
                playerTag.SetActive(false);
                minionTag1.SetActive(false);
                minionTag2.SetActive(false);
                minionTag3.SetActive(true);
            }
        }
    }
}
