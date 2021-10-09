using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This goes on the BUTTON, not the DOOR
public class doorScript : MonoBehaviour
{
    public Boolean IsToggleDoor = false;
    public GameObject door;
    public SpriteRenderer myButton;
    public Sprite buttonOn;
    public Sprite buttonOff;

    void Start()
    {
        myButton = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Minion1") || other.gameObject.CompareTag("Minion2") || other.gameObject.CompareTag("Minion3")) //If the player bumps into you...
        {
            myButton.sprite = buttonOn;
            door.SetActive(false); //Make door go away
        } //Apparently the separate tags for each minion were necessary. I don't know why as of writing this comment, but I was told it was necessary to have a unique tag on each minion.
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsToggleDoor == true) //If a box in the editor is checked...
        {
            door.SetActive(true); //Come back when they stop bumping you
            myButton.sprite = buttonOff;
        }
    }
}