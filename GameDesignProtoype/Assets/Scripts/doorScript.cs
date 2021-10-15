using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class doorScript : MonoBehaviour //This script handles the opening (and potential closing) of doors throughout the level. Goes on the button. Dependencies; None.
{
    public Boolean IsToggleDoor = false;
    public GameObject door;
    public SpriteRenderer myButton;
    public Sprite buttonOn;
    public Sprite buttonOff;

    void Start()
    {
        //myButton = GetComponent<SpriteRenderer>(); //I'm not sure why this line is here. I'll comment it out for now but won't delete it because even though it seems useless it might somehow end up essential...
    }

    private void OnTriggerEnter2D(Collider2D other) //When something bumps into you...
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Minion1") || other.gameObject.CompareTag("Minion2") || other.gameObject.CompareTag("Minion3")) //If that something is a player character...
        {
            myButton.sprite = buttonOn; //Change the button's sprite to its "on" state.
            door.SetActive(false); //Make the door go away
        } //I do wish there were a more compact way to write that if statement...
    } //NOTABLE; In the event that we expect the player to move multiple player characters near a button, this may cause issues because the OnTriggerExit funtion will reactivate the door even though the button is still in contact.
    //To fix this we would need to change this from OnTriggerEnter to OnTriggerStay or something, but currently it's not an issue.

    private void OnTriggerExit2D(Collider2D other) //When stuff stops bumping into you...
    {
        if (IsToggleDoor == true) //If a box in the editor is checked...
        {
            door.SetActive(true); //Re-enable the door.
            myButton.sprite = buttonOff; //Change the button's sprite to its "off" state.
        }
    }
}